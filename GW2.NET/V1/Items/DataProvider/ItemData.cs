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

using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.Items.Models.Items;

namespace GW2DotNET.V1.Items.DataProvider
{
    using System.IO;
    using System.Collections.Specialized;

    /// <summary>
    /// The item data provider.
    /// </summary>
    public partial class ItemData : DataProviderBase, IEnumerable<Item>
    {
        /// <summary>The api manager.</summary>
        private readonly ApiManager apiManager;

        /// <summary>
        /// The name of the file on disk where we will cache the item data.
        /// </summary>
        private readonly string cacheFileName;

        /// <summary>
        /// The item id cache.
        /// </summary>
        private IEnumerable<int> itemIdCache;

        /// <summary>
        /// The items cache.
        /// </summary>
        private IEnumerable<Item> itemsCache;

        /// <summary>
        /// Used to synchronize access to the itemsCache. Use this one
        /// object for both itemIdCache and itemsCache.
        /// </summary>
        private readonly object itemCacheSyncObject = new object();

        /// <summary>Initializes a new instance of the <see cref="ItemData"/> class.</summary>
        /// <param name="apiManager">The api Manager.</param>
        internal ItemData(ApiManager apiManager)
        {
            this.apiManager = apiManager;

            this.cacheFileName = string.Format("{0}\\GW2.NET\\ItemDataCache{1}.binary", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), this.apiManager.Language);
        }

        /// <summary>Initializes a new instance of the <see cref="ItemData"/> class.</summary>
        /// <param name="language">The language of the retrieved content.</param>
        /// <param name="savePath">The path to the file (without file name and trailing slash).</param>
        /// <param name="apiManager">The api Manager.</param>
        internal ItemData(Language language, string savePath, ApiManager apiManager)
        {
            this.apiManager = apiManager;

            this.cacheFileName = string.Format("{0}\\ItemDataCache{1}.binary", savePath, language);

            this.LoadCache();

            this.InitializeDelegates();
        }

        /// <summary>
        ///     Initialize the delegates. This is called by the constructor.
        /// </summary>
        protected virtual void InitializeDelegates()
        {
            onGetItemFromIdCompletedDelegate = GetItemFromIdCompletedCallback;

            onGetItemFromIdProgressReportDelegate = GetItemFromIdReportProgressCallback;

            onGetAllItemsCompletedDelegate = GetAllItemsCompletedCallback;

            onGetAllItemsProgressReportDelegate = GetAllItemsReportProgressCallback;
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
                lock (itemCacheSyncObject)
                {
                    // Try to load the cache from disk
                    if (this.itemsCache == null)
                    {
                        this.LoadCache();
                    }

                    // If there was nothing on disk, or it was stale, use the API
                    if (this.itemsCache == null)
                    {
                        this.GetAllItems();
                    }
                }

                return this.itemsCache;
            }
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
        /// Loads the cache from the file system to the internal cache.
        /// </summary>
        private void LoadCache()
        {
            // Because this method is only called by the AllItems property
            // accessor, and that accessor locks the cache sync object, we
            // don't need to lock it here.

            // Check if there is a cache file present.
            if (File.Exists(this.cacheFileName))
            {
                ItemDataCache diskData;

                // Deserialize the binary file.
                using (var fileStream = new FileStream(this.cacheFileName, FileMode.Open))
                {
                    var binarySerializer = new BinaryFormatter();

                    diskData = (ItemDataCache) binarySerializer.Deserialize(fileStream);
                }

                // Check if the data is stale.
                if (diskData.Build >= this.apiManager.GetLatestBuild())
                {
                    this.itemsCache = diskData.ItemsList;

                    this.itemIdCache = diskData.ItemIds;
                }

                /* If we had no data on disk or it was stale, the cache will
                 * be empty when this method returns.
                 */
            }
        }

        /// <summary>
        /// Saves the contents of the cache to the file system.
        /// </summary>
        private void SaveCache()
        {
            var dataToSave = new ItemDataCache
            {
                Build = this.apiManager.Build,
                ItemIds = this.itemIdCache,
                ItemsList = this.itemsCache
            };

            string directoryPath = Path.GetDirectoryName(this.cacheFileName);

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
            using (var fileStream = new FileStream(this.cacheFileName, FileMode.Create))
            {
                var binarySerializer = new BinaryFormatter();

                binarySerializer.Serialize(fileStream, dataToSave);
            }
        }

        /// <summary>Fill the items cache with data and save it to disk.</summary>
        /// <remarks>This causes upwards of 25,000 API calls, 
        /// so we only want to do it when the build number of Guild Wars 2 changes.
        /// Otherwise, the item data should not have changed (according to ArenaNet).
        /// </remarks>
        private void GetAllItems()
        {
            // Because this method is ONLY called by the private AllItems property
            // accessor, and that accessor has already locked the sync object, we
            // don't have to lock it here.
            this.itemIdCache =
                ApiCall.GetContent<Dictionary<string, List<int>>>("items.json", null, ApiCall.Categories.Items)
                       .Values.First();

            this.itemsCache = this.itemIdCache
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

            this.SaveCache();
        }
    }
}