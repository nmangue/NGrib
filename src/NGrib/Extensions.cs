using System;

namespace NGrib
{
	public static class Extensions
	{
		/// <summary>
		/// Convert to radians.
		/// </summary>
		/// <param name="val">The value to convert to radians</param>
		/// <returns>The value in radians</returns>
		public static double ToRadians(this double val) => Math.PI / 180d * val;

		/// <summary>
		/// Convert to degrees.
		/// </summary>
		/// <param name="val">The value to convert to degrees</param>
		/// <returns>The value in degrees</returns>
		public static double ToDegrees(this double val) => 180d / Math.PI * val;

		public static T? As<T>(this int val) where T : struct, Enum, IConvertible
		{
			return (T?) (Enum.IsDefined(typeof(T), val) ? Enum.ToObject(typeof(T), val) : null);
		}
	}
}
