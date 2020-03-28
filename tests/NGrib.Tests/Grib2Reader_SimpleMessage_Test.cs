using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using NFluent;
using Xunit;

namespace NGrib.Tests
{
	public class Grib2Reader_SimpleMessage_Test
	{
		[Fact]
		public void Section_Check()
		{
			using var stream = File.OpenRead(GribFileSamples.WmoOneDataSetMessage);
			var reader = Grib2Reader.Open(stream);

			Check.That(reader.Records).HasOneElementOnly();

			var record = reader.Records.Single();

			CheckIndicatorSection(record);
		}
		private static void CheckIndicatorSection(Grib2Record record)
		{
			Check.That(record.Is.DisciplineNumber).Equals(0);
			Check.That(record.Is.Discipline).Equals(Discipline.MeteorologicalProducts);
			Check.That(record.Is.GribEdition).Equals(2);
			Check.That(record.Is.TotalLength).Equals(new BigInteger(207));
			Check.That(record.Is.Length).Equals(16);
		}
	}
}
