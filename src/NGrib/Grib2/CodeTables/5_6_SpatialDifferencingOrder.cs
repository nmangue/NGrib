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
	/// Code Table 5.6: Order of Spatial Differencing
	/// </summary>
	public enum SpatialDifferencingOrder
	{
		/// <summary>
		/// No spatial differencing.
		/// </summary>
		None = 0,

		/// <summary>
		/// First-order spatial differencing.
		/// </summary>
		FirstOrder = 1,

		/// <summary>
		/// Second-order spatial differencing.
		/// </summary>
		SecondOrder = 2,

		/// <summary>
		/// Missing.
		/// </summary>
		Missing = 255,
	}
}