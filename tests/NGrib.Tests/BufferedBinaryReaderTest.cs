using System.IO;
using NFluent;
using Xunit;

namespace NGrib.Tests
{
	public class BufferedBinaryReaderTest
	{
		[Theory]
		// 01000110 10001111
		// ^^^'''** *'''^^^
		//  2  1  5   0  7
		[InlineData(3, new byte[] { 0b01000110, 0b10001111 }, new[] { 2, 1, 5, 0, 7 } )]
		public void ReadUIntN_Test(int nbBits, byte[] data, int[] expectedValues)
		{
			var nbReads = expectedValues.Length;
			var readValues = new int[nbReads];
			using var stream = new MemoryStream(data);
			using var reader = new BufferedBinaryReader(stream);

			for (int i = 0; i < nbReads; i++)
			{
				readValues[i] = reader.ReadUIntN(nbBits);
			}

			Check.That(readValues).ContainsExactly(expectedValues);
		}
	}
}
