// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GwColour.ColourDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the GwColour type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace GW2DotNET.V1.Items.Models
{
    /// <summary>
    /// Represents a colour in the game.
    /// </summary>
    public partial struct GwColour
    {
        /// <summary>
        /// The colour modifying attributes.
        /// </summary>
        public struct ColourDetails
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ColourDetails"/> struct.
            /// </summary>
            /// <param name="brightness">
            /// The brightness.
            /// </param>
            /// <param name="contrast">
            /// The contrast.
            /// </param>
            /// <param name="hue">
            /// The hue.
            /// </param>
            /// <param name="saturation">
            /// The saturation.
            /// </param>
            /// <param name="lightness">
            /// The lightness.
            /// </param>
            [JsonConstructor]
            public ColourDetails(double brightness, double contrast, double hue, double saturation, double lightness) : this()
            {
                this.Lightness = lightness;
                this.Saturation = saturation;
                this.Hue = hue;
                this.Contrast = contrast;
                this.Brightness = brightness;
            }

            /// <summary>
            /// Gets the brightness.
            /// </summary>
            [JsonProperty("brightness")]
            public double Brightness
            {
                get;
                private set;
            }

            /// <summary>
            /// Gets the contrast.
            /// </summary>
            [JsonProperty("contrast")]
            public double Contrast
            {
                get;
                private set;
            }

            /// <summary>
            /// Gets the hue.
            /// </summary>
            [JsonProperty("hue")]
            public double Hue
            {
                get;
                private set;
            }

            /// <summary>
            /// Gets the saturation.
            /// </summary>
            [JsonProperty("saturation")]
            public double Saturation
            {
                get;
                private set;
            }

            /// <summary>
            /// Gets the lightness.
            /// </summary>
            [JsonProperty("lightness")]
            public double Lightness
            {
                get;
                private set;
            }
        }
    }
}
