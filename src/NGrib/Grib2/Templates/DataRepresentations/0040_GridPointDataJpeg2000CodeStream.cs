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

using CSJ2K;
using NGrib.Grib2.Sections;
using System.Collections.Generic;

namespace NGrib.Grib2.Templates.DataRepresentations
{
	public class GridPointDataJpeg2000CodeStream : GridPointDataSimplePacking
	{
		/// <summary> Type compression method used (see Code Table 5.40000).</summary>
		/// <returns> CompressionMethod
		/// </returns>
		public int CompressionMethod { get; }

		/// <summary> Compression ratio used .</summary>
		/// <returns> CompressionRatio
		/// </returns>
		public int CompressionRatio { get; }

		internal GridPointDataJpeg2000CodeStream(BufferedBinaryReader reader) : base(reader)
		{
			CompressionMethod = reader.ReadUInt8();

			CompressionRatio = reader.ReadUInt8();
		}

		private protected override IEnumerable<float> DoEnumerateDataValues(BufferedBinaryReader reader, DataSection dataSection, long dataPointsNumber)
		{
			var data = reader.Read((int) dataSection.DataLength);
			var img = J2kImage.FromBytes(data);

			if (img.NumberOfComponents <= 0)
			{
				return new float[0];
			}

			var values = img.GetComponent(0);

			return Unpack(values);
		}
	}
}