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

namespace NGrib.Grib2.Sections.Templates.GridDefinitionTemplates
{
	public class PolarStereographicProjectionGridDefinition : GridPointEarthGridDefinition
	{
		/// <summary> .</summary>
		/// <returns> Lad as a float
		/// 
		/// </returns>
		public double Lad { get; }

		/// <summary> .</summary>
		/// <returns> Lov as a float
		/// 
		/// </returns>
		public double Lov { get; }

		/// <summary> Get x-increment/distance between two grid points.
		/// 
		/// </summary>
		/// <returns> x-increment
		/// </returns>
		public double Dx { get; }

		/// <summary> Get y-increment/distance between two grid points.
		/// 
		/// </summary>
		/// <returns> y-increment
		/// </returns>
		public double Dy { get; }

		/// <summary> .</summary>
		/// <returns> ProjectionCenter as a int
		/// 
		/// </returns>
		public int ProjectionCenter { get; }

		/// <summary> Get scan mode.
		/// 
		/// </summary>
		/// <returns> scan mode
		/// </returns>
		public int ScanMode { get; }

		internal PolarStereographicProjectionGridDefinition(BufferedBinaryReader reader) : base(reader)
		{
			Lad = reader.ReadInt32() * 1e-6;
			Lov = reader.ReadUInt32() * 1e-6;
			Dx = reader.ReadUInt32() * 1e-3;
			Dy = reader.ReadUInt32() * 1e-3;
			ProjectionCenter = reader.ReadUInt8();
			ScanMode = reader.ReadUInt8();
		}

		public override IEnumerable<Coordinate> EnumerateGridPoints() => throw new NotImplementedException();
	}
}