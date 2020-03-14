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

namespace NGrib
{
	
	/// <summary> A class representing the product definition section (PDS) of a GRIB product.</summary>
	public sealed class Grib2ProductDefinitionSection : IGrib2ProductDefinitionSection
	{
		/// <summary> Number of this coordinates.</summary>
		/// <returns>  Coordinates number
		/// </returns>
		public int Coordinates
		{
			get
			{
				return coordinates;
			}
			
		}
		/// <summary> productDefinition.</summary>
		/// <returns> ProductDefinition
		/// </returns>
		public int ProductDefinition
		{
			get
			{
				return productDefinition;
			}
			
		}
		/// <summary> parameter Category .</summary>
		/// <returns> parameterCategory as int
		/// </returns>
		public int ParameterCategory
		{
			get
			{
				return parameterCategory;
			}
			
		}
		/// <summary> parameter Number.</summary>
		/// <returns> ParameterNumber
		/// </returns>
		public int ParameterNumber
		{
			get
			{
				return parameterNumber;
			}
			
		}
		/// <summary> typeGenProcess.</summary>
		/// <returns> GenProcess
		/// </returns>
		public int TypeGenProcess
		{
			get
			{
				return typeGenProcess;
			}
			
		}
		/// <summary> backGenProcess.</summary>
		/// <returns> BackGenProcess
		/// </returns>
		public int BackGenProcess
		{
			get
			{
				return backGenProcess;
			}
			
		}
		/// <summary> analysisGenProcess.</summary>
		/// <returns> analysisGenProcess
		/// </returns>
		public int AnalysisGenProcess
		{
			get
			{
				return analysisGenProcess;
			}
			
		}
		/// <summary> hoursAfter.</summary>
		/// <returns> HoursAfter
		/// </returns>
		public int HoursAfter
		{
			get
			{
				return hoursAfter;
			}
			
		}
		/// <summary> minutesAfter.</summary>
		/// <returns>  MinutesAfter
		/// </returns>
		public int MinutesAfter
		{
			get
			{
				return minutesAfter;
			}
			
		}
		/// <summary> returns timeRangeUnit .</summary>
		/// <returns> TimeRangeUnitName
		/// </returns>
		public int TimeRangeUnit
		{
			get
			{
				return timeRangeUnit;
			}
			
		}
		/// <summary> forecastTime.</summary>
		/// <returns> ForecastTime
		/// </returns>
		public int ForecastTime
		{
			get
			{
				return forecastTime;
			}
			
		}
		/// <summary> typeFirstFixedSurface.</summary>
		/// <returns> FirstFixedSurface as int
		/// </returns>
		public int TypeFirstFixedSurface
		{
			get
			{
				return typeFirstFixedSurface;
			}
			
		}
		/// <summary> typeFirstFixedSurface Name.</summary>
		/// <returns> FirstFixedSurfaceName
		/// </returns>
		public System.String TypeFirstFixedSurfaceName
		{
			get
			{
				return getTypeSurfaceName(typeFirstFixedSurface);
			}
			
		}
		/// <summary> valueFirstFixedSurface.</summary>
		/// <returns> FirstFixedSurfaceValue
		/// </returns>
		public float ValueFirstFixedSurface
		{
			get
			{
				return FirstFixedSurfaceValue;
			}
			
		}
		/// <summary> typeSecondFixedSurface.</summary>
		/// <returns>  SecondFixedSurface as int
		/// </returns>
		public int TypeSecondFixedSurface
		{
			get
			{
				return typeSecondFixedSurface;
			}
			
		}
		/// <summary> typeSecondFixedSurface Name.</summary>
		/// <returns>  SecondFixedSurfaceName
		/// </returns>
		public System.String TypeSecondFixedSurfaceName
		{
			get
			{
				return getTypeSurfaceName(typeSecondFixedSurface);
			}
			
		}
		/// <summary> valueSecondFixedSurface.</summary>
		/// <returns> SecondFixedSurfaceValue
		/// </returns>
		public float ValueSecondFixedSurface
		{
			get
			{
				return SecondFixedSurfaceValue;
			}
			
		}
		
