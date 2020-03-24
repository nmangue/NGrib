namespace NGrib.Sections.Templates.DataRepresentationTemplates
{
    public class GridPointDataJpeg2000CodeStream : GridPointDataSimplePacking
    {
        /// <summary> Type compression method used (see Code Table 5.40000).</summary>
        /// <returns> CompressionMethod
        /// </returns>
        public int CompressionMethod { get; }

        /// <summary> Compression ratio used .</summary>
        /// <returns> CompressionRatio
        /// </returns>
        public int CompressionRatio { get; }

        internal GridPointDataJpeg2000CodeStream(BufferedBinaryReader reader) : base(reader)
        {
            CompressionMethod = reader.ReadUInt8();

            CompressionRatio = reader.ReadUInt8();
        }
    }
}