using System.IO;
using System.Linq;
using NFluent;
using Xunit;

namespace NGrib.Tests;

public class Grib1Reader_Harmonie_Test
{
    [Fact]
    public void Test()
    {
        using var stream = File.OpenRead(GribFileSamples.HarmonieOneHourFile);
        var reader = new Grib1Reader(stream);

        var records = reader.ReadRecords().ToArray();

        var record = records.First();

        Check.That(record.GridDefinitionSection.GridType).Equals(10);
        Check.That(record.GridDefinitionSection.dx).Equals(0.05);
        Check.That(record.GridDefinitionSection.dy).Equals(0.05);
        Check.That(record.GridDefinitionSection.lat1).Equals(-8.5);
        Check.That(record.GridDefinitionSection.lat2).Equals(8.45);
        Check.That(record.GridDefinitionSection.lon1).Equals(-5.5);
        Check.That(record.GridDefinitionSection.lon2).Equals(11.45);
        Check.That(record.GridDefinitionSection.SpLon).Equals(0);
        Check.That(record.GridDefinitionSection.SpLat).Equals(-38);
        Check.That(record.GridDefinitionSection.SpLat).Equals(-38);
        Check.That(record.GridDefinitionSection.nx).Equals(340);
        Check.That(record.GridDefinitionSection.ny).Equals(340);
        Check.That(record.GridDefinitionSection.resolution).Equals(136);
        Check.That(record.GridDefinitionSection.ScanMode).Equals(64);
        Check.That(record.GridDefinitionSection.Lov).Equals(0);
    }
}