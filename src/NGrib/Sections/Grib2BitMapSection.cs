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
using System.IO;

namespace NGrib.Sections
{
	/// <summary> A class that represents the BitMapSection of a GRIB product.
	/// 
	/// </summary>
	public sealed class Grib2BitMapSection
	{
		/// <summary> Get bit map.
		/// 
		/// </summary>
		/// <returns> bit map as array of boolean values
		/// </returns>
		public bool[] Bitmap { get; }

		/// <summary> Length in bytes of BitMapSection section.</summary>
		//UPGRADE_NOTE: Final was removed from the declaration of 'length '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private readonly long length;

		/// <summary> Number of this section, should be 6.</summary>
		//UPGRADE_NOTE: Final was removed from the declaration of 'section '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private int section;

		/// <summary> Bit-map indicator (see Code Table 6.0 and Note (1))</summary>
		//UPGRADE_NOTE: Final was removed from the declaration of 'bitMapIndicator '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private readonly int bitMapIndicator;

		// *** constructors *******************************************************

		/// <summary> Constructs a <tt>Grib2BitMapSection</tt> object from a byteBuffer.
		/// 
		/// </summary>
		/// <param name="raf">RandomAccessFile with Section BMS content
		/// </param>
		/// <param name="gds">Grib2GridDefinitionSection
		/// </param>
		/// <throws>  IOException  if stream contains no valid GRIB file </throws>
		//UPGRADE_TODO: Class 'java.io.RandomAccessFile' was converted to 'System.IO.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioRandomAccessFile'"
		public Grib2BitMapSection(FileStream raf, Grib2GridDefinitionSection gds)
		{
			int[] bitmask = new int[] {128, 64, 32, 16, 8, 4, 2, 1};

			// octets 1-4 (Length of BMS)
			length = GribNumbers.int4(raf);

			section = raf.ReadByte();

			bitMapIndicator = raf.ReadByte();

			// no bitMap
			if (bitMapIndicator != 0)
				return;

			sbyte[] data = new sbyte[length - 6];
			SupportClass.ReadInput(raf, data, 0, data.Length);

			// create new bit map, octet 4 contains number of unused bits at the end
			Bitmap = new bool[gds.NumberPoints];

			// fill bit map
			for (int i = 0; i < Bitmap.Length; i++)
				Bitmap[i] = (data[i / 8] & bitmask[i % 8]) != 0;
		}


        internal Grib2BitMapSection(long length, int section, bool[] bitmap)
        {
            this.length = length;
            this.section = section;
            Bitmap = bitmap;
        }
        /// <summary> Constructs a <tt>Grib2BitMapSection</tt> object from a byteBuffer.
        /// 
        /// </summary>
        /// <param name="raf">RandomAccessFile with Section BMS content
        /// </param>
        /// <param name="gds">Grib2GridDefinitionSection
        /// </param>
        /// <throws>  IOException  if stream contains no valid GRIB file </throws>
        internal Grib2BitMapSection(BufferedBinaryReader raf, long numberPoints)
        {
            length = raf.ReadUInt32();

            section = raf.ReadUInt8();

            bitMapIndicator = raf.ReadUInt8();
            
            Bitmap = new bool[numberPoints];
            if (bitMapIndicator == 0)
			{
				// create new bit map, octet 4 contains number of unused bits at the end
                
                var i = 0;
                while (i < Bitmap.Length)
                {
                    var bitmap = (Bitmask) raf.ReadByte();

                    Bitmap[i++] = bitmap.HasFlag(Bitmask.Bit1);
                    Bitmap[i++] = bitmap.HasFlag(Bitmask.Bit2);
                    Bitmap[i++] = bitmap.HasFlag(Bitmask.Bit3);
                    Bitmap[i++] = bitmap.HasFlag(Bitmask.Bit4);
                    Bitmap[i++] = bitmap.HasFlag(Bitmask.Bit5);
                    Bitmap[i++] = bitmap.HasFlag(Bitmask.Bit6);
                    Bitmap[i++] = bitmap.HasFlag(Bitmask.Bit7);
                    Bitmap[i++] = bitmap.HasFlag(Bitmask.Bit8);
                }
            }
            else
            {
                for (int i = 0; i < Bitmap.Length; i++)
                {
                    Bitmap[i] = true;
                }
            }
        }

        [Flags]
        private enum Bitmask : byte
        {
            Bit1 = 1 << 7,
            Bit2 = 1 << 6,
            Bit3 = 1 << 5,
            Bit4 = 1 << 4,
            Bit5 = 1 << 3,
            Bit6 = 1 << 2,
            Bit7 = 1 << 1,
            Bit8 = 1,
        }
    }
}