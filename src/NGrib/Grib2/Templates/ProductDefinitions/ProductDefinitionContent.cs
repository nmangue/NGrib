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

using NGrib.Grib2.CodeTables;
using System;

namespace NGrib.Grib2.Templates.ProductDefinitions
{
	/// <summary>
	/// Catalog of the product definition contents.
	/// </summary>
	public static class ProductDefinitionContent
	{
		/// <summary>
		/// Parameter category (see Code Table 4.1).
		/// </summary>
		public static TemplateContent<int> ParameterCategory { get; } = new TemplateContent<int>();

		/// <summary>
		/// Parameter number (see Code Table 4.2).
		/// </summary>
		public static TemplateContent<int> ParameterNumber { get; } = new TemplateContent<int>();

		/// <summary>
		/// Parameter.
		/// </summary>
		public static TemplateContent<Parameter> Parameter { get; } = new TemplateContent<Parameter>();

		/// <summary>
		/// Type of generating process (see Code Table 4.3).
		/// </summary>
		public static TemplateContent<GeneratingProcessType> GeneratingProcessType { get; } = new TemplateContent<GeneratingProcessType>();

		/// <summary>
		/// Background generating process identifier (defined by originating centre).
		/// </summary>
		public static TemplateContent<int> BackgroundGeneratingProcessId { get; } = new TemplateContent<int>();

		/// <summary>
		/// Analysis or forecast generating processes identifier (defined by originating centre).
		/// </summary>
		public static TemplateContent<int> GeneratingProcessId { get; } = new TemplateContent<int>();

		/// <summary>
		/// Time span of observational data cutoff after reference time.
		/// </summary>
		public static TemplateContent<TimeSpan> ObservationalDataCutoff { get; } = new TemplateContent<TimeSpan>();

		/// <summary>
		/// Forecast time.
		/// </summary>
		public static TemplateContent<TimeSpan> ForecastTime { get; } = new TemplateContent<TimeSpan>();

		/// <summary>
		/// Type of first fixed surface (see Code Table 4.5).
		/// </summary>
		public static TemplateContent<FixedSurfaceType> FirstFixedSurfaceType { get; } = new TemplateContent<FixedSurfaceType>();

		/// <summary>
		/// Value of first fixed surface.
		/// </summary>
		public static TemplateContent<double> FirstFixedSurfaceValue { get; } = new TemplateContent<double>();

		/// <summary>
		/// Type of second fixed surface (see Code Table 4.5).
		/// </summary>
		public static TemplateContent<FixedSurfaceType> SecondFixedSurfaceType { get; } = new TemplateContent<FixedSurfaceType>();

		/// <summary>
		/// Value of second fixed surface.
		/// </summary>
		public static TemplateContent<double> SecondFixedSurfaceValue { get; } = new TemplateContent<double>();

		/// <summary>
		/// Type of ensemble forecast (see Code Table 4.6).
		/// </summary>
		public static TemplateContent<EnsembleForecastType> EnsembleForecastType { get; } = new TemplateContent<EnsembleForecastType>();

		/// <summary>
		/// Perturbation number.
		/// </summary>
		public static TemplateContent<int> PerturbationNumber { get; } = new TemplateContent<int>();

		/// <summary>
		/// Number of forecasts in ensemble.
		/// </summary>
		public static TemplateContent<int> EnsembleForecastsNumber { get; } = new TemplateContent<int>();

		/// <summary>
		/// Derived forecast (see Code Table 4.7).
		/// </summary>
		public static TemplateContent<int> DerivedForecast { get; } = new TemplateContent<int>();

		/// <summary>
		/// Datetime of end of overall time interval.
		/// </summary>
		public static TemplateContent<DateTime> OverallTimeIntervalEnd { get; } = new TemplateContent<DateTime>();

		/// <summary>
		/// Time range over which statistical processing is done.
		/// </summary>
		public static TemplateContent<TimeSpan> StatisticalProcessingTimeRange { get; } = new TemplateContent<TimeSpan>();

		/// <summary>
		/// Time increment between successive fields.
		/// </summary>
		public static TemplateContent<TimeSpan> SuccessiveFieldsTimeIncrement { get; } = new TemplateContent<TimeSpan>();
	}
}
