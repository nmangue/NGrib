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
using NGrib.Grib2.CodeTables;

namespace NGrib.Grib2.Sections
{
	/// <summary>
	/// Section 1 - Identification Section
	/// </summary>
	public sealed class IdentificationSection
	{
		/// <summary>
		/// Length of section in octets.
		/// </summary>
		public long Length { get; }

		/// <summary>
		/// Number of section.
		/// </summary>
		public int Section { get; }

		/// <summary>
		/// Identification of originating/generating center.
		/// </summary>
		public int CenterCode { get; }

		/// <summary>
		/// Originating/generating center.
		/// </summary>
		public Center Center { get; }

		/// <summary>
		/// Identification of originating/generating sub-centre (allocated by originating/generating Centre)
		/// </summary>
		public int SubCenterCode { get; }

		/// <summary>
		/// GRIB Master Tables Version Number.
		/// </summary>
		public int MasterTableVersion { get; }

		/// <summary>
		/// Version number of GRIB Local Tables used to augment Master Tables.
		/// </summary>
		public int LocalTableVersion { get; }

		/// <summary>
		/// Significance of Reference Time code.
		/// </summary>
		public int ReferenceTimeSignificanceCode { get; }

		/// <summary>
		/// Significance of Reference Time.
		/// </summary>
		public ReferenceTimeSignificance? ReferenceTimeSignificance { get; }

		/// <summary>
		/// Reference time of data.
		/// </summary>
		public DateTime ReferenceTime { get; }

		/// <summary>
		/// Production status code of processed data in this GRIB message.
		/// </summary>
		public int ProductStatusCode { get; }

		/// <summary>
		/// Production status of processed data in this GRIB message.
		/// </summary>
		public ProductStatus? ProductStatus { get; }

		/// <summary>
		/// Type of processed data code in this GRIB message.
		/// </summary>
		public int ProductTypeCode { get; }

		/// <summary>
		/// Type of processed data in this GRIB message.
		/// </summary>
		public ProductType? ProductType { get; }

		private IdentificationSection(long length, int section, int centerCode, int subCenterCode, int masterTableVersion, int localTableVersion, int referenceTimeSignificanceCode, DateTime referenceTime, int productStatusCode, int productTypeCode)
		{
			Length = length;
			Section = section;
			CenterCode = centerCode;
			Center = Center.GetCenterById(CenterCode);
			SubCenterCode = subCenterCode;
			MasterTableVersion = masterTableVersion;
			LocalTableVersion = localTableVersion;
			ReferenceTimeSignificanceCode = referenceTimeSignificanceCode;
			ReferenceTimeSignificance = ReferenceTimeSignificanceCode.As<ReferenceTimeSignificance>();
			ReferenceTime = referenceTime;
			ProductStatusCode = productStatusCode;
			ProductStatus = ProductStatusCode.As<ProductStatus>();
			ProductTypeCode = productTypeCode;
			ProductType = ProductTypeCode.As<ProductType>();
		}

		internal static IdentificationSection BuildFrom(BufferedBinaryReader reader)
		{
			// section 1 octet 1-4 (length of section)
			var length = reader.ReadUInt32();

			var section = reader.ReadUInt8();
			if (section != 1)
			{
				return null;
			}

			// Center  octet 6-7
			var centerCode = reader.ReadUInt16();

			// Center  octet 8-9
			var subCenterCode = reader.ReadUInt16();

			// Parameter master table octet 10
			var masterTableVersion = reader.ReadUInt8();

			// Parameter local table octet 11
			var localTableVersion = reader.ReadUInt8();

			// significanceOfRT octet 12
			var significanceOfRt = reader.ReadUInt8();

			// octets 13-19 (base time of forecast)
			var refTime = reader.ReadDateTime();

			var productStatusCode = reader.ReadUInt8();

			var productTypeCode = reader.ReadUInt8();
			return new IdentificationSection(
				length,
				section,
				centerCode,
				subCenterCode,
				masterTableVersion,
				localTableVersion,
				significanceOfRt,
				refTime,
				productStatusCode,
				productTypeCode);
		}
	}
}