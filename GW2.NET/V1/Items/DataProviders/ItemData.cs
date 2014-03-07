// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemData.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ItemData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GW2DotNET.V1.Core.ItemsInformation.Details;
using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.RestSharp;

namespace GW2DotNET.V1.Items.DataProviders
{
    /// <summary>The item data provider.</summary>
    public class ItemData : DataProviderBase
    {
        // --------------------------------------------------------------------------------------------------------------------
        // Fields
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>The api manager.</summary>
        private readonly IDataManager dataManager;

        /// <summary>The item id cache file name.</summary>
        private readonly string itemIdListCacheFileName;

        /// <summary>The item cache file name.</summary>
        private readonly string itemListCacheFileName;

        /// <summary>The item id cache.</summary>
        private Lazy<List<int>> itemIdCache;

        /// <summary>The items cache.</summary>
        private Lazy<List<Item>> itemListCache;

        // --------------------------------------------------------------------------------------------------------------------
        // Constructors & Destructors
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Initializes a new instance of the <see cref="ItemData"/> class.</summary>
        /// <param name="dataManager">The data manager.</param>
        public ItemData(IDataManager dataManager)
            : this(dataManager, false)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ItemData"/> class.</summary>
        /// <param name="dataManager">The data manager.</param>
        /// <param name="bypassCaching">A value indicating whether to bypass caching.</param>
        public ItemData(IDataManager dataManager, bool bypassCaching)
        {
            this.dataManager = dataManager;
            this.BypassCache = bypassCaching;

            this.itemListCacheFileName = string.Format("{0}\\ItemListCache{1}.json", this.dataManager.SavePath, this.dataManager.Language);
            this.itemIdListCacheFileName = string.Format("{0}\\ItemIdListCache{1}.json", dataManager.SavePath, dataManager.Language);

            int itemIdBuild;
            int itemListBuild;

            this.itemIdCache = !this.BypassCache ? new Lazy<List<int>>(() => this.ReadCacheFromDisk<List<int>>(this.itemIdListCacheFileName, out itemIdBuild)) : new Lazy<List<int>>();
            this.itemListCache = !this.BypassCache ? new Lazy<List<Item>>(() => this.ReadCacheFromDisk<List<Item>>(this.itemListCacheFileName, out itemListBuild)) : new Lazy<List<Item>>();
        }

        // --------------------------------------------------------------------------------------------------------------------
        // Properties
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Gets the item list.</summary>
        public IEnumerable<Item> ItemList
        {
            get
            {
                return this.itemListCache.Value;
            }
        }

        /// <summary>Gets the item id list.</summary>
        public IEnumerable<int> ItemIdList
        {
            get
            {
                return this.itemIdCache.Value;
            }
        }

        // --------------------------------------------------------------------------------------------------------------------
        // Public Methods
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Asynchronously gets the item id list.</summary>
        /// <returns>An <see cref="IEnumerable{T}" /> containing all item ids.</returns>
        public async Task<IEnumerable<int>> GetItemIdListAsync()
        {
            var serviceClient = ServiceClient.Create();
            var request       = new ItemsRequest();
            var response      = await request.GetResponseAsync(serviceClient).ConfigureAwait(false);
            var items         = response.EnsureSuccessStatusCode().Deserialize().Items;

            if (!this.BypassCache)
            {
                this.itemIdCache.Value.AddRange(items);
            }

            return items;
        }

        /// <summary>Synchronously gets the item id list.</summary>
        /// <returns>An <see cref="IEnumerable{T}" /> containing all item ids.</returns>
        public IEnumerable<int> GetItemIdList()
        {
            var serviceClient = ServiceClient.Create();
            var request       = new ItemsRequest();
            var response      = request.GetResponse(serviceClient);
            var items         = response.EnsureSuccessStatusCode().Deserialize().Items;

            if (!this.BypassCache)
            {
                this.itemIdCache.Value.AddRange(items);
            }

            return items;
        }

        /// <summary>Asynchronously gets the details of an item with the specified id.</summary>
        /// <param name="itemId">The id of the item to get the details for.</param>
        /// <returns>An <see cref="Item"/> with all its details.</returns>
        public async Task<Item> GetItemDetailAsync(int itemId)
        {
            // Check if the item is in the cache
            if (!this.BypassCache)
            {
                Item item = this.itemListCache.Value.Find(itm => itm.ItemId == itemId);

                if (item != null)
                {
                    return item;
                }
            }

            var serviceClient = ServiceClient.Create();
            var request       = new ItemDetailsRequest(itemId); // TODO: CultureInfo parameter
            var response      = await request.GetResponseAsync(serviceClient).ConfigureAwait(false);
            var itemDetails   = response.EnsureSuccessStatusCode().Deserialize();

            if (!this.BypassCache)
            {
                this.itemListCache.Value.Add(itemDetails);
            }

            return itemDetails;
        }

        /// <summary>Synchronously gets the details of an item with the specified id.</summary>
        /// <param name="itemId">The id of the item to get the details for.</param>
        /// <returns>An <see cref="Item"/> with all its details.</returns>
        public Item GetItemDetail(int itemId)
        {
            // Check if the item is in the cache
            if (!this.BypassCache)
            {
                Item item = this.itemListCache.Value.Find(itm => itm.ItemId == itemId);

                if (item != null)
                {
                    return item;
                }
            }

            var serviceClient = ServiceClient.Create();
            var request       = new ItemDetailsRequest(itemId); // TODO: CultureInfo parameter
            var response      = request.GetResponse(serviceClient);
            var itemDetails   = response.EnsureSuccessStatusCode().Deserialize();

            if (!this.BypassCache)
            {
                this.itemListCache.Value.Add(itemDetails);
            }

            return itemDetails;
        }

        /// <summary>Writes the complete cache to the disk using the specified serializer.</summary>
        public override void WriteCacheToDisk()
        {
            var itemCache = new GameCache<List<Item>>
                            {
                                Build = this.dataManager.Build,
                                CacheData = this.itemListCache.Value
                            };

            this.WriteDataToDisk(this.itemListCacheFileName, itemCache);

            var idCache = new GameCache<List<int>>
                          {
                              Build = this.dataManager.Build,
                              CacheData = this.itemIdCache.Value
                          };

            this.WriteDataToDisk(this.itemIdListCacheFileName, idCache);
        }

        /// <summary>Writes the complete cache to the disk asynchronously using the specified serializer</summary>
        /// <returns>The <see cref="System.Threading.Tasks.Task" />.</returns>
        public override async Task WriteCacheToDiskAsync()
        {
            throw new NotImplementedException("This function has not yet been implemented. Use the synchronous method instead.");
        }

        /// <summary>Clears the cache.</summary>
        public override void ClearCache()
        {
            this.itemIdCache = new Lazy<List<int>>();
            this.itemListCache = new Lazy<List<Item>>();
        }
    }
}