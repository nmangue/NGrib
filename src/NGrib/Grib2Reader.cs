using System.IO;
using NGrib.Sections;

namespace NGrib
{
	public class Grib2Reader
	{
		private readonly Stream gribStream;
		private BufferedBinaryReader reader;

		public Grib2Reader(Stream gribStream)
		{
			this.gribStream = gribStream;
			reader = new BufferedBinaryReader(gribStream, 4096);
		}

		private void MapGrib()
		{
			var indicatorSection = Grib2IndicatorSection.BuildFrom(reader);
			var identificationSection = Grib2IdentificationSection.BuildFrom(reader);

			Grib2LocalUseSection localSection = null;
			do
			{
				if (reader.PeekSection().Is(SectionCode.LocalUseSection))
				{
					localSection = Grib2LocalUseSection.BuildFrom(reader);
				}

				while (reader.PeekSection().Is(SectionCode.GridDefinitionSection))
				{
					var gridDefinitionSection = Grib2GridDefinitionSection.BuildFrom(reader);

					while (reader.PeekSection().Is(SectionCode.ProductDefinitionSection))
					{
						var productDefinitionSection = Grib2ProductDefinitionSection.BuildFrom(reader);

						Expect(reader.PeekSection().Is(SectionCode.DataRepresentationSection));
						var dataRepresentationSection = Grib2DataRepresentationSection.BuildFrom(reader);

						Expect(reader.PeekSection().Is(SectionCode.BitmapSection));

						Expect(reader.PeekSection().Is(SectionCode.DataSection));
					}
				}
			} while (!reader.PeekSection().Is(SectionCode.EndSection));
		}

		private void Expect(bool isOk)
		{
			if (!isOk)
			{
				throw new NoValidGribException("Unexpected section");
			}
		}
	}
}
