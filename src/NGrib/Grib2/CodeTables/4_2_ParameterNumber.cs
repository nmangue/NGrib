/*
 * This file is part of NGrib.
 *
 * Copyright © 2020 Nicolas Mangué
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
 * along with NGrib.  If not, see <https://www.gnu.org/licenses/>.
 */

using System.ComponentModel;

namespace NGrib.Grib2.CodeTables
{
	/// <summary>
	/// Code Table 4.2: Parameter number by product discipline and parameter category
	/// </summary>
	public enum ParameterNumber
	{
		#region Product Discipline 0: Meteorological products, Parameter Category 0: Temperature

		///<summary>Temperature (K)</summary>
		[Description("Temperature")] Temperature = 0,

		///<summary>Virtual temperature (K)</summary>
		[Description("Virtual temperature")] VirtualTemperature = 1,

		///<summary>Potential temperature (K)</summary>
		[Description("Potential temperature")] PotentialTemperature = 2,

		///<summary>Pseudo-adiabatic potential temperature or equivalent potential temperature (K)</summary>
		[Description("Pseudo-adiabatic potential temperature or equivalent potential temperature")]
		PseudoAdiabaticPotentialTemperatureOrEquivalentPotentialTemperature = 3,

		///<summary>Maximum temperature (K)</summary>
		[Description("Maximum temperature")] MaximumTemperature = 4,

		///<summary>Minimum temperature (K)</summary>
		[Description("Minimum temperature")] MinimumTemperature = 5,

		///<summary>Dew point temperature (K)</summary>
		[Description("Dew point temperature")] DewPointTemperature = 6,

		///<summary>Dew point depression (or deficit) (K)</summary>
		[Description("Dew point depression (or deficit)")]
		DewPointDepression = 7,

		///<summary>Lapse rate (K m-1)</summary>
		[Description("Lapse rate")] LapseRate = 8,

		///<summary>Temperature anomaly (K)</summary>
		[Description("Temperature anomaly")] TemperatureAnomaly = 9,

		///<summary>Latent heat net flux (W m-2)</summary>
		[Description("Latent heat net flux")] LatentHeatNetFlux = 10,

		///<summary>Sensible heat net flux (W m-2)</summary>
		[Description("Sensible heat net flux")]
		SensibleHeatNetFlux = 11,

		///<summary>Heat index (K)</summary>
		[Description("Heat index")] HeatIndex = 12,

		///<summary>Wind chill factor (K)</summary>
		[Description("Wind chill factor")] WindChillFactor = 13,

		///<summary>Minimum dew point depression (K)</summary>
		[Description("Minimum dew point depression")]
		MinimumDewPointDepression = 14,

		///<summary>Virtual potential temperature (K)</summary>
		[Description("Virtual potential temperature")]
		VirtualPotentialTemperature = 15,

		#endregion

		#region Product Discipline 0: Meteorological products, Parameter Category 1: Moisture

		///<summary>Specific humidity (kg kg-1)</summary>
		[Description("Specific humidity")] SpecificHumidity = 0,

		///<summary>Relative humidity (%)</summary>
		[Description("Relative humidity")] RelativeHumidity = 1,

		///<summary>Humidity mixing ratio (kg kg-1)</summary>
		[Description("Humidity mixing ratio")] HumidityMixingRatio = 2,

		///<summary>Precipitable water (kg m-2)</summary>
		[Description("Precipitable water")] PrecipitableWater = 3,

		///<summary>Vapor pressure (Pa)</summary>
		[Description("Vapor pressure")] VaporPressure = 4,

		///<summary>Saturation deficit (Pa)</summary>
		[Description("Saturation deficit")] SaturationDeficit = 5,

		///<summary>Evaporation (kg m-2)</summary>
		[Description("Evaporation")] Evaporation = 6,

		///<summary>Precipitation rate (kg m-2 s-1)</summary>
		[Description("Precipitation rate")] PrecipitationRate = 7,

		///<summary>Total precipitation (kg m-2)</summary>
		[Description("Total precipitation")] TotalPrecipitation = 8,

		///<summary>Large scale precipitation (non-convective) (kg m-2)</summary>
		[Description("Large scale precipitation (non-convective)")]
		LargeScalePrecipitationNonconvective = 9,

		///<summary>Convective precipitation (kg m-2)</summary>
		[Description("Convective precipitation")]
		ConvectivePrecipitation = 10,

		///<summary>Snow depth (m)</summary>
		[Description("Snow depth")] SnowDepth = 11,

		///<summary>Snowfall rate water equivalent (kg m-2 s-1)</summary>
		[Description("Snowfall rate water equivalent")]
		SnowfallRateWaterEquivalent = 12,

		///<summary>Water equivalent of accumulated snow depth (kg m-2)</summary>
		[Description("Water equivalent of accumulated snow depth")]
		WaterEquivalentOfAccumulatedSnowDepth = 13,

		///<summary>Convective snow (kg m-2)</summary>
		[Description("Convective snow")] ConvectiveSnow = 14,

		///<summary>Large scale snow (kg m-2)</summary>
		[Description("Large scale snow")] LargeScaleSnow = 15,

		///<summary>Snow melt (kg m-2)</summary>
		[Description("Snow melt")] SnowMelt = 16,

