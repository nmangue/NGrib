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

using System.ComponentModel;

namespace NGrib.Grib2.CodeTables
{
	/// <summary>
	/// Code Table 4.4: Indicator of unit of time range
	/// </summary>
	public enum TimeRangeUnit
	{
		///<summary>Minute</summary>
		[Description("Minute")] Minute = 0,

		///<summary>Hour</summary>
		[Description("Hour")] Hour = 1,

		///<summary>Day</summary>
		[Description("Day")] Day = 2,

		///<summary>Month</summary>
		[Description("Month")] Month = 3,

		///<summary>Year</summary>
		[Description("Year")] Year = 4,

		///<summary>Decade (10 years)</summary>
		[Description("Decade (10 years)")] Decade = 5,

		///<summary>Normal (30 years)</summary>
		[Description("Normal (30 years)")] Normal = 6,

		///<summary>Century (100 years)</summary>
		[Description("Century (100 years)")] Century = 7,

		///<summary>3 hours</summary>
		[Description("3 hours")] Hours3 = 10,

		///<summary>6 hours</summary>
		[Description("6 hours")] Hours6 = 11,

		///<summary>12 hours</summary>
		[Description("12 hours")] Hours12 = 12,

		///<summary>Second</summary>
		[Description("Second")] Second = 13,

		///<summary>Missing</summary>
		[Description("Missing")] Missing = 255,
	}
}