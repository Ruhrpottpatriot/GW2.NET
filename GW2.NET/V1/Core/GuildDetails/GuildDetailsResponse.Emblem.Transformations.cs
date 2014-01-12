// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuildDetailsResponse.Emblem.Transformations.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System;
using GW2DotNET.V1.Core.Converters;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.GuildDetails
{
    /// <summary>
    /// Represents a response that is the result of a <see cref="GuildDetailsRequest"/>.
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details"/> for more information.
    /// </remarks>
    public partial class GuildDetailsResponse
    {
        /// <summary>
        /// Represents a guild's emblem.
        /// </summary>
        public partial class Emblem
        {
            /// <summary>
            /// Enumerates the possible transformations for a guild emblem image.
            /// </summary>
            [Flags]
            [JsonConverter(typeof(StringEnumFlagsConverter<Transformations>))]
            public enum Transformations
            {
                /// <summary>
                /// Flip the background image horizontally.
                /// </summary>
                FlipBackgroundHorizontal = 1,

                /// <summary>
                /// Flip the background image vertically.
                /// </summary>
                FlipBackgroundVertical = 1 << 1,

                /// <summary>
                /// Flip the foreground image horizontally.
                /// </summary>
                FlipForegroundHorizontal = 1 << 2,

                /// <summary>
                /// Flip the foreground image vertically.
                /// </summary>
                FlipForegroundVertical = 1 << 3
            }
        }
    }
}
