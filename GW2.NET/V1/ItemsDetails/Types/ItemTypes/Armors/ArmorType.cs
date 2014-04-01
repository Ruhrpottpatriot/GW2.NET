// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArmorType.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Enumerates the possible armor piece types.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.ItemsDetails.Types.ItemTypes.Armors
{
    using System.Runtime.Serialization;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>Enumerates the possible armor piece types.</summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ArmorType
    {
        /// <summary>The 'Unknown' armor piece type.</summary>
        [EnumMember(Value = "Unknown")]
        Unknown = 0, 

        /// <summary>The 'Boots' armor piece type.</summary>
        [EnumMember(Value = "Boots")]
        Boots = 1 << 0, 

        /// <summary>The 'Coat' armor piece type.</summary>
        [EnumMember(Value = "Coat")]
        Coat = 1 << 1, 

        /// <summary>The 'Gloves' armor piece type.</summary>
        [EnumMember(Value = "Gloves")]
        Gloves = 1 << 2, 

        /// <summary>The 'Helm' armor piece type.</summary>
        [EnumMember(Value = "Helm")]
        Helm = 1 << 3, 

        /// <summary>The 'Helm Aquatic' armor piece type.</summary>
        [EnumMember(Value = "HelmAquatic")]
        HelmAquatic = 1 << 4, 

        /// <summary>The 'Leggings' armor piece type.</summary>
        [EnumMember(Value = "Leggings")]
        Leggings = 1 << 5, 

        /// <summary>The 'Shoulders' armor piece type.</summary>
        [EnumMember(Value = "Shoulders")]
        Shoulders = 1 << 6
    }
}