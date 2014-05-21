// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InfusionSlotTypes.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Enumerates the known infusion slot types.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Common
{
    using System;
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Enumerates the known infusion slot types.</summary>
    [Flags]
    [JsonConverter(typeof(StringEnumFlagsConverter))]
    public enum InfusionSlotTypes
    {
        /// <summary>Indicates no infusion slots.</summary>
        None = 0, 

        /// <summary>The 'Defense' infusion slot type.</summary>
        [EnumMember(Value = "Defense")]
        Defense = 1 << 0, 

        /// <summary>The 'Offense' infusion slot type.</summary>
        [EnumMember(Value = "Offense")]
        Offense = 1 << 1, 

        /// <summary>The 'Utility' infusion slot type.</summary>
        [EnumMember(Value = "Utility")]
        Utility = 1 << 2
    }
}