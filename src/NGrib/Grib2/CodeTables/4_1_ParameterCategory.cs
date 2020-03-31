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

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace NGrib.Grib2.CodeTables
{
	/// <summary>
	/// Represents a category parameters by product discipline.
	/// </summary>
	public struct ParameterCategory
	{
		/// <summary>
		/// Product discipline.
		/// </summary>
		public Discipline Discipline { get; }

		/// <summary>
		/// Parameter category code.
		/// </summary>
		public int Code { get; }

		/// <summary>
		/// Parameter category description.
		/// </summary>
		public string Description { get; }

		private ParameterCategory(Discipline discipline, int code, string description)
		{
			Discipline = discipline;
			Code = code;
			Description = description;
		}

		///<summary>Temperature</summary>
		public static ParameterCategory Temperature { get; } = new ParameterCategory(Discipline.MeteorologicalProducts, 0, "Temperature");

		///<summary>Moisture</summary>
		public static ParameterCategory Moisture { get; } = new ParameterCategory(Discipline.MeteorologicalProducts, 1, "Moisture");

		///<summary>Momentum</summary>
		public static ParameterCategory Momentum { get; } = new ParameterCategory(Discipline.MeteorologicalProducts, 2, "Momentum");

		///<summary>Mass</summary>
		public static ParameterCategory Mass { get; } = new ParameterCategory(Discipline.MeteorologicalProducts, 3, "Mass");

		///<summary>Short-wave Radiation</summary>
		public static ParameterCategory ShortWaveRadiation { get; } =
			new ParameterCategory(Discipline.MeteorologicalProducts, 4, "Short-wave Radiation");

		///<summary>Long-wave Radiation</summary>
		public static ParameterCategory LongWaveRadiation { get; } =
			new ParameterCategory(Discipline.MeteorologicalProducts, 5, "Long-wave Radiation");

		///<summary>Cloud</summary>
		public static ParameterCategory Cloud { get; } = new ParameterCategory(Discipline.MeteorologicalProducts, 6, "Cloud");

		///<summary>Thermodynamic Stability indices</summary>
		public static ParameterCategory ThermodynamicStabilityIndices { get; } = new ParameterCategory(Discipline.MeteorologicalProducts,
			7, "Thermodynamic Stability indices");

		///<summary>Kinematic Stability indices</summary>
		public static ParameterCategory KinematicStabilityIndices { get; } =
			new ParameterCategory(Discipline.MeteorologicalProducts, 8, "Kinematic Stability indices");

		///<summary>Temperature Probabilities</summary>
		public static ParameterCategory TemperatureProbabilities { get; } =
			new ParameterCategory(Discipline.MeteorologicalProducts, 9, "Temperature Probabilities");

		///<summary>Moisture Probabilities</summary>
		public static ParameterCategory MoistureProbabilities { get; } =
			new ParameterCategory(Discipline.MeteorologicalProducts, 10, "Moisture Probabilities");

		///<summary>Momentum Probabilities</summary>
		public static ParameterCategory MomentumProbabilities { get; } =
			new ParameterCategory(Discipline.MeteorologicalProducts, 11, "Momentum Probabilities");

		///<summary>Mass Probabilities</summary>
		public static ParameterCategory MassProbabilities { get; } =
			new ParameterCategory(Discipline.MeteorologicalProducts, 12, "Mass Probabilities");

		///<summary>Aerosols</summary>
		public static ParameterCategory Aerosols { get; } = new ParameterCategory(Discipline.MeteorologicalProducts, 13, "Aerosols");

		///<summary>Trace gases (e.g., ozone, CO2)</summary>
		public static ParameterCategory TraceGases { get; } =
			new ParameterCategory(Discipline.MeteorologicalProducts, 14, "Trace gases (e.g., ozone, CO2)");

		///<summary>Radar</summary>
		public static ParameterCategory Radar { get; } = new ParameterCategory(Discipline.MeteorologicalProducts, 15, "Radar");

		///<summary>Forecast Radar Imagery</summary>
		public static ParameterCategory ForecastRadarImagery { get; } =
			new ParameterCategory(Discipline.MeteorologicalProducts, 16, "Forecast Radar Imagery");

		///<summary>Electro-dynamics</summary>
		public static ParameterCategory Electrodynamics { get; } =
			new ParameterCategory(Discipline.MeteorologicalProducts, 17, "Electro-dynamics");

		///<summary>Nuclear/radiology</summary>
		public static ParameterCategory NuclearRadiology { get; } =
			new ParameterCategory(Discipline.MeteorologicalProducts, 18, "Nuclear/radiology");

		///<summary>Physical atmospheric properties</summary>
		public static ParameterCategory PhysicalAtmosphericProperties { get; } = new ParameterCategory(Discipline.MeteorologicalProducts,
			19, "Physical atmospheric properties");

		///<summary>CCITT IA5 string</summary>
		public static ParameterCategory CcittIa5String { get; } =
			new ParameterCategory(Discipline.MeteorologicalProducts, 190, "CCITT IA5 string");

		///<summary>Miscellaneous</summary>
		public static ParameterCategory Miscellaneous { get; } =
			new ParameterCategory(Discipline.MeteorologicalProducts, 191, "Miscellaneous");


		///<summary>Hydrology basic products</summary>
		public static ParameterCategory HydrologyBasicProducts { get; } =
			new ParameterCategory(Discipline.HydrologicalProducts, 0, "Hydrology basic products");

		///<summary>Hydrology probabilities</summary>
		public static ParameterCategory HydrologyProbabilities { get; } =
			new ParameterCategory(Discipline.HydrologicalProducts, 1, "Hydrology probabilities");


		///<summary>Vegetation/Biomass</summary>
		public static ParameterCategory VegetationBiomass { get; } =
			new ParameterCategory(Discipline.LandSurfaceProducts, 0, "Vegetation/Biomass");

		///<summary>Agri-/aquacultural Special Products</summary>
		public static ParameterCategory AgriAquaCulturalSpecialProducts { get; } = new ParameterCategory(Discipline.LandSurfaceProducts,
			1, "Agri-/aquacultural Special Products");

		///<summary>Transportation-related Products</summary>
		public static ParameterCategory TransportationRelatedProducts { get; } =
			new ParameterCategory(Discipline.LandSurfaceProducts, 2, "Transportation-related Products");

		///<summary>Soil Products</summary>
		public static ParameterCategory SoilProducts { get; } = new ParameterCategory(Discipline.LandSurfaceProducts, 3, "Soil Products");


		///<summary>Image format products</summary>
		public static ParameterCategory ImageFormatProducts { get; } =
			new ParameterCategory(Discipline.SpaceProducts, 0, "Image format products");

		///<summary>Quantitative products</summary>
		public static ParameterCategory QuantitativeProducts { get; } =
			new ParameterCategory(Discipline.SpaceProducts, 1, "Quantitative products");


		///<summary>Waves</summary>
		public static ParameterCategory Waves { get; } = new ParameterCategory(Discipline.OceanographicProducts, 0, "Waves");

		///<summary>Currents</summary>
		public static ParameterCategory Currents { get; } = new ParameterCategory(Discipline.OceanographicProducts, 1, "Currents");

		///<summary>Ice</summary>
		public static ParameterCategory Ice { get; } = new ParameterCategory(Discipline.OceanographicProducts, 2, "Ice");

		///<summary>Surface Properties</summary>
		public static ParameterCategory SurfaceProperties { get; } =
			new ParameterCategory(Discipline.OceanographicProducts, 3, "Surface Properties");

		///<summary>Sub-surface Properties</summary>
		public static ParameterCategory SubSurfaceProperties { get; } =
			new ParameterCategory(Discipline.OceanographicProducts, 4, "Sub-surface Properties");

		public static IReadOnlyDictionary<Discipline, IReadOnlyCollection<ParameterCategory>> CategoriesByDiscipline { get; } =
			ImmutableList<ParameterCategory>.Empty
				.Add(Temperature)
				.Add(Moisture)
				.Add(Momentum)
				.Add(Mass)
				.Add(ShortWaveRadiation)
				.Add(LongWaveRadiation)
				.Add(Cloud)
				.Add(ThermodynamicStabilityIndices)
				.Add(KinematicStabilityIndices)
				.Add(TemperatureProbabilities)
				.Add(MoistureProbabilities)
				.Add(MomentumProbabilities)
				.Add(MassProbabilities)
				.Add(Aerosols)
				.Add(TraceGases)
				.Add(Radar)
				.Add(ForecastRadarImagery)
				.Add(Electrodynamics)
				.Add(NuclearRadiology)
				.Add(PhysicalAtmosphericProperties)
				.Add(CcittIa5String)
				.Add(Miscellaneous)
				.Add(HydrologyBasicProducts)
				.Add(HydrologyProbabilities)
				.Add(VegetationBiomass)
				.Add(AgriAquaCulturalSpecialProducts)
				.Add(TransportationRelatedProducts)
				.Add(SoilProducts)
				.Add(ImageFormatProducts)
				.Add(QuantitativeProducts)
				.Add(Waves)
				.Add(Currents)
				.Add(Ice)
				.Add(SurfaceProperties)
				.Add(SubSurfaceProperties)
				.GroupBy(c => c.Discipline)
				.ToDictionary(g => g.Key, g => (IReadOnlyCollection<ParameterCategory>) g.ToImmutableList());
	}
}