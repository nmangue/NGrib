namespace NGrib.Sections.Templates.GridDefinitionTemplates
{
	public class SphericalHarmonicCoefficientsGridDefinition : GridDefinition
	{
		/// <summary> .</summary>
		/// <returns> J as a float
		/// 
		/// </returns>
		public float J { get; }

		/// <summary> .</summary>
		/// <returns> K as a float
		/// 
		/// </returns>
		public float K { get; }

		/// <summary> .</summary>
		/// <returns> M as a float
		/// 
		/// </returns>
		public float M { get; }

		/// <summary> .</summary>
		/// <returns> Method as a int
		/// 
		/// </returns>
		public int Method { get; }

		/// <summary> .</summary>
		/// <returns> Mode as a int
		/// 
		/// </returns>
		public int Mode { get; }

		internal SphericalHarmonicCoefficientsGridDefinition(BufferedBinaryReader reader)
		{
			J = reader.ReadSingle();
			K = reader.ReadSingle();
			M = reader.ReadSingle();
			Method = reader.ReadUInt8();
			Mode = reader.ReadUInt8();
		}
	}
}