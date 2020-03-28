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

using System.IO;

namespace NGrib.Grib2.Sections
{
	/// <summary> A class that represents the EndSection of a GRIB2 product.
	/// 
	/// </summary>
	public sealed class Grib2EndSection
	{
		public long Length { get; }
		public int Section { get; }

		/// <summary> Get ending flag for Grib record.
		/// 
		/// </summary>
		/// <returns> true if  "7777" found
		/// </returns>
		public bool EndFound
		{
			get;

			// --Commented out by Inspection START (11/21/05 12:32 PM):
			//   /*
			//    * how long was the ending, should be 4 bytes
			//   */
			//   public final int getLength()
			//   {
			//      return length;
			//   }
			// --Commented out by Inspection STOP (11/21/05 12:32 PM)
		}

		/*
		* was the grib endding 7777 found
		*/

		/*
		* how long was the ending, should be 4 bytes
		*/
		private int length = 0;

		// *** constructors *******************************************************

		/// <summary> Constructs a <tt>Grib2EndSection</tt> object from a byteBuffer.
		/// 
		/// </summary>
		/// <param name="raf">RandomAccessFile with EndSection content
		/// 
		/// </param>
		/// <throws>  IOException  if raf contains no valid GRIB record </throws>
		//UPGRADE_TODO: Class 'java.io.RandomAccessFile' was converted to 'System.IO.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioRandomAccessFile'"
		public Grib2EndSection(FileStream raf)
		{
			int match = 0;
			while (raf.Position < raf.Length)
			{
				// code must be "7" "7" "7" "7"
				sbyte c = (sbyte) raf.ReadByte();

				length++;
				if (c == '7')
				{
					match += 1;
				}
				else
				{
					match = 0; /* Needed to protect against bad ending case. */
				}

				if (match == 4)
				{
					EndFound = true;

					break;
				}
			}
		} // end Grib2EndSection

		private Grib2EndSection(long length, int section)
		{
			Length = length;
			Section = section;
		}

		internal static Grib2EndSection BuildFrom(BufferedBinaryReader reader)
		{
			var sectionInfos = reader.ReadSectionInfo();
			if (!sectionInfos.Is(SectionCode.EndSection))
			{
				throw new NoValidGribException("");
			}

			return new Grib2EndSection(sectionInfos.Length, sectionInfos.SectionCode);
		}

	} // end Grib2EndSection
}