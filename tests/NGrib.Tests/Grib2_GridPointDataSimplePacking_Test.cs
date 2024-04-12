using System.IO;
using System.Linq;
using NFluent;
using NGrib.Grib2.CodeTables;
using NGrib.Grib2.Sections;
using NGrib.Grib2.Templates.DataRepresentations;
using Xunit;

namespace NGrib.Tests
{
    public class Grib2_EnumerateDataValues_Test
    {
        [Fact]
        public void EnumerateDataValues_0BitSpecialCase_Test()
        {
            // When the number of bits is 0 in the simple packing
            // The reference value should be return without applying the formula.

            var referenceValue = 0.12345f;
            var dataPointsNumber = 3;

            var packing = new GridPointDataSimplePacking(
                referenceValue,
                -54,
                -15,
                0,
                OriginalFieldValuesType.FloatingPoint);

            var dataSection = new DataSection(0, 0, 0, 0);
            using var fileStream = File.OpenRead(GribFileSamples.WmoOneDataSetMessage);
            using var reader = new BufferedBinaryReader(fileStream);
            var values = packing.EnumerateDataValues(reader, dataSection, dataPointsNumber).ToList();

            var expectedValues = Enumerable.Repeat(referenceValue, dataPointsNumber).ToList();
            Check.That(values).ContainsExactly(expectedValues);
        }
    }
}
