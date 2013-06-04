// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Guild.GuildEmblem.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the Guild type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

using Newtonsoft.Json;

namespace GW2DotNET.V1.Guilds.Models
{
    /// <summary>
    /// Represents a guild in the game.
    /// </summary>
    public partial struct Guild
    {
        /// <summary>
        /// Represents a guild emblem.
        /// </summary>
        public partial struct GuildEmblem
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="GuildEmblem"/> struct.
            /// </summary>
            /// <param name="background">
            /// The id of the background image.
            /// </param>
            /// <param name="foreground">
            /// The id of the foreground image.
            /// </param>
            /// <param name="flags">
            /// The emblem flags.
            /// </param>
            /// <param name="backgroundColour">
            /// The background colour.
            /// </param>
            /// <param name="foregroundPrimaryColour">
            /// The primary colour of the foreground.
            /// </param>
            /// <param name="foregroundsecondaryColour">
            /// The secondary colour of the foreground.
            /// </param>
            [JsonConstructor]
            public GuildEmblem(int background, int foreground, IEnumerable<GuildEmblemFlags> flags, int backgroundColour, int foregroundPrimaryColour, int foregroundsecondaryColour)
                : this()
            {
                this.ForegroundSecondaryColour = foregroundsecondaryColour;
                this.ForegroundPrimaryColour = foregroundPrimaryColour;
                this.BackgroundColour = backgroundColour;
                this.Flags = flags;
                this.Foreground = foreground;
                this.Background = background;
            }

            /// <summary>
            /// Gets the background image id.
            /// </summary>
            [JsonProperty("background_id")]
            public int Background { get; private set; }

            /// <summary>
            /// Gets the foreground image id.
            /// </summary>
            [JsonProperty("foreground_id")]
            public int Foreground { get; private set; }

            /// <summary>
            /// Gets the emblem flags.
            /// </summary>
            [JsonProperty("flags")]
            public IEnumerable<GuildEmblemFlags> Flags { get; private set; }

            /// <summary>
            /// Gets the background colour.
            /// </summary>
            [JsonProperty("background_color_id")]
            public int BackgroundColour { get; private set; }

            /// <summary>
            /// Gets the primary foreground colour.
            /// </summary>
            [JsonProperty("foreground_primary_color_id")]
            public int ForegroundPrimaryColour { get; private set; }

            /// <summary>
            /// Gets the secondary foreground colour.
            /// </summary>
            [JsonProperty("foreground_secondary_color_id")]
            public int ForegroundSecondaryColour { get; private set; }
        }
    }
}
