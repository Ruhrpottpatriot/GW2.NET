// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Objective.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents one of a World versus World map's objectives.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.WorldVersusWorld
{
    using System;
    using System.Globalization;

    using GW2NET.Common.Drawing;

    /// <summary>Represents one of a World versus World map's objectives.</summary>
    public class Objective : IEquatable<Objective>
    {
        /// <summary>Gets or sets the type of the objective.</summary>
        public virtual string Type { get; set; }

        /// <summary>Gets or sets the locale.</summary>
        public virtual CultureInfo Culture { get; set; }

        /// <summary>Gets or sets the name of the objective. This is a navigation property. Use the value of <see cref="ObjectiveId"/> to obtain a reference.</summary>
        public virtual string Name { get; set; }

        /// <summary>Gets or sets the objective identifier.</summary>
        public virtual string ObjectiveId { get; set; }

        /// <summary>Gets or sets the sector id of the objective.</summary>
        public virtual string SectorId { get; set; }

        /// <summary>Gets or sets the id of the map containing the objective.</summary>
        public virtual int MapId { get; set; }

        /// <summary>Gets or sets the type of the map containing the objective.</summary>
        public virtual string MapType { get; set; }

        /// <summary>Gets or sets the coordinates of this objective within the map.</summary>
        public virtual Vector2D MapCoordinates { get; set; }

        /// <summary>Gets or sets the coordinates of this objective's label on the map.</summary>
        public virtual Vector2D LabelCoordinates { get; set; }

        /// <summary>Indicates whether an object is equal to another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter is equal to the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator ==(Objective left, Objective right)
        {
            return object.Equals(left, right);
        }

        /// <summary>Indicates whether an object differs from another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter differs from the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator !=(Objective left, Objective right)
        {
            return !object.Equals(left, right);
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public virtual bool Equals(Objective other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return this.ObjectiveId == other.ObjectiveId;
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

            return this.Equals((Objective)obj);
        }

        /// <summary>Serves as a hash function for a particular type.</summary>
        /// <returns>A hash code for the current <see cref="T:System.Object" />.</returns>
        public override int GetHashCode()
        {
            return this.ObjectiveId.GetHashCode();
        }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            var name = this.Name;
            if (name != null)
            {
                return name.ToString();
            }

            return this.ObjectiveId;
        }
    }
}