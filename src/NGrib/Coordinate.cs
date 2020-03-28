using System;

namespace NGrib
{
	public readonly struct Coordinate
	{
		public double Latitude { get; }
		public double Longitude { get; }

		public Coordinate(double latitude, double longitude)
		{
			Latitude = -90d <= latitude && latitude <= 90d ? latitude : SimplifyLatitude(latitude);
			Longitude = longitude >= 0d && longitude < 360d ? longitude : SimplifyLongitude(longitude);
		}

		public bool Equals(Coordinate other)
		{
			return Latitude.Equals(other.Latitude) && Longitude.Equals(other.Longitude);
		}

		public override bool Equals(object obj)
		{
			return obj is Coordinate other && Equals(other);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (Latitude.GetHashCode() * 397) ^ Longitude.GetHashCode();
			}
		}

		public Coordinate Add(double latitudeIncrement, double longitudeIncrement)
		{
			return new Coordinate(Latitude + latitudeIncrement, Longitude + longitudeIncrement);
		}

		private static double SimplifyLatitude(double latitude) => Math.Abs(latitude % 180) < 0.0000001 ? 0 : Math.Asin(Math.Sin(latitude.ToRadians())).ToDegrees();

		private static double SimplifyLongitude(double longitude) => longitude >= 0 ? longitude % 360 : 360 + longitude % 360;

		public override string ToString()
		{
			return $"{nameof(Latitude)}: {Latitude}, {nameof(Longitude)}: {Longitude}";
		}
	}
}
