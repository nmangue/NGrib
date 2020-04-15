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

namespace NGrib.Grib1
{
	/// <summary> Grib1Record contains all the sections of a Grib record.</summary>
	/// <author>  Robb Kambic  11/13/03
	/// </author>
	public sealed class Grib1Record
	{
		/// <summary>  Get header.</summary>
		/// <returns> header
		/// </returns>
		public System.String Header { get; }

		/// <summary>  Get Information record.</summary>
		/// <returns> an IS record
		/// </returns>
		public Grib1IndicatorSection IndicatorSection { get; }

		/// <summary> Get Product Definition record.</summary>
		/// <returns> a PDS record
		/// </returns>
		public Grib1ProductDefinitionSection ProductDefinitionSection { get; }

		/// <summary> Get Grid Definition record.</summary>
		/// <returns> a
		/// </returns>
		public Grib1GridDefinitionSection GridDefinitionSection { get; }

		/// <summary> Get offset to bms.</summary>
		/// <returns> long
		/// </returns>
		public long DataOffset { get; } = -1;

		public long RecordOffset { get; } = -1;

		private long endRecordOffset = -1;

		internal Grib1Record(System.String hdr, Grib1IndicatorSection aIndicatorSection, Grib1ProductDefinitionSection aProductDefinitionSection, Grib1GridDefinitionSection aGridDefinitionSection, long offset, long recOffset, long startOfRecordOffset)
		{
			Header = hdr;
			IndicatorSection = aIndicatorSection;
			ProductDefinitionSection = aProductDefinitionSection;
			GridDefinitionSection = aGridDefinitionSection;
			DataOffset = offset;
			endRecordOffset = recOffset;
			RecordOffset = startOfRecordOffset;
		}
	} // end Grib1Record
}