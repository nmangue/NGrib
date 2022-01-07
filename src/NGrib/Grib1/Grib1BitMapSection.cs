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

namespace NGrib.Grib1
{
	/// <summary> A class that represents the bitmap section (BMS) of a GRIB record. It
	/// indicates grid points where no grid value is defined by a 0.
	/// 
	/// </summary>
	/// <version>  1.0
	/// </version>
	public sealed class Grib1BitMapSection
	{
		/// <summary> Get bit map.
		/// 
		/// </summary>
		/// <returns> bit map as array of boolean values
		/// </returns>
		public bool[] Bitmap { get; }

		/// <summary> Length in bytes of this section.</summary>
		//UPGRADE_NOTE: Final was removed from the declaration of 'length '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private int length;

		/// <summary> Constructs a <tt> Grib1BitMapSection</tt> object from a raf input stream.
		/// 
		/// </summary>
		/// <param name="raf">input stream with BMS content
		/// 
		/// </param>
		//UPGRADE_TODO: Class 'java.io.RandomAccessFile' was converted to 'System.IO.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioRandomAccessFile'"
		internal Grib1BitMapSection(System.IO.Stream raf)
		{
			int[] bitmask = new int[] {128, 64, 32, 16, 8, 4, 2, 1};

			// octet 1-3 (length of section)
			length = (int) GribNumbers.uint3(raf);


			// octet 4 unused bits
			int unused = raf.ReadByte();


			// octets 5-6
			int bm = GribNumbers.int2(raf);
			if (bm != 0)
			{
				System.Console.Out.WriteLine("BMS pre-defined BM provided by center");
				if ((length - 6) == 0)
					return;
				sbyte[] data = new sbyte[length - 6];
				SupportClass.ReadInput(raf, data, 0, data.Length);
				return;
			}

			sbyte[] data2 = new sbyte[length - 6];
			SupportClass.ReadInput(raf, data2, 0, data2.Length);

			// create new bit map, octet 4 contains number of unused bits at the end
			Bitmap = new bool[(length - 6) * 8 - unused];


			// fill bit map
			for (int i = 0; i < Bitmap.Length; i++)
				Bitmap[i] = (data2[i / 8] & bitmask[i % 8]) != 0;
		} // end Grib1BitMapSection
	} // end Grib1BitMapSection
}