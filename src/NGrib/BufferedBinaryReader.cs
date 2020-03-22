using System;
using System.IO;
using System.Numerics;

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
			if (!FillBuffer() || NumBytesAvailable < numBytes)
			{
				throw new IndexOutOfRangeException();
			}
		}

		public int ReadUInt8()
		{
			EnsureAvailable(sizeof(byte));
			var val = buffer[bufferOffset];
			bufferOffset += sizeof(byte);
			return val;
		}

		public int ReadUInt16()
		{
			EnsureAvailable(sizeof(short));
			var val = BigEndianBitConverter.ToUInt16(buffer, bufferOffset);
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
			savedPosition = stream.Position;
		}

		public void SeekToSavedPosition()
		{
			Seek(savedPosition, SeekOrigin.Begin);
		}
	}
}
