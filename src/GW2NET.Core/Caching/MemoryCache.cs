// <copyright file="MemoryCache.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Caching
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Common;

    public sealed class MemoryCache<T, TKey> : ICache<T, TKey>
        where T : IKey<TKey>, ILocalizable
        where TKey : IEquatable<TKey>
    {
        private readonly Dictionary<TKey, List<CacheItem<T, TKey>>> itemDict;

        public MemoryCache()
        {
            this.itemDict = new Dictionary<TKey, List<CacheItem<T, TKey>>>();
        }

        /// <inheritdoc />
        public TimeSpan TimeUntilStale { get; set; }

        /// <inheritdoc />
        public int Count => this.itemDict.Count;

        /// <inheritdoc />
        public IEnumerable<CacheItem<T, TKey>> this[TKey key] => this.itemDict[key];

        /// <inheritdoc />
        public void Put(T data, DateTimeOffset inputTime)
        {
            if (this.itemDict.ContainsKey(data.Id))
            {
                List<CacheItem<T, TKey>> dataList = this.itemDict[data.Id];
                for (int i = 0; i < dataList.Count; i++)
                {
                    if (!dataList[i].Culture.Equals(data.Culture))
                    {
                        continue;
                    }

                    if (dataList[i].Added.Equals(inputTime))
                    {
                        return;
                    }

                    dataList[i] = new CacheItem<T, TKey>(data, inputTime, data.Culture);
                    return;
                }
            }

            this.itemDict.Add(data.Id, new List<CacheItem<T, TKey>>(100) { new CacheItem<T, TKey>(data, inputTime, data.Culture) });
        }

        /// <inheritdoc />
        public IEnumerable<CacheItem<T, TKey>> Get(Func<T, bool> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            return this.itemDict
                .SelectMany(l => l.Value)
                .Where(i => selector((T)i));
        }

        /// <inheritdoc />
        public CacheItem<T, TKey> GetByKey(TKey key, CultureInfo culture)
        {
            var item = this.itemDict.SingleOrDefault(i => i.Key.Equals(key));
            return item.Value.SingleOrDefault(i => i.Culture.Equals(culture));
        }

        /// <inheritdoc />
        public void Prune()
        {
            foreach (KeyValuePair<TKey, List<CacheItem<T, TKey>>> itemPair in this.itemDict)
            {
                itemPair.Value.RemoveAll(this.IsStale);
                if (itemPair.Value.Count == 0)
                {
                    this.itemDict.Remove(itemPair.Key);
                }
            }
        }

        /// <inheritdoc />
        public void Empty()
        {
            this.itemDict.Clear();
        }

        /// <inheritdoc />
        public IEnumerator<IGrouping<TKey, CacheItem<T, TKey>>> GetEnumerator()
        {
            return this.itemDict
                .SelectMany(l => l.Value)
                .Where(i => !this.IsStale(i))
                .GroupBy(k => k.Data.Id, e => e)
                .GetEnumerator();
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <inheritdoc />
        public bool Contains(TKey key)
        {
            return this.itemDict.ContainsKey(key);
        }

        private bool IsStale(CacheItem<T, TKey> item)
        {
            return item.Added + this.TimeUntilStale < DateTimeOffset.UtcNow;
        }
    }
}
