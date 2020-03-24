using System;
using System.Collections;
using System.Collections.Generic;

namespace NGrib.Sections.Templates
{
    internal class TemplateFactory<T> : IEnumerable<KeyValuePair<int, Func<BufferedBinaryReader, T>>>
    {
        /// <summary>
        /// Methods available to build T from a templateNumber.
        /// </summary>
        /// <remarks>
        /// We use Stack instead of List (or even Dictionary) to provide an easy way to override or extend
        /// the default factories.
        /// </remarks>
        private readonly Dictionary<int, Func<BufferedBinaryReader, T>> factories;

        public TemplateFactory()
        {
            factories = new Dictionary<int, Func<BufferedBinaryReader, T>>();
        }

        /// <summary>
        /// Add a new factory method.
        /// </summary>
        internal void Add(int templateNumber, Func<BufferedBinaryReader, T> factoryMethod)
        {
            if (factoryMethod == null) throw new ArgumentNullException(nameof(factoryMethod));

            factories[templateNumber] = factoryMethod;
        }

        internal T Build(BufferedBinaryReader reader, int templateNumber)
        {
            return factories.TryGetValue(templateNumber, out var factory) ? factory(reader) : throw new NotSupportedException();

        }

        public IEnumerator<KeyValuePair<int, Func<BufferedBinaryReader, T>>> GetEnumerator() => factories.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
