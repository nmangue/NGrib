using System;
using System.Numerics;

namespace NGrib
{
	internal static class BigEndianBitConverter
	{
		public static int ToUInt16(byte[] data, int startIndex)
		{
			var index = startIndex;
			return (data[index++] << 8) | data[index];
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
