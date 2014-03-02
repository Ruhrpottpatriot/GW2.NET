// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Guild.GuildEmblem.GuildEmblemFlags.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a guild in the game.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Guilds.Models
{
    /// <summary>Represents a guild in the game.</summary>
    public partial class Guild
    {
        /// <summary>Represents a guild emblem.</summary>
        public partial class GuildEmblem
        {
            /// <summary>Enumerates all possible guild emblem flags.</summary>
            public enum GuildEmblemFlags
            {
                /// <summary>The background is flipped horizontal.</summary>
                FlipBackgroundHorizontal, 

                /// <summary>The background is flipped vertical.</summary>
                FlipBackgroundVertical, 

                /// <summary>The foreground is flipped horizontal.</summary>
                FlipForegroundHorizontal, 

                /// <summary>The foreground is flipped vertical.</summary>
                FlipForegroundVertical
            }
        }
    }
}