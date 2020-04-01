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
using System.Linq;
using System.Numerics;
using NGrib.Grib2.CodeTables;

namespace NGrib.Grib2.Sections
{
	/// <summary>
	/// Section 0 - Indicator Section
	/// </summary>
	public sealed class IndicatorSection
	{
		private const int INDICATOR_SECTION_LENGTH = 16;

		/// <summary>
		/// Length of section in octets.
		/// </summary>
		public long Length { get; }

		/// <summary>
		/// Number of section.
		/// </summary>
		public int Section { get; }

		/// <summary>
		/// Discipline from the GRIB Code Table 0.0.
		/// </summary>
		public Discipline Discipline { get; }

		/// <summary>
		/// GRIB Edition Number.
		/// </summary>
		public int GribEdition { get; }

		/// <summary>
		/// Total length of GRIB message in octets (including Section 0).
		/// </summary>
		public BigInteger TotalLength { get; }

		private IndicatorSection(int disciplineCode, int gribEdition, BigInteger totalLength)
		{
			Length = INDICATOR_SECTION_LENGTH;
			Section = (int) SectionCode.IndicatorSection;
			Discipline = (Discipline)disciplineCode;

			GribEdition = gribEdition;
			TotalLength = totalLength;
		}

		internal static IndicatorSection BuildFrom(BufferedBinaryReader reader)
		{
			var fileStart = reader.Read(Constants.GribFileStart.Length);
			if (!Constants.GribFileStart.SequenceEqual(fileStart))
			{
				throw new BadGribFormatException("Invalid file start.");
			}

			// Ignore the 2 reserved bytes
			reader.Skip(2);

			var disciplineNumber = reader.ReadUInt8();
			var gribEdition = reader.ReadUInt8();
			if (gribEdition != 2)
			{
				throw new NotSupportedException($"Only GRIB edition 2 is supported. GRIB edition {gribEdition} is not yet supported");
			}

			var totalLength = reader.ReadUInt64();

			return new IndicatorSection(disciplineNumber, 2, totalLength);
		}
	}
}