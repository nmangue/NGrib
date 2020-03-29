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

using NGrib.Grib2.Sections.Templates;
using NGrib.Grib2.Sections.Templates.ProductDefinitionTemplates;

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

		internal static ProductDefinitionSection BuildFrom(BufferedBinaryReader reader)
		{
			// octets 1-4 (Length of PDS)
			var length = reader.ReadUInt32();

			// octet 5
			var section = reader.ReadUInt8();

			// octet 6-7
			var coordinates = reader.ReadUInt16();

			// octet 8-9
			var productDefinitionTemplateNumber = reader.ReadUInt16();

			var productDefinition = ProductDefinitionFactories.Build(reader, productDefinitionTemplateNumber);

			return new ProductDefinitionSection(length, section, coordinates, productDefinitionTemplateNumber,
				productDefinition);
		}

		private static readonly TemplateFactory<ProductDefinition> ProductDefinitionFactories =
			new TemplateFactory<ProductDefinition>()
			{
				{ 0, r => new PointInTimeHorizontalLevelProductDefinition(r) },
				{ 8, r => new StatisticallyProcessedPointInTimeHorizontalLevelProductDefinition(r) }
			};
	}
}