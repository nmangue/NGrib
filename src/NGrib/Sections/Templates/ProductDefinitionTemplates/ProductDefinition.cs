namespace NGrib.Sections.Templates.ProductDefinitionTemplates
{
    public abstract class ProductDefinition
    {
        public long Offset { get; }

        /// <summary> parameter Category .</summary>
        /// <returns> parameterCategory as int
        /// </returns>
        public int ParameterCategory { get; }

        /// <summary> parameter Number.</summary>
        /// <returns> ParameterNumber
        /// </returns>
        public int ParameterNumber { get; }

        /// <summary> typeGenProcess.</summary>
        /// <returns> GenProcess
        /// </returns>
        public int TypeGenProcess { get; }
        
        private protected ProductDefinition(BufferedBinaryReader reader)
        {
            Offset = reader.Position;
            ParameterCategory = reader.ReadUInt8();
            ParameterNumber = reader.ReadUInt8();
            TypeGenProcess = reader.ReadUInt8();
        }
    }
}
