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
		private const int CoordinateNbDecimals = 9; // 9 decimals means a 110 microns precision.
		private const double CoordinatePrecision = 1e-9;

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
			Latitude = Math.Round(Math.Max(Math.Min(latitude, 90d), -90d), CoordinateNbDecimals);
			Longitude = Math.Round(-180d <= longitude && longitude <= 180d ? longitude : SimplifyLongitude(longitude), CoordinateNbDecimals);
		}

		private bool IsOnSameLongitude(Coordinate other) => EqualsWithTolerance(Longitude, other.Longitude) || IsAntimeridian(Longitude) && IsAntimeridian(other.Longitude);

		private static bool IsAntimeridian(double longitude) => EqualsWithTolerance(Math.Abs(longitude), 180);

		public bool Equals(Coordinate other) => EqualsWithTolerance(Latitude, other.Latitude) && IsOnSameLongitude(other);

		public override bool Equals(object obj) => obj is Coordinate other && Equals(other);

		private static bool EqualsWithTolerance(double a, double b) => Math.Abs(a - b) <= CoordinatePrecision;

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

		private static double SimplifyLongitude(double longitude)
		{
			var radians = longitude.ToRadians();
			return Math.Atan2(Math.Sin(radians), Math.Cos(radians)).ToDegrees();
		}

		public static implicit operator Coordinate(ValueTuple<double, double> latLon) => new Coordinate(latLon.Item1, latLon.Item2);

		public override string ToString()
		{
			return $"{nameof(Latitude)}: {Latitude}, {nameof(Longitude)}: {Longitude}";
		}
	}
}
