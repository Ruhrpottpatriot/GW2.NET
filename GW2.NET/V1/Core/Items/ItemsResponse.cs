// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemsResponse.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

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
    public class ItemsResponse : JsonObject
    {
        /// <summary>
        /// Gets or sets a list of all discovered item IDs.
        /// </summary>
        [JsonProperty("items")]
        public List<int> Items { get; set; }
    }
}