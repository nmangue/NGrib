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
	public class EquatorialAzimuthalEquidistantProjectionGridDefinition : GridPointEarthGridDefinition
	{
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
		/// <returns> ProjectionCenter as a int
		/// 
		/// </returns>
		public int ProjectionCenter { get; }

		internal EquatorialAzimuthalEquidistantProjectionGridDefinition(BufferedBinaryReader reader) : base(reader)
		{
			Dx = reader.ReadUInt32() * 1e-3f;
			Dy = reader.ReadUInt32() * 1e-3f;
			ProjectionCenter = reader.ReadUInt8();
			ScanMode = reader.ReadUInt8();
		}

		public override IEnumerable<Coordinate> EnumerateGridPoints() => throw new NotImplementedException();
	}
}