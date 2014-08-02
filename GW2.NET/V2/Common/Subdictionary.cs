// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Subdictionary.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a subcollection of keys and values.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V2.Common
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>Represents a subset of keys and values.</summary>
    /// <typeparam name="TKey">The type of the keys in the subset.</typeparam>
    /// <typeparam name="TValue">The type of the values in the subset.</typeparam>
    public sealed class Subdictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISubcollection
    {
        /// <summary>Initializes a new instance of the <see cref="Subdictionary{TKey,TValue}"/> class. 
        /// Initializes a new instance of the <see cref="Subdictionary{TKey,TValue}"/> class that is empty, has the default initial capacity, and uses the default equality comparer for the key type.</summary>
        public Subdictionary()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Subdictionary{TKey,TValue}"/> class. Initializes a new instance of the <see cref="Subdictionary{TKey,TValue}"/> class that is empty, has the specified initial capacity, and uses the default equality comparer for the key type.</summary>
        /// <param name="capacity">The initial number of elements that the <see cref="Subdictionary{TKey,TValue}"/> can contain.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="capacity"/> is less than 0.</exception>
        public Subdictionary(int capacity)
            : base(capacity)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Subdictionary{TKey,TValue}"/> class. Initializes a new instance of the <see cref="Subdictionary{TKey,TValue}"/> class that is empty, has the specified initial capacity, and uses the specified <see cref="IEqualityComparer{T}"/>.</summary>
        /// <param name="capacity">The initial number of elements that the <see cref="Subdictionary{TKey,TValue}"/> can contain.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{T}"/> implementation to use when comparing keys, or null to use the default <see cref="EqualityComparer{T}"/> for the type of the key.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="capacity"/> is less than 0.</exception>
        public Subdictionary(int capacity, IEqualityComparer<TKey> comparer)
            : base(capacity, comparer)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Subdictionary{TKey,TValue}"/> class. Initializes a new instance of the <see cref="Subdictionary{TKey,TValue}"/> class that is empty, has the default initial capacity, and uses the specified <see cref="IEqualityComparer{T}"/>.</summary>
        /// <param name="comparer">The <see cref="IEqualityComparer{T}"/> implementation to use when comparing keys, or null to use the default <see cref="EqualityComparer{T}"/> for the type of the key.</param>
        public Subdictionary(IEqualityComparer<TKey> comparer)
            : base(comparer)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Subdictionary{TKey,TValue}"/> class. Initializes a new instance of the <see cref="Subdictionary{TKey,TValue}"/> class that contains elements copied from the specified <see cref="IDictionary{TKey, TValue}"/> and uses the default equality comparer for the key type.</summary>
        /// <param name="dictionary">The <see cref="IDictionary{TKey, TValue}"/> whose elements are copied to the new <see cref="Subdictionary{TKey,TValue}"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="dictionary"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="dictionary"/> contains one or more duplicate keys.</exception>
        public Subdictionary(IDictionary<TKey, TValue> dictionary)
            : base(dictionary)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Subdictionary{TKey,TValue}"/> class. Initializes a new instance of the <see cref="Subdictionary{TKey,TValue}"/> class that contains elements copied from the specified <see cref="IDictionary{TKey, TValue}"/> and uses the specified <see cref="IEqualityComparer{T}"/>.</summary>
        /// <param name="dictionary">The <see cref="IDictionary{TKey, TValue}"/> whose elements are copied to the new <see cref="Subdictionary{TKey,TValue}"/>.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{T}"/> implementation to use when comparing keys, or null to use the default <see cref="EqualityComparer{T}"/> for the type of the key.</param>
        /// <exception cref="ArgumentNullException"><paramref name="dictionary"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="dictionary"/> contains one or more duplicate keys.</exception>
        public Subdictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
            : base(dictionary, comparer)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Subdictionary{TKey,TValue}"/> class. Initializes a new instance of the <see cref="Subdictionary{TKey,TValue}"/> class with serialized data.</summary>
        /// <param name="info">A <see cref="SerializationInfo"/> object containing the information required to serialize the <see cref="Subdictionary{TKey,TValue}"/>.</param>
        /// <param name="context">A <see cref="StreamingContext"/> structure containing the source and destination of the serialized stream associated with the <see cref="Subdictionary{TKey,TValue}"/>.</param>
        private Subdictionary(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>Gets or sets the number of values in this subset.</summary>
        public int PageCount { get; set; }

        /// <summary>Gets or sets the number of values in the collection.</summary>
        public int TotalCount { get; set; }
    }
}