namespace NGrib.Sections.Templates.GridDefinitionTemplates
{
	public class MercatorGridDefinition : GridPointEarthGridDefinition
	{
		/// <summary> .</summary>
		/// <returns> Lad as a float
		/// 
		/// </returns>
		public float Lad { get; }

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
		
		/// <summary> Get scan mode.
		/// 
		/// </summary>
		/// <returns> scan mode
		/// </returns>
		public int ScanMode { get; }
		
		/// <summary> .</summary>
		/// <returns> Angle as a int
		/// 
		/// </returns>
		public long Angle { get; }

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

		internal MercatorGridDefinition(BufferedBinaryReader reader) : base(reader)
		{
			Lad = reader.ReadUInt32() * 1e-6f;
			La2 = reader.ReadUInt32() * 1e-6f;
			Lo2 = reader.ReadUInt32() * 1e-6f;
			ScanMode = reader.ReadUInt8();
			Angle = reader.ReadUInt32();
			Dx = reader.ReadUInt32() * 1e-3f;
			Dy = reader.ReadUInt32() * 1e-3f;
		}
	}
}