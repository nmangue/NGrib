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

namespace NGrib.Grib1
{
	/// <summary>
	/// A class representing the binary data section (BDS) of a GRIB record.
	/// </summary>
	public sealed class Grib1BinaryDataSection
	{
		/// <summary>
		/// Grid values as an array of float.
		/// </summary>
		public float[] Values { get; }

		/// <summary>
		/// Constant value for an undefined grid value.
		/// </summary>
		public static float MissingValue { get; } = -9999f;

		/// <summary>
		/// Length in bytes of this BDS.
		/// </summary>
		private int length;

		/// <summary>
		/// Buffer for one byte which will be processed bit by bit.
		/// </summary>
		private int bitBuf;

		/// <summary>
		/// Current bit position in <tt>bitBuf</tt>.
		/// </summary>
		private int bitPos;

		/// <summary> Indicates whether the BMS is represented by a single value
		/// Octet 12 is empty, and the data is represented by the reference value.
		/// </summary>
		private bool isConstant;

		/// <summary> Constructs a Grib1BinaryDataSection object from a raf.
		/// A bit map is defined.
		/// 
		/// </summary>
		/// <param name="raf">raf with BDS content
		/// </param>
		/// <param name="decimalscale">the exponent of the decimal scale
		/// </param>
		/// <param name="bms">bit map section of GRIB record
		/// 
		/// </param>
		/// <throws>  NotSupportedException  if stream contains no valid GRIB file </throws>
		//UPGRADE_TODO: Class 'java.io.RandomAccessFile' was converted to 'System.IO.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioRandomAccessFile'"
		internal Grib1BinaryDataSection(System.IO.Stream raf, int decimalscale, Grib1BitMapSection bms)
		{
			// octets 1-3 (section length)
			length = (int) GribNumbers.uint3(raf);


			// octet 4, 1st half (packing flag)
			int unusedbits = raf.ReadByte();

			// TODO Check this!!!
			if ((unusedbits & 192) != 0)
				throw new NotSupportedException("BDS: (octet 4, 1st half) not grid point data and simple packing ");

			// octet 4, 2nd half (number of unused bits at end of this section)
			unusedbits = unusedbits & 15;


			// octets 5-6 (binary scale factor)
			int binscale = GribNumbers.int2(raf);

			// octets 7-10 (reference point = minimum value)
			float refvalue = GribNumbers.float4(raf);

			// octet 11 (number of bits per value)
			int numbits = raf.ReadByte();

			if (numbits == 0)
				isConstant = true;


			// *** read values *******************************************************

			//UPGRADE_WARNING: Data types in Visual C# might be different.  Verify the accuracy of narrowing conversions. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1042'"
			float ref_Renamed = (float) (Math.Pow(10.0, -decimalscale) * refvalue);
			//UPGRADE_WARNING: Data types in Visual C# might be different.  Verify the accuracy of narrowing conversions. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1042'"
			float scale = (float) (Math.Pow(10.0, -decimalscale) * Math.Pow(2.0, binscale));

			if (bms != null)
			{
				bool[] bitmap = bms.Bitmap;

				Values = new float[bitmap.Length];
				for (int i = 0; i < bitmap.Length; i++)
				{
					if (bitmap[i])
					{
						if (!isConstant)
						{
							Values[i] = ref_Renamed + scale * bits2UInt(numbits, raf);
						}
						else
						{
							// rdg - added this to handle a constant valued parameter
							Values[i] = ref_Renamed;
						}
					}
					else
						Values[i] = MissingValue;
				}
			}
			else
			{
				// bms is null
				if (!isConstant)
				{

					//(((length - 11) * 8 - unusedbits) /  numbits));
					Values = new float[((length - 11) * 8 - unusedbits) / numbits];

					for (int i = 0; i < Values.Length; i++)
					{
						Values[i] = ref_Renamed + scale * bits2UInt(numbits, raf);
					}
				}
				else
				{
					// constant valued - same min and max
					int x = 0, y = 0;
					raf.Seek(raf.Position - 53, System.IO.SeekOrigin.Begin); // return to start of GDS
					length = (int) GribNumbers.uint3(raf);
					if (length == 42)
					{
						// Lambert/Mercator offset
						SupportClass.Skip(raf, 3);
						x = GribNumbers.int2(raf);
						y = GribNumbers.int2(raf);
					}
					else
					{
						SupportClass.Skip(raf, 7);
						length = (int) GribNumbers.uint3(raf);
						if (length == 32)
						{
							// Polar sterographic
							SupportClass.Skip(raf, 3);
							x = GribNumbers.int2(raf);
							y = GribNumbers.int2(raf);
						}
						else
						{
							x = y = 1;
							Console.Out.WriteLine("BDS constant value, can't determine array size");
						}
					}

					Values = new float[x * y];
					for (int i = 0; i < Values.Length; i++)
						Values[i] = ref_Renamed;
				}
			}
		} // end Grib1BinaryDataSection

		/// <summary> Convert bits (nb) to Unsigned Int .
		/// 
		/// </summary>
		/// <param name="nb">
		/// </param>
		/// <param name="raf">
		/// </param>
		/// <returns> int of BinaryDataSection section
		/// </returns>
		//UPGRADE_TODO: Class 'java.io.RandomAccessFile' was converted to 'System.IO.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioRandomAccessFile'"
		private int bits2UInt(int nb, System.IO.Stream raf)
		{
			int bitsLeft = nb;
			int result = 0;

			if (bitPos == 0)
			{
				bitBuf = raf.ReadByte();
				bitPos = 8;
			}

			while (true)
			{
				int shift = bitsLeft - bitPos;
				if (shift > 0)
				{
					// Consume the entire buffer
					result |= bitBuf << shift;
					bitsLeft -= bitPos;

					// Get the next byte from the RandomAccessFile
					bitBuf = raf.ReadByte();
					bitPos = 8;
				}
				else
				{
					// Consume a portion of the buffer
					result |= bitBuf >> -shift;
					bitPos -= bitsLeft;
					bitBuf &= 0xff >> (8 - bitPos); // mask off consumed bits

					return result;
				}
			} // end while
		} // end bits2Int

		// *** public methods ****************************************************

		// --Commented out by Inspection START (11/17/05 1:25 PM):
		//   /**
		//    * Get the length in bytes of this section.
		//    *
		//    * @return length in bytes of this section
		//    */
		//   public int getLength()
		//   {
		//      return length;
		//   }
		// --Commented out by Inspection STOP (11/17/05 1:25 PM)
	} // end class Grib1BinaryDataSection
}