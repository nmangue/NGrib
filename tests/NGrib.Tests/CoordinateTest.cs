using NFluent;
using Xunit;

namespace NGrib.Tests
{
	public class CoordinateTest
	{
		[Theory]
		[InlineData(0, 0, 0, 0)]
		[InlineData(-90, 0.25, -90, 0.25)]
		[InlineData(90, 360, 90, 0)]
		[InlineData(91, 0, 90, 0)]
		[InlineData(0, 345, 0, -15)]
		[InlineData(-181, 720, -90, 0)]
		public void CoordinateSimplification_Test(double lat, double lon, double expectedLat, double expectedLon)
		{
			var coordinate = new Coordinate(lat, lon);

			Check.That(coordinate.Latitude).IsCloseTo(expectedLat, 1e-6);
			Check.That(coordinate.Longitude).IsCloseTo(expectedLon, 1e-6);
		}
	}
}