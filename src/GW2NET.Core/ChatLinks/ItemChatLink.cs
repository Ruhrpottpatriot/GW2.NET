// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemChatLink.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a chat link that links to an item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.ChatLinks
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    using GW2NET.ChatLinks.Interop;

    /// <summary>Represents a chat link that links to an item.</summary>
    public class ItemChatLink : ChatLink
    {
        private int quantity = 1;

        /// <summary>Gets or sets the item identifier.</summary>
        public int ItemId { get; set; }

        /// <summary>Gets or sets an item quantity between 1 and 255, both inclusive.</summary>
        public int Quantity
        {
            get
            {
                Debug.Assert(this.quantity > 0, "this.quantity > 0");
                Debug.Assert(this.quantity < 256, "this.quantity < 256");
                return this.quantity;
            }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Precondition: value > 0");
                }

                if (value > 255)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Precondition: value < 256");
                }

                this.quantity = value;
            }
        }

        /// <summary>Gets or sets the secondary upgrade identifier.</summary>
        public int? SecondarySuffixItemId { get; set; }

        /// <summary>Gets or sets the skin identifier.</summary>
        public int? SkinId { get; set; }

        /// <summary>Gets or sets the upgrade identifier.</summary>
        public int? SuffixItemId { get; set; }

        protected override int CopyTo(ChatLinkStruct value)
        {
            value.header = Header.Item;
            value.item.count = (byte)this.Quantity;
            value.item.itemId = new UInt24((uint)this.ItemId);
            var modifiers = new Queue<int>(3);
            if (this.SkinId.HasValue)
            {
                modifiers.Enqueue(this.SkinId.Value);
                value.item.Modifiers |= ItemModifiers.Skin;
            }

            if (this.SuffixItemId.HasValue)
            {
                modifiers.Enqueue(this.SuffixItemId.Value);
                value.item.Modifiers |= ItemModifiers.SuffixItem;
            }

            if (this.SecondarySuffixItemId.HasValue)
            {
                modifiers.Enqueue(this.SecondarySuffixItemId.Value);
                value.item.Modifiers |= ItemModifiers.SecondarySuffixItem;
            }

            if (modifiers.Count == 0)
            {
                return 6;
            }

            value.item.modifier1 = modifiers.Dequeue();
            if (modifiers.Count == 0)
            {
                return 10;
            }

            value.item.modifier2 = modifiers.Dequeue();
            if (modifiers.Count == 0)
        {
                return 14;
            }

            value.item.modifier3 = modifiers.Dequeue();
            return 18;
        }
    }
}