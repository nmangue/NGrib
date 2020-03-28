namespace NGrib.Grib2.CodeTables
{
	/// <summary>
	/// Code Table 1.2: Significance of Reference Time
	/// </summary>
	public enum ReferenceTimeSignificance
	{
		/// <summary>
		/// Analysis.
		/// </summary>
		Analysis = 0,

		/// <summary>
		/// Start of forecast.
		/// </summary>
		ForecastStart = 1,

		/// <summary>
		/// Verifying time of forecast.
		/// </summary>
		ForecastVerifyingTime = 2,

		/// <summary>
		/// Observation time.
		/// </summary>
		ObservationTime = 3,

		/// <summary>
		/// Missing.
		/// </summary>
		Missing = 255
	}
}
