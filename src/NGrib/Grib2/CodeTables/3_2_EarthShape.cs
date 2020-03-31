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

namespace NGrib.Grib2.CodeTables
{
	/// <summary>
	/// Code Table 3.2: Shape of the Earth
	/// </summary>
	public enum EarthShape
	{
		/// <summary>
		/// Earth assumed spherical with radius = 6,367,470.0 m.
		/// </summary>
		DefaultSpherical,

		/// <summary>
		/// Earth assumed spherical with radius specified by data producer.
		/// </summary>
		CustomSpherical,

		/// <summary>
		/// Earth assumed oblate spheroid with size as determined by IAU in 1965 (major axis = 6,378,160.0 m, minor axis = 6,356,775.0 m, f = 1/297.0).
		/// </summary>
		Iau1965OblateSpheroid,

		/// <summary>
		/// Earth assumed oblate spheroid with major and minor axes specified by data producer.
		/// </summary>
		CustomOblateSpheroid,

		/// <summary>
		/// Earth assumed oblate spheroid as defined in IAG-GRS80 model (major axis = 6,378,137.0 m, minor axis = 6,356,752.314 m, f = 1/298.257222101).
		/// </summary>
		IagGr80OblateSpheroid,

		/// <summary>
		/// Earth assumed represented by WGS84 (as used by ICAO since 1998).
		/// </summary>
		Wgs84,

		/// <summary>
		/// Earth model assumed spherical with radius 6,371,200.0 m,
		/// but the horizontal datum of the resulting Latitude/Longitude field is the WGS84 reference frame.
		/// </summary>
		Wgs84Spherical
	}
}