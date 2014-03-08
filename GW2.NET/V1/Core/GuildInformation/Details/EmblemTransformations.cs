// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmblemTransformations.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;
using GW2DotNET.V1.Core.Converters;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.GuildInformation.Details
{
    /// <summary>
    ///     Enumerates the possible transformations for a guild emblem image.
    /// </summary>
    [Flags]
    [JsonConverter(typeof(StringEnumFlagsConverter))]
    public enum EmblemTransformations
    {
        /// <summary>Indicates no transformations.</summary>
        None = 0,

        /// <summary>Flip the background image horizontally.</summary>
        [EnumMember(Value = "FlipBackgroundHorizontal")] FlipBackgroundHorizontal = 1 << 0,

        /// <summary>Flip the background image vertically.</summary>
        [EnumMember(Value = "FlipBackgroundVertical")] FlipBackgroundVertical = 1 << 1,

        /// <summary>Flip the foreground image horizontally.</summary>
        [EnumMember(Value = "FlipForegroundHorizontal")] FlipForegroundHorizontal = 1 << 2,

        /// <summary>Flip the foreground image vertically.</summary>
        [EnumMember(Value = "FlipForegroundVertical")] FlipForegroundVertical = 1 << 3
    }
}