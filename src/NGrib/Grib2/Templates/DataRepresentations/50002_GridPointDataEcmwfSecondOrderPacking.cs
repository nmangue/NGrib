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

using NGrib.Grib2.Sections;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace NGrib.Grib2.Templates.DataRepresentations
{
	/// <summary>
	/// Data Representation Template 5.0: Grid point data - second order packing
	/// </summary>
	/// <remarks>
	///	https://apps.ecmwf.int/codes/grib/format/grib2/templates/5/50002
	/// </remarks>
	public class GridPointDataEcmwfSecondOrderPacking : DataRepresentation
	{
		/// <summary>
		/// Reference value (R) .
		/// </summary>
		public float ReferenceValue { get; }

		/// <summary>
		/// Binary scale factor (E).
		/// </summary>
		public int BinaryScaleFactor { get; }

		/// <summary>
		/// Decimal scale factor (D).
		/// </summary>
		public int DecimalScaleFactor { get; }

		/// <summary>
		/// Number of bits used for each packed value.
		/// </summary>
		public int NumberOfBits { get; }

		/// <summary>
		/// Width of first order values 
		/// </summary>
		public int WidthOfFirstOrderValues { get; }

		/// <summary>
		/// Number of groups
		/// </summary>
		public long P1 { get; }

		/// <summary>
		/// Number of second order packed values
		/// </summary>
		public long P2 { get; }

		/// <summary>
		/// Width of widths 
		/// </summary>
		public int WidthOfWidths { get; }

		/// <summary>
		/// Width of lengths 
		/// </summary>
		public int WidthOfLengths { get; }

		/// <summary>
		/// Ordering flags (Flag table 5.50002) 
		/// </summary>
		public int SecondOrderFlags { get; }

		/// <summary>
		/// Order of spatial differencing 
		/// </summary>
		public int OrderOfSpd { get; }

		/// <summary>
		/// Width of spatial differencing 
		/// </summary>
		public int WidthOfSpd { get; }

		/// <summary>
		/// SPD
		/// </summary>
		public IReadOnlyList<int> Spd { get; }

		internal GridPointDataEcmwfSecondOrderPacking(BufferedBinaryReader reader)
		{
			ReferenceValue = reader.ReadSingle();
			BinaryScaleFactor = reader.ReadInt16();
			DecimalScaleFactor = reader.ReadInt16();
			NumberOfBits = reader.ReadUInt8();

			WidthOfFirstOrderValues = reader.ReadUInt8();
			P1 = reader.ReadUInt32();
			P2 = reader.ReadUInt32();
			WidthOfWidths = reader.ReadUInt8();
			WidthOfLengths = reader.ReadUInt8();
			SecondOrderFlags = reader.ReadUInt8();
			OrderOfSpd = reader.ReadUInt8();
			WidthOfSpd = reader.ReadUInt8();
			var spdA = new int [OrderOfSpd + 1];

			reader.NextUIntN();
			for (var i = 0; i < OrderOfSpd; i++)
			{
				spdA[i] = reader.ReadUIntN(WidthOfSpd);
			}

			spdA[OrderOfSpd] = reader.ReadIntN(WidthOfSpd);
			Spd = spdA.ToImmutableList();
		}

		private protected override IEnumerable<float> DoEnumerateDataValues(BufferedBinaryReader reader, DataSection dataSection, long dataPointsNumber)
		{
			// Implementation based on NetCDF-Java
			// https://github.com/Unidata/netcdf-java/blob/v5.4.2/grib/src/main/java/ucar/nc2/grib/grib2/Grib2DataReader.java#L972
			reader.NextUIntN();
			var groupWidth = new int[P1];
			for (var i = 0; i < P1; i++)
			{
				groupWidth[i] = reader.ReadUIntN(WidthOfWidths);
			}

			reader.NextUIntN();
			var groupLength = new int[P1];
			for (var i = 0; i < P1; i++)
			{
				groupLength[i] = reader.ReadUIntN(WidthOfLengths);
			}

			reader.NextUIntN();
			var firstOrderValues = new int[P1];
			for (var i = 0; i < P1; i++)
			{
				firstOrderValues[i] = reader.ReadUIntN(WidthOfFirstOrderValues);
			}

			var bias = 0;
			if (OrderOfSpd > 0)
			{
				bias = Spd[OrderOfSpd];
			}

			reader.NextUIntN();
			var cnt = OrderOfSpd;
			var data = new int[dataPointsNumber];
			for (var i = 0; i < P1; i++)
			{
				if (groupWidth[i] > 0)
				{
					for (var j = 0; j < groupLength[i]; j++)
					{
						data[cnt] = reader.ReadUIntN(groupWidth[i]);
						data[cnt] += firstOrderValues[i];
						cnt++;
					}
				}
				else
				{
					for (var j = 0; j < groupLength[i]; j++)
					{
						data[cnt] = firstOrderValues[i];
						cnt++;
					}
				}
			}

			for (var i = 0; i < OrderOfSpd; i++)
			{
				data[i] = Spd[i];
			}

			int y, z, w;
			switch (OrderOfSpd)
			{
				case 1:
					y = data[0];
					for (var i = 1; i < dataPointsNumber; i++)
					{
						y += data[i] + bias;
						data[i] = y;
					}

					break;
				case 2:
					y = data[1] - data[0];
					z = data[1];
					for (var i = 2; i < dataPointsNumber; i++)
					{
						y += data[i] + bias;
						z += y;
						data[i] = z;
					}

					break;
				case 3:
					y = data[2] - data[1];
					z = y - (data[1] - data[0]);
					w = data[2];
					for (var i = 3; i < dataPointsNumber; i++)
					{
						z += data[i] + bias;
						y += z;
						w += y;
						data[i] = w;
					}

					break;
			}

			var d = DecimalScaleFactor;

			var dd = Math.Pow(10, -d);

			var r = ReferenceValue;

			var e = BinaryScaleFactor;

			var ee = Math.Pow(2.0, e);

			for (var i = 0; i < dataPointsNumber; i++)
			{
				yield return (float)((data[i] * ee + r) * dd);
			}
		}
	}
}