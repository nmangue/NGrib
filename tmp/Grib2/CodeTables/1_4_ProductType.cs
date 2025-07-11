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

namespace NGrib.Grib2.CodeTables;

/// <summary>
/// Code Table 1.4: Type of data
/// </summary>
public enum ProductType
{
    /// <summary>
    /// Analysis products
    /// </summary>
    AnalysisProducts = 0,

    /// <summary>
    /// Forecast products
    /// </summary>
    ForecastProducts = 1,

    /// <summary>
    /// Analysis and forecast products
    /// </summary>
    AnalysisAndForecastProducts = 2,

    /// <summary>
    /// Control forecast products
    /// </summary>
    ControlForecastProducts = 3,

    /// <summary>
    /// Perturbed forecast products
    /// </summary>
    PerturbedForecastProducts = 4,

    /// <summary>
    /// Control and perturbed forecast products
    /// </summary>
    ControlAndPerturbedForecastProducts = 5,

    /// <summary>
    /// Processed satellite observations
    /// </summary>
    ProcessedSatelliteObservations = 6,

    /// <summary>
    /// Processed radar observations
    /// </summary>
    ProcessedRadarObservations = 7,

    /// <summary>
    /// Missing
    /// </summary>
    Missing = 255
}