		/// <summary> Length in bytes of this PDS.</summary>
		//UPGRADE_NOTE: Final was removed from the declaration of 'length '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private int length;
		
		/// <summary> Number of this section, should be 4.</summary>
		//UPGRADE_NOTE: Final was removed from the declaration of 'section '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private int section;
		
		/// <summary> Number of this coordinates.</summary>
		//UPGRADE_NOTE: Final was removed from the declaration of 'coordinates '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private int coordinates;
		
		/// <summary> productDefinition.</summary>
		//UPGRADE_NOTE: Final was removed from the declaration of 'productDefinition '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private int productDefinition;
		
		/// <summary> parameterCategory.</summary>
		private int parameterCategory;
		
		/// <summary> parameterNumber.</summary>
		private int parameterNumber;
		
		/// <summary> typeGenProcess.</summary>
		private int typeGenProcess;
		
		/// <summary> backGenProcess.</summary>
		private int backGenProcess;
		
		/// <summary> analysisGenProcess.</summary>
		private int analysisGenProcess;
		
		/// <summary> hoursAfter.</summary>
		private int hoursAfter;
		
		/// <summary> minutesAfter.</summary>
		private int minutesAfter;
		
		/// <summary> timeRangeUnit.</summary>
		internal int timeRangeUnit;
		
		/// <summary> forecastTime.</summary>
		private int forecastTime;
		
		/// <summary> typeFirstFixedSurface.</summary>
		private int typeFirstFixedSurface;
		
		/// <summary> value of FirstFixedSurface.
		/// 
		/// </summary>
		private float FirstFixedSurfaceValue;
		
		/// <summary> typeSecondFixedSurface.</summary>
		private int typeSecondFixedSurface;
		
		/// <summary> SecondFixedSurface Value.</summary>
		private float SecondFixedSurfaceValue;
		
		/// <summary>  number of bands.</summary>
		private int nb;
		
		// *** constructors *******************************************************
		
