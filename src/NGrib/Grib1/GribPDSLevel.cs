/*
 * This file is part of NGrib.
 *
 * Copyright © 2020 Nicolas Mangué
 * 
 * Copyright 2006-2010 Seaware AB, PO Box 1244, SE-131 28 
 * Nacka Strand, Sweden, info@seaware.se.
 * 
 * Copyright 1997-2006 Unidata Program Center/University 
 * Corporation for Atmospheric Research, P.O. Box 3000, Boulder, CO 80307,
 * support@unidata.ucar.edu.
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

/// <summary> GribPDSLevel.java  1.0  08/01/2002
/// 
/// Performs operations related to loading level information from Table 3.
/// </summary>
/// <author>  Capt Richard D. Gonzalez
/// </author>

namespace NGrib.Grib1
{
	/// <summary> A class containing static methods which deliver names of
	/// levels and units for byte codes from GRIB records.
	/// </summary>
	public sealed class GribPDSLevel
	{
		/// <summary> Index number from table 3 - can be used for comparison even if the
		/// description of the level changes.
		/// </summary>
		/// <returns> index
		/// </returns>
		public int Index
		{
			get { return index; }
		}

		/// <summary> Name of this level.</summary>
		/// <returns> name as String
		/// </returns>
		public System.String Name
		{
			get { return name; }
		}

		/// <summary> gets the 1st value for the level.</summary>
		/// <returns> level value 1
		/// </returns>
		public float Value1
		{
			get { return value1; }
		}

		/// <summary> gets the 2nd value for the level.</summary>
		/// <returns> level value 2
		/// </returns>
		public float Value2
		{
			get { return value2; }
		}

		/// <summary> Index number from table 3 - can be used for comparison even if the
		/// description of the level changes.
		/// </summary>
		//UPGRADE_NOTE: Final was removed from the declaration of 'index '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private int index;

		/// <summary> Name of the vertical coordinate/level.
		/// 
		/// </summary>
		private System.String name;

		/// <summary> Value of PDS octet10 if separate from 11, otherwise value from octet10&11.</summary>
		private float value1;

		/// <summary> Value of PDS octet11.</summary>
		private float value2;

		/// <summary> Constructor.  Creates a GribPDSLevel based on octets 10-12 of the PDS.
		/// Implements tables 3 and 3a.
		/// 
		/// </summary>
		/// <param name="pds10">part 1 of level code index
		/// </param>
		/// <param name="pds11">part 2 of level code
		/// </param>
		/// <param name="pds12">part 3 of level code
		/// 
		/// </param>
		internal GribPDSLevel(int pds10, int pds11, int pds12)
		{
			int pds1112 = pds11 << 8 | pds12;
			index = pds10;
			switch (index)
			{
				case 0:
					name = "reserved";
					break;

				case 1:
					name = "surface";
					break;

				case 2:
					name = "cloud base level";
					break;

				case 3:
					name = "cloud top level";
					break;

				case 4:
					name = "0 degree isotherm level";
					break;

				case 5:
					name = "condensation level";
					break;

				case 6:
					name = "maximum wind level";
					break;

				case 7:
					name = "tropopause level";
					break;

				case 8:
					name = "nominal atmosphere top";
					break;

				case 9:
					name = "sea bottom";
					break;

				case 20:
					name = "Isothermal level";
					value1 = pds1112;
					break;

				case 100:
					name = "isobaric";
					value1 = pds1112;
					break;

				case 101:
					name = "layer between two isobaric levels";
					value1 = pds11 * 10; // convert from kPa to hPa - who uses kPa???
					value2 = pds12 * 10;
					break;

				case 102:
					name = "mean sea level";
					break;

				case 103:
					name = "Altitude above MSL";
					value1 = pds1112;
					break;

				case 104:
					name = "Layer between two altitudes above MSL";
					value1 = (pds11 * 100); // convert hm to m
					value2 = (pds12 * 100);
					break;

				case 105:
					name = "fixed height above ground";
					value1 = pds1112;
					break;

				case 106:
					name = "layer between two height levels";
					value1 = (pds11 * 100); // convert hm to m
					value2 = (pds12 * 100);
					break;

				case 107:
					name = "Sigma level";
					value1 = pds1112;
					break;

				case 108:
					name = "Layer between two sigma layers";
					value1 = pds11;
					value2 = pds12;
					break;

				case 109:
					name = "hybrid level";
					value1 = pds1112;
					break;

				case 110:
					name = "Layer between two hybrid levels";
					value1 = pds11;
					value2 = pds12;
					break;

				case 111:
					name = "Depth below land surface";
					value1 = pds1112;
					break;

				case 112:
					name = "Layer between two levels below land surface";
					value1 = pds11;
					value2 = pds12;
					break;

				case 113:
					name = "Isentropic theta level";
					value1 = pds1112;
					break;

				case 114:
					name = "Layer between two isentropic layers";
					value1 = pds11;
					value2 = pds12;
					break;

				case 115:
					name = "level at specified pressure difference from ground to level";
					value1 = pds1112;
					break;

				case 116:
					name = "Layer between pressure differences from ground to levels";
					value1 = pds11;
					value2 = pds12;
					break;

				case 117:
					name = "potential vorticity(pv) surface";
					value1 = pds1112;
					break;

				case 119:
					name = "Eta level";
					value1 = pds1112;
					break;

				case 120:
					name = "layer between two Eta levels";
					value1 = pds11;
					value2 = pds12;
					break;

				case 121:
					name = "layer between two isobaric surfaces";
					value1 = pds11;
					value2 = pds12;
					break;

				case 125:
					name = "Height above ground (high precision)";
					value1 = pds1112;
					break;

				case 126:
					name = "isobaric level";
					value1 = pds1112;
					break;

				case 128:
					name = "layer between two sigma levels";
					value1 = pds11;
					value2 = pds12;
					break;

				case 141:
					name = "layer between two isobaric surfaces";
					value1 = pds11 * 10; // convert from kPa to hPa - who uses kPa???
					value2 = pds12;
					break;

				case 160:
					name = "Depth below sea level";
					value1 = pds1112;
					break;

				case 200:
					name = "entire atmosphere layer";
					break;

				case 201:
					name = "entire ocean layer";
					break;

				case 204:
					name = "Highest tropospheric freezing level";
					break;

				case 206:
					name = "Grid scale cloud bottom level";
					break;

				case 207:
					name = "Grid scale cloud top level";
					break;

				case 209:
					name = "Boundary layer cloud bottom level";
					break;

				case 210:
					name = "Boundary layer cloud top level";
					break;

				case 211:
					name = "Boundary layer cloud layer";
					break;

				case 212:
					name = "Low cloud bottom level";
					break;

				case 213:
					name = "Low cloud top level";
					break;

				case 214:
					name = "Low Cloud Layer";
					break;

				case 222:
					name = "Middle cloud bottom level";
					break;

				case 223:
					name = "Middle cloud top level";
					break;

				case 224:
					name = "Middle Cloud Layer";
					break;

				case 232:
					name = "High cloud bottom level";
					break;

				case 233:
					name = "High cloud top level";
					break;

				case 234:
					name = "High Cloud Layer";
					break;

				case 235:
					name = "Ocean Isotherm Level";
					break;

				case 236:
					name = "Layer between two depths below ocean surface";
					value1 = pds11;
					value2 = pds12;
					break;

				case 237:
					name = "Bottom of Ocean Mixed Layer";
					break;

				case 238:
					name = "Bottom of Ocean Isothermal Layer";
					break;

				case 242:
					name = "Convective cloud bottom level";
					break;

				case 243:
					name = "Convective cloud top level";
					break;

				case 244:
					name = "Convective cloud layer";
					break;

				case 245:
					name = "Lowest level of the wet bulb zero";
					break;

				case 246:
					name = "Maximum equivalent potential temperature level";
					break;

				case 247:
					name = "Equilibrium level";
					break;

				case 248:
					name = "Shallow convective cloud bottom level";
					break;

				case 249:
					name = "Shallow convective cloud top level";
					break;

				case 251:
					name = "Deep convective cloud bottom level";
					break;

				case 252:
					name = "Deep convective cloud top level";
					break;

				default:
					name = "undefined level";
					System.Console.Out.WriteLine("GribPDSLevel: Table 3 level " + index + " is not implemented yet");
					break;
			}
		} // end GribPDSLevel

		/// <summary> type of vertical coordinate: Description or short Name
		/// derived from  ON388 - TABLE 3.
		/// </summary>
		/// <param name="id">
		/// </param>
		/// <returns> level description as String
		/// </returns>
		static public System.String getLevelDescription(int id)
		{
			switch (id)
			{
				case 0: return "Reserved";

				case 1: return "Ground or water surface";

				case 2: return "Cloud base level";

				case 3: return "Level of cloud tops";

				case 4: return "Level of 0o C isotherm";

				case 5: return "Level of adiabatic condensation lifted from the surface";

				case 6: return "Maximum wind level";

				case 7: return "Tropopause";

				case 8: return "Nominal top of the atmosphere";

				case 9: return "Sea bottom";

				case 20: return "Isothermal level";

				case 100: return "Isobaric surface";

				case 101: return "Layer between 2 isobaric levels";

				case 102: return "Mean sea level";

				case 103: return "Altitude above mean sea level";

				case 104: return "Layer between 2 altitudes above msl";

				case 105: return "Specified height level above ground";

				case 106: return "Layer between 2 specified height level above ground";

				case 107: return "Sigma level";

				case 108: return "Layer between 2 sigma levels";

				case 109: return "Hybrid level";

				case 110: return "Layer between 2 hybrid levels";

				case 111: return "Depth below land surface";

				case 112: return "Layer between 2 depths below land surface";

				case 113: return "Isentropic theta level";

				case 114: return "Layer between 2 isentropic levels";

				case 115: return "Level at specified pressure difference from ground to level";

				case 116: return "Layer between 2 level at pressure difference from ground to level";

				case 117: return "Potential vorticity surface";

				case 119: return "Eta level";

				case 120: return "Layer between 2 Eta levels";

				case 121: return "Layer between 2 isobaric levels";

				case 125: return "Specified height level above ground";

				case 126: return "Isobaric level";

				case 128: return "Layer between 2 sigma levels (hi precision)";

				case 141: return "Layer between 2 isobaric surfaces";

				case 160: return "Depth below sea level";

				case 200: return "Entire atmosphere";

				case 201: return "Entire ocean";

				case 204: return "Highest tropospheric freezing level";

				case 206: return "Grid scale cloud bottom level";

				case 207: return "Grid scale cloud top level";

				case 209: return "Boundary layer cloud bottom level";

				case 210: return "Boundary layer cloud top level";

				case 211: return "Boundary layer cloud layer";

				case 212: return "Low cloud bottom level";

				case 213: return "Low cloud top level";

				case 214: return "Low Cloud Layer";

				case 222: return "Middle cloud bottom level";

				case 223: return "Middle cloud top level";

				case 224: return "Middle Cloud Layer";

				case 232: return "High cloud bottom level";

				case 233: return "High cloud top level";

				case 234: return "High Cloud Layer";

				case 242: return "Convective cloud bottom level";

				case 243: return "Convective cloud top level";

				case 244: return "Convective cloud layer";

				case 245: return "Lowest level of the wet bulb zero";

				case 246: return "Maximum equivalent potential temperature level";

				case 247: return "Equilibrium level";

				case 248: return "Shallow convective cloud bottom level";

				case 249: return "Shallow convective cloud top level";

				case 251: return "Deep convective cloud bottom level";

				case 252: return "Deep convective cloud top level";

				case 255: return "Missing";


				default: return "Unknown=" + id;
			}
		}

		/// <summary> short name of level.</summary>
		/// <param name="id">
		/// </param>
		/// <returns> name of level
		/// </returns>
		static public System.String getNameShort(int id)
		{
			switch (id)
			{
				case 1: return "surface";

				case 2: return "cloud_base";

				case 3: return "cloud_tops";

				case 4: return "zeroDegC_isotherm";

				case 5: return "adiabatic_condensation_lifted";

				case 6: return "maximum_wind";

				case 7: return "tropopause";

				case 8: return "atmosphere_top";

				case 9: return "sea_bottom";

				case 20: return "isotherm";

				case 100: return "isobaric";

				case 101: return "layer_between_two_isobaric";

				case 102: return "msl";

				case 103: return "altitude_above_msl";

				case 104: return "layer_between_two_altitudes_above_msl";

				case 105: return "height_above_ground";

				case 106: return "layer_between_two_heights_above_ground";

				case 107: return "sigma";

				case 108: return "layer_between_two_sigmas";

				case 109: return "hybrid";

				case 110: return "layer_between_two_hybrids";

				case 111: return "depth_below_surface";

				case 112: return "layer_between_two_depths_below_surface";

				case 113: return "isentrope";

				case 114: return "layer_between_two_isentrope";

				case 115: return "pressure_difference";

				case 116: return "layer_between_two_pressure_difference_from_ground";

				case 117: return "potential_vorticity_surface";

				case 119: return "eta";

				case 120: return "layer_between_two_eta";

				case 121: return "layer_between_two_isobaric_surfaces";

				case 125: return "height_above_ground";

				case 126: return "isobaric";

				case 128: return "layer_between_two_sigmas_hi";

				case 141: return "layer_between_two_isobaric_surfaces";

				case 160: return "depth_below_sea";

				case 200: return "entire_atmosphere";

				case 201: return "entire_ocean";

				case 204: return "highest_tropospheric_freezing";

				case 206: return "grid_scale_cloud bottom";

				case 207: return "grid_scale_cloud_top";

				case 209: return "boundary_layer_cloud_bottom";

				case 210: return "boundary_layer_cloud_top";

				case 211: return "boundary_layer_cloud_layer";

				case 212: return "low_cloud_bottom";

				case 213: return "low_cloud_top";

				case 214: return "low_cloud_layer";

				case 222: return "middle_cloud_bottom";

				case 223: return "middle_cloud_top";

				case 224: return "middle_cloud_layer";

				case 232: return "high_cloud_bottom";

				case 233: return "high_cloud_top";

				case 234: return "high_cloud_layer";

				case 242: return "convective_cloud_bottom";

				case 243: return "convective_cloud_top";

				case 244: return "convective_cloud_layer";

				case 245: return "lowest_level_of_wet_bulb_zero";

				case 246: return "maximum_equivalent_potential_temperature";

				case 247: return "equilibrium";

				case 248: return "shallow_convective_cloud_bottom";

				case 249: return "shallow_convective_cloud_top";

				case 251: return "deep_convective_cloud_bottom";

				case 252: return "deep_convective_cloud_top";

				case 255: return "";


				default: return "Unknown" + id;
			}
		} // end getNameShort

		/// <summary> type of vertical coordinate: units
		/// derived from  ON388 - TABLE 3.
		/// </summary>
		/// <param name="id">units number
		/// </param>
		/// <returns> unit as String
		/// </returns>
		static public System.String getUnits(int id)
		{
			switch (id)
			{
				case 20:
				case 113:
				case 114:
					return "K";

				case 100:
				case 101:
				case 115:
				case 116:
				case 121:
				case 141:
					return "hPa";

				case 103:
				case 104:
				case 105:
				case 106:
				case 160:
					return "m";

				case 107:
				case 108:
				case 128:
					return "sigma";

				case 111:
				case 112:
				case 125:
					return "cm";

				case 117:
					return "10-6Km2/kgs";

				case 126:
					return "Pa";
			}

			return "";
		} // end getUnits
	}
}