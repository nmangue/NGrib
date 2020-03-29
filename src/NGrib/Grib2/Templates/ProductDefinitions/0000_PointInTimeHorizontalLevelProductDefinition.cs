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
    /// Product Definition Template 4.0: Analysis or forecast at a horizontal level or in a horizontal layer at a point in time
    /// </summary>
    public class PointInTimeHorizontalLevelProductDefinition : WithBackgroundProductDefinition
    {
        /// <summary> analysisGenProcess.</summary>
        /// <returns> analysisGenProcess
        /// </returns>
        public int AnalysisGenProcess { get; }

        /// <summary> hoursAfter.</summary>
        /// <returns> HoursAfter
        /// </returns>
        public int HoursAfter { get; }

        /// <summary> minutesAfter.</summary>
        /// <returns>  MinutesAfter
        /// </returns>
        public int MinutesAfter { get; }

        /// <summary> returns timeRangeUnit .</summary>
        /// <returns> TimeRangeUnitName
        /// </returns>
        public int TimeRangeUnit { get; }

        /// <summary> forecastTime.</summary>
        /// <returns> ForecastTime
        /// </returns>
        public long ForecastTime { get; }

        /// <summary> typeFirstFixedSurface.</summary>
        /// <returns> FirstFixedSurface as int
        /// </returns>
        public int TypeFirstFixedSurface { get; }

        /// <summary> valueFirstFixedSurface.</summary>
        /// <returns> FirstFixedSurfaceValue
        /// </returns>
        public float ValueFirstFixedSurface { get; }

        /// <summary> typeSecondFixedSurface.</summary>
        /// <returns>  SecondFixedSurface as int
        /// </returns>
        public int TypeSecondFixedSurface { get; }

        /// <summary> valueSecondFixedSurface.</summary>
        /// <returns> SecondFixedSurfaceValue
        /// </returns>
        public float ValueSecondFixedSurface { get; }

        internal PointInTimeHorizontalLevelProductDefinition(BufferedBinaryReader reader) : base(reader)
        {
            AnalysisGenProcess = reader.ReadUInt8();
            HoursAfter = reader.ReadUInt16();
            MinutesAfter = reader.ReadUInt8();
            TimeRangeUnit = reader.ReadUInt8();
            ForecastTime = reader.ReadUInt32();

            TypeFirstFixedSurface = reader.ReadUInt8();
            int scaleFirstFixedSurface = reader.ReadUInt8();
            long valueFirstFixedSurface = reader.ReadUInt32();
			
            ValueFirstFixedSurface = (float)((scaleFirstFixedSurface == 0 || valueFirstFixedSurface == 0)
                ? valueFirstFixedSurface
                : Math.Pow(valueFirstFixedSurface, -scaleFirstFixedSurface));

            TypeSecondFixedSurface = reader.ReadUInt8();
            int scaleSecondFixedSurface = reader.ReadUInt8();
            long valueSecondFixedSurface = reader.ReadUInt32();

            ValueSecondFixedSurface = (float)((scaleSecondFixedSurface == 0 || valueSecondFixedSurface == 0)
                ? valueSecondFixedSurface
                : Math.Pow(valueSecondFixedSurface, -scaleSecondFixedSurface));
        }
    }
}