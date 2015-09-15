// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemQuantity.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a stack of items.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Items
{
    using System;
    using System.Diagnostics;
    using System.Globalization;

    using GW2NET.ChatLinks;

    /// <summary>Represents a stack of items.</summary>
    public class ItemQuantity
    {
        private int count = 1;

        /// <summary>Gets or sets the number of items in this stack.</summary>
        public virtual int Count
        {
            get
            {
                Debug.Assert(this.count > 0, "this.count > 0");
                return this.count;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("value", value, "Precondition: value > 0");
                }

                this.count = value;
            }
        }

        /// <summary>Gets or sets the item. This is a navigation property. Use the value of <see cref="ItemId"/> to obtain a reference.</summary>
        public virtual Item Item { get; set; }

        /// <summary>Gets or sets the item identifier.</summary>
        public virtual int ItemId { get; set; }

        /// <summary>Gets an item chat link for this item.</summary>
        /// <returns>The <see cref="ChatLink"/>.</returns>
        public virtual ChatLink GetItemChatLink()
        {
            ItemChatLink chatLink;
            var item = this.Item;
            if (item == null)
            {
                chatLink = new ItemChatLink { ItemId = this.ItemId };
            }
            else
            {
                chatLink = (ItemChatLink)item.GetItemChatLink();
            }

            chatLink.Quantity = this.Count;
            return chatLink;
        }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            var item = this.Item;
            if (item == null)
            {
                return this.ItemId.ToString(NumberFormatInfo.InvariantInfo);
            }

            if (this.Count == 1)
            {
                return item.ToString();
            }

            return string.Format("{0} {1}", this.Count, item);
        }
    }
}