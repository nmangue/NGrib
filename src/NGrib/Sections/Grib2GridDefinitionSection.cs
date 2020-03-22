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
	/// <summary> A class that represents the grid definition section (GDS) of a GRIB product.
	/// 
	/// </summary>
	public sealed class Grib2GridDefinitionSection
	{
		/// <summary> source of grid definition.</summary>
		/// <returns> source
		/// </returns>
		public int Source { get; }

		/// <summary> number of data points .</summary>
		/// <returns> numberPoints
		/// </returns>
		public long NumberPoints { get; }

		/// <summary> optional list of numbers .</summary>
		/// <returns> olon
		/// </returns>
		public int Olon { get; }

		/// <summary> iterpretation of optional list of numbers .</summary>
		/// <returns> iolon
		/// </returns>
		public int Iolon { get; }

		/// <summary> Grid Definition Template Number .</summary>
		/// <returns> gdtn
		/// </returns>
		public int Gdtn { get; }

		/// <summary> Grid name .</summary>
		/// <returns> gridName
		/// </returns>
		public string Name { get; }

		/// <summary> .</summary>
		/// <returns> shape as a int
		/// 
		/// </returns>
		public int Shape { get; }

		/// <summary> .</summary>
		/// <returns> EarthRadius as a float
		/// 
		/// </returns>
		public float EarthRadius { get; }

		/// <summary> .</summary>
		/// <returns> MajorAxis as a float
		/// 
		/// </returns>
		public float MajorAxis { get; }

		/// <summary> .</summary>
		/// <returns> MinorAxis as a float
		/// 
		/// </returns>
		public float MinorAxis { get; }

		/// <summary> Get number of grid columns.
		/// 
		/// </summary>
		/// <returns> number of grid columns
		/// </returns>
		public long Nx { get; }

		/// <summary> Get number of grid rows.
		/// 
		/// </summary>
		/// <returns> number of grid rows.
		/// </returns>
		public long Ny { get; }

		/// <summary> .</summary>
		/// <returns> Angle as a int
		/// 
		/// </returns>
		public long Angle { get; }

		/// <summary> .</summary>
		/// <returns> Subdivisionsangle as a int
		/// 
		/// </returns>
		public long Subdivisionsangle { get; }

		/// <summary> .</summary>
		/// <returns> La1 as a float
		/// 
		/// </returns>
		public float La1 { get; }

		/// <summary> .</summary>
		/// <returns> Lo1 as a float
		/// 
		/// </returns>
		public float Lo1 { get; }

		/// <summary> .</summary>
		/// <returns> Resolution as a int
		/// 
		/// </returns>
		public int Resolution { get; }

		/// <summary> .</summary>
		/// <returns> La2 as a float
		/// 
		/// </returns>
		public float La2 { get; }

		/// <summary> .</summary>
		/// <returns> Lo2 as a float
		/// 
		/// </returns>
		public float Lo2 { get; }

		/// <summary> .</summary>
		/// <returns> Lad as a float
		/// 
		/// </returns>
		public float Lad { get; }

		/// <summary> .</summary>
		/// <returns> Lov as a float
		/// 
		/// </returns>
		public float Lov { get; }

		/// <summary> Get x-increment/distance between two grid points.
		/// 
		/// </summary>
		/// <returns> x-increment
		/// </returns>
		public float Dx { get; }

		/// <summary> Get y-increment/distance between two grid points.
		/// 
		/// </summary>
		/// <returns> y-increment
		/// </returns>
		public float Dy { get; }

		/// <summary> .</summary>
		/// <returns> ProjectionCenter as a int
		/// 
		/// </returns>
		public int ProjectionCenter { get; }

		/// <summary> Get scan mode.
		/// 
		/// </summary>
		/// <returns> scan mode
		/// </returns>
		public int ScanMode { get; }

		/// <summary> .</summary>
		/// <returns> Latin1 as a float
		/// 
		/// </returns>
		public float Latin1 { get; }

		/// <summary> .</summary>
		/// <returns> Latin2 as a float
		/// 
		/// </returns>
		public float Latin2 { get; }

		/// <summary> .</summary>
		/// <returns> SpLat as a float
		/// 
		/// </returns>
		public float SpLat { get; }

		/// <summary> .</summary>
		/// <returns> SpLon as a float
		/// 
		/// </returns>
		public float SpLon { get; }

		/// <summary> .</summary>
		/// <returns> Rotationangle as a float
		/// 
		/// </returns>
		public float Rotationangle { get; }

		/// <summary> .</summary>
		/// <returns> PoleLat as a float
		/// 
		/// </returns>
		public float PoleLat { get; }

		/// <summary> .</summary>
		/// <returns> PoleLon as a float
		/// 
		/// </returns>
		public float PoleLon { get; }

		/// <summary> .</summary>
		/// <returns> Factor as a float
		/// 
		/// </returns>
		public float Factor
		{
			get { return factor; }
		}

		/// <summary> .</summary>
		/// <returns> N as a int
		/// 
		/// </returns>
		public long N { get; }

		/// <summary> .</summary>
		/// <returns> J as a float
		/// 
		/// </returns>
		public float J { get; }

		/// <summary> .</summary>
		/// <returns> K as a float
		/// 
		/// </returns>
		public float K { get; }

		/// <summary> .</summary>
		/// <returns> M as a float
		/// 
		/// </returns>
		public float M { get; }

		/// <summary> .</summary>
		/// <returns> Method as a int
		/// 
		/// </returns>
		public int Method { get; }

		/// <summary> .</summary>
		/// <returns> Mode as a int
		/// 
		/// </returns>
		public int Mode { get; }

		/// <summary> .</summary>
		/// <returns> Lap as a float
		/// 
		/// </returns>
		public float Lap
		{
			get { return lap; }
		}

		/// <summary> .</summary>
		/// <returns> Lop as a float
		/// 
		/// </returns>
		public float Lop
		{
			get { return lop; }
		}

		/// <summary> .</summary>
		/// <returns> Xp as a float
		/// 
		/// </returns>
		public float Xp { get; }

		/// <summary> .</summary>
		/// <returns> Yp as a float
		/// 
		/// </returns>
		public float Yp { get; }

		/// <summary> .</summary>
		/// <returns> Xo as a float
		/// 
		/// </returns>
		public float Xo
		{
			get { return xo; }
		}

		/// <summary> .</summary>
		/// <returns> Yo as a float
		/// 
		/// </returns>
		public float Yo
		{
			get { return yo; }
		}

		/// <summary> .</summary>
		/// <returns> Altitude as a float
		/// 
		/// </returns>
		public float Altitude
		{
			get { return altitude; }
		}

		/// <summary> .</summary>
		/// <returns> N2 as a int
		/// 
		/// </returns>
		public int N2 { get; }

		/// <summary> .</summary>
		/// <returns> N3 as a int
		/// 
		/// </returns>
		public int N3 { get; }

		/// <summary> .</summary>
		/// <returns> Ni as a int
		/// 
		/// </returns>
		public int Ni { get; }

		/// <summary> .</summary>
		/// <returns> Nd as a int
		/// 
		/// </returns>
		public int Nd { get; }

		/// <summary> .</summary>
		/// <returns> Position as a int
		/// 
		/// </returns>
		public int Position { get; }

		/// <summary> .</summary>
		/// <returns> Order as a int
		/// 
		/// </returns>
		public int Order { get; }

		/// <summary> .</summary>
		/// <returns> Nb as a float
		/// 
		/// </returns>
		public float Nb { get; }

		/// <summary> .</summary>
		/// <returns> Nr as a float
		/// 
		/// </returns>
		public float Nr { get; }

		/// <summary> .</summary>
		/// <returns> Dstart as a float
		/// 
		/// </returns>
		public float Dstart { get; }

		/// <summary> .</summary>
		/// <returns> CheckSum as a String
		/// 
		/// </returns>
		public string CheckSum { get; } = "";

		/// <summary>  scale factor for Lat/Lon variables in degrees.</summary>
		//UPGRADE_WARNING: Data types in Visual C# might be different.  Verify the accuracy of narrowing conversions. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1042'"
		private static readonly float tenToNegSix = (float)SupportClass.Identity((1 / 1000000.0));

		//UPGRADE_WARNING: Data types in Visual C# might be different.  Verify the accuracy of narrowing conversions. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1042'"
		private static readonly float tenToNegThree = (float)SupportClass.Identity((1 / 1000.0));

		/// <summary> Length in bytes of this section.</summary>
		public int Length { get; }

		/// <summary> section number should be 3.</summary>
		public int Section { get; }

		private long lonofcenter;
		private readonly long factor;
		private readonly long lap;
		private readonly long lop;
		private readonly long xo;
		private readonly long yo;
		private readonly long altitude;

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
		public Grib2GridDefinitionSection(FileStream raf, bool doCheckSum)
		{
			int scalefactorradius = 0;
			int scaledvalueradius = 0;
			int scalefactormajor = 0;
			int scaledvaluemajor = 0;
			int scalefactorminor = 0;
			int scaledvalueminor = 0;

			// octets 1-4 (Length of GDS)
			Length = GribNumbers.int4(raf);

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

			Section = raf.ReadByte(); // This is section 3

			Source = raf.ReadByte();

			NumberPoints = GribNumbers.int4(raf);

			Olon = raf.ReadByte();

			Iolon = raf.ReadByte();

			Gdtn = GribNumbers.int2(raf);

			Name = getGridName(Gdtn);

			float ratio;

			switch (Gdtn)
			{
				// Grid Definition Template Number
				case 0:
				case 1:
				case 2:
				case 3: // Latitude/Longitude Grid
					Shape = raf.ReadByte();

					scalefactorradius = raf.ReadByte();
					scaledvalueradius = GribNumbers.int4(raf);
					scalefactormajor = raf.ReadByte();
					scaledvaluemajor = GribNumbers.int4(raf);
					scalefactorminor = raf.ReadByte();
					scaledvalueminor = GribNumbers.int4(raf);
					Nx = GribNumbers.int4(raf);

					Ny = GribNumbers.int4(raf);

					Angle = GribNumbers.int4(raf);
					Subdivisionsangle = GribNumbers.int4(raf);
					if (Angle == 0)
					{
						ratio = tenToNegSix;
					}
					else
					{
						ratio = Angle / (float)Subdivisionsangle;
					}

					La1 = (float)(GribNumbers.int4(raf) * ratio);
					Lo1 = (float)(GribNumbers.int4(raf) * ratio);
					Resolution = raf.ReadByte();
					La2 = (float)(GribNumbers.int4(raf) * ratio);
					Lo2 = (float)(GribNumbers.int4(raf) * ratio);
					Dx = (float)(GribNumbers.int4(raf) * ratio);
					Dy = (float)(GribNumbers.int4(raf) * ratio);
					ScanMode = raf.ReadByte();

					//  1, 2, and 3 needs checked
					if (Gdtn == 1)
					{
						//Rotated Latitude/longitude
						SpLat = GribNumbers.int4(raf) * tenToNegSix;
						SpLon = GribNumbers.int4(raf) * tenToNegSix;
						Rotationangle = GribNumbers.IEEEfloat4(raf);
					}
					else if (Gdtn == 2)
					{
						//Stretched Latitude/longitude
						PoleLat = GribNumbers.int4(raf) * tenToNegSix;
						PoleLon = GribNumbers.int4(raf) * tenToNegSix;
						factor = GribNumbers.int4(raf);
					}
					else if (Gdtn == 3)
					{
						//Stretched and Rotated 
						// Latitude/longitude
						SpLat = GribNumbers.int4(raf) * tenToNegSix;
						SpLon = GribNumbers.int4(raf) * tenToNegSix;
						Rotationangle = GribNumbers.IEEEfloat4(raf);
						PoleLat = GribNumbers.int4(raf) * tenToNegSix;
						PoleLon = GribNumbers.int4(raf) * tenToNegSix;
						factor = GribNumbers.int4(raf);
					}

					break;

				case 10: // Mercator
								 // la1, lo1, lad, la2, and lo2 need checked
					Shape = raf.ReadByte();

					scalefactorradius = raf.ReadByte();
					scaledvalueradius = GribNumbers.int4(raf);
					scalefactormajor = raf.ReadByte();
					scaledvaluemajor = GribNumbers.int4(raf);
					scalefactorminor = raf.ReadByte();
					scaledvalueminor = GribNumbers.int4(raf);
					Nx = GribNumbers.int4(raf);

					Ny = GribNumbers.int4(raf);

					La1 = GribNumbers.int4(raf) * tenToNegSix;
					Lo1 = GribNumbers.int4(raf) * tenToNegSix;
					Resolution = raf.ReadByte();
					Lad = GribNumbers.int4(raf) * tenToNegSix;
					La2 = GribNumbers.int4(raf) * tenToNegSix;
					Lo2 = GribNumbers.int4(raf) * tenToNegSix;
					ScanMode = raf.ReadByte();
					Angle = GribNumbers.int4(raf);
					Dx = (float)(GribNumbers.int4(raf) * tenToNegThree);
					Dy = (float)(GribNumbers.int4(raf) * tenToNegThree);

					break;

				case 20: // Polar stereographic projection
								 // la1, lo1, lad, and lov need checked
					Shape = raf.ReadByte();

					scalefactorradius = raf.ReadByte();
					scaledvalueradius = GribNumbers.int4(raf);
					scalefactormajor = raf.ReadByte();
					scaledvaluemajor = GribNumbers.int4(raf);
					scalefactorminor = raf.ReadByte();
					scaledvalueminor = GribNumbers.int4(raf);
					Nx = GribNumbers.int4(raf);

					Ny = GribNumbers.int4(raf);

					La1 = GribNumbers.int4(raf) * tenToNegSix;
					Lo1 = GribNumbers.int4(raf) * tenToNegSix;
					Resolution = raf.ReadByte();
					Lad = GribNumbers.int4(raf) * tenToNegSix;
					Lov = GribNumbers.int4(raf) * tenToNegSix;
					Dx = (float)(GribNumbers.int4(raf) * tenToNegThree);
					Dy = (float)(GribNumbers.int4(raf) * tenToNegThree);
					ProjectionCenter = raf.ReadByte();
					ScanMode = raf.ReadByte();

					break;

				case 30: // Lambert Conformal
					Shape = raf.ReadByte();

					scalefactorradius = raf.ReadByte();
					scaledvalueradius = GribNumbers.int4(raf);
					scalefactormajor = raf.ReadByte();
					scaledvaluemajor = GribNumbers.int4(raf);
					scalefactorminor = raf.ReadByte();
					scaledvalueminor = GribNumbers.int4(raf);
					Nx = GribNumbers.int4(raf);

					Ny = GribNumbers.int4(raf);

					La1 = (float)(GribNumbers.int4(raf) * tenToNegSix);

					Lo1 = (float)(GribNumbers.int4(raf) * tenToNegSix);

					Resolution = raf.ReadByte();
					Lad = (float)(GribNumbers.int4(raf) * tenToNegSix);
					Lov = (float)(GribNumbers.int4(raf) * tenToNegSix);
					Dx = (float)(GribNumbers.int4(raf) * tenToNegThree);
					Dy = (float)(GribNumbers.int4(raf) * tenToNegThree);
					ProjectionCenter = raf.ReadByte();
					ScanMode = raf.ReadByte();
					Latin1 = (float)(GribNumbers.int4(raf) * tenToNegSix);
					Latin2 = (float)(GribNumbers.int4(raf) * tenToNegSix);

					SpLat = (float)(GribNumbers.int4(raf) * tenToNegSix);
					SpLon = (float)(GribNumbers.int4(raf) * tenToNegSix);

					break;

				case 31: // Albers Equal Area
								 // la1, lo1, lad, and lov need checked
					Shape = raf.ReadByte();

					scalefactorradius = raf.ReadByte();
					scaledvalueradius = GribNumbers.int4(raf);
					scalefactormajor = raf.ReadByte();
					scaledvaluemajor = GribNumbers.int4(raf);
					scalefactorminor = raf.ReadByte();
					scaledvalueminor = GribNumbers.int4(raf);
					Nx = GribNumbers.int4(raf);

					Ny = GribNumbers.int4(raf);

					La1 = GribNumbers.int4(raf) * tenToNegSix;

					Lo1 = GribNumbers.int4(raf) * tenToNegSix;

					Resolution = raf.ReadByte();
					Lad = GribNumbers.int4(raf) * tenToNegSix;
					Lov = GribNumbers.int4(raf) * tenToNegSix;
					Dx = (float)(GribNumbers.int4(raf) * tenToNegThree);
					Dy = (float)(GribNumbers.int4(raf) * tenToNegThree);
					ProjectionCenter = raf.ReadByte();
					ScanMode = raf.ReadByte();
					Latin1 = GribNumbers.int4(raf) * tenToNegSix;
					Latin2 = GribNumbers.int4(raf) * tenToNegSix;

					SpLat = GribNumbers.int4(raf) * tenToNegSix;
					SpLon = GribNumbers.int4(raf) * tenToNegSix;

					break;

				case 40:
				case 41:
				case 42:
				case 43: // Gaussian latitude/longitude
					Shape = raf.ReadByte();

					scalefactorradius = raf.ReadByte();
					scaledvalueradius = GribNumbers.int4(raf);
					scalefactormajor = raf.ReadByte();
					scaledvaluemajor = GribNumbers.int4(raf);
					scalefactorminor = raf.ReadByte();
					scaledvalueminor = GribNumbers.int4(raf);
					Nx = GribNumbers.int4(raf);

					Ny = GribNumbers.int4(raf);

					Angle = GribNumbers.int4(raf);
					Subdivisionsangle = GribNumbers.int4(raf);
					if (Angle == 0)
					{
						ratio = tenToNegSix;
					}
					else
					{
						ratio = Angle / Subdivisionsangle;
					}

					La1 = (float)(GribNumbers.int4(raf) * ratio);
					Lo1 = (float)(GribNumbers.int4(raf) * ratio);
					Resolution = raf.ReadByte();
					La2 = (float)(GribNumbers.int4(raf) * ratio);
					Lo2 = (float)(GribNumbers.int4(raf) * ratio);
					Dx = (float)(GribNumbers.int4(raf) * ratio);
					N = raf.ReadByte();
					ScanMode = raf.ReadByte();

					if (Gdtn == 41)
					{
						//Rotated Gaussian Latitude/longitude

						SpLat = GribNumbers.int4(raf) * ratio;
						SpLon = GribNumbers.int4(raf) * ratio;
						Rotationangle = GribNumbers.IEEEfloat4(raf);
					}
					else if (Gdtn == 42)
					{
						//Stretched Gaussian 
						// Latitude/longitude

						PoleLat = GribNumbers.int4(raf) * ratio;
						PoleLon = GribNumbers.int4(raf) * ratio;
						factor = GribNumbers.int4(raf);
					}
					else if (Gdtn == 43)
					{
						//Stretched and Rotated Gaussian  
						// Latitude/longitude

						SpLat = GribNumbers.int4(raf) * ratio;
						SpLon = GribNumbers.int4(raf) * ratio;
						Rotationangle = GribNumbers.IEEEfloat4(raf);
						PoleLat = GribNumbers.int4(raf) * ratio;
						PoleLon = GribNumbers.int4(raf) * ratio;
						factor = GribNumbers.int4(raf);
					}

					break;

				case 50:
				case 51:
				case 52:
				case 53: // Spherical harmonic coefficients

					J = GribNumbers.IEEEfloat4(raf);
					K = GribNumbers.IEEEfloat4(raf);
					M = GribNumbers.IEEEfloat4(raf);
					Method = raf.ReadByte();
					Mode = raf.ReadByte();
					if (Gdtn == 51)
					{
						//Rotated Spherical harmonic coefficients

						SpLat = GribNumbers.int4(raf) * tenToNegSix;
						SpLon = GribNumbers.int4(raf) * tenToNegSix;
						Rotationangle = GribNumbers.IEEEfloat4(raf);
					}
					else if (Gdtn == 52)
					{
						//Stretched Spherical 
						// harmonic coefficients

						PoleLat = GribNumbers.int4(raf) * tenToNegSix;
						PoleLon = GribNumbers.int4(raf) * tenToNegSix;
						factor = GribNumbers.int4(raf);
					}
					else if (Gdtn == 53)
					{
						//Stretched and Rotated 
						// Spherical harmonic coefficients

						SpLat = GribNumbers.int4(raf) * tenToNegSix;
						SpLon = GribNumbers.int4(raf) * tenToNegSix;
						Rotationangle = GribNumbers.IEEEfloat4(raf);
						PoleLat = GribNumbers.int4(raf) * tenToNegSix;
						PoleLon = GribNumbers.int4(raf) * tenToNegSix;
						factor = GribNumbers.int4(raf);
					}

					break;

				case 90: // Space view perspective or orthographic
					Shape = raf.ReadByte();

					scalefactorradius = raf.ReadByte();
					scaledvalueradius = GribNumbers.int4(raf);
					scalefactormajor = raf.ReadByte();
					scaledvaluemajor = GribNumbers.int4(raf);
					scalefactorminor = raf.ReadByte();
					scaledvalueminor = GribNumbers.int4(raf);
					Nx = GribNumbers.int4(raf);

					Ny = GribNumbers.int4(raf);

					lap = GribNumbers.int4(raf);
					lop = GribNumbers.int4(raf);
					Resolution = raf.ReadByte();
					Dx = GribNumbers.int4(raf);
					Dy = GribNumbers.int4(raf);
					Xp = (float)(GribNumbers.int4(raf) * tenToNegThree);
					Yp = (float)(GribNumbers.int4(raf) * tenToNegThree);
					ScanMode = raf.ReadByte();
					Angle = GribNumbers.int4(raf);
					altitude = GribNumbers.int4(raf) * 1000000;
					xo = GribNumbers.int4(raf);
					yo = GribNumbers.int4(raf);

					break;

				case 100: // Triangular grid based on an icosahedron

					N2 = raf.ReadByte();
					N3 = raf.ReadByte();
					Ni = GribNumbers.int2(raf);
					Nd = raf.ReadByte();
					PoleLat = GribNumbers.int4(raf) * tenToNegSix;
					PoleLon = GribNumbers.int4(raf) * tenToNegSix;
					lonofcenter = GribNumbers.int4(raf);
					Position = raf.ReadByte();
					Order = raf.ReadByte();
					ScanMode = raf.ReadByte();
					N = GribNumbers.int4(raf);
					break;

				case 110: // Equatorial azimuthal equidistant projection
					Shape = raf.ReadByte();

					scalefactorradius = raf.ReadByte();
					scaledvalueradius = GribNumbers.int4(raf);
					scalefactormajor = raf.ReadByte();
					scaledvaluemajor = GribNumbers.int4(raf);
					scalefactorminor = raf.ReadByte();
					scaledvalueminor = GribNumbers.int4(raf);
					Nx = GribNumbers.int4(raf);

					Ny = GribNumbers.int4(raf);

					La1 = GribNumbers.int4(raf) * tenToNegSix;
					Lo1 = GribNumbers.int4(raf) * tenToNegSix;
					Resolution = raf.ReadByte();
					Dx = (float)(GribNumbers.int4(raf) * tenToNegThree);
					Dy = (float)(GribNumbers.int4(raf) * tenToNegThree);
					ProjectionCenter = raf.ReadByte();
					ScanMode = raf.ReadByte();

					break;

				case 120: // Azimuth-range Projection
					Nb = GribNumbers.int4(raf);
					Nr = GribNumbers.int4(raf);
					La1 = GribNumbers.int4(raf);
					Lo1 = GribNumbers.int4(raf);
					Dx = GribNumbers.int4(raf);
					Dstart = GribNumbers.IEEEfloat4(raf);
					ScanMode = raf.ReadByte();
					for (int i = 0; i < Nr; i++)
					{
						// get azi (33+4(Nr-1))-(34+4(Nr-1))
						// get adelta (35+4(Nr-1))-(36+4(Nr-1))
					}

					Console.Out.WriteLine("need code to get azi and adelta");

					break;

				default:
					Console.Out.WriteLine("Unknown Grid Type " + Convert.ToString(Gdtn));
					break;
			} // end switch

			// calculate earth radius
			if ((Gdtn < 50 || Gdtn > 53) && Gdtn != 100 && Gdtn != 120)
			{
				if (Shape == 0)
				{
					EarthRadius = 6367470;
				}
				else if (Shape == 1)
				{
					EarthRadius = scaledvalueradius;
					if (scalefactorradius != 0)
						EarthRadius = (float)(EarthRadius / Math.Pow(10, scalefactorradius));
				}
				else if (Shape == 2)
				{
					//UPGRADE_WARNING: Data types in Visual C# might be different.  Verify the accuracy of narrowing conversions. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1042'"
					MajorAxis = (float)6378160.0;
					//UPGRADE_WARNING: Data types in Visual C# might be different.  Verify the accuracy of narrowing conversions. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1042'"
					MinorAxis = (float)6356775.0;
				}
				else if (Shape == 3)
				{
					MajorAxis = scaledvaluemajor;

					MajorAxis = (float)(MajorAxis / Math.Pow(10, scalefactormajor));

					MinorAxis = scaledvalueminor;

					MinorAxis = (float)(MinorAxis / Math.Pow(10, scalefactorminor));
				}
				else if (Shape == 4)
				{
					//UPGRADE_WARNING: Data types in Visual C# might be different.  Verify the accuracy of narrowing conversions. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1042'"
					MajorAxis = (float)6378137.0;
					MinorAxis = (float)SupportClass.Identity(6356752.314);
				}
				else if (Shape == 6)
				{
					EarthRadius = 6371229;
				}
			}
		} // end of Grib2GridDefinitionSection

		/// <summary> Constructs a <tt>Grib2GridDefinitionSection</tt> object from a raf.
		/// 
		/// </summary>
		/// <param name="raf">RandomAccessFile
		/// </param>
		/// <param name="doCheckSum"> calculate the checksum
		/// </param>
		/// <throws>  IOException  if raf contains no valid GRIB product </throws>
		//UPGRADE_TODO: Class 'java.io.RandomAccessFile' was converted to 'System.IO.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioRandomAccessFile'"
		internal Grib2GridDefinitionSection(BufferedBinaryReader reader)
		{
			int scalefactorradius = 0;
			long scaledvalueradius = 0;
			int scalefactormajor = 0;
			long scaledvaluemajor = 0;
			int scalefactorminor = 0;
			long scaledvalueminor = 0;

			// octets 1-4 (Length of GDS)
			Length = (int)reader.ReadUInt32();

			Section = reader.ReadUInt8(); // This is section 3

			if (Section != 3)
			{
				throw new NoValidGribException("Expected section 3");
			}

			Source = reader.ReadUInt8();

			NumberPoints = reader.ReadUInt32();

			Olon = reader.ReadUInt8();

			Iolon = reader.ReadUInt8();

			Gdtn = reader.ReadUInt16();

			Name = getGridName(Gdtn);

			float ratio;

			switch (Gdtn)
			{
				// Grid Definition Template Number
				case 0:
				case 1:
				case 2:
				case 3: // Latitude/Longitude Grid
					Shape = reader.ReadUInt8();

					scalefactorradius = reader.ReadUInt8();
					scaledvalueradius = reader.ReadUInt32();
					scalefactormajor = reader.ReadUInt8();
					scaledvaluemajor = reader.ReadUInt32();
					scalefactorminor = reader.ReadUInt8();
					scaledvalueminor = reader.ReadUInt32();
					Nx = reader.ReadUInt32();

					Ny = reader.ReadUInt32();

					Angle = reader.ReadUInt32();
					Subdivisionsangle = reader.ReadUInt32();
					if (Angle == 0)
					{
						ratio = tenToNegSix;
					}
					else
					{
						ratio = Angle / (float)Subdivisionsangle;
					}

					La1 = (float)(reader.ReadUInt32() * ratio);
					Lo1 = (float)(reader.ReadUInt32() * ratio);
					Resolution = reader.ReadUInt8();
					La2 = (float)(reader.ReadUInt32() * ratio);
					Lo2 = (float)(reader.ReadUInt32() * ratio);
					Dx = (float)(reader.ReadUInt32() * ratio);
					Dy = (float)(reader.ReadUInt32() * ratio);
					ScanMode = reader.ReadUInt8();

					//  1, 2, and 3 needs checked
					if (Gdtn == 1)
					{
						//Rotated Latitude/longitude
						SpLat = reader.ReadUInt32() * tenToNegSix;
						SpLon = reader.ReadUInt32() * tenToNegSix;
						Rotationangle = reader.ReadSingle();
					}
					else if (Gdtn == 2)
					{
						//Stretched Latitude/longitude
						PoleLat = reader.ReadUInt32() * tenToNegSix;
						PoleLon = reader.ReadUInt32() * tenToNegSix;
						factor = reader.ReadUInt32();
					}
					else if (Gdtn == 3)
					{
						//Stretched and Rotated 
						// Latitude/longitude
						SpLat = reader.ReadUInt32() * tenToNegSix;
						SpLon = reader.ReadUInt32() * tenToNegSix;
						Rotationangle = reader.ReadSingle();
						PoleLat = reader.ReadUInt32() * tenToNegSix;
						PoleLon = reader.ReadUInt32() * tenToNegSix;
						factor = reader.ReadUInt32();
					}

					break;

				case 10: // Mercator
								 // la1, lo1, lad, la2, and lo2 need checked
					Shape = reader.ReadUInt8();

					scalefactorradius = reader.ReadUInt8();
					scaledvalueradius = reader.ReadUInt32();
					scalefactormajor = reader.ReadUInt8();
					scaledvaluemajor = reader.ReadUInt32();
					scalefactorminor = reader.ReadUInt8();
					scaledvalueminor = reader.ReadUInt32();
					Nx = reader.ReadUInt32();

					Ny = reader.ReadUInt32();

					La1 = reader.ReadUInt32() * tenToNegSix;
					Lo1 = reader.ReadUInt32() * tenToNegSix;
					Resolution = reader.ReadUInt8();
					Lad = reader.ReadUInt32() * tenToNegSix;
					La2 = reader.ReadUInt32() * tenToNegSix;
					Lo2 = reader.ReadUInt32() * tenToNegSix;
					ScanMode = reader.ReadUInt8();
					Angle = reader.ReadUInt32();
					Dx = (float)(reader.ReadUInt32() * tenToNegThree);
					Dy = (float)(reader.ReadUInt32() * tenToNegThree);

					break;

				case 20: // Polar stereographic projection
								 // la1, lo1, lad, and lov need checked
					Shape = reader.ReadUInt8();

					scalefactorradius = reader.ReadUInt8();
					scaledvalueradius = reader.ReadUInt32();
					scalefactormajor = reader.ReadUInt8();
					scaledvaluemajor = reader.ReadUInt32();
					scalefactorminor = reader.ReadUInt8();
					scaledvalueminor = reader.ReadUInt32();
					Nx = reader.ReadUInt32();

					Ny = reader.ReadUInt32();

					La1 = reader.ReadUInt32() * tenToNegSix;
					Lo1 = reader.ReadUInt32() * tenToNegSix;
					Resolution = reader.ReadUInt8();
					Lad = reader.ReadUInt32() * tenToNegSix;
					Lov = reader.ReadUInt32() * tenToNegSix;
					Dx = (float)(reader.ReadUInt32() * tenToNegThree);
					Dy = (float)(reader.ReadUInt32() * tenToNegThree);
					ProjectionCenter = reader.ReadUInt8();
					ScanMode = reader.ReadUInt8();

					break;

				case 30: // Lambert Conformal
					Shape = reader.ReadUInt8();

					scalefactorradius = reader.ReadUInt8();
					scaledvalueradius = reader.ReadUInt32();
					scalefactormajor = reader.ReadUInt8();
					scaledvaluemajor = reader.ReadUInt32();
					scalefactorminor = reader.ReadUInt8();
					scaledvalueminor = reader.ReadUInt32();
					Nx = reader.ReadUInt32();

					Ny = reader.ReadUInt32();

					La1 = (float)(reader.ReadUInt32() * tenToNegSix);

					Lo1 = (float)(reader.ReadUInt32() * tenToNegSix);

					Resolution = reader.ReadUInt8();
					Lad = (float)(reader.ReadUInt32() * tenToNegSix);
					Lov = (float)(reader.ReadUInt32() * tenToNegSix);
					Dx = (float)(reader.ReadUInt32() * tenToNegThree);
					Dy = (float)(reader.ReadUInt32() * tenToNegThree);
					ProjectionCenter = reader.ReadUInt8();
					ScanMode = reader.ReadUInt8();
					Latin1 = (float)(reader.ReadUInt32() * tenToNegSix);
					Latin2 = (float)(reader.ReadUInt32() * tenToNegSix);

					SpLat = (float)(reader.ReadUInt32() * tenToNegSix);
					SpLon = (float)(reader.ReadUInt32() * tenToNegSix);

					break;

				case 31: // Albers Equal Area
								 // la1, lo1, lad, and lov need checked
					Shape = reader.ReadUInt8();

					scalefactorradius = reader.ReadUInt8();
					scaledvalueradius = reader.ReadUInt32();
					scalefactormajor = reader.ReadUInt8();
					scaledvaluemajor = reader.ReadUInt32();
					scalefactorminor = reader.ReadUInt8();
					scaledvalueminor = reader.ReadUInt32();
					Nx = reader.ReadUInt32();

					Ny = reader.ReadUInt32();

					La1 = reader.ReadUInt32() * tenToNegSix;

					Lo1 = reader.ReadUInt32() * tenToNegSix;

					Resolution = reader.ReadUInt8();
					Lad = reader.ReadUInt32() * tenToNegSix;
					Lov = reader.ReadUInt32() * tenToNegSix;
					Dx = (float)(reader.ReadUInt32() * tenToNegThree);
					Dy = (float)(reader.ReadUInt32() * tenToNegThree);
					ProjectionCenter = reader.ReadUInt8();
					ScanMode = reader.ReadUInt8();
					Latin1 = reader.ReadUInt32() * tenToNegSix;
					Latin2 = reader.ReadUInt32() * tenToNegSix;

					SpLat = reader.ReadUInt32() * tenToNegSix;
					SpLon = reader.ReadUInt32() * tenToNegSix;

					break;

				case 40:
				case 41:
				case 42:
				case 43: // Gaussian latitude/longitude
					Shape = reader.ReadUInt8();

					scalefactorradius = reader.ReadUInt8();
					scaledvalueradius = reader.ReadUInt32();
					scalefactormajor = reader.ReadUInt8();
					scaledvaluemajor = reader.ReadUInt32();
					scalefactorminor = reader.ReadUInt8();
					scaledvalueminor = reader.ReadUInt32();
					Nx = reader.ReadUInt32();

					Ny = reader.ReadUInt32();

					Angle = reader.ReadUInt32();
					Subdivisionsangle = reader.ReadUInt32();
					if (Angle == 0)
					{
						ratio = tenToNegSix;
					}
					else
					{
						ratio = Angle / Subdivisionsangle;
					}

					La1 = (float)(reader.ReadUInt32() * ratio);
					Lo1 = (float)(reader.ReadUInt32() * ratio);
					Resolution = reader.ReadUInt8();
					La2 = (float)(reader.ReadUInt32() * ratio);
					Lo2 = (float)(reader.ReadUInt32() * ratio);
					Dx = (float)(reader.ReadUInt32() * ratio);
					N = reader.ReadUInt8();
					ScanMode = reader.ReadUInt8();

					if (Gdtn == 41)
					{
						//Rotated Gaussian Latitude/longitude

						SpLat = reader.ReadUInt32() * ratio;
						SpLon = reader.ReadUInt32() * ratio;
						Rotationangle = reader.ReadSingle();
					}
					else if (Gdtn == 42)
					{
						//Stretched Gaussian 
						// Latitude/longitude

						PoleLat = reader.ReadUInt32() * ratio;
						PoleLon = reader.ReadUInt32() * ratio;
						factor = reader.ReadUInt32();
					}
					else if (Gdtn == 43)
					{
						//Stretched and Rotated Gaussian  
						// Latitude/longitude

						SpLat = reader.ReadUInt32() * ratio;
						SpLon = reader.ReadUInt32() * ratio;
						Rotationangle = reader.ReadSingle();
						PoleLat = reader.ReadUInt32() * ratio;
						PoleLon = reader.ReadUInt32() * ratio;
						factor = reader.ReadUInt32();
					}

					break;

				case 50:
				case 51:
				case 52:
				case 53: // Spherical harmonic coefficients

					J = reader.ReadSingle();
					K = reader.ReadSingle();
					M = reader.ReadSingle();
					Method = reader.ReadUInt8();
					Mode = reader.ReadUInt8();
					if (Gdtn == 51)
					{
						//Rotated Spherical harmonic coefficients

						SpLat = reader.ReadUInt32() * tenToNegSix;
						SpLon = reader.ReadUInt32() * tenToNegSix;
						Rotationangle = reader.ReadSingle();
					}
					else if (Gdtn == 52)
					{
						//Stretched Spherical 
						// harmonic coefficients

						PoleLat = reader.ReadUInt32() * tenToNegSix;
						PoleLon = reader.ReadUInt32() * tenToNegSix;
						factor = reader.ReadUInt32();
					}
					else if (Gdtn == 53)
					{
						//Stretched and Rotated 
						// Spherical harmonic coefficients

						SpLat = reader.ReadUInt32() * tenToNegSix;
						SpLon = reader.ReadUInt32() * tenToNegSix;
						Rotationangle = reader.ReadSingle();
						PoleLat = reader.ReadUInt32() * tenToNegSix;
						PoleLon = reader.ReadUInt32() * tenToNegSix;
						factor = reader.ReadUInt32();
					}

					break;

				case 90: // Space view perspective or orthographic
					Shape = reader.ReadUInt8();

					scalefactorradius = reader.ReadUInt8();
					scaledvalueradius = reader.ReadUInt32();
					scalefactormajor = reader.ReadUInt8();
					scaledvaluemajor = reader.ReadUInt32();
					scalefactorminor = reader.ReadUInt8();
					scaledvalueminor = reader.ReadUInt32();
					Nx = reader.ReadUInt32();

					Ny = reader.ReadUInt32();

					lap = reader.ReadUInt32();
					lop = reader.ReadUInt32();
					Resolution = reader.ReadUInt8();
					Dx = reader.ReadUInt32();
					Dy = reader.ReadUInt32();
					Xp = (float)(reader.ReadUInt32() * tenToNegThree);
					Yp = (float)(reader.ReadUInt32() * tenToNegThree);
					ScanMode = reader.ReadUInt8();
					Angle = reader.ReadUInt32();
					altitude = reader.ReadUInt32() * 1000000;
					xo = reader.ReadUInt32();
					yo = reader.ReadUInt32();

					break;

				case 100: // Triangular grid based on an icosahedron

					N2 = reader.ReadUInt8();
					N3 = reader.ReadUInt8();
					Ni = reader.ReadUInt16();
					Nd = reader.ReadUInt8();
					PoleLat = reader.ReadUInt32() * tenToNegSix;
					PoleLon = reader.ReadUInt32() * tenToNegSix;
					lonofcenter = reader.ReadUInt32();
					Position = reader.ReadUInt8();
					Order = reader.ReadUInt8();
					ScanMode = reader.ReadUInt8();
					N = reader.ReadUInt32();
					break;

				case 110: // Equatorial azimuthal equidistant projection
					Shape = reader.ReadUInt8();

					scalefactorradius = reader.ReadUInt8();
					scaledvalueradius = reader.ReadUInt32();
					scalefactormajor = reader.ReadUInt8();
					scaledvaluemajor = reader.ReadUInt32();
					scalefactorminor = reader.ReadUInt8();
					scaledvalueminor = reader.ReadUInt32();
					Nx = reader.ReadUInt32();

					Ny = reader.ReadUInt32();

					La1 = reader.ReadUInt32() * tenToNegSix;
					Lo1 = reader.ReadUInt32() * tenToNegSix;
					Resolution = reader.ReadUInt8();
					Dx = (float)(reader.ReadUInt32() * tenToNegThree);
					Dy = (float)(reader.ReadUInt32() * tenToNegThree);
					ProjectionCenter = reader.ReadUInt8();
					ScanMode = reader.ReadUInt8();

					break;

				case 120: // Azimuth-range Projection
					Nb = reader.ReadUInt32();
					Nr = reader.ReadUInt32();
					La1 = reader.ReadUInt32();
					Lo1 = reader.ReadUInt32();
					Dx = reader.ReadUInt32();
					Dstart = reader.ReadSingle();
					ScanMode = reader.ReadUInt8();
					for (int i = 0; i < Nr; i++)
					{
						// get azi (33+4(Nr-1))-(34+4(Nr-1))
						// get adelta (35+4(Nr-1))-(36+4(Nr-1))
					}

					Console.Out.WriteLine("need code to get azi and adelta");

					break;

				default:
					Console.Out.WriteLine("Unknown Grid Type " + Convert.ToString(Gdtn));
					break;
			} // end switch

			// calculate earth radius
			if ((Gdtn < 50 || Gdtn > 53) && Gdtn != 100 && Gdtn != 120)
			{
				if (Shape == 0)
				{
					EarthRadius = 6367470;
				}
				else if (Shape == 1)
				{
					EarthRadius = scaledvalueradius;
					if (scalefactorradius != 0)
						EarthRadius = (float)(EarthRadius / Math.Pow(10, scalefactorradius));
				}
				else if (Shape == 2)
				{
					//UPGRADE_WARNING: Data types in Visual C# might be different.  Verify the accuracy of narrowing conversions. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1042'"
					MajorAxis = (float)6378160.0;
					//UPGRADE_WARNING: Data types in Visual C# might be different.  Verify the accuracy of narrowing conversions. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1042'"
					MinorAxis = (float)6356775.0;
				}
				else if (Shape == 3)
				{
					MajorAxis = scaledvaluemajor;

					MajorAxis = (float)(MajorAxis / Math.Pow(10, scalefactormajor));

					MinorAxis = scaledvalueminor;

					MinorAxis = (float)(MinorAxis / Math.Pow(10, scalefactorminor));
				}
				else if (Shape == 4)
				{
					//UPGRADE_WARNING: Data types in Visual C# might be different.  Verify the accuracy of narrowing conversions. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1042'"
					MajorAxis = (float)6378137.0;
					MinorAxis = (float)SupportClass.Identity(6356752.314);
				}
				else if (Shape == 6)
				{
					EarthRadius = 6371229;
				}
			}
		} // end of Grib2GridDefinitionSection

		/// <summary> .</summary>
		/// <param name="gdtn"> Grid definition template number same as type of grid
		/// </param>
		/// <returns> GridName as a String
		/// 
		/// </returns>
		public static string getGridName(int gdtn)
		{
			switch (gdtn)
			{
				// code table 3.2
				case 0: return "Latitude/Longitude";

				case 1: return "Rotated Latitude/Longitude";

				case 2: return "Stretched Latitude/Longitude";

				case 3: return "iStretched and Rotated Latitude/Longitude";

				case 10: return "Mercator";

				case 20: return "Polar stereographic";

				case 30: return "Lambert Conformal";

				case 31: return "Albers Equal Area";

				case 40: return "Gaussian latitude/longitude";

				case 41: return "Rotated Gaussian Latitude/longitude";

				case 42: return "Stretched Gaussian Latitude/longitude";

				case 43: return "Stretched and Rotated Gaussian Latitude/longitude";

				case 50: return "Spherical harmonic coefficients";

				case 51: return "Rotated Spherical harmonic coefficients";

				case 52: return "Stretched Spherical harmonic coefficients";

				case 53: return "Stretched and Rotated Spherical harmonic coefficients";

				case 90: return "Space View Perspective or Orthographic";

				case 100: return "Triangular Grid Based on an Icosahedron";

				case 110: return "Equatorial Azimuthal Equidistant";

				case 120: return "Azimuth-Range";

				default: return "Unknown projection" + gdtn;
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
		public string getShapeName()
		{
			return getShapeName(Shape);
		}

		/// <summary> .</summary>
		/// <param name="shape">
		/// </param>
		/// <returns> shapeName as a String
		/// 
		/// </returns>
		static public string getShapeName(int shape)
		{
			switch (shape)
			{
				// code table 3.2
				case 0: return "Earth spherical with radius = 6367470 m";

				case 1: return "Earth spherical with radius specified by producer";

				case 2: return "Earth oblate spheroid with major axis = 6378160.0 m and minor axis = 6356775.0 m";

				case 3: return "Earth oblate spheroid with axes specified by producer";

				case 4: return "Earth oblate spheroid with major axis = 6378137.0 m and minor axis = 6356752.314 m";

				case 5: return "Earth represent by WGS84";

				case 6: return "Earth spherical with radius of 6371229.0 m";

				default: return "Unknown Earth Shape";
			}
		}
	} // end Grib2GridDefinitionSection
}