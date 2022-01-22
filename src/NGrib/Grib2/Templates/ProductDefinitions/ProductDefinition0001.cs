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

namespace NGrib.Grib2.Templates.ProductDefinitions
{
	/// <summary>
	/// Product Definition Template 4.1: Individual ensemble forecast, control and perturbed, at ahorizontal level or in a horizontal layer at a point in time.
	/// </summary>
	public class ProductDefinition0001 : ProductDefinition0000
	{
		/// <summary>
		/// Type of ensemble forecast (see Code table 4.6).
		/// </summary>
		public EnsembleForecastType EnsembleForecastType { get; }

		/// <summary>
		/// Perturbation number.
		/// </summary>
		public int PerturbationNumber { get; }

		/// <summary>
		/// Number of forecasts in ensemble
		/// </summary>
		public int EnsembleForecastsNumber { get; }

		internal ProductDefinition0001(BufferedBinaryReader reader, Discipline discipline,
		                               int centerCode) : base(reader, discipline, centerCode)
		{
			EnsembleForecastType = (EnsembleForecastType) reader.ReadByte();
			PerturbationNumber = reader.ReadByte();
			EnsembleForecastsNumber = reader.ReadByte();

			RegisterContent(ProductDefinitionContent.EnsembleForecastType, () => EnsembleForecastType);
			RegisterContent(ProductDefinitionContent.PerturbationNumber, () => PerturbationNumber);
			RegisterContent(ProductDefinitionContent.EnsembleForecastsNumber, () => EnsembleForecastsNumber);
		}
	}
}
