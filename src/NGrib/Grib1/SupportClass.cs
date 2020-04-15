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

		/// <summary>
		/// Skips a given number of characters into a given Stream.
		/// </summary>
		/// <param name=" stream">The stream in which the skips are done.</param>
		/// <param name="number">The number of caracters to skip.</param>
		/// <returns>The number of characters skipped.</returns>
		public static long Skip(System.IO.StreamReader stream, long number)
		{
			long skippedBytes = 0;
			for (long index = 0; index < number; index++)
			{
				stream.Read();
				skippedBytes++;
			}

			return skippedBytes;
		}

		/// <summary>
		/// Skips a given number of characters into a given StringReader.
		/// </summary>
		/// <param name="strReader">The StringReader in which the skips are done.</param>
		/// <param name="number">The number of caracters to skip.</param>
		/// <returns>The number of characters skipped.</returns>
		public static long Skip(System.IO.StringReader strReader, long number)
		{
			long skippedBytes = 0;
			for (long index = 0; index < number; index++)
			{
				strReader.Read();
				skippedBytes++;
			}

			return skippedBytes;
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

		/// <summary>Reads a number of characters from the current source TextReader and writes the data to the target array at the specified index.</summary>
		/// <param name="sourceTextReader">The source TextReader to read from</param>
		/// <param name="target">Contains the array of characteres read from the source TextReader.</param>
		/// <param name="start">The starting index of the target array.</param>
		/// <param name="count">The maximum number of characters to read from the source TextReader.</param>
		/// <returns>The number of characters read. The number will be less than or equal to count depending on the data available in the source TextReader. Returns -1 if the end of the stream is reached.</returns>
		public static Int32 ReadInput(System.IO.TextReader sourceTextReader, sbyte[] target, int start, int count)
		{
			// Returns 0 bytes if not enough space in target
			if (target.Length == 0) return 0;

			char[] charArray = new char[target.Length];
			int bytesRead = sourceTextReader.Read(charArray, start, count);

			// Returns -1 if EOF
			if (bytesRead == 0) return -1;

			for (int index = start; index < start + bytesRead; index++)
				target[index] = (sbyte) charArray[index];

			return bytesRead;
		}

		/// Converts an array of sbytes to an array of bytes
		/// </summary>
		/// <param name="sbyteArray">The array of sbytes to be converted</param>
		/// <returns>The new array of bytes</returns>
		public static byte[] ToByteArray(sbyte[] sbyteArray)
		{
			byte[] byteArray = null;

			if (sbyteArray != null)
			{
				byteArray = new byte[sbyteArray.Length];
				for (int index = 0; index < sbyteArray.Length; index++)
					byteArray[index] = (byte) sbyteArray[index];
			}

			return byteArray;
		}

		/// <summary>
		/// Converts a string to an array of bytes
		/// </summary>
		/// <param name="sourceString">The string to be converted</param>
		/// <returns>The new array of bytes</returns>
		public static byte[] ToByteArray(String sourceString)
		{
			return System.Text.Encoding.UTF8.GetBytes(sourceString);
		}

		/// <summary>
		/// Converts a array of object-type instances to a byte-type array.
		/// </summary>
		/// <param name="tempObjectArray">Array to convert.</param>
		/// <returns>An array of byte type elements.</returns>
		public static byte[] ToByteArray(Object[] tempObjectArray)
		{
			byte[] byteArray = null;
			if (tempObjectArray != null)
			{
				byteArray = new byte[tempObjectArray.Length];
				for (int index = 0; index < tempObjectArray.Length; index++)
					byteArray[index] = (byte) tempObjectArray[index];
			}

			return byteArray;
		}

		/*******************************/

		/*******************************/
		/// <summary>
		/// Provides support for DateFormat
		/// </summary>
		public class DateTimeFormatManager
		{
			static public DateTimeFormatHashTable manager = new DateTimeFormatHashTable();

			/// <summary>
			/// Hashtable class to provide functionality for dateformat properties
			/// </summary>
			public class DateTimeFormatHashTable : System.Collections.Hashtable
			{
				/// <summary>
				/// Sets the format for datetime.
				/// </summary>
				/// <param name="format">DateTimeFormat instance to set the pattern</param>
				/// <param name="newPattern">A string with the pattern format</param>
				public void SetDateFormatPattern(System.Globalization.DateTimeFormatInfo format, String newPattern)
				{
					if (this[format] != null)
						((DateTimeFormatProperties) this[format]).DateFormatPattern = newPattern;
					else
					{
						DateTimeFormatProperties tempProps = new DateTimeFormatProperties();
						tempProps.DateFormatPattern = newPattern;
						Add(format, tempProps);
					}
				}

				/// <summary>
				/// Gets the current format pattern of the DateTimeFormat instance
				/// </summary>
				/// <param name="format">The DateTimeFormat instance which the value will be obtained</param>
				/// <returns>The string representing the current datetimeformat pattern</returns>
				public String GetDateFormatPattern(System.Globalization.DateTimeFormatInfo format)
				{
					if (this[format] == null)
						return "d-MMM-yy";
					else
						return ((DateTimeFormatProperties) this[format]).DateFormatPattern;
				}

				/// <summary>
				/// Sets the datetimeformat pattern to the giving format
				/// </summary>
				/// <param name="format">The datetimeformat instance to set</param>
				/// <param name="newPattern">The new datetimeformat pattern</param>
				public void SetTimeFormatPattern(System.Globalization.DateTimeFormatInfo format, String newPattern)
				{
					if (this[format] != null)
						((DateTimeFormatProperties) this[format]).TimeFormatPattern = newPattern;
					else
					{
						DateTimeFormatProperties tempProps = new DateTimeFormatProperties();
						tempProps.TimeFormatPattern = newPattern;
						Add(format, tempProps);
					}
				}

				/// <summary>
				/// Gets the current format pattern of the DateTimeFormat instance
				/// </summary>
				/// <param name="format">The DateTimeFormat instance which the value will be obtained</param>
				/// <returns>The string representing the current datetimeformat pattern</returns>
				public String GetTimeFormatPattern(System.Globalization.DateTimeFormatInfo format)
				{
					if (this[format] == null)
						return "h:mm:ss tt";
					else
						return ((DateTimeFormatProperties) this[format]).TimeFormatPattern;
				}

				/// <summary>
				/// Internal class to provides the DateFormat and TimeFormat pattern properties on .NET
				/// </summary>
				class DateTimeFormatProperties
				{
					public String DateFormatPattern = "d-MMM-yy";
					public String TimeFormatPattern = "h:mm:ss tt";
				}
			}
		}

		/*******************************/
		/// <summary>
		/// Gets the DateTimeFormat instance and date instance to obtain the date with the format passed
		/// </summary>
		/// <param name="format">The DateTimeFormat to obtain the time and date pattern</param>
		/// <param name="date">The date instance used to get the date</param>
		/// <returns>A string representing the date with the time and date patterns</returns>
		public static String FormatDateTime(System.Globalization.DateTimeFormatInfo format, DateTime date)
		{
			String timePattern = DateTimeFormatManager.manager.GetTimeFormatPattern(format);
			String datePattern = DateTimeFormatManager.manager.GetDateFormatPattern(format);
			return date.ToString(datePattern + " " + timePattern, format);
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


		/*******************************/
		/// <summary>
		/// This class provides functionality not found in .NET collection-related interfaces.
		/// </summary>
		public class ICollectionSupport
		{
			/// <summary>
			/// Adds a new element to the specified collection.
			/// </summary>
			/// <param name="c">Collection where the new element will be added.</param>
			/// <param name="obj">Object to add.</param>
			/// <returns>true</returns>
			public static bool Add(System.Collections.ICollection c, Object obj)
			{
				bool added = false;
				//Reflection. Invoke either the "add" or "Add" method.
				System.Reflection.MethodInfo method;
				try
				{
					//Get the "add" method for proprietary classes
					method = c.GetType().GetMethod("Add");
					if (method == null)
						method = c.GetType().GetMethod("add");
					int index = (int) method.Invoke(c, new Object[] {obj});
					if (index >= 0)
						added = true;
				}
				catch (Exception e)
				{
					throw e;
				}

				return added;
			}

			/// <summary>
			/// Adds all of the elements of the "c" collection to the "target" collection.
			/// </summary>
			/// <param name="target">Collection where the new elements will be added.</param>
			/// <param name="c">Collection whose elements will be added.</param>
			/// <returns>Returns true if at least one element was added, false otherwise.</returns>
			public static bool AddAll(System.Collections.ICollection target, System.Collections.ICollection c)
			{
				System.Collections.IEnumerator e = new System.Collections.ArrayList(c).GetEnumerator();
				bool added = false;

				//Reflection. Invoke "addAll" method for proprietary classes
				System.Reflection.MethodInfo method;
				try
				{
					method = target.GetType().GetMethod("addAll");

					if (method != null)
						added = (bool) method.Invoke(target, new Object[] {c});
					else
					{
						method = target.GetType().GetMethod("Add");
						while (e.MoveNext() == true)
						{
							bool tempBAdded = (int) method.Invoke(target, new Object[] {e.Current}) >= 0;
							added = added ? added : tempBAdded;
						}
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}

				return added;
			}

			/// <summary>
			/// Removes all the elements from the collection.
			/// </summary>
			/// <param name="c">The collection to remove elements.</param>
			public static void Clear(System.Collections.ICollection c)
			{
				//Reflection. Invoke "Clear" method or "clear" method for proprietary classes
				System.Reflection.MethodInfo method;
				try
				{
					method = c.GetType().GetMethod("Clear");

					if (method == null)
						method = c.GetType().GetMethod("clear");

					method.Invoke(c, new Object[] { });
				}
				catch (Exception e)
				{
					throw e;
				}
			}

			/// <summary>
			/// Determines whether the collection contains the specified element.
			/// </summary>
			/// <param name="c">The collection to check.</param>
			/// <param name="obj">The object to locate in the collection.</param>
			/// <returns>true if the element is in the collection.</returns>
			public static bool Contains(System.Collections.ICollection c, Object obj)
			{
				bool contains = false;

				//Reflection. Invoke "contains" method for proprietary classes
				System.Reflection.MethodInfo method;
				try
				{
					method = c.GetType().GetMethod("Contains");

					if (method == null)
						method = c.GetType().GetMethod("contains");

					contains = (bool) method.Invoke(c, new Object[] {obj});
				}
				catch (Exception e)
				{
					throw e;
				}

				return contains;
			}

			/// <summary>
			/// Determines whether the collection contains all the elements in the specified collection.
			/// </summary>
			/// <param name="target">The collection to check.</param>
			/// <param name="c">Collection whose elements would be checked for containment.</param>
			/// <returns>true id the target collection contains all the elements of the specified collection.</returns>
			public static bool ContainsAll(System.Collections.ICollection target, System.Collections.ICollection c)
			{
				System.Collections.IEnumerator e = c.GetEnumerator();

				bool contains = false;

				//Reflection. Invoke "containsAll" method for proprietary classes or "Contains" method for each element in the collection
				System.Reflection.MethodInfo method;
				try
				{
					method = target.GetType().GetMethod("containsAll");

					if (method != null)
						contains = (bool) method.Invoke(target, new Object[] {c});
					else
					{
						method = target.GetType().GetMethod("Contains");
						while (e.MoveNext() == true)
						{
							if ((contains = (bool) method.Invoke(target, new Object[] {e.Current})) == false)
								break;
						}
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}

				return contains;
			}

			/// <summary>
			/// Removes the specified element from the collection.
			/// </summary>
			/// <param name="c">The collection where the element will be removed.</param>
			/// <param name="obj">The element to remove from the collection.</param>
			public static bool Remove(System.Collections.ICollection c, Object obj)
			{
				bool changed = false;

				//Reflection. Invoke "remove" method for proprietary classes or "Remove" method
				System.Reflection.MethodInfo method;
				try
				{
					method = c.GetType().GetMethod("remove");

					if (method != null)
						method.Invoke(c, new Object[] {obj});
					else
					{
						method = c.GetType().GetMethod("Contains");
						changed = (bool) method.Invoke(c, new Object[] {obj});
						method = c.GetType().GetMethod("Remove");
						method.Invoke(c, new Object[] {obj});
					}
				}
				catch (Exception e)
				{
					throw e;
				}

				return changed;
			}

			/// <summary>
			/// Removes all the elements from the specified collection that are contained in the target collection.
			/// </summary>
			/// <param name="target">Collection where the elements will be removed.</param>
			/// <param name="c">Elements to remove from the target collection.</param>
			/// <returns>true</returns>
			public static bool RemoveAll(System.Collections.ICollection target, System.Collections.ICollection c)
			{
				System.Collections.ArrayList al = ToArrayList(c);
				System.Collections.IEnumerator e = al.GetEnumerator();

				//Reflection. Invoke "removeAll" method for proprietary classes or "Remove" for each element in the collection
				System.Reflection.MethodInfo method;
				try
				{
					method = target.GetType().GetMethod("removeAll");

					if (method != null)
						method.Invoke(target, new Object[] {al});
					else
					{
						method = target.GetType().GetMethod("Remove");
						System.Reflection.MethodInfo methodContains = target.GetType().GetMethod("Contains");

						while (e.MoveNext() == true)
						{
							while ((bool) methodContains.Invoke(target, new Object[] {e.Current}) == true)
								method.Invoke(target, new Object[] {e.Current});
						}
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}

				return true;
			}

			/// <summary>
			/// Retains the elements in the target collection that are contained in the specified collection
			/// </summary>
			/// <param name="target">Collection where the elements will be removed.</param>
			/// <param name="c">Elements to be retained in the target collection.</param>
			/// <returns>true</returns>
			public static bool RetainAll(System.Collections.ICollection target, System.Collections.ICollection c)
			{
				System.Collections.IEnumerator e = new System.Collections.ArrayList(target).GetEnumerator();
				System.Collections.ArrayList al = new System.Collections.ArrayList(c);

				//Reflection. Invoke "retainAll" method for proprietary classes or "Remove" for each element in the collection
				System.Reflection.MethodInfo method;
				try
				{
					method = c.GetType().GetMethod("retainAll");

					if (method != null)
						method.Invoke(target, new Object[] {c});
					else
					{
						method = c.GetType().GetMethod("Remove");

						while (e.MoveNext() == true)
						{
							if (al.Contains(e.Current) == false)
								method.Invoke(target, new Object[] {e.Current});
						}
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}

				return true;
			}

			/// <summary>
			/// Returns an array containing all the elements of the collection.
			/// </summary>
			/// <returns>The array containing all the elements of the collection.</returns>
			public static Object[] ToArray(System.Collections.ICollection c)
			{
				int index = 0;
				Object[] objects = new Object[c.Count];
				System.Collections.IEnumerator e = c.GetEnumerator();

				while (e.MoveNext())
					objects[index++] = e.Current;

				return objects;
			}

			/// <summary>
			/// Obtains an array containing all the elements of the collection.
			/// </summary>
			/// <param name="objects">The array into which the elements of the collection will be stored.</param>
			/// <returns>The array containing all the elements of the collection.</returns>
			public static Object[] ToArray(System.Collections.ICollection c, Object[] objects)
			{
				int index = 0;

				Type type = objects.GetType().GetElementType();
				Object[] objs = (Object[]) Array.CreateInstance(type, c.Count);

				System.Collections.IEnumerator e = c.GetEnumerator();

				while (e.MoveNext())
					objs[index++] = e.Current;

				//If objects is smaller than c then do not return the new array in the parameter
				if (objects.Length >= c.Count)
					objs.CopyTo(objects, 0);

				return objs;
			}

			/// <summary>
			/// Converts an ICollection instance to an ArrayList instance.
			/// </summary>
			/// <param name="c">The ICollection instance to be converted.</param>
			/// <returns>An ArrayList instance in which its elements are the elements of the ICollection instance.</returns>
			public static System.Collections.ArrayList ToArrayList(System.Collections.ICollection c)
			{
				System.Collections.ArrayList tempArrayList = new System.Collections.ArrayList();
				System.Collections.IEnumerator tempEnumerator = c.GetEnumerator();
				while (tempEnumerator.MoveNext())
					tempArrayList.Add(tempEnumerator.Current);
				return tempArrayList;
			}
		}


		/*******************************/
		/// <summary>
		/// This method returns the literal value received
		/// </summary>
		/// <param name="literal">The literal to return</param>
		/// <returns>The received value</returns>
		public static long Identity(long literal)
		{
			return literal;
		}

		/// <summary>
		/// This method returns the literal value received
		/// </summary>
		/// <param name="literal">The literal to return</param>
		/// <returns>The received value</returns>
		public static ulong Identity(ulong literal)
		{
			return literal;
		}

		/// <summary>
		/// This method returns the literal value received
		/// </summary>
		/// <param name="literal">The literal to return</param>
		/// <returns>The received value</returns>
		public static float Identity(float literal)
		{
			return literal;
		}

		/// <summary>
		/// This method returns the literal value received
		/// </summary>
		/// <param name="literal">The literal to return</param>
		/// <returns>The received value</returns>
		public static double Identity(double literal)
		{
			return literal;
		}

		/*******************************/
		/// <summary>
		/// Writes the exception stack trace to the received stream
		/// </summary>
		/// <param name="throwable">Exception to obtain information from</param>
		/// <param name="stream">Output sream used to write to</param>
		public static void WriteStackTrace(Exception throwable, System.IO.TextWriter stream)
		{
			stream.Write(throwable.StackTrace);
			stream.Flush();
		}

		/*******************************/
		/// <summary>
		/// The class performs token processing in strings
		/// </summary>
		public class Tokenizer : System.Collections.IEnumerator
		{
			/// Position over the string
			private long currentPos;

			/// Include demiliters in the results.
			private bool includeDelims;

			/// Char representation of the String to tokenize.
			private char[] chars;

			//The tokenizer uses the default delimiter set: the space character, the tab character, the newline character, and the carriage-return character and the form-feed character
			private string delimiters = " \t\n\r\f";

			/// <summary>
			/// Initializes a new class instance with a specified string to process
			/// </summary>
			/// <param name="source">String to tokenize</param>
			public Tokenizer(String source)
			{
				chars = source.ToCharArray();
			}

			/// <summary>
			/// Initializes a new class instance with a specified string to process
			/// and the specified token delimiters to use
			/// </summary>
			/// <param name="source">String to tokenize</param>
			/// <param name="delimiters">String containing the delimiters</param>
			public Tokenizer(String source, String delimiters) : this(source)
			{
				this.delimiters = delimiters;
			}


			/// <summary>
			/// Initializes a new class instance with a specified string to process, the specified token 
			/// delimiters to use, and whether the delimiters must be included in the results.
			/// </summary>
			/// <param name="source">String to tokenize</param>
			/// <param name="delimiters">String containing the delimiters</param>
			/// <param name="includeDelims">Determines if delimiters are included in the results.</param>
			public Tokenizer(String source, String delimiters, bool includeDelims) : this(source, delimiters)
			{
				this.includeDelims = includeDelims;
			}


			/// <summary>
			/// Returns the next token from the token list
			/// </summary>
			/// <returns>The string value of the token</returns>
			public String NextToken()
			{
				return NextToken(delimiters);
			}

			/// <summary>
			/// Returns the next token from the source string, using the provided
			/// token delimiters
			/// </summary>
			/// <param name="delimiters">String containing the delimiters to use</param>
			/// <returns>The string value of the token</returns>
			public String NextToken(String delimiters)
			{
				//According to documentation, the usage of the received delimiters should be temporary (only for this call).
				//However, it seems it is not true, so the following line is necessary.
				this.delimiters = delimiters;

				//at the end 
				if (currentPos == chars.Length)
					throw new ArgumentOutOfRangeException();
				//if over a delimiter and delimiters must be returned
				else if ((Array.IndexOf(delimiters.ToCharArray(), chars[currentPos]) != -1)
				         && includeDelims)
					return "" + chars[currentPos++];
				//need to get the token wo delimiters.
				else
					return nextToken(delimiters.ToCharArray());
			}

			//Returns the nextToken wo delimiters
			private String nextToken(char[] delimiters)
			{
				string token = "";
				long pos = currentPos;

				//skip possible delimiters
				while (Array.IndexOf(delimiters, chars[currentPos]) != -1)
					//The last one is a delimiter (i.e there is no more tokens)
					if (++currentPos == chars.Length)
					{
						currentPos = pos;
						throw new ArgumentOutOfRangeException();
					}

				//getting the token
				while (Array.IndexOf(delimiters, chars[currentPos]) == -1)
				{
					token += chars[currentPos];
					//the last one is not a delimiter
					if (++currentPos == chars.Length)
						break;
				}

				return token;
			}


			/// <summary>
			/// Determines if there are more tokens to return from the source string
			/// </summary>
			/// <returns>True or false, depending if there are more tokens</returns>
			public bool HasMoreTokens()
			{
				//keeping the current pos
				long pos = currentPos;

				try
				{
					NextToken();
				}
				catch (ArgumentOutOfRangeException)
				{
					return false;
				}
				finally
				{
					currentPos = pos;
				}

				return true;
			}

			/// <summary>
			/// Remaining tokens count
			/// </summary>
			public int Count
			{
				get
				{
					//keeping the current pos
					long pos = currentPos;
					int i = 0;

					try
					{
						while (true)
						{
							NextToken();
							i++;
						}
					}
					catch (ArgumentOutOfRangeException)
					{
						currentPos = pos;
						return i;
					}
				}
			}

			/// <summary>
			///  Performs the same action as NextToken.
			/// </summary>
			public Object Current
			{
				get { return (Object) NextToken(); }
			}

			/// <summary>
			//  Performs the same action as HasMoreTokens.
			/// </summary>
			/// <returns>True or false, depending if there are more tokens</returns>
			public bool MoveNext()
			{
				return HasMoreTokens();
			}

			/// <summary>
			/// Does nothing.
			/// </summary>
			public void Reset()
			{
				;
			}
		}
	}
}