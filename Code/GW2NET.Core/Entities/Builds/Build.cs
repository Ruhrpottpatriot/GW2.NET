// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Build.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents the current build of the game.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Entities.Builds
{
    using System;
    using System.Globalization;

    /// <summary>Represents the current build of the game.</summary>
    /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/build" /> for more information.</remarks>
    public class Build : IEquatable<Build>, IComparable<Build>
    {
        /// <summary>Gets or sets the current build identifier of the game.</summary>
        public virtual int BuildId { get; set; }

        /// <summary>Gets or sets a timestamp for this build.</summary>
        public virtual DateTimeOffset Timestamp { get; set; }

        /// <summary>Indicates whether an object is equal to another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter is equal to the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator ==(Build left, Build right)
        {
            return object.Equals(left, right);
        }

        /// <summary>Indicates whether a build is greater than another.</summary>
        /// <param name="left">The build on the left side.</param>
        /// <param name="right">The build on the right side.</param>
        /// <returns>true if the <paramref name="left" /> build is greater than the <paramref name="right" /> build; otherwise, false</returns>
        public static bool operator >(Build left, Build right)
        {
            if (left == null)
            {
                return false;
            }

            if (right == null)
            {
                return true;
            }

            return left.BuildId > right.BuildId;
        }

        /// <summary>Indicates whether a build is greater or equal to another.</summary>
        /// <param name="left">The build on the left side.</param>
        /// <param name="right">The build on the right side.</param>
        /// <returns>true if the <paramref name="left" /> build is greater or equal to the <paramref name="right" /> build; otherwise, false</returns>
        public static bool operator >=(Build left, Build right)
        {
            if (left == null)
            {
                return false;
            }

            if (right == null)
            {
                return true;
            }

            return left.BuildId >= right.BuildId;
        }

        /// <summary>Indicates whether an object differs from another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter differs from the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator !=(Build left, Build right)
        {
            return !object.Equals(left, right);
        }

        /// <summary>Indicates whether a build is greater than another.</summary>
        /// <param name="left">The build on the left side.</param>
        /// <param name="right">The build on the right side.</param>
        /// <returns>true if the <paramref name="left" /> build is smaller than the <paramref name="right" /> build; otherwise, false</returns>
        public static bool operator <(Build left, Build right)
        {
            if (left == null)
            {
                return true;
            }

            if (right == null)
            {
                return false;
            }

            return left.BuildId < right.BuildId;
        }

        /// <summary>Indicates whether a build is smaller or equal to another.</summary>
        /// <param name="left">The build on the left side.</param>
        /// <param name="right">The build on the right side.</param>
        /// <returns>true if the <paramref name="left" /> build is smaller or equal to the <paramref name="right" /> build; otherwise, false</returns>
        public static bool operator <=(Build left, Build right)
        {
            if (left == null)
            {
                return true;
            }

            if (right == null)
            {
                return false;
            }

            return left.BuildId <= right.BuildId;
        }

        /// <summary>Compares the current object with another object of the same type.</summary>
        /// <returns>A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than<paramref name="other"/>.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public virtual int CompareTo(Build other)
        {
            return other == null ? 1 : this.BuildId.CompareTo(other.BuildId);
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public virtual bool Equals(Build other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return this.BuildId == other.BuildId;
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

            return this.Equals((Build)obj);
        }

        /// <summary>Serves as a hash function for a particular type.</summary>
        /// <returns>A hash code for the current <see cref="T:System.Object" />.</returns>
        public override int GetHashCode()
        {
            return this.BuildId;
        }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return this.BuildId.ToString(NumberFormatInfo.InvariantInfo);
        }
    }
}