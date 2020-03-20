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

namespace NGrib.Sections
{
    public interface IGrib2DataRepresentationSection
    {
        int BinaryScaleFactor { get; }
        int BitsGroupWidths { get; }
        int BitsScaledGroupLength { get; }
        int CompressionMethod { get; }
        int CompressionRatio { get; }
        int DataPoints { get; }
        int DataTemplateNumber { get; }
        int DecimalScaleFactor { get; }
        int DescriptorSpatial { get; }
        int Length { get; }
        int LengthIncrement { get; }
        int LengthLastGroup { get; }
        int MissingValueManagement { get; }
        int NumberOfBits { get; }
        int NumberOfGroups { get; }
        int OrderSpatial { get; }
        int OriginalType { get; }
        float PrimaryMissingValue { get; }
        int ReferenceGroupLength { get; }
        int ReferenceGroupWidths { get; }
        float ReferenceValue { get; }
        float SecondaryMissingValue { get; }
        int SplittingMethod { get; }
    }
}
