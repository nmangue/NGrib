using NGrib.Grib2;

namespace NGrib.Common.Adapters;

public class Grib2FileAdapter:IGribFile
{
    private readonly Grib2File _grib2File;

    public Grib2FileAdapter(Grib2File grib2File)
    {
        _grib2File = grib2File;
    }

    public IGribMessage GetMessage(Stream stream)
    {
        using var reader = new BufferedBinaryReader(stream, true);
        var message = _grib2File.ReadGrib2Message(reader, out var currentPosition);
        stream.Seek(currentPosition, SeekOrigin.Begin);
        return new Grib2MessageAdapter(message, stream);
    }
}