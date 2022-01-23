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

/// <summary> Grib1Ensemble class 12/30/04.</summary>
/// <author>  Robb Kambic  
/// code is not complete.
/// </author>

namespace NGrib.Grib1
{
	/// <summary> Represents an Ensemble product.
	/// 
	/// </summary>
	public sealed class Grib1Ensemble
	{
		/// <summary> The Type.</summary>
		private int eType;

		/// <summary> The Identification number.</summary>
		private int eId;

		/// <summary> The Product Identifier.</summary>
		private int eProd;

		/// <summary> The Spatial Identifier.</summary>
		private int eSpatial;

		/// <summary> Probability product definition.</summary>
		private int epd;

		private int ept;
		private int epll;
		private int epul;
		private int eSize;
		private int eCSize;
		private int eCNumber;
		private int eCMethod;
		private int nLat;
		private int sLat;
		private int eLat;
		private int wLat;
		private sbyte[] cm;

		/// <summary> Creates an ensemble object for the product PDS.</summary>
		/// <param name="raf">RandomAccessFile.
		/// </param>
		/// <param name="parameterNumber">
		/// </param>
		/// <throws>  IOException </throws>
		//UPGRADE_TODO: Class 'java.io.RandomAccessFile' was converted to 'System.IO.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioRandomAccessFile'"
		internal Grib1Ensemble(System.IO.Stream raf, int parameterNumber)
		{
			// skip 12 bytes to start of ensemble
			SupportClass.Skip(raf, 12);

			// octet 41 id's ensemble
			int app = raf.ReadByte();
			if (app != 1)
			{
				System.Console.Out.WriteLine("not ensemble product");
				return;
			}

			// octet 42 Type
			eType = raf.ReadByte();

			// octet 43 Identification number 
			eId = raf.ReadByte();

			// octet 44 Product Identifier
			eProd = raf.ReadByte();

			// octet 45 Spatial Identifier
			eSpatial = raf.ReadByte();

			if (parameterNumber == 191 || parameterNumber == 192)
			{
				// octet 46 Probability product definition
				epd = raf.ReadByte();

				// octet 47 Probability type
				ept = raf.ReadByte();

				// octet 48-51 Probability lower limit
				epll = GribNumbers.int4(raf);

				// octet 52-55 Probability upper limit
				epul = GribNumbers.int4(raf);

				// octet 56-60 reserved
				int reserved = GribNumbers.int4(raf);

				if (eType == 4 || eType == 5)
				{
					// octet 61 Ensemble size
					eSize = raf.ReadByte();

					// octet 62 Cluster size
					eCSize = raf.ReadByte();

					// octet 63 Number of clusters
					eCNumber = raf.ReadByte();

					// octet 64 Clustering Method
					eCMethod = raf.ReadByte();

					// octet 65-67 Northern latitude of clustering domain
					nLat = GribNumbers.int3(raf);

					// octet 68-70 Southern latitude of clustering domain
					sLat = GribNumbers.int3(raf);

					// octet 71-73 Eastern latitude of clustering domain
					eLat = GribNumbers.int3(raf);

					// octet 74-76 Western latitude of clustering domain
					wLat = GribNumbers.int3(raf);

					if (eType == 4)
					{
						// octets 77-86 Cluster Membership
						cm = new sbyte[10];
						SupportClass.ReadInput(raf, cm, 0, cm.Length);
					}
				}
			}
		}
	} // end Grib1Ensemble
}