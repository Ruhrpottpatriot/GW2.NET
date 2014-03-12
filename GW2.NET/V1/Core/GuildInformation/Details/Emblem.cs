// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Emblem.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a guild's emblem.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.GuildInformation.Details
{
    using Newtonsoft.Json;

    /// <summary>
    ///     Represents a guild's emblem.
    /// </summary>
    public class Emblem : JsonObject
    {
        /// <summary>
        ///     Gets or sets the background color ID.
        /// </summary>
        [JsonProperty("background_color_id", Order = 3)]
        public int BackgroundColorId { get; set; }

        /// <summary>
        ///     Gets or sets the background image ID.
        /// </summary>
        [JsonProperty("background_id", Order = 0)]
        public int BackgroundId { get; set; }

        /// <summary>
        ///     Gets or sets the image transformations, if any.
        /// </summary>
        [JsonProperty("flags", Order = 2)]
        public EmblemTransformations Flags { get; set; }

        /// <summary>
        ///     Gets or sets the foreground image ID.
        /// </summary>
        [JsonProperty("foreground_id", Order = 1)]
        public int ForegroundId { get; set; }

        /// <summary>
        ///     Gets or sets the primary foreground color ID.
        /// </summary>
        [JsonProperty("foreground_primary_color_id", Order = 4)]
        public int ForegroundPrimaryColorId { get; set; }

        /// <summary>
        ///     Gets or sets the secondary foreground color ID.
        /// </summary>
        [JsonProperty("foreground_secondary_color_id", Order = 5)]
        public int ForegroundSecondaryColorId { get; set; }
    }
}