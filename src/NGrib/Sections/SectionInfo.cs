namespace NGrib.Sections
{
	public readonly struct SectionInfo
	{
		public long Length { get; }

		public int SectionCode { get; }

		public SectionInfo(long length, int sectionCode)
		{
			Length = length;
			SectionCode = sectionCode;
		}

		public SectionInfo(long length, SectionCode sectionCode) : this(length, (int) sectionCode)
		{
		}

		public bool Is(SectionCode sectionCode) => SectionCode == (int) sectionCode;
	}
}
