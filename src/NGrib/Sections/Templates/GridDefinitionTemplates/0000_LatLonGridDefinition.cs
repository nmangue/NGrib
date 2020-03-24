namespace NGrib.Sections.Templates.GridDefinitionTemplates
{
	public class LatLonGridDefinition : XyEarthGridDefinition
	{
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
		public float Dy { get; }

		/// <summary> Get scan mode.
		/// 
		/// </summary>
		/// <returns> scan mode
		/// </returns>
		public int ScanMode { get; }
		
		internal LatLonGridDefinition(BufferedBinaryReader reader) : base(reader)
		{
			Angle = reader.ReadUInt32();
			Subdivisionsangle = reader.ReadUInt32();
			float ratio;
			if (Angle == 0)
			{
				ratio = 1e-6f;
			}
			else
			{
				ratio = Angle / (float)Subdivisionsangle;
			}

			La1 = reader.ReadUInt32() * ratio;
			Lo1 = reader.ReadUInt32() * ratio;
			Resolution = reader.ReadUInt8();
			La2 = reader.ReadUInt32() * ratio;
			Lo2 = reader.ReadUInt32() * ratio;
			Dx = reader.ReadUInt32() * ratio;
			Dy = reader.ReadUInt32() * ratio;
			ScanMode = reader.ReadUInt8();
		}
	}
}