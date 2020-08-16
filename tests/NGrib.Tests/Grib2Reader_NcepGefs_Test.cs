using System.Collections.Generic;
using System.IO;
using System.Linq;
using NFluent;
using NGrib.Grib2.CodeTables;
using NGrib.Grib2.Templates.ProductDefinitions;
using Xunit;

namespace NGrib.Tests
{
	public class Grib2Reader_NcepGefs_Test
	{
		[Fact]
		public void Test()
		{
			using var stream = File.OpenRead(GribFileSamples.NcepGefsFile);
			var reader = new Grib2Reader(stream);

			var datasets = reader.ReadAllDataSets().ToArray();

			var apcpDataset = datasets.Single(d => d.Parameter.Equals(Parameter.TotalPrecipitation));
			Check.That(apcpDataset.ProductDefinitionSection.ProductDefinition.TryGet(ProductDefinitionContent.EnsembleForecastsNumber, out var ensembleForecastsNumber)).IsTrue();
			Check.That(ensembleForecastsNumber).IsEqualTo(20);
		}
	}
}
