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
	public class LambertConformalGridDefinition : PolarStereographicProjectionGridDefinition
	{
		/// <summary> .</summary>
		/// <returns> Latin1 as a float
		/// 
		/// </returns>
		public float Latin1 { get; }

		/// <summary> .</summary>
		/// <returns> Latin2 as a float
		/// 
		/// </returns>
		public float Latin2 { get; }

		/// <summary> .</summary>
		/// <returns> SpLat as a float
		/// 
		/// </returns>
		public float SpLat { get; }

		/// <summary> .</summary>
		/// <returns> SpLon as a float
		/// 
		/// </returns>
		public float SpLon { get; }

		internal LambertConformalGridDefinition(BufferedBinaryReader reader) : base(reader)
		{
			Latin1 = reader.ReadUInt32() * 1e-6f;
			Latin2 = reader.ReadUInt32() * 1e-6f;

			SpLat = reader.ReadInt32() * 1e-6f;
			SpLon = reader.ReadUInt32() * 1e-6f;
		}
	}
}