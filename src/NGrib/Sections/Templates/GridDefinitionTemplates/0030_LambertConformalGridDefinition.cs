namespace NGrib.Sections.Templates.GridDefinitionTemplates
{
	public class LambertConformalGridDefinition : PolarStereographicProjectionGridDefinition
	{
		/// <summary> .</summary>
		/// <returns> Latin1 as a float
		/// 
		/// </returns>
		public float Latin1 { get; }

		/// <summary> .</summary>
		/// <returns> Latin2 as a float
		/// 
		/// </returns>
		public float Latin2 { get; }

		/// <summary> .</summary>
		/// <returns> SpLat as a float
		/// 
		/// </returns>
		public float SpLat { get; }

		/// <summary> .</summary>
		/// <returns> SpLon as a float
		/// 
		/// </returns>
		public float SpLon { get; }

		internal LambertConformalGridDefinition(BufferedBinaryReader reader) : base(reader)
		{
			Latin1 = reader.ReadUInt32() * 1e-6f;
			Latin2 = reader.ReadUInt32() * 1e-6f;

			SpLat = reader.ReadUInt32() * 1e-6f;
			SpLon = reader.ReadUInt32() * 1e-6f;
		}
	}
}