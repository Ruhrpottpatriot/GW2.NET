// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BulkResultDictionary.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a collection of keys and values.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V2.Common
{
    using System.Collections.Generic;

    /// <summary>Represents a collection of keys and values.</summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    public class BulkResultDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        /// <summary>Initializes a new instance of the <see cref="BulkResultDictionary{TKey,TValue}"/> class that is empty, has the default initial capacity, and uses the default equality comparer for the key type.</summary>
        public BulkResultDictionary()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="BulkResultDictionary{TKey,TValue}"/> class that contains elements copied from the specified <see cref="IDictionary{TKey, TValue}"/> and uses the default equality comparer for the key type.</summary>
        /// <param name="dictionary">The <see cref="IDictionary{TKey, TValue}"/> whose elements are copied to the new <see cref="BulkResultDictionary{TKey, TValue}"/>.</param>
        public BulkResultDictionary(IDictionary<TKey, TValue> dictionary)
            : base(dictionary)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="BulkResultDictionary{TKey,TValue}"/> class that is empty, has the specified initial capacity, and uses the default equality comparer for the key type.</summary>
        /// <param name="capacity">The initial number of elements that the <see cref="BulkResultDictionary{TKey,TValue}"/> can contain.</param>
        public BulkResultDictionary(int capacity)
            : base(capacity)
        {
            this.ResultCount = capacity;
        }

        /// <summary>Gets or sets the number of retrieved results.</summary>
        public int ResultCount { get; set; }

        /// <summary>Gets or sets the total number of results.</summary>
        public int ResultTotal { get; set; }
    }
}