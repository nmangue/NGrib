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

using NGrib.Grib2.CodeTables;
using NGrib.Grib2.Templates;
using NGrib.Grib2.Templates.ProductDefinitions;
using System.IO;
using System.Runtime.InteropServices;

namespace NGrib.Grib2.Sections
{
	/// <summary>
	/// Section 4 - Product Definition Section
	/// </summary>
	public sealed class ProductDefinitionSection
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
		/// Number of coordinates values after Template.
		/// </summary>
		public int CoordinatesAfterTemplateNumber { get; }

		/// <summary>
		/// Product Definition Template Number
		/// </summary>
		public int ProductDefinitionTemplateNumber { get; }

		/// <summary>
		/// Product Definition Template.
		/// </summary>
		public ProductDefinition ProductDefinition { get; }

		private ProductDefinitionSection(
			long length,
			int section,
			int coordinatesAfterTemplateNumber,
			int productDefinitionTemplateNumber,
			ProductDefinition productDefinition)
		{
			CoordinatesAfterTemplateNumber = coordinatesAfterTemplateNumber;
			ProductDefinitionTemplateNumber = productDefinitionTemplateNumber;
			ProductDefinition = productDefinition;
			Length = length;
			Section = section;
		}

		internal static ProductDefinitionSection BuildFrom(BufferedBinaryReader reader, Discipline discipline,
		                                                   IdentificationSection identificationSection)
		{
			var currentPosition = reader.Position;

			// octets 1-4 (Length of PDS)
			var length = reader.ReadUInt32();

			// octet 5
			var section = reader.ReadUInt8();

			// octet 6-7
			var coordinates = reader.ReadUInt16();

			// octet 8-9
			var productDefinitionTemplateNumber = reader.ReadUInt16();

			var productDefinition = ProductDefinitionFactories.Build(reader, productDefinitionTemplateNumber, discipline, identificationSection);

			// Prevent from over-reading the stream
			reader.Seek(currentPosition + length, SeekOrigin.Begin);

			return new ProductDefinitionSection(length, section, coordinates, productDefinitionTemplateNumber,
				productDefinition);
		}

		public bool TryGet<T>(TemplateContent<T> content, out T value) => ProductDefinition.TryGet(content, out value);

		private static readonly TemplateFactory<ProductDefinition> ProductDefinitionFactories =
			new TemplateFactory<ProductDefinition>
			{
				{ 0, (r, args) => new ProductDefinition0000(r, (Discipline) args[0], (IdentificationSection) args[1]) },
				{ 1, (r, args) => new ProductDefinition0001(r, (Discipline) args[0], (IdentificationSection) args[1]) },
				{ 2, (r, args) => new ProductDefinition0002(r, (Discipline) args[0], (IdentificationSection) args[1]) },
				{ 8, (r, args) => new ProductDefinition0008(r, (Discipline) args[0], (IdentificationSection) args[1]) },
				{ 11, (r, args) => new ProductDefinition0011(r, (Discipline) args[0], (IdentificationSection) args[1]) },
				{ 12, (r, args) => new ProductDefinition0012(r, (Discipline) args[0], (IdentificationSection) args[1]) }
			};
	}
}