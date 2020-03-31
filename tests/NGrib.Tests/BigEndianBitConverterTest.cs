using System.Numerics;
using NFluent;
using Xunit;

namespace NGrib.Tests
{
	public class BigEndianBitConverterTest
	{
		[Theory]
		[InlineData(new byte[] { 0, 13 }, 0, 13)]
		[InlineData(new byte[] { 0, 255 }, 0, 255)]
		[InlineData(new byte[] { 0x7, 0xe4 }, 0, 2020)]
		[InlineData(new byte[] { 0xff, 0x7, 0xfa }, 1, 2042)]
		[InlineData(new byte[] { 0xff, 0xff }, 0, 65535)]
		public void ToUInt16_Test(byte[] data, int startIndex, int value)
		{
			Check.That(BigEndianBitConverter.ToUInt16(data, startIndex)).Equals(value);
		}
		
		[Theory]
		[InlineData(new byte[] { 0, 0, 0, 13 }, 0, 13)]
		[InlineData(new byte[] { 0x24, 0x80, 0xc6, 0xd3 }, 0, 612419283)]
		[InlineData(new byte[] { 0xff, 0xff, 0xff, 0xff }, 0, 4294967295)]
		public void ToUInt32_Test(byte[] data, int startIndex, long value)
		{
			Check.That(BigEndianBitConverter.ToUInt32(data, startIndex)).Equals(value);
		}
		
		[Theory]
		[MemberData(nameof(UInt64TestData))]
		public void ToUInt64_Test(byte[] data, int startIndex, BigInteger value)
		{
			Check.That(BigEndianBitConverter.ToUInt64(data, startIndex)).Equals(value);
		}
		
		public static object[][] UInt64TestData = 
		{
			new object[] {new byte[] { 0, 0, 0, 0, 0, 0, 0, 13 }, 0, new BigInteger(13) },
			new object[] {new byte[] { 0x2a, 0xcc, 0, 0, 0, 0xb, 0x02, 0x54, 0x4c, 0x46, 0 }, 2, new BigInteger(47283719238) },
			new object[] {new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff }, 0, new BigInteger(18446744073709551615) },
		};


		[Theory]
		[InlineData(new byte[] { 74, 143, 11, 0 }, 0, 4687232f)]
		[InlineData(new byte[] { 69, 28, 5, 204 }, 0, 2496.3623f)]
		[InlineData(new byte[] { 0, 1, 2, 69, 12, 38, 226, 0 }, 3, 2242.43018f)]
		public void ToSingle_Test(byte[] data, int startIndex, float value)
		{
			Check.That(BigEndianBitConverter.ToSingle(data, startIndex)).Equals(value);
		}

		[Theory]
		[InlineData(new byte[] { 0b1000_0001 }, 0, -1)]
		[InlineData(new byte[] { 0, 0b0000_0011 }, 1, 3)]
		[InlineData(new byte[] { 0b1110_0111 }, 0, -103)]
		public void ToInt8_Test(byte[] data, int startIndex, float value)
		{
			Check.That(BigEndianBitConverter.ToInt8(data, startIndex)).Equals(value);
		}
	}
}
