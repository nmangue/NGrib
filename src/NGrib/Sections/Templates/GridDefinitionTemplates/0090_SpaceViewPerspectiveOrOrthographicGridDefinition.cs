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
using System.Collections.Generic;

namespace NGrib.Sections.Templates.GridDefinitionTemplates
{
	public class SpaceViewPerspectiveOrOrthographicGridDefinition : XyEarthGridDefinition
	{
		public long Lap { get; }
		public long Lop { get; }
		public long Xo { get; }
		public long Yo { get; }
		public long Altitude { get; }

		/// <summary> .</summary>
		/// <returns> Resolution as a int
		/// 
		/// </returns>
		public int Resolution { get; }

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


		/// <summary> .</summary>
		/// <returns> Xp as a float
		/// 
		/// </returns>
		public float Xp { get; }

		/// <summary> .</summary>
		/// <returns> Yp as a float
		/// 
		/// </returns>
		public float Yp { get; }

		/// <summary> .</summary>
		/// <returns> Angle as a int
		/// 
		/// </returns>
		public long Angle { get; }

		internal SpaceViewPerspectiveOrOrthographicGridDefinition(BufferedBinaryReader reader) : base(reader)
		{
			Lap = reader.ReadInt32();
			Lop = reader.ReadUInt32();
			Resolution = reader.ReadUInt8();
			Dx = reader.ReadUInt32();
			Dy = reader.ReadUInt32();
			Xp = reader.ReadUInt32() * 1e-3f;
			Yp = reader.ReadUInt32() * 1e-3f;
			ScanMode = reader.ReadUInt8();
			Angle = reader.ReadUInt32();
			Altitude = reader.ReadUInt32() * 1_000_000;
			Xo = reader.ReadUInt32();
			Yo = reader.ReadUInt32();
		}

		public override IEnumerable<Coordinate> EnumerateGridPoints() => throw new NotImplementedException();
	}
}