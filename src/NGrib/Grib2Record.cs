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

namespace NGrib
{
	/// <summary> Class which represents a record in a Grib2File.</summary>
	public sealed class Grib2Record
	{
		/// <summary> returns Inofrmation Section of record.</summary>
		/// <returns> is
		/// </returns>
		public Grib2IndicatorSection Is { get; }

		/// <summary> returns IdentificationSection.</summary>
		/// <returns> IdentificationSection
		/// </returns>
		public Grib2IdentificationSection ID { get; }

		/// <summary> returns GDS of record.</summary>
		/// <returns> gds
		/// </returns>
		public Grib2GridDefinitionSection GDS { get; }

		/// <summary> returns PDS.</summary>
		/// <returns> pds
		/// </returns>
		public Grib2ProductDefinitionSection PDS { get; }

		/// <summary> returns Data Representation Section.</summary>
		/// <returns> DataRepresentationSection
		/// </returns>
		public Grib2DataRepresentationSection DRS { get; }

		public Grib2BitMapSection Bms { get; }
		public long GdsOffset { get; }
		public long PdsOffset { get; }

		/// <summary> returns Local Use Section.</summary>
		/// <returns> DataRepresentationSection
		/// </returns>
		public Grib2LocalUseSection LUS { get; }

		public Grib2DataSection DataSection { get; }

		/// <summary> Construction for Grib2Record.</summary>
		/// <param name="is">
		/// </param>
		/// <param name="id">
		/// </param>
		/// <param name="gds">
		/// </param>
		/// <param name="pds">
		/// </param>
		/// <param name="drs">
		/// </param>
		/// <param name="bms">
		/// </param>
		/// <param name="gdsOffset">
		/// </param>
		/// <param name="pdsOffset">PDS offset in Grib file
		/// </param>
		public Grib2Record(Grib2IndicatorSection is_Renamed,
			Grib2IdentificationSection id, Grib2GridDefinitionSection gds,
			Grib2ProductDefinitionSection pds, Grib2DataRepresentationSection drs,
			Grib2BitMapSection bms, long gdsOffset, long pdsOffset,
			Grib2LocalUseSection lus)
		{
			Is = is_Renamed;
			ID = id;
			GDS = gds;
			PDS = pds;
			DRS = drs;
			Bms = bms;
			GdsOffset = gdsOffset;
			PdsOffset = pdsOffset;
			LUS = lus;
		}

		internal Grib2Record(
			Grib2IndicatorSection indicatorSection, 
			Grib2IdentificationSection identificationSection, 
			Grib2LocalUseSection localSection, 
			Grib2GridDefinitionSection gridDefinitionSection, 
			Grib2ProductDefinitionSection productDefinitionSection, 
			Grib2DataRepresentationSection dataRepresentationSection, 
			Grib2BitMapSection bitmapSection,
			Grib2DataSection dataSection)
		{
			Is = indicatorSection;
			ID = identificationSection;
			LUS = localSection;
			GDS = gridDefinitionSection;
			PDS = productDefinitionSection;
			DRS = dataRepresentationSection;
			Bms = bitmapSection;
			DataSection = dataSection;
		}

		internal IEnumerable<KeyValuePair<Coordinate, float?>> GetData(BufferedBinaryReader reader)
		{
			return GDS.GridDefinition.EnumerateGridPoints().Zip(GetRawData(reader), (p, v) => new KeyValuePair<Coordinate, float?>(p, v));
		}

		internal IEnumerable<float?> GetRawData(BufferedBinaryReader reader)
		{
			var bitmap = Bms.GetBitmap(reader);
			
			reader.Seek(DataSection.DataOffset, SeekOrigin.Begin);
			using var valuesEnumerator = DRS.DataRepresentation.EnumerateDataValues(reader, DRS.DataPoints).GetEnumerator();
			
			foreach (var isValueDefined in bitmap)
			{
				var v = (bool) isValueDefined && valuesEnumerator.MoveNext() ? valuesEnumerator.Current : DRS.DataRepresentation.MissingValueSubstitute;
				yield return v;
			}
		}
	}
}