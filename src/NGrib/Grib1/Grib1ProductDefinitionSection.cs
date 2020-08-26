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

/// <summary> Grib1ProductDefinitionSection.java  1.1  09/30/2004
/// 
/// Parameters use external tables, so program does not have to be modified to
/// add support for new tables.
/// </summary>
/// <seealso cref="Parameter, GribPDSParamTable, and GribPDSLevel classes.">
/// </seealso>

using System;

namespace NGrib.Grib1
{
	/// <summary> A class representing the product definition section (PDS) of a GRIB record.
	/// 
	/// </summary>
	public sealed class Grib1ProductDefinitionSection
	{
		/// <summary> Center as int.</summary>
		/// <returns> center_id
		/// </returns>
		public int Center
		{
			get { return center_id; }
		}

		/// <summary> Process Id as int.</summary>
		/// <returns> process_id
		/// </returns>
		public int Process_Id
		{
			get { return process_id; }
		}

		/// <summary> Grid ID as int.</summary>
		/// <returns> grid_id
		/// </returns>
		public int Grid_Id
		{
			get { return grid_id; }
		}

		/// <summary> SubCenter as int.</summary>
		/// <returns> subCenter
		/// </returns>
		public int SubCenter
		{
			get { return subcenter_id; }
		}

		/// <summary> gets the Table version as a int.</summary>
		/// <returns> table_version
		/// </returns>
		public int TableVersion
		{
			get { return table_version; }
		}

		/// <summary> Get the exponent of the decimal scale used for all data values.
		/// 
		/// </summary>
		/// <returns> exponent of decimal scale
		/// </returns>
		public int DecimalScale
		{
			get { return decscale; }
		}

		/// <summary> Get the number of the parameter.
		/// 
		/// </summary>
		/// <returns> index number of parameter in table
		/// </returns>
		public int ParameterNumber
		{
			get { return parameterNumber; }
		}

		/// <summary> Get the type of the parameter.
		/// 
		/// </summary>
		/// <returns> type of parameter
		/// </returns>
		public String Type
		{
			get { return parameter.Name; }
		}

		/// <summary> Get a descritpion of the parameter.
		/// 
		/// </summary>
		/// <returns> descritpion of parameter
		/// </returns>
		public String Description
		{
			get { return parameter.Description; }
		}

		/// <summary> Get the name of the unit of the parameter.
		/// 
		/// </summary>
		/// <returns> name of the unit of the parameter
		/// </returns>
		public String Unit
		{
			get { return parameter.Unit; }
		}

		/// <summary> Get the name for the type of level for forecast/analysis.
		/// 
		/// </summary>
		/// <returns> name of level (height or pressure)
		/// </returns>
		public String LevelName
		{
			get { return level.Name; }
		}

		/// <summary> Get the numeric value for this level.
		/// 
		/// </summary>
		/// <returns> name of level (height or pressure)
		/// </returns>
		public int LevelType
		{
			get { return level.Index; }
		}

		/// <summary> Get the numeric value for this level.
		/// 
		/// </summary>
		/// <returns> name of level (height or pressure)
		/// </returns>
		public int LevelValue1
		{
			get
			{
				//UPGRADE_WARNING: Data types in Visual C# might be different.  Verify the accuracy of narrowing conversions. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1042'"
				return (int) level.Value1;
			}
		}

		/// <summary> Get value 2 (if it exists) for this level.
		/// 
		/// </summary>
		/// <returns> name of level (height or pressure)
		/// </returns>
		public int LevelValue2
		{
			get
			{
				//UPGRADE_WARNING: Data types in Visual C# might be different.  Verify the accuracy of narrowing conversions. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1042'"
				return (int) level.Value2;
			}
		}

		/// <summary> Get the base (analysis) time of the forecast.
		/// 
		/// </summary>
		/// <returns> date and time
		/// </returns>
		public DateTime BaseTime
		{
			get { return baseTime; }
		}

