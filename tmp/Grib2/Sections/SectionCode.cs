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

namespace NGrib.Grib2.Sections;

/// <summary>
/// Section Codes.
/// </summary>
public enum SectionCode
{
    /// <summary>
    /// Indicator Section Code.
    /// </summary>
    IndicatorSection,

    /// <summary>
    /// Identification Section Code.
    /// </summary>
    IdentificationSection,

    /// <summary>
    /// Local Use Section Code.
    /// </summary>
    LocalUseSection,

    /// <summary>
    /// Grid Definition Section Code.
    /// </summary>
    GridDefinitionSection,

    /// <summary>
    /// Product Definition Section Code.
    /// </summary>
    ProductDefinitionSection,

    /// <summary>
    /// Data Representation Section Code.
    /// </summary>
    DataRepresentationSection,

    /// <summary>
    /// Bitmap Section Code.
    /// </summary>
    BitmapSection,

    /// <summary>
    /// Data Section Code.
    /// </summary>
    DataSection,

    /// <summary>
    /// End Section Code.
    /// </summary>
    EndSection
}