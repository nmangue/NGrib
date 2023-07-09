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
using System.Diagnostics;
using NGrib;

namespace NGrib.Grib1
{
	/// <summary> A class that represents the grid definition section (GDS) of a GRIB record.</summary>
	public class Grib1GridDefinitionSection
	{
		/// <summary> is this a thin grid.
		/// 
		/// </summary>
		/// <returns> isThin grid boolean
		/// </returns>
		virtual public bool IsThin
		{
			get { return isThin; }
			// --Commented out by Inspection START (11/17/05 1:42 PM):
			//   public final int[] getNumPlPts()
			//   {
			//      return numPlPts;
			//   }
			// --Commented out by Inspection STOP (11/17/05 1:42 PM)
		}

		/// <summary> Get type of grid. 
		/// 
		/// </summary>
		/// <returns> type of grid
		/// </returns>
		virtual public int GridType
		{
			get { return type; }
		}

		/// <summary> Get type of grid. 
		/// 
		/// </summary>
		/// <returns> type of grid
		/// </returns>
		virtual public int Gdtn
		{
			get { return type; }
		}

		/// <summary> Get number of grid columns.
		/// 
		/// </summary>
		/// <returns> number of grid columns
		/// </returns>
		virtual public int Nx
		{
			get { return nx; }
		}

		/// <summary> Get number of grid rows.
		/// 
		/// </summary>
		/// <returns> number of grid rows.
		/// </returns>
		virtual public int Ny
		{
			get { return ny; }
		}

		/// <summary>
		/// Grid size number of points in total
		/// </summary>
		public int Npts => nx * ny;
		
		/// <summary> Get y-coordinate/latitude of grid start point.
		/// 
		/// </summary>
		/// <returns> y-coordinate/latitude of grid start point
		/// </returns>
		virtual public double La1
		{
			get { return lat1; }
		}

		/// <summary> Get x-coordinate/longitude of grid start point.
		/// 
		/// </summary>
		/// <returns> x-coordinate/longitude of grid start point
		/// </returns>
		virtual public double Lo1
		{
			get { return lon1; }
		}

		/// <summary> Get grid resolution. 
		/// 
		/// </summary>
		/// <returns> resolution
		/// </returns>
		virtual public int Resolution
		{
			get { return resolution; }
		}

		/// <summary> grid shape spherical or oblate.</summary>
		/// <returns> int grid shape code 1 or 3
		/// </returns>
		virtual public int Shape
		{
			get
			{
				int res = resolution >> 6;
				if (res == 1 || res == 3)
				{
					return 1;
				}
				else
				{
					return 0;
				}
			}
		}

		/// <summary> Grib 1 has static radius.</summary>
		/// <returns> ShapeRadius of 6367.47
		/// </returns>
		public static double ShapeRadius
		{
			get { return 6367.47; }
		}

		/// <summary> Grib 1 has static MajorAxis.</summary>
		/// <returns> ShapeMajorAxis of 6378.160
		/// </returns>
		public static double ShapeMajorAxis
		{
			get { return 6378.160; }
		}

		/// <summary> Grib 1 has static MinorAxis.
		/// 
		/// </summary>
		/// <returns> ShapeMinorAxis of 6356.775
		/// </returns>
		public static double ShapeMinorAxis
		{
			get { return 6356.775; }
		}

		/// <summary> Get y-coordinate/latitude of grid end point.
		/// 
		/// </summary>
		/// <returns> y-coordinate/latitude of grid end point
		/// </returns>
		virtual public double La2
		{
			get { return lat2; }
		}

		/// <summary> Get x-coordinate/longitude of grid end point.
		/// 
		/// </summary>
		/// <returns> x-coordinate/longitude of grid end point
		/// </returns>
		virtual public double Lo2
		{
			get { return lon2; }
		}

		/// <summary> orientation of the grid.</summary>
		/// <returns> lov
		/// </returns>
		virtual public double Lov
		{
			get { return lov; }
		}

