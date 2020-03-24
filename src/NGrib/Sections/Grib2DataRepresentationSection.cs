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
	/// <summary> A class that represents the DataRepresentationSection of a GRIB product.
	/// 
	/// </summary>
	public sealed class Grib2DataRepresentationSection
	{
		private void InitBlock()
		{
			PrimaryMissingValue = GribNumbers.UNDEFINED;
			SecondaryMissingValue = GribNumbers.UNDEFINED;
		}

		/// <summary> Get the byte length of the Section DRS section.
		/// 
		/// </summary>
		/// <returns> length in bytes of Section DRS section
		/// </returns>
		public long Length { get; }

		/// <summary> Get the number of dataPoints in DS section.
		/// 
		/// </summary>
		/// <returns> number of dataPoints in DS section
		/// </returns>
		public long DataPoints { get; }

		/// <summary> Get the Data Template Number for the GRID.
		/// 
		/// </summary>
		/// <returns> Data Template Number
		/// </returns>
		public int DataTemplateNumber { get; }

		/// <summary> Reference value (R) (IEEE 32-bit floating-point value).</summary>
		/// <returns> ReferenceValue
		/// </returns>
		public float ReferenceValue { get; }

		/// <summary> Binary scale factor (E).</summary>
		/// <returns> BinaryScaleFactor
		/// </returns>
		public int BinaryScaleFactor { get; }

		/// <summary> Decimal scale factor (D).</summary>
		/// <returns> DecimalScaleFactor
		/// </returns>
		public int DecimalScaleFactor { get; }

		/// <summary> Number of bits used for each packed value..</summary>
		/// <returns> NumberOfBits NB
		/// </returns>
		public int NumberOfBits { get; }

		/// <summary> Type of original field values.</summary>
		/// <returns> OriginalType dataType
		/// </returns>
		public int OriginalType { get; }

		/// <summary> Group splitting method used (see Code Table 5.4).</summary>
		/// <returns> SplittingMethod
		/// </returns>
		public int SplittingMethod { get; }

		/// <summary> Type compression method used (see Code Table 5.40000).</summary>
		/// <returns> CompressionMethod
		/// </returns>
		public int CompressionMethod { get; }

		/// <summary> Compression ratio used .</summary>
		/// <returns> CompressionRatio
		/// </returns>
		public int CompressionRatio { get; }

		/// <summary> Missing value management used (see Code Table 5.5).</summary>
		/// <returns> MissingValueManagement
		/// </returns>
		public int MissingValueManagement { get; }

		/// <summary> Primary missing value substitute.</summary>
		/// <returns> PrimaryMissingValue
		/// </returns>
		public float PrimaryMissingValue { get; private set; }

		/// <summary> Secondary missing value substitute.</summary>
		/// <returns> SecondaryMissingValue
		/// </returns>
		public float SecondaryMissingValue { get; private set; }

		/// <summary> NG - Number of groups of data values into which field is split.</summary>
		/// <returns> NumberOfGroups NG
		/// </returns>
		public long NumberOfGroups { get; }

		/// <summary> Reference for group widths (see Note 12).</summary>
		/// <returns> ReferenceGroupWidths
		/// </returns>
		public int ReferenceGroupWidths { get; }

		/// <summary> Number of bits used for the group widths (after the reference value 
		/// in octet 36 has been removed).
		/// </summary>
		/// <returns> BitsGroupWidths
		/// </returns>
		public int BitsGroupWidths { get; }

		/// <summary> Reference for group lengths (see Note 13).</summary>
		/// <returns> ReferenceGroupLength
		/// </returns>
		public long ReferenceGroupLength { get; }

		/// <summary> Length increment for the group lengths (see Note 14).</summary>
		/// <returns> LengthIncrement
		/// </returns>
		public int LengthIncrement { get; }

		/// <summary> Length increment for the group lengths (see Note 14).</summary>
		/// <returns> LengthLastGroup
		/// </returns>
		public long LengthLastGroup { get; }

		/// <summary> Number of bits used for the scaled group lengths (after subtraction of 
		/// the reference value given in octets 38-41 and division by the length 
		/// increment given in octet 42).
		/// </summary>
		/// <returns> BitsScaledGroupLength
		/// </returns>
		public int BitsScaledGroupLength { get; }

		/// <summary> Order of spatial differencing (see Code Table 5.6).</summary>
		/// <returns> OrderSpatial
		/// </returns>
		public int OrderSpatial { get; }

		/// <summary> Number of octets required in the Data Section to specify extra
		/// descriptors needed for spatial differencing (octets 6-ww in Data
		/// Template 7.3).
		/// </summary>
		/// <returns> DescriptorSpatial
		/// </returns>
		public int DescriptorSpatial { get; }

		/// <summary> Number of this section, should be 5.</summary>
		//UPGRADE_NOTE: Final was removed from the declaration of 'section '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private int section;

		// *** constructors *******************************************************

		/// <summary> Constructs a <tt>Grib2DataRepresentationSection</tt> object from a raf.
		/// 
		/// </summary>
		/// <param name="raf">RandomAccessFile with Section DRS content
		/// </param>
		/// <throws>  IOException  if stream contains no valid GRIB file </throws>
		//UPGRADE_TODO: Class 'java.io.RandomAccessFile' was converted to 'System.IO.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioRandomAccessFile'"
		public Grib2DataRepresentationSection(FileStream raf)
		{
			InitBlock();
			// octets 1-4 (Length of DRS)
			Length = GribNumbers.int4(raf);

			section = raf.ReadByte();

			DataPoints = GribNumbers.int4(raf);

			DataTemplateNumber = (int) GribNumbers.uint2(raf);

			switch (DataTemplateNumber)
			{
				// Data Template Number
				case 0:
				case 1: // 0 - Grid point data - simple packing 
					// 1 - Matrix values - simple packing

					ReferenceValue = GribNumbers.IEEEfloat4(raf);
					BinaryScaleFactor = GribNumbers.int2(raf);
					DecimalScaleFactor = GribNumbers.int2(raf);
					NumberOfBits = raf.ReadByte();

					OriginalType = raf.ReadByte();

					if (DataTemplateNumber == 0)
						break;
					// case 1 not implememted
					Console.Out.WriteLine("DRS dataTemplate=1 not implemented yet");
					break;

				case 2:
				case 3: // Grid point data - complex packing

					// octet 12 - 15
					ReferenceValue = GribNumbers.IEEEfloat4(raf);
					// octet 16 - 17
					BinaryScaleFactor = GribNumbers.int2(raf);
					// octet 18 - 19
					DecimalScaleFactor = GribNumbers.int2(raf);
					// octet 20
					NumberOfBits = raf.ReadByte();

					// octet 21
					OriginalType = raf.ReadByte();

					// octet 22
					SplittingMethod = raf.ReadByte();

					//     splittingMethod );
					// octet 23
					MissingValueManagement = raf.ReadByte();

					//     missingValueManagement );
					// octet 24 - 27
					PrimaryMissingValue = GribNumbers.IEEEfloat4(raf);
					// octet 28 - 31
					SecondaryMissingValue = GribNumbers.IEEEfloat4(raf);
					// octet 32 - 35
					NumberOfGroups = GribNumbers.int4(raf);

					//     numberOfGroups );
					// octet 36
					ReferenceGroupWidths = raf.ReadByte();

					//     referenceGroupWidths );
					// octet 37
					BitsGroupWidths = raf.ReadByte();
					// according to documentation subtract referenceGroupWidths
					BitsGroupWidths = BitsGroupWidths - ReferenceGroupWidths;

					//     bitsGroupWidths );
					// octet 38 - 41
					ReferenceGroupLength = GribNumbers.int4(raf);

					//     referenceGroupLength );
					// octet 42
					LengthIncrement = raf.ReadByte();

					//     lengthIncrement );
					// octet 43 - 46
					LengthLastGroup = GribNumbers.int4(raf);

					//     lengthLastGroup );
					// octet 47
					BitsScaledGroupLength = raf.ReadByte();

					//     bitsScaledGroupLength );
					if (DataTemplateNumber == 2)
						break;

					// case 3 // complex packing & spatial differencing
					OrderSpatial = raf.ReadByte();

					DescriptorSpatial = raf.ReadByte();

					break;

				case 40:
				case 40000: // Grid point data - JPEG 2000 Code Stream Format

					ReferenceValue = GribNumbers.IEEEfloat4(raf);
					BinaryScaleFactor = GribNumbers.int2(raf);
					DecimalScaleFactor = GribNumbers.int2(raf);
					NumberOfBits = raf.ReadByte();

					OriginalType = raf.ReadByte();

					CompressionMethod = raf.ReadByte();

					CompressionRatio = raf.ReadByte();

					break;

				default:
					break;
			}
		} // end of Grib2DataRepresentationSection

		/// <summary> Constructs a <tt>Grib2DataRepresentationSection</tt> object from a raf.
		/// 
		/// </summary>
		/// <param name="reader">RandomAccessFile with Section DRS content
		/// </param>
		/// <throws>  IOException  if stream contains no valid GRIB file </throws>
		internal Grib2DataRepresentationSection(BufferedBinaryReader reader)
		{
			InitBlock();
			// octets 1-4 (Length of DRS)
			Length = reader.ReadUInt32();

			section = reader.ReadUInt8();

			DataPoints = reader.ReadUInt32();

			DataTemplateNumber = (int)reader.ReadUInt16();

			switch (DataTemplateNumber)
			{
				// Data Template Number
				case 0:
				case 1: // 0 - Grid point data - simple packing 
						// 1 - Matrix values - simple packing

					ReferenceValue = reader.ReadSingle();
					BinaryScaleFactor = reader.ReadUInt16();
					DecimalScaleFactor = reader.ReadUInt16();
					NumberOfBits = reader.ReadUInt8();

					OriginalType = reader.ReadUInt8();

					if (DataTemplateNumber == 0)
						break;
					// case 1 not implememted
					Console.Out.WriteLine("DRS dataTemplate=1 not implemented yet");
					break;

				case 2:
				case 3: // Grid point data - complex packing

					// octet 12 - 15
					ReferenceValue = reader.ReadSingle();
					// octet 16 - 17
					BinaryScaleFactor = reader.ReadUInt16();
					// octet 18 - 19
					DecimalScaleFactor = reader.ReadUInt16();
					// octet 20
					NumberOfBits = reader.ReadUInt8();

					// octet 21
					OriginalType = reader.ReadUInt8();

					// octet 22
					SplittingMethod = reader.ReadUInt8();

					//     splittingMethod );
					// octet 23
					MissingValueManagement = reader.ReadUInt8();

					//     missingValueManagement );
					// octet 24 - 27
					PrimaryMissingValue = reader.ReadSingle();
					// octet 28 - 31
					SecondaryMissingValue = reader.ReadSingle();
					// octet 32 - 35
					NumberOfGroups = reader.ReadUInt32();

					//     numberOfGroups );
					// octet 36
					ReferenceGroupWidths = reader.ReadUInt8();

					//     referenceGroupWidths );
					// octet 37
					BitsGroupWidths = reader.ReadUInt8();
					// according to documentation subtract referenceGroupWidths
					BitsGroupWidths = BitsGroupWidths - ReferenceGroupWidths;

					//     bitsGroupWidths );
					// octet 38 - 41
					ReferenceGroupLength = reader.ReadUInt32();

					//     referenceGroupLength );
					// octet 42
					LengthIncrement = reader.ReadUInt8();

					//     lengthIncrement );
					// octet 43 - 46
					LengthLastGroup = reader.ReadUInt32();

					//     lengthLastGroup );
					// octet 47
					BitsScaledGroupLength = reader.ReadUInt8();

					//     bitsScaledGroupLength );
					if (DataTemplateNumber == 2)
						break;

					// case 3 // complex packing & spatial differencing
					OrderSpatial = reader.ReadUInt8();

					DescriptorSpatial = reader.ReadUInt8();

					break;

				case 40:
				case 40000: // Grid point data - JPEG 2000 Code Stream Format

					ReferenceValue = reader.ReadSingle();
					BinaryScaleFactor = reader.ReadUInt16();
					DecimalScaleFactor = reader.ReadUInt16();
					NumberOfBits = reader.ReadUInt8();

					OriginalType = reader.ReadUInt8();

					CompressionMethod = reader.ReadUInt8();

					CompressionRatio = reader.ReadUInt8();

					break;

				default:
					break;
			}
		} // end of Grib2DataRepresentationSection
	}
}