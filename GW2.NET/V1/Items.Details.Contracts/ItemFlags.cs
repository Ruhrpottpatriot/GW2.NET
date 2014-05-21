// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemFlags.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Enumerates the known additional item flags.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Items.Details.Contracts
{
    using System;
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Enumerates the known additional item flags.</summary>
    [Flags]
    [JsonConverter(typeof(StringEnumFlagsConverter))]
    public enum ItemFlags
    {
        /// <summary> Indicates no additional item flags.</summary>
        None = 0, 

        /// <summary>The 'Account Bound' item flag.</summary>
        [EnumMember(Value = "AccountBound")]
        AccountBound = 1 << 0, 

        /// <summary>The 'Hide Suffix' item flag.</summary>
        [EnumMember(Value = "HideSuffix")]
        HideSuffix = 1 << 1, 

        /// <summary>The 'No Mystic Forge' item flag.</summary>
        [EnumMember(Value = "NoMysticForge")]
        NoMysticForge = 1 << 2, 

        /// <summary>The 'No Salvage' item flag.</summary>
        [EnumMember(Value = "NoSalvage")]
        NoSalvage = 1 << 3, 

        /// <summary>The 'No Sell' item flag.</summary>
        [EnumMember(Value = "NoSell")]
        NoSell = 1 << 4, 

        /// <summary>The 'Not Upgradeable' item flag.</summary>
        [EnumMember(Value = "NotUpgradeable")]
        NotUpgradeable = 1 << 5, 

        /// <summary>The 'No Underwater' item flag.</summary>
        [EnumMember(Value = "NoUnderwater")]
        NoUnderwater = 1 << 6, 

        /// <summary>The 'Soul Bind On Acquire' item flag.</summary>
        [EnumMember(Value = "SoulBindOnAcquire")]
        SoulBindOnAcquire = 1 << 7, 

        /// <summary>The 'Soul Bind On Use' item flag.</summary>
        [EnumMember(Value = "SoulBindOnUse")]
        SoulBindOnUse = 1 << 8, 

        /// <summary>The 'Unique' item flag.</summary>
        [EnumMember(Value = "Unique")]
        Unique = 1 << 9, 

        /// <summary>The 'Account Bind On Use' item flag.</summary>
        [EnumMember(Value = "AccountBindOnUse")]
        AccountBindOnUse = 1 << 10
    }
}