		/// <summary> Constructs a Grib2ProductDefinitionSection  object from a raf.
		/// 
		/// </summary>
		/// <param name="raf">RandomAccessFile with PDS content
		/// 
		/// </param>
		/// <throws>  IOException  if raf contains no valid GRIB file </throws>
		//UPGRADE_TODO: Class 'java.io.RandomAccessFile' was converted to 'System.IO.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioRandomAccessFile'"
		public Grib2ProductDefinitionSection(System.IO.FileStream raf)
		{
			// octets 1-4 (Length of PDS)
			length = GribNumbers.int4(raf);
			//System.out.println( "PDS length=" + length );
			
			// octet 5
			section = raf.ReadByte();
			//System.out.println( "PDS is 4, section=" + section );
			
			// octet 6-7
			coordinates = GribNumbers.int2(raf);
			//System.out.println( "PDS coordinates=" + coordinates );
			
			// octet 8-9
			productDefinition = GribNumbers.int2(raf);
			//System.out.println( "PDS productDefinition=" + productDefinition );
			
			switch (productDefinition)
			{
				
				
				// Analysis or forecast at a horizontal level or in a horizontal
				// layer at a point in time
				case 0: 
				case 1: 
				case 2: 
				case 3: 
				case 4: 
				case 5: 
				case 6: 
				case 7: 
				case 8:  {
						
						// octet 10
						parameterCategory = raf.ReadByte();
						//System.out.println( "PDS parameterCategory=" + 
						//parameterCategory );
						
						// octet 11
						parameterNumber = raf.ReadByte();
						//System.out.println( "PDS parameterNumber=" + parameterNumber );
						
						// octet 12
						typeGenProcess = raf.ReadByte();
						//System.out.println( "PDS typeGenProcess=" + typeGenProcess );
						
						// octet 13
						backGenProcess = raf.ReadByte();
						//System.out.println( "PDS backGenProcess=" + backGenProcess );
						
						// octet 14
						analysisGenProcess = raf.ReadByte();
						//System.out.println( "PDS analysisGenProcess=" + 
						//analysisGenProcess );
						
						// octet 15-16
						hoursAfter = GribNumbers.int2(raf);
						//System.out.println( "PDS hoursAfter=" + hoursAfter );
						
						// octet 17
						minutesAfter = raf.ReadByte();
						//System.out.println( "PDS minutesAfter=" + minutesAfter );
						
						// octet 18
						timeRangeUnit = raf.ReadByte();
						//System.out.println( "PDS timeRangeUnit=" + timeRangeUnit );
						
						// octet 19-22
						forecastTime = GribNumbers.int4(raf);
						//System.out.println( "PDS forecastTime=" + forecastTime );
						
						// octet 23
						typeFirstFixedSurface = raf.ReadByte();
						//System.out.println( "PDS typeFirstFixedSurface=" + 
						//     typeFirstFixedSurface );
						
						// octet 24
						int scaleFirstFixedSurface = raf.ReadByte();
						//System.out.println( "PDS scaleFirstFixedSurface=" + 
						//     scaleFirstFixedSurface );
						
						// octet 25-28
						int valueFirstFixedSurface = GribNumbers.int4(raf);
						//System.out.println( "PDS valueFirstFixedSurface=" + 
						//     valueFirstFixedSurface );
						
						//UPGRADE_WARNING: Data types in Visual C# might be different.  Verify the accuracy of narrowing conversions. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1042'"
						FirstFixedSurfaceValue = (float) ((scaleFirstFixedSurface == 0 || valueFirstFixedSurface == 0)?valueFirstFixedSurface:System.Math.Pow(valueFirstFixedSurface, - scaleFirstFixedSurface));
						
						// octet 29
						typeSecondFixedSurface = raf.ReadByte();
						//System.out.println( "PDS typeSecondFixedSurface=" + 
						//typeSecondFixedSurface );
						
						// octet 30
						int scaleSecondFixedSurface = raf.ReadByte();
						//System.out.println( "PDS scaleSecondFixedSurface=" + 
						//scaleSecondFixedSurface );
						
						// octet 31-34
						int valueSecondFixedSurface = GribNumbers.int4(raf);
						//System.out.println( "PDS valueSecondFixedSurface=" + 
						//valueSecondFixedSurface );
						
						//UPGRADE_WARNING: Data types in Visual C# might be different.  Verify the accuracy of narrowing conversions. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1042'"
						SecondFixedSurfaceValue = (float) ((scaleSecondFixedSurface == 0 || valueSecondFixedSurface == 0)?valueSecondFixedSurface:System.Math.Pow(valueSecondFixedSurface, - scaleSecondFixedSurface));
						
						
						// Individual ensemble forecast, control and perturbed, at a
						// horizontal level or in a horizontal layer at a point in time
						if (productDefinition == 1)
						{
							System.Console.Out.WriteLine("PDS productDefinition == 1 not done");
							
							//Derived forecast based on all ensemble members at a horizontal 
							// level or in a horizontal layer at a point in time
						}
						else if (productDefinition == 2)
						{
							System.Console.Out.WriteLine("PDS productDefinition == 2 not done");
							
							// Derived forecasts based on a cluster of ensemble members over
							// a rectangular area at a horizontal level or in a horizontal layer
							// at a point in time
						}
						else if (productDefinition == 3)
						{
							System.Console.Out.WriteLine("PDS productDefinition == 3 not done");
							
							// Derived forecasts based on a cluster of ensemble members
							// over a circular area at a horizontal level or in a horizontal
							// layer at a point in time
						}
						else if (productDefinition == 4)
						{
							System.Console.Out.WriteLine("PDS productDefinition == 4 not done");
							
							// Probability forecasts at a horizontal level or in a horizontal 
							//  layer at a point in time
						}
						else if (productDefinition == 5)
						{
							System.Console.Out.WriteLine("PDS productDefinition == 5 not done");
							
							// Percentile forecasts at a horizontal level or in a horizontal layer
							// at a point in time
						}
						else if (productDefinition == 6)
						{
							System.Console.Out.WriteLine("PDS productDefinition == 6 not done");
							
							// Analysis or forecast error at a horizontal level or in a horizontal 
							// layer at a point in time
						}
						else if (productDefinition == 7)
						{
							System.Console.Out.WriteLine("PDS productDefinition == 7 not done");
							
							// Average, accumulation, and/or extreme values at a horizontal
							// level or in a horizontal layer in a continuous or non-continuous
							// time interval
						}
						else if (productDefinition == 8)
						{
							//System.out.println( "PDS productDefinition == 8 " );
							//  35-41 bytes
							int year = GribNumbers.int2(raf);
							int month = (raf.ReadByte()) - 1;
							int day = raf.ReadByte();
							int hour = raf.ReadByte();
							int minute = raf.ReadByte();
							int second = raf.ReadByte();
							//System.out.println( "PDS date:" + year +":" + month +
							//":" + day + ":" + hour +":" + minute +":" + second );
							
							// 42 - 46
							int timeRanges = raf.ReadByte();
							//System.out.println( "PDS timeRanges=" + timeRanges ) ;
							int missingDataValues = GribNumbers.int4(raf);
							//System.out.println( "PDS missingDataValues=" + missingDataValues ) ;
							// 47 - 48
							int outmostTimeRange = raf.ReadByte();
							//System.out.println( "PDS outmostTimeRange=" + outmostTimeRange )
							;
							int missing = raf.ReadByte();
							//System.out.println( "PDS missing=" + missing ) ;
							// 49 - 53
							int statisticalProcess = raf.ReadByte();
							//System.out.println( "PDS statisticalProcess=" + statisticalProcess ) ;
							int timeIncrement = GribNumbers.int4(raf);
							//System.out.println( "PDS timeIncrement=" + timeIncrement ) ;
							
							// 54 - 58
							int indicatorTR = raf.ReadByte();
							//System.out.println( "PDS indicatorTR=" + indicatorTR ) ;
							
							int lengthTR = GribNumbers.int4(raf);
							//System.out.println( "PDS lengthTR=" + lengthTR ) ;
							
							//int indicatorSF = raf.read();
							//System.out.println( "PDS indicatorSF=" + indicatorSF ) ;
							
							//int incrementSF = GribNumbers.int4( raf );
							//System.out.println( "PDS incrementSF=" + incrementSF ) ;
						}
						break;
					} // cases 0-8
					
					// Radar product
				
				case 20:  {
						
						parameterCategory = raf.ReadByte();
						//System.out.println( "PDS parameterCategory=" + 
						//parameterCategory );
						
						parameterNumber = raf.ReadByte();
						//System.out.println( "PDS parameterNumber=" + parameterNumber );
						
						typeGenProcess = raf.ReadByte();
						//System.out.println( "PDS typeGenProcess=" + typeGenProcess );
						
						backGenProcess = raf.ReadByte();
						//System.out.println( "PDS backGenProcess=" + backGenProcess );
						
						hoursAfter = GribNumbers.int2(raf);
						//System.out.println( "PDS hoursAfter=" + hoursAfter );
						
						minutesAfter = raf.ReadByte();
						//System.out.println( "PDS minutesAfter=" + minutesAfter );
						
						timeRangeUnit = raf.ReadByte();
						//System.out.println( "PDS timeRangeUnit=" + timeRangeUnit );
						
						forecastTime = GribNumbers.int4(raf);
						//System.out.println( "PDS forecastTime=" + forecastTime );
						
						break;
					} // case 20
					
					// Satellite Product
				
				case 30:  {
						
						parameterCategory = raf.ReadByte();
						//System.out.println( "PDS parameterCategory=" + parameterCategory );
						
						parameterNumber = raf.ReadByte();
						//System.out.println( "PDS parameterNumber=" + parameterNumber );
						
						typeGenProcess = raf.ReadByte();
						//System.out.println( "PDS typeGenProcess=" + typeGenProcess );
						
						backGenProcess = raf.ReadByte();
						//System.out.println( "PDS backGenProcess=" + backGenProcess );
						
						nb = raf.ReadByte();
						//System.out.println( "PDS nb =" + nb );
						for (int j = 0; j < nb; j++)
							SupportClass.Skip(raf, 10);
						break;
					} // case 30
					
					// CCITTIA5 character string
				
				case 254:  {
						
						parameterCategory = raf.ReadByte();
						//System.out.println( "PDS parameterCategory=" + 
						//parameterCategory );
						
						parameterNumber = raf.ReadByte();
						//System.out.println( "PDS parameterNumber=" + parameterNumber );
						
						//numberOfChars = GribNumbers.int4( raf );
						//System.out.println( "PDS numberOfChars=" + 
						//numberOfChars );
						break;
					} // case 254
				
				
				default: 
					break;
				
			} // end switch
		}
		
