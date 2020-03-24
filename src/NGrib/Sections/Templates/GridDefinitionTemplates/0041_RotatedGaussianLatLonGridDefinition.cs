namespace NGrib.Sections.Templates.GridDefinitionTemplates
{
	public class RotatedGaussianLatLonGridDefinition : GaussianLatLonGridDefinition
	{
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

		/// <summary> .</summary>
		/// <returns> Rotationangle as a float
		/// 
		/// </returns>
		public long Rotationangle { get; }

		internal RotatedGaussianLatLonGridDefinition(BufferedBinaryReader reader) : base(reader)
		{
			SpLat = reader.ReadUInt32() * Ratio;
			SpLon = reader.ReadUInt32() * Ratio;
			Rotationangle = reader.ReadUInt32();
		}
	}
}