namespace NGrib
{
	internal class Constants
	{
		public static byte[] GribFileStart = { 0x47, 0x52, 0x49, 0x42 };

		/// <summary>
		/// "GRIB" (coded according to the International Alphabet No. 5.)
		/// converted to long.
		/// </summary>
		public static long GribFileStartCode = 1196575042;

		public static byte[] GribFileEnd = { 0x37, 0x37, 0x37, 0x37 };

		/// <summary>
		/// "7777" (coded according to the International Alphabet No. 5.)
		/// converted to long.
		/// </summary>
		public static long GribFileEndCode = 926365495;

		public static long IndicatorSectionLength = 16;
		public static long EndSectionLength = 16;
	}
}