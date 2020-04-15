/*
 * This file is part of NGrib.
 *
 * Copyright © 2020 Nicolas Mangué
 * 
 * NGrib is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 3 of the License, or (at your option) any later version.
 * 
 * NGrib is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 * 
 * You should have received a copy of the GNU Lesser General Public License
 * along with NGrib.  If not, see <https://www.gnu.org/licenses/>.
 */

using System;

namespace NGrib
{
	/// <summary>
	/// Represents a location on the Earth surface.
	/// </summary>
	public readonly struct Coordinate
	{
		/// <summary>
		/// Specifies the north–south position.
		/// </summary>
		public double Latitude { get; }

		/// <summary>
		/// Specifies the east–west position.
		/// </summary>
		public double Longitude { get; }

		/// <summary>
		/// Initializes a new instance of the <c>Coordinate</c> class
		/// based on the specified file. 
		/// </summary>
		/// <param name="latitude">Latitude of the point.</param>
		/// <param name="longitude">Longitude of the point.</param>
		public Coordinate(double latitude, double longitude)
		{
			const int coordinateMaxPrecision = 9; // 9 decimals means a 110 microns precision.
			Latitude = Math.Round(-90d <= latitude && latitude <= 90d ? latitude : SimplifyLatitude(latitude), coordinateMaxPrecision);
			Longitude = Math.Round(longitude >= 0d && longitude < 360d ? longitude : SimplifyLongitude(longitude), coordinateMaxPrecision);
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

		public static implicit operator Coordinate(ValueTuple<double, double> latLon) => new Coordinate(latLon.Item1, latLon.Item2);

		public override string ToString()
		{
			return $"{nameof(Latitude)}: {Latitude}, {nameof(Longitude)}: {Longitude}";
		}
	}
}
