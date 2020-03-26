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
using System.Diagnostics;

namespace NGrib.Sections.Templates.GridDefinitionTemplates
{
	public class LatLonGridDefinition : XyEarthGridDefinition
	{
		/// <summary> .</summary>
		/// <returns> Angle as a int
		/// 
		/// </returns>
		public long Angle { get; }

		/// <summary> .</summary>
		/// <returns> Subdivisionsangle as a int
		/// 
		/// </returns>
		public long Subdivisionsangle { get; }

		/// <summary> .</summary>
		/// <returns> La1 as a float
		/// 
		/// </returns>
		public float La1 { get; }

		/// <summary> .</summary>
		/// <returns> Lo1 as a float
		/// 
		/// </returns>
		public float Lo1 { get; }

		/// <summary> .</summary>
		/// <returns> Resolution as a int
		/// 
		/// </returns>
		public int Resolution { get; }

		/// <summary> .</summary>
		/// <returns> La2 as a float
		/// 
		/// </returns>
		public float La2 { get; }

		/// <summary> .</summary>
		/// <returns> Lo2 as a float
		/// 
		/// </returns>
		public float Lo2 { get; }

		/// <summary> Get x-increment/distance between two grid points.
		/// 
		/// </summary>
		/// <returns> x-increment
		/// </returns>
		public float Dx { get; }

		/// <summary> Get y-increment/distance between two grid points.
		/// 
		/// </summary>
		/// <returns> y-increment
		/// </returns>
		public float Dy { get; }

		/// <summary> Get scan mode.
		/// 
		/// </summary>
		/// <returns> scan mode
		/// </returns>
		public int ScanMode { get; }
		
		internal LatLonGridDefinition(BufferedBinaryReader reader) : base(reader)
		{
			Angle = reader.ReadUInt32();
			Subdivisionsangle = reader.ReadUInt32();
			float ratio;
			if (Angle == 0)
			{
				ratio = 1e-6f;
			}
			else
			{
				ratio = Angle / (float)Subdivisionsangle;
			}

			La1 = reader.ReadInt32() * ratio;
			Lo1 = reader.ReadUInt32() * ratio;
			Resolution = reader.ReadUInt8();
			La2 = reader.ReadInt32() * ratio;
			Lo2 = reader.ReadUInt32() * ratio;
			Dx = reader.ReadUInt32() * ratio;
			Dy = reader.ReadUInt32() * ratio;
			ScanMode = reader.ReadUInt8();
		}

		public override IEnumerable<Coordinate> EnumerateGridPoints()
		{
			var firstGridPoint = new Coordinate(La1, Lo1);
			var lastGridPoint = new Coordinate(La2, Lo2);

			var currentGridPoint = firstGridPoint;

			var longitudeOffset = 0f;
			for (var x = 0; x < Nx; x++)
			{
				var latitudeOffset = 0f;
				for (var y = 0; y < Ny; y++)
				{
					currentGridPoint = firstGridPoint.Add(latitudeOffset, longitudeOffset);
					yield return currentGridPoint;

					latitudeOffset += Dy;
				}

				longitudeOffset += Dx;
			}

			Debug.Assert(lastGridPoint.Equals(currentGridPoint));
		}
	}
}