using NGrib.Grib1.PdsParameterTables;

namespace NGrib.Grib1;

public abstract class GribPdsParamTable
{
    private const string Undefined = "undefined";

    private static readonly IReadOnlyDictionary<(int, int, int), GribPdsParamTable> _table =
        new Dictionary<(int, int, int), GribPdsParamTable>()
        {
            {(98,0,1),new ParameterTable001()},
            {(98,0,2),new ParameterTable002()},
            {(98,0,3),new ParameterTable003()},
            {(98,0,128), new ParameterTable128()},
            {(98,0,210), new ParameterTable210()}
        };

    private static readonly DefaultParameterTable _default = new(0);

    protected abstract int TableNumber { get; }

    public static GribPdsParamTable GetParameterTable(int centerId, int subcenterId, int tableVersion)
    {
        if (_table.TryGetValue((centerId, subcenterId, tableVersion), out var parameterTable))
            return parameterTable;
        return _default;
    }

    public abstract Parameter GetParameter(int parameterNumber);

    protected Parameter GetDefaultParameter(int parameterNumber)
    {
        return new Parameter(TableNumber * 1000 + parameterNumber, parameterNumber.ToString(),
            Undefined, Undefined);
    }
}