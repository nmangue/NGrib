using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NFluent;
using NGrib.Grib2.CodeTables;
using Xunit;

namespace NGrib.Tests
{
	public struct WindData
{
    public Coordinate Coordinate { get; }
    public double Direction { get; }
    public double Speed { get; }

    public WindData(Coordinate coordinate, double direction, double speed)
    {
        Coordinate = coordinate;
        Direction = direction;
        Speed = speed;
    }
}
	public class Grib2Reader_NcepGfsMaxWind_Test
	{
		
		[Fact]
		public void Test()
		{
			using var stream = File.OpenRead(GribFileSamples.NcepGfsMaxWindFile);
			var reader = new Grib2Reader(stream);

			var datasets = reader.ReadAllDataSets().ToArray();
			
			Check.That(datasets.Select(d => d.Parameter)).ContainsExactly(
				Parameter.UComponentOfWind,
				Parameter.VComponentOfWind
			);

			var uComponentOfWindDs = datasets.Single(d => d.Parameter.Equals(Parameter.UComponentOfWind));
			var vComponentOfWindDs = datasets.Single(d => d.Parameter.Equals(Parameter.VComponentOfWind));

			var uComponentOfWindData = reader.ReadDataSetValues(uComponentOfWindDs).ToList();
			var vComponentOfWindData = reader.ReadDataSetValues(vComponentOfWindDs).ToList();

			var windDirectionAndSpeedData = CalculateWindData(uComponentOfWindData, vComponentOfWindData);
			
			Check.That(windDirectionAndSpeedData.First(wind => 
				wind.Coordinate.Latitude == 90 &&
				wind.Coordinate.Longitude == 0 &&
				wind.Direction == 137.21634227869845 &&
				wind.Speed == 14.194902650874068));
		}

		private static List<WindData> CalculateWindData(List<KeyValuePair<Coordinate, float?>> uComponentOfWindData, List<KeyValuePair<Coordinate, float?>> vComponentOfWindData)
		{
			List<WindData> windDataList = new List<WindData>();

			// Ensure both lists have the same length
			int count = Math.Min(uComponentOfWindData.Count, vComponentOfWindData.Count);

			for (int i = 0; i < count; i++)
			{
				Coordinate coordinate = uComponentOfWindData[i].Key;
				double u = uComponentOfWindData[i].Value ?? 0.0; // If null, default value is 0.0
				double v = vComponentOfWindData[i].Value ?? 0.0; // If null, default value is 0.0

				// Calculate wind direction
				double direction = CalculateWindDirection(u, v);

				// Calculate wind speed
				double speed = CalculateWindSpeed(u, v);

				// Create WindData instance
				WindData windData = new WindData(coordinate, direction, speed);

				// Add to the list
				windDataList.Add(windData);
			}

			return windDataList;
		}

		private static double CalculateWindDirection(double U, double V)
		{
			double windDirection = Math.Atan2(U, V) * 180 / Math.PI;
			windDirection = (windDirection + 360) % 360; // Convert negative angles to positive

			return windDirection;
		}

		private static double CalculateWindSpeed(double U, double V)
		{
			// Convert U and V components to eastward and northward components
			double u = U;
			double v = V;

			// Calculate wind speed (magnitude)
			double windSpeed = Math.Sqrt(u * u + v * v);

			return windSpeed;
		}
	}
}