		///<summary>Snow age (day)</summary>
		[Description("Snow age")] SnowAge = 17,

		///<summary>Absolute humidity (kg m-3)</summary>
		[Description("Absolute humidity")] AbsoluteHumidity = 18,

		///<summary>Precipitation type (Code table (4.201))</summary>
		[Description("Precipitation type")] PrecipitationType = 19,

		///<summary>Integrated liquid water (kg m-2)</summary>
		[Description("Integrated liquid water")]
		IntegratedLiquidWater = 20,

		///<summary>Condensate (kg kg-1)</summary>
		[Description("Condensate")] Condensate = 21,

		///<summary>Cloud mixing ratio (kg kg-1)</summary>
		[Description("Cloud mixing ratio")] CloudMixingRatio = 22,

		///<summary>Ice water mixing ratio (kg kg-1)</summary>
		[Description("Ice water mixing ratio")]
		IceWaterMixingRatio = 23,

		///<summary>Rain mixing ratio (kg kg-1)</summary>
		[Description("Rain mixing ratio")] RainMixingRatio = 24,

		///<summary>Snow mixing ratio (kg kg-1)</summary>
		[Description("Snow mixing ratio")] SnowMixingRatio = 25,

		///<summary>Horizontal moisture convergence (kg kg-1 s-1)</summary>
		[Description("Horizontal moisture convergence")]
		HorizontalMoistureConvergence = 26,

		///<summary>Maximum relative humidity (%)</summary>
		[Description("Maximum relative humidity")]
		MaximumRelativeHumidity = 27,

		///<summary>Maximum absolute humidity (kg m-3)</summary>
		[Description("Maximum absolute humidity")]
		MaximumAbsoluteHumidity = 28,

		///<summary>Total snowfall (m)</summary>
		[Description("Total snowfall")] TotalSnowfall = 29,

		///<summary>Precipitable water category (Code table (4.202))</summary>
		[Description("Precipitable water category")]
		PrecipitableWaterCategory = 30,

		///<summary>Hail (m)</summary>
		[Description("Hail")] Hail = 31,

		///<summary>Graupel (snow pellets) (kg kg-1)</summary>
		[Description("Graupel (snow pellets)")]
		Graupel = 32,

		#endregion

		#region Product Discipline 0: Meteorological products, Parameter Category 2: Momentum

		///<summary>Wind direction (from which blowing) (deg true)</summary>
		[Description("Wind direction (from which blowing)")]
		WindDirection = 0,

		///<summary>Wind speed (m s-1)</summary>
		[Description("Wind speed")] WindSpeed = 1,

		///<summary>u-component of wind (m s-1)</summary>
		[Description("u-component of wind")] UComponentOfWind = 2,

		///<summary>v-component of wind (m s-1)</summary>
		[Description("v-component of wind")] VComponentOfWind = 3,

		///<summary>Stream function (m2 s-1)</summary>
		[Description("Stream function")] StreamFunction = 4,

		///<summary>Velocity potential (m2 s-1)</summary>
		[Description("Velocity potential")] VelocityPotential = 5,

		///<summary>Montgomery stream function (m2 s-2)</summary>
		[Description("Montgomery stream function")]
		MontgomeryStreamFunction = 6,

		///<summary>Sigma coordinate vertical velocity (s-1)</summary>
		[Description("Sigma coordinate vertical velocity")]
		SigmaCoordinateVerticalVelocity = 7,

		///<summary>Vertical velocity (pressure) (Pa s-1)</summary>
		[Description("Vertical velocity (pressure)")]
		VerticalVelocityPressure = 8,

		///<summary>Vertical velocity (geometric) (m s-1)</summary>
		[Description("Vertical velocity (geometric)")]
		VerticalVelocityGeometric = 9,

		///<summary>Absolute vorticity (s-1)</summary>
		[Description("Absolute vorticity")] AbsoluteVorticity = 10,

		///<summary>Absolute divergence (s-1)</summary>
		[Description("Absolute divergence")] AbsoluteDivergence = 11,

		///<summary>Relative vorticity (s-1)</summary>
		[Description("Relative vorticity")] RelativeVorticity = 12,

		///<summary>Relative divergence (s-1)</summary>
		[Description("Relative divergence")] RelativeDivergence = 13,

		///<summary>Potential vorticity (K m2 kg-1 s-1)</summary>
		[Description("Potential vorticity")] PotentialVorticity = 14,

		///<summary>Vertical u-component shear (s-1)</summary>
		[Description("Vertical u-component shear")]
		VerticalUComponentShear = 15,

		///<summary>Vertical v-component shear (s-1)</summary>
		[Description("Vertical v-component shear")]
		VerticalVComponentShear = 16,

		///<summary>Momentum flux, u component (s-1)</summary>
		[Description("Momentum flux, u component")]
		MomentumFluxUComponent = 17,

		///<summary>Momentum flux, v component (s-1)</summary>
		[Description("Momentum flux, v component")]
		MomentumFluxVComponent = 18,

		///<summary>Wind mixing energy (J)</summary>
		[Description("Wind mixing energy")] WindMixingEnergy = 19,

		///<summary>Boundary layer dissipation (W m-2)</summary>
		[Description("Boundary layer dissipation")]
		BoundaryLayerDissipation = 20,

		///<summary>Maximum wind speed (m s-1)</summary>
		[Description("Maximum wind speed")] MaximumWindSpeed = 21,

