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
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using NGrib.Grib2.CodeTables;
using NGrib.Grib2.Sections;

namespace NGrib.Grib2.Templates.DataRepresentations
{
	/// <summary>
	/// Data Representation Template 5.3:  Grid point data - complex packing and spatial differencing
	/// </summary>
	public class GridPointDataComplexPackingAndSpatialDifferencing : GridPointDataComplexPacking
	{
		/// <summary>
		/// Order of spatial differencing.
		/// </summary>
		public SpatialDifferencingOrder OrderSpatial { get; }

		/// <summary>
		/// Number of octets required in the Data Section to specify extra
		/// descriptors needed for spatial differencing.
		/// </summary>
		public int ExtraDescriptorsLength { get; }

		internal GridPointDataComplexPackingAndSpatialDifferencing(BufferedBinaryReader reader) : base(reader)
		{
			OrderSpatial = (SpatialDifferencingOrder) reader.ReadUInt8();
			ExtraDescriptorsLength = reader.ReadUInt8();
		}

		private protected override IEnumerable<float> DoEnumerateDataValues(BufferedBinaryReader reader, DataSection dataSection, long dataPointsNumber)
		{
			var bufRef = dataSection.DataOffset;

            var refP = NumberOfGroups * NumberOfBits;

            if (OrderSpatial != 0)
			{
                refP += (1 + (int) OrderSpatial) * (ExtraDescriptorsLength * 8);
			}

			long bufWidth = bufRef + refP / 8 + (refP % 8 != 0 ? 1 : 0);

            var widthP = NumberOfGroups * BitsGroupWidths;
            long bufLength = bufWidth + widthP / 8 + (widthP % 8 != 0 ? 1 : 0);

            var lengthP = NumberOfGroups * this.BitsScaledGroupLength;
            long bufVals = bufLength + lengthP / 8 + (lengthP % 8 != 0 ? 1 : 0);

            lengthP = 0;
            refP = OrderSpatial != 0 ? ((int) OrderSpatial + 1) * (ExtraDescriptorsLength * 8) : 0;
            long vcount = 0;

			var ng = (int)NumberOfGroups;

			var groupRefValArray = ArrayPool<int>.Shared.Rent(ng);
            reader.Seek(bufRef, System.IO.SeekOrigin.Begin);
			reader.ReadUIntN(NumberOfBits, groupRefValArray, ng, (int)refP);

			var nvalsPerGroupArray = ArrayPool<int>.Shared.Rent(ng);
            reader.Seek(bufLength, System.IO.SeekOrigin.Begin);
			reader.ReadUIntN(BitsScaledGroupLength, nvalsPerGroupArray, ng);

			var nbitsPerGroupValArray = ArrayPool<int>.Shared.Rent(ng);
            reader.Seek(bufWidth, System.IO.SeekOrigin.Begin);
			reader.ReadUIntN(BitsGroupWidths, nbitsPerGroupValArray, ng);

			var secVal = ArrayPool<long>.Shared.Rent((int)dataPointsNumber);

			reader.Seek(bufVals, System.IO.SeekOrigin.Begin);
			reader.NextUIntN();

			for (var i = 0; i < NumberOfGroups; i++)
			{
				var groupRefVal = groupRefValArray[i];
				long nvalsPerGroup = nvalsPerGroupArray[i];
				var nbitsPerGroupVal = nbitsPerGroupValArray[i];

                nvalsPerGroup *= LengthIncrement;
                nvalsPerGroup += ReferenceGroupLength;
                nbitsPerGroupVal += ReferenceGroupWidths;

                if (i == NumberOfGroups - 1)
				{
                    nvalsPerGroup = LastGroupLength;
				}
                if (dataPointsNumber < vcount + nvalsPerGroup)
                {
					throw new BadGribFormatException("Decoding error");
                }

                if (MissingValueManagement == ComplexPackingMissingValueManagement.None)
                {
                    // No explicit missing values included within data values
                    for (var j = 0; j < nvalsPerGroup; j++)
                    {
                        Debug.Assert(vcount + j < dataPointsNumber);
                        secVal[vcount + j] = groupRefVal + reader.ReadUIntN(nbitsPerGroupVal);
                    }
                }
                else if (MissingValueManagement == ComplexPackingMissingValueManagement.Primary)
                {
                    // Primary missing values included within data values
                    long maxn = 0;
                    for (var j = 0; j < nvalsPerGroup; j++)
                    {
                        if (nbitsPerGroupVal == 0)
                        {
                            maxn = (1L << NumberOfBits) - 1;
                            if (groupRefVal == maxn)
                            {
                                secVal[vcount + j] = long.MaxValue;  // missing value
                            }
                            else
                            {
                                long temp = reader.ReadUIntN(nbitsPerGroupVal);
                                secVal[vcount + j] = groupRefVal + temp;
                            }
                        }
                        else
                        {
                            long temp = reader.ReadUIntN(nbitsPerGroupVal);
                            maxn = (1L << nbitsPerGroupVal) - 1;
                            if (temp == maxn)
                            {
                                secVal[vcount + j] = long.MaxValue;  // missing value
                            }
                            else
                            {
                                secVal[vcount + j] = groupRefVal + temp;
                            }
                        }
                    }
                }
                else if (MissingValueManagement == ComplexPackingMissingValueManagement.PrimaryAndSecondary)
                {
                    // Primary and secondary missing values included within data values
                    long maxn = (1L << NumberOfBits) - 1;
                    long maxn2 = 0;  // maxn - 1
                    for (var j = 0; j < nvalsPerGroup; j++)
                    {
                        if (nbitsPerGroupVal == 0)
                        {
                            maxn2 = maxn - 1;
                            if (groupRefVal == maxn || groupRefVal == maxn2)
                            {
                                secVal[vcount + j] = long.MaxValue;  // missing value
                            }
                            else
                            {
                                long temp = reader.ReadUIntN(nbitsPerGroupVal);
                                secVal[vcount + j] = groupRefVal + temp;
                            }
                        }
                        else
                        {
                            long temp = reader.ReadUIntN(nbitsPerGroupVal);
                            maxn = (1L << nbitsPerGroupVal) - 1;
                            maxn2 = maxn - 1;
                            if (temp == maxn || temp == maxn2)
                            {
                                secVal[vcount + j] = long.MaxValue;  // missing value
                            }
                            else
                            {
                                secVal[vcount + j] = groupRefVal + temp;
                            }
                        }
                    }
                }

                vcount += nvalsPerGroup;
            }

            if (OrderSpatial != SpatialDifferencingOrder.None)
            {
                reader.Seek(bufRef, System.IO.SeekOrigin.Begin);
                reader.NextUIntN();

                long bias = 0;
                var extras = new ulong[2];
                refP = 0;

                // For Complex packing, order == 0
                // For Complex packing and spatial differencing, order == 1 or 2 (code table 5.6)
                if (OrderSpatial != SpatialDifferencingOrder.FirstOrder && OrderSpatial != SpatialDifferencingOrder.SecondOrder)
                {
					throw new BadGribFormatException($"Unsupported order of spatial differencing {OrderSpatial}");
                }

                for (var i = 0; i < (int) OrderSpatial; i++)
                {
                    extras[i] = (ulong)reader.ReadUIntN(ExtraDescriptorsLength * 8);
                }

                bias = reader.ReadIntN(ExtraDescriptorsLength * 8);

                PostProcess(secVal, dataPointsNumber, (int) OrderSpatial, bias, extras);
            }

            var binaryS = Math.Pow(2, BinaryScaleFactor);
            var decimalS = Math.Pow(10, -DecimalScaleFactor);

            var missingValue = MissingValueManagement switch
            {
                ComplexPackingMissingValueManagement.Primary => PrimaryMissingValue,
                ComplexPackingMissingValueManagement.PrimaryAndSecondary => SecondaryMissingValue,
                _ => 9999f
            };

            var val = new float[dataPointsNumber];
            for (var i = 0; i < dataPointsNumber; i++)
            {
                if (secVal[i] == long.MaxValue)
                {
                    val[i] = missingValue;
                }
                else
                {
                    val[i] = (float)((secVal[i] * binaryS + ReferenceValue) * decimalS);
                }
            }

            ArrayPool<int>.Shared.Return(groupRefValArray);
            ArrayPool<int>.Shared.Return(nvalsPerGroupArray);
            ArrayPool<int>.Shared.Return(nbitsPerGroupValArray);
            ArrayPool<long>.Shared.Return(secVal);

			return val;
        }

