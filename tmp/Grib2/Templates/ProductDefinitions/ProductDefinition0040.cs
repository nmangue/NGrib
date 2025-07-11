using NGrib.Grib2.CodeTables;

namespace NGrib.Grib2.Templates.ProductDefinitions;

public class ProductDefinition0040:ProductDefinition0000
{
    public ChemicalOrPhysicalConsistent ChemicalOrPhysicalConsistent { get; set; }

    protected override void InitGeneratingProcessType(BufferedBinaryReader reader)
    {
        ChemicalOrPhysicalConsistent = (ChemicalOrPhysicalConsistent)reader.ReadUInt16();
        RegisterContent(ProductDefinitionContent.ChemicalOrPhysicalConsistent, ()=>ChemicalOrPhysicalConsistent);
        
        base.InitGeneratingProcessType(reader);
    }

    internal ProductDefinition0040(BufferedBinaryReader reader, Discipline discipline) : base(reader, discipline)
    {
    }
}