		///<summary>Wind speed (gust) (m s-1)</summary>
		[Description("Wind speed (gust)")] WindSpeedGust = 22,

		///<summary>u-component of wind (gust) (m s-1)</summary>
		[Description("u-component of wind (gust)")]
		UComponentOfWindGust = 23,

		///<summary>v-component of wind (gust) (m s-1)</summary>
		[Description("v-component of wind (gust)")]
		VComponentOfWindGust = 24,

		#endregion

		#region Product Discipline 0: Meteorological products, Parameter Category 3: Mass

		///<summary>Pressure (Pa)</summary>
		[Description("Pressure")] Pressure = 0,

		///<summary>Pressure reduced to MSL (Pa)</summary>
		[Description("Pressure reduced to MSL")]
		PressureReducedToMsl = 1,

		///<summary>Pressure tendency (Pa s-1)</summary>
		[Description("Pressure tendency")] PressureTendency = 2,

		///<summary>ICAO Standard Atmosphere Reference Height (m)</summary>
		[Description("ICAO Standard Atmosphere Reference Height")]
		IcaoStandardAtmosphereReferenceHeight = 3,

		///<summary>Geopotential (m2 s-2)</summary>
		[Description("Geopotential")] Geopotential = 4,

		///<summary>Geopotential height (gpm)</summary>
		[Description("Geopotential height")] GeopotentialHeight = 5,

		///<summary>Geometric height (m)</summary>
		[Description("Geometric height")] GeometricHeight = 6,

		///<summary>Standard deviation of height (m)</summary>
		[Description("Standard deviation of height")]
		StandardDeviationOfHeight = 7,

		///<summary>Pressure anomaly (Pa)</summary>
		[Description("Pressure anomaly")] PressureAnomaly = 8,

		///<summary>Geopotential height anomaly (gpm)</summary>
		[Description("Geopotential height anomaly")]
		GeopotentialHeightAnomaly = 9,

		///<summary>Density (kg m-3)</summary>
		[Description("Density")] Density = 10,

		///<summary>Altimeter setting (Pa)</summary>
		[Description("Altimeter setting")] AltimeterSetting = 11,

		///<summary>Thickness (m)</summary>
		[Description("Thickness")] Thickness = 12,

		///<summary>Pressure altitude (m)</summary>
		[Description("Pressure altitude")] PressureAltitude = 13,

		///<summary>Density altitude (m)</summary>
		[Description("Density altitude")] DensityAltitude = 14,

		#endregion

		#region Product Discipline 0: Meteorological products, Parameter Category 4: Short-wave Radiation

		///<summary>Net short-wave radiation flux (surface) (W m-2)</summary>
		[Description("Net short-wave radiation flux (surface)")]
		NetShortWaveRadiationFluxSurface = 0,

		///<summary>Net short-wave radiation flux (top of atmosphere) (W m-2)</summary>
		[Description("Net short-wave radiation flux (top of atmosphere)")]
		NetShortWaveRadiationFlux = 1,

		///<summary>Short wave radiation flux (W m-2)</summary>
		[Description("Short wave radiation flux")]
		ShortWaveRadiationFlux = 2,

		///<summary>Global radiation flux (W m-2)</summary>
		[Description("Global radiation flux")] GlobalRadiationFlux = 3,

		///<summary>Brightness temperature (K)</summary>
		[Description("Brightness temperature")]
		BrightnessTemperature = 4,

		///<summary>Radiance (with respect to wave number) (W m-1 sr-1)</summary>
		[Description("Radiance (with respect to wave number)")]
		RadianceWaveNumber = 5,

		///<summary>Radiance (with respect to wave length) (W m-3 sr-1)</summary>
		[Description("Radiance (with respect to wave length)")]
		RadianceWaveLength = 6,

		#endregion

		#region Product Discipline 0: Meteorological products, Parameter Category 5: Long-wave Radiation

		///<summary>Net long wave radiation flux (surface) (W m-2)</summary>
		[Description("Net long wave radiation flux (surface)")]
		NetLongWaveRadiationFluxSurface = 0,

		///<summary>Net long wave radiation flux (top of atmosphere) (W m-2)</summary>
		[Description("Net long wave radiation flux (top of atmosphere)")]
		NetLongWaveRadiationFluxTopOfAtmosphere = 1,

		///<summary>Long wave radiation flux (W m-2)</summary>
		[Description("Long wave radiation flux")]
		LongWaveRadiationFlux = 2,

		#endregion

		#region Product Discipline 0: Meteorological products, Parameter Category 6: Cloud

		///<summary>Cloud Ice (kg m-2)</summary>
		[Description("Cloud Ice")] CloudIce = 0,

		///<summary>Total cloud cover (%)</summary>
		[Description("Total cloud cover")] TotalCloudCover = 1,

		///<summary>Convective cloud cover (%)</summary>
		[Description("Convective cloud cover")]
		ConvectiveCloudCover = 2,

		///<summary>Low cloud cover (%)</summary>
		[Description("Low cloud cover")] LowCloudCover = 3,

		///<summary>Medium cloud cover (%)</summary>
		[Description("Medium cloud cover")] MediumCloudCover = 4,

		///<summary>High cloud cover (%)</summary>
		[Description("High cloud cover")] HighCloudCover = 5,

