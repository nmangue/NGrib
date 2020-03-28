using System;
using System.IO;
using NFluent;
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
			
			var section = Grib2IdentificationSection.BuildFrom(reader);

			Check.That(section).IsNotNull();
			Check.That(section.Length).Equals(21);
			Check.That(section.Section).Equals(1);
			Check.That(section.Center_id).Equals(7);
			Check.That(section.Subcenter_id).Equals(0);
			Check.That(section.Master_table_version).Equals(2);
			Check.That(section.Local_table_version).Equals(1);
			Check.That(section.ProductStatus).Equals(0);
			Check.That(section.ProductType).Equals(0);
			Check.That(section.SignificanceOfRT).Equals(0);
			Check.That(section.RefTime).Equals(new DateTime(2020, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc));
		}
	}
}
