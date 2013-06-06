// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemData.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ItemData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using System.Linq;

using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.Items.Models.Items;
using System;

namespace GW2DotNET.V1.Items.DataProvider
{
    /// <summary>
    /// The item data provider.
    /// </summary>
    public class ItemData : IEnumerable<Item>
    {
        /// <summary>
        /// The language.
        /// </summary>
        private readonly Language language;

        /// <summary>
        /// The item id cache.
        /// </summary>
        private IEnumerable<int> itemIdCache = null;

        /// <summary>
        /// The items cache.
        /// </summary>
        private IEnumerable<Item> itemsCache = null;

        /// <summary>
        /// The name of the file on disk where we will cache the item data.
        /// </summary>
        private string cacheFileName;

        /// <summary>
        /// The GW2ApiManager that instantiated this object.
        /// </summary>
        private GW2ApiManager gw2ApiManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemData"/> class.
        /// </summary>
        /// <param name="language">THe language of the retrieved content.</param>
        internal ItemData(Language language, GW2ApiManager gw2ApiManager)
        {
            this.language = language;

            this.cacheFileName = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\GW2.NET\\ItemDataCache" + language.ToString() + ".binary";

            this.gw2ApiManager = gw2ApiManager;
            
            this.LoadItemCacheFromDisk();
        }

        private void LoadItemCacheFromDisk()
        {
            // Do we have the items for this language cached to disk already?
            if (System.IO.File.Exists(this.cacheFileName))
            {
                using (var stream = new System.IO.FileStream(this.cacheFileName, System.IO.FileMode.Open))
                {
                    ItemDataCache itemDataFromDisk = new ItemDataCache();

                    var serializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    itemDataFromDisk = (ItemDataCache)serializer.Deserialize(stream);

                    stream.Close();

                    // Is this data still good?
                    if (this.gw2ApiManager.BuildNumber == itemDataFromDisk.build)
                    {
                        this.itemsCache = itemDataFromDisk.itemsList;

                        this.itemIdCache = itemDataFromDisk.itemIds;
                    }
                }
            }

            // If we had no data on disk or it was stale, the cache will
            // be empty when this method returns. We do not proactively
            // retrieve the item data for the new build. This will be done
            // the next time the caller attempts to retrieve the details
            // of an item.
        }

        /// <summary>
        /// Fill the items cache with data and save it to disk. This causes
        /// upwards of 25,000 API calls, so we only want to do it when the
        /// build number of Guild Wars 2 changes. Otherwise, the item data
        /// should not have changed.
        /// </summary>
        private void PopulateItemCache()
        {
            this.itemIdCache = ApiCall.GetContent<Dictionary<string, IEnumerable<int>>>("items.json", null, ApiCall.Categories.Items).Values.First();

            this.itemsCache = this.itemIdCache.Select(itemId => new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("item_id", itemId), new KeyValuePair<string, object>("lang", this.language) }).Select(arguments => ApiCall.GetContent<Item>("item_details.json", arguments, ApiCall.Categories.Items));

            var cachedDataToSave = new ItemDataCache();

            cachedDataToSave.build = this.gw2ApiManager.BuildNumber;

            cachedDataToSave.itemIds = this.itemIdCache.ToList();

            cachedDataToSave.itemsList = this.itemsCache.ToList();

            // Once we have it as a list, set the cache to point to the list.
            // Otherwise, we repeat the query and retrieve the data all over again
            // when this.itemsCache is accessed.
            this.itemsCache = cachedDataToSave.itemsList;

            // Make sure the directory exists first
            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(this.cacheFileName));

            // Serialize the data and write the file
            using (var stream = new System.IO.FileStream(this.cacheFileName, System.IO.FileMode.Create))
            {
                var serializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                serializer.Serialize(stream, cachedDataToSave);

                stream.Close();
            }
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
                if (this.itemsCache == null)
                {
                    this.PopulateItemCache();
                }

                return this.itemsCache;
            }
        }

        /// <summary>
        /// Gets a single item from the cache.
        /// </summary>
        /// <param name="itemId">
        /// The item id.
        /// </param>
        /// <returns>
        /// The <see cref="Item"/>.
        /// </returns>
        public Item this[int itemId]
        {
            get
            {
                return this.AllItems.Single(item => item.Id == itemId);
            }
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return this.AllItems.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.AllItems.GetEnumerator();
        }
    }
}