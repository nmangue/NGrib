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

namespace NGrib.Grib2.Templates.GridDefinitions
{
	public abstract class Earth
	{
    }

	public class SphericalEarth : Earth
	{
		/// <summary> .</summary>
		/// <returns> EarthRadius as a float
		/// 
		/// </returns>
		public float Radius { get; }

		public SphericalEarth(float radius)
		{
			Radius = radius;
		}
	}

	public class OblateSpheroidEarth : Earth
	{
		/// <summary> .</summary>
		/// <returns> MajorAxis as a float
		/// 
		/// </returns>
		public float MajorAxis { get; }

		/// <summary> .</summary>
		/// <returns> MinorAxis as a float
		/// 
		/// </returns>
		public float MinorAxis { get; }

		public OblateSpheroidEarth(float majorAxis, float minorAxis)
		{
			MajorAxis = majorAxis;
			MinorAxis = minorAxis;
		}
	}
}