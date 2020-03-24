namespace NGrib.Sections.Templates.GridDefinitionTemplates
{
	public abstract class GridPointEarthGridDefinition : EarthGridDefinition
	{
		/// <summary> .</summary>
		/// <returns> La1 as a float
		/// 
		/// </returns>
		public float La1 { get; }

		/// <summary> .</summary>
		/// <returns> Lo1 as a float
		/// 
		/// </returns>
		public float Lo1 { get; }

		/// <summary> .</summary>
		/// <returns> Resolution as a int
		/// 
		/// </returns>
		public int Resolution { get; }


		private protected GridPointEarthGridDefinition(BufferedBinaryReader reader) : base(reader)
		{
			La1 = reader.ReadUInt32() * 1e-6f;
			Lo1 = reader.ReadUInt32() * 1e-6f;
			Resolution = reader.ReadUInt8();
		}
	}
}