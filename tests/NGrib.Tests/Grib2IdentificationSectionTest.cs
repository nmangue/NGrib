using System;
using System.IO;
using NFluent;
using NGrib.Grib2.CodeTables;
using NGrib.Grib2.Sections;
using Xunit;

namespace NGrib.Tests
{
	public class Grib2IdentificationSectionTest
	{
		[Fact]
		public void BuildFrom_ValidGribFile_Test()
		{
			using var gribFileStream = File.OpenRead(GribFileSamples.ValidFile);
			var reader = new BufferedBinaryReader(gribFileStream);
			reader.Seek(16, SeekOrigin.Begin);
			
			var section = IdentificationSection.BuildFrom(reader);

			Check.That(section).IsNotNull();
			Check.That(section.Length).Equals(21);
			Check.That(section.Section).Equals(1);
			Check.That(section.CenterCode).Equals(7);
			Check.That(section.SubCenterCode).Equals(0);
			Check.That(section.MasterTableVersion).Equals(2);
			Check.That(section.LocalTableVersion).Equals(1);
			Check.That(section.ProductStatusCode).Equals(0);
			Check.That(section.ProductStatus).Equals(ProductStatus.OperationalProducts);
			Check.That(section.ProductTypeCode).Equals(0);
			Check.That(section.ProductType).Equals(ProductType.AnalysisProducts);
			Check.That(section.ReferenceTimeSignificanceCode).Equals(0);
			Check.That(section.ReferenceTimeSignificance).Equals(ReferenceTimeSignificance.Analysis);
			Check.That(section.ReferenceTime).Equals(new DateTime(2020, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc));
		}
	}
}
