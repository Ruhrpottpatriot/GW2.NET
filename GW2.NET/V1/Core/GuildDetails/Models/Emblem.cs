// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Emblem.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.GuildDetails.Models
{
    /// <summary>
    /// Represents a guild's emblem.
    /// </summary>
    public class Emblem : JsonObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Emblem"/> class.
        /// </summary>
        public Emblem()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Emblem"/> class.
        /// </summary>
        /// <param name="backgroundId">The background image ID.</param>
        /// <param name="foregroundId">The foreground image ID.</param>
        /// <param name="flags">The image transformation flags.</param>
        /// <param name="backgroundColorId">The background color ID.</param>
        /// <param name="foregroundPrimaryColorId">The primary foreground color ID.</param>
        /// <param name="foregroundSecondaryColorId">The secondary foreground color ID.</param>
        public Emblem(int backgroundId, int foregroundId, EmblemTransformations flags, int backgroundColorId, int foregroundPrimaryColorId, int foregroundSecondaryColorId)
        {
            this.BackgroundId = backgroundId;
            this.ForegroundId = foregroundId;
            this.Flags = flags;
            this.BackgroundColorId = backgroundColorId;
            this.ForegroundPrimaryColorId = foregroundPrimaryColorId;
            this.ForegroundSecondaryColorId = foregroundSecondaryColorId;
        }

        /// <summary>
        /// Gets or sets the background color ID.
        /// </summary>
        [JsonProperty("background_color_id", Order = 3)]
        public int BackgroundColorId { get; set; }

        /// <summary>
        /// Gets or sets the background image ID.
        /// </summary>
        [JsonProperty("background_id", Order = 0)]
        public int BackgroundId { get; set; }

        /// <summary>
        /// Gets or sets the image transformations, if any.
        /// </summary>
        [JsonProperty("flags", Order = 2)]
        public EmblemTransformations Flags { get; set; }

        /// <summary>
        /// Gets or sets the foreground image ID.
        /// </summary>
        [JsonProperty("foreground_id", Order = 1)]
        public int ForegroundId { get; set; }

        /// <summary>
        /// Gets or sets the primary foreground color ID.
        /// </summary>
        [JsonProperty("foreground_primary_color_id", Order = 4)]
        public int ForegroundPrimaryColorId { get; set; }

        /// <summary>
        /// Gets or sets the secondary foreground color ID.
        /// </summary>
        [JsonProperty("foreground_secondary_color_id", Order = 5)]
        public int ForegroundSecondaryColorId { get; set; }
    }
}