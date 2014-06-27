// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InfusionSlot.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents one of an item's infusion slots.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.Common
{
    using System.Runtime.Serialization;

    using GW2DotNET.Common.Contracts;
    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents one of an item's infusion slots.</summary>
    public class InfusionSlot : ServiceContract
    {
        /// <summary>Gets or sets the infusion slot's type(s).</summary>
        [DataMember(Name = "flags")]
        public virtual InfusionSlotTypes Flags { get; set; }

        /// <summary>Gets or sets the infusion slot's item.</summary>
        [DataMember(Name = "item_id")]
        [JsonConverter(typeof(UnknownItemConverter))]
        public virtual Item Item { get; set; }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return this.Flags.ToString();
        }
    }
}