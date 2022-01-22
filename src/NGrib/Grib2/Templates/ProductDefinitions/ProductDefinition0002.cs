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
	/// Product Definition Template 4.2: Derived forecast based on all ensemble members at a horizontal level 
	/// or in a horizontal layer at a point in time.
	/// </summary>
	public class ProductDefinition0002 : ProductDefinition0000
	{
		/// <summary>
		/// Derived forecast (see Code Table 4.7)
		/// </summary>
		public int DerivedForecast { get; }

		/// <summary>
		/// Number of forecasts in ensemble
		/// </summary>
		public int EnsembleForecastsNumber { get; }

		internal ProductDefinition0002(BufferedBinaryReader reader, Discipline discipline, int centerCode)
			: base(reader, discipline, centerCode)
		{
			DerivedForecast = reader.ReadByte();
			EnsembleForecastsNumber = reader.ReadByte();

			RegisterContent(ProductDefinitionContent.DerivedForecast, () => DerivedForecast);
			RegisterContent(ProductDefinitionContent.EnsembleForecastsNumber, () => EnsembleForecastsNumber);
		}
	}
}