		/// <summary> not defined in Grib1.</summary>
		/// <returns> lad
		/// </returns>
		virtual public double Lad
		{
			get { return 0; }
		}

		/// <summary> Get x-increment/distance between two grid points.
		/// 
		/// </summary>
		/// <returns> x-increment
		/// </returns>
		virtual public double Dx
		{
			get { return dx; }
		}

		/// <summary> Get y-increment/distance between two grid points.
		/// 
		/// </summary>
		/// <returns> y-increment
		/// </returns>
		virtual public double Dy
		{
			get { return dy; }
		}

		/// <summary> Get parallels between a pole and the equator.
		/// 
		/// </summary>
		/// <returns> np
		/// </returns>
		virtual public double Np
		{
			get { return np; }
		}

		/// <summary> Get scan mode.
		/// 
		/// </summary>
		/// <returns> scan mode
		/// </returns>
		virtual public int ScanMode
		{
			get { return scan; }
		}

		/// <summary> Get Projection Center flag - see note 5 of Table D.
		/// 
		/// </summary>
		/// <returns> Projection Center flag
		/// </returns>
		virtual public int ProjectionCenter
		{
			get { return proj_center; }
		}

		/// <summary> Get first latitude from the pole at which cylinder cuts spherical earth -
		/// see note 8 of Table D.
		/// 
		/// </summary>
		/// <returns> latitude 
		/// </returns>
		virtual public double Latin
		{
			get { return latin1; }
		}

		/// <summary> Get first latitude from the pole at which cone cuts spherical earth -
		/// see note 8 of Table D.
		/// 
		/// </summary>
		/// <returns> latitude of south pole
		/// </returns>
		virtual public double Latin1
		{
			get { return latin1; }
		}

		/// <summary> Get second latitude from the pole at which cone cuts spherical earth -
		/// see note 8 of Table D.
		/// 
		/// </summary>
		/// <returns> latitude of south pole
		/// </returns>
		virtual public double Latin2
		{
			get { return latin2; }
		}

		/// <summary> Get latitude of south pole.
		/// 
		/// </summary>
		/// <returns> latitude
		/// </returns>
		virtual public double SpLat
		{
			get { return latsp; }
		}

		/// <summary> Get longitude of south pole of a rotated latitude/longitude grid.
		/// 
		/// </summary>
		/// <returns> longitude
		/// </returns>
		virtual public double SpLon
		{
			get { return lonsp; }
		}

		/// <summary> MD5 checksum of this gds, used for comparisons.
		/// 
		/// </summary>
		/// <returns> string representation of this GDS checksum
		/// </returns>
		virtual public String CheckSum
		{
			get { return checksum; }
		}

		/// <summary> Length in bytes of this section.</summary>
		private int length;

		/// <summary>  P(V|L).
		/// PV - list of vertical coordinate parameters.
		/// PL - list of numbers of points in each row.
		/// or 255 missing.
		/// </summary>
		private int P_VorL;
		//UPGRADE_NOTE: Final was removed from the declaration of 'numPlPts '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		// private int[] numPlPts = null;

		/// <summary> Is this a thin grid code not implemented.</summary>
		private bool isThin;

		/// <summary> Type of grid (See table 6)ie 1 == Mercator Projection Grid.</summary>
		protected internal int type;

		/// <summary> Grid name.</summary>
		protected internal String name = "";

		/// <summary> Number of grid columns. (Also Ni).</summary>
		protected internal int nx;

		/// <summary> Number of grid rows. (Also Nj).</summary>
		protected internal int ny;

		/// <summary> Latitude of grid start point.</summary>
		protected internal double lat1;

		/// <summary> Longitude of grid start point.</summary>
		protected internal double lon1;

		/// <summary> Latitude of grid last point.</summary>
		protected internal double lat2;