		///<summary>Cloud water (kg m-2)</summary>
		[Description("Cloud water")] CloudWater = 6,

		///<summary>Cloud amount (%)</summary>
		[Description("Cloud amount")] CloudAmount = 7,

		///<summary>Cloud type (Code table (4.203))</summary>
		[Description("Cloud type")] CloudType = 8,

		///<summary>Thunderstorm maximum tops (m)</summary>
		[Description("Thunderstorm maximum tops")]
		ThunderstormMaximumTops = 9,

		///<summary>Thunderstorm coverage (Code table (4.204))</summary>
		[Description("Thunderstorm coverage")] ThunderstormCoverage = 10,

		///<summary>Cloud base (m)</summary>
		[Description("Cloud base")] CloudBase = 11,

		///<summary>Cloud top (m)</summary>
		[Description("Cloud top")] CloudTop = 12,

		///<summary>Ceiling (m)</summary>
		[Description("Ceiling")] Ceiling = 13,

		///<summary>Non-Convective Cloud Cover (%)</summary>
		[Description("Non-Convective Cloud Cover")] NonConvectiveCloudCover = 14,

		///<summary>Cloud Work Function (J kg-1)</summary>
		[Description("Cloud Work Function")] CloudWorkFunction = 15,

		///<summary>Convective Cloud Efficiency (Proportion)</summary>
		[Description("Convective Cloud Efficiency")] ConvectiveCloudEfficiency = 16,

		///<summary>Ice fraction of total condensate (Proportion)</summary>
		[Description("Ice fraction of total condensate")] IceFractionOfTotalCondensate = 21,

		///<summary>Cloud Cover (%)</summary>
		[Description("Cloud Cover")] CloudCover = 22,

		///<summary>Sunshine (Numeric)</summary>
		[Description("Sunshine")] Sunshine = 24,

		///<summary>Horizontal Extent of Cumulonimbus (CB) (%)</summary>
		[Description("Horizontal Extent of Cumulonimbus (CB)")] HorizontalExtentOfCumulonimbus = 25,

		///<summary>Height of Convective Cloud Base (m)</summary>
		[Description("Height of Convective Cloud Base")] HeightOfConvectiveCloudBase = 26,

		///<summary>Height of Convective Cloud Top (m)</summary>
		[Description("Height of Convective Cloud Top")] HeightOfConvectiveCloudTop = 27,

		///<summary>Number Concentration of Cloud Droplets (kg-1)</summary>
		[Description("Number Concentration of Cloud Droplets")] NumberConcentrationOfCloudDroplets = 28,

		///<summary>Number Concentration of Cloud Ice (kg-1)</summary>
		[Description("Number Concentration of Cloud Ice")] NumberConcentrationOfCloudIce = 29,

		///<summary>Number Density of Cloud Droplets (m-3)</summary>
		[Description("Number Density of Cloud Droplets")] NumberDensityOfCloudDroplets = 30,

		///<summary>Number Density of Cloud Ice (m-3)</summary>
		[Description("Number Density of Cloud Ice")] NumberDensityOfCloudIce = 31,

		///<summary>Fraction of Cloud Cover (Numeric)</summary>
		[Description("Fraction of Cloud Cover")] FractionOfCloudCover = 32,

		///<summary>Sunshine Duration (s)</summary>
		[Description("Sunshine Duration")] SunshineDuration = 33,

		///<summary>Surface Long Wave Effective Total Cloudiness (Numeric)</summary>
		[Description("Surface Long Wave Effective Total Cloudiness")] SurfaceLongWaveEffectiveTotalCloudiness = 34,

		///<summary>Surface Short Wave Effective Total Cloudiness (Numeric)</summary>
		[Description("Surface Short Wave Effective Total Cloudiness")] SurfaceShortWaveEffectiveTotalCloudiness = 35,

		///<summary>Fraction of Stratiform Precipitation Cover (Proportion)</summary>
		[Description("Fraction of Stratiform Precipitation Cover")] FractionOfStratiformPrecipitationCover = 36,

		///<summary>Fraction of Convective Precipitation Cover (Proportion)</summary>
		[Description("Fraction of Convective Precipitation Cover")] FractionOfConvectivePrecipitationCover = 37,

		///<summary>Mass Density of Cloud Droplets (kg m-3)</summary>
		[Description("Mass Density of Cloud Droplets")] MassDensityOfCloudDroplets = 38,

		///<summary>Mass Density of Cloud Ice (kg m-3)</summary>
		[Description("Mass Density of Cloud Ice")] MassDensityOfCloudIce = 39,

		///<summary>Mass Density of Convective Cloud Water Droplets (kg m-3)</summary>
		[Description("")] MassDensityOfConvectiveCloudWaterDroplets = 40,

		///<summary>Volume Fraction of Cloud Water Droplets (Numeric)</summary>
		[Description("Volume Fraction of Cloud Water Droplets")] VolumeFractionOfCloudWaterDroplets = 47,

		///<summary>Volume Fraction of Cloud Ice Particles (Numeric)</summary>
		[Description("Volume Fraction of Cloud Ice Particles")] VolumeFractionOfCloudIceParticles = 48,

