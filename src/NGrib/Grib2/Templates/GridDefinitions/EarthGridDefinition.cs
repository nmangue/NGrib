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
	public abstract class EarthGridDefinition : GridDefinition
	{
		/// <summary>
		/// Shape of the earth code.
		/// </summary>
		public int EarthShapeCode { get; }

		/// <summary>
		/// Radius of spherical earth.
		/// </summary>
		public double? EarthRadius { get; }

		/// <summary>
		/// Major axis of oblate spheroid earth.
		/// </summary>
		public double? EarthMajorAxis { get; }

		/// <summary>
		/// Minor axis of oblate spheroid earth.
		/// </summary>
		public double? EarthMinorAxis { get; }

		/// <summary>
		/// Computed Earth shape (with default values).
		/// </summary>
		public Earth EarthShape { get; }

		private protected EarthGridDefinition(BufferedBinaryReader reader) : base(reader)
		{
			EarthShapeCode = reader.ReadUInt8();

			EarthRadius = reader.ReadScaledValue();
			EarthMajorAxis = reader.ReadScaledValue();
			EarthMinorAxis = reader.ReadScaledValue();

			EarthShape = ComputeEarthShape();
		}

		private Earth ComputeEarthShape()
		{
			Earth earthShape;

			switch (EarthShapeCode)
			{
				case (int) CodeTables.EarthShape.DefaultSpherical:
					earthShape = new SphericalEarth(EarthShapeCode, 6367470);
					break;
				case (int) CodeTables.EarthShape.CustomSpherical:
					earthShape = new SphericalEarth(EarthShapeCode, EarthRadius ?? throw new BadGribFormatException("Missing Earth radius value."));
					break;
				case (int) CodeTables.EarthShape.Iau1965OblateSpheroid:
					earthShape = new OblateSpheroidEarth(EarthShapeCode, 6378160.0f, 6356775.0f);
					break;
				case (int) CodeTables.EarthShape.CustomOblateSpheroid:
					earthShape = new OblateSpheroidEarth(EarthShapeCode,
						EarthMajorAxis ?? throw new BadGribFormatException("Missing Earth major axis value."),
						EarthMinorAxis ?? throw new BadGribFormatException("Missing Earth minor axis value.")
					);
					break;
				case (int) CodeTables.EarthShape.IagGr80OblateSpheroid:
					earthShape = new OblateSpheroidEarth(EarthShapeCode,
						6378137.0f,
						6356752.314f);
					break;
				case (int) CodeTables.EarthShape.Wgs84:
					earthShape = new OblateSpheroidEarth(EarthShapeCode, 6_378_137.0f, 6_356_752.314245179497563967f);
					break;
				case (int) CodeTables.EarthShape.Wgs84Spherical:
					earthShape = new SphericalEarth(EarthShapeCode, 6371229);
					break;
				default:
					return null;
			}

			return earthShape;
		}
	}
}