// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemDetailsServiceCache.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides an implementation of the item details service, backed up by a caching provider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details
{
    using System;
    using System.Globalization;
    using System.Runtime.Caching;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Extensions;
    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Common;
    using GW2DotNET.V1.Common.Caching;
    using GW2DotNET.V1.Items.Details.Contracts;

    /// <summary>Provides an implementation of the item details service, backed up by a caching provider.</summary>
    public class ItemDetailsServiceCache : ServiceObjectCache, IItemDetailsServiceCache
    {
        /// <summary>Infrastructure. Holds a reference to the default in-memory cache.</summary>
        private static readonly Lazy<ItemDetailsServiceCache> DefaultServiceCache = new Lazy<ItemDetailsServiceCache>();

        /// <summary>Infrastructure. Holds a reference to the fallback service.</summary>
        private readonly IItemDetailsService fallbackService;

        /// <summary>Initializes a new instance of the <see cref="ItemDetailsServiceCache" /> class.</summary>
        public ItemDetailsServiceCache()
            : this(new ItemDetailsService())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ItemDetailsServiceCache"/> class.</summary>
        /// <param name="objectCache">The object cache.</param>
        public ItemDetailsServiceCache(ObjectCache objectCache)
            : this(objectCache, new ItemDetailsService())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ItemDetailsServiceCache"/> class.</summary>
        /// <param name="fallbackService">The fallback service.</param>
        public ItemDetailsServiceCache(IItemDetailsService fallbackService)
            : this(new MemoryCache(Services.Items), fallbackService)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ItemDetailsServiceCache"/> class.</summary>
        /// <param name="objectCache">The object cache.</param>
        /// <param name="fallbackService">The fallback service.</param>
        public ItemDetailsServiceCache(ObjectCache objectCache, IItemDetailsService fallbackService)
            : base(objectCache)
        {
            Preconditions.EnsureNotNull(paramName: "fallbackService", value: fallbackService);
            this.fallbackService = fallbackService;
        }

        /// <summary>Gets the default implementation of the service, backed up by an in-memory cache.</summary>
        public static ItemDetailsServiceCache Default
        {
            get
            {
                return DefaultServiceCache.Value;
            }
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="itemId">The item identifier.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Item GetItemDetails(int itemId)
        {
            return this.GetItemDetails(itemId, ServiceBase.DefaultLanguage, true);
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="itemId">The item identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Item GetItemDetails(int itemId, CultureInfo language)
        {
            return this.GetItemDetails(itemId, language, true);
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="itemId">The item identifier.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Item GetItemDetails(int itemId, bool allowCache)
        {
            return this.GetItemDetails(itemId, ServiceBase.DefaultLanguage, allowCache);
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="itemId">The item identifier.</param>
        /// <param name="language">The language.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Item GetItemDetails(int itemId, CultureInfo language, bool allowCache)
        {
            if (!allowCache)
            {
                return this.fallbackService.GetItemDetails(itemId, language);
            }

            var item = this.Get<Item>(GetKey(itemId, language));

            if (item == null)
            {
                this.SetItemDetails(item = this.fallbackService.GetItemDetails(itemId, language), language);
            }

            return item;
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="itemId">The item identifier.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Task<Item> GetItemDetailsAsync(int itemId)
        {
            return this.GetItemDetailsAsync(itemId, ServiceBase.DefaultLanguage, CancellationToken.None, true);
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="itemId">The item identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Task<Item> GetItemDetailsAsync(int itemId, CultureInfo language)
        {
            return this.GetItemDetailsAsync(itemId, language, CancellationToken.None, true);
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="itemId">The item identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Task<Item> GetItemDetailsAsync(int itemId, CancellationToken cancellationToken)
        {
            return this.GetItemDetailsAsync(itemId, ServiceBase.DefaultLanguage, cancellationToken, true);
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="itemId">The item identifier.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Task<Item> GetItemDetailsAsync(int itemId, CultureInfo language, CancellationToken cancellationToken)
        {
            return this.GetItemDetailsAsync(itemId, language, cancellationToken, true);
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="itemId">The item identifier.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Task<Item> GetItemDetailsAsync(int itemId, bool allowCache)
        {
            return this.GetItemDetailsAsync(itemId, ServiceBase.DefaultLanguage, CancellationToken.None, allowCache);
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="itemId">The item identifier.</param>
        /// <param name="language">The language.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Task<Item> GetItemDetailsAsync(int itemId, CultureInfo language, bool allowCache)
        {
            return this.GetItemDetailsAsync(itemId, language, CancellationToken.None, allowCache);
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="itemId">The item identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Task<Item> GetItemDetailsAsync(int itemId, CancellationToken cancellationToken, bool allowCache)
        {
            return this.GetItemDetailsAsync(itemId, ServiceBase.DefaultLanguage, cancellationToken, allowCache);
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="itemId">The item identifier.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Task<Item> GetItemDetailsAsync(int itemId, CultureInfo language, CancellationToken cancellationToken, bool allowCache)
        {
            if (!allowCache)
            {
                return this.fallbackService.GetItemDetailsAsync(itemId, language, cancellationToken);
            }

            var item = this.Get<Item>(GetKey(itemId, language));

            if (item != null)
            {
                return Task.Factory.FromResult(item);
            }

            var t1 = this.fallbackService.GetItemDetailsAsync(itemId, language, cancellationToken).ContinueWith(
                task =>
                    {
                        this.SetItemDetails(item = task.Result, language);
                        return item;
                    }, 
                cancellationToken);

            return t1;
        }

        /// <summary>Sets an item and its localized details.</summary>
        /// <param name="item">An item and its localized details.</param>
        /// <param name="language">The language.</param>
        public void SetItemDetails(Item item, CultureInfo language)
        {
            var absoluteExpiration = DateTimeOffset.Now.AddDays(1D);
            this.SetItemDetails(item, language, new CacheItemParameters { AbsoluteExpiration = absoluteExpiration });
        }

        /// <summary>Sets an item and its localized details.</summary>
        /// <param name="item">An item and its localized details.</param>
        /// <param name="language">The language.</param>
        /// <param name="parameters">The eviction and expiration details.</param>
        public void SetItemDetails(Item item, CultureInfo language, CacheItemParameters parameters)
        {
            this.Set(GetKey(item.ItemId, language), item, parameters);
        }

        /// <summary>Infrastructure. Gets the cache item key.</summary>
        /// <param name="itemId">The item identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>The key.</returns>
        private static string GetKey(int itemId, CultureInfo language)
        {
            return string.Format("{0}|{1}|{2}", "item_details", language.TwoLetterISOLanguageName, itemId.ToStringInvariant());
        }
    }
}