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
using NGrib.Grib2.Sections;

namespace NGrib.Grib2
{
	/// <summary>
	/// Represents a GRIB2 message.
	/// </summary>
	public sealed class Message
	{
		/// <summary>
		/// Indicator Section.
		/// </summary>
		public IndicatorSection IndicatorSection { get; }

		/// <summary>
		/// Identification Section.
		/// </summary>
		public IdentificationSection IdentificationSection { get; }

		/// <summary>
		/// Data sets in the message.
		/// </summary>
		public IReadOnlyCollection<DataSet> DataSets => dataSets;

		private readonly List<DataSet> dataSets;

		internal Message(IndicatorSection indicatorSection, IdentificationSection identificationSection)
		{
			IndicatorSection = indicatorSection ?? throw new ArgumentNullException(nameof(indicatorSection));
			IdentificationSection = identificationSection ?? throw new ArgumentNullException(nameof(identificationSection));
			dataSets = new List<DataSet>();
		}

		internal void AddDataset(
			LocalUseSection lus,
			GridDefinitionSection gds,
			ProductDefinitionSection pds,
			DataRepresentationSection drs,
			BitmapSection bs,
			DataSection ds)
		{
			var record = new DataSet(
				this,
				lus,
				gds,
				pds,
				drs,
				bs,
				ds);

			dataSets.Add(record);
		}
	}
}