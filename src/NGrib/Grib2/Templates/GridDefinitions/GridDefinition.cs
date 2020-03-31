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

using System.Collections.Generic;

namespace NGrib.Grib2.Templates.GridDefinitions
{
	/// <summary>
	/// Represents a GRIB2 Grid Definition
	/// </summary>
	public abstract class GridDefinition
	{
		/// <summary>
		/// Grid Definition Offset.
		/// </summary>
		public long Offset { get; }

		private protected GridDefinition(BufferedBinaryReader reader)
		{
			Offset = reader.Position;
		}

		/// <summary>
		/// Enumerated the point coordinates within the current grid.
		/// </summary>
		/// <remarks>
		/// The points are returned in the order defined by the grid (i.e. scanning mode).
		/// </remarks>
		/// <returns>
		/// Grid points coordinates.
		/// </returns>
		public abstract IEnumerable<Coordinate> EnumerateGridPoints();
	}
}