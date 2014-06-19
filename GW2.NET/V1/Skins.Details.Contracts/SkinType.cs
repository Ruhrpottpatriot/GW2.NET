// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkinType.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Enumerates the possible skin types.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Skins.Details.Contracts
{
    using System.Runtime.Serialization;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>Enumerates the possible skin types.</summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SkinType
    {
        /// <summary>The 'Unknown' skin type.</summary>
        [EnumMember(Value = "Unknown")]
        Unknown = 0, 

        /// <summary>The 'Armor' skin type.</summary>
        [EnumMember(Value = "Armor")]
        Armor = 1 << 0, 

        /// <summary>The 'Back' skin type.</summary>
        [EnumMember(Value = "Back")]
        Back = 1 << 1, 

        /// <summary>The 'Weapon' skin type.</summary>
        [EnumMember(Value = "Weapon")]
        Weapon = 1 << 2
    }
}