		// --Commented out by Inspection START (11/21/05 2:24 PM):
		//   /**
		//    * Get the byte length of this section.
		//    *
		//    * @return length in bytes of this section
		//    */
		//   public final int getLength()
		//   {
		//      return length;
		//   }
		// --Commented out by Inspection STOP (11/21/05 2:24 PM)
		
		// --Commented out by Inspection START (11/21/05 2:24 PM):
		//   /**
		//    * Number of this section, should be 4
		//    */
		//   public final int getSection()
		//   {
		//      return section;
		//   }
		// --Commented out by Inspection STOP (11/21/05 2:24 PM)
		
		/// <summary> product Definition  Name.</summary>
		/// <returns> ProductDefinitionName
		/// </returns>
		public System.String getProductDefinitionName()
		{
			return getProductDefinitionName(productDefinition);
		}
		
		/// <summary> productDefinition  Name.
		/// from code table 4.0.
		/// </summary>
		/// <param name="productDefinition">
		/// </param>
		/// <returns> ProductDefinitionName
		/// </returns>
		static public System.String getProductDefinitionName(int productDefinition)
		{
			switch (productDefinition)
			{
				
				
				case 0:  return "Analysis/forecast at horizontal level/layer";
				
				case 1:  return "Individual ensemble forecast, control and perturbed";
				
				case 2:  return "Derived forecast on all ensemble members";
				
				case 3:  return "Derived forecasts on cluster of ensemble members over rectangular area";
				
				case 4:  return "Derived forecasts on cluster of ensemble members over circular area";
				
				case 5:  return "Probability forecasts at a horizontal level";
				
				case 6:  return "Percentile forecasts at a horizontal level";
				
				case 7:  return "Analysis or forecast error at a horizontal level";
				
				case 8:  return "Average, accumulation, extreme values or other statistically processed value at a horizontal level";
				
				case 20:  return "Radar product";
				
				case 30:  return "Satellite product";
				
				case 254:  return "CCITTIA5 character string";
				
				
				default:  return "Unknown";
				
			}
		}
		
