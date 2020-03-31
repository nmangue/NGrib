using System.IO;
using NFluent;
using NGrib.Grib2.CodeTables;
using NGrib.Grib2.Sections;
using Xunit;

namespace NGrib.Tests
{
	public class Grib2IndicatorSectionTest
	{
		[Fact]
		public void BuildFrom_ValidGribFile_Test()
		{
			using var gribFileStream = File.OpenRead(GribFileSamples.ValidFile);
			var reader = new BufferedBinaryReader(gribFileStream);
			
			var indicatorSection = IndicatorSection.BuildFrom(reader);

			Check.That(indicatorSection).IsNotNull();
			Check.That(indicatorSection.GribEdition).Equals(2);
			Check.That(indicatorSection.Discipline).Equals(Discipline.MeteorologicalProducts);
			Check.That(indicatorSection.TotalLength.Sign).IsStrictlyPositive();
		}
	}
}
