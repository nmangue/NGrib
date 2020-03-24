namespace NGrib.Sections.Templates.GridDefinitionTemplates
{
	public class PolarStereographicProjectionGridDefinition : GridPointEarthGridDefinition
	{
		/// <summary> .</summary>
		/// <returns> Lad as a float
		/// 
		/// </returns>
		public float Lad { get; }

		/// <summary> .</summary>
		/// <returns> Lov as a float
		/// 
		/// </returns>
		public float Lov { get; }

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

		/// <summary> .</summary>
		/// <returns> ProjectionCenter as a int
		/// 
		/// </returns>
		public int ProjectionCenter { get; }

		/// <summary> Get scan mode.
		/// 
		/// </summary>
		/// <returns> scan mode
		/// </returns>
		public int ScanMode { get; }

		internal PolarStereographicProjectionGridDefinition(BufferedBinaryReader reader) : base(reader)
		{
			Lad = reader.ReadUInt32() * 1e-6f;
			Lov = reader.ReadUInt32() * 1e-6f;
			Dx = reader.ReadUInt32() * 1e-3f;
			Dy = reader.ReadUInt32() * 1e-3f;
			ProjectionCenter = reader.ReadUInt8();
			ScanMode = reader.ReadUInt8();
		}
	}
}