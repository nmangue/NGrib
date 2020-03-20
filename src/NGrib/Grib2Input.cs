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
using NGrib.Sections;

namespace NGrib
{
	
	/// <summary> A class that scans a GRIB2 file stream to extract product information. </summary>
	public sealed class Grib2Input : IGrib2Input
	{
		/// <summary> returns Grib file type, 1 or 2, or 0 not a Grib file.</summary>
		/// <returns> GribFileType
		/// </returns>
		/// <throws>  IOException </throws>
		/// <throws>  NotSupportedException </throws>
		public int Edition
		{
			get
			{
				long length = (raf.Length < 4000L)?raf.Length:4000L;
				if (!seekHeader(raf, length))
				{
					return 0; // not valid Grib file
				}
				//  Read Section 0 Indicator Section to get Edition number
				Grib2IndicatorSection indicatorSec = new Grib2IndicatorSection(raf); // section 0
                return indicatorSec.GribEdition;
			}
			// end getEdition
			
		}
		/// <summary> Get products of the GRIB file.
		/// 
		/// </summary>
		/// <returns> products 
		/// </returns>
		public System.Collections.ArrayList Products
		{
			get
			{
				return products;
			}
			
		}
		/// <summary> Get records of the GRIB file.
		/// 
		/// </summary>
		/// <returns> records 
		/// </returns>
		public System.Collections.ArrayList Records
		{
			get
			{
				return records;
			}
			
		}
		/// <summary> Get GDS's of the GRIB file.
		/// 
		/// </summary>
		/// <returns> gdsHM 
		/// </returns>
		//UPGRADE_TODO: Class 'java.util.HashMap' was converted to 'System.Collections.Hashtable' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilHashMap'"
		public System.Collections.Hashtable GDSs
		{
			get
			{
				return gdsHM;
			}
			
		}

        public int ProductsCount 
        { 
            get
            {
                return products.Count;
            }
        }
        public int RecordsCount
        {
            get
            {
                return records.Count;
            }
        }

		/*
		*  /ucar/unidata/io/RandomAccessFile 
		*/
		//UPGRADE_TODO: Class 'java.io.RandomAccessFile' was converted to 'System.IO.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioRandomAccessFile'"
		private System.IO.FileStream raf = null;
		
		/*
		* the WMO header of a record
		*/
		private System.String header = "GRIB";
		
		/// <summary> Pattern to extract header.</summary>
		//UPGRADE_NOTE: Final was removed from the declaration of 'productID '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		//private static readonly Pattern productID = Pattern.compile("(\\w{6} \\w{4} \\d{6})");
		
		/*
		* stores record sections: header, is, id, gds, pds, drs, bms and
		* GdsOffset and PdsOffsets. used to return data of record 
		*/
		//UPGRADE_NOTE: Final was removed from the declaration of 'records '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private System.Collections.ArrayList records = new System.Collections.ArrayList();
		
		/*
		* stores header, is, id, GDSkey , pds, GdsOffset, PdsOffset 
		* of the record. a product supplies enough information to extract the
		* data of the record. used in creating Grib file indexes 
		*/
		//UPGRADE_NOTE: Final was removed from the declaration of 'products '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private System.Collections.ArrayList products = new System.Collections.ArrayList();
		
		/*
		* stores all different GDSs of Grib2 file, there is possibility of more than 1
		*/
		//UPGRADE_NOTE: Final was removed from the declaration of 'gdsHM '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		//UPGRADE_TODO: Class 'java.util.HashMap' was converted to 'System.Collections.Hashtable' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilHashMap'"
		private System.Collections.Hashtable gdsHM = new System.Collections.Hashtable();
		
		// *** constructors *******************************************************
		
		/// <summary> Constructs a Grib2Input object from a raf.
		/// 
		/// </summary>
		/// <param name="raf">with GRIB content
		/// 
		/// </param>
		//UPGRADE_TODO: Class 'java.io.RandomAccessFile' was converted to 'System.IO.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioRandomAccessFile'"
		public Grib2Input(System.IO.FileStream raf)
		{
			this.raf = raf;
		}

        public Grib2Input()
        {
        }

        public void setFilename(string filename)
        {
            this.raf = new System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read );
        }

        public void closeFile()
        {
            this.raf.Close();
        }
		
