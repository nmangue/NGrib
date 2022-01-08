/*
 * This file is part of NGrib.
 *
 * Copyright (c) 2022 Andreas Dekiert
 *
 * NGrib is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 3 of the License, or (at your option) any later version.
 *
 * NGrib is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with NGrib. If not, see <https://www.gnu.org/licenses/>.
 */

namespace NGrib.Grib2.CodeTables.LocalTables;

public readonly struct Parameter_US_NOAA_NCEP {

    #region Product Discipline 0 - Meteorological products, Parameter Category 16: Forecast Radar Imagery

    ///<summary>Equivalent radar reflectivity factor for rain (m m6 m-3)</summary>
    public static Parameter EquivalentRadarReflectivityFactorForRain { get; } = new Parameter(ParameterCategory.ForecastRadarImagery, 192, "Equivalent radar reflectivity factor for rain", "m m6 m-3");

    ///<summary>Equivalent radar reflectivity factor for snow (m m6 m-3)</summary>
    public static Parameter EquivalentRadarReflectivityFactorForSnow { get; } = new Parameter(ParameterCategory.ForecastRadarImagery, 193, "Equivalent radar reflectivity factor for snow", "m m6 m-3");

    ///<summary>Equivalent radar reflectivity factor for parameterized convection (m m6 m-3)</summary>
    public static Parameter EquivalentRadarReflectivityFactorForParameterizedConvection { get; } = new Parameter(ParameterCategory.ForecastRadarImagery, 194, "Equivalent radar reflectivity factor for parameterized convection", "m m6 m-3");

    ///<summary>Reflectivity (dB)</summary>
    public static Parameter Reflectivity { get; } = new Parameter(ParameterCategory.ForecastRadarImagery, 195, "Reflectivity", "dB");

    ///<summary>Composite reflectivity (dB)</summary>
    public static Parameter CompositeReflectivity { get; } = new Parameter(ParameterCategory.ForecastRadarImagery, 196, "Composite reflectivity", "dB");

    ///<summary>Echo Top (m)</summary>
    public static Parameter EchoTop { get; } = new Parameter(ParameterCategory.ForecastRadarImagery, 197, "Echo Top", "m");

    ///<summary>Hourly Maximum of Simulated Reflectivity (dB)</summary>
    public static Parameter HourlyMaximumOfSimulatedReflectivity { get; } = new Parameter(ParameterCategory.ForecastRadarImagery, 198, "Hourly Maximum of Simulated Reflectivity", "dB");

    #endregion
}