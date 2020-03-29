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

using System;

namespace NGrib.Grib2.Templates.ProductDefinitions
{
	/// <summary>
	/// Product Definition Template 4.8:  Average, accumulation, and/or extreme values
	/// or other statistically processed values at a horizontal level or in a horizontal
	/// layer in a continuous or non-continuous time interval
	/// </summary>
	public class StatisticallyProcessedPointInTimeHorizontalLevelProductDefinition : PointInTimeHorizontalLevelProductDefinition
	{
		private DateTime endTime;
		private int timeRanges;
		private long missingDataValues;
		private int outmostTimeRange;
		private int missing;
		private int statisticalProcess;
		private long timeIncrementType;
		private int indicatorTr;
		private long lengthTr;
		private int indicatorTuIncrement;
		private long timeIncrement;

		internal StatisticallyProcessedPointInTimeHorizontalLevelProductDefinition(BufferedBinaryReader reader) :
			base(reader)
		{
			endTime = reader.ReadDateTime();

			// 42
			timeRanges = reader.ReadUInt8();

			// 43-46  
			missingDataValues = reader.ReadUInt32();

			//47
			statisticalProcess = reader.ReadUInt8();
			//48
			timeIncrementType = reader.ReadUInt8();
			//49
			indicatorTr = reader.ReadUInt8();
			//50-53
			lengthTr = reader.ReadUInt32();
			//54
			indicatorTuIncrement = reader.ReadUInt8();
			//55-58
			timeIncrement = reader.ReadUInt32();
		}
	}
}