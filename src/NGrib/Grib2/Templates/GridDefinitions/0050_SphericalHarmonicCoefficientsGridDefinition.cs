﻿/*
 * This file is part of NGrib.
 *
 * Copyright © 2020 Nicolas Mangué
 * 
 * Copyright 2006-2010 Seaware AB, PO Box 1244, SE-131 28 
 * Nacka Strand, Sweden, info@seaware.se.
 * 
 * Copyright 1997-2006 Unidata Program Center/University 
 * Corporation for Atmospheric Research, P.O. Box 3000, Boulder, CO 80307,
 * support@unidata.ucar.edu.
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
	public class SphericalHarmonicCoefficientsGridDefinition : GridDefinition
	{
		/// <summary> .</summary>
		/// <returns> J as a float
		/// 
		/// </returns>
		public float J { get; }

		/// <summary> .</summary>
		/// <returns> K as a float
		/// 
		/// </returns>
		public float K { get; }

		/// <summary> .</summary>
		/// <returns> M as a float
		/// 
		/// </returns>
		public float M { get; }

		/// <summary> .</summary>
		/// <returns> Method as a int
		/// 
		/// </returns>
		public int Method { get; }

		/// <summary> .</summary>
		/// <returns> Mode as a int
		/// 
		/// </returns>
		public int Mode { get; }

		internal SphericalHarmonicCoefficientsGridDefinition(BufferedBinaryReader reader) : base(reader)
		{
			J = reader.ReadSingle();
			K = reader.ReadSingle();
			M = reader.ReadSingle();
			Method = reader.ReadUInt8();
			Mode = reader.ReadUInt8();
		}

		public override IEnumerable<Coordinate> EnumerateGridPoints() => throw new NotImplementedException();
	}
}