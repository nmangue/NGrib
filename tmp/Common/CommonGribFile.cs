using System.Text;
using NGrib.Common.Adapters;
using NGrib.Grib1;
using NGrib.Grib2;

namespace NGrib.Common;

public class CommonGribFile : IGribFile
{
    private readonly Grib1FileAdapter _grib1File = new(new Grib1File());
    private readonly Grib2FileAdapter _grib2File = new(new Grib2File());


    public static bool SeekHeader(Stream raf, long stop, out long startOffset)
    {
        // seek header
        StringBuilder hdr = new StringBuilder();
        int match = 0;
        startOffset = -1;

        while (raf.Position < stop && raf.Position<raf.Length)
        {
            // code must be "G" "R" "I" "B"
            char c = (char) raf.ReadByte();

            hdr.Append((char) c);
            switch (c)
            {
                case 'G':
                    match = 1;
                    startOffset = raf.Position - 1;
                    break;
                case 'R' when (match == 1):
                    match = 2;
                    break;
                case 'I' when (match == 2):
                    match = 3;
                    break;
                case 'B' when (match == 3):
                    return true;
                default:
                    match = 0; /* Needed to protect against "GaRaIaB" case. */
                    break;
            }
        }

        startOffset = -1;
        return false;
    }

    //UPGRADE_TODO: Class 'java.io.RandomAccessFile' was converted to 'System.IO.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioRandomAccessFile'"
    // end seekHeader
    private static bool SeekHeader(Stream raf, long stop)
    {
        long startOffsetDummy = -1;
        return SeekHeader(raf, stop, out startOffsetDummy);
    }

    /// <summary> Grib edition number 1, 2 or 0 not a Grib file.</summary>
    /// <param name="inputStream"></param>
    /// <param name="grib1File"></param>
    /// <throws>  NotSupportedException </throws>
    /// <returns> int 0 not a Grib file, 1 Grib1, 2 Grib2
    /// </returns>
    private static int GetEdition(Stream InputStream, out long offset)
    {
        long length = (InputStream.Length < 4000L) ? InputStream.Length :InputStream.Position + 4000L;
        if (!SeekHeader(InputStream, length, out offset))
        {
            return 0; // not valid Grib file
        }

        //  Read Section 0 Indicator Section to get Edition number
        Grib1IndicatorSection isRenamed = new Grib1IndicatorSection(InputStream); // section 0
        return isRenamed.GribEdition;
    }

    public IGribMessage GetMessage(Stream stream)
    {
        var edition = GetEdition(stream, out var offset);
        if (edition == 0 && offset == -1)
            return null;
        switch (edition)
        {
            case 1:
                stream.Seek(offset+4, SeekOrigin.Begin);
                return _grib1File.GetMessage(stream);
            case 2:
                stream.Seek(offset, SeekOrigin.Begin);
                return _grib2File.GetMessage(stream);
            default:
                throw new NotSupportedException();
        }
    }
}