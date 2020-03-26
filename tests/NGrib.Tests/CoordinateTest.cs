using NFluent;
using Xunit;

namespace NGrib.Tests
{
	public class CoordinateTest
	{
		[Theory]
		[InlineData(0, 0, 0, 0)]
		[InlineData(-90, 0.25, -90, 0.25)]
		[InlineData(90, 360, 90, 360)]
		[InlineData(91, 0, 89, 0)]
		[InlineData(0, -15, 0, 345)]
		[InlineData(-181, 720, 1, 0)]
		public void CoordinateSimplification_Test(float lat, float lon, float expectedLat, float expectedLon)
		{
			var coordinate = new Coordinate(lat, lon);

			Check.That(coordinate.Latitude).Equals(expectedLat);
			Check.That(coordinate.Longitude).Equals(expectedLon);
		}
	}
}