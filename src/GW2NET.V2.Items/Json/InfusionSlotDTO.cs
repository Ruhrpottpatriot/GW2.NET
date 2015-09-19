// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InfusionSlotDTO.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the InfusionSlotDTO type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Items.Json
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented",
        Justification = "http://wiki.guildwars2.com/wiki/API:2/items")]
    public sealed class InfusionSlotDTO
    {
        [DataMember(Name = "flags", Order = 0)]
        public ICollection<string> Flags { get; set; }

        [DataMember(Name = "item_id", Order = 1)]
        public int? ItemId { get; set; }
    }
}