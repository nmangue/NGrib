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
using System.IO;

namespace NGrib.Grib1
{
    /// <summary>
    /// A class representing the binary data section (BDS) of a GRIB record.
    /// </summary>
    public sealed class Grib1BinaryDataSection
    {
        /// <summary>
        /// Grid values as an array of float.
        /// </summary>
        public float[] Values { get; private set; }

        /// <summary>
        /// Constant value for an undefined grid value.
        /// </summary>
        public static float MissingValue { get; } = -9999f;

        /// <summary>
        /// Length in bytes of this BDS.
        /// </summary>
        private int length;

        /// <summary>
        /// Buffer for one byte which will be processed bit by bit.
        /// </summary>
        private int bitBuf;

        /// <summary>
        /// Current bit position in <tt>bitBuf</tt>.
        /// </summary>
        private int bitPos;

        /// <summary> Indicates whether the BMS is represented by a single value
        /// Octet 12 is empty, and the data is represented by the reference value.
        /// </summary>
        private bool isConstant;

        private long startPos;

        /// <summary> Constructs a Grib1BinaryDataSection object from a raf.
        /// A bit map is defined.
        /// 
        /// </summary>
        /// <param name="raf">raf with BDS content
        /// </param>
        /// <param name="decimalscale">the exponent of the decimal scale
        /// </param>
        /// <param name="bms">bit map section of GRIB record
        /// 
        /// </param>
        /// <throws>  NotSupportedException  if stream contains no valid GRIB file </throws>
        //UPGRADE_TODO: Class 'java.io.RandomAccessFile' was converted to 'System.IO.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioRandomAccessFile'"
        internal Grib1BinaryDataSection(System.IO.Stream raf, int decimalscale, Grib1BitMapSection bms,
            Grib1Record record)
        {
            startPos = raf.Position;

            // octets 1-3 (section length)
            length = (int)GribNumbers.uint3(raf);


            // octet 4, 1st half (packing flag)
            int unusedbits = raf.ReadByte();

            bool isSimplePacking = !GribNumbers.TestGribBitIsSet(unusedbits, 2);


            // octet 4, 2nd half (number of unused bits at end of this section)
            unusedbits = unusedbits & 15;


            // octets 5-6 (binary scale factor)
            int binscale = GribNumbers.int2(raf);

            // octets 7-10 (reference point = minimum value)
            float refvalue = GribNumbers.float4(raf);

            // octet 11 (number of bits per value)
            int numbits = raf.ReadByte();

            if (numbits == 0)
                isConstant = true;


            // *** read values *******************************************************

            if (isSimplePacking)
            {
                ReadSimplePacking(raf, decimalscale, bms, refvalue, binscale, numbits, unusedbits);
            }
            else
            {
                throw new NotSupportedException("BDS: (octet 4, 1st half) not grid point data and simple packing ");
                //ReadComplexPacking(raf, decimalscale, bms, refvalue, binscale, numbits, unusedbits, record);
            }
        }

