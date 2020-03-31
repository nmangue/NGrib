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
	/// Code table 4.5: Fixed surface types and units
	/// </summary>
	public enum FixedSurfaceType
	{
		///<summary>Ground or water surface</summary>
		[Description("Ground or water surface")]
		GroundOrWaterSurface = 1,

		///<summary>Cloud base level</summary>
		[Description("Cloud base level")] CloudBaseLevel = 2,

		///<summary>Level of cloud tops</summary>
		[Description("Level of cloud tops")] LevelOfCloudTops = 3,

		///<summary>Level of 0°C isotherm</summary>
		[Description("Level of 0°C isotherm")] LevelOf0CIsotherm = 4,

		///<summary>Level of adiabatic condensation lifted from the surface</summary>
		[Description("Level of adiabatic condensation lifted from the surface")]
		LevelOfAdiabaticCondensationLiftedFromTheSurface = 5,

		///<summary>Maximum wind level</summary>
		[Description("Maximum wind level")] MaximumWindLevel = 6,

		///<summary>Tropopause</summary>
		[Description("Tropopause")] Tropopause = 7,

		///<summary>Nominal top of the atmosphere</summary>
		[Description("Nominal top of the atmosphere")]
		NominalTopOfTheAtmosphere = 8,

		///<summary>Sea bottom</summary>
		[Description("Sea bottom")] SeaBottom = 9,

		///<summary>Isothermal level (K)</summary>
		[Description("Isothermal level")] IsothermalLevel = 20,

		///<summary>Isobaric surface (Pa)</summary>
		[Description("Isobaric surface")] IsobaricSurface = 100,

		///<summary>Mean sea level</summary>
		[Description("Mean sea level")] MeanSeaLevel = 101,

		///<summary>Specific altitude above mean sea level (m)</summary>
		[Description("Specific altitude above mean sea level")]
		SpecificAltitudeAboveMeanSeaLevel = 102,

		///<summary>Specified height level above ground (m)</summary>
		[Description("Specified height level above ground")]
		SpecifiedHeightLevelAboveGround = 103,

		///<summary>Sigma level (sigma value)</summary>
		[Description("Sigma level")] SigmaLevel = 104,

		///<summary>Hybrid level</summary>
		[Description("Hybrid level")] HybridLevel = 105,

		///<summary>Depth below land surface (m)</summary>
		[Description("Depth below land surface")]
		DepthBelowLandSurface = 106,

		///<summary>Isentropic (theta) level (K)</summary>
		[Description("Isentropic (theta) level")]
		IsentropicLevel = 107,

		///<summary>Level at specified pressure difference from ground to level (Pa)</summary>
		[Description("Level at specified pressure difference from ground to level")]
		LevelAtSpecifiedPressureDifferenceFromGroundToLevel = 108,

		///<summary>Potential vorticity surface (K m2 kg-1 s-1)</summary>
		[Description("Potential vorticity surface")]
		PotentialVorticitySurface = 109,

		///<summary>Eta* level</summary>
		[Description("Eta* level")] EtaLevel = 111,

		///<summary>Mixed layer depth (m)</summary>
		[Description("Mixed layer depth")] MixedLayerDepth = 117,

		///<summary>Depth below sea  level (m)</summary>
		[Description("Depth below sea  level")]
		DepthBelowSeaLevel = 160,

		///<summary>Missing </summary>
		[Description("Missing ")] Missing = 255,
	}
}