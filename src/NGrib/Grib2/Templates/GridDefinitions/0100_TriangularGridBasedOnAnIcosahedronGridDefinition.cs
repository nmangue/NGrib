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

namespace NGrib.Grib2.Templates.GridDefinitions
{
	public class TriangularGridBasedOnAnIcosahedronGridDefinition : GridDefinition
	{
		/// <summary> .</summary>
		/// <returns> N2 as a int
		/// 
		/// </returns>
		public int N2 { get; }

		/// <summary> .</summary>
		/// <returns> N3 as a int
		/// 
		/// </returns>
		public int N3 { get; }

		/// <summary> .</summary>
		/// <returns> Ni as a int
		/// 
		/// </returns>
		public int Ni { get; }

		/// <summary> .</summary>
		/// <returns> Nd as a int
		/// 
		/// </returns>
		public int Nd { get; }

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

		public long Lonofcenter { get; }

		/// <summary> .</summary>
		/// <returns> Position as a int
		/// 
		/// </returns>
		public int Position { get; }

		/// <summary> .</summary>
		/// <returns> Order as a int
		/// 
		/// </returns>
		public int Order { get; }

		/// <summary> Get scan mode.
		/// 
		/// </summary>
		/// <returns> scan mode
		/// </returns>
		public int ScanMode { get; }

		/// <summary> .</summary>
		/// <returns> N as a int
		/// 
		/// </returns>
		public long N { get; }

		internal TriangularGridBasedOnAnIcosahedronGridDefinition(BufferedBinaryReader reader) : base(reader)
		{
			N2 = reader.ReadUInt8();
			N3 = reader.ReadUInt8();
			Ni = reader.ReadUInt16();
			Nd = reader.ReadUInt8();
			PoleLat = reader.ReadInt32() * 1e-6f;
			PoleLon = reader.ReadUInt32() * 1e-6f;
			Lonofcenter = reader.ReadUInt32();
			Position = reader.ReadUInt8();
			Order = reader.ReadUInt8();
			ScanMode = reader.ReadUInt8();
			N = reader.ReadUInt32();
		}

		public override IEnumerable<Coordinate> EnumerateGridPoints() => throw new NotImplementedException();
	}
}