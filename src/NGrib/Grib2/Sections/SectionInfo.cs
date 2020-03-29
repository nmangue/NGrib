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
  /// Represents basic section information.
  /// </summary>
	public readonly struct SectionInfo
	{
		/// <summary>
		/// Length of section in octets.
		/// </summary>
		public long Length { get; }

		/// <summary>
		/// Number of section.
		/// </summary>
		public int SectionCode { get; }

		/// <summary>
		/// Initialize a new instance.
		/// </summary>
		/// <param name="length">Section length.</param>
		/// <param name="sectionCode">Section code.</param>
		public SectionInfo(long length, int sectionCode)
		{
			Length = length;
			SectionCode = sectionCode;
		}

		/// <summary>
		/// Initialize a new instance.
		/// </summary>
		/// <param name="length">Section length.</param>
		/// <param name="sectionCode">Section code.</param>
		public SectionInfo(long length, SectionCode sectionCode) : this(length, (int) sectionCode)
		{
		}

		/// <summary>
		/// Indicates whether this instance section code is equal to a specified section code.
		/// </summary>
		/// <param name="sectionCode">A section code.</param>
		/// <returns><c>true</c> if this instance section is the same as the parameter, <c>false</c> otherwise.</returns>
		public bool Is(SectionCode sectionCode) => SectionCode == (int) sectionCode;
	}
}
