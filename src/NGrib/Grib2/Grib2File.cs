using NGrib.Grib2.Sections;

namespace NGrib.Grib2;

public class Grib2File
{
    public Message ReadGrib2Message(BufferedBinaryReader reader, out long currentPosition)
    {
        var indicatorSection = IndicatorSection.BuildFrom(reader);
        var identificationSection = IdentificationSection.BuildFrom(reader);

        var message = new Message(indicatorSection, identificationSection);

        LocalUseSection localUseSection = null;
        do
        {
            if (reader.PeekSection().Is(SectionCode.LocalUseSection))
            {
                localUseSection = LocalUseSection.BuildFrom(reader);
            }

            while (reader.PeekSection().Is(SectionCode.GridDefinitionSection))
            {
                var gridDefinitionSection = GridDefinitionSection.BuildFrom(reader);

                while (reader.PeekSection().Is(SectionCode.ProductDefinitionSection))
                {
                    var productDefinitionSection = ProductDefinitionSection.BuildFrom(reader, indicatorSection.Discipline);
                    var dataRepresentationSection = DataRepresentationSection.BuildFrom(reader);

                    var bitmapSection = BitmapSection.BuildFrom(reader, dataRepresentationSection.DataPointsNumber);

                    var dataSection = DataSection.BuildFrom(reader);

                    message.AddDataset(
                        localUseSection,
                        gridDefinitionSection,
                        productDefinitionSection,
                        dataRepresentationSection,
                        bitmapSection,
                        dataSection);
                }
            }
        } while (!reader.PeekSection().Is(SectionCode.EndSection));

        EndSection.BuildFrom(reader);

        // Saves and restore the current position
        // to avoid losing track of the current message
        // if a data set read happens during the enumeration
        currentPosition = reader.Position;
        return message;
    }

    public IEnumerable<IEnumerable<KeyValuePair<Coordinate,double?>>> GetData(BufferedBinaryReader reader, Message message)
    {
        return message.DataSets.Select(x => x.GetData(reader));
    }
}