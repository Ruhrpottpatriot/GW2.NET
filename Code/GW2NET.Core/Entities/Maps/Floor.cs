// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Floor.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a map floor, used to populate a world map. All coordinates are map coordinates.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Entities.Maps
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;

    using GW2NET.Common;
    using GW2NET.Common.Drawing;

    /// <summary>Represents a map floor, used to populate a world map. All coordinates are map coordinates.</summary>
    /// <remarks>The returned data only contains static content. Dynamic content, such as vendors, is not currently available.</remarks>
    public class Floor : IEquatable<Floor>, ILocalizable
    {
        /// <summary>Gets or sets a rectangle of downloadable textures. Every tile coordinate outside of this rectangle is not available on the tile server.</summary>
        public virtual Rectangle? ClampedView { get; set; }

        /// <summary>Gets or sets the continent. This is a navigation property. Use the value of <see cref="ContinentId"/> to obtain a reference.</summary>
        public virtual Continent Continent { get; set; }

        /// <summary>Gets or sets the continent identifier.</summary>
        public virtual int ContinentId { get; set; }

        /// <summary>Gets or sets the locale.</summary>
        public CultureInfo Culture { get; set; }

        /// <summary>Gets or sets the floor identifier.</summary>
        public virtual int FloorId { get; set; }

        /// <summary>Gets or sets the collection of regions.</summary>
        public virtual IDictionary<int, Region> Regions { get; set; }

        /// <summary>Gets or sets the texture's dimensions.</summary>
        public virtual Size2D TextureDimensions { get; set; }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Operators do not require documentation.")]
        public static bool operator ==(Floor left, Floor right)
        {
            return object.Equals(left, right);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Operators do not require documentation.")]
        public static bool operator !=(Floor left, Floor right)
        {
            return !object.Equals(left, right);
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(Floor other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.ContinentId == other.ContinentId && this.FloorId == other.FloorId;
        }

        /// <summary>Determines whether the specified <see cref="T:System.Object"/> is equal to the current<see cref="T:System.Object"/>.</summary>
        /// <returns>true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.</returns>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>. </param>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((Floor)obj);
        }

        /// <summary>Serves as a hash function for a particular type.</summary>
        /// <returns>A hash code for the current <see cref="T:System.Object" />.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (this.ContinentId * 397) ^ this.FloorId;
            }
        }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return this.FloorId.ToString(NumberFormatInfo.InvariantInfo);
        }
    }
}