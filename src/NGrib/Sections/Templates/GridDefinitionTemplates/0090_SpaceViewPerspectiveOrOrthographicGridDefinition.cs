namespace NGrib.Sections.Templates.GridDefinitionTemplates
{
	public class SpaceViewPerspectiveOrOrthographicGridDefinition : XyEarthGridDefinition
	{
		public long Lap { get; }
		public long Lop { get; }
		public long Xo { get; }
		public long Yo { get; }
		public long Altitude { get; }

		/// <summary> .</summary>
		/// <returns> Resolution as a int
		/// 
		/// </returns>
		public int Resolution { get; }

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
		/// <returns> Xp as a float
		/// 
		/// </returns>
		public float Xp { get; }

		/// <summary> .</summary>
		/// <returns> Yp as a float
		/// 
		/// </returns>
		public float Yp { get; }

		/// <summary> .</summary>
		/// <returns> Angle as a int
		/// 
		/// </returns>
		public long Angle { get; }

		internal SpaceViewPerspectiveOrOrthographicGridDefinition(BufferedBinaryReader reader) : base(reader)
		{
			Lap = reader.ReadUInt32();
			Lop = reader.ReadUInt32();
			Resolution = reader.ReadUInt8();
			Dx = reader.ReadUInt32();
			Dy = reader.ReadUInt32();
			Xp = (float)(reader.ReadUInt32() * 1e-3f);
			Yp = (float)(reader.ReadUInt32() * 1e-3f);
			ScanMode = reader.ReadUInt8();
			Angle = reader.ReadUInt32();
			Altitude = reader.ReadUInt32() * 1000000;
			Xo = reader.ReadUInt32();
			Yo = reader.ReadUInt32();
		}
	}
}