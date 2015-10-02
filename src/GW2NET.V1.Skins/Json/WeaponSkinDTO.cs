// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeaponSkinDTO.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the WeaponSkinDTO type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Skins.Json
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/skin_details")]
    public sealed class WeaponSkinDTO
    {
        [DataMember(Name = "type", Order = 0)]
        public string Type { get; set; }

        [DataMember(Name = "damage_type", Order = 1)]
        public string DamageType { get; set; }
    }
}