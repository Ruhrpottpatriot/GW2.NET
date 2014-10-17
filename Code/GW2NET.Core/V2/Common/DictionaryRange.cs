// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DictionaryRange.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a subset of keys and values.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>Represents a subset of keys and values.</summary>
    /// <typeparam name="TKey">The type of the keys in the subset.</typeparam>
    /// <typeparam name="TValue">The type of the values in the subset.</typeparam>
    public sealed class DictionaryRange<TKey, TValue> : Dictionary<TKey, TValue>, IDictionaryRange<TKey, TValue>
    {
        /// <summary>Initializes a new instance of the <see cref="DictionaryRange{TKey,TValue}"/> class. 
        /// Initializes a new instance of the <see cref="DictionaryRange{TKey,TValue}"/> class that is empty, has the default initial capacity, and uses the default equality comparer for the key type.</summary>
        public DictionaryRange()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DictionaryRange{TKey,TValue}"/> class. Initializes a new instance of the <see cref="DictionaryRange{TKey,TValue}"/> class that is empty, has the specified initial capacity, and uses the default equality comparer for the key type.</summary>
        /// <param name="capacity">The initial number of elements that the <see cref="DictionaryRange{TKey,TValue}"/> can contain.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="capacity"/> is less than 0.</exception>
        public DictionaryRange(int capacity)
            : base(capacity)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DictionaryRange{TKey,TValue}"/> class. Initializes a new instance of the <see cref="DictionaryRange{TKey,TValue}"/> class that is empty, has the specified initial capacity, and uses the specified <see cref="IEqualityComparer{T}"/>.</summary>
        /// <param name="capacity">The initial number of elements that the <see cref="DictionaryRange{TKey,TValue}"/> can contain.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{T}"/> implementation to use when comparing keys, or null to use the default <see cref="EqualityComparer{T}"/> for the type of the key.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="capacity"/> is less than 0.</exception>
        public DictionaryRange(int capacity, IEqualityComparer<TKey> comparer)
            : base(capacity, comparer)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DictionaryRange{TKey,TValue}"/> class. Initializes a new instance of the <see cref="DictionaryRange{TKey,TValue}"/> class that is empty, has the default initial capacity, and uses the specified <see cref="IEqualityComparer{T}"/>.</summary>
        /// <param name="comparer">The <see cref="IEqualityComparer{T}"/> implementation to use when comparing keys, or null to use the default <see cref="EqualityComparer{T}"/> for the type of the key.</param>
        public DictionaryRange(IEqualityComparer<TKey> comparer)
            : base(comparer)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DictionaryRange{TKey,TValue}"/> class. Initializes a new instance of the <see cref="DictionaryRange{TKey,TValue}"/> class that contains elements copied from the specified <see cref="IDictionary{TKey, TValue}"/> and uses the default equality comparer for the key type.</summary>
        /// <param name="dictionary">The <see cref="IDictionary{TKey, TValue}"/> whose elements are copied to the new <see cref="DictionaryRange{TKey,TValue}"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="dictionary"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="dictionary"/> contains one or more duplicate keys.</exception>
        public DictionaryRange(IDictionary<TKey, TValue> dictionary)
            : base(dictionary)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DictionaryRange{TKey,TValue}"/> class. Initializes a new instance of the <see cref="DictionaryRange{TKey,TValue}"/> class that contains elements copied from the specified <see cref="IDictionary{TKey, TValue}"/> and uses the specified <see cref="IEqualityComparer{T}"/>.</summary>
        /// <param name="dictionary">The <see cref="IDictionary{TKey, TValue}"/> whose elements are copied to the new <see cref="DictionaryRange{TKey,TValue}"/>.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{T}"/> implementation to use when comparing keys, or null to use the default <see cref="EqualityComparer{T}"/> for the type of the key.</param>
        /// <exception cref="ArgumentNullException"><paramref name="dictionary"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="dictionary"/> contains one or more duplicate keys.</exception>
        public DictionaryRange(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
            : base(dictionary, comparer)
        {
        }

        /// <summary>Gets or sets the number of values in this subset.</summary>
        public int SubtotalCount { get; set; }

        /// <summary>Gets or sets the number of values in the collection.</summary>
        public int TotalCount { get; set; }
    }
}