namespace NGrib.Grib1.PdsParameterTables;

public class ParameterTable210 : GribPdsParamTable
{
    protected override int TableNumber => 210;

    public override Parameter GetParameter(int parameterNumber)
    {
        return parameterNumber switch
        {
            6=> Parameters.AERMR06,
            
            206 => Parameters.GTCO3,

            //73 => Parameters.PM2P5,

            121 => Parameters.NO2,

            123 => Parameters.CO,

            126 => Parameters.TCSO2,

            _ => GetDefaultParameter(parameterNumber)
        };
    }
}