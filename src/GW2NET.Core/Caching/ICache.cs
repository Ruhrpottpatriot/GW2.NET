// <copyright file="ICache.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Caching
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Common;

    public interface ICache<TData, TKey> : ILookup<TKey, CacheItem<TData, TKey>>
        where TData : IKey<TKey>, ILocalizable
        where TKey : IEquatable<TKey>
    {
        /// <summary>Gets or sets the time until items become stale.</summary>
        TimeSpan TimeUntilStale { get; set; }

        /// <summary>Adds a single item to the cache.</summary>
        /// <param name="data">The data to add.</param>
        /// <param name="inputTime">The time the item were added to the cache.</param>
        void Put(TData data, DateTimeOffset inputTime);

        /// <summary>Returns all non-stale items.</summary>
        /// <param name="selector">An optional selector filtering the data.</param>
        /// <returns>The filtered data.</returns>
        IEnumerable<CacheItem<TData, TKey>> Get(Func<TData, bool> selector = null);

        CacheItem<TData, TKey> GetByKey(TKey key, CultureInfo culture);

        /// <summary>Removes all stale items from the cache</summary>
        void Prune();

        /// <summary>Resets the cache.</summary>
        void Empty();
    }

}