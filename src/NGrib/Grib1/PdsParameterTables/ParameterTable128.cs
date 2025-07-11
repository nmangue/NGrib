namespace NGrib.Grib1.PdsParameterTables;

public class ParameterTable128:GribPdsParamTable
{
    protected override int TableNumber => 128;

    public override Parameter GetParameter(int parameterNumber)
    {
        return parameterNumber switch
        {
            206 => Parameters.GTCO3,
            _ => GetDefaultParameter(parameterNumber)
        };
    }

}