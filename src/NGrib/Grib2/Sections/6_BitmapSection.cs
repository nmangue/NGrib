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

using System;
using System.Collections;
using System.IO;

namespace NGrib.Grib2.Sections
{
	/// <summary>
	/// Section 6 - Bitmap Section
	/// </summary>
	public sealed class BitmapSection
	{
		/// <summary>
		/// Length of section in octets.
		/// </summary>
		public long Length { get; }

		/// <summary>
		/// Number of section.
		/// </summary>
		public int Section { get; }

		/// <summary>
		/// Bit-map indicator code.
		/// </summary>
		public int BitMapIndicatorCode { get; }

		/// <summary>
		/// Position of the bitmap start.
		/// </summary>
		public long BitmapOffset { get; }

		/// <summary>
		/// Number of data points.
		/// </summary>
		/// <remarks>
		/// As defined in the Grid Definition Section when there is no bitmap.
		/// </remarks>
		private readonly long dataPointsNumber;

		private BitmapSection(long length, int section, int bitmapIndicatorCode, long dataPointsNumber, long bitmapOffset)
		{
			BitmapOffset = bitmapOffset;
			Length = length;
			Section = section;
			BitMapIndicatorCode = bitmapIndicatorCode;
			this.dataPointsNumber = bitmapIndicatorCode == 0 ? (length - 6) * 8 : dataPointsNumber;
		}

		internal static BitmapSection BuildFrom(BufferedBinaryReader raf, long dataPointsNumber)
		{
			var length = raf.ReadUInt32();

			var section = raf.ReadUInt8();
			if (section != (int) SectionCode.BitmapSection)
			{
				throw new UnexpectedGribSectionException(
					SectionCode.BitmapSection,
					section
				);
			}

			var bitmapIndicator = raf.ReadUInt8();
			var bitmapOffset = raf.Position;

			// Skip through the bitmap data
			// There is no need to load it now
			raf.Skip((int) length - 6);

			return new BitmapSection(length, section, bitmapIndicator, dataPointsNumber, bitmapOffset);
		}

		internal BitArray GetBitmap(BufferedBinaryReader reader)
		{
			reader.Seek(BitmapOffset, SeekOrigin.Begin);

			var bitmap = new BitArray((int) dataPointsNumber, true);

			void TrySet(int i, bool value)
			{
				if (i < bitmap.Length)
				{
					bitmap[i] = value;
				}
			}

			if (BitMapIndicatorCode == 0)
			{
				// create new bit map, octet 4 contains number of unused bits at the end
				var i = 0;
				while (i < bitmap.Length)
				{
					var bitmapByte = (Bitmask) reader.ReadByte();

					TrySet(i++, bitmapByte.HasFlag(Bitmask.Bit1));
					TrySet(i++, bitmapByte.HasFlag(Bitmask.Bit2));
					TrySet(i++, bitmapByte.HasFlag(Bitmask.Bit3));
					TrySet(i++, bitmapByte.HasFlag(Bitmask.Bit4));
					TrySet(i++, bitmapByte.HasFlag(Bitmask.Bit5));
					TrySet(i++, bitmapByte.HasFlag(Bitmask.Bit6));
					TrySet(i++, bitmapByte.HasFlag(Bitmask.Bit7));
					TrySet(i++, bitmapByte.HasFlag(Bitmask.Bit8));
				}
			}

			return bitmap;
		}

		[Flags]
		private enum Bitmask : byte
		{
			Bit1 = 1 << 7,
			Bit2 = 1 << 6,
			Bit3 = 1 << 5,
			Bit4 = 1 << 4,
			Bit5 = 1 << 3,
			Bit6 = 1 << 2,
			Bit7 = 1 << 1,
			Bit8 = 1,
		}
	}
}