		/// <summary> Longitude of grid last point.</summary>
		protected internal double lon2;

		/// <summary> orientation of the grid.</summary>
		private double lov;

		/// <summary> Resolution of grid (See table 7).</summary>
		protected internal int resolution;

		/// <summary> x-distance between two grid points
		/// can be delta-Lon or delta x.
		/// </summary>
		protected internal double dx;

		/// <summary> y-distance of two grid points
		/// can be delta-Lat or delta y.
		/// </summary>
		protected internal double dy;

		/// <summary> Number of parallels between a pole and the equator.</summary>
		private int np;

		/// <summary> Scanning mode (See table 8).</summary>
		protected internal int scan;

		/// <summary> Projection Center Flag.</summary>
		private int proj_center;

		/// <summary> Latin 1 - The first latitude from pole at which secant cone cuts the
		/// sperical earth.  See Note 8 of ON388.
		/// </summary>
		private double latin1;

		/// <summary> Latin 2 - The second latitude from pole at which secant cone cuts the
		/// sperical earth.  See Note 8 of ON388.
		/// </summary>
		private double latin2;

		/// <summary> latitude of south pole.</summary>
		private double latsp;

		/// <summary> longitude of south pole.</summary>
		private double lonsp;

		/// <summary> checksum value for this gds.</summary>
		protected internal String checksum = "";

		// *** constructors *******************************************************
		/// <summary> constructor</summary>
		internal Grib1GridDefinitionSection()
		{
		}

