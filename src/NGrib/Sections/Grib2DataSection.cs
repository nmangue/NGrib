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
	
	/// <summary> A class that represents the DataSection of a GRIB product.
	/// 
	/// </summary>
	public sealed class Grib2DataSection
	{
		/// <summary> Grib2 data unpacked as floats.</summary>
		/// <returns> data
		/// </returns>
		public float[] Data { get; private set; }

		/// <summary> Length in bytes of DataSection section.</summary>
		private readonly int length;
		
		/// <summary> Number of this section, should be 7.</summary>
		//UPGRADE_NOTE: Final was removed from the declaration of 'section '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private int section;

		/// <summary> Buffer for one byte which will be processed bit by bit.</summary>
		private int bitBuf = 0;
		
		/// <summary> Current bit position in <tt>bitBuf</tt>.</summary>
		private int bitPos = 0;
		private int scanMode;
		private int count; // raw data count
		private int Xlength; // length of the x axis
		
		// *** constructors *******************************************************
		
		/// <summary> Constructor for a Grib2 Data Section.</summary>
		/// <param name="getData">
		/// </param>
		/// <param name="raf">
		/// </param>
		/// <param name="gds">
		/// </param>
		/// <param name="drs">
		/// </param>
		/// <param name="bms">
		/// </param>
		/// <throws>  IOException </throws>
		//UPGRADE_TODO: Class 'java.io.RandomAccessFile' was converted to 'System.IO.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioRandomAccessFile'"
		public Grib2DataSection(bool getData, FileStream raf, Grib2GridDefinitionSection gds, Grib2DataRepresentationSection drs, Grib2BitMapSection bms)
		{
			//System.out.println( "raf.FilePointer=" + raf.FilePointer() );
			// octets 1-4 (Length of DS)
			length = GribNumbers.int4(raf);
			//System.out.println( "DS length=" + length );
			//System.out.println( "DS calculated end=" + ( raf.getFilePointer() + length -4 ));
			// octet 5  section 7
			section = raf.ReadByte();
			//System.out.println( "DS is 7, section=" + section );
			if (!getData)
			{
				// skip data read
				//System.out.println( "raf.position before reposition="+raf.getFilePointer());
				//System.out.println( "raf.length=" + raf.length() );
				// sanity check for erronous ds length
				if (length > 0 && length < raf.Length)
				{
					SupportClass.Skip(raf, length - 5);
					//System.out.println( "raf.skipBytes = " + (length -5) );
				}
				else
				{
					length = 5; // only read length and section
				}
				//System.out.println( "raf.position after skip=" + raf.getFilePointer() );
				return ;
			}
			int dtn = drs.DataTemplateNumber;
			//System.out.println( "DS dtn=" + dtn );
			if (dtn == 0 || dtn == 1)
			{
				// 0: Grid point data - simple packing
				// 1: Matrix values - simple packing
				simpleUnpacking(raf, gds, drs, bms);
			}
			else if (dtn == 2)
			{
				// 2:Grid point data - complex packing
				complexUnpacking(raf, gds, drs);
			}
			else if (dtn == 3)
			{
				// 3: complex packing with spatial differencing
				complexUnpackingWithSpatial(raf, gds, drs);
			}
			else if (dtn == 40 || dtn == 40000)
			{
				// JPEG 2000 Stream Format
				//jpeg2000Unpacking(raf, gds, drs, bms);
				throw new NotSupportedException();
			}
		} // end Grib2DataSection
		
		/// <summary> simple Unpacking method for Grib2 data.</summary>
		/// <param name="raf">
		/// </param>
		/// <param name="gds">
		/// </param>
		/// <param name="drs">
		/// </param>
		/// <param name="bms">
		/// </param>
		/// <throws>  IOException </throws>
		//UPGRADE_TODO: Class 'java.io.RandomAccessFile' was converted to 'System.IO.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioRandomAccessFile'"
		private void  simpleUnpacking(FileStream raf, Grib2GridDefinitionSection gds, Grib2DataRepresentationSection drs, Grib2BitMapSection bms)
		{
			int dtn = drs.DataTemplateNumber;
			//System.out.println( "DS dtn=" + dtn );
			
			if (dtn == 1)
			{
				// Matrix values
				Console.Out.WriteLine("DS Matrix values not supported yet");
				return ;
			}
			// dataPoints are number of points encoded, it could be less than the
			// numberPoints in the grid record if bitMap is used, otherwise equal
			int dataPoints = drs.DataPoints;
			//System.out.println( "DS DRS dataPoints=" + drs.getDataPoints() );
			float pmv = drs.PrimaryMissingValue;
			//System.out.println( "DS pmv=" + pmv );
			int nb = drs.NumberOfBits;
			//System.out.println( "DS nb=" + nb );
			int D = drs.DecimalScaleFactor;
			//System.out.println( "DS D=" + D );
			//UPGRADE_WARNING: Data types in Visual C# might be different.  Verify the accuracy of narrowing conversions. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1042'"
			float DD = (float) Math.Pow((double) 10, (double) D);
			//System.out.println( "DS DD=" + DD );
			float R = drs.ReferenceValue;
			//System.out.println( "DS R=" + R );
			int E = drs.BinaryScaleFactor;
			//System.out.println( "DS E=" + E );
			//UPGRADE_WARNING: Data types in Visual C# might be different.  Verify the accuracy of narrowing conversions. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1042'"
			float EE = (float) Math.Pow((double) 2.0, (double) E);
			//System.out.println( "DS EE=" + EE );
			
			int numberPoints = gds.NumberPoints;
			//System.out.println( "DS GDS NumberPoints=" +  gds.getNumberPoints() );
			Data = new float[numberPoints];
			
			bool[] bitmap = bms.Bitmap;
			
			//  Y * 10**D = R + (X1 + X2) * 2**E
			//   E = binary scale factor
			//   D = decimal scale factor
			//   R = reference value
			//   X1 = 0
			//   X2 = scaled encoded value
			//   data[ i ] = (R + ( X1 + X2) * EE)/DD ;
			
			if (bitmap == null)
			{
				for (int i = 0; i < numberPoints; i++)
				{
					//data[ i ] = (R + ( X1 + X2) * EE)/DD ;
					Data[i] = (R + bits2UInt(nb, raf) * EE) / DD;
				}
			}
			else
			{
				bitPos = 0;
				bitBuf = 0;
				for (int i = 0; i < bitmap.Length; i++)
				{
					if (bitmap[i])
					{
						//data[ i ] = (R + ( X1 + X2) * EE)/DD ;
						Data[i] = (R + bits2UInt(nb, raf) * EE) / DD;
					}
					else
					{
						Data[i] = pmv;
					}
				}
			}
			scanMode = gds.ScanMode;
			Xlength = gds.Nx; // needs some smarts for different type Grids
			//scanningModeCheck();
		} // end simpleUnpacking
		
		/// <summary> complex unpacking of Grib2 data.</summary>
		/// <param name="raf">
		/// </param>
		/// <param name="gds">
		/// </param>
		/// <param name="drs">
		/// </param>
		/// <throws>  IOException </throws>
		//UPGRADE_TODO: Class 'java.io.RandomAccessFile' was converted to 'System.IO.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioRandomAccessFile'"
		private void  complexUnpacking(FileStream raf, Grib2GridDefinitionSection gds, Grib2DataRepresentationSection drs)
		{
			int mvm = drs.MissingValueManagement;
			//System.out.println( "DS mvm=" + mvm );
			
			float pmv = drs.PrimaryMissingValue;
			//System.out.println( "DS pmv=" + pmv );
			
			int NG = drs.NumberOfGroups;
			//System.out.println( "DS NG=" + NG );
			
			// 6-xx  Get reference values for groups (X1's)
			int[] X1 = new int[NG];
			int nb = drs.NumberOfBits;
			//System.out.println( "DS nb=" + nb );
			bitPos = 0;
			bitBuf = 0;
			for (int i = 0; i < NG; i++)
			{
				X1[i] = bits2UInt(nb, raf);
				//System.out.println( "DS X1[ i ]=" + X1[ i ] );
			}
			
			// [xx +1 ]-yy Get number of bits used to encode each group
			int[] NB = new int[NG];
			nb = drs.BitsGroupWidths;
			//System.out.println( "DS nb=" + nb );
			bitPos = 0;
			bitBuf = 0;
			for (int i = 0; i < NG; i++)
			{
				NB[i] = bits2UInt(nb, raf);
				//System.out.println( "DS NB[ i ]=" + NB[ i ] );
			}
			
			// [yy +1 ]-zz Get the scaled group lengths using formula
			//     Ln = ref + Kn * len_inc, where n = 1-NG,
			//          ref = referenceGroupLength, and  len_inc = lengthIncrement
			
			int[] L = new int[NG];
			int countL = 0;
			int ref_Renamed = drs.ReferenceGroupLength;
			//System.out.println( "DS ref=" + ref );
			int len_inc = drs.LengthIncrement;
			//System.out.println( "DS len_inc=" + len_inc );
			nb = drs.BitsScaledGroupLength;
			//System.out.println( "DS nb=" + nb );
			bitPos = 0;
			bitBuf = 0;
			for (int i = 0; i < NG; i++)
			{
				// NG
				L[i] = ref_Renamed + (bits2UInt(nb, raf) * len_inc);
				//System.out.println( "DS L[ i ]=" + L[ i ] );
				countL += L[i];
			}
			//System.out.println( "DS countL=" + countL );
			
			// [zz +1 ]-nn get X2 values and calculate the results Y using formula
			//                Y * 10**D = R + (X1 + X2) * 2**E
			
			int D = drs.DecimalScaleFactor;
			//System.out.println( "DS D=" + D );
			//UPGRADE_WARNING: Data types in Visual C# might be different.  Verify the accuracy of narrowing conversions. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1042'"
			float DD = (float) Math.Pow((double) 10, (double) D);
			//System.out.println( "DS DD=" + DD );
			
			float R = drs.ReferenceValue;
			//System.out.println( "DS R=" + R );
			
			int E = drs.BinaryScaleFactor;
			//System.out.println( "DS E=" + E );
			//UPGRADE_WARNING: Data types in Visual C# might be different.  Verify the accuracy of narrowing conversions. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1042'"
			float EE = (float) Math.Pow((double) 2.0, (double) E);
			//System.out.println( "DS EE=" + EE );
			
			Data = new float[countL];
			//System.out.println( "DS countL=" + countL + " dataPoints=" +
			//gds.getNumberPoints() );
			count = 0;
			Xlength = gds.Nx; // needs some smarts for different type Grids
			// used to check missing values when X2 is packed with all 1's
			int[] bitsmv1 = new int[31];
			//int bitsmv2[] = new int[ 31 ]; didn't code cuz number larger the # of bits
			for (int i = 0; i < 31; i++)
			{
				//bitsmv1[ i ] = ( bitsmv1[ i -1 ] +1 ) *2 -1;
				//bitsmv2[ i ] = ( bitsmv2[ i -1 ] +2 ) *2 -2;
				//UPGRADE_WARNING: Data types in Visual C# might be different.  Verify the accuracy of narrowing conversions. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1042'"
				bitsmv1[i] = (int) Math.Pow((double) 2, (double) i) - 1;
				//bitsmv2[ i ] = (int) java.lang.Math.pow( (double)2, (double)i +1) -2;
				//System.out.println( "DS bitsmv1[ "+ i +" ] =" + bitsmv1[ i ] );
				//System.out.println( "DS bitsmv2[ "+ i +" ] =" + bitsmv2[ i ] );
			}
			int X2;
			bitPos = 0;
			bitBuf = 0;
			for (int i = 0; i < NG - 1; i++)
			{
				//System.out.println( "DS NB[ i ]=" + NB[ i ] );
				//System.out.println( "DS L[ i ]=" + L[ i ] );
				//System.out.println( "DS X1[ i ]=" + X1[ i ] );
				for (int j = 0; j < L[i]; j++)
				{
					if (NB[i] == 0)
					{
						if (mvm == 0)
						{
							// X2 = 0
							Data[count++] = (R + X1[i] * EE) / DD;
						}
						else if (mvm == 1)
						{
							Data[count++] = pmv;
						}
					}
					else
					{
						X2 = bits2UInt(NB[i], raf);
						if (mvm == 0)
						{
							Data[count++] = (R + (X1[i] + X2) * EE) / DD;
						}
						else if (mvm == 1)
						{
							// X2 is also set to missing value is all bits set to 1's
							if (X2 == bitsmv1[NB[i]])
							{
								Data[count++] = pmv;
							}
							else
							{
								Data[count++] = (R + (X1[i] + X2) * EE) / DD;
							}
						}
						//System.out.println( "DS count=" + count );
						//System.out.println( "DS NB[ "+ i +" ]=" + NB[ i ] );
						//System.out.println( "DS X1[ "+ i +" ]=" + X1[ i ] );
						//System.out.println( "DS X2 =" +X2 );
						//System.out.println( "DS X1[ i ] + X2 ="+(X1[ i ]+X2) );
					}
				} // end for j
			} // end for i
			// process last group
			int last = drs.LengthLastGroup;
			//System.out.println( "DS last=" + last );
			for (int j = 0; j < last; j++)
			{
				// last group
				if (NB[NG - 1] == 0)
				{
					if (mvm == 0)
					{
						// X2 = 0
						Data[count++] = (R + X1[NG - 1] * EE) / DD;
					}
					else if (mvm == 1)
					{
						Data[count++] = pmv;
					}
				}
				else
				{
					X2 = bits2UInt(NB[NG - 1], raf);
					if (mvm == 0)
					{
						Data[count++] = (R + (X1[NG - 1] + X2) * EE) / DD;
					}
					else if (mvm == 1)
					{
						// X2 is also set to missing value is all bits set to 1's
						if (X2 == bitsmv1[NB[NG - 1]])
						{
							Data[count++] = pmv;
						}
						else
						{
							Data[count++] = (R + (X1[NG - 1] + X2) * EE) / DD;
						}
					}
				}
			} // end for j
			scanMode = gds.ScanMode;
			scanningModeCheck();
			//System.out.println( "DS true end =" + raf.position() );
		} // end complexUnpacking
		
		/// <summary> complex unpacking method for spatial data.</summary>
		/// <param name="raf">
		/// </param>
		/// <param name="gds">
		/// </param>
		/// <param name="drs">
		/// </param>
		/// <throws>  IOException </throws>
		//UPGRADE_TODO: Class 'java.io.RandomAccessFile' was converted to 'System.IO.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioRandomAccessFile'"
		private void  complexUnpackingWithSpatial(FileStream raf, Grib2GridDefinitionSection gds, Grib2DataRepresentationSection drs)
		{
			int mvm = drs.MissingValueManagement;
			//System.out.println( "DS mvm=" + mvm );
			
			float pmv = drs.PrimaryMissingValue;
			//System.out.println( "DS pmv=" + pmv );
			
			int NG = drs.NumberOfGroups;
			//System.out.println( "DS NG=" + NG );
			
			int g1 = 0, gMin = 0, h1 = 0, h2 = 0, hMin = 0;
			// [6-ww]   1st values of undifferenced scaled values and minimums
			int os = drs.OrderSpatial;
			int ds = drs.DescriptorSpatial;
			//System.out.println( "DS os=" + os +" ds =" + ds );
			bitPos = 0;
			bitBuf = 0;
			int sign;
			// ds is number of bytes, convert to bits -1 for sign bit
			ds = ds * 8 - 1;
			if (os == 1)
			{
				// first order spatial differencing g1 and gMin
				sign = bits2UInt(1, raf);
				g1 = bits2UInt(ds, raf);
				if (sign == 1)
				{
					g1 *= (- 1);
				}
				sign = bits2UInt(1, raf);
				gMin = bits2UInt(ds, raf);
				if (sign == 1)
				{
					gMin *= (- 1);
				}
			}
			else if (os == 2)
			{
				//second order spatial differencing h1, h2, hMin
				sign = bits2UInt(1, raf);
				h1 = bits2UInt(ds, raf);
				if (sign == 1)
				{
					h1 *= (- 1);
				}
				sign = bits2UInt(1, raf);
				h2 = bits2UInt(ds, raf);
				if (sign == 1)
				{
					h2 *= (- 1);
				}
				sign = bits2UInt(1, raf);
				hMin = bits2UInt(ds, raf);
				if (sign == 1)
				{
					hMin *= (- 1);
				}
				//System.out.println( "DS ds ="+ ds +" h1=" + h1 +" h2 =" + h2 + " hMin=" + hMin );
			}
			else
			{
				Console.Out.WriteLine("DS error os=" + os + " ds =" + ds);
				return ;
			}
			
			// [ww +1]-xx  Get reference values for groups (X1's)
			int[] X1 = new int[NG];
			int nb = drs.NumberOfBits;
			//System.out.println( "DS nb=" + nb );
			bitPos = 0;
			bitBuf = 0;
			for (int i = 0; i < NG; i++)
			{
				X1[i] = bits2UInt(nb, raf);
				//System.out.println( "DS X1[ i ]=" + X1[ i ] );
			}
			
			// [xx +1 ]-yy Get number of bits used to encode each group
			int[] NB = new int[NG];
			nb = drs.BitsGroupWidths;
			//System.out.println( "DS nb=" + nb );
			bitPos = 0;
			bitBuf = 0;
			for (int i = 0; i < NG; i++)
			{
				NB[i] = bits2UInt(nb, raf);
				//System.out.println( "DS NB[ i ]=" + NB[ i ] );
			}
			
			// [yy +1 ]-zz Get the scaled group lengths using formula
			//     Ln = ref + Kn * len_inc, where n = 1-NG,
			//          ref = referenceGroupLength, and  len_inc = lengthIncrement
			
			int[] L = new int[NG];
			int countL = 0;
			int ref_Renamed = drs.ReferenceGroupLength;
			//System.out.println( "DS ref=" + ref );
			int len_inc = drs.LengthIncrement;
			//System.out.println( "DS len_inc=" + len_inc );
			nb = drs.BitsScaledGroupLength;
			//System.out.println( "DS nb=" + nb );
			bitPos = 0;
			bitBuf = 0;
			for (int i = 0; i < NG; i++)
			{
				// NG
				L[i] = ref_Renamed + (bits2UInt(nb, raf) * len_inc);
				//System.out.println( "DS L[ i ]=" + L[ i ] );
				countL += L[i];
			}
			//System.out.println( "DS countL=" + countL );
			
			// [zz +1 ]-nn get X2 values and add X1[ i ] + X2
			
			Data = new float[countL];
			//System.out.println( "DS countL=" + countL + " dataPoints=" +
			//gds.getNumberPoints() );
			// used to check missing values when X2 is packed with all 1's
			int[] bitsmv1 = new int[31];
			//int bitsmv2[] = new int[ 31 ]; didn't code cuz number larger the # of bits
			for (int i = 0; i < 31; i++)
			{
				//bitsmv1[ i ] = ( bitsmv1[ i -1 ] +1 ) *2 -1;
				//bitsmv2[ i ] = ( bitsmv2[ i -1 ] +2 ) *2 -2;
				//UPGRADE_WARNING: Data types in Visual C# might be different.  Verify the accuracy of narrowing conversions. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1042'"
				bitsmv1[i] = (int) Math.Pow((double) 2, (double) i) - 1;
				//bitsmv2[ i ] = (int) java.lang.Math.pow( (double)2, (double)i +1) -2;
				//System.out.println( "DS bitsmv1[ "+ i +" ] =" + bitsmv1[ i ] );
				//System.out.println( "DS bitsmv2[ "+ i +" ] =" + bitsmv2[ i ] );
			}
			count = 0;
			Xlength = gds.Nx; // needs some smarts for different type Grids
			int X2;
			bitPos = 0;
			bitBuf = 0;
			for (int i = 0; i < NG - 1; i++)
			{
				//System.out.println( "DS pmv=" + pmv );
				//System.out.println( "DS count=" + count );
				//System.out.println( "DS L[ "+ i +" ]=" + L[ i ] );
				//System.out.println( "DS NB[ "+ i +" ]=" + NB[ i ] );
				//System.out.println( "DS X1[ "+ i +" ]=" + X1[ i ] );
				//System.out.println( "DS cumlative L[i] =" + (count + L[ i ]) );
				for (int j = 0; j < L[i]; j++)
				{
					if (NB[i] == 0)
					{
						if (mvm == 0)
						{
							// X2 = 0
							Data[count++] = X1[i];
						}
						else if (mvm == 1)
						{
							Data[count++] = pmv;
						}
					}
					else
					{
						X2 = bits2UInt(NB[i], raf);
						
						if (mvm == 0)
						{
							Data[count++] = X1[i] + X2;
						}
						else if (mvm == 1)
						{
							// X2 is also set to missing value is all bits set to 1's
							if (X2 == bitsmv1[NB[i]])
							{
								Data[count++] = pmv;
							}
							else
							{
								Data[count++] = X1[i] + X2;
							}
						}
						//if( count > 1235 && count < 1275 ) {
						//   System.out.println( "DS count=" + count );
						//   System.out.println( "DS NB[ "+ i +" ]=" + NB[ i ] );
						//   System.out.println( "DS X1[ "+ i +" ]=" + X1[ i ] );
						//   System.out.println( "DS X2 =" +X2 );
						//   System.out.println( "DS X1[ i ] + X2 ="+(X1[ i ]+X2) );
						//}
					}
				} // end for j
			} // end for i
			// process last group
			int last = drs.LengthLastGroup;
			//System.out.println( "DS last=" + last );
			for (int j = 0; j < last; j++)
			{
				// last group
				if (NB[NG - 1] == 0)
				{
					if (mvm == 0)
					{
						// X2 = 0
						Data[count++] = X1[NG - 1];
					}
					else if (mvm == 1)
					{
						Data[count++] = pmv;
					}
				}
				else
				{
					X2 = bits2UInt(NB[NG - 1], raf);
					if (mvm == 0)
					{
						Data[count++] = X1[NG - 1] + X2;
					}
					else if (mvm == 1)
					{
						// X2 is also set to missing value is all bits set to 1's
						if (X2 == bitsmv1[NB[NG - 1]])
						{
							Data[count++] = pmv;
						}
						else
						{
							Data[count++] = X1[NG - 1] + X2;
						}
					}
				}
			} // end for j
			
			
			//System.out.println( "DS mvm =" + mvm );
			if (os == 1)
			{
				// g1 and gMin this coding is a sort of guess, no doc
				float sum = 0;
				if (mvm == 0)
				{
					// no missing values
					for (int i = 1; i < Data.Length; i++)
					{
						Data[i] += gMin; // add minimum back
					}
					Data[0] = g1;
					for (int i = 1; i < Data.Length; i++)
					{
						sum += Data[i];
						Data[i] = Data[i - 1] + sum;
					}
				}
				else
				{
					// contains missing values
					float lastOne = pmv;
					// add the minimum back and set g1
					int idx = 0;
					for (int i = 0; i < Data.Length; i++)
					{
						if (Data[i] != pmv)
						{
							if (idx == 0)
							{
								// set g1
								Data[i] = g1;
								lastOne = Data[i];
								idx = i + 1;
							}
							else
							{
								Data[i] += gMin;
							}
						}
					}
					//System.out.println( "DS data[ 0 ] ="+ data[ 0 ] );
					if (lastOne == pmv)
					{
						Console.Out.WriteLine("DS bad spatial differencing data");
						return ;
					}
					for (int i = idx; i < Data.Length; i++)
					{
						if (Data[i] != pmv)
						{
							//System.out.println( "DS i=" + i + " sum =" + sum );
							sum += Data[i];
							Data[i] = lastOne + sum;
							lastOne = Data[i];
							//System.out.println( "DS data[ "+ i +" ] =" + data[ i ] );
						}
					}
				}
			}
			else if (os == 2)
			{
				//h1, h2, hMin
				float hDiff = h2 - h1;
				float sum = 0;
				if (mvm == 0)
				{
					// no missing values
					for (int i = 2; i < Data.Length; i++)
					{
						Data[i] += hMin; // add minimum back
					}
					Data[0] = h1;
					Data[1] = h2;
					sum = hDiff;
					for (int i = 2; i < Data.Length; i++)
					{
						sum += Data[i];
						Data[i] = Data[i - 1] + sum;
					}
				}
				else
				{
					// contains missing values
					int idx = 0;
					float lastOne = pmv;
					// add the minimum back and set h1 and h2
					for (int i = 0; i < Data.Length; i++)
					{
						if (Data[i] != pmv)
						{
							if (idx == 0)
							{
								// set h1
								Data[i] = h1;
								sum = 0;
								lastOne = Data[i];
								idx++;
							}
							else if (idx == 1)
							{
								// set h2
								Data[i] = h1 + hDiff;
								sum = hDiff;
								lastOne = Data[i];
								idx = i + 1;
							}
							else
							{
								Data[i] += hMin;
							}
						}
					}
					if (lastOne == pmv)
					{
						Console.Out.WriteLine("DS bad spatial differencing data");
						return ;
					}
					for (int i = idx; i < Data.Length; i++)
					{
						if (Data[i] != pmv)
						{
							//System.out.println( "DS i=" + i + " sum =" + sum );
							sum += Data[i];
							//System.out.println( "DS before data[ "+ i +" ] =" + data[ i ] );
							Data[i] = lastOne + sum;
							lastOne = Data[i];
							//System.out.println( "DS after data[ "+ i +" ] =" + data[ i ] );
						}
					}
				}
			} // end h1, h2, hMin
			
			// formula used to create values,  Y * 10**D = R + (X1 + X2) * 2**E
			
			int D = drs.DecimalScaleFactor;
			//System.out.println( "DS D=" + D );
			//UPGRADE_WARNING: Data types in Visual C# might be different.  Verify the accuracy of narrowing conversions. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1042'"
			float DD = (float) Math.Pow((double) 10, (double) D);
			//System.out.println( "DS DD=" + DD );
			
			float R = drs.ReferenceValue;
			//System.out.println( "DS R=" + R );
			
			int E = drs.BinaryScaleFactor;
			//System.out.println( "DS E=" + E );
			//UPGRADE_WARNING: Data types in Visual C# might be different.  Verify the accuracy of narrowing conversions. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1042'"
			float EE = (float) Math.Pow((double) 2.0, (double) E);
			//System.out.println( "DS EE=" + EE );
			
			if (mvm == 0)
			{
				// no missing values
				for (int i = 0; i < Data.Length; i++)
				{
					Data[i] = (R + Data[i] * EE) / DD;
				}
			}
			else
			{
				// missing value == 1
				for (int i = 0; i < Data.Length; i++)
				{
					if (Data[i] != pmv)
					{
						Data[i] = (R + Data[i] * EE) / DD;
					}
				}
			}
			scanMode = gds.ScanMode;
			scanningModeCheck();
			//System.out.println( "DS true end =" + raf.position() );
		} // end complexUnpackingWithSpatial
		
		/// <summary> Jpeg2000 unpacking method for Grib2 data.</summary>
		/// <param name="raf">
		/// </param>
		/// <param name="gds">
		/// </param>
		/// <param name="drs">
		/// </param>
		/// <param name="bms">bit-map section object
		/// </param>
		//UPGRADE_TODO: Class 'java.io.RandomAccessFile' was converted to 'System.IO.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioRandomAccessFile'"
		private void  jpeg2000Unpacking(FileStream raf, Grib2GridDefinitionSection gds, Grib2DataRepresentationSection drs, Grib2BitMapSection bms)
		{
			// 6-xx  jpeg2000 data block to decode
			
			// dataPoints are number of points encoded, it could be less than the
			// numberPoints in the grid record if bitMap is used, otherwise equal
			int dataPoints = drs.DataPoints;
			//System.out.println( "DS DRS dataPoints=" + drs.getDataPoints() );
			//System.out.println( "DS length=" + length );
			
			float pmv = drs.PrimaryMissingValue;
			//System.out.println( "DS pmv=" + pmv );
			int nb = drs.NumberOfBits;
			//System.out.println( "DS nb = " + nb );
			
			int D = drs.DecimalScaleFactor;
			//System.out.println( "DS D=" + D );
			//UPGRADE_WARNING: Data types in Visual C# might be different.  Verify the accuracy of narrowing conversions. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1042'"
			float DD = (float) Math.Pow((double) 10, (double) D);
			//System.out.println( "DS DD=" + DD );
			
			float R = drs.ReferenceValue;
			//System.out.println( "DS R=" + R );
			
			int E = drs.BinaryScaleFactor;
			//System.out.println( "DS E=" + E );
			//UPGRADE_WARNING: Data types in Visual C# might be different.  Verify the accuracy of narrowing conversions. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1042'"
			float EE = (float) Math.Pow((double) 2.0, (double) E);
			//System.out.println( "DS EE=" + EE );
			
			/*Grib2JpegDecoder g2j = null;
			if (nb != 0)
			{
				// there's data to decode
				System.String[] argv = new System.String[4];
				argv[0] = "-rate";
				argv[1] = System.Convert.ToString(nb);
				argv[2] = "-verbose";
				argv[3] = "off";
				//argv[ 2 ] = "-nocolorspace" ;
				//argv[ 3 ] = "-Rno_roi" ;
				//argv[ 4 ] = "-cdstr_info" ;
				//argv[ 5 ] = "-verbose" ;
				//argv[ 6 ] = "-debug" ;
				g2j = new Grib2JpegDecoder(argv);
				g2j.decode(raf, length - 5);
			}
             */

            // Jpeg2000Decoder decoder = new Jpeg2000Decoder();
            byte[] buf = new byte[length-5];
            // TODO Check cast
            int res = raf.Read(buf, 0, length-5);
            int[] values = null;
            if( res == length-5 )
            {
                // values = decoder.Decode(buf, dataPoints);
            }
            else
            {
                // TODO Error handling
            }

			int numberPoints = gds.NumberPoints;
			//System.out.println( "DS GDS NumberPoints=" +  gds.getNumberPoints() );
			Data = new float[numberPoints];
			bool[] bitmap = bms.Bitmap;
			
			if (bitmap == null)
			{
				if (nb == 0)
				{
					// no data decoded, set to primaryMissingValue
					for (int i = 0; i < numberPoints; i++)
					{
						Data[i] = pmv;
					}
				}
				else
				{
					//System.out.println( "DS jpeg data length ="+ g2j.data.length );
					// record has missing bitmap
					if (values.Length != numberPoints)
					{
						Data = null;
						return ;
					}
					for (int i = 0; i < numberPoints; i++)
					{
						//Y = (R + ( 0 + X2) * EE)/DD ;
						Data[i] = (R + values[i] * EE) / DD;
						//System.out.println( "DS data[ " + i +"  ]=" + data[ i ] );
					}
				}
			}
			else
			{
				for (int i = 0, j = 0; i < bitmap.Length; i++)
				{
					if (bitmap[i])
					{
						Data[i] = (R + values[j++] * EE) / DD;
					}
					else
					{
						Data[i] = pmv;
					}
				}
			}
			scanMode = gds.ScanMode;
			scanningModeCheck();
		} // end jpeg2000Unpacking
		
		
		/// <summary> Convert bits (nb) to Unsigned Int .</summary>
		/// <param name="nb">the number of bits to convert to int
		/// </param>
		/// <param name="raf">
		/// </param>
		/// <throws>  IOException </throws>
		/// <returns> int of DataSections section
		/// </returns>
		//UPGRADE_TODO: Class 'java.io.RandomAccessFile' was converted to 'System.IO.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioRandomAccessFile'"
		private int bits2UInt(int nb, FileStream raf)
		{
			int bitsLeft = nb;
			int result = 0;
			
			if (bitPos == 0)
			{
				bitBuf = raf.ReadByte();
				bitPos = 8;
			}
			
			while (true)
			{
				int shift = bitsLeft - bitPos;
				if (shift > 0)
				{
					// Consume the entire buffer
					result |= bitBuf << shift;
					bitsLeft -= bitPos;
					
					// Get the next byte from the RandomAccessFile
					bitBuf = raf.ReadByte();
					bitPos = 8;
				}
				else
				{
					// Consume a portion of the buffer
					result |= bitBuf >> - shift;
					bitPos -= bitsLeft;
					bitBuf &= 0xff >> (8 - bitPos); // mask off consumed bits
					
					return result;
				}
			} // end while
		} // end bits2UInt
		
		/// <summary> Rearrange the data array using the scanning mode.
		/// 
		/// </summary>
		private void  scanningModeCheck()
		{
			// Mode  0 +x, -y, adjacent x, adjacent rows same dir
			// Mode  64 +x, +y, adjacent x, adjacent rows same dir
			if (scanMode == 0 || scanMode == 64)
			{
				return ;
				// Mode  128 -x, -y, adjacent x, adjacent rows same dir
				// Mode  192 -x, +y, adjacent x, adjacent rows same dir
				// change -x to +x ie east to west -> west to east
			}
			else if (scanMode == 128 || scanMode == 192)
			{
				float tmp;
				int mid = (int) Xlength / 2;
				//System.out.println( "Xlength =" +Xlength +" mid ="+ mid );
				for (int index = 0; index < Data.Length; index += Xlength)
				{
					for (int idx = 0; idx < mid; idx++)
					{
						tmp = Data[index + idx];
						Data[index + idx] = Data[index + Xlength - idx - 1];
						Data[index + Xlength - idx - 1] = tmp;
						//System.out.println( "switch " + (index + idx) + " " +
						//(index + Xlength -idx -1) );
					}
				}
				return ;
			}
			// else
			// scanMode == 16, 80, 144, 208 adjacent rows scan opposite dir
			float tmp2;
			int mid2 = (int) Xlength / 2;
			//System.out.println( "Xlength =" +Xlength +" mid ="+ mid );
			for (int index = 0; index < Data.Length; index += Xlength)
			{
				int row = (int) index / Xlength;
				if (row % 2 == 1)
				{
					// odd numbered row, calculate reverse index
					for (int idx = 0; idx < mid2; idx++)
					{
						tmp2 = Data[index + idx];
						Data[index + idx] = Data[index + Xlength - idx - 1];
						Data[index + Xlength - idx - 1] = tmp2;
						//System.out.println( "switch " + (index + idx) + " " +
						//(index + Xlength -idx -1) );
					}
				}
			}
		} // end of scanningModeCheck
		
		// --Commented out by Inspection START (11/21/05 11:16 AM):
		//   /**
		//    * Get the byte length of the DataSectionS section.
		//    *
		//    * @return length in bytes of DataSectionS section
		//    */
		//   public final int getLength()
		//   {
		//      return length;
		//   }
		// --Commented out by Inspection STOP (11/21/05 11:16 AM)
		
		// --Commented out by Inspection START (11/21/05 11:16 AM):
		//   /**
		//    * Number of this section, should be 7
		//    */
		//   public final int getSection()
		//   {
		//      return section;
		//   }
		// --Commented out by Inspection STOP (11/21/05 11:16 AM)
	}
}