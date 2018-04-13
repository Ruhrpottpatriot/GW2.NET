// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapName.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a map and its localized name.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Maps
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;

    using GW2NET.Common;

    /// <summary>Represents a map and its localized name.</summary>
    public class MapName : IEquatable<MapName>, ILocalizable
    {
        /// <summary>Gets or sets the locale.</summary>
        public virtual CultureInfo Culture { get; set; }

        /// <summary>Gets or sets the map identifier.</summary>
        public virtual int MapId { get; set; }

        /// <summary>Gets or sets the localized name of the map.</summary>
        public virtual string Name { get; set; }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Operators don't require an explanation.")]
        public static bool operator ==(MapName left, MapName right)
        {
            return object.Equals(left, right);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Operators don't require an explanation.")]
        public static bool operator !=(MapName left, MapName right)
        {
            return !object.Equals(left, right);
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(MapName other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.MapId == other.MapId;
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

            return this.Equals((MapName)obj);
        }

        /// <summary>Serves as a hash function for a particular type.</summary>
        /// <returns>A hash code for the current <see cref="T:System.Object" />.</returns>
        public override int GetHashCode()
        {
            return this.MapId;
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