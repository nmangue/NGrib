﻿/*
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
using System.Numerics;

namespace NGrib
{
	internal static class BigEndianBitConverter
	{
		public const int Int8MinValue = -127;
		public const int Int32MinValue = -2147483647;

		public static int ToInt8(byte[] data, int startIndex) => ToInt8(data[startIndex]);

		public static int ToInt8(byte data) => (1 - ((data & 128) >> 6)) * (data & 127);

		public static int ToUInt16(byte[] data, int startIndex)
		{
			var index = startIndex;
			return (data[index++] << 8) | data[index];
		}

		public static int ToInt16(byte[] data, int startIndex)
		{
			var index = startIndex;
			return (1 - ((data[index] & 128) >> 6)) * ((data[index++] & 127) << 8 | data[index]);
		}

		public static long ToUInt32(byte[] data, int startIndex)
		{
			var index = startIndex;
			return ((uint) data[index++] << 24) |
			       ((uint) data[index++] << 16) |
			       ((uint) data[index++] <<  8) |
			       data[index];
		}
		
		public static BigInteger ToUInt64(byte[] data, int startIndex)
		{
			var index = startIndex;
			return ((ulong) data[index++] << 56) |
			       ((ulong) data[index++] << 48) |
			       ((ulong) data[index++] << 40) |
			       ((ulong) data[index++] << 32) |
			       ((ulong) data[index++] << 24) |
			       ((ulong) data[index++] << 16) |
			       ((ulong) data[index++] <<  8) |
			       data[index];
		}

		public static int ToInt32(byte[] data, int startIndex)
		{
			var index = startIndex;
			return (1 - ((data[index] & 128) >> 6)) * ((data[index++] & 127) << 24 |
			                                           data[index++] << 16 |
			                                           data[index++] << 8 |
			                                           data[index]);
		}

		public static float ToSingle(byte[] data, int startIndex)
		{
			if (BitConverter.IsLittleEndian)
			{
				var reversedBytes = new[]
				{
					data[startIndex+3],
					data[startIndex+2],
					data[startIndex+1],
					data[startIndex]
				};
				return BitConverter.ToSingle(reversedBytes, 0);
			}
			return BitConverter.ToSingle(data, startIndex);
		}
	}
}
