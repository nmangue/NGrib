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

namespace NGrib
{
	internal class Constants
	{
		public static byte[] GribFileStart = { 0x47, 0x52, 0x49, 0x42 };

		/// <summary>
		/// "GRIB" (coded according to the International Alphabet No. 5.)
		/// converted to long.
		/// </summary>
		public static long GribFileStartCode = 1196575042;

		public static byte[] GribFileEnd = { 0x37, 0x37, 0x37, 0x37 };

		/// <summary>
		/// "7777" (coded according to the International Alphabet No. 5.)
		/// converted to long.
		/// </summary>
		public static long GribFileEndCode = 926365495;

		public static long IndicatorSectionLength = 16;
		public static long EndSectionLength = 16;
	}
}