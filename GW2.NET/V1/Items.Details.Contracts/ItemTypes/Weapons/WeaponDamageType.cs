// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeaponDamageType.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Enumerates the possible weapon damage types.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Weapons
{
    using System.Runtime.Serialization;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>Enumerates the possible weapon damage types.</summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum WeaponDamageType
    {
        /// <summary>The 'Unknown' damage type.</summary>
        [EnumMember(Value = "Unknown")]
        Unknown = 0, 

        /// <summary>The 'Fire' damage type.</summary>
        [EnumMember(Value = "Fire")]
        Fire = 1 << 0, 

        /// <summary>The 'Ice' damage type.</summary>
        [EnumMember(Value = "Ice")]
        Ice = 1 << 1, 

        /// <summary>The 'Lightning' damage type.</summary>
        [EnumMember(Value = "Lightning")]
        Lightning = 1 << 2, 

        /// <summary>The 'Physical' damage type.</summary>
        [EnumMember(Value = "Physical")]
        Physical = 1 << 3, 

        /// <summary>The 'Choking' damage type.</summary>
        [EnumMember(Value = "Choking")]
        Choking = 1 << 4
    }
}