// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InfusionSlot.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents one of an item's infusion slots.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Types.ItemTypes.Common
{
    using System.ComponentModel;
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Types;

    using Newtonsoft.Json;

    /// <summary>Represents one of an item's infusion slots.</summary>
    public class InfusionSlot : JsonObject
    {
        /// <summary>Gets or sets the infusion slot's type(s).</summary>
        [DataMember(Name = "flags", Order = 0)]
        public InfusionSlotTypes Flags { get; set; }

        /// <summary>Gets or sets the infusion slot's item. Reserved for future use.</summary>
        [DataMember(Name = "item", Order = 1)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Item { get; set; }
    }
}