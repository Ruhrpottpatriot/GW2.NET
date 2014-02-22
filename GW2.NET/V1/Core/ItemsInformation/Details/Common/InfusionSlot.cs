// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InfusionSlot.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemsInformation.Details.Common
{
    /// <summary>
    /// Represents one of an item's infusion slots.
    /// </summary>
    public class InfusionSlot : JsonObject
    {
        /// <summary>
        /// Gets or sets the infusion slot's type(s).
        /// </summary>
        [JsonProperty("flags", Order = 0)]
        public InfusionSlotTypes Flags { get; set; }

        /// <summary>
        /// Gets or sets the infusion slot's item. Reserved for future use.
        /// </summary>
        [JsonProperty("item", Order = 1, NullValueHandling = NullValueHandling.Ignore)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Item { get; set; }
    }
}