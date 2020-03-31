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
	public abstract class XyEarthGridDefinition : EarthGridDefinition
	{
		/// <summary>
		/// Number of points along x-axis or a parallel.
		/// </summary>
		public long Nx { get; }

		/// <summary>
		/// Number of points along y-axis or a meridian.
		/// </summary>
		public long Ny { get; }

		private protected XyEarthGridDefinition(BufferedBinaryReader reader) : base(reader)
		{
			Nx = reader.ReadUInt32();
			Ny = reader.ReadUInt32();
		}
	}
}