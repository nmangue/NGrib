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

namespace NGrib.Grib2.Sections
{
	/// <summary>
	/// Section 8 - End Section
	/// </summary>
	public sealed class EndSection
	{
		/// <summary>
		/// Length of section in octets.
		/// </summary>
		public long Length { get; }

		/// <summary>
		/// Number of section.
		/// </summary>
		public int Section { get; }

		private EndSection(long length, int section)
		{
			Length = length;
			Section = section;
		}

		internal static EndSection BuildFrom(BufferedBinaryReader reader)
		{
			var sectionInfos = reader.ReadSectionInfo();
			if (!sectionInfos.Is(SectionCode.EndSection))
			{
				throw new NoValidGribException("");
			}

			return new EndSection(sectionInfos.Length, sectionInfos.SectionCode);
		}
	}
}