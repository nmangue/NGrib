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
using NGrib.Grib2.CodeTables;

namespace NGrib.Grib2.Templates.GridDefinitions
{
	public abstract class Earth
	{
		public EarthShape Shape { get; }

		protected Earth(int shapeCode)
		{
			Shape = shapeCode.As<EarthShape>() ?? throw new ArgumentException("Unknown shape code.", nameof(shapeCode));
		}
	}

	public class SphericalEarth : Earth
	{
		/// <summary> .</summary>
		/// <returns> EarthRadius as a float
		/// 
		/// </returns>
		public double Radius { get; }

		public SphericalEarth(int shapeCode, double radius) : base(shapeCode)
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
		public double MajorAxis { get; }

		/// <summary> .</summary>
		/// <returns> MinorAxis as a float
		/// 
		/// </returns>
		public double MinorAxis { get; }

		public OblateSpheroidEarth(int shapeCode, double majorAxis, double minorAxis) : base(shapeCode)
		{
			MajorAxis = majorAxis;
			MinorAxis = minorAxis;
		}
	}
}