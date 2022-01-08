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

using NGrib.Grib2.CodeTables;
using System;

using NGrib.Grib2.Sections;

namespace NGrib.Grib2.Templates.ProductDefinitions
{

	/// <summary>
	/// Product Definition Template 4.0: Analysis or forecast at a horizontal level or in a horizontal layer at a point in time
	/// </summary>
	public class ProductDefinition0000 : WithBackgroundProductDefinition
	{
		/// <summary>
		/// Analysis or forecast generating processes identifier.
		/// </summary>
		public int GeneratingProcessIdentifier { get; }

		/// <summary>
		/// Hours of observational data cutoff after reference time.
		/// </summary>
		public int HoursAfter { get; }

		/// <summary>
		/// Minutes of observational data cutoff after reference time.
		/// </summary>
		public int MinutesAfter { get; }

		/// <summary>
		/// Timespan of observational data cutoff after reference time.
		/// </summary>
		public TimeSpan ObservationalDataCutoff { get; }

		/// <summary>
		/// Indicator of unit of time range.
		/// </summary>
		public TimeRangeUnit TimeRangeUnit { get; }

		/// <summary>
		/// Forecast time in units defined by indicator of unit of time range.
		/// </summary>
		public int ForecastTime { get; }

		/// <summary>
		/// Type of first fixed surface.
		/// </summary>
		public FixedSurfaceType FirstFixedSurfaceType { get; }

		/// <summary>
		/// Value of first fixed surface.
		/// </summary>
		public double? FirstFixedSurfaceValue { get; }

		/// <summary>
		/// Type of second fixed surface.
		/// </summary>
		public FixedSurfaceType SecondFixedSurfaceType { get; }

		/// <summary>
		/// Value of second fixed surface.
		/// </summary>
		public double? SecondFixedSurfaceValue { get; }

		internal ProductDefinition0000(BufferedBinaryReader reader, Discipline discipline,
		                               IdentificationSection identificationSection) : base(
			reader, discipline, identificationSection)
		{
			GeneratingProcessIdentifier = reader.ReadUInt8();
			HoursAfter = reader.ReadUInt16();
			MinutesAfter = reader.ReadUInt8();
			ObservationalDataCutoff = TimeSpan.FromHours(HoursAfter) + TimeSpan.FromMinutes(MinutesAfter);
			TimeRangeUnit = (TimeRangeUnit) reader.ReadUInt8();
			ForecastTime = reader.ReadInt32();

			FirstFixedSurfaceType = (FixedSurfaceType) reader.ReadUInt8();
			FirstFixedSurfaceValue = reader.ReadScaledValue();

			SecondFixedSurfaceType = (FixedSurfaceType) reader.ReadUInt8();
			SecondFixedSurfaceValue = reader.ReadScaledValue();

			RegisterContent(ProductDefinitionContent.GeneratingProcessId, () => GeneratingProcessIdentifier);
			RegisterContent(ProductDefinitionContent.ObservationalDataCutoff, () => ObservationalDataCutoff);
			var forecastTime = CalculateTimeRangeFrom(TimeRangeUnit, ForecastTime);
			if (forecastTime.HasValue) {
				RegisterContent(ProductDefinitionContent.ForecastTime, () => forecastTime.Value);
			}

			RegisterContent(ProductDefinitionContent.FirstFixedSurfaceType, () => FirstFixedSurfaceType);
			if (FirstFixedSurfaceValue.HasValue)
			{
				RegisterContent(ProductDefinitionContent.FirstFixedSurfaceValue, () => FirstFixedSurfaceValue.Value);
			}
			RegisterContent(ProductDefinitionContent.SecondFixedSurfaceType, () => SecondFixedSurfaceType);
			if (SecondFixedSurfaceValue.HasValue)
			{
				RegisterContent(ProductDefinitionContent.SecondFixedSurfaceValue, () => SecondFixedSurfaceValue.Value);
			}
		}
	}
}