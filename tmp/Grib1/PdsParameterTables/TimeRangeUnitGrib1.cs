using System.ComponentModel;

namespace NGrib.Grib1.PdsParameterTables;

public enum TimeRangeUnitGrib1
{
    [Description("Missing")] Missing = 255,
    [Description("Minute")] Minute = 0,
    [Description("Hour")] Hour = 1,
    [Description("Day")] Day = 2,
    [Description("Month")] Month = 3,
    [Description("Year")] Year = 4,
    [Description("Decade")] Decade = 5,
    [Description("Normal")] Normal = 6,
    [Description("Century")] Century = 7,
    [Description("3 Hours")] Hours3 = 10,
    [Description("6 Hours")] Hours6 = 11,
    [Description("12 Hours")] Hours12 = 12,
    [Description("15 Minutes")] Minutes15 = 13,
    [Description("30 Minutes")] Minutes30 = 14,
    [Description("Reserved")] Reserved = 253,
    [Description("Second")] Second = 254
}