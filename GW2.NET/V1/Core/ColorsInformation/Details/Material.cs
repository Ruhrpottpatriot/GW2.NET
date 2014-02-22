// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Material.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Drawing;
using Newtonsoft.Json;
using ColorConverter = GW2DotNET.V1.Core.Converters.ColorConverter;

namespace GW2DotNET.V1.Core.ColorsInformation.Details
{
    /// <summary>
    /// Represents a dye's color component information for a specific material.
    /// </summary>
    public class Material : JsonObject
    {
        /// <summary>
        /// Gets or sets the brightness.
        /// </summary>
        [JsonProperty("brightness", Order = 0)]
        public int Brightness { get; set; }

        /// <summary>
        /// Gets or sets the contrast.
        /// </summary>
        [JsonProperty("contrast", Order = 1)]
        public double Contrast { get; set; }

        /// <summary>
        /// Gets or sets the hue in the HSL color space.
        /// </summary>
        [JsonProperty("hue", Order = 2)]
        public int Hue { get; set; }

        /// <summary>
        /// Gets or sets the lightness in the HSL color space.
        /// </summary>
        [JsonProperty("lightness", Order = 4)]
        public double Lightness { get; set; }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        [JsonProperty("rgb", Order = 5)]
        [JsonConverter(typeof(ColorConverter))]
        public Color RGB { get; set; }

        /// <summary>
        /// Gets or sets the saturation in the HSL color space.
        /// </summary>
        [JsonProperty("saturation", Order = 3)]
        public double Saturation { get; set; }
    }
}