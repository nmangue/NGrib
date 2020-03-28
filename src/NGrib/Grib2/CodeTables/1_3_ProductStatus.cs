namespace NGrib.Grib2.CodeTables
{
	/// <summary>
	/// Code Table 1.3: Production status of data
	/// </summary>
	public enum ProductStatus
	{
		/// <summary>
		/// Operational products
		/// </summary>
		OperationalProducts = 0,

		/// <summary>
		/// Operational test products
		/// </summary>
		OperationalTestProducts = 1,

		/// <summary>
		/// Research products
		/// </summary>
		ResearchProducts = 2,

		/// <summary>
		/// Re-analysis products
		/// </summary>
		ReanalysisProducts = 3,

		/// <summary>
		/// Missing
		/// </summary>
		Missing = 255
	}
}