		/// <summary> gets reference time as a String.</summary>
		/// <returns> referenceTime
		/// </returns>
		public String ReferenceTime
		{
			get { return referenceTime; }
		}

		/// <summary> Get the time of the forecast.
		/// 
		/// </summary>
		/// <returns> date and time
		/// </returns>
		public int ForecastTime
		{
			get { return forecastTime; }
		}

		/// <summary> Get the time unit.
		/// 
		/// </summary>
		/// <returns> time unit
		/// </returns>
		public int TimeUnitValue
		{
			get { return timeUnit; }
		}


		/// <summary> P1.</summary>
		/// <returns> p1
		/// </returns>
		public int P1
		{
			get { return p1; }
		}

		/// <summary> P2.</summary>
		/// <returns> p2
		/// </returns>
		public int P2
		{
			get { return p2; }
		}

		/// <summary> Get the parameter for this pds.</summary>
		/// <returns> parameter
		/// </returns>
		public Parameter Parameter
		{
			get { return parameter; }
		}

		/// <summary> gets the time unit ie hour.</summary>
		/// <returns> tUnit
		/// </returns>
		public String TimeUnit
		{
			get { return tUnit; }
		}

		/// <summary> ProductDefinition as a int.</summary>
		/// <returns> timeRangeValue
		/// </returns>
		public int ProductDefinition
		{
			get { return timeRangeValue; }
		}

		/// <summary> TimeRange as int.</summary>
		/// <returns> timeRangeValue
		/// </returns>
		public int TimeRange
		{
			get { return timeRangeValue; }
		}

		/// <summary>  TimeRange as String.</summary>
		/// <returns> timeRange
		/// </returns>
		public String TimeRangeString
		{
			get { return timeRange; }
		}

		/// <summary> PDS length did not correspond with read .</summary>
		/// <returns> lengthErr
		/// </returns>
		public bool LengthErr
		{
			get { return lengthErr; }
		}

		public int RefTimeT
		{
			get
			{
				DateTime startTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
				TimeSpan rt = refTime - startTime;
				int t = Convert.ToInt32(rt.TotalSeconds);
				return t;
			}
		}

		public Grib1WaveSpectra2DDirFreq WaveSpectra2DDirFreq
		{
			get { return waveSpectra2DDirFreq; }
		}

		//UPGRADE_ISSUE: Class 'java.text.SimpleDateFormat' was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1000_javatextSimpleDateFormat'"
		private static System.Globalization.DateTimeFormatInfo dateFormat;

		/// <summary> Length in bytes of this PDS.</summary>
		//UPGRADE_NOTE: Final was removed from the declaration of 'length '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private int length;

		/// <summary> Exponent of decimal scale.</summary>
		//UPGRADE_NOTE: Final was removed from the declaration of 'decscale '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private int decscale;

		/// <summary> ID of grid type.</summary>
		//UPGRADE_NOTE: Final was removed from the declaration of 'grid_id '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private int grid_id;

		/// <summary> True, if GDS exists.</summary>
		//UPGRADE_NOTE: Final was removed from the declaration of 'gds_exists '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private bool gds_exists;

		/// <summary> True, if BMS exists.</summary>
		//UPGRADE_NOTE: Final was removed from the declaration of 'bms_exists '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private bool bms_exists;

		/// <summary> The parameter as defined in the Parameter Table.</summary>
		//UPGRADE_NOTE: Final was removed from the declaration of 'parameter '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private Parameter parameter;

		/// <summary> parameterNumber.</summary>
		//UPGRADE_NOTE: Final was removed from the declaration of 'parameterNumber '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private int parameterNumber;

		/// <summary> Class containing the information about the level.  This helps to actually
		/// use the data, otherwise the string for level will have to be parsed.
		/// </summary>
		//UPGRADE_NOTE: Final was removed from the declaration of 'level '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private GribPDSLevel level;

		/// <summary> Model Run/Analysis/Reference time.
		/// 
		/// </summary>
		// TODO Why baseTime???
		private DateTime baseTime;

		private String referenceTime = "";

