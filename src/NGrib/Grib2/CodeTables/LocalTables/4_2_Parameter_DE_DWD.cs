/*
 * This file is part of NGrib.
 * Created by Andreas Dekiert
 *
 * Copyright (c) 2022 Remy Webservices
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
 * along with NGrib. If not, see <https://www.gnu.org/licenses/>.
 */

namespace NGrib.Grib2.CodeTables.LocalTables;

public readonly struct Parameter_DE_DWD {

    #region Product Discipline 0: Meteorological products, Parameter Category 19: Physical atmospheric properties

    ///<summary>Icing Base - Icing Degree Composit (hft)</summary>
    public static Parameter IcingBase { get; } = new Parameter(ParameterCategory.PhysicalAtmosphericProperties, 195, "Icing Base", "hft");

    ///<summary>Icing Max Base - Icing Degree Composit (hft)</summary>
    public static Parameter IcingMaxBase { get; } = new Parameter(ParameterCategory.PhysicalAtmosphericProperties, 196, "Icing Max Base", "hft");

    ///<summary>Icing Max Top - Icing Degree Composit (hft)</summary>
    public static Parameter IcingMaxTop { get; } = new Parameter(ParameterCategory.PhysicalAtmosphericProperties, 197, "Icing Max Top", "hft");

    ///<summary>Icing Top - Icing Degree Composit (hft)</summary>
    public static Parameter IcingTop { get; } = new Parameter(ParameterCategory.PhysicalAtmosphericProperties, 198, "Icing Top", "hft");

    ///<summary>
    /// Icing Vertical Code - Icing Degree Composit
    /// Code: 1=continuous,2=discontinuous
    /// (entire atmosphere)
    ///</summary>
    public static Parameter IcingVerticalCode { get; } = new Parameter(ParameterCategory.PhysicalAtmosphericProperties, 199, "Icing Vertical Code", "code");

    ///<summary>
    /// Icing Max Code - Icing Degree Composit
    /// Code: 1=light,2=moderate,3=severe
    ///</summary>
    public static Parameter IcingMaxCode { get; } = new Parameter(ParameterCategory.PhysicalAtmosphericProperties, 200, "Icing Max Code", "code");

    ///<summary>
    /// Icing Significant Code
    /// Code: 1=general,2=convective,3=stratiform,4=freezing
    ///</summary>
    public static Parameter IcingSignificantCode { get; } = new Parameter(ParameterCategory.PhysicalAtmosphericProperties, 206, "Icing Significant Code", "code");

    ///<summary>
    /// Icing Degree Code
    /// Code: 1=light,2=moderate,3=severe
    ///</summary>
    public static Parameter IcingDegreeCode { get; } = new Parameter(ParameterCategory.PhysicalAtmosphericProperties, 207, "Icing Degree Code", "code");

    ///<summary>Eddy dissipation rate (m2 m-3 s-1)</summary>
    public static Parameter EddyDissipationRate { get; } = new Parameter(ParameterCategory.PhysicalAtmosphericProperties, 216, "Eddy dissipation rate", "m2 m-3 s-1");

    ///<summary>Eddy Dissipation Rate Total Col-Max. Upper FIR (&lt; FL255) (m2 m-3 s-1)</summary>
    public static Parameter EddyDissipationRateTotalColMax_UpperFIR { get; } = new Parameter(ParameterCategory.PhysicalAtmosphericProperties, 224, "Eddy Dissipation Rate Total Col-Max. Upper FIR (< FL255)", "m2 m-3 s-1");

    ///<summary>Eddy Dissipation Rate Total Col-Max. Lower UIR (&lt; FL350) (m2 m-3 s-1)</summary>
    public static Parameter EddyDissipationRateTotalColMax_LowerUIR { get; } = new Parameter(ParameterCategory.PhysicalAtmosphericProperties, 225, "Eddy Dissipation Rate Total Col-Max. Lower UIR (< FL350)", "m2 m-3 s-1");

    ///<summary>Eddy Dissipation Rate Total Col-Max. Upper UIR (&lt; FL450) (m2 m-3 s-1)</summary>
    public static Parameter EddyDissipationRateTotalColMax_UpperUIR { get; } = new Parameter(ParameterCategory.PhysicalAtmosphericProperties, 226, "Eddy Dissipation Rate Total Col-Max. Upper UIR (< FL450)", "m2 m-3 s-1");

    ///<summary>Eddy Dissipation Rate Total Col-Max. Lower FIR (&lt; FL180) (m2 m-3 s-1)</summary>
    public static Parameter EddyDissipationRateTotalColMax_LowerFIR { get; } = new Parameter(ParameterCategory.PhysicalAtmosphericProperties, 228, "Eddy Dissipation Rate Total Col-Max. Lower FIR (< FL180)", "m2 m-3 s-1");

    #endregion

}