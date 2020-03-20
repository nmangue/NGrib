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

namespace NGrib.Sections
{
	
	/// <summary> A class that represents the grid definition section (GDS) of a GRIB product.
	/// 
	/// </summary>
	public sealed class Grib2GridDefinitionSection : IGrib2GridDefinitionSection
	{
		/// <summary> source of grid definition.</summary>
		/// <returns> source
		/// </returns>
		public int Source
		{
			get
			{
				return source;
			}
			
		}
		/// <summary> number of data points .</summary>
		/// <returns> numberPoints
		/// </returns>
		public int NumberPoints
		{
			get
			{
				return numberPoints;
			}
			
		}
		/// <summary> optional list of numbers .</summary>
		/// <returns> olon
		/// </returns>
		public int Olon
		{
			get
			{
				return olon;
			}
			
		}
		/// <summary> iterpretation of optional list of numbers .</summary>
		/// <returns> iolon
		/// </returns>
		public int Iolon
		{
			get
			{
				return iolon;
			}
			
		}
		/// <summary> Grid Definition Template Number .</summary>
		/// <returns> gdtn
		/// </returns>
		public int Gdtn
		{
			get
			{
				return gdtn;
			}
			
		}
		/// <summary> Grid name .</summary>
		/// <returns> gridName
		/// </returns>
		public System.String Name
		{
			get
			{
				return name;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> shape as a int
		/// 
		/// </returns>
		public int Shape
		{
			get
			{
				return shape;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> EarthRadius as a float
		/// 
		/// </returns>
		public float EarthRadius
		{
			get
			{
				return earthRadius;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> MajorAxis as a float
		/// 
		/// </returns>
		public float MajorAxis
		{
			get
			{
				return majorAxis;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> MinorAxis as a float
		/// 
		/// </returns>
		public float MinorAxis
		{
			get
			{
				return minorAxis;
			}
			
		}
		/// <summary> Get number of grid columns.
		/// 
		/// </summary>
		/// <returns> number of grid columns
		/// </returns>
		public int Nx
		{
			get
			{
				return nx;
			}
			
		}
		/// <summary> Get number of grid rows.
		/// 
		/// </summary>
		/// <returns> number of grid rows.
		/// </returns>
		public int Ny
		{
			get
			{
				return ny;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> Angle as a int
		/// 
		/// </returns>
		public int Angle
		{
			get
			{
				return angle;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> Subdivisionsangle as a int
		/// 
		/// </returns>
		public int Subdivisionsangle
		{
			get
			{
				return subdivisionsangle;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> La1 as a float
		/// 
		/// </returns>
		public float La1
		{
			get
			{
				return la1;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> Lo1 as a float
		/// 
		/// </returns>
		public float Lo1
		{
			get
			{
				return lo1;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> Resolution as a int
		/// 
		/// </returns>
		public int Resolution
		{
			get
			{
				return resolution;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> La2 as a float
		/// 
		/// </returns>
		public float La2
		{
			get
			{
				return la2;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> Lo2 as a float
		/// 
		/// </returns>
		public float Lo2
		{
			get
			{
				return lo2;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> Lad as a float
		/// 
		/// </returns>
		public float Lad
		{
			get
			{
				return lad;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> Lov as a float
		/// 
		/// </returns>
		public float Lov
		{
			get
			{
				return lov;
			}
			
		}
		/// <summary> Get x-increment/distance between two grid points.
		/// 
		/// </summary>
		/// <returns> x-increment
		/// </returns>
		public float Dx
		{
			get
			{
				return dx;
			}
			
		}
		/// <summary> Get y-increment/distance between two grid points.
		/// 
		/// </summary>
		/// <returns> y-increment
		/// </returns>
		public float Dy
		{
			get
			{
				return dy;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> ProjectionCenter as a int
		/// 
		/// </returns>
		public int ProjectionCenter
		{
			get
			{
				return projectionCenter;
			}
			
		}
		/// <summary> Get scan mode.
		/// 
		/// </summary>
		/// <returns> scan mode
		/// </returns>
		public int ScanMode
		{
			get
			{
				return scanMode;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> Latin1 as a float
		/// 
		/// </returns>
		public float Latin1
		{
			get
			{
				return latin1;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> Latin2 as a float
		/// 
		/// </returns>
		public float Latin2
		{
			get
			{
				return latin2;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> SpLat as a float
		/// 
		/// </returns>
		public float SpLat
		{
			get
			{
				return spLat;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> SpLon as a float
		/// 
		/// </returns>
		public float SpLon
		{
			get
			{
				return spLon;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> Rotationangle as a float
		/// 
		/// </returns>
		public float Rotationangle
		{
			get
			{
				return rotationangle;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> PoleLat as a float
		/// 
		/// </returns>
		public float PoleLat
		{
			get
			{
				return poleLat;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> PoleLon as a float
		/// 
		/// </returns>
		public float PoleLon
		{
			get
			{
				return poleLon;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> Factor as a float
		/// 
		/// </returns>
		public float Factor
		{
			get
			{
				return factor;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> N as a int
		/// 
		/// </returns>
		public int N
		{
			get
			{
				return n;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> J as a float
		/// 
		/// </returns>
		public float J
		{
			get
			{
				return j;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> K as a float
		/// 
		/// </returns>
		public float K
		{
			get
			{
				return k;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> M as a float
		/// 
		/// </returns>
		public float M
		{
			get
			{
				return m;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> Method as a int
		/// 
		/// </returns>
		public int Method
		{
			get
			{
				return method;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> Mode as a int
		/// 
		/// </returns>
		public int Mode
		{
			get
			{
				return mode;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> Lap as a float
		/// 
		/// </returns>
		public float Lap
		{
			get
			{
				return lap;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> Lop as a float
		/// 
		/// </returns>
		public float Lop
		{
			get
			{
				return lop;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> Xp as a float
		/// 
		/// </returns>
		public float Xp
		{
			get
			{
				return xp;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> Yp as a float
		/// 
		/// </returns>
		public float Yp
		{
			get
			{
				return yp;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> Xo as a float
		/// 
		/// </returns>
		public float Xo
		{
			get
			{
				return xo;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> Yo as a float
		/// 
		/// </returns>
		public float Yo
		{
			get
			{
				return yo;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> Altitude as a float
		/// 
		/// </returns>
		public float Altitude
		{
			get
			{
				return altitude;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> N2 as a int
		/// 
		/// </returns>
		public int N2
		{
			get
			{
				return n2;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> N3 as a int
		/// 
		/// </returns>
		public int N3
		{
			get
			{
				return n3;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> Ni as a int
		/// 
		/// </returns>
		public int Ni
		{
			get
			{
				return ni;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> Nd as a int
		/// 
		/// </returns>
		public int Nd
		{
			get
			{
				return nd;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> Position as a int
		/// 
		/// </returns>
		public int Position
		{
			get
			{
				return position;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> Order as a int
		/// 
		/// </returns>
		public int Order
		{
			get
			{
				return order;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> Nb as a float
		/// 
		/// </returns>
		public float Nb
		{
			get
			{
				return nb;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> Nr as a float
		/// 
		/// </returns>
		public float Nr
		{
			get
			{
				return nr;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> Dstart as a float
		/// 
		/// </returns>
		public float Dstart
		{
			get
			{
				return dstart;
			}
			
		}
		/// <summary> .</summary>
		/// <returns> CheckSum as a String
		/// 
		/// </returns>
		public System.String CheckSum
		{
			get
			{
				return checksum;
			}
			
		}
		/// <summary>  scale factor for Lat/Lon variables in degrees.</summary>
		//UPGRADE_WARNING: Data types in Visual C# might be different.  Verify the accuracy of narrowing conversions. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1042'"
		private static float tenToNegSix = (float) SupportClass.Identity((1 / 1000000.0));
		//UPGRADE_WARNING: Data types in Visual C# might be different.  Verify the accuracy of narrowing conversions. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1042'"
		private static float tenToNegThree = (float) SupportClass.Identity((1 / 1000.0));
		
		/// <summary> Length in bytes of this section.</summary>
		//UPGRADE_NOTE: Final was removed from the declaration of 'length '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private int length;
		
		/// <summary> section number should be 3.</summary>
		//UPGRADE_NOTE: Final was removed from the declaration of 'section '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private int section;
		
		/// <summary> source of grid definition.</summary>
		//UPGRADE_NOTE: Final was removed from the declaration of 'source '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private int source;
		
		/// <summary> number of data points.</summary>
		//UPGRADE_NOTE: Final was removed from the declaration of 'numberPoints '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private int numberPoints;
		
		/// <summary> optional list of numbers.</summary>
		//UPGRADE_NOTE: Final was removed from the declaration of 'olon '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private int olon;
		
		/// <summary> iterpretation of optional list of numbers.</summary>
		//UPGRADE_NOTE: Final was removed from the declaration of 'iolon '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private int iolon;
		
		/// <summary> Grid Definition Template Number.</summary>
		//UPGRADE_NOTE: Final was removed from the declaration of 'gdtn '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private int gdtn;
		
		/// <summary> Grid name.</summary>
		//UPGRADE_NOTE: Final was removed from the declaration of 'name '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private System.String name;
		
		/// <summary> grid definitions from template 3.</summary>
		private int shape;
		private float earthRadius;
		private float majorAxis;
		private float minorAxis;
		
		/// <summary> Number of grid columns. (Also Ni).</summary>
		private int nx;
		
		/// <summary> Number of grid rows. (Also Nj).</summary>
		private int ny;
		
		private int angle;
		private int subdivisionsangle;
		private float la1;
		private float lo1;
		private int resolution;
		private float la2;
		private float lo2;
		private float lad;
		private float lov;
		/// <summary> x-distance between two grid points
		/// can be delta-Lon or delta x.
		/// </summary>
		private float dx;
		
		/// <summary> y-distance of two grid points
		/// can be delta-Lat or delta y.
		/// </summary>
		private float dy;
		
		private int projectionCenter;
		private int scanMode;
		private float latin1;
		private float latin2;
		private float spLat;
		private float spLon;
		private float rotationangle;
		private float poleLat;
		private float poleLon;
		private int lonofcenter;
		private int factor;
		private int n;
		private float j;
		private float k;
		private float m;
		private int method;
		private int mode;
		private float xp;
		private float yp;
		private int lap;
		private int lop;
		private int xo;
		private int yo;
		private int altitude;
		private int n2;
		private int n3;
		private int ni;
		private int nd;
		private int position;
		private int order;
		private float nb;
		private float nr;
		private float dstart;
		
		private System.String checksum = "";
		// *** constructors *******************************************************
		
		/// <summary> Constructs a <tt>Grib2GridDefinitionSection</tt> object from a raf.
		/// 
		/// </summary>
		/// <param name="raf">RandomAccessFile
		/// </param>
		/// <param name="doCheckSum"> calculate the checksum
		/// </param>
		/// <throws>  IOException  if raf contains no valid GRIB product </throws>
		//UPGRADE_TODO: Class 'java.io.RandomAccessFile' was converted to 'System.IO.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioRandomAccessFile'"
		public Grib2GridDefinitionSection(System.IO.FileStream raf, bool doCheckSum)
		{
			int scalefactorradius = 0;
			int scaledvalueradius = 0;
			int scalefactormajor = 0;
			int scaledvaluemajor = 0;
			int scalefactorminor = 0;
			int scaledvalueminor = 0;
			
			// octets 1-4 (Length of GDS)
			length = GribNumbers.int4(raf);
			//System.out.println( "GDS length=" + length );
			
			if (doCheckSum)
			{
                /*
				// get byte array for this gds, then reset raf to same position
				// calculate checksum for this gds via the byte array
				long mark = raf.Position;
				sbyte[] dst = new sbyte[length - 4];
				SupportClass.ReadInput(raf, dst, 0, dst.Length);
				raf.Seek(mark, System.IO.SeekOrigin.Begin);
				//UPGRADE_ISSUE: Class 'java.util.zip.CRC32' was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1000_javautilzipCRC32'"
				//UPGRADE_ISSUE: Constructor 'java.util.zip.CRC32.CRC32' was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1000_javautilzipCRC32'"
				CRC32 cs = new CRC32();
				//UPGRADE_ISSUE: Method 'java.util.zip.CRC32.update' was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1000_javautilzipCRC32'"
				cs.update(dst);
				//UPGRADE_ISSUE: Method 'java.util.zip.CRC32.getValue' was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1000_javautilzipCRC32'"
				checksum = System.Convert.ToString(cs.getValue());
				//System.out.println( "GDS checksum =" + checksum );
                */ 
                // TODO Check this
			}
			
			section = raf.ReadByte(); // This is section 3
			//System.out.println( "GDS is 3, section=" + section );
			
			source = raf.ReadByte();
			//System.out.println( "GDS source=" + source );
			
			numberPoints = GribNumbers.int4(raf);
			//System.out.println( "GDS numberPoints=" + numberPoints );
			
			olon = raf.ReadByte();
			//System.out.println( "GDS olon=" + olon );
			
			iolon = raf.ReadByte();
			//System.out.println( "GDS iolon=" + iolon );
			
			gdtn = GribNumbers.int2(raf);
			//System.out.println( "GDS gdtn=" + gdtn );
			
			name = getGridName(gdtn);
			
			float ratio;
			
			switch (gdtn)
			{
				
				// Grid Definition Template Number
				case 0: 
				case 1: 
				case 2: 
				case 3:  // Latitude/Longitude Grid
					shape = raf.ReadByte();
					//System.out.println( "shape=" + shape );
					scalefactorradius = raf.ReadByte();
					scaledvalueradius = GribNumbers.int4(raf);
					scalefactormajor = raf.ReadByte();
					scaledvaluemajor = GribNumbers.int4(raf);
					scalefactorminor = raf.ReadByte();
					scaledvalueminor = GribNumbers.int4(raf);
					nx = GribNumbers.int4(raf);
					//System.out.println( "nx=" + nx);
					ny = GribNumbers.int4(raf);
					//System.out.println( "ny=" + ny);
					angle = GribNumbers.int4(raf);
					subdivisionsangle = GribNumbers.int4(raf);
					if (angle == 0)
					{
						ratio = tenToNegSix;
					}
					else
					{
						ratio = angle / (float) subdivisionsangle;
					}
					//System.out.println( "ratio =" + ratio );
					la1 = (float) (GribNumbers.int4(raf) * ratio);
					lo1 = (float) (GribNumbers.int4(raf) * ratio);
					resolution = raf.ReadByte();
					la2 = (float) (GribNumbers.int4(raf) * ratio);
					lo2 = (float) (GribNumbers.int4(raf) * ratio);
					dx = (float) (GribNumbers.int4(raf) * ratio);
					dy = (float) (GribNumbers.int4(raf) * ratio);
					scanMode = raf.ReadByte();
					
					//  1, 2, and 3 needs checked
					if (gdtn == 1)
					{
						//Rotated Latitude/longitude
						spLat = GribNumbers.int4(raf) * tenToNegSix;
						spLon = GribNumbers.int4(raf) * tenToNegSix;
                        rotationangle = GribNumbers.IEEEfloat4(raf);
					}
					else if (gdtn == 2)
					{
						//Stretched Latitude/longitude
						poleLat = GribNumbers.int4(raf) * tenToNegSix;
						poleLon = GribNumbers.int4(raf) * tenToNegSix;
						factor = GribNumbers.int4(raf);
					}
					else if (gdtn == 3)
					{
						//Stretched and Rotated 
						// Latitude/longitude
						spLat = GribNumbers.int4(raf) * tenToNegSix;
						spLon = GribNumbers.int4(raf) * tenToNegSix;
                        rotationangle = GribNumbers.IEEEfloat4(raf);
						poleLat = GribNumbers.int4(raf) * tenToNegSix;
						poleLon = GribNumbers.int4(raf) * tenToNegSix;
						factor = GribNumbers.int4(raf);
					}
					break;
				
				
				case 10:  // Mercator
					// la1, lo1, lad, la2, and lo2 need checked
					shape = raf.ReadByte();
					//System.out.println( "shape=" + shape );
					scalefactorradius = raf.ReadByte();
					scaledvalueradius = GribNumbers.int4(raf);
					scalefactormajor = raf.ReadByte();
					scaledvaluemajor = GribNumbers.int4(raf);
					scalefactorminor = raf.ReadByte();
					scaledvalueminor = GribNumbers.int4(raf);
					nx = GribNumbers.int4(raf);
					//System.out.println( "nx=" + nx);
					ny = GribNumbers.int4(raf);
					//System.out.println( "ny=" + ny);
					la1 = GribNumbers.int4(raf) * tenToNegSix;
					lo1 = GribNumbers.int4(raf) * tenToNegSix;
					resolution = raf.ReadByte();
					lad = GribNumbers.int4(raf) * tenToNegSix;
					la2 = GribNumbers.int4(raf) * tenToNegSix;
					lo2 = GribNumbers.int4(raf) * tenToNegSix;
					scanMode = raf.ReadByte();
					angle = GribNumbers.int4(raf);
					dx = (float) (GribNumbers.int4(raf) * tenToNegThree);
					dy = (float) (GribNumbers.int4(raf) * tenToNegThree);
					
					break;
				
				
				case 20:  // Polar stereographic projection
					// la1, lo1, lad, and lov need checked
					shape = raf.ReadByte();
					//System.out.println( "shape=" + shape );
					scalefactorradius = raf.ReadByte();
					scaledvalueradius = GribNumbers.int4(raf);
					scalefactormajor = raf.ReadByte();
					scaledvaluemajor = GribNumbers.int4(raf);
					scalefactorminor = raf.ReadByte();
					scaledvalueminor = GribNumbers.int4(raf);
					nx = GribNumbers.int4(raf);
					//System.out.println( "nx=" + nx);
					ny = GribNumbers.int4(raf);
					//System.out.println( "ny=" + ny);
					la1 = GribNumbers.int4(raf) * tenToNegSix;
					lo1 = GribNumbers.int4(raf) * tenToNegSix;
					resolution = raf.ReadByte();
					lad = GribNumbers.int4(raf) * tenToNegSix;
					lov = GribNumbers.int4(raf) * tenToNegSix;
					dx = (float) (GribNumbers.int4(raf) * tenToNegThree);
					dy = (float) (GribNumbers.int4(raf) * tenToNegThree);
					projectionCenter = raf.ReadByte();
					scanMode = raf.ReadByte();
					
					break;
				
				
				case 30:  // Lambert Conformal
					shape = raf.ReadByte();
					//System.out.println( "shape=" + shape );
					scalefactorradius = raf.ReadByte();
					scaledvalueradius = GribNumbers.int4(raf);
					scalefactormajor = raf.ReadByte();
					scaledvaluemajor = GribNumbers.int4(raf);
					scalefactorminor = raf.ReadByte();
					scaledvalueminor = GribNumbers.int4(raf);
					nx = GribNumbers.int4(raf);
					//System.out.println( "nx=" + nx);
					ny = GribNumbers.int4(raf);
					//System.out.println( "ny=" + ny);
					la1 = (float) (GribNumbers.int4(raf) * tenToNegSix);
					//System.out.println( "la1=" + la1 );
					lo1 = (float) (GribNumbers.int4(raf) * tenToNegSix);
					//System.out.println( "lo1=" + lo1);
					resolution = raf.ReadByte();
					lad = (float) (GribNumbers.int4(raf) * tenToNegSix);
					lov = (float) (GribNumbers.int4(raf) * tenToNegSix);
					dx = (float) (GribNumbers.int4(raf) * tenToNegThree);
					dy = (float) (GribNumbers.int4(raf) * tenToNegThree);
					projectionCenter = raf.ReadByte();
					scanMode = raf.ReadByte();
					latin1 = (float) (GribNumbers.int4(raf) * tenToNegSix);
					latin2 = (float) (GribNumbers.int4(raf) * tenToNegSix);
					//System.out.println( "latin1=" + latin1);
					//System.out.println( "latin2=" + latin2);
					spLat = (float) (GribNumbers.int4(raf) * tenToNegSix);
					spLon = (float) (GribNumbers.int4(raf) * tenToNegSix);
					//System.out.println( "spLat=" + spLat);
					//System.out.println( "spLon=" + spLon);
					
					break;
				
				
				case 31:  // Albers Equal Area
					// la1, lo1, lad, and lov need checked
					shape = raf.ReadByte();
					//System.out.println( "shape=" + shape );
					scalefactorradius = raf.ReadByte();
					scaledvalueradius = GribNumbers.int4(raf);
					scalefactormajor = raf.ReadByte();
					scaledvaluemajor = GribNumbers.int4(raf);
					scalefactorminor = raf.ReadByte();
					scaledvalueminor = GribNumbers.int4(raf);
					nx = GribNumbers.int4(raf);
					//System.out.println( "nx=" + nx);
					ny = GribNumbers.int4(raf);
					//System.out.println( "ny=" + ny);
					la1 = GribNumbers.int4(raf) * tenToNegSix;
					//System.out.println( "la1=" + la1 );
					lo1 = GribNumbers.int4(raf) * tenToNegSix;
					//System.out.println( "lo1=" + lo1);
					resolution = raf.ReadByte();
					lad = GribNumbers.int4(raf) * tenToNegSix;
					lov = GribNumbers.int4(raf) * tenToNegSix;
					dx = (float) (GribNumbers.int4(raf) * tenToNegThree);
					dy = (float) (GribNumbers.int4(raf) * tenToNegThree);
					projectionCenter = raf.ReadByte();
					scanMode = raf.ReadByte();
					latin1 = GribNumbers.int4(raf) * tenToNegSix;
					latin2 = GribNumbers.int4(raf) * tenToNegSix;
					//System.out.println( "latin1=" + latin1);
					//System.out.println( "latin2=" + latin2);
					spLat = GribNumbers.int4(raf) * tenToNegSix;
					spLon = GribNumbers.int4(raf) * tenToNegSix;
					//System.out.println( "spLat=" + spLat);
					//System.out.println( "spLon=" + spLon);
					
					break;
				
				
				case 40: 
				case 41: 
				case 42: 
				case 43:  // Gaussian latitude/longitude
					shape = raf.ReadByte();
					//System.out.println( "shape=" + shape );
					scalefactorradius = raf.ReadByte();
					scaledvalueradius = GribNumbers.int4(raf);
					scalefactormajor = raf.ReadByte();
					scaledvaluemajor = GribNumbers.int4(raf);
					scalefactorminor = raf.ReadByte();
					scaledvalueminor = GribNumbers.int4(raf);
					nx = GribNumbers.int4(raf);
					//System.out.println( "nx=" + nx);
					ny = GribNumbers.int4(raf);
					//System.out.println( "ny=" + ny);
					angle = GribNumbers.int4(raf);
					subdivisionsangle = GribNumbers.int4(raf);
					if (angle == 0)
					{
						ratio = tenToNegSix;
					}
					else
					{
						ratio = angle / subdivisionsangle;
					}
					//System.out.println( "ratio =" + ratio );
					la1 = (float) (GribNumbers.int4(raf) * ratio);
					lo1 = (float) (GribNumbers.int4(raf) * ratio);
					resolution = raf.ReadByte();
					la2 = (float) (GribNumbers.int4(raf) * ratio);
					lo2 = (float) (GribNumbers.int4(raf) * ratio);
					dx = (float) (GribNumbers.int4(raf) * ratio);
					n = raf.ReadByte();
					scanMode = raf.ReadByte();
					
					if (gdtn == 41)
					{
						//Rotated Gaussian Latitude/longitude
						
						spLat = GribNumbers.int4(raf) * ratio;
						spLon = GribNumbers.int4(raf) * ratio;
                        rotationangle = GribNumbers.IEEEfloat4(raf);
					}
					else if (gdtn == 42)
					{
						//Stretched Gaussian 
						// Latitude/longitude
						
						poleLat = GribNumbers.int4(raf) * ratio;
						poleLon = GribNumbers.int4(raf) * ratio;
						factor = GribNumbers.int4(raf);
					}
					else if (gdtn == 43)
					{
						//Stretched and Rotated Gaussian  
						// Latitude/longitude
						
						spLat = GribNumbers.int4(raf) * ratio;
						spLon = GribNumbers.int4(raf) * ratio;
                        rotationangle = GribNumbers.IEEEfloat4(raf);
						poleLat = GribNumbers.int4(raf) * ratio;
						poleLon = GribNumbers.int4(raf) * ratio;
						factor = GribNumbers.int4(raf);
					}
					break;
				
				
				case 50: 
				case 51: 
				case 52: 
				case 53:  // Spherical harmonic coefficients

                    j = GribNumbers.IEEEfloat4(raf);
                    k = GribNumbers.IEEEfloat4(raf);
                    m = GribNumbers.IEEEfloat4(raf);
					method = raf.ReadByte();
					mode = raf.ReadByte();
					if (gdtn == 51)
					{
						//Rotated Spherical harmonic coefficients
						
						spLat = GribNumbers.int4(raf) * tenToNegSix;
						spLon = GribNumbers.int4(raf) * tenToNegSix;
                        rotationangle = GribNumbers.IEEEfloat4(raf);
					}
					else if (gdtn == 52)
					{
						//Stretched Spherical 
						// harmonic coefficients
						
						poleLat = GribNumbers.int4(raf) * tenToNegSix;
						poleLon = GribNumbers.int4(raf) * tenToNegSix;
						factor = GribNumbers.int4(raf);
					}
					else if (gdtn == 53)
					{
						//Stretched and Rotated 
						// Spherical harmonic coefficients
						
						spLat = GribNumbers.int4(raf) * tenToNegSix;
						spLon = GribNumbers.int4(raf) * tenToNegSix;
                        rotationangle = GribNumbers.IEEEfloat4(raf);
						poleLat = GribNumbers.int4(raf) * tenToNegSix;
						poleLon = GribNumbers.int4(raf) * tenToNegSix;
						factor = GribNumbers.int4(raf);
					}
					break;
				
				
				case 90:  // Space view perspective or orthographic
					shape = raf.ReadByte();
					//System.out.println( "shape=" + shape );
					scalefactorradius = raf.ReadByte();
					scaledvalueradius = GribNumbers.int4(raf);
					scalefactormajor = raf.ReadByte();
					scaledvaluemajor = GribNumbers.int4(raf);
					scalefactorminor = raf.ReadByte();
					scaledvalueminor = GribNumbers.int4(raf);
					nx = GribNumbers.int4(raf);
					//System.out.println( "nx=" + nx);
					ny = GribNumbers.int4(raf);
					//System.out.println( "ny=" + ny);
					lap = GribNumbers.int4(raf);
					lop = GribNumbers.int4(raf);
					resolution = raf.ReadByte();
					dx = GribNumbers.int4(raf);
					dy = GribNumbers.int4(raf);
					xp = (float) (GribNumbers.int4(raf) * tenToNegThree);
					yp = (float) (GribNumbers.int4(raf) * tenToNegThree);
					scanMode = raf.ReadByte();
					angle = GribNumbers.int4(raf);
					altitude = GribNumbers.int4(raf) * 1000000;
					xo = GribNumbers.int4(raf);
					yo = GribNumbers.int4(raf);
					
					break;
				
				
				case 100:  // Triangular grid based on an icosahedron
					
					n2 = raf.ReadByte();
					n3 = raf.ReadByte();
					ni = GribNumbers.int2(raf);
					nd = raf.ReadByte();
					poleLat = GribNumbers.int4(raf) * tenToNegSix;
					poleLon = GribNumbers.int4(raf) * tenToNegSix;
					lonofcenter = GribNumbers.int4(raf);
					position = raf.ReadByte();
					order = raf.ReadByte();
					scanMode = raf.ReadByte();
					n = GribNumbers.int4(raf);
					break;
				
				
				case 110:  // Equatorial azimuthal equidistant projection
					shape = raf.ReadByte();
					//System.out.println( "shape=" + shape );
					scalefactorradius = raf.ReadByte();
					scaledvalueradius = GribNumbers.int4(raf);
					scalefactormajor = raf.ReadByte();
					scaledvaluemajor = GribNumbers.int4(raf);
					scalefactorminor = raf.ReadByte();
					scaledvalueminor = GribNumbers.int4(raf);
					nx = GribNumbers.int4(raf);
					//System.out.println( "nx=" + nx);
					ny = GribNumbers.int4(raf);
					//System.out.println( "ny=" + ny);
					la1 = GribNumbers.int4(raf) * tenToNegSix;
					lo1 = GribNumbers.int4(raf) * tenToNegSix;
					resolution = raf.ReadByte();
					dx = (float) (GribNumbers.int4(raf) * tenToNegThree);
					dy = (float) (GribNumbers.int4(raf) * tenToNegThree);
					projectionCenter = raf.ReadByte();
					scanMode = raf.ReadByte();
					
					break;
				
				
				case 120:  // Azimuth-range Projection
					nb = GribNumbers.int4(raf);
					nr = GribNumbers.int4(raf);
					la1 = GribNumbers.int4(raf);
					lo1 = GribNumbers.int4(raf);
					dx = GribNumbers.int4(raf);
                    dstart = GribNumbers.IEEEfloat4(raf);
					scanMode = raf.ReadByte();
					for (int i = 0; i < nr; i++)
					{
						// get azi (33+4(Nr-1))-(34+4(Nr-1))
						// get adelta (35+4(Nr-1))-(36+4(Nr-1))
					}
					System.Console.Out.WriteLine("need code to get azi and adelta");
					
					break;
				
				
				default: 
					System.Console.Out.WriteLine("Unknown Grid Type " + System.Convert.ToString(gdtn));
					break;
				
			} // end switch
			
			// calculate earth radius
			if ((gdtn < 50 || gdtn > 53) && gdtn != 100 && gdtn != 120)
			{
				if (shape == 0)
				{
					earthRadius = 6367470;
				}
				else if (shape == 1)
				{
					earthRadius = scaledvalueradius;
					if (scalefactorradius != 0)
						earthRadius = (float) (earthRadius / System.Math.Pow(10, scalefactorradius));
				}
				else if (shape == 2)
				{
					//UPGRADE_WARNING: Data types in Visual C# might be different.  Verify the accuracy of narrowing conversions. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1042'"
					majorAxis = (float) 6378160.0;
					//UPGRADE_WARNING: Data types in Visual C# might be different.  Verify the accuracy of narrowing conversions. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1042'"
					minorAxis = (float) 6356775.0;
				}
				else if (shape == 3)
				{
					majorAxis = scaledvaluemajor;
					//System.out.println( "majorAxisScale =" + scalefactormajor );
					//System.out.println( "majorAxisiValue =" + scaledvaluemajor );
					majorAxis = (float) (majorAxis / System.Math.Pow(10, scalefactormajor));
					
					minorAxis = scaledvalueminor;
					//System.out.println( "minorAxisScale =" + scalefactorminor );
					//System.out.println( "minorAxisValue =" + scaledvalueminor );
					minorAxis = (float) (minorAxis / System.Math.Pow(10, scalefactorminor));
				}
				else if (shape == 4)
				{
					//UPGRADE_WARNING: Data types in Visual C# might be different.  Verify the accuracy of narrowing conversions. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1042'"
					majorAxis = (float) 6378137.0;
					minorAxis = (float) SupportClass.Identity(6356752.314);
				}
				else if (shape == 6)
				{
					earthRadius = 6371229;
				}
			}
		} // end of Grib2GridDefinitionSection
		
		/// <summary> .</summary>
		/// <param name="gdtn"> Grid definition template number same as type of grid
		/// </param>
		/// <returns> GridName as a String
		/// 
		/// </returns>
		public static System.String getGridName(int gdtn)
		{
			switch (gdtn)
			{
				
				// code table 3.2
				case 0:  return "Latitude/Longitude";
				
				case 1:  return "Rotated Latitude/Longitude";
				
				case 2:  return "Stretched Latitude/Longitude";
				
				case 3:  return "iStretched and Rotated Latitude/Longitude";
				
				case 10:  return "Mercator";
				
				case 20:  return "Polar stereographic";
				
				case 30:  return "Lambert Conformal";
				
				case 31:  return "Albers Equal Area";
				
				case 40:  return "Gaussian latitude/longitude";
				
				case 41:  return "Rotated Gaussian Latitude/longitude";
				
				case 42:  return "Stretched Gaussian Latitude/longitude";
				
				case 43:  return "Stretched and Rotated Gaussian Latitude/longitude";
				
				case 50:  return "Spherical harmonic coefficients";
				
				case 51:  return "Rotated Spherical harmonic coefficients";
				
				case 52:  return "Stretched Spherical harmonic coefficients";
				
				case 53:  return "Stretched and Rotated Spherical harmonic coefficients";
				
				case 90:  return "Space View Perspective or Orthographic";
				
				case 100:  return "Triangular Grid Based on an Icosahedron";
				
				case 110:  return "Equatorial Azimuthal Equidistant";
				
				case 120:  return "Azimuth-Range";
				
				
				default:  return "Unknown projection" + gdtn;
				
			}
		} // end getGridName
		
		// --Commented out by Inspection START (11/21/05 12:34 PM):
		//   /**
		//    * Get length in bytes of this section.
		//    *
		//    * @return length in bytes of this section
		//    */
		//   public final int getLength()
		//   {
		//      return length;
		//   }
		// --Commented out by Inspection STOP (11/21/05 12:34 PM)
		
		// --Commented out by Inspection START (12/1/05 3:04 PM):
		//   /**
		//    * Number of this section, should be 3
		//    */
		//   public final int getSection()
		//   {
		//      return section;
		//   }
		// --Commented out by Inspection STOP (12/1/05 3:04 PM)
		
		/// <summary> .</summary>
		/// <returns> shapeName as a String
		/// 
		/// </returns>
		public System.String getShapeName()
		{
			return getShapeName(shape);
		}
		
		/// <summary> .</summary>
		/// <param name="shape">
		/// </param>
		/// <returns> shapeName as a String
		/// 
		/// </returns>
		static public System.String getShapeName(int shape)
		{
			switch (shape)
			{
				
				// code table 3.2
				case 0:  return "Earth spherical with radius = 6367470 m";
				
				case 1:  return "Earth spherical with radius specified by producer";
				
				case 2:  return "Earth oblate spheroid with major axis = 6378160.0 m and minor axis = 6356775.0 m";
				
				case 3:  return "Earth oblate spheroid with axes specified by producer";
				
				case 4:  return "Earth oblate spheroid with major axis = 6378137.0 m and minor axis = 6356752.314 m";
				
				case 5:  return "Earth represent by WGS84";
				
				case 6:  return "Earth spherical with radius of 6371229.0 m";
				
				default:  return "Unknown Earth Shape";
				
			}
		}
	} // end Grib2GridDefinitionSection
}