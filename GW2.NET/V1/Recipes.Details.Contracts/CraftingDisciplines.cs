// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CraftingDisciplines.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Enumerates the known crafting disciplines.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Recipes.Details.Contracts
{
    using System;
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Enumerates the known crafting disciplines.</summary>
    [Flags]
    [JsonConverter(typeof(StringEnumFlagsConverter))]
    public enum CraftingDisciplines
    {
        /// <summary>Indicates no crafting disciplines.</summary>
        None = 0,

        /// <summary>The 'Armor smith' crafting discipline.</summary>
        [EnumMember(Value = "Armorsmith")]
        Armorsmith = 1 << 0,

        /// <summary>The 'Artificer' crafting discipline.</summary>
        [EnumMember(Value = "Artificer")]
        Artificer = 1 << 1,

        /// <summary>The 'Chef' crafting discipline.</summary>
        [EnumMember(Value = "Chef")]
        Chef = 1 << 2,

        /// <summary>The 'Huntsman' crafting discipline.</summary>
        [EnumMember(Value = "Huntsman")]
        Huntsman = 1 << 3,

        /// <summary>The 'Jeweler' crafting discipline.</summary>
        [EnumMember(Value = "Jeweler")]
        Jeweler = 1 << 4,

        /// <summary>The 'Leatherworker' crafting discipline.</summary>
        [EnumMember(Value = "Leatherworker")]
        Leatherworker = 1 << 5,

        /// <summary>The 'Tailor' crafting discipline.</summary>
        [EnumMember(Value = "Tailor")]
        Tailor = 1 << 6,

        /// <summary>The 'Weapon smith' crafting discipline.</summary>
        [EnumMember(Value = "Weaponsmith")]
        Weaponsmith = 1 << 7
    }
}