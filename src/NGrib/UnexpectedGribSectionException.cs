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

using NGrib.Grib2.Sections;

namespace NGrib
{
	/// <summary>
	/// The exception that is thrown when the read section number is not
	/// the expected one.
	/// </summary>
	public class UnexpectedGribSectionException : BadGribFormatException
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UnexpectedGribSectionException"/> class.
		/// </summary>
		/// <param name="expectedSectionCode">The expected section code.</param>
		/// <param name="readSectionCode">The section code actually read.</param>
		public UnexpectedGribSectionException(SectionCode expectedSectionCode, int readSectionCode) 
			: base($"Expected section {expectedSectionCode} but found {readSectionCode}")
		{
		}
	}
}