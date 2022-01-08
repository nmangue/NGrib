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

using System.ComponentModel;

namespace NGrib.Grib2.CodeTables.LocalTables;

public enum ParameterNumber_DE_DWD {

    #region Product Discipline 0: Meteorological products, Parameter Category 19: Physical atmospheric properties

    ///<summary>Icing Base - Icing Degree Composit (hft)</summary>
    [Description("Icing Base - Icing Degree Composit (hft)")] IcingBase = 195,

    ///<summary>Icing Max Base - Icing Degree Composit (hft)</summary>
    [Description("Icing Max Base - Icing Degree Composit (hft)")] IcingMaxBase = 196,

    ///<summary>Icing Max Top - Icing Degree Composit (hft)</summary>
    [Description("Icing Max Top - Icing Degree Composit (hft)")] IcingMaxTop = 197,

    ///<summary>Icing Top - Icing Degree Composit (hft)</summary>
    [Description("Icing Top - Icing Degree Composit (hft)")] IcingTop = 198,

    ///<summary>
    /// Icing Vertical Code - Icing Degree Composit
    /// Code: 1=continuous,2=discontinuous
    /// (entire atmosphere)
    ///</summary>
    [Description("Icing Vertical Code - Icing Degree Composit")] IcingVerticalCode = 199,

    ///<summary>
    /// Icing Max Code - Icing Degree Composit
    /// Code: 1=light,2=moderate,3=severe
    ///</summary>
    [Description("Icing Max Code - Icing Degree Composit")] IcingMaxCode = 200,

    ///<summary>
    /// Icing Significant Code
    /// Code: 1=general,2=convective,3=stratiform,4=freezing
    ///</summary>
    [Description("Icing Significant Code")] IcingSignificantCode = 206,

    ///<summary>
    /// Icing Degree Code
    /// Code: 1=light,2=moderate,3=severe
    ///</summary>
    [Description("Icing Degree Code")] IcingDegreeCode = 207,

    ///<summary>Eddy dissipation rate (m2 m-3 s-1)</summary>
    [Description("Eddy dissipation rate (m2 m-3 s-1)")] EddyDissipationRate = 216,

    ///<summary>Eddy Dissipation Rate Total Col-Max. Upper FIR (&lt; FL255) (m2 m-3 s-1)</summary>
    [Description("Eddy Dissipation Rate Total Col-Max. Upper FIR (< FL255) (m2 m-3 s-1)")] EddyDissipationRateTotalColMax_UpperFIR = 224,

    ///<summary>Eddy Dissipation Rate Total Col-Max. Lower UIR (&lt; FL350) (m2 m-3 s-1)</summary>
    [Description("Eddy Dissipation Rate Total Col-Max. Lower UIR (< FL350) (m2 m-3 s-1)")] EddyDissipationRateTotalColMax_LowerUIR = 225,

    ///<summary>Eddy Dissipation Rate Total Col-Max. Upper UIR (&lt; FL450) (m2 m-3 s-1)</summary>
    [Description("Eddy Dissipation Rate Total Col-Max. Upper UIR (< FL450) (m2 m-3 s-1)")] EddyDissipationRateTotalColMax_UpperUIR = 226,

    ///<summary>Eddy Dissipation Rate Total Col-Max. Lower FIR (&lt; FL180) (m2 m-3 s-1)</summary>
    [Description("Eddy Dissipation Rate Total Col-Max. Lower FIR (< FL180) (m2 m-3 s-1)")] EddyDissipationRateTotalColMax_LowerFIR = 228,

    #endregion

}