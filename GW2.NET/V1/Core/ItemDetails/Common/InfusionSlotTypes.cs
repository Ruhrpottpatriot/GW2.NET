// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InfusionSlotTypes.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;
using GW2DotNET.V1.Core.Converters;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemDetails.Common
{
    /// <summary>
    /// Enumerates the possible infusion slot types.
    /// </summary>
    [Flags]
    [JsonConverter(typeof(StringEnumFlagsConverter))]
    public enum InfusionSlotTypes
    {
        /// <summary>
        /// The defensive infusion slot type.
        /// </summary>
        [EnumMember(Value = "Defense")]
        Defense = 1 << 0,

        /// <summary>
        /// The offensive infusion slot type.
        /// </summary>
        [EnumMember(Value = "Offense")]
        Offense = 1 << 1,

        /// <summary>
        /// The utility infusion slot type.
        /// </summary>
        [EnumMember(Value = "Utility")]
        Utility = 1 << 2
    }
}