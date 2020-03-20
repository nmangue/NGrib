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

using NGrib.Sections;

namespace NGrib
{
    public interface IGrib2LocalUseAdapter
    {
        /// <summary>
        /// Connects this adapter to a Grib2LocalUseSection object
        /// </summary>
        /// <param name="source">Grib2LocalUseSection object</param>
        void Connect(Grib2LocalUseSection source);

        /// <summary>
        /// Reads a string using the specified encoding from the local use section buffer
        /// </summary>
        /// <param name="startByte">Byte index to start at</param>
        /// <param name="byteCount">No of bytes to read</param>
        /// <param name="encoding">The encoding to use</param>
        /// <returns></returns>
        string ReadString(int startByte, int byteCount, System.Text.Encoding encoding);

        /// <summary>
        /// Reads a Int32 from the local use section
        /// </summary>
        /// <param name="startByte">Byte index to start at</param>
        /// <returns></returns>
        int ReadInt32(int startByte);

        /// <summary>
        /// Reads a byte array from the local use section
        /// </summary>
        /// <param name="startByte">Byte index to start at</param>
        /// <param name="byteCount">No of bytes to read</param>
        /// <returns></returns>
        byte[] ReadBytes(int startByte, int byteCount);
    }
}
