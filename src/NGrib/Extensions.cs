/*
 * This file is part of NGrib.
 *
 * Copyright © 2020 Nicolas Mangué
 * 
 * NGrib is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 3 of the License, or (at your option) any later version.
 * 
 * NGrib is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 * 
 * You should have received a copy of the GNU Lesser General Public License
 * along with NGrib.  If not, see <https://www.gnu.org/licenses/>.
 */

using System;

namespace NGrib
{
	internal static class Extensions
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
			if (IsFlagEnum(typeof(T)))
			{

			}
			return (T?) (Enum.IsDefined(typeof(T), val) ? Enum.ToObject(typeof(T), val) : null);
		}

		public static bool IsFlagEnum(Type t) => t.IsEnum && !Attribute.IsDefined(t, typeof(FlagsAttribute));
	}
}
