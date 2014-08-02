// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InfusionSlotContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents one of an item's infusion slots.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Contracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>Represents one of an item's infusion slots.</summary>
    [DataContract]
    public sealed class InfusionSlotContract
    {
        /// <summary>Gets or sets the infusion slot type(s).</summary>
        [DataMember(Name = "flags", Order = 0)]
        public ICollection<string> Flags { get; set; }

        /// <summary>Gets or sets the infusion slot's item identifier.</summary>
        [DataMember(Name = "item_id", Order = 1)]
        public string ItemId { get; set; }
    }
}