		/// <summary> Constructs a <tt>Grib1GridDefinitionSection</tt> object from a raf.
		/// 
		/// </summary>
		/// <param name="raf">RandomAccessFile with GDS content
		/// 
		/// </param>
		/// <throws>  NoValidGribException  if raf contains no valid GRIB info </throws>
		//UPGRADE_TODO: Class 'java.io.RandomAccessFile' was converted to 'System.IO.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioRandomAccessFile'"
		internal Grib1GridDefinitionSection(System.IO.Stream raf)
		{
			int reserved; // used to read empty space

			// octets 1-3 (Length of GDS)
			length = (int) GribNumbers.uint3(raf);
			if (length == 0)
			{
				// there's a extra byte between PDS and GDS
				SupportClass.Skip(raf, -2);
				length = (int) GribNumbers.uint3(raf);
			}


			// TODO Fix Checksum stuff
			// get byte array for this gds, then reset raf to same position
			// calculate checksum for this gds via the byte array
			/*
            long mark = raf.Position;
			sbyte[] dst = new sbyte[length - 3];
			SupportClass.ReadInput(raf, dst, 0, dst.Length);
			raf.Seek(mark, System.IO.SeekOrigin.Begin);
			//UPGRADE_ISSUE: Class 'java.util.zip.CRC32' was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1000_javautilzipCRC32'"
			//UPGRADE_ISSUE: Constructor 'java.util.zip.CRC32.CRC32' was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1000_javautilzipCRC32'"
			CRC32 cs = new CRC32();
			//UPGRADE_ISSUE: Method 'java.util.zip.CRC32.update' was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1000_javautilzipCRC32'"
			cs.update(dst);
			//UPGRADE_ISSUE: Method 'java.util.zip.CRC32.getValue' was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1000_javautilzipCRC32'"
			checksum = System.Convert.ToString(cs.getValue());

			*/

			// octets 4 NV
			int NV = raf.ReadByte();


			// octet 5 PL the location (octet number) of the list of numbers of points in each row
			P_VorL = raf.ReadByte();


			// octet 6 (grid type)
			type = raf.ReadByte();

			name = getName(type);

			if (type != 50)
			{
				// values same up to resolution 

				// octets 7-8 (Nx - number of points along x-axis)
				nx = GribNumbers.int2(raf);
				nx = (nx == -1) ? 1 : nx;

				// octets 9-10 (Ny - number of points along y-axis)
				ny = GribNumbers.int2(raf);
				ny = (ny == -1) ? 1 : ny;

				// octets 11-13 (La1 - latitude of first grid point)
				lat1 = GribNumbers.int3(raf) / 1000.0;

				// octets 14-16 (Lo1 - longitude of first grid point)
				lon1 = GribNumbers.int3(raf) / 1000.0;

				// octet 17 (resolution and component flags).  See Table 7
				resolution = raf.ReadByte();
			}

			switch (type)
			{
				//  Latitude/Longitude  grids ,  Arakawa semi-staggered e-grid rotated
				//  Arakawa filled e-grid rotated
				case 0:
				case 4:
				case 40:
				case 201:
				case 202:

					// octets 18-20 (La2 - latitude of last grid point)
					lat2 = GribNumbers.int3(raf) / 1000.0;

					// octets 21-23 (Lo2 - longitude of last grid point)
					lon2 = GribNumbers.int3(raf) / 1000.0;

					// octets 24-25 (Dx - Longitudinal Direction Increment )
					dx = GribNumbers.int2(raf) / 1000.0;

					// octets 26-27 (Dy - Latitudinal Direction Increment )
					//               Np - parallels between a pole and the equator
					if (type == 4)
					{
						np = GribNumbers.int2(raf);
					}
					else
					{
						dy = GribNumbers.int2(raf) / 1000.0;
					}

					// octet 28 (Scanning mode)  See Table 8
					scan = raf.ReadByte();

					// octet 29-32 reserved
					reserved = GribNumbers.int4(raf);

					if (length > 32)
					{
						// getP_VorL(raf);
						// Vertical coordinates (NV) and thinned grids (PL) not supported - skip this
						SupportClass.Skip(raf, length - 32);
					}

					break; // end Latitude/Longitude grids


				case 1: //  Mercator grids

					// octets 18-20 (La2 - latitude of last grid point)
					lat2 = GribNumbers.int3(raf) / 1000.0;

					// octets 21-23 (Lo2 - longitude of last grid point)
					lon2 = GribNumbers.int3(raf) / 1000.0;

					// octets 24-26 (Latin - latitude where cylinder intersects the earth
					latin1 = GribNumbers.int3(raf) / 1000.0;

					// octet 27 reserved
					reserved = raf.ReadByte();

					// octet 28 (Scanning mode)  See Table 8
					scan = raf.ReadByte();

					// octets 29-31 (Dx - Longitudinal Direction Increment )
					dx = GribNumbers.int3(raf);

					// octets 32-34 (Dx - Longitudinal Direction Increment )
					dy = GribNumbers.int3(raf);

					// octet 35-42 reserved
					reserved = GribNumbers.int4(raf);
					reserved = GribNumbers.int4(raf);

					if (length > 42)
					{
						// getP_VorL(raf);
						// Vertical coordinates (NV) and thinned grids (PL) not supported - skip this
						SupportClass.Skip(raf, length - 42);
					}

					break; // end Mercator grids


				case 3: // Lambert Conformal

					// octets 18-20 (Lov - Orientation of the grid - east lon parallel to y axis)
					lov = GribNumbers.int3(raf) / 1000.0;

					// octets 21-23 (Dx - the X-direction grid length) See Note 2 of Table D
					dx = GribNumbers.int3(raf);

					// octets 24-26 (Dy - the Y-direction grid length) See Note 2 of Table D
					dy = GribNumbers.int3(raf);

					// octets 27 (Projection Center flag) See Note 5 of Table D
					proj_center = raf.ReadByte();

					// octet 28 (Scanning mode)  See Table 8
					scan = raf.ReadByte();

					// octets 29-31 (Latin1 - first lat where secant cone cuts spherical earth
					latin1 = GribNumbers.int3(raf) / 1000.0;

					// octets 32-34 (Latin2 - second lat where secant cone cuts spherical earth)
					latin2 = GribNumbers.int3(raf) / 1000.0;

					// octets 35-37 (lat of southern pole)
					latsp = GribNumbers.int3(raf) / 1000.0;

					// octets 38-40 (lon of southern pole)
					lonsp = GribNumbers.int3(raf) / 1000.0;

					// octets 41-42
					reserved = GribNumbers.int2(raf);

					if (length > 42)
					{
						// getP_VorL(raf);
						// Vertical coordinates (NV) and thinned grids (PL) not supported - skip this
						SupportClass.Skip(raf, length - 42);
					}

					break; // end Lambert Conformal


				case 5: //  Polar Stereographic grids

					// octets 18-20 (Lov - Orientation of the grid - east lon parallel to y axis)
					lov = GribNumbers.int3(raf) / 1000.0;

					// octets 21-23 (Dx - Longitudinal Direction Increment )
					dx = GribNumbers.int3(raf);

					// octets 24-26(Dy - Latitudinal Direction Increment )
					dy = GribNumbers.int3(raf);

					// octets 27 (Projection Center flag) See Note 5 of Table D
					proj_center = raf.ReadByte();

					// octet 28 (Scanning mode)  See Table 8
					scan = raf.ReadByte();

					// octet 29-32 reserved
					reserved = GribNumbers.int4(raf);

					if (length > 32)
					{
						// getP_VorL(raf);
						// Vertical coordinates (NV) and thinned grids (PL) not supported - skip this
						SupportClass.Skip(raf, length - 32);
					}

					break; // end Polar Stereographic grids

				case 10: // Rotated Lat-Lon

					// octets 18-20 (La2 latitude of last grid point)
					lat2 = GribNumbers.int3(raf) / 1000.0;
					
					// octets 21-23 (Lo2 longitude of last grid point)
					lon2 = GribNumbers.int3(raf) / 1000.0;
					
					// octets 24-25 (Di i direction increment)
					dx = GribNumbers.int2(raf) / 1000.0;
					
					// octets 26-27 (Dj j direction increment)
					dy = GribNumbers.int2(raf) / 1000.0;
					
					// octet 28 (Scanning mode)
					scan = raf.ReadByte();
					
					// octet 29-32 reserved
					reserved = GribNumbers.int4(raf);
					
					// octets 33-35 (lat of southern pole)
					latsp = GribNumbers.int3(raf) / 1000.0;

					// octets 36-38 (lon of southern pole)
					lonsp = GribNumbers.int3(raf) / 1000.0;
					
					
					// octets 39-42 (Angle of rotation (represented in the same way as the reference value)
					lov = GribNumbers.float4(raf);

					
					if (length > 42)
					{
						// getP_VorL(raf);
						// Vertical coordinates (NV) and thinned grids (PL) not supported - skip this
						SupportClass.Skip(raf, length - 42);
					}
					
					break;

				default:
					Console.Out.WriteLine("Unknown Grid Type : " + type);
					break;
			} // end switch grid_type


			if ((scan & 63) != 0)
				throw new BadGribFormatException("GDS: This scanning mode (" + scan + ") is not supported.");
		} // end Grib1GridDefinitionSection( raf )

