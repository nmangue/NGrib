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
	/// <summary> A class that contains several static methods for converting multiple 
	/// bytes into one float or integer.
	/// 
	/// </summary>
	/// <author>  Robb Kambic  10/20/04
	/// </author>
	/// <version>  2.0
	/// </version>
	internal sealed class GribNumbers
	{
		/// <summary> if missing value is not defined use this value.</summary>
		public const int UNDEFINED = -9999;
		
		private static int[] bitmask = {128, 64, 32, 16, 8, 4, 2, 1};

		
		/**
		* Test if the given gribBitNumber is set in the test value.
		* 
		* @param value test the 8 bits in this value .
		* @param gribBitNumber one based, starting from highest bit. Must be between 1-8.
		* @return true if the given gribBitNumber is set.
		*/
		public static bool TestGribBitIsSet(int value, int gribBitNumber) {
			return (value & bitmask[gribBitNumber - 1]) != 0;
		}
		
		/// <summary> Convert 2 bytes into a signed integer.
		/// 
		/// </summary>
		/// <param name="raf">*
		/// </param>
		/// <returns> integer value
		/// </returns>
		/// <throws>  IOException </throws>
		//UPGRADE_TODO: Class 'java.io.RandomAccessFile' was converted to 'System.IO.Stream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioRandomAccessFile'"
		public static int int2(System.IO.Stream raf)
		{
			//byte[] bytes = ReadBytes(raf, 2);
			//return (int)BitConverter.ToInt16(bytes, 0);

			int a = raf.ReadByte();
			int b = raf.ReadByte();
			return int2(a, b);
		}

		public static int int2(int a, int b)
		{
			return (1 - ((a & 128) >> 6)) * ((a & 127) << 8 | b);
		}

		/// <summary> Convert 3 bytes into a signed integer.
		/// 
		/// </summary>
		/// <param name="raf">*
		/// </param>
		/// <returns> integer value
		/// </returns>
		/// <throws>  IOException </throws>
		public static int int3(System.IO.Stream raf)
		{
//            byte[] bytes = ReadBytes(raf, 3);
//            byte[] fourBytes = new byte[4];
//            bytes.CopyTo(fourBytes, 0);
//            fourBytes[3] = 0;
//            return BitConverter.ToInt32(fourBytes, 0);

			int a = raf.ReadByte();
			int b = raf.ReadByte();
			int c = raf.ReadByte();
			return (1 - ((a & 128) >> 6)) * ((a & 127) << 16 | b << 8 | c);
		}


		/// <summary> Convert 4 bytes into a signed integer.
		/// 
		/// </summary>
		/// <param name="raf">*
		/// </param>
		/// <returns> integer value
		/// </returns>
		/// <throws>  IOException </throws>
		public static int int4(System.IO.Stream raf)
		{
			//byte[] bytes = ReadBytes(raf, 4);
			//int i1 = BitConverter.ToInt32(bytes, 0);

			int a = raf.ReadByte();
			int b = raf.ReadByte();
			int c = raf.ReadByte();
			int d = raf.ReadByte();

			// all bits set to ones
			if (a == 0xff && b == 0xff && c == 0xff && d == 0xff)
				return UNDEFINED;

			int i2 = (1 - ((a & 128) >> 6)) * ((a & 127) << 24 | b << 16 | c << 8 | d);
			return i2;
		}


		/// <summary> Convert 2 bytes into an unsigned integer.
		/// 
		/// </summary>
		/// <param name="raf">*
		/// </param>
		/// <returns> integer value
		/// </returns>
		/// <throws>  IOException </throws>
		public static int uint2(System.IO.Stream raf)
		{
			//byte[] bytes = ReadBytes(raf, 2);
			//return (uint)BitConverter.ToUInt16(bytes, 0); 

			int a = raf.ReadByte();
			int b = raf.ReadByte();
			return a << 8 | b;
		}

		/// <summary> Convert 3 bytes into an unsigned integer.
		/// 
		/// </summary>
		/// <param name="raf">*
		/// </param>
		/// <returns> integer
		/// </returns>
		/// <throws>  IOException </throws>
		public static int uint3(System.IO.Stream raf)
		{
//            byte[] bytes = ReadBytes(raf, 3);
//            byte[] fourBytes = new byte[4];
//            bytes.CopyTo(fourBytes, 0);
//            fourBytes[3] = 0;
//            return BitConverter.ToUInt32(fourBytes, 0);

			int a = raf.ReadByte();
			int b = raf.ReadByte();
			int c = raf.ReadByte();
			return a << 16 | b << 8 | c;
		}


		/// <summary> Convert 4 bytes into a float.
		/// 
		/// </summary>
		/// <param name="raf">FileStream to read from
		/// </param>
		/// <returns> float
		/// </returns>
		/// <throws>  IOException </throws>
		public static float float4(System.IO.Stream raf)
		{
			int a = raf.ReadByte();
			int b = raf.ReadByte();
			int c = raf.ReadByte();
			int d = raf.ReadByte();

			int sgn, mant, exp;

			mant = b << 16 | c << 8 | d;
			if (mant == 0) return 0.0f;

			sgn = -(((a & 128) >> 6) - 1);
			exp = (a & 127) - 64;

			return (float) (sgn * Math.Pow(16.0, exp - 6) * mant);
		}

		public static float IEEEfloat4(System.IO.Stream raf)
		{
			byte[] bytes = ReadBytes(raf, 4);
			return BitConverter.ToSingle(bytes, 0);
		}


		/// <summary> Convert 8 bytes into a signed long.
		/// 
		/// </summary>
		/// <param name="raf">RandomAccessFile
		/// 
		/// </param>
		/// <returns> long value
		/// </returns>
		/// <throws>  IOException </throws>
		//UPGRADE_TODO: Class 'java.io.RandomAccessFile' was converted to 'System.IO.Stream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioRandomAccessFile'"
		public static long int8(System.IO.Stream raf)
		{
			int a = raf.ReadByte();
			int b = raf.ReadByte();
			int c = raf.ReadByte();
			int d = raf.ReadByte();
			int e = raf.ReadByte();
			int f = raf.ReadByte();
			int g = raf.ReadByte();
			int h = raf.ReadByte();

			return (1 - ((a & 128) >> 6)) * ((a & 127) << 56 | b << 48 | c << 40 | d << 32 | e << 24 | f << 16 | g << 8 | h);
		} // end int8


		public static byte[] ReadBytes(System.IO.Stream raf, int count)
		{
			byte[] bytes = new byte[count];
			raf.Read(bytes, 0, count);
			if (BitConverter.IsLittleEndian)
			{
				bytes = Swap(bytes);
			}

			return bytes;
		}

		public static byte[] Swap(byte[] bytes)
		{
			int nb = bytes.Length;
			byte[] swappedBytes = new byte[nb];
			for (int i = 0; i < nb; i++)
			{
				swappedBytes[i] = bytes[nb - 1 - i];
			}

			return swappedBytes;
		}
	} // end GribNumbers
}