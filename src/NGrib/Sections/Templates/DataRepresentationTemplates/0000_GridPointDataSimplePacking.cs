namespace NGrib.Sections.Templates.DataRepresentationTemplates
{
    /// <summary>
    /// Data Representation Template 5.0: Grid point data - simple packing
    /// </summary>
    public class GridPointDataSimplePacking : DataRepresentation
    {
        /// <summary> Reference value (R) (IEEE 32-bit floating-point value).</summary>
        /// <returns> ReferenceValue
        /// </returns>
        public float ReferenceValue { get; }

        /// <summary> Binary scale factor (E).</summary>
        /// <returns> BinaryScaleFactor
        /// </returns>
        public int BinaryScaleFactor { get; }

        /// <summary> Decimal scale factor (D).</summary>
        /// <returns> DecimalScaleFactor
        /// </returns>
        public int DecimalScaleFactor { get; }

        /// <summary> Number of bits used for each packed value..</summary>
        /// <returns> NumberOfBits NB
        /// </returns>
        public int NumberOfBits { get; }

        /// <summary> Type of original field values.</summary>
        /// <returns> OriginalType dataType
        /// </returns>
        public int OriginalType { get; }

        internal GridPointDataSimplePacking(BufferedBinaryReader reader)
        {
            ReferenceValue = reader.ReadSingle();
            BinaryScaleFactor = reader.ReadUInt16();
            DecimalScaleFactor = reader.ReadUInt16();
            NumberOfBits = reader.ReadUInt8();

            OriginalType = reader.ReadUInt8();
        }
    }
}