        /**
         * untested code for reading complex packing
         */
        // private void ReadComplexPacking(Stream raf, int decimalscale, Grib1BitMapSection bms, float refvalue,
        //     int binscale,
        //     int numbits, int unusedbits, Grib1Record record)
        // {
        //     
        //     // octet 12-13
        //     int N1 = GribNumbers.uint2(raf);
        //     
        //     // octet 14
        //     int flagExt = raf.ReadByte();
        //
        //     /*
        //      * From
        //      * http://cost733.geo.uni-augsburg.de/cost733class-1.2/browser/grib_api-1.9.18/definitions/grib1/11-2.table?rev=4
        //      * 
        //      * # CODE TABLE 11-2, Flag
        //      * # Undocumented use of octet 14 extededFlags
        //      * # Taken from d2ordr.F
        //      * # R------- only bit 1 is reserved.
        //      * # -0------ single datum at each grid point.
        //      * # -1------ matrix of values at each grid point.
        //      * # --0----- no secondary bit map.
        //      * # --1----- secondary bit map present.
        //      * # ---0---- second order values have constant width.
        //      * # ---1---- second order values have different widths.
        //      * # ----0--- no general extended second order packing.
        //      * # ----1--- general extended second order packing used.
        //      * # -----0-- standard field ordering in section 4.
        //      * # -----1-- boustrophedonic ordering in section 4.
        //      * 1 0 Reserved
        //      * 1 1 Reserved
        //      * 2 0 Single datum at each grid point
        //      * 2 1 Matrix of values at each grid point
        //      * 3 0 No secondary bitmap Present
        //      * 3 1 Secondary bitmap Present
        //      * 4 0 Second-order values constant width
        //      * 4 1 Second-order values different widths
        //      * 5 0 no general extended second order packing
        //      * 5 1 general extended second order packing used
        //      * 6 0 standard field ordering in section 4
        //      * 6 1 boustrophedonic ordering in section 4
        //      * # ------00 no spatial differencing used.
        //      * # ------01 1st-order spatial differencing used.
        //      * # ------10 2nd-order "         " " .
        //      * # ------11 3rd-order "         " " .
        //      * 
        //      */
        //
        //     bool hasBitmap2 = GribNumbers.TestGribBitIsSet(flagExt, 3);
        //     bool hasDifferentWidths = GribNumbers.TestGribBitIsSet(flagExt, 4);
        //     bool useGeneralExtended = GribNumbers.TestGribBitIsSet(flagExt, 5);
        //     bool useBoustOrdering = GribNumbers.TestGribBitIsSet(flagExt, 6);
        //
        //     /*
        //      * Octet Contents
        //      * 12–13 N1 – octet number at which first-order packed data begin
        //      * 14 Extended flags (see Code table 11)
        //      * 15–16 N2 – octet number at which second-order packed data begin
        //      * 
        //      * try replacing:
        //      * 17–18 P1 – number of first-order packed values
        //      * 19–20 P2 – number of second-order packed values
        //      * 21 Reserved
        //      * 
        //      * with:
        //      * data.grid_second_order.def
        //      * 
        //      * unsigned [2] N2 : dump;
        //      * unsigned [2] codedNumberOfGroups : no_copy ;
        //      * unsigned [2] numberOfSecondOrderPackedValues : dump;
        //      * 
        //      * # used to extend
        //      * unsigned [1] extraValues=0 : hidden, edition_specific;
        //      * 
        //      * meta numberOfGroups evaluate(codedNumberOfGroups + 65536 * extraValues);
        //      * 
        //      * unsigned [1] widthOfWidths : dump;
        //      * unsigned [1] widthOfLengths : dump;
        //      * unsigned [2] NL : dump;
        //      * 
        //      * if (orderOfSPD) {
        //      * unsigned[1] widthOfSPD ;
        //      * meta SPD spd(widthOfSPD,orderOfSPD) : read_only;
        //      * }
        //      */
        //
        //     // octet 15-16
        //     int N2 = GribNumbers.uint2(raf);
        //     // octet 17-18
        //     int codedNumberOfGroups = GribNumbers.uint2(raf);
        //     // octet 19-20
        //     int numberOfSecondOrderPackedValues = GribNumbers.uint2(raf);
        //     // octet 21
        //     int extraValues = raf.ReadByte();
        //     int NG = codedNumberOfGroups + 65536 * extraValues;
        //     
        //     // octet 22
        //     int widthOfWidths = raf.ReadByte();
        //     // octet 23
        //     int widthOfLengths = raf.ReadByte();
        //     // octet 24-25
        //     int NL = GribNumbers.uint2(raf);
        //
        //     // heres how many bits groupWidths should take
        //     int groupWidthsSizeBits = widthOfWidths * NG;
        //     int groupWidthsSizeBytes = (groupWidthsSizeBits + 7) / 8;
        //     int skipBytes = NL - groupWidthsSizeBytes - 26;
        //
        //     SupportClass.Skip(raf, skipBytes);
        //
        //
        //     // from grib_dimp output
        //     // raf.skipBytes(6);
        //     // int widthOfSPD = raf.read();
        //     // int SPD = GribNumbers.int4(raf);
        //     // raf.read();
        //     // raf.read();
        //
        //
        //     // meta groupWidths unsigned_bits(widthOfWidths,numberOfGroups) : read_only;
        //     int[] groupWidth = new int[NG];
        //     for (int group = 0; group < NG; group++)
        //     {
        //         groupWidth[group] = (int)bits2UInt(widthOfWidths, raf);
        //     }
        //
        //     bitPos = 0; // assume on byte boundary
        //
        //     // try forcing to NL
        //     // reader = new BitReader(raf, this.startPos + NL - 1);
        //     
        //     // meta groupLengths unsigned_bits(widthOfLengths,numberOfGroups) : read_only;
        //     int[] groupLength = new int[NG];
        //     for (int group = 0; group < NG; group++)
        //         groupLength[group] = (int)bits2UInt(widthOfLengths, raf);
        //
        //     // meta countOfGroupLengths sum(groupLengths);
        //     int countOfGroupLengths = 0;
        //     for (int group = 0; group < NG; group++)
        //         countOfGroupLengths += groupLength[group];
        //
        //     // try forcing to N1
        //     // reader = new BitReader(raf, this.startPos + N1 - 1);
        //
        //     // First-order descriptors width stored at the equivalent place of bit number for ordinary packing
        //     int foWidth = numbits;
        //
        //     // meta firstOrderValues unsigned_bits(widthOfFirstOrderValues,numberOfGroups) : read_only;
        //     bitPos = 0; // assume on byte boundary
        //     int[] firstOrderValues = new int[NG];
        //     for (int group = 0; group < NG; group++)
        //         firstOrderValues[group] = (int)bits2UInt(foWidth, raf);
        //     int offset3 = (int)(raf.Position - this.startPos);
        //
        //
        //     int total_nbits = 0;
        //     for (int group = 0; group < NG; group++)
        //     {
        //         int nbits = groupLength[group] * groupWidth[group];
        //         total_nbits += nbits;
        //     }
        //
        //     int data_bytes = (total_nbits + 7) / 8;
        //     int simplepackSizeInBits = record.GridDefinitionSection.Npts * numbits;
        //     int simplepackSizeInBytes = (simplepackSizeInBits + 7) / 8;
        //
        //     // meta bitsPerValue second_order_bits_per_value(codedValues,binaryScaleFactor,decimalScaleFactor);
        //     bitPos = 0; // assume on byte boundary
        //     int[] secondOrderValues = new int[countOfGroupLengths];
        //     int countGroups = 0;
        //     try
        //     {
        //         int val1 = 0;
        //         double log2 = Math.Log(2);
        //         for (int group = 0; group < NG; group++)
        //         {
        //             for (int i = 0; i < groupLength[group]; i++)
        //             {
        //                 int secVal = (int)bits2UInt(groupWidth[group], raf);
        //                 secondOrderValues[val1++] = secVal;
        //             }
        //
        //             countGroups++;
        //         }
        //     }
        //     catch (Exception ioe)
        //     {
        //         //logger.warn("Only did {} groups out of {}", countGroups, NG);
        //     }
        //
        //     int offset4 = (int)(raf.Position - record.RecordOffset);
        //
        //
        //     double pow10 = Math.Pow(10.0, -decimalscale);
        //     float reference = (float)(pow10 * refvalue);
        //     float scale = (float)(pow10 * Math.Pow(2.0, binscale));
        //     float[] values = new float[record.GridDefinitionSection.Npts];
        //     int val = 0;
        //     int n = Math.Min(countOfGroupLengths, record.GridDefinitionSection.Npts);
        //     for (int group = 0; group < NG; group++)
        //     {
        //         for (int i = 0; i < groupLength[group]; i++)
        //         {
        //             values[val] = reference + scale * (firstOrderValues[group] + secondOrderValues[val]);
        //             val++;
        //         }
        //     }
        //
        //     // use last average for shortfall
        //     for (int i = countOfGroupLengths; i < record.GridDefinitionSection.Npts; i++)
        //     {
        //         values[val] = reference + scale * firstOrderValues[NG - 1];
        //         val++;
        //     }
        //
        //     scanningModeCheck(values, record.GridDefinitionSection.ScanMode, record.GridDefinitionSection.Nx);
        // }


