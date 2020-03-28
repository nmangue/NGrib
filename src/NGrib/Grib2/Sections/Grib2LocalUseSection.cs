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

using System.IO;

namespace NGrib.Grib2.Sections
{
	/// <summary> A class that represents the local use section (LUS) of a GRIB product.
	/// 
	/// </summary>
	public sealed class Grib2LocalUseSection
	{
		/// <summary> Length in bytes of this section.</summary>
		public long Length { get; }

		/// <summary> section number should be 2.</summary>
		public int Section { get; }

		public byte[] Bytes { get; }

		// *** constructors *******************************************************

		/// <summary> Constructs a <tt>Grib2LocalUseSection</tt> object from a raf.</summary>
		/// <param name="raf">
		/// </param>
		/// <throws>  IOException  if raf contains no valid GRIB product </throws>
		//UPGRADE_TODO: Class 'java.io.RandomAccessFile' was converted to 'System.IO.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioRandomAccessFile'"
		public Grib2LocalUseSection(FileStream raf)
		{
			// octets 1-4 (Length of GDS)
			Length = GribNumbers.int4(raf);

			Section = raf.ReadByte(); // This is section 2

			if (Section != 2)
			{
				// no local use section
				SupportClass.Skip(raf, -5);
				return;
			}
			else
			{
				//SupportClass.Skip(raf, length - 5);
				Bytes = new byte[Length - 5];
				int nb = raf.Read(Bytes, 0, (int) Length - 5);
				if (nb != Length - 5)
				{
					throw new NoValidGribException("Failed to read Local Use Section data");
				}
			}
		} // end of Grib2LocalUseSection

		public Grib2LocalUseSection(long length, int section, byte[] bytes)
		{
			Length = length;
			Section = section;
			Bytes = bytes;
		}

		internal static Grib2LocalUseSection? BuildFrom(BufferedBinaryReader reader)
		{
			// octets 1-4 (Length of GDS)
			var length = reader.ReadUInt32();

			var section = reader.ReadUInt8(); // This is section 2

			if (section != 2)
			{
				return null;
			}

			var bytes = reader.Read((int) length - 5);
			return new Grib2LocalUseSection(length, section, bytes);
		}

		internal static Grib2LocalUseSection? BuildFrom(BufferedBinaryReader reader, SectionInfo info)
		{
			if (info.SectionCode != (int) SectionCode.LocalUseSection)
			{
				return null;
			}

			var bytes = reader.Read((int)(info.Length - 5));
			return new Grib2LocalUseSection(info.Length, info.SectionCode, bytes);
		}
	} // end Grib2LocalUseSection
}