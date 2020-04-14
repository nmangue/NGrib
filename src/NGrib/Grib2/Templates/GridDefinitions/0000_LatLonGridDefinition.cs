/*
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
using System.Diagnostics;
using NGrib.Grib2.CodeTables;

namespace NGrib.Grib2.Templates.GridDefinitions
{
	public class LatLonGridDefinition : XyEarthGridDefinition
	{
		/// <summary>
		/// Basic angle of the initial production domain.
		/// </summary>
		public long Angle { get; }

		/// <summary>
		/// Subdivisions of basic angle used to define extreme longitudes and latitudes, and direction increments.
		/// </summary>
		public long SubdivisionsAngle { get; }

		/// <summary>
		/// Latitude of first grid point.
		/// </summary>
		public double La1 { get; }

		/// <summary>
		/// Longitude of first grid point.
		/// </summary>
		public double Lo1 { get; }

		/// <summary>
		/// Resolution and component flags value.
		/// </summary>
		public ResolutionAndComponent ResolutionAndComponent { get; }

		/// <summary>
		/// Latitude of last grid point.
		/// </summary>
		public double La2 { get; }

		/// <summary>
		/// Longitude of last grid point.
		/// </summary>
		public double Lo2 { get; }

		/// <summary>
		/// X-direction increment.
		/// </summary>
		public double Dx { get; }

		/// <summary>
		/// Y-direction increment.
		/// </summary>
		public double Dy { get; }

		/// <summary>
		/// Scanning mode.
		/// </summary>
		public int ScanMode { get; }

		internal LatLonGridDefinition(BufferedBinaryReader reader) : base(reader)
		{
			Angle = reader.ReadUInt32();
			SubdivisionsAngle = reader.ReadUInt32();
			double ratio;
			if (Angle == 0)
			{
				ratio = 1e-6;
			}
			else
			{
				ratio = Angle / (double) SubdivisionsAngle;
			}

			La1 = reader.ReadInt32() * ratio;
			Lo1 = reader.ReadInt32() * ratio;
			ResolutionAndComponent = (ResolutionAndComponent) reader.ReadUInt8();
			La2 = reader.ReadInt32() * ratio;
			Lo2 = reader.ReadInt32() * ratio;
			Dx = reader.ReadInt32() * ratio;
			Dy = reader.ReadInt32() * ratio;
			ScanMode = reader.ReadUInt8();
		}

		public override IEnumerable<Coordinate> EnumerateGridPoints()
		{
			var scanningMode = (ScanningMode) ScanMode;
			var resolution = ResolutionAndComponent;

			if (resolution != (ResolutionAndComponent.JDirectionIncrementGiven | ResolutionAndComponent.IDirectionIncrementGiven) ||
			    (scanningMode & ~(ScanningMode.ScanJPositive | ScanningMode.ScanIReverse)) != ScanningMode.Default)
			{
				throw new NotImplementedException();
			}

			var firstGridPoint = new Coordinate(La1, Lo1);
			var lastGridPoint = new Coordinate(La2, Lo2);

			var xStep = Dx * (scanningMode.HasFlag(ScanningMode.ScanIReverse) ? -1 : 1);
			var yStep = Dy * (scanningMode.HasFlag(ScanningMode.ScanJPositive) ? 1 : -1);
			var currentGridPoint = firstGridPoint;

			// Adjacent points in x direction are consecutive 
			var latitudeOffset = 0d;
			for (var y = 0; y < Ny; y++)
			{
				var longitudeOffset = 0d;
				for (var x = 0; x < Nx; x++)
				{
					currentGridPoint = firstGridPoint.Add(latitudeOffset, longitudeOffset);
					yield return currentGridPoint;

					longitudeOffset += xStep;
				}
				latitudeOffset += yStep;
			}

			Debug.Assert(lastGridPoint.Equals(currentGridPoint));
		}
	}
}