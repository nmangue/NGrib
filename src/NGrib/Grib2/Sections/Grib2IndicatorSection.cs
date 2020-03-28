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
using System.IO;
using System.Linq;
using System.Numerics;
using NGrib.Grib2.CodeTables;

namespace NGrib.Grib2.Sections
{
	/// <summary>
	/// Represents the IndicatorSection (Section 0) of a GRIB record.
	/// </summary>
	public sealed class Grib2IndicatorSection
	{
		/// <summary>
		/// Length in bytes of IndicatorSection.
		/// </summary>
		public int Length { get; }

		/// <summary>
		/// Discipline - GRIB Master Table Number.
		/// </summary>
		public int DisciplineNumber { get; }

		/// <summary>
		/// Discipline from the GRIB Code Table 0.0.
		/// </summary>
		public Discipline? Discipline { get; }

		/// <summary>
		/// GRIB Edition Number.
		/// </summary>
		public int GribEdition { get; }

		/// <summary>
		/// Total length of GRIB message in octets (including Section 0).
		/// </summary>
		public BigInteger TotalLength { get; }

		public Grib2IndicatorSection(int length, int disciplineNumber, int gribEdition, BigInteger totalLength)
		{
			Length = length;
			DisciplineNumber = disciplineNumber;

			if (Enum.IsDefined(typeof(Discipline), disciplineNumber))
			{
				Discipline = (Discipline) disciplineNumber;
			}

			GribEdition = gribEdition;
			TotalLength = totalLength;
		}

		/// <summary> Constructs a <tt>Grib2IndicatorSection</tt> object from a byteBuffer.
		/// 
		/// </summary>
		/// <param name="raf">RandomAccessFile with IndicatorSection content
		/// 
		/// </param>
		/// <throws>  IOException  if raf contains no valid GRIB file </throws>
		public Grib2IndicatorSection(Stream raf)
		{
			//if Grib edition 1, get bytes for the gribLength
			int[] data = new int[3];
			for (int i = 0; i < 3; i++)
			{
				data[i] = raf.ReadByte();
			}

			// edition of GRIB specification
			GribEdition = raf.ReadByte();
			if (GribEdition == 2)
			{
				// length of GRIB record
				DisciplineNumber = (byte) data[2];
				TotalLength = GribNumbers.int8(raf);
				Length = 16;
			}
			else
			{
				throw new NotSupportedException("GRIB edition " + GribEdition + " is not yet supported");
			}
		}

		internal static Grib2IndicatorSection BuildFrom(BufferedBinaryReader reader)
		{
			var fileStart = reader.Read(Constants.GribFileStart.Length);
			if (!Constants.GribFileStart.SequenceEqual(fileStart))
			{
				throw new NoValidGribException("Grib2Input.scan failed to find header");
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
			const int indicatorSectionLength = 16;

			return new Grib2IndicatorSection(indicatorSectionLength, disciplineNumber, 2, totalLength);
		}
	}
}