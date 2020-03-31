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
using System.Collections;
using System.Collections.Generic;

namespace NGrib.Grib2.Templates
{
	internal class TemplateFactory<T> : IEnumerable<KeyValuePair<int, Func<BufferedBinaryReader, object[], T>>>
	{
		/// <summary>
		/// Methods available to build T from a templateNumber.
		/// </summary>
		/// <remarks>
		/// We use Stack instead of List (or even Dictionary) to provide an easy way to override or extend
		/// the default factories.
		/// </remarks>
		private readonly Dictionary<int, Func<BufferedBinaryReader, object[], T>> factories;

		public TemplateFactory()
		{
			factories = new Dictionary<int, Func<BufferedBinaryReader, object[], T>>();
		}

		/// <summary>
		/// Add a new factory method.
		/// </summary>
		internal void Add(int templateNumber, Func<BufferedBinaryReader, T> factoryMethod)
		{
			if (factoryMethod == null) throw new ArgumentNullException(nameof(factoryMethod));

			factories[templateNumber] = (reader, objects) => factoryMethod(reader);
		}

		/// <summary>
		/// Add a new factory method.
		/// </summary>
		internal void Add(int templateNumber, Func<BufferedBinaryReader, object[], T> factoryMethod)
		{
			factories[templateNumber] = factoryMethod ?? throw new ArgumentNullException(nameof(factoryMethod));
		}

		internal T Build(BufferedBinaryReader reader, int templateNumber, params object[] args)
		{
			return factories.TryGetValue(templateNumber, out var factory)
				? factory(reader, args)
				: throw new NotSupportedException();
		}

		public IEnumerator<KeyValuePair<int, Func<BufferedBinaryReader, object[], T>>> GetEnumerator() =>
			factories.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}