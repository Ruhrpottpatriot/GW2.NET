// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemRestrictions.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Enumerates the known item restrictions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Items.Details.Contracts
{
    using System;
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Enumerates the known item restrictions.</summary>
    [Flags]
    [JsonConverter(typeof(StringEnumFlagsConverter))]
    public enum ItemRestrictions
    {
        /// <summary>Indicates no restrictions.</summary>
        None = 0, 

        /// <summary>The 'Asura' item restriction.</summary>
        [EnumMember(Value = "Asura")]
        Asura = 1 << 0, 

        /// <summary>The 'Charr' item restriction.</summary>
        [EnumMember(Value = "Charr")]
        Charr = 1 << 1, 

        /// <summary>The 'Human' item restriction.</summary>
        [EnumMember(Value = "Human")]
        Human = 1 << 2, 

        /// <summary>The 'Norn' item restriction.</summary>
        [EnumMember(Value = "Norn")]
        Norn = 1 << 3, 

        /// <summary>The 'Sylvari' item restriction.</summary>
        [EnumMember(Value = "Sylvari")]
        Sylvari = 1 << 4, 

        /// <summary>The 'Elementalist' item restriction.</summary>
        [EnumMember(Value = "Elementalist")]
        Elementalist = 1 << 5, 

        /// <summary>The 'Engineer' item restriction.</summary>
        [EnumMember(Value = "Engineer")]
        Engineer = 1 << 6, 

        /// <summary>The 'Guardian' item restriction.</summary>
        [EnumMember(Value = "Guardian")]
        Guardian = 1 << 7, 

        /// <summary>The 'Mesmer' item restriction.</summary>
        [EnumMember(Value = "Mesmer")]
        Mesmer = 1 << 8, 

        /// <summary>The 'Necromancer' item restriction.</summary>
        [EnumMember(Value = "Necromancer")]
        Necromancer = 1 << 9, 

        /// <summary>The 'Ranger' item restriction.</summary>
        [EnumMember(Value = "Ranger")]
        Ranger = 1 << 10, 

        /// <summary>The 'Thief' item restriction.</summary>
        [EnumMember(Value = "Thief")]
        Thief = 1 << 11, 

        /// <summary>The 'Warrior' item restriction.</summary>
        [EnumMember(Value = "Warrior")]
        Warrior = 1 << 12
    }
}