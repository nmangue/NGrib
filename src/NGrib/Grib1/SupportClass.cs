/*
 * This file is part of NGrib.
 *
 * Copyright © 2020 Nicolas Mangué
 * 
 * Copyright 2006-2010 Seaware AB, PO Box 1244, SE-131 28 
 * Nacka Strand, Sweden, info@seaware.se.
 * 
 * Copyright 1997-2006 Unidata Program Center/University 
 * Corporation for Atmospheric Research, P.O. Box 3000, Boulder, CO 80307,
 * support@unidata.ucar.edu.
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

namespace NGrib.Grib1
{
	/// <summary>
	/// Contains conversion support elements such as classes, interfaces and static methods.
	/// </summary>
	internal class SupportClass
	{
		/// <summary>
		/// Try to skip bytes in the input stream and return the actual number of bytes skipped.
		/// </summary>
		/// <param name="stream">Input stream that will be used to skip the bytes</param>
		/// <param name="skipbytes">Number of bytes to be skipped</param>
		/// <returns>Actual number of bytes skipped</returns>
		public static int Skip(System.IO.Stream stream, int skipBytes)
		{
			long oldPosition = stream.Position;
			long result = stream.Seek(skipBytes, System.IO.SeekOrigin.Current) - oldPosition;
			return (int) result;
		}

		/*******************************/
		/// <summary>Reads a number of characters from the current source Stream and writes the data to the target array at the specified index.</summary>
		/// <param name="sourceStream">The source Stream to read from.</param>
		/// <param name="target">Contains the array of characteres read from the source Stream.</param>
		/// <param name="start">The starting index of the target array.</param>
		/// <param name="count">The maximum number of characters to read from the source Stream.</param>
		/// <returns>The number of characters read. The number will be less than or equal to count depending on the data available in the source Stream. Returns -1 if the end of the stream is reached.</returns>
		public static Int32 ReadInput(System.IO.Stream sourceStream, sbyte[] target, int start, int count)
		{
			// Returns 0 bytes if not enough space in target
			if (target.Length == 0)
				return 0;

			byte[] receiver = new byte[target.Length];
			int bytesRead = sourceStream.Read(receiver, start, count);

			// Returns -1 if EOF
			if (bytesRead == 0)
				return -1;

			for (int i = start; i < start + bytesRead; i++)
				target[i] = (sbyte) receiver[i];

			return bytesRead;
		}

		/*******************************/
		/// <summary>
		/// Represents a collection ob objects that contains no duplicate elements.
		/// </summary>	
		public interface SetSupport : System.Collections.ICollection, System.Collections.IList
		{
			/// <summary>
			/// Adds a new element to the Collection if it is not already present.
			/// </summary>
			/// <param name="obj">The object to add to the collection.</param>
			/// <returns>Returns true if the object was added to the collection, otherwise false.</returns>
			new bool Add(Object obj);

			/// <summary>
			/// Adds all the elements of the specified collection to the Set.
			/// </summary>
			/// <param name="c">Collection of objects to add.</param>
			/// <returns>true</returns>
			bool AddAll(System.Collections.ICollection c);
		}

		/*******************************/
		/// <summary>
		/// SupportClass for the HashSet class.
		/// </summary>
		[Serializable]
		public class HashSetSupport : System.Collections.ArrayList, SetSupport
		{
			public HashSetSupport() : base()
			{
			}

			public HashSetSupport(System.Collections.ICollection c)
			{
				AddAll(c);
			}

			public HashSetSupport(int capacity) : base(capacity)
			{
			}

			/// <summary>
			/// Adds a new element to the ArrayList if it is not already present.
			/// </summary>		
			/// <param name="obj">Element to insert to the ArrayList.</param>
			/// <returns>Returns true if the new element was inserted, false otherwise.</returns>
			new public virtual bool Add(Object obj)
			{
				bool inserted;

				if ((inserted = Contains(obj)) == false)
				{
					base.Add(obj);
				}

				return !inserted;
			}

			/// <summary>
			/// Adds all the elements of the specified collection that are not present to the list.
			/// </summary>
			/// <param name="c">Collection where the new elements will be added</param>
			/// <returns>Returns true if at least one element was added, false otherwise.</returns>
			public bool AddAll(System.Collections.ICollection c)
			{
				System.Collections.IEnumerator e = new System.Collections.ArrayList(c).GetEnumerator();
				bool added = false;

				while (e.MoveNext() == true)
				{
					if (Add(e.Current) == true)
						added = true;
				}

				return added;
			}

			/// <summary>
			/// Returns a copy of the HashSet instance.
			/// </summary>		
			/// <returns>Returns a shallow copy of the current HashSet.</returns>
			public override Object Clone()
			{
				return MemberwiseClone();
			}
		}
	}
}