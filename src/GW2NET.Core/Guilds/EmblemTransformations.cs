// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmblemTransformations.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Enumerates the possible transformations for a guild emblem image.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Guilds
{
    using System;

    /// <summary>Enumerates the possible transformations for a guild emblem image.</summary>
    [Flags]
    public enum EmblemTransformations
    {
        /// <summary>Indicates no transformations.</summary>
        None = 0,

        /// <summary>Flip the background image horizontally.</summary>
        FlipBackgroundHorizontal = 1 << 0,

        /// <summary>Flip the background image vertically.</summary>
        FlipBackgroundVertical = 1 << 1,

        /// <summary>Flip the foreground image horizontally.</summary>
        FlipForegroundHorizontal = 1 << 2,

        /// <summary>Flip the foreground image vertically.</summary>
        FlipForegroundVertical = 1 << 3
    }
}