		///<summary>Volume Fraction of Cloud (Ice and/or Water) (Numeric)</summary>
		[Description("Volume Fraction of Cloud (Ice and/or Water)")] VolumeFractionOfCloud_IceAndOrWater = 49,

		#endregion

		#region Product Discipline 0: Meteorological products, Parameter Category 7: Thermodynamic Stability Indices

		///<summary>Parcel lifted index (to 500 hPa) (K)</summary>
		[Description("Parcel lifted index (to 500 hPa)")]
		ParcelLiftedIndex = 0,

		///<summary>Best lifted index (to 500 hPa) (K)</summary>
		[Description("Best lifted index (to 500 hPa)")]
		BestLiftedIndex = 1,

		///<summary>K index (K)</summary>
		[Description("K index")] KIndex = 2,

		///<summary>KO index (K)</summary>
		[Description("KO index")] KoIndex = 3,

		///<summary>Total totals index (K)</summary>
		[Description("Total totals index")] TotalTotalsIndex = 4,

		///<summary>Sweat index (numeric)</summary>
		[Description("Sweat index")] SweatIndex = 5,

		///<summary>Convective available potential energy (J kg-1)</summary>
		[Description("Convective available potential energy")]
		ConvectiveAvailablePotentialEnergy = 6,

		///<summary>Convective inhibition (J kg-1)</summary>
		[Description("Convective inhibition")] ConvectiveInhibition = 7,

		///<summary>Storm relative helicity (J kg-1)</summary>
		[Description("Storm relative helicity")]
		StormRelativeHelicity = 8,

		///<summary>Energy helicity index (numeric)</summary>
		[Description("Energy helicity index")] EnergyHelicityIndex = 9,

		#endregion

		#region Product Discipline 0: Meteorological products, Parameter Category 13: Aerosols

		///<summary>Aerosol type (Code table (4.205))</summary>
		[Description("Aerosol type")] AerosolType = 0,

		#endregion

		#region Product Discipline 0: Meteorological products, Parameter Category 14: Trace Gases

		///<summary>Total ozone (Dobson)</summary>
		[Description("Total ozone")] TotalOzone = 0,

		#endregion

		#region Product Discipline 0 - Meteorological products, Parameter Category 15: Radar

		///<summary>Base spectrum width (m s-1)</summary>
		[Description("Base spectrum width")] BaseSpectrumWidth = 0,

		///<summary>Base reflectivity (dB)</summary>
		[Description("Base reflectivity")] BaseReflectivity = 1,

		///<summary>Base radial velocity (m s-1)</summary>
		[Description("Base radial velocity")] BaseRadialVelocity = 2,

		///<summary>Vertically-integrated liquid (kg m-1)</summary>
		[Description("Vertically-integrated liquid")]
		VerticallyIntegratedLiquid = 3,

		///<summary>Layer-maximum base reflectivity (dB)</summary>
		[Description("Layer-maximum base reflectivity")]
		LayerMaximumBaseReflectivity = 4,

		///<summary>Precipitation (kg m-2)</summary>
		[Description("Precipitation")] Precipitation = 5,

		///<summary>Radar spectra (1) (-)</summary>
		[Description("Radar spectra (1)")] RadarSpectra1 = 6,

		///<summary>Radar spectra (2) (-)</summary>
		[Description("Radar spectra (2)")] RadarSpectra2 = 7,

		///<summary>Radar spectra (3) (-)</summary>
		[Description("Radar spectra (3)")] RadarSpectra3 = 8,

		#endregion

		#region Product Discipline 0 - Meteorological products, Parameter Category 16: Forecast Radar Imagery

		///<summary>Equivalent radar reflectivity factor for rain (m m6 m-3)</summary>
		[Description("Equivalent radar reflectivity factor for rain (m m6 m-3)")] EquivalentRadarReflectivityFactorForRain = 0,

		///<summary>Equivalent radar reflectivity factor for snow (m m6 m-3)</summary>
		[Description("Equivalent radar reflectivity factor for snow (m m6 m-3)")] EquivalentRadarReflectivityFactorForSnow = 1,

		///<summary>Equivalent radar reflectivity factor for parameterized convection (m m6 m-3)</summary>
		[Description("Equivalent radar reflectivity factor for parameterized convection (m m6 m-3)")] EquivalentRadarReflectivityFactorForParameterizedConvection = 2,

		///<summary>Echo Top (m)</summary>
		[Description("Echo Top (m)")] EchoTop = 3,

		///<summary>Reflectivity (dB)</summary>
		[Description("Reflectivity (dB)")] Reflectivity = 4,

		///<summary>Composite reflectivity (dB)</summary>
		[Description("Composite reflectivity (dB)")] CompositeReflectivity = 5,

		///<summary>Equivalent radar reflectivity factor for rain (m m6 m-3)</summary>
		[Description("Equivalent radar reflectivity factor for rain (m m6 m-3)")] EquivalentRadarReflectivityFactorForRain2 = 192,

		///<summary>Equivalent radar reflectivity factor for snow (m m6 m-3)</summary>
		[Description("Equivalent radar reflectivity factor for snow (m m6 m-3)")] EquivalentRadarReflectivityFactorForSnow2 = 193,

		///<summary>Equivalent radar reflectivity factor for parameterized convection (m m6 m-3)</summary>
		[Description("Equivalent radar reflectivity factor for parameterized convection (m m6 m-3)")] EquivalentRadarReflectivityFactorForParameterizedConvection2 = 194,

