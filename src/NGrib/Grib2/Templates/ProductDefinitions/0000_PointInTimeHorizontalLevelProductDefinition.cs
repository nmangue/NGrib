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

namespace NGrib.Grib2.Templates.ProductDefinitions
{
	/// <summary>
	/// Product Definition Template 4.0: Analysis or forecast at a horizontal level or in a horizontal layer at a point in time
	/// </summary>
	public class PointInTimeHorizontalLevelProductDefinition : WithBackgroundProductDefinition
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

		internal PointInTimeHorizontalLevelProductDefinition(BufferedBinaryReader reader, Discipline discipline) : base(
			reader, discipline)
		{
			GeneratingProcessIdentifier = reader.ReadUInt8();
			HoursAfter = reader.ReadUInt16();
			MinutesAfter = reader.ReadUInt8();
			TimeRangeUnit = (TimeRangeUnit) reader.ReadUInt8();
			ForecastTime = reader.ReadInt32();

			FirstFixedSurfaceType = (FixedSurfaceType) reader.ReadUInt8();
			FirstFixedSurfaceValue = reader.ReadScaledValue();

			SecondFixedSurfaceType = (FixedSurfaceType) reader.ReadUInt8();
			SecondFixedSurfaceValue = reader.ReadScaledValue();
		}
	}
}