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

namespace NGrib.Grib1
{
	/// <summary> Title:        Grib1
	/// Description:  Class which has the necessary information about
	/// a product in a Grib1 File to extract the data for the product.
	/// </summary>
	/// <author>  Robb Kambic  
	/// </author>
	/// <version>  1.0
	/// </version>
	public sealed class Grib1Product
	{
		/// <summary> get the discipline of product as int.</summary>
		/// <returns> discipline
		/// </returns>
		public int Discipline
		{
			get { return discipline; }
		}

		/// <summary> get category of this product as int.</summary>
		/// <returns> category as a int
		/// </returns>
		public int Category
		{
			get { return category; }
		}

		//UPGRADE_NOTE: Respective javadoc comments were merged.  It should be changed in order to comply with .NET documentation conventions. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1199'"
		/// <summary> gets GDS key for this product.</summary>
		/// <returns> gdsKey
		/// </returns>
		/// <summary> sets the GDS key for this product.</summary>
		/// <param name="aGDSkey"> MD5 checksum as text
		/// </param>
		public System.String GDSkey
		{
			get { return gdsKey; }

			set { gdsKey = value; }
		}

		/// <summary> get the PDS for this product.</summary>
		/// <returns> pds
		/// </returns>
		public Grib1ProductDefinitionSection PDS
		{
			get { return pds; }
		}

		/// <summary> offset to where to start reading data for this product.</summary>
		/// <returns> dataOffset
		/// </returns>
		public long DataOffset
		{
			get { return dataOffset; }
		}

		/// <summary> where this record ends in the Grib File.</summary>
		/// <returns> endRecordOffset
		/// </returns>
		public long EndRecordOffset
		{
			get { return endRecordOffset; }
		}

		//UPGRADE_NOTE: Final was removed from the declaration of 'header '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private System.String header;

		//UPGRADE_NOTE: Final was removed from the declaration of 'discipline '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private int discipline = 0;

		//UPGRADE_NOTE: Final was removed from the declaration of 'category '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private int category = -1;

		// --Commented out by Inspection (11/17/05 2:14 PM): protected Grib1IndicatorSection is = null;
		private Grib1ProductDefinitionSection pds;
		private System.String gdsKey;
		private long dataOffset = -1;
		private long endRecordOffset = -1;

		/// <summary> Constructor.</summary>
		/// <param name="header">
		/// </param>
		/// <param name="pds">
		/// </param>
		/// <param name="gdsKey">
		/// </param>
		/// <param name="offset">
		/// </param>
		/// <param name="size">endRecordOffset in file
		/// </param>
		internal Grib1Product(System.String header, Grib1ProductDefinitionSection pds, System.String gdsKey, long offset, long size)
		{
			this.header = header;
			this.gdsKey = gdsKey;
			this.pds = pds;
			dataOffset = offset;
			endRecordOffset = size;
		}

		// --Commented out by Inspection START (11/17/05 2:15 PM):
		//   public final String getHeader(){
		//      return header;
		//   }
		// --Commented out by Inspection STOP (11/17/05 2:15 PM)
	} // end Grib1Product
}