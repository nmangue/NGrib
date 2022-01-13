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

using System.ComponentModel;

namespace NGrib.Grib2.CodeTables.LocalTables;

public enum US_NOAA_NCEP_ParameterNumber {

    #region Product Discipline 0: Meteorological products, Parameter Category 1: Moisture

    ///<summary>Categorical Rain (Code table 4.222)</summary>
    [Description("Categorical Rain (Code table 4.222)")] CategoricalRain = 192,

    ///<summary>Categorical Freezing Rain (Code table 4.222)</summary>
    [Description("Categorical Freezing Rain (Code table 4.222)")] CategoricalFreezingRain = 193,

    ///<summary>Categorical Ice Pellets (Code table 4.222)</summary>
    [Description("Categorical Ice Pellets (Code table 4.222)")] CategoricalIcePellets = 194,

    ///<summary>Categorical Snow (Code table 4.222)</summary>
    [Description("Categorical Snow (Code table 4.222)")] CategoricalSnow = 195,

    ///<summary>Convective Precipitation Rate (1 Hour Average) (kg m-2 s-1)</summary>
    [Description("Convective Precipitation Rate (1 Hour Average) (kg m-2 s-1)")] ConvectivePrecipitationRate_1HourAverage = 196,

    ///<summary>Potential Evaporation Rate (W m-2)</summary>
    [Description("Potential Evaporation Rate (W m-2)")] PotentialEvaporationRate = 200,

    ///<summary>Snow Cover (%)</summary>
    [Description("Snow Cover (%)")] SnowCover = 201,

    #endregion

    #region Product Discipline 0: Meteorological products, Parameter Category 2: Momentum

    ///<summary>Vertical Speed Shear (s-1)</summary>
    [Description("Vertical Speed Shear (s-1)")] VerticalSpeedShear = 192,

    ///<summary>U-Component Storm Motion (m s-1)</summary>
    [Description("U-Component Storm Motion (m s-1)")] U_ComponentStormMotion = 194,

    ///<summary>V-Component Storm Motion (m s-1)</summary>
    [Description("V-Component Storm Motion (m s-1)")] V_ComponentStormMotion = 195,

    ///<summary>Frictional Velocity (m s-1)</summary>
    [Description("Frictional Velocity (m s-1)")] FrictionalVelocity = 197,

    ///<summary>Ventilation Rate (m2 s-1)</summary>
    [Description("Ventilation Rate (m2 s-1)")] VentilationRate = 224,

    #endregion

    #region Product Discipline 0: Meteorological products, Parameter Category 3: Mass

    ///<summary>MSLP (Eta model reduction) (Pa)</summary>
    [Description("MSLP (Eta model reduction) (Pa)")] MSLP_EtaModelReduction = 192,

    ///<summary>5-Wave Geopotential Height (gpm)</summary>
    [Description("5-Wave Geopotential Height (gpm)")] FiveWaveGeopotentialHeight = 193,

    ///<summary>Zonal Flux of Gravity Wave Stress (N m-2)</summary>
    [Description("Zonal Flux of Gravity Wave Stress (N m-2)")] ZonalFluxOfGravityWaveStress = 194,

    ///<summary>Meridional Flux of Gravity Wave Stress (N m-2)</summary>
    [Description("Meridional Flux of Gravity Wave Stress (N m-2)")] MeridionalFluxOfGravityWaveStress = 195,

    ///<summary>Planetary Boundary Layer Height (m)</summary>
    [Description("Planetary Boundary Layer Height (m)")] PlanetaryBoundaryLayerHeight = 196,

    ///<summary>Pressure of level from which parcel was lifted (Pa)</summary>
    [Description("Pressure of level from which parcel was lifted (Pa)")] PressureOfLevelFromWhichParcelWasLifted = 200,

    #endregion

    #region Product Discipline 0: Meteorological products, Parameter Category 4: Short-wave Radiation

    ///<summary>Downward Short-Wave Radiation Flux (W m-2)</summary>
    [Description("Downward Short-Wave Radiation Flux (W m-2)")] DownwardShortWaveRadiationFlux = 192,

    ///<summary>Upward Short-Wave Radiation Flux (W m-2)</summary>
    [Description("Upward Short-Wave Radiation Flux (W m-2)")] UpwardShortWaveRadiationFlux = 193,

    #endregion

    #region Product Discipline 0: Meteorological products, Parameter Category 5: Long-wave Radiation

    ///<summary>Downward Long-Wave Radiation Flux (W m-2)</summary>
    [Description("Downward Long-Wave Radiation Flux (W m-2)")] DownwardLongWaveRadiationFlux = 192,

    ///<summary>Upward Long-Wave Radiation Flux (W m-2)</summary>
    [Description("Upward Long-Wave Radiation Flux (W m-2)")] UpwardLongWaveRadiationFlux = 193,

    #endregion

    #region Product Discipline 0: Meteorological products, Parameter Category 6: Cloud

    ///<summary>Cloud Work Function (J kg-1)</summary>
    [Description("Cloud Work Function (J kg-1)")] CloudWorkFunction = 193,

    ///<summary>X-gradient of Log Pressure (m-1)</summary>
    [Description("X-gradient of Log Pressure (m-1)")] XGradientOfLogPressure = 201,

    #endregion

    #region Product Discipline 0: Meteorological products, Parameter Category 7: Thermodynamic Stability Indices

    ///<summary>Surface Lifted Index (K)</summary>
    [Description("Surface Lifted Index (K)")] SurfaceLiftedIndex = 192,

    ///<summary>Best (4 layer) Lifted Index (K)</summary>
    [Description("Best (4 layer) Lifted Index (K)")] Best_4Layer_LiftedIndex = 193,

    #endregion

    #region Product Discipline 0: Meteorological products, Parameter Category 14: Trace Gases

    ///<summary>Ozone Mixing Ratio (kg kg-1)</summary>
    [Description("Ozone Mixing Ratio (kg kg-1)")] OzoneMixingRatio = 192,

    #endregion

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

    #region Product Discipline 2: Land surface products, Parameter Category 0: Vegetation/Biomass

    ///<summary>Volumetric Soil Moisture Content (Fraction)</summary>
    [Description("Volumetric Soil Moisture Content (Fraction)")] VolumetricSoilMoistureContent = 192,

    ///<summary>Ground Heat Flux (W m-2)</summary>
    [Description("Ground Heat Flux (W m-2)")] GroundHeatFlux = 193,

    ///<summary>Plant Canopy Surface Water (kg m-2)</summary>
    [Description("Plant Canopy Surface Water (kg m-2)")] PlantCanopySurfaceWater = 196,

    ///<summary>Wilting Point (Fraction)</summary>
    [Description("Wilting Point (Fraction)")] WiltingPoint = 201,

    #endregion

    #region Product Discipline 2: Land surface products, Parameter Category 3: Soil Products

    ///<summary>Liquid Volumetric Soil Moisture (non Frozen) (Proportion)</summary>
    [Description("Liquid Volumetric Soil Moisture (non Frozen) (Proportion)")] LiquidVolumetricSoilMoisture_NonFrozen = 192,

    ///<summary>Field Capacity (Fraction)</summary>
    [Description("Field Capacity (Fraction)")] FieldCapacity = 203,

    #endregion
}