// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemDTO.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ItemDTO type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Items.Json
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:2/items")]
    public sealed class ItemDTO
    {
        [DataMember(Order = 5, Name = "default_skin")]
        public string DefaultSkin { get; set; }

        [DataMember(Order = 1, Name = "description")]
        public string Description { get; set; }

        [DataMember(Order = 12, Name = "details")]
        public DetailsDTO Details { get; set; }

        [DataMember(Order = 8, Name = "flags")]
        public ICollection<string> Flags { get; set; }

        [DataMember(Order = 7, Name = "game_types")]
        public ICollection<string> GameTypes { get; set; }

        [DataMember(Order = 11, Name = "icon")]
        public string Icon { get; set; }

        [DataMember(Order = 10, Name = "id")]
        public int Id { get; set; }

        [DataMember(Order = 3, Name = "level")]
        public int Level { get; set; }

        [DataMember(Order = 0, Name = "name")]
        public string Name { get; set; }

        [DataMember(Order = 4, Name = "rarity")]
        public string Rarity { get; set; }

        [DataMember(Order = 9, Name = "restrictions")]
        public ICollection<string> Restrictions { get; set; }

        [DataMember(Order = 2, Name = "type")]
        public string Type { get; set; }

        [DataMember(Order = 6, Name = "vendor_value")]
        public int VendorValue { get; set; }
    }
}