        /**
   * Rearrange the data array using the scanning mode.
   * LOOK: not handling scanMode generally
   * Flag/Code table 8 – Scanning mode
   * Bit No. Value Meaning
   * 1 0 Points scan in +i direction
   * 1 Points scan in –i direction
   * 2 0 Points scan in –j direction
   * 1 Points scan in +j direction
   * 3 0 Adjacent points in i direction are consecutive
   * 1 Adjacent points in j direction are consecutive
   */
        private void scanningModeCheck(float[] data, int scanMode, int Xlength)
        {
            if (Xlength <= 0) // old code
                return;

            // Mode 0 +x, -y, adjacent x, adjacent rows same dir
            // Mode 64 +x, +y, adjacent x, adjacent rows same dir
            // if ((scanMode == 0) || (scanMode == 64)) {
            // NOOP
            // } else
            if ((scanMode == 128) || (scanMode == 192))
            {
                // Mode 128 -x, -y, adjacent x, adjacent rows same dir
                // Mode 192 -x, +y, adjacent x, adjacent rows same dir
                // change -x to +x ie east to west -> west to east
                int mid = Xlength / 2;
                for (int index = 0; index < data.Length; index += Xlength)
                {
                    for (int idx = 0; idx < mid; idx++)
                    {
                        float tmp = data[index + idx];
                        data[index + idx] = data[index + Xlength - idx - 1];
                        data[index + Xlength - idx - 1] = tmp;
                    }
                }
            }
        }

