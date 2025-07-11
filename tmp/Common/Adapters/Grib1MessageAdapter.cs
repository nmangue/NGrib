using System.Data;
using System.Diagnostics;
using NGrib.Grib1;
using NGrib.Grib1.PdsParameterTables;

namespace NGrib.Common.Adapters;

public class Grib1MessageAdapter : IGribMessage
{
    private Grib1Record _record;
    private Grib1File _grib1File;
    private readonly Stream _stream;

    public Grib1MessageAdapter(Grib1Record @record, Grib1File grib1File, Stream stream)
    {
        _record = record;
        _grib1File = grib1File;
        _stream = stream;
    }

    public string Name => _record.ProductDefinitionSection.Parameter.Name;

    public DateTime Time => GetForecastTime();


    public IEnumerable<KeyValuePair<Coordinate, double?>> GetData()
    {
        var rawData =
            _grib1File.getData(_stream, _record.DataOffset,
                _record.ProductDefinitionSection.DecimalScale, false);
        return _record.GridDefinitionSection.EnumerateGridPoints()
            .Zip(rawData, (c, v) => new KeyValuePair<Coordinate, double?>(c, v));
    }

    public int Version => 1;

    public int ParameterHash
    {
        get
        {
            var parametr = _record.ProductDefinitionSection;
            if (parametr.WaveSpectra2DDirFreq != null)
                throw new DataException("Нестандартная секция");
            return (parametr.Center, parametr.Description, parametr.P1, parametr.P2, parametr.Parameter.Description,
                    parametr.Parameter.Name, parametr.Parameter.Number, parametr.Parameter.Unit,
                    parametr.Type, parametr.Unit, parametr.CustomData, parametr.DecimalScale, parametr.Grid_Id,
                    parametr.LengthErr, parametr.LevelName, parametr.LevelValue1, parametr.LevelValue2,
                    parametr.ParameterNumber, parametr.Process_Id, parametr.ProductDefinition,
                    parametr.SubCenter, parametr.TableVersion, parametr.TimeUnit, parametr.TimeRangeUnit)
                .GetHashCode();
        }
    } 

    private DateTime GetForecastTime()
    {
        var productSection = _record.ProductDefinitionSection;
        var baseTime = productSection.BaseTime;
        var unit = productSection.TimeRangeUnit;
        var unitNumber = productSection.ForecastTime;

        return unit switch
        {
            TimeRangeUnitGrib1.Day => baseTime.AddDays(unitNumber),
            TimeRangeUnitGrib1.Minute => baseTime.AddMinutes(unitNumber),
            TimeRangeUnitGrib1.Hour => baseTime.AddHours(unitNumber),
            TimeRangeUnitGrib1.Month => baseTime.AddMonths(unitNumber),
            TimeRangeUnitGrib1.Year => baseTime.AddYears(unitNumber),
            TimeRangeUnitGrib1.Decade => baseTime.AddYears(10 * unitNumber),
            TimeRangeUnitGrib1.Normal => baseTime.AddYears(30 * unitNumber),
            TimeRangeUnitGrib1.Century => baseTime.AddYears(100 * unitNumber),
            TimeRangeUnitGrib1.Hours3 => baseTime.AddHours(3 * unitNumber),
            TimeRangeUnitGrib1.Hours6 => baseTime.AddHours(6 * unitNumber),
            TimeRangeUnitGrib1.Hours12 => baseTime.AddHours(12 * unitNumber),
            TimeRangeUnitGrib1.Minutes15 => baseTime.AddMinutes(15 * unitNumber),
            TimeRangeUnitGrib1.Minutes30 => baseTime.AddMinutes(30 * unitNumber),
            TimeRangeUnitGrib1.Second => baseTime.AddSeconds(unitNumber),
            TimeRangeUnitGrib1.Reserved =>
                throw new NotSupportedException("Ключ формата был зарезервирован в стандарте и не реализован"),
            TimeRangeUnitGrib1.Missing =>
                throw new NotSupportedException("Ключ формата отсутствовал в стандарте и не реализован"),
            _ => throw new NotSupportedException("Поведение для этого заначения ключа не было реализовано")
        };
    }
}