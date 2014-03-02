// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GwColour.ColourDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the GwColour type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace GW2DotNET.V1.Items.Models
{
    /// <summary>Represents a colour in the game.</summary>
    public partial class GwColour
    {
        /// <summary>The colour modifying attributes.</summary>
        public class ColourDetails : IEquatable<ColourDetails>
        {
            /// <summary>Initializes a new instance of the <see cref="ColourDetails"/> class.</summary>
            /// <param name="brightness">The brightness.</param>
            /// <param name="contrast">The contrast.</param>
            /// <param name="hue">The hue.</param>
            /// <param name="saturation">The saturation.</param>
            /// <param name="lightness">The lightness.</param>
            /// <param name="rgb">Pre calculated rgb values for some convenience.</param>
            [JsonConstructor]
            public ColourDetails(double brightness, double contrast, double hue, double saturation, double lightness, IList<int> rgb)
            {
                this.RgbValues = new RgbColour(rgb);
                this.Lightness = lightness;
                this.Saturation = saturation;
                this.Hue = hue;
                this.Contrast = contrast;
                this.Brightness = brightness;
            }

            /// <summary>Gets the brightness.</summary>
            [JsonProperty("brightness")]
            public double Brightness { get; private set; }

            /// <summary>Gets the contrast.</summary>
            [JsonProperty("contrast")]
            public double Contrast { get; private set; }

            /// <summary>Gets the hue.</summary>
            [JsonProperty("hue")]
            public double Hue { get; private set; }

            /// <summary>Gets the saturation.</summary>
            [JsonProperty("saturation")]
            public double Saturation { get; private set; }

            /// <summary>Gets the lightness.</summary>
            [JsonProperty("lightness")]
            public double Lightness { get; private set; }

            /// <summary>Gets the rgb values.</summary>
            public RgbColour RgbValues { get; private set; }

            /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
            /// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
            /// <param name="other">An object to compare with this object.</param>
            public bool Equals(ColourDetails other)
            {
                if ((object)other == null)
                {
                    return false;
                }

                return other.RgbValues == this.RgbValues;
            }

            /// <summary>Checks two colour details for equality.</summary>
            /// <param name="detailsA">The details a.</param>
            /// <param name="detailsB">The details b.</param>
            /// <returns>True if both colour details are equal.</returns>
            public static bool operator ==(ColourDetails detailsA, ColourDetails detailsB)
            {
                if (ReferenceEquals(detailsA, detailsB))
                {
                    return true;
                }

                if (((object)detailsA == null) || ((object)detailsB == null))
                {
                    return false;
                }

                return detailsA.RgbValues == detailsB.RgbValues;
            }

            /// <summary>Checks two colour details for inequality.</summary>
            /// <param name="detailsA">The details a.</param>
            /// <param name="detailsB">The details b.</param>
            /// <returns>True if both colour details are not equal.</returns>
            public static bool operator !=(ColourDetails detailsA, ColourDetails detailsB)
            {
                return !(detailsA == detailsB);
            }

            /// <summary>Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.</summary>
            /// <returns>true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.</returns>
            /// <param name="obj">The object to compare with the current object. </param>
            /// <filterpriority>2</filterpriority>
            public override bool Equals(object obj)
            {
                // If parameter is null return false.
                if (obj == null)
                {
                    return false;
                }

                // If parameter cannot be cast to Point return false.
                ColourDetails colour = obj as ColourDetails;

                if ((object)colour == null)
                {
                    return false;
                }

                return colour.RgbValues == this.RgbValues;
            }

            /// <summary>Serves as a hash function for a particular type.</summary>
            /// <returns>A hash code for the current <see cref="T:System.Object" />.</returns>
            public override int GetHashCode()
            {
                return this.RgbValues.GetHashCode();
            }
        }
    }
}