namespace NGrib.Sections.Templates.GridDefinitionTemplates
{
	public class TriangularGridBasedOnAnIcosahedronGridDefinition : GridDefinition
	{
		/// <summary> .</summary>
		/// <returns> N2 as a int
		/// 
		/// </returns>
		public int N2 { get; }

		/// <summary> .</summary>
		/// <returns> N3 as a int
		/// 
		/// </returns>
		public int N3 { get; }

		/// <summary> .</summary>
		/// <returns> Ni as a int
		/// 
		/// </returns>
		public int Ni { get; }

		/// <summary> .</summary>
		/// <returns> Nd as a int
		/// 
		/// </returns>
		public int Nd { get; }

		/// <summary> .</summary>
		/// <returns> PoleLat as a float
		/// 
		/// </returns>
		public float PoleLat { get; }

		/// <summary> .</summary>
		/// <returns> PoleLon as a float
		/// 
		/// </returns>
		public float PoleLon { get; }

		public long Lonofcenter { get; }

		/// <summary> .</summary>
		/// <returns> Position as a int
		/// 
		/// </returns>
		public int Position { get; }

		/// <summary> .</summary>
		/// <returns> Order as a int
		/// 
		/// </returns>
		public int Order { get; }

		/// <summary> Get scan mode.
		/// 
		/// </summary>
		/// <returns> scan mode
		/// </returns>
		public int ScanMode { get; }

		/// <summary> .</summary>
		/// <returns> N as a int
		/// 
		/// </returns>
		public long N { get; }

		internal TriangularGridBasedOnAnIcosahedronGridDefinition(BufferedBinaryReader reader)
		{
			N2 = reader.ReadUInt8();
			N3 = reader.ReadUInt8();
			Ni = reader.ReadUInt16();
			Nd = reader.ReadUInt8();
			PoleLat = reader.ReadUInt32() * 1e-6f;
			PoleLon = reader.ReadUInt32() * 1e-6f;
			Lonofcenter = reader.ReadUInt32();
			Position = reader.ReadUInt8();
			Order = reader.ReadUInt8();
			ScanMode = reader.ReadUInt8();
			N = reader.ReadUInt32();
		}
	}
}