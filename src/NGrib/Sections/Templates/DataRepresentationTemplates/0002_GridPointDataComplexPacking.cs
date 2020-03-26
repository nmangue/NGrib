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

namespace NGrib.Sections.Templates.DataRepresentationTemplates
{
    /// <summary>
    /// Data Representation Template 5.2: Grid point data - complex packing
    /// </summary>
    public class GridPointDataComplexPacking : GridPointDataSimplePacking
    {
        /// <summary> Group splitting method used (see Code Table 5.4).</summary>
        /// <returns> SplittingMethod
        /// </returns>
        public int SplittingMethod { get; }

        /// <summary> Missing value management used (see Code Table 5.5).</summary>
        /// <returns> MissingValueManagement
        /// </returns>
        public int MissingValueManagement { get; }

        /// <summary> Primary missing value substitute.</summary>
        /// <returns> PrimaryMissingValue
        /// </returns>
        public float PrimaryMissingValue { get; private set; }

        /// <summary> Secondary missing value substitute.</summary>
        /// <returns> SecondaryMissingValue
        /// </returns>
        public float SecondaryMissingValue { get; private set; }

        /// <summary> NG - Number of groups of data values into which field is split.</summary>
        /// <returns> NumberOfGroups NG
        /// </returns>
        public long NumberOfGroups { get; }

        /// <summary> Reference for group widths (see Note 12).</summary>
        /// <returns> ReferenceGroupWidths
        /// </returns>
        public int ReferenceGroupWidths { get; }

        /// <summary> Number of bits used for the group widths (after the reference value 
        /// in octet 36 has been removed).
        /// </summary>
        /// <returns> BitsGroupWidths
        /// </returns>
        public int BitsGroupWidths { get; }

        /// <summary> Reference for group lengths (see Note 13).</summary>
        /// <returns> ReferenceGroupLength
        /// </returns>
        public long ReferenceGroupLength { get; }

        /// <summary> Length increment for the group lengths (see Note 14).</summary>
        /// <returns> LengthIncrement
        /// </returns>
        public int LengthIncrement { get; }

        /// <summary> Length increment for the group lengths (see Note 14).</summary>
        /// <returns> LengthLastGroup
        /// </returns>
        public long LengthLastGroup { get; }

        /// <summary> Number of bits used for the scaled group lengths (after subtraction of 
        /// the reference value given in octets 38-41 and division by the length 
        /// increment given in octet 42).
        /// </summary>
        /// <returns> BitsScaledGroupLength
        /// </returns>
        public int BitsScaledGroupLength { get; }

        internal GridPointDataComplexPacking(BufferedBinaryReader reader) : base(reader)
        {
            SplittingMethod = reader.ReadUInt8();

            MissingValueManagement = reader.ReadUInt8();

            PrimaryMissingValue = reader.ReadSingle();
            SecondaryMissingValue = reader.ReadSingle();
            NumberOfGroups = reader.ReadUInt32();

            ReferenceGroupWidths = reader.ReadUInt8();

            BitsGroupWidths = reader.ReadUInt8();
            // according to documentation subtract referenceGroupWidths
            BitsGroupWidths = BitsGroupWidths - ReferenceGroupWidths;

            ReferenceGroupLength = reader.ReadUInt32();

            LengthIncrement = reader.ReadUInt8();

            LengthLastGroup = reader.ReadUInt32();

            BitsScaledGroupLength = reader.ReadUInt8();
        }

        internal override IEnumerable<float> EnumerateDataValues(BufferedBinaryReader reader, long numberDataPoints)
        {
					int mvm = MissingValueManagement;

					float pmv = PrimaryMissingValue;

					int NG = (int) NumberOfGroups;

					// 6-xx  Get reference values for groups (X1's)
					int[] X1 = new int[NG];
					int nb = NumberOfBits;
			
					for (int i = 0; i < NG; i++)
					{
						X1[i] = reader.ReadUIntN(nb);
					}

					// [xx + 1 ]-yy Get number of bits used to encode each group
					int[] NB = new int[NG];
					nb = BitsGroupWidths;

					reader.NextUIntN();
					for (int i = 0; i < NG; i++)
					{
						NB[i] = reader.ReadUIntN(nb);
					}

					// [yy +1 ]-zz Get the scaled group lengths using formula
					//     Ln = ref + Kn * len_inc, where n = 1-NG,
					//          ref = referenceGroupLength, and  len_inc = lengthIncrement

					int[] L = new int[NG];
					int countL = 0;
					int ref_Renamed = (int) ReferenceGroupLength;

					int len_inc = LengthIncrement;

					nb = BitsScaledGroupLength;

					reader.NextUIntN();
					for (int i = 0; i < NG; i++)
					{
						// NG
						L[i] = ref_Renamed + reader.ReadUIntN(nb) * len_inc;

						countL += L[i];
					}

					// [zz +1 ]-nn get X2 values and calculate the results Y using formula
					//                Y * 10**D = R + (X1 + X2) * 2**E

					int D = DecimalScaleFactor;

					float DD = (float) Math.Pow(10, D);

					float R = ReferenceValue;

					int E = BinaryScaleFactor;

					float EE = (float) Math.Pow(2.0, E);

					// used to check missing values when X2 is packed with all 1's
					int[] bitsmv1 = new int[31];
					for (int i = 0; i < 31; i++)
					{
						bitsmv1[i] = (int) Math.Pow( 2, i) - 1;
					}

					int X2;
					reader.NextUIntN();
					for (int i = 0; i < NG - 1; i++)
					{
						for (int j = 0; j < L[i]; j++)
						{
							if (NB[i] == 0)
							{
								if (mvm == 0)
								{
									// X2 = 0
									yield return (R + X1[i] * EE) / DD;
								}
								else if (mvm == 1)
								{
									yield return pmv;
								}
							}
							else
							{
								X2 = reader.ReadUIntN(NB[i]);
								if (mvm == 0)
								{
									yield return (R + (X1[i] + X2) * EE) / DD;
								}
								else if (mvm == 1)
								{
									// X2 is also set to missing value is all bits set to 1's
									if (X2 == bitsmv1[NB[i]])
									{
										yield return pmv;
									}
									else
									{
										yield return (R + (X1[i] + X2) * EE) / DD;
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
						if (NB[NG - 1] == 0)
						{
							if (mvm == 0)
							{
								// X2 = 0
								yield return (R + X1[NG - 1] * EE) / DD;
							}
							else if (mvm == 1)
							{
								yield return pmv;
							}
						}
						else
						{
							X2 = reader.ReadUIntN(NB[NG - 1]);
							if (mvm == 0)
							{
								yield return (R + (X1[NG - 1] + X2) * EE) / DD;
							}
							else if (mvm == 1)
							{
								// X2 is also set to missing value is all bits set to 1's
								if (X2 == bitsmv1[NB[NG - 1]])
								{
									yield return pmv;
								}
								else
								{
									yield return (R + (X1[NG - 1] + X2) * EE) / DD;
								}
							}
						}
					} // end for j
        }

        internal override float? MissingValueSubstitute => PrimaryMissingValue;
    }
}