// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Skin.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an in-game item skin.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Skins
{
    using System;
    using System.Diagnostics;
    using System.Globalization;

    using GW2NET.ChatLinks;
    using GW2NET.Common;
    using GW2NET.Items;

    /// <summary>Represents an in-game item skin.</summary>
    public abstract class Skin : IEquatable<Skin>, IRenderable, ILocalizable
    {
        /// <summary>Gets or sets the locale.</summary>
        public virtual CultureInfo Culture { get; set; }

        /// <summary>Gets or sets the skin's description.</summary>
        public virtual string Description { get; set; }

        /// <summary>Gets or sets the skin's additional flags.</summary>
        public virtual SkinFlags Flags { get; set; }

        /// <summary>Gets or sets the skin's icon identifier for use with the render service.</summary>
        public virtual int IconFileId { get; set; }

        /// <summary>Gets or sets the skin's icon signature for use with the render service.</summary>
        public virtual string IconFileSignature { get; set; }

        /// <summary>Gets or sets the icon file URL.</summary>
        public virtual Uri IconFileUrl { get; set; }

        /// <summary>Gets or sets the name of the skin.</summary>
        public virtual string Name { get; set; }

        /// <summary>Gets or sets the skin's restrictions.</summary>
        public virtual ItemRestrictions Restrictions { get; set; }

        /// <summary>Gets or sets the skin identifier.</summary>
        public virtual int SkinId { get; set; }

        /// <inheritdoc />
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        int IRenderable.FileId
        {
            get
            {
                return this.IconFileId;
            }
        }

        /// <inheritdoc />
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        string IRenderable.FileSignature
        {
            get
            {
                return this.IconFileSignature;
            }
        }

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

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public virtual bool Equals(Skin other)
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

        /// <summary>Gets a skin chat link for this item skin.</summary>
        /// <returns>The <see cref="ChatLink"/>.</returns>
        public virtual ChatLink GetSkinChatLink()
        {
            return new SkinChatLink
            {
                SkinId = this.SkinId
            };
        }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            var name = this.Name;
            if (!string.IsNullOrEmpty(name))
            {
                return name;
            }

            return this.SkinId.ToString(NumberFormatInfo.InvariantInfo);
        }
    }
}