		/// <summary> returns    Time Range Unit Name.</summary>
		/// <returns> TimeRangeUnitName
		/// </returns>
		public System.String getTimeRangeUnitName()
		{
			return getTimeRangeUnitName(timeRangeUnit);
		}
		
		/// <summary> return Time Range Unit Name from code table 4.4.</summary>
		/// <param name="timeRangeUnit">
		/// </param>
		/// <returns> TimeRangeUnitName
		/// </returns>
		static public System.String getTimeRangeUnitName(int timeRangeUnit)
		{
			switch (timeRangeUnit)
			{
				
				case 0:  return "minutes";
				
				case 1:  return "hours";
				
				case 2:  return "days";
				
				case 3:  return "months";
				
				case 4:  return "years";
				
				case 5:  return "decade";
				
				case 6:  return "normal";
				
				case 7:  return "century";
				
				case 10:  return "3hours";
				
				case 11:  return "6hours";
				
				case 12:  return "12hours";
				
				case 13:  return "secs";
				}
			return "unknown";
		}
		
		/// <summary> type of vertical coordinate: Name
		/// code table 4.5.
		/// </summary>
		/// <param name="id">
		/// </param>
		/// <returns> SurfaceName
		/// </returns>
		static public System.String getTypeSurfaceName(int id)
		{
			switch (id)
			{
				
				case 0:  return "Reserved";
				
				case 1:  return "Ground or water surface";
				
				case 2:  return "Cloud base level";
				
				case 3:  return "Level of cloud tops";
				
				case 4:  return "Level of 0o C isotherm";
				
				case 5:  return "Level of adiabatic condensation lifted from the surface";
				
				case 6:  return "Maximum wind level";
				
				case 7:  return "Tropopause";
				
				case 8:  return "Nominal top of the atmosphere";
				
				case 9:  return "Sea bottom";
				
				case 20:  return "Isothermal level";
				
				case 100:  return "Isobaric surface";
				
				case 101:  return "Mean sea level";
				
				case 102:  return "Specific altitude above mean sea level";
				
				case 103:  return "Specified height level above ground";
				
				case 104:  return "Sigma level";
				
				case 105:  return "Hybrid level";
				
				case 106:  return "Depth below land surface";
				
				case 107:  return "Isentropic 'theta' level";
				
				case 108:  return "Level at specified pressure difference from ground to level";
				
				case 109:  return "Potential vorticity surface";
				
				case 111:  return "Eta* level";
				
				case 117:  return "Mixed layer depth";
				
				case 160:  return "Depth below sea level";
				
				case 200:  return "entire atmosphere layer";
				
				case 201:  return "entire ocean layer";
				
				case 204:  return "Highest tropospheric freezing level";
				
				case 206:  return "Grid scale cloud bottom level";
				
				case 207:  return "Grid scale cloud top level";
				
				case 209:  return "Boundary layer cloud bottom level";
				
				case 210:  return "Boundary layer cloud top level";
				
				case 211:  return "Boundary layer cloud layer";
				
				case 212:  return "Low cloud bottom level";
				
				case 213:  return "Low cloud top level";
				
				case 214:  return "Low cloud layer";
				
				case 222:  return "Middle cloud bottom level";
				
				case 223:  return "Middle cloud top level";
				
				case 224:  return "Middle cloud layer";
				
				case 232:  return "High cloud bottom level";
				
				case 233:  return "High cloud top level";
				
				case 234:  return "High cloud layer";
				
				case 235:  return "Ocean isotherm level";
				
				case 236:  return "Layer between two depths below ocean surface";
				
				case 237:  return "Bottom of ocean mixed layer";
				
				case 238:  return "Bottom of ocean isothermal layer";
				
				case 242:  return "Convective cloud bottom level";
				
				case 243:  return "Convective cloud top level";
				
				case 244:  return "Convective cloud layer";
				
				case 245:  return "Lowest level of the wet bulb zero";
				
				case 246:  return "Maximum equivalent potential temperature level";
				
				case 247:  return "Equilibrium level";
				
				case 248:  return "Shallow convective cloud bottom level";
				
				case 249:  return "Shallow convective cloud top level";
				
				case 251:  return "Deep convective cloud bottom level";
				
				case 252:  return "Deep convective cloud top level";
				
				case 255:  return "Missing";
				
				default:  return "Unknown=" + id;
				
			}
		} // end getTypeSurfaceName
		
