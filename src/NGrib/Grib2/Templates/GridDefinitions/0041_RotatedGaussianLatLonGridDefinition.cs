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
	public class RotatedGaussianLatLonGridDefinition : GaussianLatLonGridDefinition
	{
		/// <summary> .</summary>
		/// <returns> SpLat as a float
		/// 
		/// </returns>
		public double SpLat { get; }

		/// <summary> .</summary>
		/// <returns> SpLon as a float
		/// 
		/// </returns>
		public double SpLon { get; }

		/// <summary> .</summary>
		/// <returns> Rotationangle as a float
		/// 
		/// </returns>
		public long Rotationangle { get; }

		internal RotatedGaussianLatLonGridDefinition(BufferedBinaryReader reader) : base(reader)
		{
			SpLat = reader.ReadInt32() * Ratio;
			SpLon = reader.ReadUInt32() * Ratio;
			Rotationangle = reader.ReadUInt32();
		}
	}
}