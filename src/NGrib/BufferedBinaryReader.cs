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
using System.IO;
using System.Numerics;
using NGrib.Grib2.Sections;

namespace NGrib
{
	internal class BufferedBinaryReader : IDisposable
	{
		private readonly Stream stream;
		private readonly byte[] buffer;
		private readonly int bufferSize;
		private int bufferOffset;
		private int numBufferedBytes;
		private long savedPosition;
		private int NumBytesAvailable => Math.Max(0, numBufferedBytes - bufferOffset);

		public bool HasReachedStreamEnd => stream.Position >= stream.Length && NumBytesAvailable <= 0;

		public BufferedBinaryReader(Stream stream, int bufferSize = 4096)
		{
			this.stream = stream;
			this.bufferSize = bufferSize;
			buffer = new byte[bufferSize];
			MarkBufferAsUsed();
			SaveCurrentPosition();
		}

		private bool FillBuffer()
		{
			var numBytesUnread = bufferSize - bufferOffset;
			var numBytesToRead = bufferSize - numBytesUnread;
			bufferOffset = 0;
			numBufferedBytes = numBytesUnread;
			if (numBytesUnread > 0)
			{
				Buffer.BlockCopy(buffer, numBytesToRead, buffer, 0, numBytesUnread);
			}
			while (numBytesToRead > 0)
			{
				var numBytesRead = stream.Read(buffer, numBytesUnread, numBytesToRead);
				if (numBytesRead == 0)
				{
					return false;
				}
				numBufferedBytes += numBytesRead;
				numBytesToRead -= numBytesRead;
				numBytesUnread += numBytesRead;
			}
			return true;
		}

		private void EnsureAvailable(int numBytes)
		{
			if (NumBytesAvailable >= numBytes) return;
			
			// Try to read from the stream
			// and check that we were able to read the bytes we wanted
			if (!FillBuffer() && NumBytesAvailable < numBytes)
			{
				throw new IndexOutOfRangeException();
			}
		}

    public byte ReadByte()
    {
      EnsureAvailable(sizeof(byte));
      var val = buffer[bufferOffset];
      bufferOffset += sizeof(byte);
      return val;
		}

		public int ReadUInt8() => ReadByte();

    public int ReadUInt16()
		{
			EnsureAvailable(sizeof(short));
			var val = BigEndianBitConverter.ToUInt16(buffer, bufferOffset);
			bufferOffset += sizeof(short);
			return val;
		}

    public int ReadInt16()
    {
	    EnsureAvailable(sizeof(short));
	    var val = BigEndianBitConverter.ToInt16(buffer, bufferOffset);
	    bufferOffset += sizeof(short);
	    return val;
    }

		public long ReadUInt32()
		{
			EnsureAvailable(sizeof(uint));
			var val = BigEndianBitConverter.ToUInt32(buffer, bufferOffset);
			bufferOffset += sizeof(uint);
			return val;
		}

		public int ReadInt32()
		{
			EnsureAvailable(sizeof(int));
			var val = BigEndianBitConverter.ToInt32(buffer, bufferOffset);
			bufferOffset += sizeof(int);
			return val;
		}

		public void NextUIntN()
		{
			positionInBbbReadBuffer = 0;
			bitByBitReadBuffer = 0;
		}

		private int bitByBitReadBuffer;
		private int positionInBbbReadBuffer;
		public int ReadUIntN(int nbBit)
		{
			int bitsLeft = nbBit;
			int result = 0;

			if (positionInBbbReadBuffer == 0)
			{
				bitByBitReadBuffer = ReadByte();
				positionInBbbReadBuffer = 8;
			}

			while (true)
			{
				int shift = bitsLeft - positionInBbbReadBuffer;
				if (shift > 0)
				{
					// Consume the entire buffer
					result |= bitByBitReadBuffer << shift;
					bitsLeft -= positionInBbbReadBuffer;

					// Get the next byte from the RandomAccessFile
					bitByBitReadBuffer = ReadByte();
					positionInBbbReadBuffer = 8;
				}
				else
				{
					// Consume a portion of the buffer
					result |= bitByBitReadBuffer >> -shift;
					positionInBbbReadBuffer -= bitsLeft;
					bitByBitReadBuffer &= 0xff >> (8 - positionInBbbReadBuffer); // mask off consumed bits

					return result;
				}
			}
		}
	
		public BigInteger ReadUInt64()
		{
			EnsureAvailable(sizeof(ulong));
			var val = BigEndianBitConverter.ToUInt64(buffer, bufferOffset);
			bufferOffset += sizeof(ulong);
			return val;
		}

		public float ReadSingle()
		{
			EnsureAvailable(sizeof(float));
			var val = BigEndianBitConverter.ToSingle(buffer, bufferOffset);
			bufferOffset += sizeof(float);
			return val;
		}

		public byte[] Read(int numBytes)
		{
			if (numBytes == 0) return new byte[0];
			EnsureAvailable(numBytes);
			var result = new byte[numBytes];
			Buffer.BlockCopy(buffer, bufferOffset, result, 0, numBytes);
			bufferOffset += numBytes;
			return result;
		}

		public SectionInfo PeekSection()
		{
			SaveCurrentPosition();
			var info = ReadSectionInfo();
			SeekToSavedPosition();
			return info;
		}

		public SectionInfo ReadSectionInfo()
		{
			var sectionLength = ReadUInt32();

			if (sectionLength == Constants.GribFileStartCode)
			{
				return new SectionInfo(Constants.IndicatorSectionLength, SectionCode.IndicatorSection);
			}
			
			if (sectionLength == Constants.GribFileEndCode)
			{
				return new SectionInfo(Constants.EndSectionLength, SectionCode.EndSection);
			}

			var sectionCode = ReadUInt8();
			return new SectionInfo(sectionLength, sectionCode);
		}

		public void Skip(int numBytes)
		{
			if (numBytes <= NumBytesAvailable)
			{
				bufferOffset += numBytes;
			}
			else
			{
				var offset = numBytes - NumBytesAvailable;
				stream.Seek(offset, SeekOrigin.Current);
				MarkBufferAsUsed();
			}
		}

		public void Seek(long offset, SeekOrigin origin)
		{
			stream.Seek(offset, origin);
			MarkBufferAsUsed();
		}

		private void MarkBufferAsUsed()
		{
			// Mark the buffer as completely used
			// to trigger a refill
			bufferOffset = bufferSize;
		}

		public void Dispose()
		{
			stream.Close();
		}

		public void SaveCurrentPosition()
		{
			savedPosition = Position;
		}

    public long Position => stream.Position - NumBytesAvailable;

		public void SeekToSavedPosition()
		{
			Seek(savedPosition, SeekOrigin.Begin);
		}
	}
}
