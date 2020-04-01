using NGrib.Grib2.Sections;

namespace NGrib
{
	/// <summary>
	/// The exception that is thrown when the read section number is not
	/// the expected one.
	/// </summary>
	public class UnexpectedGribSectionException : BadGribFormatException
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UnexpectedGribSectionException"/> class.
		/// </summary>
		/// <param name="expectedSectionCode">The expected section code.</param>
		/// <param name="readSectionCode">The section code actually read.</param>
		public UnexpectedGribSectionException(SectionCode expectedSectionCode, int readSectionCode) 
			: base($"Expected section {expectedSectionCode} but found {readSectionCode}")
		{
		}
	}
}