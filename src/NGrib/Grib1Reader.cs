using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NGrib.Grib1;

namespace NGrib
{
	public class Grib1Reader : IDisposable
	{
		private readonly bool leaveOpen;
		private Grib1Input input;
		private Grib1Data data;

		/// <summary>
		/// Initializes a new instance of the <c>Grib2Reader</c> class
		/// based on the specified file.
		/// </summary>
		/// <param name="filePath">The GRIB 2 file path.</param>
		public Grib1Reader(string filePath) : this(File.OpenRead(filePath))
		{ }

		/// <summary>
		/// Initializes a new instance of the <c>Grib2Reader</c> class
		/// based on the specified stream.
		/// </summary>
		/// <param name="input">The GRIB 2 input stream.</param>
		/// <param name="leaveOpen"><c>true</c>to leave the stream open after the <see cref="Grib2Reader"/> object is disposed; otherwise, <c>false</c>.</param>
		public Grib1Reader(Stream input, bool leaveOpen = false)
		{
			if (input == null) throw new ArgumentNullException(nameof(input));
			if (!input.CanRead) throw new ArgumentException("The stream must support reading.", nameof(input));
			if (!input.CanSeek) throw new ArgumentException("The stream must support seeking.", nameof(input));
			this.leaveOpen = leaveOpen;

			this.input = new Grib1Input(input);
			data = new Grib1Data(input);
		}

		/// <summary>
		/// Enumerates the records in the underlying stream.
		/// </summary>
		/// <returns>The records in the GRIB11 stream.</returns>
		public IEnumerable<Grib1Record> ReadRecords() => input.scanRecords();


		/// <summary>
		/// Read the data set floating point values.
		/// </summary>
		/// <param name="record">The record to read.</param>
		/// <param name="hasBitmapSection">Indicates whether the Bit-map section was used by the GRIB file producer.</param>
		/// <returns>The data set point values.</returns>
		public float[] ReadRecordRawData(Grib1Record record, bool hasBitmapSection = false) => data.getData(record.DataOffset, record.ProductDefinitionSection.DecimalScale, false, record);

		/// <summary>
		/// Read the records grid value.
		/// </summary>
		/// <param name="record">The record to read.</param>
		/// <param name="hasBitmapSection">Indicates whether the Bit-map section was used by the GRIB file producer.</param>
		/// <returns>The record grid points and the corresponding values.</returns>
		public IEnumerable<KeyValuePair<Coordinate, float>> ReadRecordValues(Grib1Record record, bool hasBitmapSection = false)
		{
			var rawData = ReadRecordRawData(record, hasBitmapSection);

			return record.GridDefinitionSection.EnumerateGridPoints()
				.Zip(rawData, (c, v) => new KeyValuePair<Coordinate, float>(c, v));
		}

		public void Dispose()
		{
			if (!leaveOpen)
			{
				input.InputStream.Close();
			}
		}
	}
}
