// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventStyles.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;
using GW2DotNET.V1.Core.Converters;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.EventDetails.Models
{
    /// <summary>
    /// Enumerates the special event styles.
    /// </summary>
    [Flags]
    [JsonConverter(typeof(StringEnumFlagsConverter))]
    public enum DynamicEventStyles
    {
        /// <summary>
        /// The group event style.
        /// </summary>
        [EnumMember(Value = "group_event")]
        GroupEvent = 1,

        /// <summary>
        /// The map-wide event style.
        /// </summary>
        [EnumMember(Value = "map_wide")]
        MapWide = 1 << 1
    }
}