		/// <summary> scans the Grib2 file obtaining Products or Records that contain all 
		/// needed information for data extraction later. For most purposes, 
		/// getProductsOnly should be set to true, it's lightweight of getRecords.
		/// </summary>
		/// <param name="getProductsOnly">
		/// </param>
		/// <param name="oneRecord">
		/// </param>
		/// <returns> success
		/// </returns>
		/// <throws>  NotSupportedException </throws>
		/// <throws>  IOException </throws>
		public bool scan(bool getProductsOnly, bool oneRecord)
		{
            if (raf == null)
            {
                throw new ApplicationException("Grib2Input.scan called without file");
            }

			long start = (System.DateTime.Now.Ticks - 621355968000000000) / 10000;
			
			Grib2IndicatorSection is_Renamed = null;
			Grib2IdentificationSection id = null;
			Grib2LocalUseSection lus = null;
			Grib2GridDefinitionSection gds = null;
			// if raf.getFilePointer() != 0 then called from Grib2IndexExtender
			if (raf.Position > 4)
			{
				raf.Seek(raf.Position - 4, System.IO.SeekOrigin.Begin);
				Grib2EndSection es = new Grib2EndSection(raf);
				if (!es.EndFound)
				{
					// ending found somewhere in file
                    throw new NoValidGribException("Grib2Input.scan failed to find end of record");
				}
				//System.out.println( "Scan succeeded to find end of record");
			}
			//System.out.println("Scan file pointer =" + raf.getFilePointer()); 
			long GdsOffset = 0; // GDS offset from start of file
			bool startAtHeader = true; // otherwise skip to GDS
			bool processGDS = true;
			while (raf.Position < raf.Length)
			{
				if (startAtHeader)
				{
					// begining of record
					if (!seekHeader(raf, raf.Length))
					{
						//System.out.println( "Scan seekHeader failed" );
                        throw new NoValidGribException("Grib2Input.scan failed to find header");
					}
					
					// Read Section 0 Indicator Section
					is_Renamed = new Grib2IndicatorSection(raf); // section 0
					//System.out.println( "Grib record length=" + is.getGribLength());
					
					// Read other Sections
					id = new Grib2IdentificationSection(raf); // Section 1
				} // end startAtHeader
				if (processGDS)
				{
					// check for Local Use Section 2
					lus = new Grib2LocalUseSection(raf);
					
					// obtain GDS offset in the file for this record
					GdsOffset = raf.Position;
					
					// Section 3
					gds = new Grib2GridDefinitionSection(raf, getProductsOnly);
					//System.out.println( "GDS length=" + gds.getLength() );
				} // end processGDS
				
				// obtain PDS offset in the file for this record
				long PdsOffset = raf.Position;
				
				Grib2ProductDefinitionSection pds = new Grib2ProductDefinitionSection(raf); // Section 4
				
				Grib2DataRepresentationSection drs = null;
				Grib2BitMapSection bms = null;
				Grib2DataSection ds = null;
				drs = new Grib2DataRepresentationSection(raf); // Section 5
				
				bms = new Grib2BitMapSection(raf, gds); // Section 6
				
				//ds =  new Grib2DataSection( getData, raf, gds, drs, bms ); //Section 7
				ds = new Grib2DataSection(false, raf, gds, drs, bms); //Section 7
				
				// assume scan ok
				if (getProductsOnly)
				{
					Grib2Product gp = new Grib2Product(header, is_Renamed, id, getGDSkey(gds), pds, GdsOffset, PdsOffset);
					products.Add(gp);
				}
				else
				{
					Grib2Record gr = new Grib2Record(header, is_Renamed, id, gds, pds, drs, bms, GdsOffset, PdsOffset, lus);
					records.Add(gr);
				}
				if (oneRecord)
					return true;
				
				// early return because ending "7777" missing
				if (raf.Position > raf.Length)
				{
					raf.Seek(0, System.IO.SeekOrigin.Begin);
					return true;
				}
				
				// EndSection processing section 8
				int ending = GribNumbers.int4(raf);
				//System.out.println( "ending = " + ending );
				if (ending == 926365495)
				{
					// record ending string 7777 as a number
					startAtHeader = true;
					processGDS = true;
				}
				else
				{
					int section = raf.ReadByte(); // check if GDS or PDS section, 3 or 4
					//System.out.println( "section = " + section );
					//reset back to begining of section
					raf.Seek(raf.Position - 5, System.IO.SeekOrigin.Begin);
					
					if (section == 3)
					{
						// start processing at GDS 
						startAtHeader = false;
						processGDS = true;
					}
					else if (section == 4)
					{
						// start processing at PDS
						startAtHeader = false;
						processGDS = false;
					}
					else
					{
						// error
						Grib2EndSection es = new Grib2EndSection(raf);
						if (es.EndFound)
						{
							// ending found somewhere in file
							startAtHeader = true;
							processGDS = true;
						}
						else
						{
							//System.err.println( "Grib2Input: possible file corruption");
                            throw new NoValidGribException("Grib2Input.scan failed to find end of record");
						}
					}
				}
				//System.out.println( "raf.getFilePointer=" + raf.getFilePointer() );
				//System.out.println( "raf.length()=" + raf.length() );
			} // end raf.getFilePointer() < raf.length()
			//System.out.println("GribInput: processed in " +
			//   (System.currentTimeMillis()- start) + " milliseconds");
			return true;
		} // end scan

        public IGrib2Record GetRecord(int idx)
        {
            if (idx < 0 || idx >= records.Count)
            {
                throw new IndexOutOfRangeException();
            }
            return records[idx] as Grib2Record;
        }

        public IGrib2Product GetProduct(int idx)
        {
            if (idx < 0 || idx >= products.Count)
            {
                throw new IndexOutOfRangeException();
            }
            return products[idx] as Grib2Product;
        }


		private bool seekHeader(System.IO.FileStream raf, long stop)
		{
			// seek header
			System.Text.StringBuilder hdr = new System.Text.StringBuilder();
			int match = 0;
            while (raf.Position < stop)
			{
				// code must be "G" "R" "I" "B"
				sbyte c = (sbyte) raf.ReadByte();
				if (c < 0)
                    c = (sbyte)' '; //Changed to work with new header, why does this row exist at all?
				
				hdr.Append((char) c);
				if (c == 'G')
				{
					match = 1;
				}
				else if ((c == 'R') && (match == 1))
				{
					match = 2;
				}
				else if ((c == 'I') && (match == 2))
				{
					match = 3;
				}
				else if ((c == 'B') && (match == 3))
				{
					return true;
				}
				else
				{
					match = 0; /* Needed to protect against "GaRaIaB" case. */
				}
			}
			return false;
		} // end seekHeader
		
		private System.String getGDSkey(Grib2GridDefinitionSection gds)
		{
			
			System.String key = gds.CheckSum;
			if (!gdsHM.ContainsKey(key))
			{
				// check if gds is already saved
				gdsHM[key] = gds;
			}
			return key;
		} // end getGDSkey
	} // end Grib2Input
}