// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemChatLink.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a chat link that links to an item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.ChatLinks
{
    using System;

    using GW2DotNET.Utilities;

    /// <summary>Represents a chat link that links to an item.</summary>
    public class ItemChatLink : ChatLink
    {
        /// <summary>The quantity.</summary>
        private int quantity;

        /// <summary>Initializes a new instance of the <see cref="ItemChatLink"/> class.</summary>
        /// <param name="itemId">The item identifier.</param>
        public ItemChatLink(int itemId)
            : base(ChatLinkType.Item)
        {
            this.ItemId = itemId;
            this.Quantity = 1;
        }

        /// <summary>Gets the item identifier.</summary>
        public int ItemId { get; private set; }

        /// <summary>Gets or sets the quantity.</summary>
        public int Quantity
        {
            get
            {
                return this.quantity;
            }

            set
            {
                Preconditions.EnsureInRange(value, 1, byte.MaxValue);
                this.quantity = value;
            }
        }

        /// <summary>Gets or sets the secondary upgrade identifier.</summary>
        public int? SecondarySuffixItemId { get; set; }

        /// <summary>Gets or sets the skin identifier.</summary>
        public int? SkinId { get; set; }

        /// <summary>Gets or sets the upgrade identifier.</summary>
        public int? SuffixItemId { get; set; }

        /// <summary>Gets the bytes.</summary>
        /// <returns>The <see cref="byte" /> array.</returns>
        protected override byte[] GetBytes()
        {
            var buffer = new byte[18];
            var index = 0;
            Buffer.SetByte(buffer, index++, (byte)this.Type);
            Buffer.SetByte(buffer, index++, (byte)this.Quantity);
            byte modifiers = 0;
            Buffer.BlockCopy(BitConverter.GetBytes(this.ItemId), 0, buffer, index, 3);
            index += 3;
            var modifiersIndex = index++;
            if (this.SkinId.HasValue)
            {
                modifiers |= 0x80;
                Buffer.BlockCopy(BitConverter.GetBytes(this.SkinId.Value), 0, buffer, index, 4);
                index += 4;
            }

            if (this.SuffixItemId.HasValue)
            {
                modifiers |= 0x40;
                Buffer.BlockCopy(BitConverter.GetBytes(this.SuffixItemId.Value), 0, buffer, index, 4);
                index += 4;
            }

            if (this.SecondarySuffixItemId.HasValue)
            {
                modifiers |= 0x20;
                Buffer.BlockCopy(BitConverter.GetBytes(this.SecondarySuffixItemId.Value), 0, buffer, index, 4);
                index += 4;
            }

            Buffer.SetByte(buffer, modifiersIndex, modifiers);
            Array.Resize(ref buffer, index);
            return buffer;
        }
    }
}