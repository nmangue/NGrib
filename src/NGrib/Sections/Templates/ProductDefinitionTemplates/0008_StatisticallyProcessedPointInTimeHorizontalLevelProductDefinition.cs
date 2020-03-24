using System;

namespace NGrib.Sections.Templates.ProductDefinitionTemplates
{
    /// <summary>
    /// Product Definition Template 4.8:  Average, accumulation, and/or extreme values
    /// or other statistically processed values at a horizontal level or in a horizontal
    /// layer in a continuous or non-continuous time interval
    /// </summary>
    public class StatisticallyProcessedPointInTimeHorizontalLevelProductDefinition : PointInTimeHorizontalLevelProductDefinition
    {
        internal StatisticallyProcessedPointInTimeHorizontalLevelProductDefinition(BufferedBinaryReader reader) : base(reader)
        {
            int year = reader.ReadUInt16();
            int month = reader.ReadUInt8();
            int day = reader.ReadUInt8();
            int hour = reader.ReadUInt8();
            int minute = reader.ReadUInt8();
            int second = reader.ReadUInt8();
            
            var endTime = new DateTime(year, month, day, hour, minute, second, DateTimeKind.Utc);
            
            int timeRanges = reader.ReadUInt8();

            long missingDataValues = reader.ReadUInt32();

            int outmostTimeRange = reader.ReadUInt8();

            int missing = reader.ReadUInt8();

            int statisticalProcess = reader.ReadUInt8();

            long timeIncrement = reader.ReadUInt32();

            int indicatorTR = reader.ReadUInt8();

            long lengthTR = reader.ReadUInt32();
        }
    }
}