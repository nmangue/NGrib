/*
 * This file is part of NGrib.
 * Created by Andreas Dekiert
 *
 * Copyright (c) 2022 Remy Webservices
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

    #region Product Discipline 0: Meteorological products, Parameter Category 1: Moisture

    ///<summary>Categorical Rain (Code table 4.222)</summary>
    public static Parameter CategoricalRain { get; } = new Parameter(ParameterCategory.Moisture, 192, "Categorical Rain", "Code table 4.222");

    ///<summary>Categorical Freezing Rain (Code table 4.222)</summary>
    public static Parameter CategoricalFreezingRain { get; } = new Parameter(ParameterCategory.Moisture, 193, "Categorical Freezing Rain", "Code table 4.222");

    ///<summary>Categorical Ice Pellets (Code table 4.222)</summary>
    public static Parameter CategoricalIcePellets { get; } = new Parameter(ParameterCategory.Moisture, 194, "Categorical Ice Pellets", "Code table 4.222");

    ///<summary>Categorical Snow (Code table 4.222)</summary>
    public static Parameter CategoricalSnow { get; } = new Parameter(ParameterCategory.Moisture, 195, "Categorical Snow", "Code table 4.222");

    ///<summary>Convective Precipitation Rate (kg m-2 s-1)</summary>
    public static Parameter ConvectivePrecipitationRate { get; } = new Parameter(ParameterCategory.Moisture, 196, "Convective Precipitation Rate", "kg m-2 s-1");

    ///<summary>Snow Cover (%)</summary>
    public static Parameter SnowCover { get; } = new Parameter(ParameterCategory.Moisture, 201, "Snow Cover", "%");

    #endregion

    #region Product Discipline 0: Meteorological products, Parameter Category 2: Momentum

    ///<summary>Vertical Speed Shear (s-1)</summary>
    public static Parameter VerticalSpeedShear { get; } = new Parameter(ParameterCategory.Momentum, 192, "Vertical Speed Shear", "s-1");

    ///<summary>U-Component Storm Motion (m s-1)</summary>
    public static Parameter U_ComponentStormMotion { get; } = new Parameter(ParameterCategory.Momentum, 194, "U-Component Storm Motion", "m s-1");

    ///<summary>V-Component Storm Motion (m s-1)</summary>
    public static Parameter V_ComponentStormMotion { get; } = new Parameter(ParameterCategory.Momentum, 195, "V-Component Storm Motion", "m s-1");

    ///<summary>Frictional Velocity (m s-1)</summary>
    public static Parameter FrictionalVelocity { get; } = new Parameter(ParameterCategory.Momentum, 197, "Frictional Velocity", "m s-1");

    ///<summary>Ventilation Rate (m2 s-1)</summary>
    public static Parameter VentilationRate { get; } = new Parameter(ParameterCategory.Momentum, 224, "Ventilation Rate", "m2 s-1");

    #endregion

    #region Product Discipline 0: Meteorological products, Parameter Category 3: Mass

    ///<summary>MSLP (Eta model reduction) (Pa)</summary>
    public static Parameter MSLP_EtaModelReduction { get; } = new Parameter(ParameterCategory.Mass, 192, "MSLP (Eta model reduction)", "Pa");

    ///<summary>Planetary Boundary Layer Height (m)</summary>
    public static Parameter PlanetaryBoundaryLayerHeight { get; } = new Parameter(ParameterCategory.Mass, 196, "Planetary Boundary Layer Height", "m");

    ///<summary>Pressure of level from which parcel was lifted (Pa)</summary>
    public static Parameter PressureOfLevelFromWhichParcelWasLifted { get; } = new Parameter(ParameterCategory.Mass, 200, "Pressure of level from which parcel was lifted", "Pa");

    #endregion

    #region Product Discipline 0: Meteorological products, Parameter Category 6: Cloud

    ///<summary>X-gradient of Log Pressure (m-1)</summary>
    public static Parameter XGradientOfLogPressure { get; } = new Parameter(ParameterCategory.Cloud, 201, "X-gradient of Log Pressure", "m-1");

    #endregion

    #region Product Discipline 0: Meteorological products, Parameter Category 7: Thermodynamic Stability Indices

    ///<summary>Surface Lifted Index (K)</summary>
    public static Parameter SurfaceLiftedIndex { get; } = new Parameter(ParameterCategory.ThermodynamicStabilityIndices, 192, "Surface Lifted Index", "K");

    ///<summary>Best (4 layer) Lifted Index (K)</summary>
    public static Parameter Best_4Layer_LiftedIndex { get; } = new Parameter(ParameterCategory.ThermodynamicStabilityIndices, 193, "Best (4 layer) Lifted Index", "K");

    #endregion

    #region Product Discipline 0: Meteorological products, Parameter Category 14: Trace Gases

    ///<summary>Ozone Mixing Ratio (kg kg-1)</summary>
    public static Parameter OzoneMixingRatio { get; } = new Parameter(ParameterCategory.TraceGases, 192, "Ozone Mixing Ratio", "kg kg-1");

    #endregion

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

    #region Product Discipline 2: Land surface products, Parameter Category 0: Vegetation/Biomass

    ///<summary>Volumetric Soil Moisture Content (Fraction)</summary>
    public static Parameter VolumetricSoilMoistureContent { get; } = new Parameter(ParameterCategory.VegetationBiomass, 192, "Volumetric Soil Moisture Content", "Fraction");

    ///<summary>Plant Canopy Surface Water (kg m-2)</summary>
    public static Parameter PlantCanopySurfaceWater { get; } = new Parameter(ParameterCategory.VegetationBiomass, 196, "Plant Canopy Surface Water", "kg m-2");

    ///<summary>Wilting Point (Fraction)</summary>
    public static Parameter WiltingPoint { get; } = new Parameter(ParameterCategory.VegetationBiomass, 201, "Wilting Point", "Fraction");

    #endregion

    #region Product Discipline 2: Land surface products, Parameter Category 3: Soil Products

    ///<summary>Liquid Volumetric Soil Moisture (non Frozen) (Proportion)</summary>
    public static Parameter LiquidVolumetricSoilMoisture_NonFrozen { get; } = new Parameter(ParameterCategory.SoilProducts, 192, "Liquid Volumetric Soil Moisture (non Frozen)", "Proportion");

    ///<summary>Field Capacity (Fraction)</summary>
    public static Parameter FieldCapacity { get; } = new Parameter(ParameterCategory.SoilProducts, 203, "Field Capacity", "Fraction");

    #endregion
}