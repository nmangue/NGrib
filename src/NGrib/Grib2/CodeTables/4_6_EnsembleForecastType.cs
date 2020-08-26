namespace NGrib.Grib2.CodeTables
{
	/// <summary>
	/// Code table 4.6 - Type of ensemble forecast
	/// </summary>
	public enum EnsembleForecastType
	{
		/// <summary>
		/// Unperturbed high-resolution control forecast
		/// </summary>
		UnperturbedHighResolutionControlForecast = 0,

		/// <summary>
		/// Unperturbed low-resolution control forecast
		/// </summary>
		UnperturbedLowResolutionControlForecast = 1,

		/// <summary>
		/// Negatively perturbed forecast
		/// </summary>
		NegativelyPerturbedForecast = 2,

		/// <summary>
		/// Positively perturbed forecast
		/// </summary>
		PositivelyPerturbedForecast = 3,

		/// <summary>
		/// Multi-model forecast
		/// </summary>
		MultiModelForecast = 4,

		/// <summary>
		/// Missing
		/// </summary>
		Missing = 255,
	}
}
