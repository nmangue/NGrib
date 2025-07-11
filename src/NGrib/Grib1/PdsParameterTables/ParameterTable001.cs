namespace NGrib.Grib1.PdsParameterTables;

public class ParameterTable001:GribPdsParamTable
{
    protected override int TableNumber => 1;
    public override Parameter GetParameter(int parameterNumber)
    {
        return parameterNumber switch
        {
            10 => Parameters.TCO3,
            _ => GetDefaultParameter(parameterNumber)
        };
    }
}