// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GwColour.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the GwColour type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Newtonsoft.Json;

namespace GW2DotNET.V1.Items.Models
{
    /// <summary>Represents a colour in the game.</summary>
    public partial class GwColour : IEquatable<GwColour>
    {
        /// <summary>The colour id.</summary>
        private readonly int id;

        /// <summary>Initializes a new instance of the <see cref="GwColour"/> class.</summary>
        /// <param name="id">The colour id.</param>
        /// <param name="name">The name of the colour</param>
        /// <param name="baseRgb">The base Rgb.</param>
        /// <param name="clothDetail">The colour modifying attributes on cloth.</param>
        /// <param name="leatherDetail">The  colour modifying attributes on leather.</param>
        /// <param name="metalDetail">The colour modifying attributes on metal.</param>
        [JsonConstructor]
        public GwColour(int id, string name, int[] baseRgb, ColourDetails clothDetail, ColourDetails leatherDetail, ColourDetails metalDetail)
        {
            this.id = id;
            this.Name = name;
            this.BaseRgb = baseRgb;
            this.Cloth = clothDetail;
            this.Leather = leatherDetail;
            this.Metal = metalDetail;
        }

        /// <summary>Gets the colour id.</summary>
        public int Id
        {
            get
            {
                return this.id;
            }
        }

        /// <summary>Gets the name.</summary>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>Gets the base rgb.</summary>
        [JsonProperty("base_rgb")]
        public int[] BaseRgb { get; private set; }

        /// <summary>Gets the colour modifying attributes on cloth.</summary>
        [JsonProperty("cloth")]
        public ColourDetails Cloth { get; private set; }

        /// <summary>Gets the colour modifying attributes on leather.</summary>
        [JsonProperty("leather")]
        public ColourDetails Leather { get; private set; }

        /// <summary>Gets the colour modifying attributes on metal.</summary>
        [JsonProperty("metal")]
        public ColourDetails Metal { get; private set; }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(GwColour other)
        {
            if ((object)other == null)
            {
                return false;
            }

            return other.Id == this.Id;
        }

        /// <summary>Checks if two instances of <see cref="GwColour" /> are equal.</summary>
        /// <param name="colourA">The first colour.</param>
        /// <param name="colourB">The second colour.</param>
        /// <returns>true if both instances are the same, otherwise false.</returns>
        public static bool operator ==(GwColour colourA, GwColour colourB)
        {
            if (ReferenceEquals(colourA, colourB))
            {
                return true;
            }

            if (((object)colourA == null) || ((object)colourB == null))
            {
                return false;
            }

            return colourA.Id == colourB.Id;
        }

        /// <summary>Checks if two instances of <see cref="GwColour" /> are not equal.</summary>
        /// <param name="colourA">The first colour.</param>
        /// <param name="colourB">The second colour.</param>
        /// <returns>true if both instances are not the same, otherwise false.</returns>
        public static bool operator !=(GwColour colourA, GwColour colourB)
        {
            return !(colourA == colourB);
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
            GwColour colour = obj as GwColour;

            if ((object)colour == null)
            {
                return false;
            }

            return colour.Id == this.Id;
        }

        /// <summary>Serves as a hash function for a particular type.</summary>
        /// <returns>A hash code for the current <see cref="T:System.Object" />.</returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }
    }
}