        private void ReadSimplePacking(Stream raf, int decimalscale, Grib1BitMapSection bms, float refvalue,
            int binscale,
            int numbits, int unusedbits)
        {
            float ref_Renamed = (float)(Math.Pow(10.0, -decimalscale) * refvalue);
            //UPGRADE_WARNING: Data types in Visual C# might be different.  Verify the accuracy of narrowing conversions. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1042'"
            float scale = (float)(Math.Pow(10.0, -decimalscale) * Math.Pow(2.0, binscale));

            if (bms != null)
            {
                bool[] bitmap = bms.Bitmap;

                Values = new float[bitmap.Length];
                for (int i = 0; i < bitmap.Length; i++)
                {
                    if (bitmap[i])
                    {
                        if (!isConstant)
                        {
                            Values[i] = ref_Renamed + scale * bits2UInt(numbits, raf);
                        }
                        else
                        {
                            // rdg - added this to handle a constant valued parameter
                            Values[i] = ref_Renamed;
                        }
                    }
                    else
                        Values[i] = MissingValue;
                }
            }
            else
            {
                // bms is null
                if (!isConstant)
                {
                    //(((length - 11) * 8 - unusedbits) /  numbits));
                    Values = new float[((length - 11) * 8 - unusedbits) / numbits];

                    for (int i = 0; i < Values.Length; i++)
                    {
                        Values[i] = ref_Renamed + scale * bits2UInt(numbits, raf);
                    }
                }
                else
                {
                    // constant valued - same min and max
                    int x = 0, y = 0;
                    raf.Seek(raf.Position - 53, System.IO.SeekOrigin.Begin); // return to start of GDS
                    length = (int)GribNumbers.uint3(raf);
                    if (length == 42)
                    {
                        // Lambert/Mercator offset
                        SupportClass.Skip(raf, 3);
                        x = GribNumbers.int2(raf);
                        y = GribNumbers.int2(raf);
                    }
                    else
                    {
                        SupportClass.Skip(raf, 7);
                        length = (int)GribNumbers.uint3(raf);
                        if (length == 32)
                        {
                            // Polar sterographic
                            SupportClass.Skip(raf, 3);
                            x = GribNumbers.int2(raf);
                            y = GribNumbers.int2(raf);
                        }
                        else
                        {
                            x = y = 1;
                            Console.Out.WriteLine("BDS constant value, can't determine array size");
                        }
                    }

                    Values = new float[x * y];
                    for (int i = 0; i < Values.Length; i++)
                        Values[i] = ref_Renamed;
                }
            }
        }
        // end Grib1BinaryDataSection

        /// <summary> Convert bits (nb) to Unsigned Int .
        /// 
        /// </summary>
        /// <param name="nb">
        /// </param>
        /// <param name="raf">
        /// </param>
        /// <returns> int of BinaryDataSection section
        /// </returns>
        //UPGRADE_TODO: Class 'java.io.RandomAccessFile' was converted to 'System.IO.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioRandomAccessFile'"
        private int bits2UInt(int nb, System.IO.Stream raf)
        {
            int bitsLeft = nb;
            int result = 0;

            if (bitPos == 0)
            {
                bitBuf = raf.ReadByte();
                bitPos = 8;
            }

            while (true)
            {
                int shift = bitsLeft - bitPos;
                if (shift > 0)
                {
                    // Consume the entire buffer
                    result |= bitBuf << shift;
                    bitsLeft -= bitPos;

                    // Get the next byte from the RandomAccessFile
                    bitBuf = raf.ReadByte();
                    bitPos = 8;
                }
                else
                {
                    // Consume a portion of the buffer
                    result |= bitBuf >> -shift;
                    bitPos -= bitsLeft;
                    bitBuf &= 0xff >> (8 - bitPos); // mask off consumed bits

                    return result;
                }
            } // end while
        } // end bits2Int

        // *** public methods ****************************************************

        // --Commented out by Inspection START (11/17/05 1:25 PM):
        //   /**
        //    * Get the length in bytes of this section.
        //    *
        //    * @return length in bytes of this section
        //    */
        //   public int getLength()
        //   {
        //      return length;
        //   }
        // --Commented out by Inspection STOP (11/17/05 1:25 PM)
    } // end class Grib1BinaryDataSection
}