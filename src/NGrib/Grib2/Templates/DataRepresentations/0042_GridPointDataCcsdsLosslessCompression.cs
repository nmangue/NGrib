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
using Libaec;
using NGrib.Grib2.Sections;
using static Libaec.AecDataFlags;

namespace NGrib.Grib2.Templates.DataRepresentations
{
    /// <summary>
    /// Data Representation Template 5. : Grid point data - CCSDS recommended lossless compression
    /// </summary>
    public class GridPointDataCcsdsLosslessCompression : GridPointDataSimplePacking
	{
        /// <summary>
        /// CCSDS compression options mask.
        /// </summary>
        public int Flags { get; }

        /// <summary>
        /// Block size.
        /// </summary>
        public int BlockSize { get; }

        /// <summary>
        /// Reference sample interval.
        /// </summary>
        public int Rsi { get; }

        private readonly AecDecoder decoder;

		internal GridPointDataCcsdsLosslessCompression(BufferedBinaryReader reader) : base(reader)
		{
			Flags = reader.ReadByte();
			BlockSize = reader.ReadByte();
			Rsi = reader.ReadInt16();

            AecDataFlags decodingFlags = (AecDataFlags)Flags;

            // No need for 3-bytes per value representation
            decodingFlags &= ~AEC_DATA_3BYTE;

            // Use endianness corresponding to current environment
            if (BitConverter.IsLittleEndian)
            {
                decodingFlags &= ~AEC_DATA_MSB;
            }
            else
            {
                decodingFlags |= AEC_DATA_MSB;
            }

            decoder = new AecDecoder(NumberOfBits, decodingFlags, BlockSize, Rsi);
        }

        private protected override IEnumerable<int> ReadPackedValues(BufferedBinaryReader reader, DataSection dataSection, long dataPointsNumber)
        {
            var compressedData = reader.Read((int)dataSection.DataLength);

            var uValues = decoder.Decode(compressedData, compressedData.Length, (int)dataPointsNumber);
    
            return Array.ConvertAll(uValues, static item => (int) item);
        }
    }
}