		//UPGRADE_TODO: Class 'java.io.RandomAccessFile' was converted to 'System.IO.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioRandomAccessFile'"
		private void getP_VorL(System.IO.Stream raf)
		{
			isThin = true;
			int numPts;
			if (ny != 1)
			{
				dx = (float) GribNumbers.UNDEFINED;
				numPts = ny;
			}
			else
			{
				dx = (float) GribNumbers.UNDEFINED;
				numPts = nx;
			}


			int[] numPlPts = new int[numPts];
			for (int i = 0; i < numPts; i++)
			{
				numPlPts[i] = GribNumbers.int2(raf);

			}
		}

		// *** public methods ***************************************************

		// --Commented out by Inspection START (11/17/05 1:43 PM):
		//   /**
		//    * Get length in bytes of this section.
		//    *
		//    * @return length in bytes of this section
		//    */
		//   public final int getLength()
		//   {
		//      return length;
		//   }
		// --Commented out by Inspection STOP (11/17/05 1:43 PM)

		/// <summary> Get Grid name.
		/// 
		/// </summary>
		/// <returns> name
		/// </returns>
		public String getName()
		{
			return name;
		}

		/// <summary> Get Grid name.
		/// 
		/// </summary>
		/// <param name="type">
		/// </param>
		/// <returns> name
		/// </returns>
		static public String getName(int type)
		{
			switch (type)
			{
				case 0: return "Latitude/Longitude Grid";

				case 1: return "Mercator Projection Grid";

				case 2: return "Gnomonic Projection Grid";

				case 3: return "Lambert Conformal";

				case 4: return "Gaussian Latitude/Longitude";

				case 5: return "Polar Stereographic projection Grid";

				case 6: return "Universal Transverse Mercator";

				case 7: return "Simple polyconic projection";

				case 8: return "Albers equal-area, secant or tangent, conic or bi-polar, projection";

				case 9: return "Miller's cylindrical projection";

				case 10: return "Rotated latitude/longitude grid";

				case 13: return "Oblique Lambert conformal, secant or tangent, conical or bipolar, projection";

				case 14: return "Rotated Gaussian latitude/longitude grid";

				case 20: return "Stretched latitude/longitude grid";

				case 24: return "Stretched Gaussian latitude/longitude grid";

				case 30: return "Stretched and rotated latitude/longitude grids";

				case 34: return "Stretched and rotated Gaussian latitude/longitude grids";

				case 50: return "Spherical Harmonic Coefficients";

				case 60: return "Rotated spherical harmonic coefficients";

				case 70: return "Stretched spherical harmonics";

				case 80: return "Stretched and rotated spherical harmonic coefficients";

				case 90: return "Space view perspective or orthographic";

				case 201: return "Arakawa semi-staggered E-grid on rotated latitude/longitude grid-point array";

				case 202: return "Arakawa filled E-grid on rotated latitude/longitude grid-point array";
			}

			return "Unknown";
		} // end getName

