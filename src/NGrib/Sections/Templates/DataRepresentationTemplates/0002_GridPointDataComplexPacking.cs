namespace NGrib.Sections.Templates.DataRepresentationTemplates
{
    /// <summary>
    /// Data Representation Template 5.2: Grid point data - complex packing
    /// </summary>
    public class GridPointDataComplexPacking : GridPointDataSimplePacking
    {
        /// <summary> Group splitting method used (see Code Table 5.4).</summary>
        /// <returns> SplittingMethod
        /// </returns>
        public int SplittingMethod { get; }

        /// <summary> Missing value management used (see Code Table 5.5).</summary>
        /// <returns> MissingValueManagement
        /// </returns>
        public int MissingValueManagement { get; }

        /// <summary> Primary missing value substitute.</summary>
        /// <returns> PrimaryMissingValue
        /// </returns>
        public float PrimaryMissingValue { get; private set; }

        /// <summary> Secondary missing value substitute.</summary>
        /// <returns> SecondaryMissingValue
        /// </returns>
        public float SecondaryMissingValue { get; private set; }

        /// <summary> NG - Number of groups of data values into which field is split.</summary>
        /// <returns> NumberOfGroups NG
        /// </returns>
        public long NumberOfGroups { get; }

        /// <summary> Reference for group widths (see Note 12).</summary>
        /// <returns> ReferenceGroupWidths
        /// </returns>
        public int ReferenceGroupWidths { get; }

        /// <summary> Number of bits used for the group widths (after the reference value 
        /// in octet 36 has been removed).
        /// </summary>
        /// <returns> BitsGroupWidths
        /// </returns>
        public int BitsGroupWidths { get; }

        /// <summary> Reference for group lengths (see Note 13).</summary>
        /// <returns> ReferenceGroupLength
        /// </returns>
        public long ReferenceGroupLength { get; }

        /// <summary> Length increment for the group lengths (see Note 14).</summary>
        /// <returns> LengthIncrement
        /// </returns>
        public int LengthIncrement { get; }

        /// <summary> Length increment for the group lengths (see Note 14).</summary>
        /// <returns> LengthLastGroup
        /// </returns>
        public long LengthLastGroup { get; }

        /// <summary> Number of bits used for the scaled group lengths (after subtraction of 
        /// the reference value given in octets 38-41 and division by the length 
        /// increment given in octet 42).
        /// </summary>
        /// <returns> BitsScaledGroupLength
        /// </returns>
        public int BitsScaledGroupLength { get; }

        internal GridPointDataComplexPacking(BufferedBinaryReader reader) : base(reader)
        {
            SplittingMethod = reader.ReadUInt8();

            MissingValueManagement = reader.ReadUInt8();

            PrimaryMissingValue = reader.ReadSingle();
            SecondaryMissingValue = reader.ReadSingle();
            NumberOfGroups = reader.ReadUInt32();

            ReferenceGroupWidths = reader.ReadUInt8();

            BitsGroupWidths = reader.ReadUInt8();
            // according to documentation subtract referenceGroupWidths
            BitsGroupWidths = BitsGroupWidths - ReferenceGroupWidths;

            ReferenceGroupLength = reader.ReadUInt32();

            LengthIncrement = reader.ReadUInt8();

            LengthLastGroup = reader.ReadUInt32();

            BitsScaledGroupLength = reader.ReadUInt8();
        }
    }
}