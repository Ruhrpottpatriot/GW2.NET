// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpgradeComponentType.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Enumerates the possible upgrade component types.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.UpgradeComponents
{
    using System.Runtime.Serialization;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>Enumerates the possible upgrade component types.</summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum UpgradeComponentType
    {
        /// <summary>The 'Unknown' upgrade component type.</summary>
        [EnumMember(Value = "Unknown")]
        Unknown = 0, 

        /// <summary>The 'Default' upgrade component type.</summary>
        [EnumMember(Value = "Default")]
        Default = 1 << 0, 

        /// <summary>The 'Gem' upgrade component type.</summary>
        [EnumMember(Value = "Gem")]
        Gem = 1 << 2, 

        /// <summary>The 'Rune' upgrade component type.</summary>
        [EnumMember(Value = "Rune")]
        Rune = 1 << 3, 

        /// <summary>The 'Sigil' upgrade component type.</summary>
        [EnumMember(Value = "Sigil")]
        Sigil = 1 << 4
    }
}