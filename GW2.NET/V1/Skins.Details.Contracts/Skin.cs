// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Skin.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an in-game item skin.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Skins.Details.Contracts
{
    using System;
    using System.Globalization;
    using System.Runtime.Serialization;

    using GW2DotNET.Common;
    using GW2DotNET.Common.Contracts;
    using GW2DotNET.V1.Items.Details.Contracts;

    /// <summary>Represents an in-game item skin.</summary>
    public abstract class Skin : JsonObject, IEquatable<Skin>, IComparable<Skin>, IRenderable
    {
        /// <summary>Gets or sets the skin's description.</summary>
        [DataMember(Name = "description", Order = 7)]
        public string Description { get; set; }

        /// <summary>Gets or sets the skin's icon identifier for use with the render service.</summary>
        [DataMember(Name = "icon_file_id", Order = 5)]
        public int FileId { get; set; }

        /// <summary>Gets or sets the skin's icon signature for use with the render service.</summary>
        [DataMember(Name = "icon_file_signature", Order = 6)]
        public string FileSignature { get; set; }

        /// <summary>Gets or sets the skin's additional flags.</summary>
        [DataMember(Name = "flags", Order = 3)]
        public SkinFlags Flags { get; set; }

        /// <summary>Gets or sets the language info.</summary>
        [DataMember(Name = "lang", Order = 8)]
        public CultureInfo Language { get; set; }

        /// <summary>Gets or sets the skin's name.</summary>
        [DataMember(Name = "name", Order = 1)]
        public string Name { get; set; }

        /// <summary>Gets or sets the skin's restrictions.</summary>
        [DataMember(Name = "restrictions", Order = 4)]
        public ItemRestrictions Restrictions { get; set; }

        /// <summary>Gets or sets the skin's identifier.</summary>
        [DataMember(Name = "skin_id", Order = 0)]
        public int SkinId { get; set; }

        /// <summary>Indicates whether an object is equal to another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter is equal to the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator ==(Skin left, Skin right)
        {
            return object.Equals(left, right);
        }

        /// <summary>Indicates whether an object differs from another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter differs from the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator !=(Skin left, Skin right)
        {
            return !object.Equals(left, right);
        }

        /// <summary>Compares the current object with another object of the same type.</summary>
        /// <returns>A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than<paramref name="other"/>.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public int CompareTo(Skin other)
        {
            if (other == null)
            {
                return 1;
            }

            return this.SkinId.CompareTo(other.SkinId);
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(Skin other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return this.SkinId == other.SkinId;
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

            return this.Equals((Skin)obj);
        }

        /// <summary>Serves as a hash function for a particular type.</summary>
        /// <returns>A hash code for the current <see cref="T:System.Object" />.</returns>
        public override int GetHashCode()
        {
            return this.SkinId;
        }
    }
}