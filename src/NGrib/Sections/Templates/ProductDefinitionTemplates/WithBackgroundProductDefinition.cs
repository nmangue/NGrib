namespace NGrib.Sections.Templates.ProductDefinitionTemplates
{
    public class WithBackgroundProductDefinition : ProductDefinition
    {
        /// <summary> backGenProcess.</summary>
        /// <returns> BackGenProcess
        /// </returns>
        public int BackGenProcess { get; }

        internal WithBackgroundProductDefinition(BufferedBinaryReader reader) : base(reader)
        {
            BackGenProcess = reader.ReadUInt8();
        }
    }
}