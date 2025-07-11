namespace NGrib.Grib2.Templates.ProductDefinitions;

public enum ChemicalOrPhysicalConsistent : ushort
{
    Ozone = 0,
    
    WaterVapour,
    
    Methane,
    
    CarbonDioxide,
    
    CarbonMonoxide,
    
    NitrogenDioxide,
    
    NitrousOxide,
    
    Formaldehyde,
    
    SulphurDioxide,
    
    Ammonia,
    
    Ammonium,
    
    NitrogenMonoxide,
    
    AtomicOxygen,
    
    NitrateRadical,
    
    HydroperoxylRadical,
    
    DinitrogenPentoxide,
    
    NitrousAcid,
    
    NitricAcid,
    
    PeroxynitricAcid,
    
    HydrogenPeroxide,
    
    MolecularHydrogen,
    
    AtomicNitrogen,
    
    Sulphate,
    
    Radon,
    
    ElementalMercury,
    
    DivalentMercury,
    
    AtomicChlorine,
    
    ChlorineMonoxide,
    
    DichlorinePeroxide,
    
    HypochlorousAcid,
    
    ChlorineNitrate,
    
    ChlorineDioxide,
    
    AtomicBromide,
    
    BromineMonoxide,
    
    BromineChloride,
    
    HydrogenBromide,
    
    HypobromousAcid,
    
    BromineNitrate,
    
    Oxygen,
    
    HydroxylRadical = 10000,
    
    MethylPeroxyRadical,
    
    MethylHydroperoxide,
    
    Methanol = 10004,
    
    FormicAcid,
    
    HydrogenCyanide,
    
    AcetoNitrile,
    
    Ethane,
    
    EtheneEthylene,
    
    EthyneAcetylene,
    
    Ethanol,
    
    AceticAcid,
    
    PeroxyacetylNitrate,
    
    Propane,
    
    Propene,
    
    Butanes,
    
    Isoprene,
    
    AlphaPinene,
    
    BetaPinene,
    
    Limonene,
    
    Benzene,
    
    Toluene,
    
    Xylene,
    
    DimethylSulphide = 10500,
    
    HydrogenChloride = 20000,
    
    Cfc11,
    
    Cfc12,
    
    Cfc113,
    
    Cfc113A,
    
    Cfc114,
    
    Cfc115,
    
    Hcfc22,
    
    Hcfc141B,
    
    Hcfc142B,
    
    Halon1202,
    
    Halon1211,
    
    Halon1301,
    
    Halon2402,
    
    MethylChlorideHcc40,
    
    CarbonTetrachlorideHcc10,
    
    Hcc140A,
    
    MethylBromideHbc40B1,
    
    HexachlorocyclohexaneHch,
    
    AlphaHexachlorocyclohexane,
    
    HexachlorobiphenylPcb153,
    
    /// <summary>
    /// Tracer, defined by originating centre
    /// </summary>
    RadioactivePollutant = 30000,

    /// <summary>
    /// OH+HO2
    /// </summary>
    HOxRadical,
    
    /// <summary>
    /// HO2+RO2
    /// </summary>
    TotalInorganicAndOrganicPeroxyRadicals,
    
    PassiveOzone,
    
    NOxExpressedAsNitrogen,
    
    AllNitrogenOxidesNOyExpressedAsNitrogen,
    
    TotalInorganicChlorine,
    
    TotalInorganicBromine,

    /// <summary>
    ///Total Inorganic Chlorine Except HCl, ClONO2: ClOx
    /// </summary>
    TotalInorganicChlorineExceptHClClOno2ClOx,

    /// <summary>
    /// Total Inorganic Bromine Except Hbr, BrONO2:BrOx
    /// </summary>
    TotalInorganicBromineExceptHbrBrOno2BrOx,
    
    LumpedAlkanes,
    
    LumpedAlkenes,
    
    LumpedAromaticCoumpounds,
    
    LumpedTerpenes,
    
    NonMethaneVolatileOrganicCompoundsExpressedAsCarbon,
    
    AnthropogenicNonMethaneVolatileOrganicCompoundsExpressedAsCarbon,
    
    BiogenicNonMethaneVolatileOrganicCompoundsExpressedAsCarbon,
    
    LumpedOxygenatedHydrocarbons,
    
    TotalAerosol = 62000,
    
    DustDry,
    
    WaterInAmbient,
    
    AmmoniumDry,
    
    NitrateDry,
    
    NitricAcidTrihydrate,
    
    SulphateDry,
    
    MercuryDry,
    
    SeaSaltDry,
    
    BlackCarbonDry,
    
    ParticulateOrganicMatterDry,
    
    PrimaryParticulateOrganicMatterDry,
    
    SecondaryParticulateOrganicMatterDry,
    
    Missing = 65535
}

