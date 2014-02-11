// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Guild.GuildEmblem.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the Guild type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace GW2DotNET.V1.Guilds.Models
{
    /// <summary>
    /// Represents a guild in the game.
    /// </summary>
    public partial class Guild
    {
        /// <summary>
        /// Represents a guild emblem.
        /// </summary>
        public partial class GuildEmblem : IEquatable<GuildEmblem>
        {
            /// <summary>Initializes a new instance of the <see cref="GuildEmblem"/> class. 
            /// Initializes a new instance of the <see cref="GuildEmblem"/> class.</summary>
            /// <param name="background">The id of the background image.</param>
            /// <param name="foreground">The id of the foreground image.</param>
            /// <param name="flags">The emblem flags.</param>
            /// <param name="backgroundColour">The background colour.</param>
            /// <param name="foregroundPrimaryColour">The primary colour of the foreground.</param>
            /// <param name="foregroundsecondaryColour">The secondary colour of the foreground.</param>
            [JsonConstructor]
            public GuildEmblem(int background, int foreground, IEnumerable<GuildEmblemFlags> flags, int backgroundColour, int foregroundPrimaryColour, int foregroundsecondaryColour)
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
            public int Background
            {
                get;
                private set;
            }

            /// <summary>
            /// Gets the foreground image id.
            /// </summary>
            [JsonProperty("foreground_id")]
            public int Foreground
            {
                get;
                private set;
            }

            /// <summary>
            /// Gets the emblem flags.
            /// </summary>
            [JsonProperty("flags")]
            public IEnumerable<GuildEmblemFlags> Flags
            {
                get;
                private set;
            }

            /// <summary>
            /// Gets the background colour.
            /// </summary>
            [JsonProperty("background_color_id")]
            public int BackgroundColour
            {
                get;
                private set;
            }

            /// <summary>
            /// Gets the primary foreground colour.
            /// </summary>
            [JsonProperty("foreground_primary_color_id")]
            public int ForegroundPrimaryColour
            {
                get;
                private set;
            }

            /// <summary>
            /// Gets the secondary foreground colour.
            /// </summary>
            [JsonProperty("foreground_secondary_color_id")]
            public int ForegroundSecondaryColour
            {
                get;
                private set;
            }

            /// <summary>
            /// Checks if two instances of <see cref="GuildEmblem"/> are equal.
            /// </summary>
            /// <param name="emblemA">
            /// The first emblem.
            /// </param>
            /// <param name="emblemB">
            /// The second emblem.
            /// </param>
            /// <returns>
            /// true if both instances are the same, otherwise false
            /// </returns>
            public static bool operator ==(GuildEmblem emblemA, GuildEmblem emblemB)
            {
                if (emblemA != null && emblemB != null)
                {
                    return emblemA.Background == emblemB.Background && emblemA.Foreground == emblemB.Foreground
                           && emblemA.BackgroundColour == emblemB.BackgroundColour
                           && emblemA.ForegroundPrimaryColour == emblemB.ForegroundPrimaryColour
                           && emblemA.ForegroundSecondaryColour == emblemB.ForegroundSecondaryColour;
                }

                return false;
            }

            /// <summary>
            /// Checks if two instances of <see cref="GuildEmblem"/> are not equal.
            /// </summary>
            /// <param name="emblemA">
            /// The first emblem.
            /// </param>
            /// <param name="emblemB">
            /// The second emblem.
            /// </param>
            /// <returns>
            /// true if both instances are the not the same, otherwise false.
            /// </returns>
            public static bool operator !=(GuildEmblem emblemA, GuildEmblem emblemB)
            {
                return !(emblemA == emblemB);
            }

            /// <summary>
            /// Indicates whether the current object is equal to another object of the same type.
            /// </summary>
            /// <returns>
            /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
            /// </returns>
            /// <param name="other">An object to compare with this object.</param>
            public bool Equals(GuildEmblem other)
            {
                return this == other;
            }

            /// <summary>
            /// Indicates whether this instance and a specified object are equal.
            /// </summary>
            /// <returns>
            /// true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.
            /// </returns>
            /// <param name="obj">Another object to compare to. </param>
            public override bool Equals(object obj)
            {
                return obj is GuildEmblem && (GuildEmblem)obj == this;
            }

            /// <summary>
            /// Returns the hash code for this instance.
            /// </summary>
            /// <returns>
            /// A 32-bit signed integer that is the hash code for this instance.
            /// </returns>
            public override int GetHashCode()
            {
                unchecked
                {
                    int hashCode = this.Background;
                    hashCode = (hashCode * 397) ^ this.Foreground;
                    hashCode = (hashCode * 397) ^ (this.Flags != null ? this.Flags.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ this.BackgroundColour;
                    hashCode = (hashCode * 397) ^ this.ForegroundPrimaryColour;
                    hashCode = (hashCode * 397) ^ this.ForegroundSecondaryColour;
                    return hashCode;
                }
            }
        }
    }
}
