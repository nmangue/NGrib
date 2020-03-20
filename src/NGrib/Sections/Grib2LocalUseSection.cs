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

namespace NGrib.Sections
{
	
	/// <summary> A class that represents the local use section (LUS) of a GRIB product.
	/// 
	/// </summary>
	public sealed class Grib2LocalUseSection : IGrib2LocalUseSection
	{
		
		/// <summary> Length in bytes of this section.</summary>
		//UPGRADE_NOTE: Final was removed from the declaration of 'length '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private readonly int length;
		
		/// <summary> section number should be 2.</summary>
		//UPGRADE_NOTE: Final was removed from the declaration of 'section '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private readonly int section;

        private readonly byte[] bytes;
		
		// *** constructors *******************************************************
		
		/// <summary> Constructs a <tt>Grib2LocalUseSection</tt> object from a raf.</summary>
		/// <param name="raf">
		/// </param>
		/// <throws>  IOException  if raf contains no valid GRIB product </throws>
		//UPGRADE_TODO: Class 'java.io.RandomAccessFile' was converted to 'System.IO.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioRandomAccessFile'"
		public Grib2LocalUseSection(FileStream raf)
		{
			
			// octets 1-4 (Length of GDS)
			length = GribNumbers.int4(raf);
			//System.out.println( "LUS length=" + length );
			
			section = raf.ReadByte(); // This is section 2
			//System.out.println( "LUS Local Use is 2, section=" + section );
			
			if (section != 2)
			{
				// no local use section
				SupportClass.Skip(raf, - 5);
				return ;
			}
			else
			{
				//SupportClass.Skip(raf, length - 5);
                bytes = new byte[length - 5];
                int nb = raf.Read(bytes, 0, length - 5);
                if (nb != length - 5)
                {
                    throw new NoValidGribException("Failed to read Local Use Section data");
                }
			}
		} // end of Grib2LocalUseSection
		
		// *** public methods *****************************************************
		

	   /**
	    * Get length in bytes of this section.
	    *
	    * @return length in bytes of this section
	   */
	   public int getLength()
	   {
	      return length;
	   }

       public byte[] getBytes()
       {
           return bytes;
       }

	   /**
	    * Number of this section, should be 3
	    */
	   public int getSection()
	   {
	      return section;
	   }

	} // end Grib2LocalUseSection
}