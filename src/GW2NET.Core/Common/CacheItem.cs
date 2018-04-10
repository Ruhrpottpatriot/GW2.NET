// <copyright file="CacheItem.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Common
{
    using System;
    using System.Globalization;

    /// <summary>Represents an items stored inside an <see cref="ICache{TData, TKey}"/>.</summary>
    /// <typeparam name="T">The type of data that is stored.</typeparam>
    /// <typeparam name="TKey">The key type.</typeparam>
    public class CacheItem<T, TKey> : ILocalizable, IEquatable<CacheItem<T, TKey>>
        where T : IKey<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>Initializes a new instance of the <see cref="CacheItem{T,TKey}"/> class.</summary>
        /// <param name="added">The time the item was added to the cache.</param>
        /// <param name="data">The item itself.</param>
        /// <param name="culture">The items culture.</param>
        public CacheItem(T data, DateTimeOffset added, CultureInfo culture)
        {
            this.Added = added;
            this.Culture = culture;
            this.Data = data;
        }

        /// <summary>Gets the time the item was added to the cache.</summary>
        public DateTimeOffset Added { get; }

        /// <summary>Gets the item data.</summary>
        public T Data { get; }

        /// <inheritdoc />
        public CultureInfo Culture { get; }

        public static implicit operator T(CacheItem<T, TKey> obj)
        {
            return obj.Data;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = this.Added.GetHashCode();
                hashCode = (hashCode * 397) ^ (this.Data != null ? this.Data.Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Culture != null ? this.Culture.GetHashCode() : 0);
                return hashCode;
            }
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj is CacheItem<T, TKey> cacheItem && this.Equals(cacheItem);
        }

        /// <inheritdoc />
        public bool Equals(CacheItem<T, TKey> other)
        {
            return this.Added.Equals(other.Added) && Equals(this.Culture, other.Culture) && this.Data.Id.Equals(other.Data.Id);
        }
    }
}