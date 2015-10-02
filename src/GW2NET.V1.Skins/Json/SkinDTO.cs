// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkinDTO.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the SkinDTO type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Skins.Json
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/skin_details")]
    public sealed class SkinDTO
    {
        [DataMember(Name = "skin_id", Order = 0)]
        public string SkinId { get; set; }

        [DataMember(Name = "name", Order = 1)]
        public string Name { get; set; }

        [DataMember(Name = "type", Order = 2)]
        public string Type { get; set; }

        [DataMember(Name = "flags", Order = 3)]
        public ICollection<string> Flags { get; set; }

        [DataMember(Name = "restrictions", Order = 4)]
        public ICollection<string> Restrictions { get; set; }

        [DataMember(Name = "icon_file_id", Order = 5)]
        public string IconFileId { get; set; }

        [DataMember(Name = "icon_file_signature", Order = 6)]
        public string IconFileSignature { get; set; }

        [DataMember(Name = "description", Order = 7)]
        public string Description { get; set; }

        [DataMember(Name = "armor", Order = 8)]
        public ArmorSkinDTO Armor { get; set; }

        [DataMember(Name = "weapon", Order = 9)]
        public WeaponSkinDTO Weapon { get; set; }
    }
}