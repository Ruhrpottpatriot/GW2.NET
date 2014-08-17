// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeaponSkinContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a weapon skin.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Skins.Json
{
    using System.Runtime.Serialization;

    /// <summary>Represents a weapon skin.</summary>
    [DataContract]
    public sealed class WeaponSkinContract
    {
        /// <summary>Gets or sets the weapon's damage type.</summary>
        [DataMember(Name = "damage_type", Order = 1)]
        public string DamageType { get; set; }

        /// <summary>Gets or sets the weapon skin type.</summary>
        [DataMember(Name = "type", Order = 0)]
        public string Type { get; set; }
    }
}