		///<summary>Reflectivity (dB)</summary>
		[Description("Reflectivity (dB)")] Reflectivity2 = 195,

		///<summary>Composite reflectivity (dB)</summary>
		[Description("Composite reflectivity (dB)")] CompositeReflectivity2 = 196,

		///<summary>Echo Top (m)</summary>
		[Description("Echo Top (m)")] EchoTop2 = 197,

		///<summary>Hourly Maximum of Simulated Reflectivity (dB)</summary>
		[Description("Hourly Maximum of Simulated Reflectivity (dB)")] HourlyMaximumOfSimulatedReflectivity = 198,

		#endregion

		#region Product Discipline 0: Meteorological products, Parameter Category 18: Nuclear/radiology

		///<summary>Air concentration of Caesium 137 (Bq m-3)</summary>
		[Description("Air concentration of Caesium 137")]
		AirConcentrationOfCaesium137 = 0,

		///<summary>Air concentration of Iodine 131 (Bq m-3)</summary>
		[Description("Air concentration of Iodine 131")]
		AirConcentrationOfIodine131 = 1,

		///<summary>Air concentration of radioactive pollutant (Bq m-3)</summary>
		[Description("Air concentration of radioactive pollutant")]
		AirConcentrationOfRadioactivePollutant = 2,

		///<summary>Ground deposition of Caesium 137 (Bq m-2)</summary>
		[Description("Ground deposition of Caesium 137")]
		GroundDepositionOfCaesium137 = 3,

		///<summary>Ground deposition of Iodine 131 (Bq m-2)</summary>
		[Description("Ground deposition of Iodine 131")]
		GroundDepositionOfIodine131 = 4,

		///<summary>Ground deposition of radioactive pollutant (Bq m-2)</summary>
		[Description("Ground deposition of radioactive pollutant")]
		GroundDepositionOfRadioactivePollutant = 5,

		///<summary>Time-integrated air concentration of caesium pollutant (Bq s m-3)</summary>
		[Description("Time-integrated air concentration of caesium pollutant")]
		TimeIntegratedAirConcentrationOfCaesiumPollutant = 6,

		///<summary>Time-integrated air concentration of iodine pollutant (Bq s m-3)</summary>
		[Description("Time-integrated air concentration of iodine pollutant")]
		TimeIntegratedAirConcentrationOfIodinePollutant = 7,

		///<summary>Time-integrated air concentration of radioactive pollutant (Bq s m-3)</summary>
		[Description("Time-integrated air concentration of radioactive pollutant")]
		TimeIntegratedAirConcentrationOfRadioactivePollutant = 8,

		#endregion

		#region Product Discipline 0: Meteorological products, Parameter Category 19: Physical atmospheric properties

		///<summary>Visibility (m)</summary>
		[Description("Visibility")] Visibility = 0,

		///<summary>Albedo (%)</summary>
		[Description("Albedo")] Albedo = 1,

		///<summary>Thunderstorm probability (%)</summary>
		[Description("Thunderstorm probability")]
		ThunderstormProbability = 2,

		///<summary>mixed layer depth (m)</summary>
		[Description("mixed layer depth")] MixedLayerDepth = 3,

		///<summary>Volcanic ash (Code table (4.206))</summary>
		[Description("Volcanic ash")] VolcanicAsh = 4,

		///<summary>Icing top (m)</summary>
		[Description("Icing top")] IcingTop = 5,

		///<summary>Icing base (m)</summary>
		[Description("Icing base")] IcingBase = 6,

		///<summary>Icing (Code table (4.207))</summary>
		[Description("Icing")] Icing = 7,

		///<summary>Turbulence top (m)</summary>
		[Description("Turbulence top")] TurbulenceTop = 8,

		///<summary>Turbulence base (m)</summary>
		[Description("Turbulence base")] TurbulenceBase = 9,

		///<summary>Turbulence (Code table (4.208))</summary>
		[Description("Turbulence")] Turbulence = 10,

		///<summary>Turbulent kinetic energy (J kg-1)</summary>
		[Description("Turbulent kinetic energy")]
		TurbulentKineticEnergy = 11,

		///<summary>Planetary boundary layer regime (Code table (4.209))</summary>
		[Description("Planetary boundary layer regime")]
		PlanetaryBoundaryLayerRegime = 12,

		///<summary>Contrail intensity (Code table (4.210))</summary>
		[Description("Contrail intensity")] ContrailIntensity = 13,

		///<summary>Contrail engine type (Code table (4.211))</summary>
		[Description("Contrail engine type")] ContrailEngineType = 14,

		///<summary>Contrail top (m)</summary>
		[Description("Contrail top")] ContrailTop = 15,

		///<summary>Contrail (base)</summary>
		[Description("Contrail")] Contrail = 16,

		#endregion

		#region Product Discipline 0: Meteorological products, Parameter Category 253: ASCII character string

		///<summary>Arbitrary text string CCITTIA5</summary>
		[Description("Arbitrary text string CCITTIA5")]
		ArbitraryTextStringCcittia5 = 0,

		#endregion

		#region Product Discipline 1: Hydrologic products, Parameter Category 0: Hydrology basic products

