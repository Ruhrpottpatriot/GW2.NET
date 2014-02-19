// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonDictionary.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace GW2DotNET.V1.Core
{
    /// <summary>
    /// Provides the base class for strongly typed JSON dictionaries.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    [Serializable]
    public abstract class JsonDictionary<TValue> : JsonObject, IDictionary<string, TValue> where TValue : JsonObject
    {
        private readonly IDictionary<string, TValue> innerDictionary;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonDictionary{TValue}"/> class.
        /// </summary>
        public JsonDictionary()
        {
            innerDictionary = new Dictionary<string, TValue>();
        }

        #region IDictionary<string,TValue> Members

        public void Add(string key, TValue value)
        {
            innerDictionary.Add(key, value);
        }

        public bool ContainsKey(string key)
        {
            return innerDictionary.ContainsKey(key);
        }

        public ICollection<string> Keys
        {
            get { return innerDictionary.Keys; }
        }

        public bool Remove(string key)
        {
            return innerDictionary.Remove(key);
        }

        public bool TryGetValue(string key, out TValue value)
        {
            return innerDictionary.TryGetValue(key, out value);
        }

        public ICollection<TValue> Values
        {
            get { return innerDictionary.Values; }
        }

        public TValue this[string key]
        {
            get { return innerDictionary[key]; }
            set { innerDictionary[key] = value; }
        }

        #endregion

        #region ICollection<KeyValuePair<string,TValue>> Members

        public void Add(KeyValuePair<string, TValue> item)
        {
            innerDictionary.Add(item);
        }

        public void Clear()
        {
            innerDictionary.Clear();
        }

        public bool Contains(KeyValuePair<string, TValue> item)
        {
            return innerDictionary.Contains(item);
        }

        public void CopyTo(KeyValuePair<string, TValue>[] array, int arrayIndex)
        {
            innerDictionary.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return innerDictionary.Count; }
        }

        public bool IsReadOnly
        {
            get { return innerDictionary.IsReadOnly; }
        }

        public bool Remove(KeyValuePair<string, TValue> item)
        {
            return innerDictionary.Remove(item);
        }

        #endregion

        #region IEnumerable<KeyValuePair<string,TValue>> Members

        public IEnumerator<KeyValuePair<string, TValue>> GetEnumerator()
        {
            return innerDictionary.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerDictionary.GetEnumerator();
        }

        #endregion
    }
}