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
using System.IO;
using System.Linq;
using NGrib.Grib2;
using NGrib.Grib2.Sections;

namespace NGrib
{
	/// <summary>
	/// Reads GRIB 2 data format.
	/// </summary>
	public class Grib2Reader : IDisposable
	{
		private readonly BufferedBinaryReader reader;

		/// <summary>
		/// Initializes a new instance of the <c>Grib2Reader</c> class
		/// based on the specified file.
		/// </summary>
		/// <param name="filePath">The GRIB 2 file path.</param>
		public Grib2Reader(string filePath, int bufferSize = 4096) : this(File.OpenRead(filePath), false, bufferSize)
		{ }

		/// <summary>
		/// Initializes a new instance of the <c>Grib2Reader</c> class
		/// based on the specified stream.
		/// </summary>
		/// <param name="input">The GRIB 2 input stream.</param>
		/// <param name="leaveOpen"><c>true</c>to leave the stream open after the <see cref="Grib2Reader"/> object is disposed; otherwise, <c>false</c>.</param>
		public Grib2Reader(Stream input, bool leaveOpen = false, int bufferSize = 4096)
		{
			if (input == null) throw new ArgumentNullException(nameof(input));
			if (!input.CanRead) throw new ArgumentException("The stream must support reading.", nameof(input));
			if (!input.CanSeek) throw new ArgumentException("The stream must support seeking.", nameof(input));

			reader = new BufferedBinaryReader(input, leaveOpen, bufferSize);
		}

		/// <summary>
		/// Enumerates the messages in the underlying stream.
		/// </summary>
		/// <returns>The messages in the GRIB 2 stream.</returns>
		public IEnumerable<Message> ReadMessages()
		{
			reader.Seek(0, SeekOrigin.Begin);

			do
			{
				var indicatorSection = IndicatorSection.BuildFrom(reader);
				var identificationSection = IdentificationSection.BuildFrom(reader);

				var message = new Message(indicatorSection, identificationSection);

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
							var productDefinitionSection = ProductDefinitionSection.BuildFrom(reader, indicatorSection.Discipline, identificationSection);
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

				// Saves and restore the current position
				// to avoid losing track of the current message
				// if a data set read happens during the enumeration
				var currentPosition = reader.Position;
				yield return message;
				reader.Seek(currentPosition, SeekOrigin.Begin);

			} while (!reader.HasReachedStreamEnd && reader.PeekSection().Is(SectionCode.IndicatorSection));
		}

		/// <summary>
		/// Enumerates every data sets for each messages in the underlying GRIB 2 stream.
		/// </summary>
		/// <returns>Enumeration of every data sets in the underlying GRIB 2 stream.</returns>
		public IEnumerable<DataSet> ReadAllDataSets() => ReadMessages().SelectMany(m => m.DataSets);

		/// <summary>
		/// Read the data set floating point values.
		/// </summary>
		/// <param name="dataSet">The data set to read.</param>
		/// <returns>The data set point values.</returns>
		public IEnumerable<float?> ReadDataSetRawData(DataSet dataSet) => dataSet.GetRawData(reader);

		/// <summary>
		/// Read the data set grid value.
		/// </summary>
		/// <param name="dataSet">The data set to read.</param>
		/// <returns>The data set grid points and the corresponding values.</returns>
		public IEnumerable<KeyValuePair<Coordinate, float?>> ReadDataSetValues(DataSet dataSet) => dataSet.GetData(reader);

		/// <summary>
		/// Releases the resources used by the <see cref="Grib2Reader"/>.
		/// </summary>
		public void Dispose()
		{
			reader?.Dispose();
		}
	}
}
