using NFluent;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NGrib.Tests
{
    public class Grib2Reader_ComplexPacking_Test
    {
        [Fact]
        public void Test()
        {
            using var stream = File.OpenRead(GribFileSamples.WaveComplexPacking);
            using var reader = new Grib2Reader(stream);

            var dataset = reader.ReadAllDataSets().Single();

            var values = new Dictionary<Coordinate, float?>(reader.ReadDataSetValues(dataset));

            var expectedValues = ReadExpectedValues(GribFileSamples.WaveComplexPacking + ".expected-values.txt");

            Check.That(values).IsEquivalentTo(expectedValues);
        }

        private static Dictionary<Coordinate, float> ReadExpectedValues(string filePath)
        {
            var result = new Dictionary<Coordinate, float>();
            using (var reader = new StreamReader(filePath))
            {
                // Skip the header line
                reader.ReadLine();

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 3)
                    {
                        var c = new Coordinate(
                            latitude: double.Parse(parts[0], CultureInfo.InvariantCulture),
                            longitude: double.Parse(parts[1], CultureInfo.InvariantCulture)
                            );

                        var value = float.Parse(parts[2], CultureInfo.InvariantCulture);
                        if (value == 9999)
                        {
                            //TODO Find out why the reference missing value
                            // if different
                            value = 9.999E20f;
                        }

                        result.Add(c, value);
                    }
                }
            }

            return result;
        }
    }
}
