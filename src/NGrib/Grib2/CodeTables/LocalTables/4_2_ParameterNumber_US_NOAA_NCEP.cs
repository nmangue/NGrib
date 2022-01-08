// Copyright (c) 2022 Remy Webservices
// All rights reserved.

using System.ComponentModel;

namespace NGrib.Grib2.CodeTables.LocalTables;

public enum ParameterNumber_US_NOAA_NCEP {

    #region Product Discipline 0 - Meteorological products, Parameter Category 16: Forecast Radar Imagery

    ///<summary>Equivalent radar reflectivity factor for rain (m m6 m-3)</summary>
    [Description("Equivalent radar reflectivity factor for rain (m m6 m-3)")] EquivalentRadarReflectivityFactorForRain = 192,

    ///<summary>Equivalent radar reflectivity factor for snow (m m6 m-3)</summary>
    [Description("Equivalent radar reflectivity factor for snow (m m6 m-3)")] EquivalentRadarReflectivityFactorForSnow = 193,

    ///<summary>Equivalent radar reflectivity factor for parameterized convection (m m6 m-3)</summary>
    [Description("Equivalent radar reflectivity factor for parameterized convection (m m6 m-3)")] EquivalentRadarReflectivityFactorForParameterizedConvection = 194,

    ///<summary>Reflectivity (dB)</summary>
    [Description("Reflectivity (dB)")] Reflectivity = 195,

    ///<summary>Composite reflectivity (dB)</summary>
    [Description("Composite reflectivity (dB)")] CompositeReflectivity = 196,

    ///<summary>Echo Top (m)</summary>
    [Description("Echo Top (m)")] EchoTop = 197,

    ///<summary>Hourly Maximum of Simulated Reflectivity (dB)</summary>
    [Description("Hourly Maximum of Simulated Reflectivity (dB)")] HourlyMaximumOfSimulatedReflectivity = 198,

    #endregion
}