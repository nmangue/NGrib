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
	/// Code table 4.3: Type of generating process
	/// </summary>
	public enum GeneratingProcessType
	{
		///<summary>Analysis</summary>
		[Description("Analysis")] Analysis = 0,

		///<summary>Initialization</summary>
		[Description("Initialization")] Initialization = 1,

		///<summary>Forecast</summary>
		[Description("Forecast")] Forecast = 2,

		///<summary>Bias corrected forecast</summary>
		[Description("Bias corrected forecast")]
		BiasCorrectedForecast = 3,

		///<summary>Ensemble forecast</summary>
		[Description("Ensemble forecast")] EnsembleForecast = 4,

		///<summary>Probability forecast</summary>
		[Description("Probability forecast")] ProbabilityForecast = 5,

		///<summary>Forecast error</summary>
		[Description("Forecast error")] ForecastError = 6,

		///<summary>Analysis error</summary>
		[Description("Analysis error")] AnalysisError = 7,

		///<summary>Observation</summary>
		[Description("Observation")] Observation = 8,

		///<summary>Missing</summary>
		[Description("Missing")] Missing = 255,
	}
}