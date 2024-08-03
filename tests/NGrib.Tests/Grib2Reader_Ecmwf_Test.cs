using System.Collections.Generic;
using System.IO;
using System.Linq;
using NFluent;
using Xunit;

namespace NGrib.Tests
{
	public class Grib2Reader_Ecmwf_Test
	{
		[Fact]
		public void Test()
		{
			using var stream = File.OpenRead(GribFileSamples.EcmwfTmp2mDataTemplate42);
			var reader = new Grib2Reader(stream);

			var datasets = reader.ReadAllDataSets().ToArray();
			
			var temperatureDs = datasets.Single();
			
			var data = reader.ReadDataSetValues(temperatureDs).ToDictionary(kv => kv.Key, kv => kv.Value);

            // Excepted values read using eccodes
            var coordinates = new Dictionary<Coordinate, float>
            {
				{(-21.25, 55.50), 2.8653944397e+02f },   // La Réunion Island
                {(40.25, 116.00), 2.9678944397e+02f },   // Great Wall of China
                {(-13.25, -72.50), 2.8072694397e+02f },  // Machu Picchu
                {(40.75, -74.00), 2.9941444397e+02f },   // Statue of Liberty
                {(48.75, 2.25), 2.8960194397e+02f },     // Eiffel Tower
            };

			foreach (var (c,v) in coordinates)
			{
				Check.That(data[c].Value).IsCloseTo(v, 1e-4f);
			}
		}
	}
}
