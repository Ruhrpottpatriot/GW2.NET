// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Subregion.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a map and its details.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Entities.Maps
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    using GW2NET.Common.Drawing;

    /// <summary>Represents a map and its details.</summary>
    public class Subregion : IEquatable<Subregion>
    {
        /// <summary>Gets or sets the dimensions of the map within the continent coordinate system.</summary>
        public virtual Rectangle ContinentRectangle { get; set; }

        /// <summary>Gets or sets the default floor of this map.</summary>
        public virtual int DefaultFloor { get; set; }

        /// <summary>Gets or sets the map. This is a navigation property. Use the value of <see cref="MapId"/> to obtain a reference.</summary>
        public virtual Map Map { get; set; }

        /// <summary>Gets or sets the map identifier.</summary>
        public virtual int MapId { get; set; }

        /// <summary>Gets or sets the dimensions of the map.</summary>
        public virtual Rectangle MapRectangle { get; set; }

        /// <summary>Gets or sets the maximum level of this map.</summary>
        public virtual int MaximumLevel { get; set; }

        /// <summary>Gets or sets the minimum level of this map.</summary>
        public virtual int MinimumLevel { get; set; }

        /// <summary>Gets or sets the name of the map.</summary>
        public string Name { get; set; }

        /// <summary>Gets or sets a collection of Points of Interest locations.</summary>
        public virtual ICollection<PointOfInterest> PointsOfInterest { get; set; }

        /// <summary>Gets or sets a collection of areas within the map.</summary>
        public virtual ICollection<Sector> Sectors { get; set; }

        /// <summary>Gets or sets a collection of skill challenge locations.</summary>
        public virtual ICollection<SkillChallenge> SkillChallenges { get; set; }

        /// <summary>Gets or sets a collection of renown heart locations.</summary>
        public virtual ICollection<RenownTask> Tasks { get; set; }

        /// <summary>Indicates whether an object is equal to another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter is equal to the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator ==(Subregion left, Subregion right)
        {
            return object.Equals(left, right);
        }

        /// <summary>Indicates whether an object differs from another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter differs from the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator !=(Subregion left, Subregion right)
        {
            return !object.Equals(left, right);
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public virtual bool Equals(Subregion other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return object.Equals(this.MapId, other.MapId);
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

            return this.Equals((Subregion)obj);
        }

        /// <summary>Serves as a hash function for a particular type.</summary>
        /// <returns>A hash code for the current <see cref="T:System.Object" />.</returns>
        public override int GetHashCode()
        {
            return this.MapId.GetHashCode();
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

            return this.MapId.ToString(NumberFormatInfo.InvariantInfo);
        }
    }
}