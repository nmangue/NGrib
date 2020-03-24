namespace NGrib.Sections.Templates.GridDefinitionTemplates
{
	public class GaussianLatLonGridDefinition : XyEarthGridDefinition
	{
		protected float Ratio;

		/// <summary> .</summary>
		/// <returns> Angle as a int
		/// 
		/// </returns>
		public long Angle { get; }

		/// <summary> .</summary>
		/// <returns> Subdivisionsangle as a int
		/// 
		/// </returns>
		public long Subdivisionsangle { get; }

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

		/// <summary> .</summary>
		/// <returns> La2 as a float
		/// 
		/// </returns>
		public float La2 { get; }

		/// <summary> .</summary>
		/// <returns> Lo2 as a float
		/// 
		/// </returns>
		public float Lo2 { get; }

		/// <summary> Get x-increment/distance between two grid points.
		/// 
		/// </summary>
		/// <returns> x-increment
		/// </returns>
		public float Dx { get; }

		/// <summary> Get y-increment/distance between two grid points.
		/// 
		/// </summary>
		/// <returns> y-increment
		/// </returns>
		public long N { get; }

		/// <summary> Get scan mode.
		/// 
		/// </summary>
		/// <returns> scan mode
		/// </returns>
		public int ScanMode { get; }

		internal GaussianLatLonGridDefinition(BufferedBinaryReader reader) : base(reader)
		{
			Angle = reader.ReadUInt32();
			Subdivisionsangle = reader.ReadUInt32();
			if (Angle == 0)
			{
				Ratio = 1e-6f;
			}
			else
			{
				Ratio = Angle / (float)Subdivisionsangle;
			}

			La1 = reader.ReadUInt32() * Ratio;
			Lo1 = reader.ReadUInt32() * Ratio;
			Resolution = reader.ReadUInt8();
			La2 = reader.ReadUInt32() * Ratio;
			Lo2 = reader.ReadUInt32() * Ratio;
			Dx = reader.ReadUInt32() * Ratio;
			N = reader.ReadUInt32();
			ScanMode = reader.ReadUInt8();
		}
	}
}