﻿/*
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

namespace NGrib.Grib2.CodeTables
{
	/// <summary>
	/// Code Table 5.4: Group Splitting Method
	/// </summary>
	public enum GroupSplittingMethod
	{
		/// <summary>
		/// Row by row splitting
		/// </summary>
		RowByRow,

		/// <summary>
		/// General group splitting
		/// </summary>
		GeneralGroup,

		/// <summary>
		/// Missing
		/// </summary>
		Missing,
	}
}