		/// <summary> Forecast time (valid time). </summary>
		private int forecastTime;

		/// <summary> Forecast time. (valid time 1)
		/// Also used as starting time when times represent a period.
		/// </summary>
		private int p1;

		/// <summary> Ending time when times represent a period (valid time 2).</summary>
		private int p2;

		/// <summary> Strings used in building a string to represent the time(s) for this PDS
		/// See the decoder for octet 21 to get an understanding.
		/// </summary>
		private String timeRange;

		//UPGRADE_NOTE: Final was removed from the declaration of 'timeRangeValue '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private int timeRangeValue;
		private String tUnit;

		/// <summary> Parameter Table Version number.</summary>
		//UPGRADE_NOTE: Final was removed from the declaration of 'table_version '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private int table_version;

		/// <summary> Identification of center e.g. 88 for Oslo.</summary>
		//UPGRADE_NOTE: Final was removed from the declaration of 'center_id '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private int center_id;

		/// <summary> Identification of subcenter.</summary>
		//UPGRADE_NOTE: Final was removed from the declaration of 'subcenter_id '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private int subcenter_id;

		/// <summary> Identification of Generating Process.</summary>
		//UPGRADE_NOTE: Final was removed from the declaration of 'process_id '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private int process_id;

		/// <summary> ensemble products have more information.</summary>
		private Grib1Ensemble epds;

		/// <summary>  PDS length not equal to number bytes read.</summary>
		//UPGRADE_NOTE: Final was removed from the declaration of 'lengthErr '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private bool lengthErr = false;

		private DateTime refTime;

		private int timeUnit;

		private Grib1WaveSpectra2DDirFreq waveSpectra2DDirFreq;

		/// <summary>
		/// Data reserved for originating centre use
		/// at the end of the section.
		/// </summary>
		/// <remarks>
		/// Each byte is stored as an item in the array.
		/// </remarks>
		public int[] CustomData { get; }

		// *** constructors *******************************************************