		///<summary>Flash flood guidance (Encoded as an accumulation over a floating subinterval of time between the reference time and valid time) (kg m-2)</summary>
		[Description(
			"Flash flood guidance (Encoded as an accumulation over a floating subinterval of time between the reference time and valid time)")]
		FlashFloodGuidance = 0,

		///<summary>Flash flood runoff (Encoded as an accumulation over a floating subinterval of time) (kg m-2)</summary>
		[Description("Flash flood runoff (Encoded as an accumulation over a floating subinterval of time)")]
		FlashFloodRunoff = 1,

		///<summary>Remotely sensed snow cover (code table 4.215)</summary>
		[Description("Remotely sensed snow cover (code table 4.215)")]
		RemotelySensedSnowCover = 2,

		///<summary>Elevation of snow covered terrain (code table 4.216)</summary>
		[Description("Elevation of snow covered terrain (code table 4.216)")]
		ElevationOfSnowCoveredTerrain = 3,

		///<summary>Snow water equivalent percent of normal (%)</summary>
		[Description("Snow water equivalent percent of normal")]
		SnowWaterEquivalentPercentOfNormal = 4,

		#endregion

		#region Product Discipline 1: Hydrologic products, Parameter Category 1: Hydrology probabilities

		///<summary>Conditional percent precipitation amount fractile for an overall period (kg m-2(Encoded as an accumulation).)</summary>
		[Description("Conditional percent precipitation amount fractile for an overall period")]
		ConditionalPercentPrecipitationAmountFractileForAnOverallPeriod = 0,

		///<summary>Percent precipitation in a sub-period of an overall period (Encoded as per cent accumulation over the sub-period) (%)</summary>
		[Description(
			"Percent precipitation in a sub-period of an overall period (Encoded as per cent accumulation over the sub-period)")]
		PercentPrecipitationInASubPeriodOfAnOverallPeriod = 1,

		///<summary>Probability of 0.01 inch of precipitation (POP) (%)</summary>
		[Description("Probability of 0.01 inch of precipitation (POP)")]
		ProbabilityOf001InchOfPrecipitationPop = 2,

		#endregion

		#region Product Discipline 2: Land surface products, Parameter Category 0: Vegetation/Biomass

		///<summary>Land cover (1=land, 2=sea) (Proportion)</summary>
		[Description("Land cover (1=land, 2=sea)")]
		LandCover = 0,

		///<summary>Surface roughness (m)</summary>
		[Description("Surface roughness")] SurfaceRoughness = 1,

		///<summary>Soil temperature</summary>
		[Description("Soil temperature")] SoilTemperature = 2,

		///<summary>Soil moisture content (kg m-2)</summary>
		[Description("Soil moisture content")] SoilMoistureContent = 3,

		///<summary>Vegetation (%)</summary>
		[Description("Vegetation")] Vegetation = 4,

		///<summary>Water runoff (kg m-2)</summary>
		[Description("Water runoff")] WaterRunoff = 5,

		///<summary>Evapotranspiration (kg-2 s-1)</summary>
		[Description("Evapotranspiration")] Evapotranspiration = 6,

		///<summary>Model terrain height (m)</summary>
		[Description("Model terrain height")] ModelTerrainHeight = 7,

		///<summary>Land use (Code table (4.212))</summary>
		[Description("Land use")] LandUse = 8,

		#endregion

		#region Product Discipline 2: Land surface products, Parameter Category 3: Soil Products

		///<summary>Soil type (Code table (4.213))</summary>
		[Description("Soil type")] SoilType = 0,

		///<summary>Upper layer soil temperature (K)</summary>
		[Description("Upper layer soil temperature")]
		UpperLayerSoilTemperature = 1,

		///<summary>Upper layer soil moisture (kg m-3)</summary>
		[Description("Upper layer soil moisture")]
		UpperLayerSoilMoisture = 2,

		///<summary>Lower layer soil moisture (kg m-3)</summary>
		[Description("Lower layer soil moisture")]
		LowerLayerSoilMoisture = 3,

		///<summary>Bottom layer soil temperature (K)</summary>
		[Description("Bottom layer soil temperature")]
		BottomLayerSoilTemperature = 4,

		#endregion

		#region Product Discipline 3: Space products, Parameter Category 0: Image format products

		///<summary>Scaled radiance (numeric)</summary>
		[Description("Scaled radiance")] ScaledRadiance = 0,

		///<summary>Scaled albedo (numeric)</summary>
		[Description("Scaled albedo")] ScaledAlbedo = 1,

		///<summary>Scaled brightness temperature (numeric)</summary>
		[Description("Scaled brightness temperature")]
		ScaledBrightnessTemperature = 2,

		///<summary>Scaled precipitable water (numeric)</summary>
		[Description("Scaled precipitable water")]
		ScaledPrecipitableWater = 3,

		///<summary>Scaled lifted index (numeric)</summary>
		[Description("Scaled lifted index")] ScaledLiftedIndex = 4,

		///<summary>Scaled cloud top pressure (numeric)</summary>
		[Description("Scaled cloud top pressure")]
		ScaledCloudTopPressure = 5,

		///<summary>Scaled skin temperature (numeric)</summary>
		[Description("Scaled skin temperature")]
		ScaledSkinTemperature = 6,

		///<summary>Cloud mask (Code table 4.217)</summary>
		[Description("Cloud mask")] CloudMask = 7,

