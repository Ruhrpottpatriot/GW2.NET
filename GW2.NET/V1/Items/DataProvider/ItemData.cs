// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemData.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ItemData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Threading.Tasks;
using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.Items.Models.Items;

namespace GW2DotNET.V1.Items.DataProvider
{
    using System.IO;

    /// <summary>
    /// The item data provider.
    /// </summary>
    public class ItemData : IEnumerable<Item>
    {
        /// <summary>The api manager.</summary>
        private readonly ApiManager apiManager;

        /// <summary>
        /// The name of the file on disk where we will cache the item data.
        /// </summary>
        private readonly string itemIdCacheFileName;

        private readonly string itemCacheFileName;

        /// <summary>
        /// The item id cache.
        /// </summary>
        private Lazy<IEnumerable<int>> itemIdCache;

        /// <summary>
        /// The items cache.
        /// </summary>
        private Lazy<IEnumerable<Item>> itemsCache;

        /// <summary>Initializes a new instance of the <see cref="ItemData"/> class.</summary>
        /// <param name="apiManager">The api Manager.</param>
        internal ItemData(ApiManager apiManager) :
            this(string.Format("{0}\\GW2.NET", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)), 
            apiManager)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ItemData"/> class.</summary>
        /// <param name="savePath">The path to the file (without file name and trailing slash).</param>
        /// <param name="apiManager">The api Manager.</param>
        internal ItemData(string savePath, ApiManager apiManager)
        {
            this.apiManager = apiManager;

            this.itemIdCacheFileName = string.Format("{0}\\ItemIdCache{1}.binary", savePath, apiManager.Language);

            this.itemCacheFileName = string.Format("{0}\\ItemCache{1}.binary", savePath, apiManager.Language);

            this.itemIdCache = new Lazy<IEnumerable<int>>(InitializeItemIdCache);

            this.itemsCache = new Lazy<IEnumerable<Item>>(InitializeItemCache);
        }

        private IEnumerable<int> InitializeItemIdCache()
        {
            if (File.Exists(this.itemIdCacheFileName))
            {
                ItemIdCacheData diskData;

                using (var fileStream = new FileStream(this.itemIdCacheFileName, FileMode.Open))
                {
                    var binarySerializer = new BinaryFormatter();

                    diskData = (ItemIdCacheData)binarySerializer.Deserialize(fileStream);
                }

                if (diskData.Build >= apiManager.Build)
                    return diskData.ItemIds;
            }

            // Cache was stale or not found
            var itemIdData = ApiCall.GetContent<Dictionary<string, List<int>>>("items.json", null, ApiCall.Categories.Items)
                       .Values.First();

            var dataToSave = new ItemIdCacheData()
                {
                    Build = apiManager.Build,
                    ItemIds = itemIdData
                };

            this.SaveCacheFile(this.itemIdCacheFileName, dataToSave);

            return itemIdData;
        }

        private IEnumerable<Item> InitializeItemCache()
        {
            if (File.Exists(this.itemCacheFileName))
            {
                ItemCacheData diskData;

                using (var fileStream = new FileStream(this.itemCacheFileName, FileMode.Open))
                {
                    var binarySerializer = new BinaryFormatter();

                    diskData = (ItemCacheData)binarySerializer.Deserialize(fileStream);
                }

                if (diskData.Build >= apiManager.Build)
                    return diskData.Items;
            }

            // Cache was stale or not found
            var itemData = this.itemIdCache.Value
                .Select(itemId =>
                    new List<KeyValuePair<string, object>>
                        {
                            new KeyValuePair<string, object>("item_id", itemId),
                            new KeyValuePair<string, object>("lang", this.apiManager.Language)
                        })
                                  .Select(
                                      arguments =>
                                      ApiCall.GetContent<Item>("item_details.json", arguments,
                                                               ApiCall.Categories.Items)).ToList();

            var dataToSave = new ItemCacheData()
                {
                    Build = apiManager.Build,
                    Items = itemData
                };

            this.SaveCacheFile(this.itemCacheFileName, dataToSave);

            return itemData;
        }

        /// <summary>
        /// Gets an IEnumerable of all item descriptions, populating
        /// the cache first if necessary. This is private. Callers
        /// get access to this list by enumerating the ItemData
        /// object.
        /// </summary>
        private IEnumerable<Item> AllItems
        {
            get
            {
                return this.itemsCache.Value;
            }
        }

        /// <summary>
        /// Gets all items asynchronously.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IEnumerable<Item>> GetAllItemsAsync(CancellationToken cancellationToken)
        {
            Func<IEnumerable<Item>> methodCall = () => this.AllItems;

            return Task.Factory.StartNew(methodCall);
        }

        /// <summary>
        /// Gets a single item from the cache.
        /// </summary>
        /// <param name="itemId">The item id.</param>
        /// <returns>The <see cref="Item"/>.</returns>
        public Item this[int itemId]
        {
            get
            {
                return this.AllItems.Single(item => item.Id == itemId);
            }
        }

        /// <summary>
        /// Gets one item from ID asynchronously.
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Item> GetItemFromIdAsync(int itemId, CancellationToken cancellationToken)
        {
            Func<Item> methodCall = () => this[itemId];

            return Task.Factory.StartNew(methodCall);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.</returns>
        public IEnumerator<Item> GetEnumerator()
        {
            return this.AllItems.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.AllItems.GetEnumerator();
        }

        /// <summary>
        /// Saves the contents of the cache to the file system.
        /// </summary>
        private void SaveCacheFile(string cacheFileName, CacheDataBase dataToSave)
        {
            string directoryPath = Path.GetDirectoryName(cacheFileName);

            // Make sure the directory exists first
            if (!string.IsNullOrEmpty(directoryPath) && !Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            else if (string.IsNullOrEmpty(directoryPath))
            {
                throw new NoNullAllowedException("The path to the directory must not be null or an empty string!");
            }

            // Serialize the data and write the file
            using (var fileStream = new FileStream(cacheFileName, FileMode.Create))
            {
                var binarySerializer = new BinaryFormatter();

                binarySerializer.Serialize(fileStream, dataToSave);
            }
        }
    }
}