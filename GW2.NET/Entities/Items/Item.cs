// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Item.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for types that represent an in-game item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Entities.Items
{
    using System;
    using System.Globalization;

    using GW2DotNET.ChatLinks;
    using GW2DotNET.Common;

    /// <summary>Provides the base class for types that represent an in-game item.</summary>
    public abstract class Item : IRenderable, IEquatable<Item>
    {
        /// <summary>Gets or sets the item's build number.</summary>
        public virtual int BuildId { get; set; }

        /// <summary>Gets or sets the item's description.</summary>
        public virtual string Description { get; set; }

        /// <summary>Gets or sets the item's icon identifier for use with the render service.</summary>
        public virtual int FileId { get; set; }

        /// <summary>Gets or sets the item's icon signature for use with the render service.</summary>
        public virtual string FileSignature { get; set; }

        /// <summary>Gets or sets the item's additional flags.</summary>
        public virtual ItemFlags Flags { get; set; }

        /// <summary>Gets or sets the item's game types.</summary>
        public virtual GameTypes GameTypes { get; set; }

        /// <summary>Gets or sets the item's identifier.</summary>
        public virtual int ItemId { get; set; }

        /// <summary>Gets or sets the language.</summary>
        public virtual string Language { get; set; }

        /// <summary>Gets or sets the item's level.</summary>
        public virtual int Level { get; set; }

        /// <summary>Gets or sets the name of the item.</summary>
        public virtual string Name { get; set; }

        /// <summary>Gets or sets the item's rarity.</summary>
        public virtual ItemRarity Rarity { get; set; }

        /// <summary>Gets or sets the item's restrictions.</summary>
        public virtual ItemRestrictions Restrictions { get; set; }

        /// <summary>Gets or sets the item's vendor value.</summary>
        public virtual int VendorValue { get; set; }

        /// <summary>Indicates whether an object is equal to another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter is equal to the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator ==(Item left, Item right)
        {
            return object.Equals(left, right);
        }

        /// <summary>Indicates whether an object differs from another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter differs from the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator !=(Item left, Item right)
        {
            return !object.Equals(left, right);
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public virtual bool Equals(Item other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return this.ItemId == other.ItemId;
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

            return this.Equals((Item)obj);
        }

        /// <summary>Serves as a hash function for a particular type.</summary>
        /// <returns>A hash code for the current <see cref="T:System.Object" />.</returns>
        public override int GetHashCode()
        {
            return this.ItemId;
        }

        /// <summary>Gets an item chat link for this item.</summary>
        /// <returns>The <see cref="ChatLink"/>.</returns>
        public virtual ChatLink GetItemChatLink()
        {
            return new ItemChatLink { ItemId = this.ItemId };
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

            return this.ItemId.ToString(NumberFormatInfo.InvariantInfo);
        }
    }
}