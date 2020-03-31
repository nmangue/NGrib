using System;
using System.IO;
using System.Linq;
using System.Numerics;
using NFluent;
using NGrib.Grib2;
using NGrib.Grib2.CodeTables;
using NGrib.Grib2.Templates.DataRepresentations;
using NGrib.Grib2.Templates.GridDefinitions;
using NGrib.Grib2.Templates.ProductDefinitions;
using Xunit;

namespace NGrib.Tests
{
	public class Grib2Reader_SimpleMessage_Test
	{
		[Fact]
		public void Section_Check()
		{
			using var stream = File.OpenRead(GribFileSamples.WmoOneDataSetMessage);
			var reader = new Grib2Reader(stream);

			var messages = reader.ReadMessages();

			Check.That(messages).HasOneElementOnly();
			Check.That(messages.Single().DataSets).HasOneElementOnly();

			var record = messages.Single().DataSets.Single();

			CheckIndicatorSection(record);

			CheckIdentificationSection(record);

			CheckGridDefinitionSection(record);

			CheckProductDefinitionSection(record);

			CheckDataRepresentationSection(record);

			CheckBitmapSection(record);

			CheckDataSection(record);
		}

		[Fact]
		public void Data_Check()
		{
			// Expected values retrieved from Panoply
			var expectedValues = new[]
			{
				5407.5f, 5416.5f, 5360.6f, 5470.8f, 5512.7f,
				5449.3f, 5376.0f, 5503.3f, 5515.2f, 5448.4f,
				5405.9f, 5467.4f, 5440.7f, 5448.5f, 5403.4f,
				5348.1f, 5378.2f, 5417.6f, 5388.2f, 5520.9f,
				5367.6f, 5465.7f, 5357.2f, 5475.4f, 5407.3f
			};

			using var stream = File.OpenRead(GribFileSamples.WmoOneDataSetMessage);
			var reader = new Grib2Reader(stream);

			var dataSets = reader.ReadAllDataSets().ToArray();

			Check.That(dataSets).HasOneElementOnly();

			var data = reader.ReadDataSetRawData(dataSets.Single()).ToArray();

			Check.That(data).ContainsExactly(expectedValues);
		}

		private static void CheckIndicatorSection(DataSet record)
		{
			var indicatorSection = record.Message.IndicatorSection;
			Check.That(indicatorSection.Discipline).Equals(Discipline.MeteorologicalProducts);
			Check.That(indicatorSection.GribEdition).Equals(2);
			Check.That(indicatorSection.TotalLength).Equals(new BigInteger(207));
			Check.That(indicatorSection.Length).Equals(16);
		}

		private static void CheckIdentificationSection(DataSet record)
		{
			var identificationSection = record.Message.IdentificationSection;
			Check.That(identificationSection.Length).Equals(21);
			Check.That(identificationSection.Section).Equals(1);
			Check.That(identificationSection.CenterCode).Equals(74);
			Check.That(identificationSection.SubCenterCode).Equals(0);
			Check.That(identificationSection.MasterTableVersion).Equals(1);
			Check.That(identificationSection.LocalTableVersion).Equals(0);
			Check.That(identificationSection.ReferenceTimeSignificance).Equals(ReferenceTimeSignificance.ForecastStart);
			Check.That(identificationSection.ReferenceTime).Equals(new DateTime(2020, 5, 1, 6, 0, 0, DateTimeKind.Utc));
			Check.That(identificationSection.ProductStatus).Equals(ProductStatus.OperationalProducts);
			Check.That(identificationSection.ProductType).Equals(ProductType.ForecastProducts);
		}

		private static void CheckGridDefinitionSection(DataSet record)
		{
			Check.That(record.GridDefinitionSection.Length).Equals(65);
			Check.That(record.GridDefinitionSection.Section).Equals(3);
			Check.That(record.GridDefinitionSection.Source).Equals(0);
			Check.That(record.GridDefinitionSection.DataPointsNumber).Equals(25);
			Check.That(record.GridDefinitionSection.OptionalListNumberLength).Equals(0);
			Check.That(record.GridDefinitionSection.OptionalListInterpretationCode).Equals(0);
			Check.That(record.GridDefinitionSection.TemplateNumber).Equals(20);

			Check.That(record.GridDefinitionSection.GridDefinition).IsInstanceOf<PolarStereographicProjectionGridDefinition>();
			var gd = (PolarStereographicProjectionGridDefinition)record.GridDefinitionSection.GridDefinition;
			Check.That(gd.EarthShapeCode).Equals(1);
			Check.That(gd.EarthRadius).Equals(6_350d);
			Check.That(gd.EarthMajorAxis).IsNull();
			Check.That(gd.EarthMinorAxis).IsNull();
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

		private static void CheckProductDefinitionSection(DataSet record)
		{
			Check.That(record.ProductDefinitionSection.Length).Equals(34);
			Check.That(record.ProductDefinitionSection.Section).Equals(4);
			Check.That(record.ProductDefinitionSection.CoordinatesAfterTemplateNumber).Equals(0);
			Check.That(record.ProductDefinitionSection.ProductDefinitionTemplateNumber).Equals(0);

			Check.That(record.ProductDefinitionSection.ProductDefinition).IsInstanceOf<PointInTimeHorizontalLevelProductDefinition>();
			var pd = (PointInTimeHorizontalLevelProductDefinition)record.ProductDefinitionSection.ProductDefinition;
			Check.That(pd.ParameterCategory).Equals(3);
			Check.That(pd.ParameterNumber).Equals(5);
			Check.That(pd.GeneratingProcessType).Equals(GeneratingProcessType.Forecast);
			Check.That(pd.BackgroundGeneratingProcessIdentifier).Equals(byte.MaxValue);
			Check.That(pd.GeneratingProcessIdentifier).Equals(byte.MaxValue);
			Check.That(pd.HoursAfter).Equals(3);
			Check.That(pd.MinutesAfter).Equals(30);
			Check.That(pd.TimeRangeUnit).Equals(1);
			Check.That(pd.ForecastTime).Equals(12);
			Check.That(pd.FirstFixedSurfaceType).Equals(100);
			Check.That(pd.FirstFixedSurfaceValue).Equals(500);
			Check.That(pd.SecondFixedSurfaceType).Equals(FixedSurfaceType.Missing);
			Check.That(pd.SecondFixedSurfaceValue).IsNull();
		}

		private static void CheckDataRepresentationSection(DataSet record)
		{
			Check.That(record.DataRepresentationSection.Length).Equals(21);
			Check.That(record.DataRepresentationSection.Section).Equals(5);
			Check.That(record.DataRepresentationSection.DataPointsNumber).Equals(25);
			Check.That(record.DataRepresentationSection.TemplateNumber).Equals(0);

			Check.That(record.DataRepresentationSection.DataRepresentation).IsInstanceOf<GridPointDataSimplePacking>();
			var dr = (GridPointDataSimplePacking)record.DataRepresentationSection.DataRepresentation;
			Check.That(dr.ReferenceValue).Equals(53400f);
			Check.That(dr.BinaryScaleFactor).Equals(0);
			Check.That(dr.DecimalScaleFactor).Equals(1);
		}

		private static void CheckBitmapSection(DataSet record)
		{
			Check.That(record.BitmapSection.Length).Equals(6);
			Check.That(record.BitmapSection.Section).Equals(6);
			Check.That(record.BitmapSection.BitMapIndicatorCode).Equals(byte.MaxValue);
		}

		private static void CheckDataSection(DataSet record)
		{
			Check.That(record.DataSection.Length).Equals(40);
			Check.That(record.DataSection.Section).Equals(7);
		}
	}
}
