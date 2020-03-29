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
	public class StretchedLatLonGridDefinition : LatLonGridDefinition
	{
		/// <summary> .</summary>
		/// <returns> PoleLat as a float
		/// 
		/// </returns>
		public float PoleLat { get; }

		/// <summary> .</summary>
		/// <returns> PoleLon as a float
		/// 
		/// </returns>
		public float PoleLon { get; }

		/// <summary> .</summary>
		/// <returns> Factor as a float
		/// 
		/// </returns>
		public float Factor { get; }

		internal StretchedLatLonGridDefinition(BufferedBinaryReader reader) : base(reader)
		{
			//Stretched Latitude/longitude
			PoleLat = reader.ReadInt32() * 1e-6f;
			PoleLon = reader.ReadUInt32() * 1e-6f;
			Factor = reader.ReadUInt32();
		}
	}
}