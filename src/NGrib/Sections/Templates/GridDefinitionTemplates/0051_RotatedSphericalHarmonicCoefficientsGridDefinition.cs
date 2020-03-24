namespace NGrib.Sections.Templates.GridDefinitionTemplates
{
	public class RotatedSphericalHarmonicCoefficientsGridDefinition : SphericalHarmonicCoefficientsGridDefinition
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

		internal RotatedSphericalHarmonicCoefficientsGridDefinition(BufferedBinaryReader reader) : base(reader)
		{
			SpLat = reader.ReadUInt32() * 1e-6f;
			SpLon = reader.ReadUInt32() * 1e-6f;
			Rotationangle = reader.ReadUInt32();
		}
	}
}