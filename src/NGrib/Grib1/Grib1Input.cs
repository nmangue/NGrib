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
using System.IO;

namespace NGrib.Grib1
{
	/// <summary> A class that scans a GRIB file to extract product information. </summary>
	public sealed class Grib1Input
	{
		/// <summary> Grib edition number 1, 2 or 0 not a Grib file.</summary>
		/// <throws>  NotSupportedException </throws>
		/// <returns> int 0 not a Grib file, 1 Grib1, 2 Grib2
		/// </returns>
		public int Edition
		{
			get
			{
				long length = (InputStream.Length < 4000L) ? InputStream.Length : 4000L;
				if (!seekHeader(InputStream, length))
				{
					return 0; // not valid Grib file
				}

				//  Read Section 0 Indicator Section to get Edition number
				Grib1IndicatorSection is_Renamed = new Grib1IndicatorSection(InputStream); // section 0
				return is_Renamed.GribEdition;
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
			get { return products; }
		}

		/// <summary> Get records of the GRIB file.
		/// 
		/// </summary>
		/// <returns> records 
		/// </returns>
		public IReadOnlyList<Grib1Record> Records => records;

		/// <summary> Get GDS's of the GRIB file.
		/// 
		/// </summary>
		/// <returns> gdsHM 
		/// </returns>
		//UPGRADE_TODO: Class 'java.util.HashMap' was converted to 'System.Collections.Hashtable' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilHashMap'"
		public System.Collections.Hashtable GDSs
		{
			get { return gdsHM; }
		}

		public int ProductsCount
		{
			get { return products.Count; }
		}

		public int RecordsCount
		{
			get { return records.Count; }
		}

		/*
		* raf for grib file
		*/
		internal Stream InputStream { get; private set; }

		/*
		* the header of Grib record
		*/
		private String header = "GRIB";

		/*
		* stores records of Grib file, records consist of objects for each section.
		* there are 5 sections to a Grib1 record.
		*/
		//UPGRADE_NOTE: Final was removed from the declaration of 'records '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private List<Grib1Record> records = new List<Grib1Record>();

		/*
		* stores products of Grib file, products have enough info to get the
		* metadata about a parameter and the data. products are lightweight
		* records. 
		*/
		//UPGRADE_NOTE: Final was removed from the declaration of 'products '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private System.Collections.ArrayList products = new System.Collections.ArrayList();

		/*
		* stores GDS of Grib1 file, there is possibility of more than 1
		*/
		//UPGRADE_NOTE: Final was removed from the declaration of 'gdsHM '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		//UPGRADE_TODO: Class 'java.util.HashMap' was converted to 'System.Collections.Hashtable' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilHashMap'"
		private System.Collections.Hashtable gdsHM = new System.Collections.Hashtable();

		// *** constructors *******************************************************

		/// <summary> Constructs a <tt>Grib1Input</tt> object from a raf.
		/// 
		/// </summary>
		/// <param name="raf">with GRIB content
		/// 
		/// </param>
		//UPGRADE_TODO: Class 'java.io.RandomAccessFile' was converted to 'System.IO.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioRandomAccessFile'"
		public Grib1Input(System.IO.Stream raf)
		{
			this.InputStream = raf;
		}

		public Grib1Input()
		{
		}

		/// <summary> scans a Grib file to gather information that could be used to
		/// create an index or dump the metadata contents.
		/// 
		/// </summary>
		/// <param name="getProducts">products have enough information for data extractions
		/// </param>
		/// <param name="oneRecord">returns after processing one record in the Grib file
		/// </param>
		/// <throws>  NotSupportedException </throws>
		public void scan(bool getProducts, bool oneRecord)
		{
			long start = (DateTime.Now.Ticks - 621355968000000000) / 10000;
			// stores the number of times a particular GDS is used
			//UPGRADE_TODO: Class 'java.util.HashMap' was converted to 'System.Collections.Hashtable' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilHashMap'"
			System.Collections.Hashtable gdsCounter = new System.Collections.Hashtable();
			Grib1ProductDefinitionSection pds = null;
			Grib1GridDefinitionSection gds = null;
			long startOffset = -1;


			while (InputStream.Position < InputStream.Length)
			{
				if (seekHeader(InputStream, InputStream.Length, out startOffset))
				{
					// Read Section 0 Indicator Section
					Grib1IndicatorSection is_Renamed = new Grib1IndicatorSection(InputStream);

					// EOR (EndOfRecord) calculated so skipping data sections is faster
					long EOR = InputStream.Position + is_Renamed.GribLength - is_Renamed.Length;

					// Read Section 1 Product Definition Section PDS
					pds = new Grib1ProductDefinitionSection(InputStream);
					if (pds.LengthErr)
						continue;

					if (pds.gdsExists())
					{
						// Read Section 2 Grid Definition Section GDS
						gds = new Grib1GridDefinitionSection(InputStream);
					}
					else
					{
						// GDS doesn't exist so make one



						gds = (Grib1GridDefinitionSection) new Grib1Grid(pds);
					}

					// obtain BMS or BDS offset in the file for this product
					long dataOffset = 0;
					if (pds.Center == 98)
					{
						// check for ecmwf offset by 1 bug
						int length = (int) GribNumbers.uint3(InputStream); // should be length of BMS
						if ((length + InputStream.Position) < EOR)
						{
							dataOffset = InputStream.Position - 3; // ok
						}
						else
						{
							dataOffset = InputStream.Position - 2;
						}
					}
					else
					{
						dataOffset = InputStream.Position;
					}

					// position filePointer to EndOfRecord
					InputStream.Seek(EOR, System.IO.SeekOrigin.Begin);


					// assume scan ok
					if (getProducts)
					{
						Grib1Product gp = new Grib1Product(header, pds, getGDSkey(gds, gdsCounter), dataOffset, InputStream.Position);
						products.Add(gp);
					}
					else
					{
						Grib1Record gr = new Grib1Record(header, is_Renamed, pds, gds, dataOffset, InputStream.Position, startOffset);
						records.Add(gr);
					}

					if (oneRecord)
						return;

					// early return because ending "7777" missing
					if (InputStream.Position > InputStream.Length)
					{
						InputStream.Seek(0, System.IO.SeekOrigin.Begin);
						Console.Error.WriteLine("Grib1Input: possible file corruption");
						checkGDSkeys(gds, gdsCounter);
						return;
					}
				} // end if seekHeader



			} // end while raf.Position < raf.Length


			//   (System.currentTimeMillis()- start) + " milliseconds");
			checkGDSkeys(gds, gdsCounter);
			return;
		} // end scan

		/// <summary> scans a Grib file to gather information that could be used to
		/// create an index or dump the metadata contents.
		/// 
		/// </summary>
		/// <param name="getProducts">products have enough information for data extractions
		/// </param>
		/// <param name="oneRecord">returns after processing one record in the Grib file
		/// </param>
		/// <throws>  NotSupportedException </throws>
		public IEnumerable<Grib1Record> scanRecords()
		{
			InputStream.Seek(0, SeekOrigin.Begin);

			// stores the number of times a particular GDS is used
			//UPGRADE_TODO: Class 'java.util.HashMap' was converted to 'System.Collections.Hashtable' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilHashMap'"
			System.Collections.Hashtable gdsCounter = new System.Collections.Hashtable();
			Grib1ProductDefinitionSection pds = null;
			Grib1GridDefinitionSection gds = null;
			long startOffset = -1;


			while (InputStream.Position < InputStream.Length)
			{
				if (seekHeader(InputStream, InputStream.Length, out startOffset))
				{
					// Read Section 0 Indicator Section
					Grib1IndicatorSection is_Renamed = new Grib1IndicatorSection(InputStream);

					// EOR (EndOfRecord) calculated so skipping data sections is faster
					long EOR = InputStream.Position + is_Renamed.GribLength - is_Renamed.Length;

					// Read Section 1 Product Definition Section PDS
					pds = new Grib1ProductDefinitionSection(InputStream);
					if (pds.LengthErr)
						continue;

					if (pds.gdsExists())
					{
						// Read Section 2 Grid Definition Section GDS
						gds = new Grib1GridDefinitionSection(InputStream);
					}
					else
					{
						// GDS doesn't exist so make one



						gds = (Grib1GridDefinitionSection)new Grib1Grid(pds);
					}

					// obtain BMS or BDS offset in the file for this product
					long dataOffset;
					if (pds.Center == 98)
					{
						// check for ecmwf offset by 1 bug
						int length = (int)GribNumbers.uint3(InputStream); // should be length of BMS
						if ((length + InputStream.Position) < EOR)
						{
							dataOffset = InputStream.Position - 3; // ok
						}
						else
						{
							dataOffset = InputStream.Position - 2;
						}
					}
					else
					{
						dataOffset = InputStream.Position;
					}

					// position filePointer to EndOfRecord
					InputStream.Seek(EOR, System.IO.SeekOrigin.Begin);


					// assume scan ok
					Grib1Record gr = new Grib1Record(header, is_Renamed, pds, gds, dataOffset, InputStream.Position, startOffset);

					var currentPosition = InputStream.Position;
					yield return gr;
					InputStream.Position = currentPosition;

					// early return because ending "7777" missing
					if (InputStream.Position > InputStream.Length)
					{
						InputStream.Seek(0, System.IO.SeekOrigin.Begin);
						checkGDSkeys(gds, gdsCounter);
						throw new BadGribFormatException("Grib1Input: GRIB ending missing. Possible file corruption");
					}
				} // end if seekHeader
			} // end while raf.Position < raf.Length

			checkGDSkeys(gds, gdsCounter);
		} // end scan

		//UPGRADE_TODO: Class 'java.io.RandomAccessFile' was converted to 'System.IO.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioRandomAccessFile'"
		private bool seekHeader(System.IO.Stream raf, long stop, out long startOffset)
		{
			// seek header
			System.Text.StringBuilder hdr = new System.Text.StringBuilder();
			int match = 0;
			startOffset = -1;

			while (raf.Position < stop)
			{
				// code must be "G" "R" "I" "B"
				char c = (char) raf.ReadByte();

				hdr.Append((char) c);
				if (c == 'G')
				{
					match = 1;
					startOffset = raf.Position - 1;
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

		private bool seekHeader(System.IO.Stream raf, long stop)
		{
			long startOffsetDummy = -1;
			return seekHeader(raf, stop, out startOffsetDummy);
		}

		//UPGRADE_TODO: Class 'java.util.HashMap' was converted to 'System.Collections.Hashtable' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilHashMap'"
		private String getGDSkey(Grib1GridDefinitionSection gds, System.Collections.Hashtable gdsCounter)
		{
			String key = gds.CheckSum;
			// only Lat/Lon grids can have > 1 GDSs
			if (gds.GridType == 0 || gds.GridType == 4)
			{
				if (!gdsHM.ContainsKey(key))
				{
					// check if gds is already saved
					gdsHM[key] = gds;
				}
			}
			else if (!gdsHM.ContainsKey(key))
			{
				// check if gds is already saved
				gdsHM[key] = gds;
				gdsCounter[key] = "1";
			}
			else
			{
				// increment the counter for this GDS
				//UPGRADE_TODO: Method 'java.util.HashMap.get' was converted to 'System.Collections.Hashtable.Item' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilHashMapget_javalangObject'"
				int count = Int32.Parse((String) gdsCounter[key]);
				gdsCounter[key] = Convert.ToString(++count);
			}

			return key;
		} // end getGDSkey

		//UPGRADE_TODO: Class 'java.util.HashMap' was converted to 'System.Collections.Hashtable' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilHashMap'"
		private void checkGDSkeys(Grib1GridDefinitionSection gds, System.Collections.Hashtable gdsCounter)
		{
			// lat/lon grids can have > 1 GDSs
			if (gds.GridType == 0 || gds.GridType == 4)
			{
				return;
			}

			String bestKey = "";
			int count = 0;
			// find bestKey with the most counts
			//UPGRADE_TODO: Method 'java.util.HashMap.keySet' was converted to 'SupportClass.HashSetSupport' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilHashMapkeySet'"
			//UPGRADE_TODO: Method 'java.util.Iterator.hasNext' was converted to 'System.Collections.IEnumerator.MoveNext' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilIteratorhasNext'"
			for (System.Collections.IEnumerator it = new SupportClass.HashSetSupport(gdsCounter.Keys).GetEnumerator(); it.MoveNext();)
			{
				//UPGRADE_TODO: Method 'java.util.Iterator.next' was converted to 'System.Collections.IEnumerator.Current' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilIteratornext'"
				String key = (String) it.Current;
				//UPGRADE_TODO: Method 'java.util.HashMap.get' was converted to 'System.Collections.Hashtable.Item' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilHashMapget_javalangObject'"
				int gdsCount = Int32.Parse((String) gdsCounter[key]);
				if (gdsCount > count)
				{
					count = gdsCount;
					bestKey = key;
				}
			}

			// remove best key from gdsCounter, others will be removed from gdsHM
			gdsCounter.Remove(bestKey);
			// remove all GDSs using the gdsCounter   
			//UPGRADE_TODO: Method 'java.util.HashMap.keySet' was converted to 'SupportClass.HashSetSupport' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilHashMapkeySet'"
			//UPGRADE_TODO: Method 'java.util.Iterator.hasNext' was converted to 'System.Collections.IEnumerator.MoveNext' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilIteratorhasNext'"
			for (System.Collections.IEnumerator it = new SupportClass.HashSetSupport(gdsCounter.Keys).GetEnumerator(); it.MoveNext();)
			{
				//UPGRADE_TODO: Method 'java.util.Iterator.next' was converted to 'System.Collections.IEnumerator.Current' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilIteratornext'"
				String key = (String) it.Current;
				gdsHM.Remove(key);
			}

			// reset GDS keys in products too
			for (int i = 0; i < products.Count; i++)
			{
				Grib1Product g1p = (Grib1Product) products[i];
				g1p.GDSkey = bestKey;
			}

			return;
		} // end checkGDSkeys

		public Grib1Record GetRecord(int idx)
		{
			if (idx < 0 || idx >= records.Count)
			{
				throw new IndexOutOfRangeException();
			}

			return records[idx] as Grib1Record;
		}

		public Grib1Product GetProduct(int idx)
		{
			if (idx < 0 || idx >= products.Count)
			{
				throw new IndexOutOfRangeException();
			}

			return products[idx] as Grib1Product;
		}

		public void setFilename(string filename)
		{
			InputStream = new System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read);
		}

		public void closeFile()
		{
			InputStream.Close();
		}

		public float MissingValue
		{
			get { return Grib1BinaryDataSection.MissingValue; }
		}
	} // end Grib1Input
}