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