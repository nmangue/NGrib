namespace NGrib.Sections.Templates.GridDefinitionTemplates
{
	public class EquatorialAzimuthalEquidistantProjectionGridDefinition : GridPointEarthGridDefinition
	{
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

		/// <summary> .</summary>
		/// <returns> ProjectionCenter as a int
		/// 
		/// </returns>
		public int ProjectionCenter { get; }

		internal EquatorialAzimuthalEquidistantProjectionGridDefinition(BufferedBinaryReader reader) : base(reader)
		{
			Dx = reader.ReadUInt32() * 1e-3f;
			Dy = reader.ReadUInt32() * 1e-3f;
			ProjectionCenter = reader.ReadUInt8();
			ScanMode = reader.ReadUInt8();
		}
	}
}