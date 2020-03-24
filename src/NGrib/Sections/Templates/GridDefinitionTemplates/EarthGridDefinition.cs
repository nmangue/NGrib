using System;

namespace NGrib.Sections.Templates.GridDefinitionTemplates
{
	public abstract class EarthGridDefinition : GridDefinition
	{
		/// <summary> .</summary>
		/// <returns> shape as a int
		/// 
		/// </returns>
		public int Shape { get; }

		public int Scalefactorradius { get; }
		public long Scaledvalueradius { get; }
		public long Scalefactormajor { get; }
		public long Scaledvaluemajor { get; }
		public int Scalefactorminor { get; }
		public long Scaledvalueminor { get; }
		
		public Earth EarthShape { get; set; }

		private protected EarthGridDefinition(BufferedBinaryReader reader)
		{
			Shape = reader.ReadUInt8();

			Scalefactorradius = reader.ReadUInt8();
			Scaledvalueradius = reader.ReadUInt32();
			Scalefactormajor = reader.ReadUInt8();
			Scaledvaluemajor = reader.ReadUInt32();
			Scalefactorminor = reader.ReadUInt8();
			Scaledvalueminor = reader.ReadUInt32();

			EarthShape = ComputeEarthShape();
		}

		private Earth ComputeEarthShape()
		{
			Earth earthShape;
			if (Shape == 0)
			{
				earthShape = new SphericalEarth(6367470);
			}
			else if (Shape == 1)
			{
				earthShape = new SphericalEarth((float) (Scalefactorradius != 0
					? Scaledvalueradius / Math.Pow(10, Scalefactorradius)
					: Scaledvalueradius));
			}
			else if (Shape == 2)
			{
				earthShape = new OblateSpheroidEarth(6378160.0f, 6356775.0f);
			}
			else if (Shape == 3)
			{
				earthShape = new OblateSpheroidEarth(
					(float) (Scaledvaluemajor / Math.Pow(10, Scalefactormajor)),
					(float) (Scaledvalueminor / Math.Pow(10, Scalefactorminor))
				);
			}
			else if (Shape == 4)
			{
				earthShape = new OblateSpheroidEarth(
					6378137.0f,
					6356752.314f);
			}
			else if (Shape == 6)
			{
				earthShape = new SphericalEarth(6371229);
			}
			else
			{
				throw new NotImplementedException();
			}

			return earthShape;
		}
	}
}