        private static void PostProcess(long[] values, long length, long order, long bias, ulong[] extras)
        {
            ulong last = 0, penultimate = 0;
            long j = 0;

            if (order <= 0 || order > 3)
            {
                throw new ArgumentOutOfRangeException(nameof(order), "Order must be between 1 and 3.");
            }

            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (order == 1)
            {
                last = extras[0];
                while (j < length && values[j] == long.MaxValue)
                {
                    j++;
                }

                if (j < length)
                {
                    values[j++] = (long)extras[0];
                }

                while (j < length)
                {
                    if (values[j] == long.MaxValue)
                    {
                        j++;
                    }
                    else
                    {
                        values[j] += (long)last + bias;
                        last = (ulong)values[j++];
                    }
                }
            }
            else if (order == 2)
            {
                penultimate = extras[0];
                last = extras[1];

                while (j < length && values[j] == long.MaxValue)
                {
                    j++;
                }

                if (j < length)
                {
                    values[j++] = (long)extras[0];
                }

                while (j < length && values[j] == long.MaxValue)
                {
                    j++;
                }

                if (j < length)
                {
                    values[j++] = (long)extras[1];
                }

                for (; j < length; j++)
                {
                    if (values[j] != long.MaxValue)
                    {
                        values[j] = values[j] + bias + (long)last + (long)last - (long)penultimate;
                        penultimate = last;
                        last = (ulong)values[j];
                    }
                }
            }
        }
	}
}