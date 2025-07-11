namespace NGrib.Grib1.PdsParameterTables;

public static class Parameters
{
    /// <summary>
    /// Ozone
    /// </summary>
    public static Parameter GTCO3 { get; }=new Parameter(206, "GTCO3 Total column ozone",
        @"(TCO3) This parameter is the total amount of ozone in a column of air extending from the surface of the Earth to the top of the atmosphere. This parameter can also be referred to as total ozone, or vertically integrated ozone. The values are dominated by ozone within the stratosphere.
In the ECMWF Integrated Forecasting System (IFS), there is a simplified representation of ozone chemistry (including representation of the chemistry which has caused the ozone hole). Ozone is also transported around in the atmosphere through the motion of air. See further documentation .
Naturally occurring ozone in the stratosphere helps protect organisms at the surface of the Earth from the harmful effects of ultraviolet (UV) radiation from the Sun. Ozone near the surface, often produced because of pollution, is harmful to organisms.
In the IFS, the units for total ozone are kilograms per square metre, but before 12/06/2001 dobson units were used. Dobson units (DU) are still used extensively for total column ozone. 1 DU = 2.1415E-5 kg m-2",
        "kg m^(-2)");
    
    public static Parameter TCO3 { get; }=new Parameter(10, "TCO3 Total column ozone",
        @"(TCO3) This parameter is the total amount of ozone in a column of air extending from the surface of the Earth to the top of the atmosphere. This parameter can also be referred to as total ozone, or vertically integrated ozone. The values are dominated by ozone within the stratosphere.
In the ECMWF Integrated Forecasting System (IFS), there is a simplified representation of ozone chemistry (including representation of the chemistry which has caused the ozone hole). Ozone is also transported around in the atmosphere through the motion of air. See further documentation .
Naturally occurring ozone in the stratosphere helps protect organisms at the surface of the Earth from the harmful effects of ultraviolet (UV) radiation from the Sun. Ozone near the surface, often produced because of pollution, is harmful to organisms.
In the IFS, the units for total ozone are kilograms per square metre, but before 12/06/2001 dobson units were used. Dobson units (DU) are still used extensively for total column ozone. 1 DU = 2.1415E-5 kg m-2",
        "kg m^(-2)");
    
    /// <summary>
    /// Particulate matter d <= 2.5 um
    /// </summary>
    public static Parameter PM2P5 { get; }= new Parameter(210073, "PM2P5 Particulate matter d <= 2.5 um", "pm2p5", "kg m-3");

    /// <summary>
    /// Nitrogen dioxide
    /// </summary>
    public static Parameter NO2 { get; } = new(210121, "NO2 Nitrogen dioxide mass mixing ratio", "NO2", "kg kg-1");

    /// <summary>
    /// Carbon monoxide
    /// </summary>
    public static Parameter CO { get; } = new(210123, "CO Carbon monoxide mass mixing ratio", "CO", "kg kg-1");

    /// <summary>
    /// Total column Sulphur dioxide
    /// </summary>
    public static Parameter TCSO2 { get; } = new(210126, "TCSO2 Total column Sulphur dioxide", "TCSO2", "kg m-2");

    /// <summary>
    /// Dust Aerosol (0.9 - 20 um) Mixing Ratio
    /// </summary>
    public static Parameter AERMR06 { get; } = new(210006, "AERMR06 Dust Aerosol (0.9 - 20 um) Mixing Ratio", "AERMR06", "kg kg-1");

}