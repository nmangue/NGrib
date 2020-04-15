using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace NGrib.Tests
{
	public class Grib1Input_Test
	{
		[Fact]
		public void Read_Test()
		{
			using var stream = File.OpenRead(@"grib1_sample.grb");

			var reader = new Grib1Reader(stream);
			using var writer = new StreamWriter(@"grib1_read_test.txt");
			foreach (var record in reader.ReadRecords())
			{
				foreach (var kv in reader.ReadRecordValues(record))
				{
					writer.WriteLine($"{kv.Key} : {kv.Value}");
				}
			}
		}
	}
}
