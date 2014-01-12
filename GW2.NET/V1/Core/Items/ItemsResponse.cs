// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemsResponse.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.Items
{
    /// <summary>
    /// Represents a response that is the result of an <see cref="ItemsRequest"/>.
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/items"/> for more information.
    /// </remarks>
    public class ItemsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemsResponse"/> class.
        /// </summary>
        public ItemsResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemsResponse"/> class.
        /// </summary>
        /// <param name="items">The list of all discovered item IDs.</param>
        public ItemsResponse(List<int> items)
        {
            this.Items = items;
        }

        /// <summary>
        /// Gets a list of all discovered item IDs.
        /// </summary>
        [JsonProperty("items")]
        public List<int> Items { get; private set; }

        /// <summary>
        /// Gets the JSON representation of this instance.
        /// </summary>
        /// <returns>Returns a JSON <see cref="String"/>.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
