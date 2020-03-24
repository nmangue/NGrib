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

			reader.SaveCurrentPosition();
			var localUseSection = Grib2LocalUseSection.BuildFrom(reader);
			if (localUseSection == null)
			{
				reader.SeekToSavedPosition();
			}

            var gridDefinitionSection = Grib2GridDefinitionSection.BuildFrom(reader);

            var productDefinitionSection = Grib2ProductDefinitionSection.BuildFrom(reader);

            var dataRepresentationSection = Grib2DataRepresentationSection.BuildFrom(reader);
        }
	}
}
