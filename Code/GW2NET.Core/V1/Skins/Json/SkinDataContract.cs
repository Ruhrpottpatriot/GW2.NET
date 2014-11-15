// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkinDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the SkinDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Skins.Json
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/skin_details")]
    internal sealed class SkinDataContract
    {
        [DataMember(Name = "skin_id", Order = 0)]
        internal string SkinId { get; set; }

        [DataMember(Name = "name", Order = 1)]
        internal string Name { get; set; }

        [DataMember(Name = "type", Order = 2)]
        internal string Type { get; set; }

        [DataMember(Name = "flags", Order = 3)]
        internal ICollection<string> Flags { get; set; }

        [DataMember(Name = "restrictions", Order = 4)]
        internal ICollection<string> Restrictions { get; set; }

        [DataMember(Name = "icon_file_id", Order = 5)]
        internal string IconFileId { get; set; }

        [DataMember(Name = "icon_file_signature", Order = 6)]
        internal string IconFileSignature { get; set; }

        [DataMember(Name = "description", Order = 7)]
        internal string Description { get; set; }

        [DataMember(Name = "armor", Order = 8)]
        internal ArmorSkinDataContract Armor { get; set; }

        [DataMember(Name = "weapon", Order = 9)]
        internal WeaponSkinDataContract Weapon { get; set; }
    }
}