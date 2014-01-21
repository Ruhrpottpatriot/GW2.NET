// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InfixUpgrade.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemDetails.Models.Common
{
    /// <summary>
    /// Represents item stats that are inherent to a specific item.
    /// </summary>
    public partial class InfixUpgrade
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InfixUpgrade"/> class.
        /// </summary>
        public InfixUpgrade()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InfixUpgrade"/> class using the specified values.
        /// </summary>
        /// <param name="attributes">The item's attributes.</param>
        public InfixUpgrade(IEnumerable<ItemAttribute> attributes)
        {
            this.Attributes = attributes;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InfixUpgrade"/> class using the specified values.
        /// </summary>
        /// <param name="buff">The item's buff.</param>
        /// <param name="attributes">The item's attributes.</param>
        public InfixUpgrade(ItemBuff buff, IEnumerable<ItemAttribute> attributes)
        {
            this.Buff = buff;
            this.Attributes = attributes;
        }

        /// <summary>
        /// Gets or sets the item's attributes.
        /// </summary>
        [JsonProperty("attributes", Order = 1)]
        public IEnumerable<ItemAttribute> Attributes { get; set; }

        /// <summary>
        /// Gets or sets the item's buff.
        /// </summary>
        [JsonProperty("buff", Order = 0, NullValueHandling = NullValueHandling.Ignore)]
        public ItemBuff Buff { get; set; }

        /// <summary>
        /// Gets the JSON representation of this instance.
        /// </summary>
        /// <returns>Returns a JSON <see cref="System.String"/>.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// Gets the JSON representation of this instance.
        /// </summary>
        /// <param name="indent">A value that indicates whether to indent the output.</param>
        /// <returns>Returns a JSON <see cref="System.String"/>.</returns>
        public string ToString(bool indent)
        {
            return JsonConvert.SerializeObject(this, indent ? Formatting.Indented : Formatting.None);
        }
    }
}