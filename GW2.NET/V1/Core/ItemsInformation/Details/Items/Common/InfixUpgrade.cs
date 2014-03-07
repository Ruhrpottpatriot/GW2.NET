// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InfixUpgrade.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemsInformation.Details.Items.Common
{
    /// <summary>
    /// Represents item stats that are inherent to a specific item.
    /// </summary>
    public class InfixUpgrade : JsonObject
    {
        /// <summary>
        /// Gets or sets the item's attributes.
        /// </summary>
        [JsonProperty("attributes", Order = 1)]
        public ItemAttributeCollection Attributes { get; set; }

        /// <summary>
        /// Gets or sets the item's buff.
        /// </summary>
        [JsonProperty("buff", Order = 0, NullValueHandling = NullValueHandling.Ignore)]
        public ItemBuff Buff { get; set; }
    }
}