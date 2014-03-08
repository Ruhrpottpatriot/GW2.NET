// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonList.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;

namespace GW2DotNET.V1.Core
{
    /// <summary>
    ///     Provides the base class for strongly typed JSON lists.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    [Serializable]
    public abstract class JsonList<T> : JsonObject, IList<T>
    {
        /// <summary>Infrastructure. This class acts as a proxy for the list stored in this field.</summary>
        private readonly IList<T> innerList;

        /// <summary>
        ///     Initializes a new instance of the <see cref="JsonList{T}" /> class.
        /// </summary>
        protected JsonList()
        {
            this.innerList = new List<T>();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="JsonList{T}" /> class.
        /// </summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        protected JsonList(int capacity)
        {
            this.innerList = new List<T>(capacity);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="JsonList{T}" /> class.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        protected JsonList(IEnumerable<T> collection)
        {
            this.innerList = new List<T>(collection);
        }

        /// <summary>
        ///     Gets the number of elements contained in the <see cref="System.Collections.Generic.ICollection{T}" />.
        /// </summary>
        public virtual int Count
        {
            get { return this.innerList.Count; }
        }

        /// <summary>
        ///     Gets a value indicating whether the <see cref="System.Collections.Generic.ICollection{T}" /> is read-only.
        /// </summary>
        public virtual bool IsReadOnly
        {
            get { return this.innerList.IsReadOnly; }
        }

        /// <summary>
        ///     Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get or set.</param>
        /// <returns>The element at the specified index.</returns>
        public virtual T this[int index]
        {
            get { return this.innerList[index]; }
            set { this.innerList[index] = value; }
        }

        /// <summary>
        ///     Adds an item to the <see cref="System.Collections.Generic.ICollection{T}" />.
        /// </summary>
        /// <param name="item"> The object to add to the <see cref="System.Collections.Generic.ICollection{T}" />.</param>
        public virtual void Add(T item)
        {
            this.innerList.Add(item);
        }

        /// <summary>
        ///     Removes all items from the <see cref="System.Collections.Generic.ICollection{T}" />.
        /// </summary>
        public virtual void Clear()
        {
            this.innerList.Clear();
        }

        /// <summary>
        ///     Determines whether the <see cref="System.Collections.Generic.ICollection{T}" /> contains a specific value.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="System.Collections.Generic.ICollection{T}" />.</param>
        /// <returns>
        ///     <c>true</c> if item is found in the <see cref="System.Collections.Generic.ICollection{T}" />; otherwise,
        ///     <c>false</c>.
        /// </returns>
        public virtual bool Contains(T item)
        {
            return this.innerList.Contains(item);
        }

        /// <summary>
        ///     Copies the elements of the <see cref="System.Collections.Generic.ICollection{T}" /> to an
        ///     <see cref="System.Array" />, starting at a particular <see cref="System.Array" /> index.
        /// </summary>
        /// <param name="array">
        ///     The one-dimensional <see cref="System.Array" /> that is the destination of the elements copied from
        ///     <see cref="System.Collections.Generic.ICollection{T}" />. The <see cref="System.Array" /> must have zero-based
        ///     indexing.
        /// </param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public virtual void CopyTo(T[] array, int arrayIndex)
        {
            this.innerList.CopyTo(array, arrayIndex);
        }

        /// <summary>
        ///     Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An <see cref="System.Collections.IEnumerator" /> object that can be used to iterate through the collection.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return this.innerList.GetEnumerator();
        }

        /// <summary>
        ///     Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An <see cref="System.Collections.IEnumerator" /> object that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this.innerList).GetEnumerator();
        }

        /// <summary>
        ///     Determines the index of a specific item in the <see cref="System.Collections.Generic.IList{T}" />.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="System.Collections.Generic.IList{T}" />.</param>
        /// <returns>The index of item if found in the list; otherwise, -1.</returns>
        public virtual int IndexOf(T item)
        {
            return this.innerList.IndexOf(item);
        }

        /// <summary>
        ///     Inserts an item to the <see cref="System.Collections.Generic.IList{T}" /> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The object to insert into the <see cref="System.Collections.Generic.IList{T}" />.</param>
        public virtual void Insert(int index, T item)
        {
            this.innerList.Insert(index, item);
        }

        /// <summary>
        ///     Removes the first occurrence of a specific object from the <see cref="System.Collections.Generic.ICollection{T}" />
        ///     .
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="System.Collections.Generic.ICollection{T}" />.</param>
        /// <returns>
        ///     <c>true</c>if item was successfully removed from the <see cref="System.Collections.Generic.ICollection{T}" />;
        ///     otherwise, <c>false</c>. This method also returns <c>false</c> if item is not found in the original
        ///     <see cref="System.Collections.Generic.ICollection{T}" />.
        /// </returns>
        public virtual bool Remove(T item)
        {
            return this.innerList.Remove(item);
        }

        /// <summary>
        ///     Removes the <see cref="System.Collections.Generic.IList{T}" /> item at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the item to remove.</param>
        public virtual void RemoveAt(int index)
        {
            this.innerList.RemoveAt(index);
        }

        /// <summary>
        ///     Adds the elements of the specified collection to the end of the <see cref="JsonList{T}" />.
        /// </summary>
        /// <param name="collection">
        ///     The collection whose elements should be added to the end of the <see cref="JsonList{T}" />.
        ///     The collection itself cannot be null, but it can contain elements that are null, if type <typeparamref name="T" />
        ///     is a reference type.
        /// </param>
        /// <exception cref="System.ArgumentNullException">The collection is null.</exception>
        public virtual void AddRange(IEnumerable<T> collection)
        {
            ((List<T>)this.innerList).AddRange(collection);
        }
    }
}