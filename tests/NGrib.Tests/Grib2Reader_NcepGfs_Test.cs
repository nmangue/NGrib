using System.Collections.Generic;
using System.IO;
using System.Linq;
using NFluent;
using NGrib.Grib2.CodeTables;
using Xunit;

namespace NGrib.Tests
{
	public class Grib2Reader_NcepGfs_Test
	{
		[Fact]
		public void Test()
		{
			using var stream = File.OpenRead(GribFileSamples.NcepGfsTmpApcpFile);
			var reader = new Grib2Reader(stream);

			var datasets = reader.ReadAllDataSets().ToArray();
			
			Check.That(datasets.Select(d => d.ProductDefinitionSection.ProductDefinition.Parameter)).ContainsExactly(
				Parameter.Temperature,
				Parameter.TotalPrecipitation, // APCP 6 hours accumulation
				Parameter.TotalPrecipitation // APCP 96 hours accumulation
			);

			var temperatureDs = datasets.Single(d => d.ProductDefinitionSection.ProductDefinition.Parameter.Equals(Parameter.Temperature));

			var data = reader.ReadRecordData(temperatureDs).ToList();

			Check.That(data).ContainsExactly(new Dictionary<Coordinate, float?>
			{
				{ (-21.25, 55), 301.405579f },
				{ (-21.25, 55.25), 301.305603f },
				{ (-21.25, 55.5), 301.705597f },
				{ (-21, 55), 301.505585f },
				{ (-21, 55.25), 302.605591f },
				{ (-21, 55.5), 301.005585f },
			});
		}
	}
}
