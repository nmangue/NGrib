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
using NGrib.Grib2.CodeTables;

namespace NGrib.Grib2.Templates.DataRepresentations
{
	/// <summary>
	/// Data Representation Template 5.2: Grid point data - complex packing
	/// </summary>
	public class GridPointDataComplexPacking : GridPointDataSimplePacking
	{
		/// <summary>
		/// Group splitting method used.
		/// </summary>
		public GroupSplittingMethod GroupSplittingMethod { get; }

		/// <summary>
		/// Group splitting method used.
		/// </summary>
		public ComplexPackingMissingValueManagement MissingValueManagement { get; }

		/// <summary>
		/// Primary missing value substitute.
		/// </summary>
		public float PrimaryMissingValue { get; }

		/// <summary>
		/// Secondary missing value substitute.
		/// </summary>
		public float SecondaryMissingValue { get; }

		/// <summary>
		/// Number of groups of data values into which field is split (NG).
		/// </summary>
		public long NumberOfGroups { get; }

		/// <summary>
		/// Reference for group widths.
		/// </summary>
		public int ReferenceGroupWidths { get; }

		/// <summary>
		/// Number of bits used for the group widths.
		/// </summary>
		public int BitsGroupWidths { get; }

		/// <summary>
		/// Reference for group lengths.
		/// </summary>
		public long ReferenceGroupLength { get; }

		/// <summary>
		/// Length increment for the group lengths.
		/// </summary>
		public int LengthIncrement { get; }

		/// <summary>
		/// True length of last group.
		/// </summary>
		public long LastGroupLength { get; }

		/// <summary>
		/// Number of bits used for the scaled group lengths.
		/// </summary>
		/// <remarks>
		/// After subtraction of the reference value given in octets 38-41 and division by the length increment given in octet 42.
		/// </remarks>
		public int BitsScaledGroupLength { get; }

		internal GridPointDataComplexPacking(BufferedBinaryReader reader) : base(reader)
		{
			GroupSplittingMethod = (GroupSplittingMethod) reader.ReadUInt8();

			MissingValueManagement = (ComplexPackingMissingValueManagement) reader.ReadUInt8();

			PrimaryMissingValue = reader.ReadSingle();
			SecondaryMissingValue = reader.ReadSingle();
			NumberOfGroups = reader.ReadUInt32();

			ReferenceGroupWidths = reader.ReadUInt8();

			BitsGroupWidths = reader.ReadUInt8();
			// according to documentation subtract referenceGroupWidths
			BitsGroupWidths = BitsGroupWidths - ReferenceGroupWidths;

			ReferenceGroupLength = reader.ReadUInt32();

			LengthIncrement = reader.ReadUInt8();

			LastGroupLength = reader.ReadUInt32();

			BitsScaledGroupLength = reader.ReadUInt8();
		}

		internal override IEnumerable<float> EnumerateDataValues(BufferedBinaryReader reader, long numberDataPoints)
		{
			var mvm = MissingValueManagement;

			var pmv = PrimaryMissingValue;

			var ng = (int) NumberOfGroups;

			// 6-xx  Get reference values for groups (X1's)
			var x1 = new int[ng];
			var nbBits = NumberOfBits;

			for (var i = 0; i < ng; i++)
			{
				x1[i] = reader.ReadUIntN(nbBits);
			}

			// [xx + 1 ]-yy Get number of bits used to encode each group
			var nb = new int[ng];
			nbBits = BitsGroupWidths;

			reader.NextUIntN();
			for (var i = 0; i < ng; i++)
			{
				nb[i] = reader.ReadUIntN(nbBits);
			}

			// [yy +1 ]-zz Get the scaled group lengths using formula
			//     Ln = ref + Kn * len_inc, where n = 1-NG,
			//          ref = referenceGroupLength, and  len_inc = lengthIncrement

			var l = new int[ng];
			var rgLength = (int) ReferenceGroupLength;

			var lenInc = LengthIncrement;

			nbBits = BitsScaledGroupLength;

			reader.NextUIntN();
			for (var i = 0; i < ng; i++)
			{
				// NG
				l[i] = rgLength + reader.ReadUIntN(nbBits) * lenInc;
			}

			// [zz +1 ]-nn get X2 values and calculate the results Y using formula
			//                Y * 10**D = R + (X1 + X2) * 2**E

			var d = DecimalScaleFactor;

			var dd = Math.Pow(10, d);

			var r = ReferenceValue;

			var e = BinaryScaleFactor;

			var ee = Math.Pow(2.0, e);

			// used to check missing values when X2 is packed with all 1's
			var bitsmv1 = new int[31];
			for (var i = 0; i < 31; i++)
			{
				bitsmv1[i] = (int) Math.Pow(2, i) - 1;
			}

			int x2;
			reader.NextUIntN();
			for (var i = 0; i < ng - 1; i++)
			{
				for (var j = 0; j < l[i]; j++)
				{
					if (nb[i] == 0)
					{
						if (mvm == 0)
						{
							// X2 = 0
							yield return (float) ((r + x1[i] * ee) / dd);
						}
						else if (mvm == ComplexPackingMissingValueManagement.Primary)
						{
							yield return pmv;
						}
					}
					else
					{
						x2 = reader.ReadUIntN(nb[i]);
						if (mvm == 0)
						{
							yield return (float) ((r + (x1[i] + x2) * ee) / dd);
						}
						else if (mvm == ComplexPackingMissingValueManagement.Primary)
						{
							// X2 is also set to missing value is all bits set to 1's
							if (x2 == bitsmv1[nb[i]])
							{
								yield return pmv;
							}
							else
							{
								yield return (float) ((r + (x1[i] + x2) * ee) / dd);
							}
						}
					}
				} // end for j
			} // end for i

			// process last group
			var last = (int) LastGroupLength;

			for (var j = 0; j < last; j++)
			{
				// last group
				if (nb[ng - 1] == 0)
				{
					if (mvm == 0)
					{
						// X2 = 0
						yield return (float) ((r + x1[ng - 1] * ee) / dd);
					}
					else if (mvm == ComplexPackingMissingValueManagement.Primary)
					{
						yield return pmv;
					}
				}
				else
				{
					x2 = reader.ReadUIntN(nb[ng - 1]);
					if (mvm == 0)
					{
						yield return (float) ((r + (x1[ng - 1] + x2) * ee) / dd);
					}
					else if (mvm == ComplexPackingMissingValueManagement.Primary)
					{
						// X2 is also set to missing value is all bits set to 1's
						if (x2 == bitsmv1[nb[ng - 1]])
						{
							yield return pmv;
						}
						else
						{
							yield return (float) ((r + (x1[ng - 1] + x2) * ee) / dd);
						}
					}
				}
			} // end for j
		}
	}
}