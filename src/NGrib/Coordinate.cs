using System;

namespace NGrib
{
	public readonly struct Coordinate
	{
		public float Latitude { get; }
		public float Longitude { get; }

		public Coordinate(float latitude, float longitude)
		{
			Latitude = -90f <= latitude && latitude <= 90 ? latitude : SimplifyLatitude(latitude);
			Longitude = longitude >= 0 && longitude < 360 ? longitude : SimplifyLongitude(longitude);
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

		public Coordinate Add(float latitudeIncrement, float longitudeIncrement)
		{
			return new Coordinate(Latitude + latitudeIncrement, Longitude + longitudeIncrement);
		}

		private static float SimplifyLatitude(float latitude) => Math.Abs(latitude % 180) < 0.0000001 ? 0 : (float) Math.Asin(Math.Sin(latitude.ToRadians())).ToDegrees();

		private static float SimplifyLongitude(float longitude) => longitude >= 0 ? longitude % 360 : 360 + longitude % 360;

		public override string ToString()
		{
			return $"{nameof(Latitude)}: {Latitude}, {nameof(Longitude)}: {Longitude}";
		}
	}
}
