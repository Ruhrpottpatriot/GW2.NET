// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventFlags.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Enumerates the possible flags for events.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Core.DynamicEventsInformation.Details
{
    using System;
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Core.Converters;

    using Newtonsoft.Json;

    /// <summary>
    ///     Enumerates the possible flags for events.
    /// </summary>
    [Flags]
    [JsonConverter(typeof(StringEnumFlagsConverter))]
    public enum DynamicEventFlags
    {
        /// <summary>Indicates no additional flags.</summary>
        None = 0, 

        /// <summary>The 'group event' flag.</summary>
        [EnumMember(Value = "group_event")]
        GroupEvent = 1 << 0, 

        /// <summary>The 'map-wide' event flag.</summary>
        [EnumMember(Value = "map_wide")]
        MapWide = 1 << 1
    }
}