		/// <summary> Constructs a <tt>Grib1ProductDefinitionSection</tt> object from a raf.
		/// 
		/// </summary>
		/// <param name="raf">with PDS content
		/// 
		/// </param>
		/// <throws>  NotSupportedException  if raf contains no valid GRIB file </throws>
		//UPGRADE_TODO: Class 'java.io.RandomAccessFile' was converted to 'System.IO.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioRandomAccessFile'"
		internal Grib1ProductDefinitionSection(System.IO.Stream raf)
		{
			// octets 1-3 PDS length
			length = (int) GribNumbers.uint3(raf);


			// Paramter table octet 4
			table_version = raf.ReadByte();

			// Center  octet 5
			center_id = raf.ReadByte();

			// octet 6 Generating Process - See Table A
			process_id = raf.ReadByte();

			// octet 7 (id of grid type) - not supported yet
			grid_id = raf.ReadByte();

			//octet 8 (flag for presence of GDS and BMS)
			int exists = raf.ReadByte();
			//BKSystem.IO.BitStream s = new BKSystem.IO.BitStream(8);
//            s.WriteByte((byte)raf.ReadByte());
//            s.Position = 0;
//            sbyte exists;
//            s.Read(out exists);
//            bms_exists = (exists & 64) == 64;

			gds_exists = (exists & 128) == 128;
			bms_exists = (exists & 64) == 64;

			// octet 9 (parameter and unit)
			parameterNumber = raf.ReadByte();

			// octets 10-12 (level)
			int levelType = raf.ReadByte();
			int levelValue1 = raf.ReadByte();
			int levelValue2 = raf.ReadByte();
			level = new GribPDSLevel(levelType, levelValue1, levelValue2);

			// octets 13-17 (base time for reference time)
			int year = raf.ReadByte();
			int month = raf.ReadByte();
			int day = raf.ReadByte();
			int hour = raf.ReadByte();
			int minute = raf.ReadByte();

			// get info for forecast time
			// octet 18 Forecast time unit
			timeUnit = raf.ReadByte();

			switch (timeUnit)
			{
				case 0: // minute
					tUnit = "minute";
					break;

				case 1: // hours
					tUnit = "hour";
					break;

				case 2: // day
					tUnit = "day";
					break;

				case 3: // month
					tUnit = "month";
					break;

				case 4: //1 year
					tUnit = "1year";
					break;

				case 5: // decade
					tUnit = "decade";
					break;

				case 6: // normal
					tUnit = "day";
					break;

				case 7: // century
					tUnit = "century";
					break;

				case 10: //3 hours
					tUnit = "3hours";
					break;

				case 11: // 6 hours
					tUnit = "6hours";
					break;

				case 12: // 12 hours
					tUnit = "12hours";
					break;

				case 254: // second
					tUnit = "second";
					break;


				default:
					Console.Error.WriteLine("PDS: Time Unit " + timeUnit + " is not yet supported");
					break;
			}

			// octet 19 & 20 used to create Forecast time
			p1 = raf.ReadByte();
			p2 = raf.ReadByte();

			// octet 21 (time range indicator)
			timeRangeValue = raf.ReadByte();
			// forecast time is always at the end of the range

			switch (timeRangeValue)
			{
				case 0:
					timeRange = "product valid at RT + P1";
					forecastTime = p1;
					break;

				case 1:
					timeRange = "product valid for RT, P1=0";
					forecastTime = 0;
					break;

				case 2:
					timeRange = "product valid from (RT + P1) to (RT + P2)";
					forecastTime = p2;
					break;

				case 3:
					timeRange = "product is an average between (RT + P1) to (RT + P2)";
					forecastTime = p2;
					break;

				case 4:
					timeRange = "product is an accumulation between (RT + P1) to (RT + P2)";
					forecastTime = p2;
					break;

				case 5:
					timeRange = "product is the difference (RT + P2) - (RT + P1)";
					forecastTime = p2;
					break;

				case 6:
					timeRange = "product is an average from (RT - P1) to (RT - P2)";
					forecastTime = -p2;
					break;

				case 7:
					timeRange = "product is an average from (RT - P1) to (RT + P2)";
					forecastTime = p2;
					break;

				case 10:
					timeRange = "product valid at RT + P1";
					// p1 really consists of 2 bytes p1 and p2
					forecastTime = p1 = GribNumbers.int2(p1, p2);
					p2 = 0;
					break;

				case 51:
					timeRange = "mean value from RT to (RT + P2)";
					forecastTime = p2;
					break;

				default:
					Console.Error.WriteLine("PDS: Time Range Indicator " + timeRangeValue + " is not yet supported");
					break;
			}

			// octet 22 & 23
			int avgInclude = GribNumbers.int2(raf);

			// octet 24
			int avgMissing = raf.ReadByte();

			// octet 25
			int century = raf.ReadByte() - 1;

			// octet 26, sub center
			subcenter_id = raf.ReadByte();

			// octets 27-28 (decimal scale factor)
			decscale = GribNumbers.int2(raf);

			refTime = new DateTime(century * 100 + year, month, day, hour, minute, 0, DateTimeKind.Utc);
			baseTime = refTime;
			referenceTime = refTime.ToString(dateFormat);


			//(century * 100 + year) +"-" +
			//month + "-" + day + "T" + hour +":" + minute +":00Z" );


			// TODO
			/*
parameter_table = GribPDSParamTable.getParameterTable(center_id, subcenter_id, table_version);
parameter = parameter_table.getParameter(parameterNumber);
*/
			parameter = new Parameter();


			if (center_id == 7 && subcenter_id == 2)
			{
				CustomData = new int[0];

				// ensemble product
				epds = new Grib1Ensemble(raf, parameterNumber);
			}
			// Special handling of 2D Wave Spectra (single)
			else if (table_version == 140 && parameterNumber == 251)
			{
				CustomData = new int[0];

				SupportClass.Skip(raf, 12);
				int extDef = raf.ReadByte(); // Extension definition

				// Read ECMWF extension for 2D wave spectra single
				if (extDef == 13)
				{
					waveSpectra2DDirFreq = new Grib1WaveSpectra2DDirFreq(raf);
				}
			}
			else
			{
				// Ignore reserved bytes 29-40
				for (int i = 29; i <= Math.Min(length, 40); i++)
				{
					raf.ReadByte();
				}

				// Try to read extra bytes
				CustomData = new int[Math.Max(length - 40, 0)];
				for (int i = 0; i < CustomData.Length; i++)
				{
					CustomData[i] = raf.ReadByte();
				}
			}
		} // end Grib1ProductDefinitionSection

