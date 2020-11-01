using System.Collections.Generic;
using System.Linq;
using NFluent;
using Xunit;

namespace NGrib.Tests
{
	public class Grib2Reader_DwdCosmo_Test
	{
		[Fact]
		public void Test()
		{
			var reader = new Grib2Reader(GribFileSamples.DwdCosmoTotalPrecipitationFile);

			var dsTemperature = reader.ReadAllDataSets().Single();

			var items = new Dictionary<Coordinate, float?>(reader.ReadDataSetValues(dsTemperature));

			double resolution = 0.02, south = 43, west = 0, east = 17;
			double lat = south;
			double lon = west;

			// Expected values from Panoply
			// ordered from West to East then South to North
			var expectedCosmoValues = TestUtils.ReadCsvValues("references/DWD-COSMO-Total_precipitation_rate_surface_12_Hour_Accumulation.csv");

			foreach (var item in expectedCosmoValues)
			{
				var shouldChangeLatitude = lon >= east - 1e-8;

				Check.That(items[(lat, lon)]).IsEqualTo(item);

				if (shouldChangeLatitude)
				{
					lat += resolution;
					lon = west;
				}
				else
				{
					lon += resolution;
				}
			}
		}
	}
}
