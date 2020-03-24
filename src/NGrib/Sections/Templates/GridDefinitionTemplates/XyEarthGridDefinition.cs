namespace NGrib.Sections.Templates.GridDefinitionTemplates
{
	public abstract class XyEarthGridDefinition : EarthGridDefinition
	{

		/// <summary> Get number of grid columns.
		/// 
		/// </summary>
		/// <returns> number of grid columns
		/// </returns>
		public long Nx { get; }

		/// <summary> Get number of grid rows.
		/// 
		/// </summary>
		/// <returns> number of grid rows.
		/// </returns>
		public long Ny { get; }


		private protected XyEarthGridDefinition(BufferedBinaryReader reader) : base(reader)
		{
			Nx = reader.ReadUInt32();
			Ny = reader.ReadUInt32();
		}
	}
}