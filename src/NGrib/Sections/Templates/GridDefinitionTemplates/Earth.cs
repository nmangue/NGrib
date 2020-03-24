namespace NGrib.Sections.Templates.GridDefinitionTemplates
{
	public abstract class Earth
	{
    }

	public class SphericalEarth : Earth
	{
		/// <summary> .</summary>
		/// <returns> EarthRadius as a float
		/// 
		/// </returns>
		public float Radius { get; }

		public SphericalEarth(float radius)
		{
			Radius = radius;
		}
	}

	public class OblateSpheroidEarth : Earth
	{
		/// <summary> .</summary>
		/// <returns> MajorAxis as a float
		/// 
		/// </returns>
		public float MajorAxis { get; }

		/// <summary> .</summary>
		/// <returns> MinorAxis as a float
		/// 
		/// </returns>
		public float MinorAxis { get; }

		public OblateSpheroidEarth(float majorAxis, float minorAxis)
		{
			MajorAxis = majorAxis;
			MinorAxis = minorAxis;
		}
	}
}