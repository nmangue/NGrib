using System;
using System.IO;
using System.Linq;
using System.Numerics;
using NFluent;
using NGrib.Grib2.CodeTables;
using NGrib.Grib2.Sections.Templates.DataRepresentationTemplates;
using NGrib.Grib2.Sections.Templates.GridDefinitionTemplates;
using NGrib.Grib2.Sections.Templates.ProductDefinitionTemplates;
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

			CheckIdentificationSection(record);

			CheckGridDefinitionSection(record);

			CheckProductDefinitionSection(record);

			CheckDataRepresentationSection(record);

			CheckBitmapSection(record);

			CheckDataSection(record);
		}

		private static void CheckIndicatorSection(Grib2Record record)
		{
			Check.That(record.Is.DisciplineCode).Equals(0);
			Check.That(record.Is.Discipline).Equals(Discipline.MeteorologicalProducts);
			Check.That(record.Is.GribEdition).Equals(2);
			Check.That(record.Is.TotalLength).Equals(new BigInteger(207));
			Check.That(record.Is.Length).Equals(16);
		}

		private static void CheckIdentificationSection(Grib2Record record)
		{
			Check.That(record.ID.Length).Equals(21);
			Check.That(record.ID.Section).Equals(1);
			Check.That(record.ID.CenterCode).Equals(74);
			Check.That(record.ID.SubCenterCode).Equals(0);
			Check.That(record.ID.MasterTableVersion).Equals(1);
			Check.That(record.ID.LocalTableVersion).Equals(0);
			Check.That(record.ID.ReferenceTimeSignificanceCode).Equals(1);
			Check.That(record.ID.ReferenceTimeSignificance).Equals(ReferenceTimeSignificance.ForecastStart);
			Check.That(record.ID.ReferenceTime).Equals(new DateTime(2020, 5, 1, 6, 0, 0, DateTimeKind.Utc));
			Check.That(record.ID.ProductStatusCode).Equals(0);
			Check.That(record.ID.ProductStatus).Equals(ProductStatus.OperationalProducts);
			Check.That(record.ID.ProductTypeCode).Equals(1);
			Check.That(record.ID.ProductType).Equals(ProductType.ForecastProducts);
		}

		private static void CheckGridDefinitionSection(Grib2Record record)
		{
			Check.That(record.GDS.Length).Equals(65);
			Check.That(record.GDS.Section).Equals(3);
			Check.That(record.GDS.Source).Equals(0);
			Check.That(record.GDS.DataPointsNumber).Equals(25);
			Check.That(record.GDS.OptionalListNumberLength).Equals(0);
			Check.That(record.GDS.OptionalListInterpretationCode).Equals(0);
			Check.That(record.GDS.TemplateNumber).Equals(20);

			Check.That(record.GDS.GridDefinition).IsInstanceOf<PolarStereographicProjectionGridDefinition>();
			var gd = (PolarStereographicProjectionGridDefinition)record.GDS.GridDefinition;
			Check.That(gd.Shape).Equals(1);
			Check.That(gd.Scalefactorradius).Equals(3);
			Check.That(gd.Scaledvalueradius).Equals(6350000);
			Check.That(gd.Scalefactormajor).Equals(byte.MaxValue);
			Check.That(gd.Scaledvaluemajor).Equals(uint.MaxValue);
			Check.That(gd.Scalefactorminor).Equals(byte.MaxValue);
			Check.That(gd.Scaledvalueminor).Equals(uint.MaxValue);
			Check.That(gd.Nx).Equals(5);
			Check.That(gd.Ny).Equals(5);
			Check.That(gd.La1).Equals(40.000001);
			Check.That(gd.Lo1).Equals(349.999999);
			Check.That(gd.Resolution).Equals(0);
			Check.That(gd.Lad).Equals(40.000001);
			Check.That(gd.Lov).Equals(0d);
			Check.That(gd.Dx).Equals(100000d);
			Check.That(gd.Dy).Equals(100000d);
			Check.That(gd.ProjectionCenter).Equals(0);
			Check.That(gd.ScanMode).Equals(0b01000000);
		}

		private static void CheckProductDefinitionSection(Grib2Record record)
		{
			Check.That(record.PDS.Length).Equals(34);
			Check.That(record.PDS.Section).Equals(4);
			Check.That(record.PDS.Coordinates).Equals(0);
			Check.That(record.PDS.ProductDefinitionTemplateNumber).Equals(0);

			Check.That(record.PDS.ProductDefinition).IsInstanceOf<PointInTimeHorizontalLevelProductDefinition>();
			var pd = (PointInTimeHorizontalLevelProductDefinition)record.PDS.ProductDefinition;
			Check.That(pd.ParameterCategory).Equals(3);
			Check.That(pd.ParameterNumber).Equals(5);
			Check.That(pd.TypeGenProcess).Equals(2);
			Check.That(pd.BackGenProcess).Equals(byte.MaxValue);
			Check.That(pd.AnalysisGenProcess).Equals(byte.MaxValue);
			Check.That(pd.HoursAfter).Equals(3);
			Check.That(pd.MinutesAfter).Equals(30);
			Check.That(pd.TimeRangeUnit).Equals(1);
			Check.That(pd.ForecastTime).Equals(12);
			Check.That(pd.TypeFirstFixedSurface).Equals(100);
			Check.That(pd.ValueFirstFixedSurface).Equals(500);
			Check.That(pd.TypeSecondFixedSurface).Equals(byte.MaxValue);
			// No need to check ValueSecondFixedSurface
		}

		private static void CheckDataRepresentationSection(Grib2Record record)
		{
			Check.That(record.DRS.Length).Equals(21);
			Check.That(record.DRS.Section).Equals(5);
			Check.That(record.DRS.DataPointsNumber).Equals(25);
			Check.That(record.DRS.TemplateNumber).Equals(0);

			Check.That(record.DRS.DataRepresentation).IsInstanceOf<GridPointDataSimplePacking>();
			var dr = (GridPointDataSimplePacking)record.DRS.DataRepresentation;
			Check.That(dr.ReferenceValue).Equals(53400f);
			Check.That(dr.BinaryScaleFactor).Equals(0);
			Check.That(dr.DecimalScaleFactor).Equals(1);
		}

		private static void CheckBitmapSection(Grib2Record record)
		{
			Check.That(record.Bms.Length).Equals(6);
			Check.That(record.Bms.Section).Equals(6);
			Check.That(record.Bms.BitMapIndicator).Equals(byte.MaxValue);
		}

		private static void CheckDataSection(Grib2Record record)
		{
			Check.That(record.DataSection.Length).Equals(40);
			Check.That(record.DataSection.Section).Equals(7);
		}
	}
}
