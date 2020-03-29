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

namespace NGrib.Grib2.Templates.DataRepresentations
{
	/// <summary>
	/// Data Representation Template 5.3:  Grid point data - complex packing and spatial differencing
	/// </summary>
	public class GridPointDataComplexPackingAndSpatialDifferencing : GridPointDataComplexPacking
	{
		/// <summary> Order of spatial differencing (see Code Table 5.6).</summary>
		/// <returns> OrderSpatial
		/// </returns>
		public int OrderSpatial { get; }

		/// <summary> Number of octets required in the Data Section to specify extra
		/// descriptors needed for spatial differencing (octets 6-ww in Data Template 7.3).
		/// </summary>
		/// <returns> DescriptorSpatial
		/// </returns>
		public int DescriptorSpatial { get; }

		internal GridPointDataComplexPackingAndSpatialDifferencing(BufferedBinaryReader reader) : base(reader)
		{
			OrderSpatial = reader.ReadUInt8();
			DescriptorSpatial = reader.ReadUInt8();
		}

		internal override IEnumerable<float> EnumerateDataValues(BufferedBinaryReader reader, long numberDataPoints)
		{
			int mvm = MissingValueManagement;

			float pmv = PrimaryMissingValue;

			int ng = (int) NumberOfGroups;

			int g1 = 0, gMin = 0, h1 = 0, h2 = 0, hMin = 0;
			// [6-ww]   1st values of undifferenced scaled values and minimums
			int os = OrderSpatial;
			int ds = DescriptorSpatial;

			reader.NextUIntN();
			int sign;
			// ds is number of bytes, convert to bits -1 for sign bit
			ds = ds * 8 - 1;
			if (os == 1)
			{
				// first order spatial differencing g1 and gMin
				sign = reader.ReadUIntN(1);
				g1 = reader.ReadUIntN(ds);
				if (sign == 1)
				{
					g1 *= (-1);
				}

				sign = reader.ReadUIntN(1);
				gMin = reader.ReadUIntN(ds);
				if (sign == 1)
				{
					gMin *= (-1);
				}
			}
			else if (os == 2)
			{
				//second order spatial differencing h1, h2, hMin
				sign = reader.ReadUIntN(1);
				h1 = reader.ReadUIntN(ds);
				if (sign == 1)
				{
					h1 *= (-1);
				}

				sign = reader.ReadUIntN(1);
				h2 = reader.ReadUIntN(ds);
				if (sign == 1)
				{
					h2 *= (-1);
				}

				sign = reader.ReadUIntN(1);
				hMin = reader.ReadUIntN(ds);
				if (sign == 1)
				{
					hMin *= (-1);
				}
			}
			else
			{
				throw new NoValidGribException("DS Error");
			}

			// [ww +1]-xx  Get reference values for groups (X1's)
			int[] x1 = new int[ng];
			int nbBits = NumberOfBits;

			reader.NextUIntN();
			for (int i = 0; i < ng; i++)
			{
				x1[i] = reader.ReadUIntN(nbBits);
			}

			// [xx +1 ]-yy Get number of bits used to encode each group
			int[] nb = new int[ng];
			nbBits = BitsGroupWidths;

			reader.NextUIntN();
			for (int i = 0; i < ng; i++)
			{
				nb[i] = reader.ReadUIntN(nbBits);
			}

			// [yy +1 ]-zz Get the scaled group lengths using formula
			//     Ln = ref + Kn * len_inc, where n = 1-NG,
			//          ref = referenceGroupLength, and  len_inc = lengthIncrement

			int[] l = new int[ng];
			int countL = 0;
			int rgLength = (int) ReferenceGroupLength;

			int lenInc = LengthIncrement;

			nbBits = BitsScaledGroupLength;

			reader.NextUIntN();
			for (int i = 0; i < ng; i++)
			{
				// NG
				l[i] = rgLength + reader.ReadUIntN(nbBits) * lenInc;

				countL += l[i];
			}

			// [zz +1 ]-nn get X2 values and add X1[ i ] + X2

			var data = new float[countL];


			//gds.getNumberPoints() );
			// used to check missing values when X2 is packed with all 1's
			int[] bitsmv1 = new int[31];
			//int bitsmv2[] = new int[ 31 ]; didn't code cuz number larger the # of bits
			for (int i = 0; i < 31; i++)
			{
				bitsmv1[i] = (int) Math.Pow(2, i) - 1;
			}

			var count = 0;
			int x2;
			reader.NextUIntN();
			for (int i = 0; i < ng - 1; i++)
			{
				for (int j = 0; j < l[i]; j++)
				{
					if (nb[i] == 0)
					{
						if (mvm == 0)
						{
							// X2 = 0
							data[count++] = x1[i];
						}
						else if (mvm == 1)
						{
							data[count++] = pmv;
						}
					}
					else
					{
						x2 = reader.ReadUIntN(nb[i]);

						if (mvm == 0)
						{
							data[count++] = x1[i] + x2;
						}
						else if (mvm == 1)
						{
							// X2 is also set to missing value is all bits set to 1's
							if (x2 == bitsmv1[nb[i]])
							{
								data[count++] = pmv;
							}
							else
							{
								data[count++] = x1[i] + x2;
							}
						}
					}
				} // end for j
			} // end for i

			// process last group
			int last = (int) LengthLastGroup;

			for (int j = 0; j < last; j++)
			{
				// last group
				if (nb[ng - 1] == 0)
				{
					if (mvm == 0)
					{
						// X2 = 0
						data[count++] = x1[ng - 1];
					}
					else if (mvm == 1)
					{
						data[count++] = pmv;
					}
				}
				else
				{
					x2 = reader.ReadUIntN(nb[ng - 1]);
					if (mvm == 0)
					{
						data[count++] = x1[ng - 1] + x2;
					}
					else if (mvm == 1)
					{
						// X2 is also set to missing value is all bits set to 1's
						if (x2 == bitsmv1[nb[ng - 1]])
						{
							data[count++] = pmv;
						}
						else
						{
							data[count++] = x1[ng - 1] + x2;
						}
					}
				}
			} // end for j

			if (os == 1)
			{
				// g1 and gMin this coding is a sort of guess, no doc
				float sum = 0;
				if (mvm == 0)
				{
					// no missing values
					for (int i = 1; i < data.Length; i++)
					{
						data[i] += gMin; // add minimum back
					}

					data[0] = g1;
					for (int i = 1; i < data.Length; i++)
					{
						sum += data[i];
						data[i] = data[i - 1] + sum;
					}
				}
				else
				{
					// contains missing values
					float lastOne = pmv;
					// add the minimum back and set g1
					int idx = 0;
					for (int i = 0; i < data.Length; i++)
					{
						if (data[i] != pmv)
						{
							if (idx == 0)
							{
								// set g1
								data[i] = g1;
								lastOne = data[i];
								idx = i + 1;
							}
							else
							{
								data[i] += gMin;
							}
						}
					}

					if (lastOne == pmv)
					{
						throw new NoValidGribException("DS bad spatial differencing data");
					}

					for (int i = idx; i < data.Length; i++)
					{
						if (data[i] != pmv)
						{
							sum += data[i];
							data[i] = lastOne + sum;
							lastOne = data[i];
						}
					}
				}
			}
			else if (os == 2)
			{
				//h1, h2, hMin
				float hDiff = h2 - h1;
				float sum = 0;
				if (mvm == 0)
				{
					// no missing values
					for (int i = 2; i < data.Length; i++)
					{
						data[i] += hMin; // add minimum back
					}

					data[0] = h1;
					data[1] = h2;
					sum = hDiff;
					for (int i = 2; i < data.Length; i++)
					{
						sum += data[i];
						data[i] = data[i - 1] + sum;
					}
				}
				else
				{
					// contains missing values
					int idx = 0;
					float lastOne = pmv;
					// add the minimum back and set h1 and h2
					for (int i = 0; i < data.Length; i++)
					{
						if (data[i] != pmv)
						{
							if (idx == 0)
							{
								// set h1
								data[i] = h1;
								sum = 0;
								lastOne = data[i];
								idx++;
							}
							else if (idx == 1)
							{
								// set h2
								data[i] = h1 + hDiff;
								sum = hDiff;
								lastOne = data[i];
								idx = i + 1;
							}
							else
							{
								data[i] += hMin;
							}
						}
					}

					if (lastOne == pmv)
					{
						throw new NoValidGribException("DS bad spatial differencing data");
					}

					for (int i = idx; i < data.Length; i++)
					{
						if (data[i] != pmv)
						{
							sum += data[i];

							data[i] = lastOne + sum;
							lastOne = data[i];
						}
					}
				}
			} // end h1, h2, hMin

			// formula used to create values,  Y * 10**D = R + (X1 + X2) * 2**E

			int d = DecimalScaleFactor;

			float dd = (float) Math.Pow(10, d);

			float r = ReferenceValue;

			int e = BinaryScaleFactor;

			float ee = (float) Math.Pow(2.0, e);

			if (mvm == 0)
			{
				// no missing values
				for (int i = 0; i < data.Length; i++)
				{
					data[i] = (r + data[i] * ee) / dd;
				}
			}
			else
			{
				// missing value == 1
				for (int i = 0; i < data.Length; i++)
				{
					if (data[i] != pmv)
					{
						data[i] = (r + data[i] * ee) / dd;
					}
				}
			}

			return data;
		}
	}
}