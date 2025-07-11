namespace NGrib.Grib1.PdsParameterTables;

public class DefaultParameterTable:GribPdsParamTable
{
    public DefaultParameterTable(int tableNumber)
    {
        TableNumber = tableNumber;
    }

    protected override int TableNumber { get; }
    public override Parameter GetParameter(int parameterNumber)
    {
        return GetDefaultParameter(parameterNumber);
    }
}