		#endregion

		#region Product Discipline 3: Space products, Parameter Category 1: Quantitative products

		///<summary>Estimated precipitation (kg m-2)</summary>
		[Description("Estimated precipitation")]
		EstimatedPrecipitation = 0,

		#endregion

		#region Product Discipline 10: Oceanographic products, Parameter Category 0: Waves

		///<summary>Wave spectra (1) (-)</summary>
		[Description("Wave spectra (1)")] WaveSpectra1 = 0,

		///<summary>Wave spectra (2) (-)</summary>
		[Description("Wave spectra (2)")] WaveSpectra2 = 1,

		///<summary>Wave spectra (3) (-)</summary>
		[Description("Wave spectra (3)")] WaveSpectra3 = 2,

		///<summary>Significant height of combined wind waves and swell (m)</summary>
		[Description("Significant height of combined wind waves and swell")]
		SignificantHeightOfCombinedWindWavesAndSwell = 3,

		///<summary>Direction of wind waves (Degree true)</summary>
		[Description("Direction of wind waves")]
		DirectionOfWindWaves = 4,

		///<summary>Significant height of wind waves (m)</summary>
		[Description("Significant height of wind waves")]
		SignificantHeightOfWindWaves = 5,

		///<summary>Mean period of wind waves (s)</summary>
		[Description("Mean period of wind waves")]
		MeanPeriodOfWindWaves = 6,

		///<summary>Direction of swell waves (Degree true)</summary>
		[Description("Direction of swell waves")]
		DirectionOfSwellWaves = 7,

		///<summary>Significant height of swell waves (m)</summary>
		[Description("Significant height of swell waves")]
		SignificantHeightOfSwellWaves = 8,

		///<summary>Mean period of swell waves (s)</summary>
		[Description("Mean period of swell waves")]
		MeanPeriodOfSwellWaves = 9,

		///<summary>Primary wave direction (Degree true)</summary>
		[Description("Primary wave direction")]
		PrimaryWaveDirection = 10,

		///<summary>Primary wave mean period (s)</summary>
		[Description("Primary wave mean period")]
		PrimaryWaveMeanPeriod = 11,

		///<summary>Secondary wave direction (Degree true)</summary>
		[Description("Secondary wave direction")]
		SecondaryWaveDirection = 12,

		///<summary>Secondary wave mean period (s)</summary>
		[Description("Secondary wave mean period")]
		SecondaryWaveMeanPeriod = 13,

		#endregion

		#region Product Discipline 10: Oceanographic products, Parameter Category 1: Currents

		///<summary>Current direction (Degree true)</summary>
		[Description("Current direction")] CurrentDirection = 0,

		///<summary>Current speed (m s-1)</summary>
		[Description("Current speed")] CurrentSpeed = 1,

		///<summary>u-component of current (m s-1)</summary>
		[Description("u-component of current")]
		UComponentOfCurrent = 2,

		///<summary>v-component of current (m s-1)</summary>
		[Description("v-component of current")]
		VComponentOfCurrent = 3,

		#endregion

		#region Product Discipline 10: Oceanographic products, Parameter Category 2: Ice

		///<summary>Ice cover (Proportion)</summary>
		[Description("Ice cover")] IceCover = 0,

		///<summary>Ice thickness (m)</summary>
		[Description("Ice thickness")] IceThickness = 1,

		///<summary>Direction of ice drift (Degree true)</summary>
		[Description("Direction of ice drift")]
		DirectionOfIceDrift = 2,

		///<summary>Speed of ice drift (m s-1)</summary>
		[Description("Speed of ice drift")] SpeedOfIceDrift = 3,

		///<summary>u-component of ice drift (m s-1)</summary>
		[Description("u-component of ice drift")]
		UComponentOfIceDrift = 4,

		///<summary>v-component of ice drift (m s-1)</summary>
		[Description("v-component of ice drift")]
		VComponentOfIceDrift = 5,

		///<summary>Ice growth rate (m s-1)</summary>
		[Description("Ice growth rate")] IceGrowthRate = 6,

		///<summary>Ice divergence (s-1)</summary>
		[Description("Ice divergence")] IceDivergence = 7,

		#endregion

		#region Product Discipline 10: Oceanographic products, Parameter Category 3: Surface Properties

		///<summary>Water temperature (K)</summary>
		[Description("Water temperature")] WaterTemperature = 0,

		///<summary>Deviation of sea level from mean (m)</summary>
		[Description("Deviation of sea level from mean")]
		DeviationOfSeaLevelFromMean = 1,

		#endregion

		#region Product Discipline 10: Oceanographic products, Parameter Category 4: Sub-surface Properties

		///<summary>Main thermocline depth (m)</summary>
		[Description("Main thermocline depth")]
		MainThermoclineDepth = 0,

		///<summary>Main thermocline anomaly (m)</summary>
		[Description("Main thermocline anomaly")]
		MainThermoclineAnomaly = 1,

		///<summary>Transient thermocline depth (m)</summary>
		[Description("Transient thermocline depth")]
		TransientThermoclineDepth = 2,

		///<summary>Salinity (kg kg-1)</summary>
		[Description("Salinity")] Salinity = 3,

		#endregion

		///<summary>Missing</summary>
		[Description("Missing")] Missing = 255,
	}
}