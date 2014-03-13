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
    using System;

    using Newtonsoft.Json;

    /// <summary>
    ///     Represents a guild's emblem.
    /// </summary>
    public class Emblem : JsonObject, IEquatable<Emblem>
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

        /// <summary>Gets or sets the guild.</summary>
        public Guild Guild { get; set; }

        /// <summary>
        ///     Indicates whether an object is equal to another object of the same type.
        /// </summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>
        ///     true if the <paramref name="left" /> parameter is equal to the <paramref name="right" /> parameter; otherwise,
        ///     false.
        /// </returns>
        public static bool operator ==(Emblem left, Emblem right)
        {
            return object.Equals(left, right);
        }

        /// <summary>
        ///     Indicates whether an object differs from another object of the same type.
        /// </summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>
        ///     true if the <paramref name="left" /> parameter differs from the <paramref name="right" /> parameter;
        ///     otherwise, false.
        /// </returns>
        public static bool operator !=(Emblem left, Emblem right)
        {
            return !object.Equals(left, right);
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(Emblem other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return this.BackgroundColorId == other.BackgroundColorId && this.BackgroundId == other.BackgroundId && this.Flags == other.Flags
                   && this.ForegroundId == other.ForegroundId && this.ForegroundPrimaryColorId == other.ForegroundPrimaryColorId
                   && this.ForegroundSecondaryColorId == other.ForegroundSecondaryColorId;
        }

        /// <summary>Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.</summary>
        /// <returns>true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.</returns>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>. </param>
        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(null, obj))
            {
                return false;
            }

            if (object.ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((Emblem)obj);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = this.BackgroundColorId;
                hashCode = (hashCode * 397) ^ this.BackgroundId;
                hashCode = (hashCode * 397) ^ (int)this.Flags;
                hashCode = (hashCode * 397) ^ this.ForegroundId;
                hashCode = (hashCode * 397) ^ this.ForegroundPrimaryColorId;
                hashCode = (hashCode * 397) ^ this.ForegroundSecondaryColorId;
                return hashCode;
            }
        }
    }
}