		// --Commented out by Inspection START (11/9/05 10:19 AM):
		//   /**
		//    * Get the byte length of this section.
		//    *
		//    * @return length in bytes of this section
		//    */
		//   public int getLength()
		//   {
		//      return length;
		//   }
		// --Commented out by Inspection STOP (11/9/05 10:19 AM)

		/// <summary> Check if GDS exists.
		/// 
		/// </summary>
		/// <returns> true, if GDS exists
		/// </returns>
		public bool gdsExists()
		{
			return gds_exists;
		}

		/// <summary> Check if BMS exists.
		/// 
		/// </summary>
		/// <returns> true, if BMS exists
		/// </returns>
		public bool bmsExists()
		{
			return bms_exists;
		}

		/// <summary> Name of Identification of center .</summary>
		/// <returns> Center Name as String
		/// </returns>
		public String getCenter_idName()
		{
			return getCenter_idName(center_id);
		}

		private static String getCenter_idName(int center)
		{
			switch (center)
			{
				case 0: return "WMO Secretariat";

				case 1:
				case 2: return "Melbourne";

				case 4:
				case 5: return "Moscow";

				case 7: return "US National Weather Service (NCEP)";

				case 8: return "US National Weather Service (NWSTG)";

				case 9: return "US National Weather Service (other)";

				case 10: return "Cairo (RSMC/RAFC)";

				case 12: return "Dakar (RSMC/RAFC)";

				case 14: return "Nairobi (RSMC/RAFC)";

				case 16: return "Atananarivo (RSMC)";

				case 18: return "Tunis Casablanca (RSMC)";

				case 20: return "Las Palmas (RAFC)";

				case 21: return "Algiers (RSMC)";

				case 22: return "Lagos (RSMC)";

				case 24: return "Pretoria (RSMC)";

				case 25: return "La R?union (RSMC)";

				case 26: return "Khabarovsk (RSMC)";

				case 28: return "New Delhi (RSMC/RAFC)";

				case 30: return "Novosibirsk (RSMC)";

				case 32: return "Tashkent (RSMC)";

				case 33: return "Jeddah (RSMC)";

				case 34: return "Tokyo (RSMC), Japan Meteorological Agency";

				case 36: return "Bangkok";

				case 37: return "Ulan Bator";

				case 38: return "Beijing (RSMC)";

				case 40: return "Seoul";

				case 41: return "Buenos Aires (RSMC/RAFC)";

				case 43: return "Brasilia (RSMC/RAFC)";

				case 45: return "Santiago";

				case 46: return "Brazilian Space Agency ? INPE";

				case 51: return "Miami (RSMC/RAFC)";

				case 52: return "Miami RSMC, National Hurricane Center";

				case 53:
				case 54: return "Montreal (RSMC)";

				case 55: return "San Francisco";

				case 57: return "Air Force Weather Agency";

				case 58: return "Fleet Numerical Meteorology and Oceanography Center";

				case 59: return "The NOAA Forecast Systems Laboratory";

				case 60: return "United States National Centre for Atmospheric Research (NCAR)";

				case 64: return "Honolulu";

				case 65: return "Darwin (RSMC)";

				case 67: return "Melbourne (RSMC)";

				case 69: return "Wellington (RSMC/RAFC)";

				case 71: return "Nadi (RSMC)";

				case 74: return "UK Meteorological Office Bracknell (RSMC)";

				case 76: return "Moscow (RSMC/RAFC)";

				case 78: return "Offenbach (RSMC)";

				case 80: return "Rome (RSMC)";

				case 82: return "Norrkoping";

				case 85: return "Toulouse (RSMC)";

				case 86: return "Helsinki";

				case 87: return "Belgrade";

				case 88: return "Oslo";

				case 89: return "Prague";

				case 90: return "Episkopi";

				case 91: return "Ankara";

				case 92: return "Frankfurt/Main (RAFC)";

				case 93: return "London (WAFC)";

				case 94: return "Copenhagen";

				case 95: return "Rota";

				case 96: return "Athens";

				case 97: return "European Space Agency (ESA)";

				case 98: return "ECMWF, RSMC";

				case 99: return "De Bilt";

				case 110: return "Hong-Kong";

				case 210: return "Frascati (ESA/ESRIN)";

				case 211: return "Lanion";

				case 212: return "Lisboa";

				case 213: return "Reykjavik";

				case 254: return "EUMETSAT Operation Centre";


				default: return "Unknown";
			}
		} // end getCenter_idName

