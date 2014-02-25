// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemAttributeType.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GW2DotNET.V1.Core.ItemsInformation.Details.Items.Common
{
    /// <summary>
    /// Enumerates the possible attribute types.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ItemAttributeType
    {
        /// <summary>
        /// The 'Condition Damage' attribute type.
        /// </summary>
        [EnumMember(Value = "ConditionDamage")]
        ConditionDamage = 1 << 0,

        /// <summary>
        /// The 'Critical Damage' attribute type.
        /// </summary>
        [EnumMember(Value = "CritDamage")]
        CritDamage = 1 << 1,

        /// <summary>
        /// The 'Healing' attribute type.
        /// </summary>
        [EnumMember(Value = "Healing")]
        Healing = 1 << 2,

        /// <summary>
        /// The 'Power' attribute type.
        /// </summary>
        [EnumMember(Value = "Power")]
        Power = 1 << 3,

        /// <summary>
        /// The 'Precision' attribute type.
        /// </summary>
        [EnumMember(Value = "Precision")]
        Precision = 1 << 4,

        /// <summary>
        /// The 'Toughness' attribute type.
        /// </summary>
        [EnumMember(Value = "Toughness")]
        Toughness = 1 << 5,

        /// <summary>
        /// The 'Vitality' attribute type.
        /// </summary>
        [EnumMember(Value = "Vitality")]
        Vitality = 1 << 6
    }
}