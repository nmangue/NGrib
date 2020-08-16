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

using System;
using NGrib.Grib2.CodeTables;

namespace NGrib.Grib2.Templates.ProductDefinitions
{
	/// <summary>
	/// Product Definition Template 4.8:  Average, accumulation, and/or extreme values
	/// or other statistically processed values at a horizontal level or in a horizontal
	/// layer in a continuous or non-continuous time interval
	/// </summary>
	public class ProductDefinition0008 : ProductDefinition0000
	{
		/// <summary>
		/// Time of end of overall time interval.
		/// </summary>
		public DateTime OverallTimeIntervalEnd { get; }

		/// <summary>
		/// Number of time range specifications describing the time intervals used to calculate the statistically processed field.
		/// </summary>
		public int TimeRangeNumber { get; }

		/// <summary>
		/// Total number of data values missing in statistical process.
		/// </summary>
		public long MissingDataValuesTotalNumber { get; }

		/// <summary>
		/// Statistical process used to calculate the processed field from the field at each time increment during the time range.
		/// </summary>
		public int StatisticalProcess { get; }

		/// <summary>
		/// Type of time increment between successive fields used in the statistical processing.
		/// </summary>
		public long StatisticalProcessingTimeIncrementType { get; }

		/// <summary>
		/// Indicator of unit of time for time range over which statistical processing is done.
		/// </summary>
		public TimeRangeUnit StatisticalProcessingTimeRangeUnit { get; }

		/// <summary>
		///  Length of the time range over which statistical processing is done, in units defined by <c>StatisticalProcessingTimeRangeUnit</c>.
		/// </summary>
		public long StatisticalProcessingTimeRangeLength { get; }

		/// <summary>
		/// Indicator of unit of time for the increment between the successive fields used.
		/// </summary>
		public TimeRangeUnit SuccessiveFieldsIncrementUnit { get; }

		/// <summary>
		/// Time increment between successive fields, in units defined by <c>SuccessiveFieldsIncrementUnit</c>.
		/// </summary>
		public long SuccessiveFieldsTimeIncrement { get; }

		internal ProductDefinition0008(
			BufferedBinaryReader reader,
			Discipline discipline) : base(reader, discipline)
		{
			OverallTimeIntervalEnd = reader.ReadDateTime();
			RegisterContent(ProductDefinitionContent.OverallTimeIntervalEnd, () => OverallTimeIntervalEnd);

			// 42
			TimeRangeNumber = reader.ReadUInt8();

			// 43-46  
			MissingDataValuesTotalNumber = reader.ReadUInt32();

			//47
			StatisticalProcess = reader.ReadUInt8();

			//48
			StatisticalProcessingTimeIncrementType = reader.ReadUInt8();

			//49
			StatisticalProcessingTimeRangeUnit = (TimeRangeUnit) reader.ReadUInt8();

			//50-53
			StatisticalProcessingTimeRangeLength = reader.ReadUInt32();

			var timeRange = CalculateTimeRangeFrom(StatisticalProcessingTimeRangeUnit, StatisticalProcessingTimeRangeLength);
			if (timeRange.HasValue)
			{
				RegisterContent(ProductDefinitionContent.StatisticalProcessingTimeRange, () => timeRange.Value);
			}

			//54
			SuccessiveFieldsIncrementUnit = (TimeRangeUnit) reader.ReadUInt8();

			//55-58
			SuccessiveFieldsTimeIncrement = reader.ReadUInt32();

			var successiveFieldsTimeIncrement = CalculateTimeRangeFrom(SuccessiveFieldsIncrementUnit, SuccessiveFieldsTimeIncrement);
			if (successiveFieldsTimeIncrement.HasValue)
			{
				RegisterContent(ProductDefinitionContent.StatisticalProcessingTimeRange, () => successiveFieldsTimeIncrement.Value);
			}
		}
	}
}