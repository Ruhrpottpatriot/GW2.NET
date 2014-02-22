// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemFlags.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;
using GW2DotNET.V1.Core.Converters;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemsInformation.Details.Common
{
    /// <summary>
    /// Enumerates the possible additional item flags.
    /// </summary>
    [Flags]
    [JsonConverter(typeof(StringEnumFlagsConverter))]
    public enum ItemFlags
    {
        /// <summary>
        /// The 'Account Bound' item flag.
        /// </summary>
        [EnumMember(Value = "AccountBound")]
        AccountBound = 1 << 0,

        /// <summary>
        /// The 'Hide Suffix' item flag.
        /// </summary>
        [EnumMember(Value = "HideSuffix")]
        HideSuffix = 1 << 1,

        /// <summary>
        /// The 'No Mystic Forge' item flag.
        /// </summary>
        [EnumMember(Value = "NoMysticForge")]
        NoMysticForge = 1 << 2,

        /// <summary>
        /// The 'No Salvage' item flag.
        /// </summary>
        [EnumMember(Value = "NoSalvage")]
        NoSalvage = 1 << 3,

        /// <summary>
        /// The 'No Sell' item flag.
        /// </summary>
        [EnumMember(Value = "NoSell")]
        NoSell = 1 << 4,

        /// <summary>
        /// The 'Not Upgradeable' item flag.
        /// </summary>
        [EnumMember(Value = "NotUpgradeable")]
        NotUpgradeable = 1 << 5,

        /// <summary>
        /// The 'No Underwater' item flag.
        /// </summary>
        [EnumMember(Value = "NoUnderwater")]
        NoUnderwater = 1 << 6,

        /// <summary>
        /// The 'SoulBind On Acquire' item flag.
        /// </summary>
        [EnumMember(Value = "SoulBindOnAcquire")]
        SoulBindOnAcquire = 1 << 7,

        /// <summary>
        /// The 'SoulBind On Use' item flag.
        /// </summary>
        [EnumMember(Value = "SoulBindOnUse")]
        SoulBindOnUse = 1 << 8,

        /// <summary>
        /// The 'Unique' item flag.
        /// </summary>
        [EnumMember(Value = "Unique")]
        Unique = 1 << 9
    }
}