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
using NGrib.Grib2.Sections;

namespace NGrib
{
	public class Grib2Reader
	{
		public IReadOnlyCollection<Grib2Record> Records => records;

		private readonly Stream gribStream;
		private BufferedBinaryReader reader;
		private List<Grib2Record> records = new List<Grib2Record>();

		private Grib2Reader(Stream gribStream)
		{
			this.gribStream = gribStream;
			reader = new BufferedBinaryReader(gribStream, 4096);
		}

		private void MapGrib()
		{
			reader.Seek(0, SeekOrigin.Begin);

			do
			{
				var indicatorSection = IndicatorSection.BuildFrom(reader);
				var identificationSection = Grib2IdentificationSection.BuildFrom(reader);

				Grib2LocalUseSection localSection = null;
				do
				{
					if (reader.PeekSection().Is(SectionCode.LocalUseSection))
					{
						localSection = Grib2LocalUseSection.BuildFrom(reader);
					}

					while (reader.PeekSection().Is(SectionCode.GridDefinitionSection))
					{
						var gridDefinitionSection = Grib2GridDefinitionSection.BuildFrom(reader);

						while (reader.PeekSection().Is(SectionCode.ProductDefinitionSection))
						{
							var productDefinitionSection = Grib2ProductDefinitionSection.BuildFrom(reader);
							var dataRepresentationSection = Grib2DataRepresentationSection.BuildFrom(reader);

							var bitmapSection = Grib2BitMapSection.BuildFrom(reader, dataRepresentationSection.DataPoints);

							var dataSection = Grib2DataSection.BuildFrom(reader);

							var record = new Grib2Record(
								indicatorSection,
								identificationSection,
								localSection,
								gridDefinitionSection,
								productDefinitionSection,
								dataRepresentationSection,
								bitmapSection,
								dataSection);

							records.Add(record);
						}
					}
				} while (!reader.PeekSection().Is(SectionCode.EndSection));
				Grib2EndSection.BuildFrom(reader);
			} while (!reader.HasReachedStreamEnd && reader.PeekSection().Is(SectionCode.IndicatorSection));
		}

		public IEnumerable<KeyValuePair<Coordinate, float?>> ReadRecordData(Grib2Record record) => record.GetData(reader);

		public static Grib2Reader Open(Stream gribStream)
		{
			var reader = new Grib2Reader(gribStream);
			reader.MapGrib();
			return reader;
		}
	}
}
