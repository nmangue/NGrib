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

using System.Collections.Generic;
using System.IO;
using System.Linq;
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
			return GridDefinitionSection.GridDefinition.EnumerateGridPoints().Zip(GetRawData(reader), (p, v) => new KeyValuePair<Coordinate, float?>(p, v));
		}

		internal IEnumerable<float?> GetRawData(BufferedBinaryReader reader)
		{
			var bitmap = BitmapSection.GetBitmap(reader);
			
			reader.Seek(DataSection.DataOffset, SeekOrigin.Begin);
			using var valuesEnumerator = DataRepresentationSection.DataRepresentation.EnumerateDataValues(reader, DataRepresentationSection.DataPointsNumber).GetEnumerator();
			
			foreach (var isValueDefined in bitmap)
			{
				var v = (bool) isValueDefined && valuesEnumerator.MoveNext() ? valuesEnumerator.Current : DataRepresentationSection.DataRepresentation.MissingValueSubstitute;
				yield return v;
			}
		}
	}
}