// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonDictionary.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for strongly typed JSON dictionaries.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Common.Contracts
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>Provides the base class for strongly typed JSON dictionaries.</summary>
    /// <typeparam name="TKey">The type of the keys.</typeparam>
    /// <typeparam name="TValue">The type of the values.</typeparam>
    [Serializable]
    public abstract class JsonDictionary<TKey, TValue> : ServiceContract, IDictionary<TKey, TValue>
        where TValue : ServiceContract
    {
        /// <summary>Infrastructure. This class acts as a proxy for the dictionary stored in this field.</summary>
        private readonly IDictionary<TKey, TValue> innerDictionary;

        /// <summary>Initializes a new instance of the <see cref="JsonDictionary{TKey,TValue}" /> class.</summary>
        protected JsonDictionary()
        {
            this.innerDictionary = new Dictionary<TKey, TValue>();
        }

        /// <summary>Initializes a new instance of the <see cref="JsonDictionary{TKey,TValue}"/> class.</summary>
        /// <param name="capacity">The initial number of elements that the new dictionary can contain.</param>
        protected JsonDictionary(int capacity)
        {
            this.innerDictionary = new Dictionary<TKey, TValue>(capacity);
        }

        /// <summary>Initializes a new instance of the <see cref="JsonDictionary{TKey,TValue}"/> class.</summary>
        /// <param name="dictionary">The dictionary whose values are copied to the new dictionary.</param>
        protected JsonDictionary(IDictionary<TKey, TValue> dictionary)
        {
            this.innerDictionary = new Dictionary<TKey, TValue>(dictionary);
        }

        /// <summary>Gets the number of elements contained in the <see cref="System.Collections.Generic.ICollection{T}" />.</summary>
        public int Count
        {
            get
            {
                return this.innerDictionary.Count;
            }
        }

        /// <summary>Gets a value indicating whether the <see cref="System.Collections.Generic.ICollection{T}" /> is read-only.</summary>
        public bool IsReadOnly
        {
            get
            {
                return this.innerDictionary.IsReadOnly;
            }
        }

        /// <summary>Gets an <see cref="System.Collections.Generic.ICollection{T}" /> containing the keys of the
        /// <see cref="JsonDictionary{TKey, TValue}" />.</summary>
        public ICollection<TKey> Keys
        {
            get
            {
                return this.innerDictionary.Keys;
            }
        }

        /// <summary>Gets an <see cref="System.Collections.Generic.ICollection{T}" /> containing the values in the
        /// <see cref="JsonDictionary{TKey, TValue}" />.</summary>
        public ICollection<TValue> Values
        {
            get
            {
                return this.innerDictionary.Values;
            }
        }

        /// <summary>Gets or sets the element with the specified key.</summary>
        /// <param name="key">The key of the element to get or set.</param>
        /// <returns>The element with the specified key.</returns>
        public TValue this[TKey key]
        {
            get
            {
                return this.innerDictionary[key];
            }

            set
            {
                this.innerDictionary[key] = value;
            }
        }

        /// <summary>Adds an element with the provided key and value to the <see cref="JsonDictionary{TKey, TValue}"/>.</summary>
        /// <param name="key">The text to use as the key of the element to add.</param>
        /// <param name="value">The object to use as the value of the element to add.</param>
        public void Add(TKey key, TValue value)
        {
            this.innerDictionary.Add(key, value);
        }

        /// <summary>Adds an item to the <see cref="System.Collections.Generic.ICollection{T}"/>.</summary>
        /// <param name="item">The object to add to the <see cref="System.Collections.Generic.ICollection{T}"/>.</param>
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            this.innerDictionary.Add(item);
        }

        /// <summary>Removes all items from the <see cref="System.Collections.Generic.ICollection{T}" />.</summary>
        public void Clear()
        {
            this.innerDictionary.Clear();
        }

        /// <summary>Determines whether the <see cref="System.Collections.Generic.ICollection{T}"/> contains a specific value.</summary>
        /// <param name="item">The object to locate in the <see cref="System.Collections.Generic.ICollection{T}"/>.</param>
        /// <returns>true if item is found in the <see cref="System.Collections.Generic.ICollection{T}"/>; otherwise, false.</returns>
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return this.innerDictionary.Contains(item);
        }

        /// <summary>Determines whether the <see cref="JsonDictionary{TKey, TValue}"/> contains an element with the specified key.</summary>
        /// <param name="key">The key to locate in the <see cref="JsonDictionary{TKey, TValue}"/>.</param>
        /// <returns>true if the <see cref="JsonDictionary{TKey, TValue}"/> contains an element with the key; otherwise, false.</returns>
        public bool ContainsKey(TKey key)
        {
            return this.innerDictionary.ContainsKey(key);
        }

        /// <summary>Copies the elements of the <see cref="System.Collections.Generic.ICollection{T}"/> to an<see cref="System.Array"/>, starting at a particular <see cref="System.Array"/> index.</summary>
        /// <param name="array">The one-dimensional <see cref="System.Array"/> that is the destination of the elements copied from<see cref="System.Collections.Generic.ICollection{T}"/>. The <see cref="System.Array"/> must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            this.innerDictionary.CopyTo(array, arrayIndex);
        }

        /// <summary>Returns an enumerator that iterates through the collection.</summary>
        /// <returns>A <see cref="System.Collections.Generic.IEnumerator{T}" /> that can be used to iterate through the collection.</returns>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return this.innerDictionary.GetEnumerator();
        }

        /// <summary>Removes the element with the specified key from the <see cref="JsonDictionary{TKey, TValue}"/>.</summary>
        /// <param name="key">The key of the element to remove.</param>
        /// <returns>true if the element is successfully removed; otherwise, false. This method also returns false if key was not found in the <see cref="JsonDictionary{TKey, TValue}"/>.</returns>
        public bool Remove(TKey key)
        {
            return this.innerDictionary.Remove(key);
        }

        /// <summary>Removes the first occurrence of a specific object from the <see cref="System.Collections.Generic.ICollection{T}"/>
        /// .</summary>
        /// <param name="item">The object to remove from the <see cref="System.Collections.Generic.ICollection{T}"/>.</param>
        /// <returns>true if item was successfully removed from the <see cref="System.Collections.Generic.ICollection{T}"/>; otherwise, false. This method also returns false if item is not found in the original<see cref="System.Collections.Generic.ICollection{T}"/>.</returns>
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return this.innerDictionary.Remove(item);
        }

        /// <summary>Gets the value associated with the specified key.</summary>
        /// <param name="key">The key whose value to get.</param>
        /// <param name="value">When this method returns, the value associated with the specified key, if the key is found; otherwise, the default value for the type of the value parameter. This parameter is passed uninitialized.</param>
        /// <returns>true if the <see cref="JsonDictionary{TKey, TValue}"/> contains an element with the specified key; otherwise, false.</returns>
        public bool TryGetValue(TKey key, out TValue value)
        {
            return this.innerDictionary.TryGetValue(key, out value);
        }

        /// <summary>Returns an enumerator that iterates through the collection.</summary>
        /// <returns>A <see cref="System.Collections.Generic.IEnumerator{T}" /> that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.innerDictionary.GetEnumerator();
        }
    }
}