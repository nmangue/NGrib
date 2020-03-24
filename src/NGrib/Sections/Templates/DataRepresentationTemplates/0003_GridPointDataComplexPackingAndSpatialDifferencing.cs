namespace NGrib.Sections.Templates.DataRepresentationTemplates
{
    /// <summary>
    /// Data Representation Template 5.3:  Grid point data - complex packing and spatial differencing
    /// </summary>
    public class GridPointDataComplexPackingAndSpatialDifferencing : GridPointDataComplexPacking
    {
        /// <summary> Order of spatial differencing (see Code Table 5.6).</summary>
        /// <returns> OrderSpatial
        /// </returns>
        public int OrderSpatial { get; }

        /// <summary> Number of octets required in the Data Section to specify extra
        /// descriptors needed for spatial differencing (octets 6-ww in Data
        /// Template 7.3).
        /// </summary>
        /// <returns> DescriptorSpatial
        /// </returns>
        public int DescriptorSpatial { get; }

        internal GridPointDataComplexPackingAndSpatialDifferencing(BufferedBinaryReader reader) : base(reader)
        {
            OrderSpatial = reader.ReadUInt8();
            DescriptorSpatial = reader.ReadUInt8();
        }
    }
}