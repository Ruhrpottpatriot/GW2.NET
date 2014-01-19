// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Material.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Drawing;
using Newtonsoft.Json;
using JsonColorConverter = GW2DotNET.V1.Core.Converters.ColorConverter;

namespace GW2DotNET.V1.Core.Colors
{
    /// <summary>
    /// Represents a dye's color component information for a specific material.
    /// </summary>
    public class Material
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Material"/> class.
        /// </summary>
        public Material()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Material"/> class using the specified values.
        /// </summary>
        /// <param name="brightness">The brightness.</param>
        /// <param name="contrast">The contrast.</param>
        /// <param name="hue">The hue in the HSL color space.</param>
        /// <param name="saturation">The saturation in the HSL color space.</param>
        /// <param name="lightness">The lightness in the HSL color space.</param>
        /// <param name="rgb">The color.</param>
        public Material(int brightness, double contrast, int hue, double saturation, double lightness, Color rgb)
        {
            this.Brightness = brightness;
            this.Contrast = contrast;
            this.Hue = hue;
            this.Saturation = saturation;
            this.Lightness = lightness;
            this.RGB = rgb;
        }

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
        [JsonConverter(typeof(JsonColorConverter))]
        public Color RGB { get; set; }

        /// <summary>
        /// Gets or sets the saturation in the HSL color space.
        /// </summary>
        [JsonProperty("saturation", Order = 3)]
        public double Saturation { get; set; }

        /// <summary>
        /// Gets the JSON representation of this instance.
        /// </summary>
        /// <returns>Returns a JSON <see cref="System.String"/>.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// Gets the JSON representation of this instance.
        /// </summary>
        /// <param name="indent">A value that indicates whether to indent the output.</param>
        /// <returns>Returns a JSON <see cref="System.String"/>.</returns>
        public string ToString(bool indent)
        {
            return JsonConvert.SerializeObject(this, indent ? Formatting.Indented : Formatting.None);
        }
    }
}