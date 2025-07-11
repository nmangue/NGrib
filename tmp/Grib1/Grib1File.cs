using System.Collections;

namespace NGrib.Grib1;

public sealed class Grib1File
{
    /*
    * the header of Grib record
    */
    private const  string _header = "GRIB";

    private readonly GdsKeys _keys = new();

    private readonly GdsKeys _gdsKeys = new();

   

    public Grib1Record ReadGrib1Record(Stream InputStream,  long startOffset, Hashtable gdsCounter, ref Grib1GridDefinitionSection gds)
    {
        Grib1ProductDefinitionSection pds;
        // Read Section 0 Indicator Section
        Grib1IndicatorSection isRenamed = new Grib1IndicatorSection(InputStream);

        // EOR (EndOfRecord) calculated so skipping data sections is faster
        long eor = InputStream.Position + isRenamed.GribLength - isRenamed.Length;

        // Read Section 1 Product Definition Section PDS
        pds = new Grib1ProductDefinitionSection(InputStream);
        if (pds.LengthErr)
            return null;

        if (pds.gdsExists())
        {
            // Read Section 2 Grid Definition Section GDS
            gds = new Grib1GridDefinitionSection(InputStream);
        }
        else
        {
            // GDS doesn't exist so make one


            gds = (Grib1GridDefinitionSection) new Grib1Grid(pds);
        }

        // obtain BMS or BDS offset in the file for this product
        long dataOffset;
        if (pds.Center == 98)
        {
            // check for ecmwf offset by 1 bug
            int length = (int) GribNumbers.uint3(InputStream); // should be length of BMS
            if ((length + InputStream.Position) < eor)
            {
                dataOffset = InputStream.Position - 3; // ok
            }
            else
            {
                dataOffset = InputStream.Position - 2;
            }
        }
        else
        {
            dataOffset = InputStream.Position;
        }

        // position filePointer to EndOfRecord
        InputStream.Seek(eor, SeekOrigin.Begin);


        // assume scan ok
        Grib1Record gr = new Grib1Record(_header, isRenamed, pds, gds, dataOffset, InputStream.Position,
            startOffset);

        var currentPosition = InputStream.Position;

        InputStream.Position = currentPosition;

        // early return because ending "7777" missing
        if (InputStream.Position > InputStream.Length)
        {
            InputStream.Seek(0, SeekOrigin.Begin);
            _gdsKeys.CheckGdSkeys(gds, gdsCounter);
            throw new BadGribFormatException("Grib1Input: GRIB ending missing. Possible file corruption");
        }

        return gr;
    }

    /// <summary> Reads the Grib data 
    /// 
    /// </summary>
    /// <param name="offset"> offset into file.
    /// </param>
    /// <param name="DecimalScale">
    /// </param>
    /// <param name="bmsExists">
    /// </param>
    /// <throws>  NotSupportedException </throws>
    /// <returns> float[]
    /// </returns>
    public double[] getData(Stream raf, long offset, int DecimalScale, bool bmsExists)
    {
        long start = (System.DateTime.Now.Ticks - 621355968000000000) / 10000;

        raf.Seek(offset, System.IO.SeekOrigin.Begin);


        // Need section 3 and 4 to read/interpet the data, section 5
        // as a check that all data read and sections are correct

        Grib1BitMapSection bms = null;
        if (bmsExists)
            // read Bit Mapped Section 3
            bms = new Grib1BitMapSection(raf);

        // read Binary Data Section 4
        Grib1BinaryDataSection bds = new Grib1BinaryDataSection(raf, DecimalScale, bms);

        return bds.Values;
    }

    public void CheckGdSkeys(Grib1GridDefinitionSection gds, Hashtable gdsCounter)
    {
        _keys.CheckGdSkeys(gds, gdsCounter);
    }
}