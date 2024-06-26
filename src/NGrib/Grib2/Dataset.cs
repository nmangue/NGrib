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
using System.Linq;
using NGrib.Grib2.CodeTables;
using NGrib.Grib2.Sections;

namespace NGrib.Grib2
{
	/// <summary>
	/// Represents a data set in a GRIB2 message.
	/// </summary>
	public sealed class DataSet
	{
		/// <summary>
		/// Message in which the data set is provided.
		/// </summary>
		public Message Message { get; }

		/// <summary>
		/// Local Use Section.
		/// </summary>
		/// <remarks><c>null</c> if not used.</remarks>
		public LocalUseSection LocalUseSection { get; }

		/// <summary>
		/// Grid Definition Section.
		/// </summary>
		public GridDefinitionSection GridDefinitionSection { get; }

		/// <summary>
		/// Product Definition Section.
		/// </summary>
		public ProductDefinitionSection ProductDefinitionSection { get; }

		/// <summary>
		/// Bitmap Section.
		/// </summary>
		public BitmapSection BitmapSection { get; }

		/// <summary>
		/// Data Representation Section.
		/// </summary>
		public DataRepresentationSection DataRepresentationSection { get; }

		/// <summary>
		/// Data Section.
		/// </summary>
		public DataSection DataSection { get; }

		/// <summary>
		/// Parameter defined in the Product Definition Section.
		/// </summary>
		public Parameter? Parameter => ProductDefinitionSection.ProductDefinition?.Parameter;

		internal DataSet(
			Message message,
			LocalUseSection localUseSection,
			GridDefinitionSection gridDefinitionSection,
			ProductDefinitionSection productDefinitionSection,
			DataRepresentationSection dataRepresentationSection,
			BitmapSection bitmapSection,
			DataSection dataSection)
		{
			Message = message;
			GridDefinitionSection = gridDefinitionSection;
			ProductDefinitionSection = productDefinitionSection;
			DataRepresentationSection = dataRepresentationSection;
			BitmapSection = bitmapSection;
			DataSection = dataSection;
			LocalUseSection = localUseSection;
		}

		internal IEnumerable<KeyValuePair<Coordinate, float?>> GetData(BufferedBinaryReader reader)
		{
			return GridDefinitionSection.GridDefinition.EnumerateGridPoints()
				.Zip(GetRawData(reader), (p, v) => new KeyValuePair<Coordinate, float?>(p, v));
		}

		internal IEnumerable<float?> GetRawData(BufferedBinaryReader reader)
		{
			if (DataRepresentationSection.DataRepresentation == null)
			{
				throw new NotSupportedException($"Data Representation Template {DataRepresentationSection.TemplateNumber} is not supported.");
			}

			var bitmap = BitmapSection.GetBitmap(reader);

			using var valuesEnumerator = DataRepresentationSection.DataRepresentation
				.EnumerateDataValues(reader, DataSection, DataRepresentationSection.DataPointsNumber)
				.GetEnumerator();

			foreach (var isValueDefined in bitmap)
			{
				var v = isValueDefined && valuesEnumerator.MoveNext() ? valuesEnumerator.Current : (float?) null;
				yield return v;
			}
		}
	}
}