		/// <summary> shape of grid.</summary>
		/// <returns> grid shape name
		/// </returns>
		public String getShapeName()
		{
			return getShapeName(Shape);
		}

		/// <summary> shape of grid.</summary>
		/// <param name="code">grid shape code
		/// </param>
		/// <returns> String grid shape name
		/// </returns>
		static public String getShapeName(int code)
		{
			if (code == 1)
			{
				return "oblate spheroid";
			}
			else
			{
				return "spherical";
			}
		}

		public IEnumerable<Coordinate> EnumerateGridPoints()
		{
			if ((Resolution & 128) == 0 || // The direction increments have to be given
			    ScanMode != 0 && (ScanMode & 64) == 0) // Expect to scan the grid from North to South and West to East, and consecutive in i direction
			{
				throw new NotSupportedException();
			}

			var firstGridPoint = new Coordinate(La1, Lo1);
			var lastGridPoint = new Coordinate(La2, Lo2);

			var xStep = Dx;
			var yStep = ((ScanMode & 64) == 0 ? -1 : 1) * Dy;
			var currentGridPoint = firstGridPoint;

			// Adjacent points in x direction are consecutive 
			var latitudeOffset = 0d;
			for (var y = 0; y < Ny; y++)
			{
				var longitudeOffset = 0d;
				for (var x = 0; x < Nx; x++)
				{
					currentGridPoint = firstGridPoint.Add(latitudeOffset, longitudeOffset);
					yield return currentGridPoint;

					longitudeOffset += xStep;
				}
				latitudeOffset += yStep;
			}

			Debug.Assert(lastGridPoint.Equals(currentGridPoint));
		}
	} // end Grib1GridDefinitionSection
}