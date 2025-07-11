using System.Collections;
using NGrib.Grib1;

namespace NGrib.Common.Adapters;

public class Grib1FileAdapter:IGribFile
{
    private readonly Grib1File _grib1File;
    private readonly Hashtable _hashtable = new();
    Grib1GridDefinitionSection gds = null;
    public Grib1FileAdapter(Grib1File grib1File)
    {
        _grib1File = grib1File;
    }

    public IGribMessage GetMessage(Stream stream)
    {
        var message =
            _grib1File.ReadGrib1Record(stream, stream.Position, _hashtable, ref gds);
        return new Grib1MessageAdapter(message, _grib1File, stream);
    }

}