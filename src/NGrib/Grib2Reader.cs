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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NGrib.Grib2;
using NGrib.Grib2.Sections;

namespace NGrib
{
	public class Grib2Reader
	{
		private readonly BufferedBinaryReader reader;

		public Grib2Reader(Stream gribStream)
		{
			if (gribStream == null) throw new ArgumentNullException(nameof(gribStream));
			if (!gribStream.CanRead) throw new ArgumentException("The stream must support reading.", nameof(gribStream));
			if (!gribStream.CanSeek) throw new ArgumentException("The stream must support seeking.", nameof(gribStream));

			reader = new BufferedBinaryReader(gribStream);
		}

		public IList<Message> ReadMessages()
		{
			var messages = new List<Message>();
			reader.Seek(0, SeekOrigin.Begin);

			do
			{
				var indicatorSection = IndicatorSection.BuildFrom(reader);
				var identificationSection = IdentificationSection.BuildFrom(reader);

				var message = new Message(indicatorSection, identificationSection);
				messages.Add(message);

				LocalUseSection localUseSection = null;
				do
				{
					if (reader.PeekSection().Is(SectionCode.LocalUseSection))
					{
						localUseSection = LocalUseSection.BuildFrom(reader);
					}

					while (reader.PeekSection().Is(SectionCode.GridDefinitionSection))
					{
						var gridDefinitionSection = GridDefinitionSection.BuildFrom(reader);

						while (reader.PeekSection().Is(SectionCode.ProductDefinitionSection))
						{
							var productDefinitionSection = ProductDefinitionSection.BuildFrom(reader);
							var dataRepresentationSection = DataRepresentationSection.BuildFrom(reader);

							var bitmapSection = BitmapSection.BuildFrom(reader, dataRepresentationSection.DataPointsNumber);

							var dataSection = DataSection.BuildFrom(reader);

							message.AddDataset(
								localUseSection,
								gridDefinitionSection,
								productDefinitionSection,
								dataRepresentationSection,
								bitmapSection,
								dataSection);
						}
					}
				} while (!reader.PeekSection().Is(SectionCode.EndSection));
				EndSection.BuildFrom(reader);
			} while (!reader.HasReachedStreamEnd && reader.PeekSection().Is(SectionCode.IndicatorSection));

			return messages;
		}

		public IEnumerable<DataSet> ReadAllDataSets() => ReadMessages().SelectMany(m => m.DataSets);

		public IEnumerable<float?> ReadDataSetRawData(DataSet record) => record.GetRawData(reader);
		
		public IEnumerable<KeyValuePair<Coordinate, float?>> ReadRecordData(DataSet record) => record.GetData(reader);
	}
}
