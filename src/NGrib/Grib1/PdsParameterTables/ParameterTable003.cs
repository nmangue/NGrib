namespace NGrib.Grib1.PdsParameterTables;

public class ParameterTable003:GribPdsParamTable
{
    protected override int TableNumber => 3;

    public override Parameter GetParameter(int parameterNumber)
    {
        return parameterNumber switch
        {
            10 => Parameters.TCO3,
            _ => GetDefaultParameter(parameterNumber)
        };
    }
}