		/// <summary> SubCenter as String.</summary>
		/// <param name="center">
		/// </param>
		/// <returns> subCenter
		/// </returns>
		public String getSubCenter_idName(int center)
		{
			if (center_id == 7)
			{
				//NWS
				switch (center)
				{
					case 0: return "WMO Secretariat";

					case 1: return "NCEP Re-Analysis Project";

					case 2: return "NCEP Ensemble Products";

					case 3: return "NCEP Central Operations";

					case 4: return "Environmental Modeling Center";

					case 5: return "Hydrometeorological Prediction Center";

					case 6: return "Marine Prediction Center";

					case 7: return "Climate Prediction Center";

					case 8: return "Aviation Weather Center";

					case 9: return "Storm Prediction Center";

					case 10: return "Tropical Prediction Center";

					case 11: return "NWS Techniques Development Laboratory";

					case 12: return "NESDIS Office of Research and Applications";

					case 13: return "FAA";

					case 14: return "NWS Meteorological Development Laboratory";

					case 15: return " The North American Regional Reanalysis (NARR) Project";
				}
			}

			return getCenter_idName(center);
		}

		/// <summary>  ProductDefinition name.</summary>
		/// <param name="type">
		/// </param>
		/// <returns>  name of ProductDefinition
		/// </returns>
		public static String getProductDefinitionName(int type)
		{
			switch (type)
			{
				case 0: return "Forecast/Uninitialized Analysis/Image Product";

				case 1: return "Initialized analysis product";

				case 2: return "Product with a valid time between P1 and P2";

				case 3:
				case 6:
				case 7: return "Average";

				case 4: return "Accumulation";

				case 5: return "Difference";

				case 10: return "product valid at reference time P1";

				case 51: return "Climatological Mean Value";

				case 113:
				case 115:
				case 117: return "Average of N forecasts";

				case 114:
				case 116: return "Accumulation of N forecasts";

				case 118: return "Temporal variance";

				case 119:
				case 125: return "Standard deviation of N forecasts";

				case 123: return "Average of N uninitialized analyses";

				case 124: return "Accumulation of N uninitialized analyses";

				case 128: return "Average of daily forecast accumulations";

				case 129: return "Average of successive forecast accumulations";

				case 130: return "Average of daily forecast averages";

				case 131: return "Average of successive forecast averages";

				case 132: return "Climatological Average of N analyses";

				case 133: return "Climatological Average of N forecasts";

				case 134: return "Climatological Root Mean Square difference between N forecasts and their verifying analyses";

				case 135: return "Climatological Standard Deviation of N forecasts from the mean of the same N forecasts";

				case 136: return "Climatological Standard Deviation of N analyses from the mean of the same N analyses";
			}

			return "Unknown";
		}

		static Grib1ProductDefinitionSection()
		{
			{
				dateFormat = new System.Globalization.DateTimeFormatInfo();
			}
		}
	} // end class Grib1ProductDefinitionSection
}