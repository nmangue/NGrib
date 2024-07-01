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
		public void Read_AvgFile_Test()
		{
			using var stream = File.OpenRead(GribFileSamples.NcepGefsAvgFile);
			var reader = new Grib2Reader(stream);

			var datasets = reader.ReadAllDataSets().ToArray();

			var apcpDataset = datasets.Single(d => d.Parameter.Equals(Parameter.TotalPrecipitation));
			Check.That(apcpDataset.ProductDefinitionSection.ProductDefinition.TryGet(ProductDefinitionContent.EnsembleForecastsNumber, out var ensembleForecastsNumber)).IsTrue();
			Check.That(ensembleForecastsNumber).IsEqualTo(20);
		}

		[Fact]
		public void Read_PerturbationFile_Test()
		{
			using var stream = File.OpenRead(GribFileSamples.NcepGefsPerturbationFile);
			var reader = new Grib2Reader(stream);

			var datasets = reader.ReadAllDataSets().ToArray();

			const int expectedEnsembleForecastsNumber = 20;
			const int expectedPerturbationNumber = 8;

			int perturbationNumber;
			int ensembleForecastsNumber;

			var tmpDataSet = datasets.Single(datasets => datasets.Parameter.Equals(Parameter.Temperature));
			Check.That(tmpDataSet.ProductDefinitionSection.ProductDefinition.TryGet(ProductDefinitionContent.EnsembleForecastsNumber, out ensembleForecastsNumber)).IsTrue();
			Check.That(ensembleForecastsNumber).IsEqualTo(expectedEnsembleForecastsNumber);

			Check.That(tmpDataSet.ProductDefinitionSection.TryGet(ProductDefinitionContent.PerturbationNumber, out perturbationNumber)).IsTrue();
			Check.That(perturbationNumber).IsEqualTo(expectedPerturbationNumber);

			var apcpDataset = datasets.Single(d => d.Parameter.Equals(Parameter.TotalPrecipitation));
			Check.That(apcpDataset.ProductDefinitionSection.ProductDefinition.TryGet(ProductDefinitionContent.EnsembleForecastsNumber, out ensembleForecastsNumber)).IsTrue();
			Check.That(ensembleForecastsNumber).IsEqualTo(expectedEnsembleForecastsNumber);

			Check.That(apcpDataset.ProductDefinitionSection.TryGet(ProductDefinitionContent.PerturbationNumber, out perturbationNumber)).IsTrue();
			Check.That(perturbationNumber).IsEqualTo(expectedPerturbationNumber);
		}

		[Fact]
		public void Read_CombinedDataSets_Test()
		{
			using var stream = File.OpenRead(GribFileSamples.NcepGefsWaveFile);
			var reader = new Grib2Reader(stream);
			var dataSets = reader.ReadAllDataSets().ToArray();

			var parameters = dataSets.Select(ds => ds.Parameter).ToArray();
			Check.That(parameters).ContainsNoNull();

			var combinedDirection = parameters.First(p => p.Value.Code == 14);
			Check.That(combinedDirection.Value.Name).Equals("Direction of combined wind waves and swell");

			var combinedPeriod = parameters.First(p => p.Value.Code == 15);
			Check.That(combinedPeriod.Value.Name).Equals("Period of combined wind waves and swell");

			var inverseFrequency = parameters.First(p => p.Value.Code == 25);
			Check.That(inverseFrequency.Value.Name).Equals("Inverse mean wave frequency");
		}
	}
}