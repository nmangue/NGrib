using System.Collections.Generic;
using System.Linq;
using NFluent;
using NGrib.Grib2.Templates.ProductDefinitions;
using Xunit;

namespace NGrib.Tests;

public class Grib2Reader_IconD2_SatelliteParameter_Test
{
    [Fact]
    public void Test()
    {
        var reader = new Grib2Reader(GribFileSamples.IconD2SatelliteFile);

        var synMsg = reader.ReadAllDataSets().First();

        Check.That(synMsg.ProductDefinitionSection.ProductDefinitionTemplateNumber).IsEqualTo(32);
        Check.That(synMsg.ProductDefinitionSection.ProductDefinition).IsInstanceOfType(typeof(ProductDefinition0032));
        
        var pd = (ProductDefinition0032) synMsg.ProductDefinitionSection.ProductDefinition;
        
        Check.That(pd.SpectralBands.Count).IsEqualTo(1);
        
        var data = reader.ReadDataSetRawData(synMsg).ToArray();
        
        Check.That(data.Length).IsEqualTo(906392);
        Check.That(data.Max()).IsEqualTo(234.78539f);
    }
}