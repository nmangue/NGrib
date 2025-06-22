using System.Collections.Generic;
using System.IO;
using System.Linq;
using NFluent;
using NGrib.Grib2.CodeTables;
using NGrib.Grib2.Templates.GridDefinitions;
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
			
			Check.That(datasets.Select(d => d.Parameter)).ContainsExactly(
				Parameter.Temperature,
				Parameter.TotalPrecipitation, // APCP 6 hours accumulation
				Parameter.TotalPrecipitation // APCP 96 hours accumulation
			);

			var temperatureDs = datasets.Single(d => d.Parameter.Equals(Parameter.Temperature));

			var data = reader.ReadDataSetValues(temperatureDs).ToList();
			
			// Excepted values read using Panoply
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

		[Fact]
		public void Test_FullDomain()
		{
			using var stream = File.OpenRead(GribFileSamples.NcepGfsFullDomainFile);
			var reader = new Grib2Reader(stream);
			
			var datasets = reader.ReadAllDataSets().ToArray();
			
			Check.That(datasets.Select(d => d.Parameter)).ContainsExactly(
				Parameter.Temperature
			);
			
			var temperatureDs = datasets.Single(d => d.Parameter.Equals(Parameter.Temperature));
			
			var latLonDef = temperatureDs.GridDefinitionSection.GridDefinition as LatLonGridDefinition;
			
			Check.That(latLonDef.La1).IsEqualTo(-90f);
			Check.That(latLonDef.La2).IsEqualTo(90f);
			Check.That(latLonDef.Lo1).IsEqualTo(-180f);
			Check.That(latLonDef.Lo2).IsEqualTo(179.75f);
			
			var vals = reader.ReadDataSetValues(temperatureDs).ToList();
			Check.That(vals).HasSize(1440 * 721);
			Check.That(vals.First().Key.Longitude).IsEqualTo(-180f);
			Check.That(vals.First().Key.Latitude).IsEqualTo(-90f);
			Check.That(vals.Last().Key.Longitude).IsEqualTo(179.75f);
			Check.That(vals.Last().Key.Latitude).IsEqualTo(90f);
		}
	}
}
