namespace NGrib.Sections.Templates.GridDefinitionTemplates
{
	public class StretchedRotatedLatLonGridDefinition : LatLonGridDefinition
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
		public float Rotationangle { get; }

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

		/// <summary> .</summary>
		/// <returns> Factor as a float
		/// 
		/// </returns>
		public float Factor { get; }

		internal StretchedRotatedLatLonGridDefinition(BufferedBinaryReader reader) : base(reader)
		{
			//Stretched and Rotated 
			// Latitude/longitude
			SpLat = reader.ReadUInt32() * 1e-6f;
			SpLon = reader.ReadUInt32() * 1e-6f;
			Rotationangle = reader.ReadSingle();
			PoleLat = reader.ReadUInt32() * 1e-6f;
			PoleLon = reader.ReadUInt32() * 1e-6f;
			Factor = reader.ReadUInt32();
		}
	}
}