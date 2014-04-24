// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemServiceCache.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides an implementation of the items service, backed up by a caching provider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Items
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Caching;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Extensions;
    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Common;
    using GW2DotNET.V1.Common.Caching;

    /// <summary>Provides an implementation of the items service, backed up by a caching provider.</summary>
    public class ItemServiceCache : ServiceObjectCache, IItemServiceCache
    {
        /// <summary>Infrastructure. Holds a reference to the default in-memory cache.</summary>
        private static readonly Lazy<ItemServiceCache> DefaultServiceCache = new Lazy<ItemServiceCache>();

        /// <summary>Infrastructure. Holds a reference to the fallback service.</summary>
        private readonly IItemService fallbackService;

        /// <summary>Initializes a new instance of the <see cref="ItemServiceCache"/> class.</summary>
        public ItemServiceCache()
            : this(new ItemService())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ItemServiceCache"/> class.</summary>
        /// <param name="objectCache">The object cache.</param>
        public ItemServiceCache(ObjectCache objectCache)
            : this(objectCache, new ItemService())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ItemServiceCache"/> class.</summary>
        /// <param name="fallbackService">The fallback service.</param>
        public ItemServiceCache(IItemService fallbackService)
            : this(new MemoryCache(Services.Items), fallbackService)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ItemServiceCache"/> class.</summary>
        /// <param name="objectCache">The object cache.</param>
        /// <param name="fallbackService">The fallback service.</param>
        public ItemServiceCache(ObjectCache objectCache, IItemService fallbackService)
            : base(objectCache)
        {
            Preconditions.EnsureNotNull(paramName: "fallbackService", value: fallbackService);
            this.fallbackService = fallbackService;
        }

        /// <summary>Gets the default implementation of the service, backed up by an in-memory cache.</summary>
        public static ItemServiceCache Default
        {
            get
            {
                return DefaultServiceCache.Value;
            }
        }

        /// <summary>Gets a collection of item identifiers.</summary>
        /// <returns>A collection of item identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/items">wiki</a> for more information.</remarks>
        public IEnumerable<int> GetItems()
        {
            return this.GetItems(true);
        }

        /// <summary>Gets a collection of item identifiers.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of item identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/items">wiki</a> for more information.</remarks>
        public IEnumerable<int> GetItems(bool allowCache)
        {
            if (!allowCache)
            {
                return this.fallbackService.GetItems();
            }

            var items = this.Get<IEnumerable<int>>(GetKey());

            if (items == null)
            {
                this.SetItems(items = this.fallbackService.GetItems());
            }

            return items;
        }

        /// <summary>Gets a collection of item identifiers.</summary>
        /// <returns>A collection of item identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/items">wiki</a> for more information.</remarks>
        public Task<IEnumerable<int>> GetItemsAsync()
        {
            return this.GetItemsAsync(CancellationToken.None, true);
        }

        /// <summary>Gets a collection of item identifiers.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of item identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/items">wiki</a> for more information.</remarks>
        public Task<IEnumerable<int>> GetItemsAsync(CancellationToken cancellationToken)
        {
            return this.GetItemsAsync(cancellationToken, true);
        }

        /// <summary>Gets a collection of item identifiers.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of item identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/items">wiki</a> for more information.</remarks>
        public Task<IEnumerable<int>> GetItemsAsync(bool allowCache)
        {
            return this.GetItemsAsync(CancellationToken.None, allowCache);
        }

        /// <summary>Gets a collection of item identifiers.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of item identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/items">wiki</a> for more information.</remarks>
        public Task<IEnumerable<int>> GetItemsAsync(CancellationToken cancellationToken, bool allowCache)
        {
            if (!allowCache)
            {
                return this.fallbackService.GetItemsAsync(cancellationToken);
            }

            var items = this.Get<IEnumerable<int>>(GetKey());

            if (items != null)
            {
                return Task.Factory.FromResult(items);
            }

            var t1 = this.fallbackService.GetItemsAsync(cancellationToken).ContinueWith(
                task =>
                    {
                        this.SetItems(items = task.Result);
                        return items;
                    }, 
                cancellationToken);

            return t1;
        }

        /// <summary>Sets a collection of item identifiers.</summary>
        /// <param name="items">A collection of item identifiers.</param>
        public void SetItems(IEnumerable<int> items)
        {
            var absoluteExpiration = DateTimeOffset.Now.AddHours(1D);
            this.SetItems(items, new CacheItemParameters { AbsoluteExpiration = absoluteExpiration });
        }

        /// <summary>Sets a collection of item identifiers.</summary>
        /// <param name="items">A collection of item identifiers.</param>
        /// <param name="parameters">The eviction and expiration details.</param>
        public void SetItems(IEnumerable<int> items, CacheItemParameters parameters)
        {
            this.Set(GetKey(), items, parameters);
        }

        /// <summary>Infrastructure. Gets the cache item key.</summary>
        /// <returns>The key.</returns>
        private static string GetKey()
        {
            return "items";
        }
    }
}