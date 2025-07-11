using NGrib.Grib2;
using NGrib.Grib2.CodeTables;
using NGrib.Grib2.Templates.ProductDefinitions;

namespace NGrib.Common.Adapters;

public class Grib2MessageAdapter : IGribMessage
{
    private readonly Message _message;
    private readonly Stream _stream;

    public Grib2MessageAdapter(Message message, Stream stream)
    {
        _message = message;
        _stream = stream;
    }

    public int GribVersion => 2;

    public string Name => _message.DataSets.Single()
                              .ProductDefinitionSection.ProductDefinition?.Parameter?.Name ??
                          (ChemicalOrPhysicalConsistent.HasValue
                              ? Enum.GetName(typeof(ChemicalOrPhysicalConsistent), ChemicalOrPhysicalConsistent.Value)
                              : (string) null);

    public DateTime Time
    {
        get
        {
            var reference = _message.IdentificationSection.ReferenceTime;
            var productDefinition =
                (ProductDefinition0000) _message.DataSets.Single().ProductDefinitionSection.ProductDefinition;
            var time = productDefinition
                .ForecastTime;
            var unit = productDefinition.TimeRangeUnitGrib2;
            var result = unit switch
            {
                TimeRangeUnitGrib2.Minute => reference.AddMinutes(time),
                TimeRangeUnitGrib2.Hour => reference.AddHours(time),
                TimeRangeUnitGrib2.Day => reference.AddDays(time),
                TimeRangeUnitGrib2.Month => reference.AddMonths(time),
                TimeRangeUnitGrib2.Year => reference.AddYears(time),
                TimeRangeUnitGrib2.Decade => reference.AddYears(10 * time),
                TimeRangeUnitGrib2.Normal => reference.AddYears(30 * time),
                TimeRangeUnitGrib2.Century => reference.AddYears(100 * time),
                TimeRangeUnitGrib2.Hours3 => reference.AddHours(3 * time),
                TimeRangeUnitGrib2.Hours6 => reference.AddHours(6 * time),
                TimeRangeUnitGrib2.Hours12 => reference.AddHours(12 * time),
                TimeRangeUnitGrib2.Second => reference.AddSeconds(time),
                TimeRangeUnitGrib2.Missing => 
                    throw new NotSupportedException("Код единицы измерения на момент реализации отсустствовал"),
                _ => throw new NotSupportedException("Логика для этого кода единицы измерения не была примененена в этой функции")
            };
            return result;
        }
    }

    public ChemicalOrPhysicalConsistent? ChemicalOrPhysicalConsistent =>
        (_message.DataSets.Single().ProductDefinitionSection.ProductDefinition as ProductDefinition0040)
        ?.ChemicalOrPhysicalConsistent;

    public int? StartStep =>
        (_message.DataSets.Single().ProductDefinitionSection.ProductDefinition as ProductDefinition0000)
        ?.HoursAfter;


    public IEnumerable<KeyValuePair<Coordinate, double?>> GetData()
    {
        using var reader = new BufferedBinaryReader(_stream, true);
        return _message.DataSets.Single().GetData(reader);
    }

    public int Version => 2;

    public int ParameterHash
    {
        get
        {
            var param = _message.IdentificationSection;
            return (param.Section,param.Length,param.Center,param.CenterCode,param.ProductStatus,
                    param.ProductType,param.LocalTableVersion,param.MasterTableVersion,
                    param.ReferenceTimeSignificance,param.SubCenterCode,param).GetHashCode();
        }
    }
}