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

namespace GW2DotNET.V1.Items.DataProviders
{
    using System.IO;
    using Newtonsoft.Json;

    /// <summary>
    /// The item data provider.
    /// </summary>
    public class ItemData
    {
        // --------------------------------------------------------------------------------------------------------------------
        // Fields
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>The api manager.</summary>
        private readonly IDataManager dataManager;

        /// <summary>
        /// The item id cache.
        /// </summary>
        private readonly Lazy<List<int>> itemIdCache;

        /// <summary>
        /// The items cache.
        /// </summary>
        private readonly Lazy<List<Item>> itemListCache;

        // --------------------------------------------------------------------------------------------------------------------
        // Constructors & Destructors
        // --------------------------------------------------------------------------------------------------------------------

        public ItemData(IDataManager dataManager)
            : this(dataManager, false)
        {
        }

        public ItemData(IDataManager dataManager, bool bypassCaching)
        {
            this.itemIdCache = new Lazy<List<int>>();
            this.itemListCache = new Lazy<List<Item>>();
            this.dataManager = dataManager;
            this.BypassCache = bypassCaching;
        }

        // --------------------------------------------------------------------------------------------------------------------
        // Properties
        // --------------------------------------------------------------------------------------------------------------------

        public bool BypassCache { get; set; }

        public IEnumerable<Item> ItemList
        {
            get
            {
                return this.itemListCache.Value;
            }
        }

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

        public async Task<IEnumerable<int>> GetItemIdListAsync()
        {
            Dictionary<string, List<int>> returnContent = await ApiCall.GetContentAsync<Dictionary<string, List<int>>>("items.json", null, ApiCall.Categories.Items);

            List<int> itemIdList = returnContent.Values.First();


            if (!this.BypassCache)
            {
                this.itemIdCache.Value.AddRange(itemIdList);
            }

            return itemIdList;
        }

        public IEnumerable<int> GetItemIdList()
        {
            return this.GetItemIdListAsync().Result;
        }

        public async Task<IEnumerable<Item>> GetItemDetailListAsync()
        {
            List<Item> itemList = new List<Item>();

            foreach (int itemId in this.itemIdCache.Value)
            {
                var args = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("item_id", itemId),
                    new KeyValuePair<string, object>("lang", this.dataManager.Language)
                };

                Item item = await ApiCall.GetContentAsync<Item>("item_details.json", args, ApiCall.Categories.Items);

                itemList.Add(item);
            }

            if (!this.BypassCache)
            {
                this.itemListCache.Value.AddRange(itemList);
            }

            return itemList;
        }

        public IEnumerable<Item> GetItemDetailList()
        {
            return this.GetItemDetailListAsync().Result;
        }

        public async Task<Item> GetItemDetailAsync(int itemId)
        {
            // Check if the item is in the cache
            if (!this.BypassCache)
            {
                Item item = this.itemListCache.Value.SingleOrDefault(itm => itm.Id == itemId);

                if (item != null)
                {
                    return item;
                }
            }

            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("item_id", itemId),
                new KeyValuePair<string, object>("lang", this.dataManager.Language)
            };

            Item itemToReturn = await ApiCall.GetContentAsync<Item>("item_details.json", args, ApiCall.Categories.Items);

            if (!this.BypassCache)
            {
                this.itemListCache.Value.Add(itemToReturn);
            }

            return itemToReturn;
        }

        public Item GetItemDetail(int itemId)
        {
           return this.GetItemDetailAsync(itemId).Result;
        }

        /// <summary>Writes the complete cache to the disk using the specified serializer.</summary>
        public void WriteCacheToDisk()
        {
            string itemCacheFileName = string.Format("{0}\\ItemCache{1}.json", this.dataManager.StoragePath, this.dataManager.Language);

            Dictionary<KeyValuePair<string, int>, List<Item>> itemListDictionary = new Dictionary<KeyValuePair<string, int>, List<Item>>
            {
                {
                    new KeyValuePair<string, int>("build", this.dataManager.Build),
                    this.itemListCache.Value
                }
            };

            this.SaveCacheFile(itemCacheFileName, itemListDictionary);

            string itemIdCacheFileName = string.Format("{0}\\ItemIdCache{1}.json", dataManager.StoragePath, dataManager.Language);

            Dictionary<KeyValuePair<string, int>, List<int>> itemIdDictionary = new Dictionary<KeyValuePair<string, int>, List<int>>
            {
                {
                    new KeyValuePair<string, int>("build", this.dataManager.Build),
                    this.itemIdCache.Value
                }
            };

            this.SaveCacheFile(itemIdCacheFileName, itemIdDictionary);
        }

        /// <summary>Writes the complete cache to the disk asynchronously using the specified serializer</summary>
        /// <returns>The <see cref="System.Threading.Tasks.Task" />.</returns>
        public async Task WriteCacheToDiskAsync()
        {
            throw new NotImplementedException("This function has not yet been implemented");
        }

        // --------------------------------------------------------------------------------------------------------------------
        // Private Methods
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Saves the contents of the cache to the file system.</summary>
        /// <param name="cacheFileName">The cache File Name.</param>
        /// <param name="dataToSave">The data To Save.</param>
        private void SaveCacheFile(string cacheFileName, object dataToSave)
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

            File.WriteAllText(cacheFileName, JsonConvert.SerializeObject(dataToSave));
        }
    }
}