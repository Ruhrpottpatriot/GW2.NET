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

namespace GW2DotNET.V1.Items.DataProvider
{
    /// <summary>
    /// The item data provider.
    /// </summary>
    public class ItemData
    {
        /// <summary>
        /// The language.
        /// </summary>
        private readonly Language language;

        /// <summary>
        /// The item id cache.
        /// </summary>
        private IEnumerable<int> itemIdCache;

        /// <summary>
        /// The items cache.
        /// </summary>
        private List<Item> itemsCache = new List<Item>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemData"/> class.
        /// </summary>
        /// <param name="language">THe language of the retrieved content.</param>
        internal ItemData(Language language)
        {
            this.language = language;
        }

        /// <summary>
        /// Gets the item ids from the server.
        /// </summary>
        private IEnumerable<int> ItemIdCache
        {
            get
            {
                return this.itemIdCache ?? (this.itemIdCache = ApiCall.GetContent<Dictionary<string, IEnumerable<int>>>("items.json", null, ApiCall.Categories.Items).Values.First());
            }
        }

        /// <summary>
        /// Gets a single item from the cache if present or the API if not.
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
                var itemToReturn = this.itemsCache.SingleOrDefault(item => item.Id == itemId);

                if (itemToReturn.Id == 0)
                {
                    var arguments = new List<KeyValuePair<string, object>>
                                        {
                                            new KeyValuePair<string, object>(
                                                "item_id", itemId),
                                                new KeyValuePair<string, object>("lang", this.language)
                                        };

                    itemToReturn = ApiCall.GetContent<Item>("item_details.json", arguments, ApiCall.Categories.Items);

                    this.itemsCache.Add(itemToReturn);
                }

                return itemToReturn;
            }
        }
    }
}