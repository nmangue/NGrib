using System.Collections.Generic;
using System.IO;
using NFluent;
using NGrib.Grib1;
using Xunit;

namespace NGrib.Tests
{
	public class Grib1Input_Test
	{
		[Fact]
		public void Read_Test()
		{
			using var stream = File.OpenRead(GribFileSamples.MarineLionCorse);

			var reader = new Grib1Reader(stream);
			var data = new Dictionary<Grib1Record, Dictionary<Coordinate, float>>();
			foreach (var record in reader.ReadRecords())
			{
				var recordData = new Dictionary<Coordinate, float>(reader.ReadRecordValues(record));
				data[record] = recordData;
			}

			Check.That(data).HasSize(34);
		}
	}
}
