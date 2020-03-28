namespace NGrib.Grib2.CodeTables
{
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
}