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

namespace NGrib.Grib2.Sections
{
	/// <summary>
	/// Section 2 - Local Use Section
	/// </summary>
	public sealed class LocalUseSection
	{
		/// <summary>
		/// Length of section in octets.
		/// </summary>
		public long Length { get; }

		/// <summary>
		/// Number of section.
		/// </summary>
		public int Section { get; }

		/// <summary>
		/// Position at which the local use data begins.
		/// </summary>
		internal long ContentOffset { get; }
		
		private LocalUseSection(long length, int section, long contentOffset)
		{
			Length = length;
			Section = section;
			ContentOffset = contentOffset;
		}

		internal static LocalUseSection BuildFrom(BufferedBinaryReader reader)
		{
			// octets 1-4 (Length of GDS)
			var length = reader.ReadUInt32();

			var section = reader.ReadUInt8();
			if (section != (int) SectionCode.LocalUseSection)
			{
				return null;
			}

			var contentOffset = reader.Position;
			reader.Skip((int) length - 5);
			return new LocalUseSection(length, section, contentOffset);
		}
	}
}