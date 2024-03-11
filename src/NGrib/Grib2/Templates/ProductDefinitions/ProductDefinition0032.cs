using System;
using System.Collections.Generic;
using NGrib.Grib2.CodeTables;

namespace NGrib.Grib2.Templates.ProductDefinitions;

/// <summary>
/// Product Definition Template 4.32: Analysis or Forecast at a horizontal level or in a horizontal layer at a point in time for simulated (synthetic) satellite data
/// </summary>
public class ProductDefinition0032 : WithBackgroundProductDefinition
{
    
    /// <summary>
    /// Analysis or forecast generating processes identifier.
    /// </summary>
    public int GeneratingProcessIdentifier { get; }

    /// <summary>
    /// Hours of observational data cutoff after reference time.
    /// </summary>
    public int HoursAfter { get; }

    /// <summary>
    /// Minutes of observational data cutoff after reference time.
    /// </summary>
    public int MinutesAfter { get; }

    /// <summary>
    /// Timespan of observational data cutoff after reference time.
    /// </summary>
    public TimeSpan ObservationalDataCutoff { get; }

    /// <summary>
    /// Indicator of unit of time range.
    /// </summary>
    public TimeRangeUnit TimeRangeUnit { get; }

    /// <summary>
    /// Forecast time in units defined by indicator of unit of time range.
    /// </summary>
    public int ForecastTime { get; }
    
    /// <summary>
    /// Number of spectral bands
    /// </summary>
    public int NumberOfSpectralBands { get; }

    /// <summary>
    /// Information about spectral bands
    /// </summary>
    public List<SatelliteSpectralBand> SpectralBands { get; } = new();
    
    internal ProductDefinition0032(BufferedBinaryReader reader, Discipline discipline, int centerCode) : base(reader, discipline, centerCode)
    {
        GeneratingProcessIdentifier = reader.ReadUInt8();
        HoursAfter = reader.ReadUInt16();
        MinutesAfter = reader.ReadUInt8();
        ObservationalDataCutoff = TimeSpan.FromHours(HoursAfter) + TimeSpan.FromMinutes(MinutesAfter);
        TimeRangeUnit = (TimeRangeUnit) reader.ReadUInt8();
        ForecastTime = reader.ReadInt32();
        
        NumberOfSpectralBands = reader.ReadUInt8();

        for (int j = 0; j < NumberOfSpectralBands; j++)
        {
            SpectralBands.Add(new SatelliteSpectralBand(reader));
        }
    }
}

/// <summary>
/// Holds information about a spectral band
/// </summary>
public class SatelliteSpectralBand
{
    /// <summary>
    /// Satellite series of band nb (BUFR Code Table 0 02 020)
    /// </summary>
    public int SeriesOfBandNumber { get; }
    /// <summary>
    /// Satellite number of band nb (BUFR Code Table 0 01 007)
    /// </summary>
    public int NumberOfBand { get; }
    
    /// <summary>
    /// Instrument types of band (BUFR Code Table 0 02 019)
    ///
    /// Instrument types code, a 16-bit value, stores the BUFR table 0 02 019 value,
    /// a 10-bit value, in the lowest ten bits. The upper three bits (bits 1-3) contain the
    /// polarization information, if known. The intervening three bits (4-6) are unused and
    ///    set to 0. Bits 1-3 will have one of the following values:
    /// 8192*0 = 000 = unknown or missing
    /// 8192*1 = 001 = unpolarized
    /// 8192*2 = 010 = horizontal linear polarization
    /// 8192*3 = 011 = vertical linear polarization
    /// 8192*4 = 100 = right circular polarization
    /// 8192*5 = 101 = left circular polarization
    /// </summary>
    public int InstrumentTypesOfBand { get; }
    /// <summary>
    /// Scale factor of central wave number of band nb
    /// </summary>
    public int ScaleFactorOfCentralWaveNumber { get; }
    /// <summary>
    /// Scaled value of central wave number of band nb (units: m-1)
    /// </summary>
    public long ScaledValueOfCentralWaveNumber { get; }

    internal SatelliteSpectralBand(BufferedBinaryReader reader)
    {
        SeriesOfBandNumber = reader.ReadUInt16();
        NumberOfBand = reader.ReadUInt16();
        InstrumentTypesOfBand = reader.ReadUInt16();
        ScaleFactorOfCentralWaveNumber = reader.ReadUInt8();
        ScaledValueOfCentralWaveNumber = reader.ReadUInt32();
    }
    
}