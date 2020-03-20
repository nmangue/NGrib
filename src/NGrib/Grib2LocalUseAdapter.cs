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
using System.Text;
using System.IO;
using NGrib.Sections;

namespace NGrib
{
    public class Grib2LocalUseAdapter : IGrib2LocalUseAdapter
    {
        private MemoryStream _memStream;


        #region IGrib2LocalUseAdapter Members

        public void Connect(Grib2LocalUseSection source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }
            _memStream = new MemoryStream(source.getBytes());
        }

        public string ReadString(int startByte, int byteCount, Encoding encoding)
        {
            byte[] bytes = ReadBytes(startByte, byteCount);
            string str = encoding.GetString(bytes);
            return str;
        }

        public int ReadInt32(int startByte)
        {
            // Use GribNumbers to handle endian byte swapping
            return GribNumbers.int4(_memStream);
        }

        public byte[] ReadBytes(int startByte, int byteCount)
        {
            byte[] bytes = new byte[byteCount];
            int n = _memStream.Read(bytes, startByte, byteCount);
            if (n != byteCount)
            {
                throw new ApplicationException("Could not read all bytes");
            }
            return bytes;
        }

        #endregion
    }
}
