// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PointOfInterest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a Point of Interest (POI) location.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Maps
{
    using System;
    using System.Globalization;

    using GW2NET.ChatLinks;
    using GW2NET.Common.Drawing;

    /// <summary>Represents a Point of Interest (POI) location.</summary>
    public class PointOfInterest : IEquatable<PointOfInterest>
    {
        /// <summary>Gets or sets the coordinates of this Point of Interest.</summary>
        public virtual Vector2D Coordinates { get; set; }

        /// <summary>Gets or sets the floor of this Point of Interest.</summary>
        public virtual int Floor { get; set; }

        /// <summary>Gets or sets the name of this Point of Interest.</summary>
        public virtual string Name { get; set; }

        /// <summary>Gets or sets the Point of Interest identifier.</summary>
        public virtual int PointOfInterestId { get; set; }

        /// <summary>Indicates whether an object is equal to another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter is equal to the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator ==(PointOfInterest left, PointOfInterest right)
        {
            return object.Equals(left, right);
        }

        /// <summary>Indicates whether an object differs from another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter differs from the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator !=(PointOfInterest left, PointOfInterest right)
        {
            return !object.Equals(left, right);
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public virtual bool Equals(PointOfInterest other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return this.PointOfInterestId == other.PointOfInterestId;
        }

        /// <summary>Determines whether the specified <see cref="T:System.Object"/> is equal to the current<see cref="T:System.Object"/>.</summary>
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

            return this.Equals((PointOfInterest)obj);
        }

        /// <summary>Serves as a hash function for a particular type.</summary>
        /// <returns>A hash code for the current <see cref="T:System.Object" />.</returns>
        public override int GetHashCode()
        {
            return this.PointOfInterestId;
        }

        /// <summary>Gets a map chat link for this Point of Interest</summary>
        /// <returns>The <see cref="ChatLink"/>.</returns>
        public virtual ChatLink GetMapChatLink()
        {
            return new PointOfInterestChatLink
            {
                PointOfInterestId = this.PointOfInterestId
            };
        }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            var name = this.Name;
            if (name != null)
            {
                return name;
            }

            return this.PointOfInterestId.ToString(NumberFormatInfo.InvariantInfo);
        }
    }
}