		/// <summary> type of vertical coordinate: short Name
		/// derived from code table 4.5.
		/// </summary>
		/// <param name="id">
		/// </param>
		/// <returns> SurfaceNameShort
		/// </returns>
		static public System.String getTypeSurfaceNameShort(int id)
		{
			switch (id)
			{
				
				case 1:  return "surface";
				
				case 2:  return "cloud_base";
				
				case 3:  return "cloud_tops";
				
				case 4:  return "zeroDegC_isotherm";
				
				case 5:  return "adiabatic_condensation_lifted";
				
				case 6:  return "maximum_wind";
				
				case 7:  return "tropopause";
				
				case 8:  return "atmosphere_top";
				
				case 9:  return "sea_bottom";
				
				case 20:  return "isotherm";
				
				case 100:  return "pressure";
				
				case 101:  return "msl";
				
				case 102:  return "altitude_above_msl";
				
				case 103:  return "height_above_ground";
				
				case 104:  return "sigma";
				
				case 105:  return "hybrid";
				
				case 106:  return "depth_below_surface";
				
				case 107:  return "isentrope";
				
				case 108:  return "pressure_difference";
				
				case 109:  return "potential_vorticity_surface";
				
				case 111:  return "eta";
				
				case 117:  return "mixed_layer_depth";
				
				case 160:  return "depth_below_sea";
				
				case 200:  return "entire_atmosphere";
				
				case 201:  return "entire_ocean";
				
				case 204:  return "highest_tropospheric_freezing";
				
				case 206:  return "grid_scale_cloud_bottom";
				
				case 207:  return "grid_scale_cloud_top";
				
				case 209:  return "boundary_layer_cloud_bottom";
				
				case 210:  return "boundary_layer_cloud_top";
				
				case 211:  return "boundary_layer_cloud";
				
				case 212:  return "low_cloud_bottom";
				
				case 213:  return "low_cloud_top";
				
				case 214:  return "low_cloud";
				
				case 222:  return "middle_cloud_bottom";
				
				case 223:  return "middle_cloud_top";
				
				case 224:  return "middle_cloud";
				
				case 232:  return "high_cloud_bottom";
				
				case 233:  return "high_cloud_top";
				
				case 234:  return "high_cloud";
				
				case 235:  return "ocean_Isotherm";
				
				case 236:  return "layer_between_two_depths_below_ocean";
				
				case 237:  return "bottom_of_ocean_mixed";
				
				case 238:  return "bottom_of_ocean_isothermal";
				
				case 242:  return "convective_cloud_bottom";
				
				case 243:  return "convective_cloud_top";
				
				case 244:  return "convective_cloud";
				
				case 245:  return "lowest_level_of_the_wet_bulb_zero";
				
				case 246:  return "maximum_equivalent_potential_temperature";
				
				case 247:  return "equilibrium";
				
				case 248:  return "shallow_convective_cloud_bottom";
				
				case 249:  return "shallow_convective_cloud_top";
				
				case 251:  return "deep_convective_cloud_bottom";
				
				case 252:  return "deep convective_cloud_top";
				
				case 255:  return "";
				
				
				default:  return "Unknown" + id;
				
			}
		} // end getTypeSurfaceNameShort
		
		/// <summary> type of vertical coordinate: Units.
		/// code table 4.5.
		/// </summary>
		/// <param name="id">
		/// </param>
		/// <returns> surfaceUnit
		/// </returns>
		static public System.String getTypeSurfaceUnit(int id)
		{
			switch (id)
			{
				
				case 20:  return "K";
				
				case 100:  return "Pa";
				
				case 102:  return "m";
				
				case 103:  return "m";
				
				case 106:  return "m";
				
				case 107:  return "K";
				
				case 108:  return "Pa";
				
				case 109:  return "K m2 kg-1 s-1";
				
				case 117:  return "m";
				
				case 160:  return "m";
				
				case 235:  return "C 0.1";
				
				case 237:  return "m";
				
				case 238:  return "m";
				
				
				default:  return "";
				
			}
		} // end getTypeSurfaceUnit
	} // end Grib2ProductDefinitionSection
}