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

using NGrib.Grib2.Templates;
using NGrib.Grib2.Templates.DataRepresentations;
using System.IO;

namespace NGrib.Grib2.Sections
{
	/// <summary>
	/// Section 5 - Data Representation Section
	/// </summary>
	public sealed class DataRepresentationSection
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
		/// Number of data points where one or more values are specified in Section 7
		/// when a bit map is present, total number of data points when a bit map is absent.
		/// </summary>
		public long DataPointsNumber { get; }

		/// <summary>
		/// Data Representation Template Number.
		/// </summary>
		public int TemplateNumber { get; }

		/// <summary>
		/// Data Representation Template.
		/// </summary>
		public DataRepresentation DataRepresentation { get; }

		private DataRepresentationSection(
			long length,
			int section,
			long dataPointsNumber,
			int templateNumber,
			DataRepresentation dataRepresentation)
		{
			Section = section;
			Length = length;
			DataPointsNumber = dataPointsNumber;
			TemplateNumber = templateNumber;
			DataRepresentation = dataRepresentation;
		}

		internal static DataRepresentationSection BuildFrom(BufferedBinaryReader reader)
		{
			var sectionStartPosition = reader.Position;

			// octets 1-4 (Length of DRS)
			var length = reader.ReadUInt32();

			var section = reader.ReadUInt8();
			if (section != (int) SectionCode.DataRepresentationSection)
			{
				throw new UnexpectedGribSectionException(
					SectionCode.DataRepresentationSection,
					section
					);
			}

			var dataPoints = reader.ReadUInt32();

			var dataTemplateNumber = reader.ReadUInt16();

			var dataRepresentation = DataRepresentationFactory.Build(reader, dataTemplateNumber);

			// Prevent from over-reading the stream
			reader.Seek(sectionStartPosition + length, SeekOrigin.Begin);

			return new DataRepresentationSection(length, section, dataPoints, dataTemplateNumber, dataRepresentation);
		}

		private static readonly TemplateFactory<DataRepresentation> DataRepresentationFactory =
			new TemplateFactory<DataRepresentation>
			{
				{ 0, r => new GridPointDataSimplePacking(r) },
				{ 2, r => new GridPointDataComplexPacking(r) },
				{ 3, r => new GridPointDataComplexPackingAndSpatialDifferencing(r) },
				{ 40, r => new GridPointDataJpeg2000CodeStream(r) },
				{ 42, r => new GridPointDataCcsdsLosslessCompression(r) },
				{ 40000, r => new GridPointDataJpeg2000CodeStream(r) },
				{ 50002, r => new GridPointDataEcmwfSecondOrderPacking(r) },
			};
	}
}