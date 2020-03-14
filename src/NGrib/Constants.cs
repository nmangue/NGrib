namespace NGrib
{
	internal class Constants
	{
		public static byte[] GribFileStart = new byte[] { 0x47, 0x52, 0x49, 0x42 };
		public static byte[] GribFileEnd = new byte[] { 0x37, 0x37, 0x37, 0x37 };
	}
}