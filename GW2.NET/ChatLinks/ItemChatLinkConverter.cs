// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemChatLinkConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides a type converter to convert string objects to and from its <see cref="RecipeChatLink" /> representation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.ChatLinks
{
    using System;

    /// <summary>Provides a type converter to convert string objects to and from its <see cref="ItemChatLink"/> representation.</summary>
    internal class ItemChatLinkConverter : ChatLinkConverter<ItemChatLink>
    {
        /// <summary>Gets the chat link header.</summary>
        protected override byte Header
        {
            get
            {
                return 0x2;
            }
        }

        /// <summary>Converts the given byte array to the specified chat link type.</summary>
        /// <param name="bytes">The byte array.</param>
        /// <returns>A chat link.</returns>
        protected override ItemChatLink ConvertFromBytes(byte[] bytes)
        {
            var chatLink = new ItemChatLink();
            var index = 0;
            chatLink.Quantity = Buffer.GetByte(bytes, index++);
            var modifiers = Buffer.GetByte(bytes, index + 3);
            Buffer.SetByte(bytes, index + 3, 0);
            chatLink.ItemId = BitConverter.ToInt32(bytes, index);
            index += 4;
            if ((modifiers & 0x80) == 0x80)
            {
                chatLink.SkinId = BitConverter.ToInt32(bytes, index);
                index += 4;
            }

            if ((modifiers & 0x40) == 0x40)
            {
                chatLink.SuffixItemId = BitConverter.ToInt32(bytes, index);
                index += 4;
            }

            if ((modifiers & 0x20) == 0x20)
            {
                chatLink.SecondarySuffixItemId = BitConverter.ToInt32(bytes, index);
                index += 4;
            }

            return chatLink;
        }

        /// <summary>Converts the given chat link to a byte array.</summary>
        /// <param name="value">The chat link.</param>
        /// <returns>A byte array.</returns>
        protected override byte[] ConvertToBytes(ItemChatLink value)
        {
            var buffer = new byte[17];
            var index = 0;
            Buffer.SetByte(buffer, index++, (byte)value.Quantity);
            byte modifiers = 0;
            Buffer.BlockCopy(BitConverter.GetBytes(value.ItemId), 0, buffer, index, 3);
            index += 3;
            var modifiersIndex = index++;
            if (value.SkinId.HasValue)
            {
                modifiers |= 0x80;
                Buffer.BlockCopy(BitConverter.GetBytes(value.SkinId.Value), 0, buffer, index, 4);
                index += 4;
            }

            if (value.SuffixItemId.HasValue)
            {
                modifiers |= 0x40;
                Buffer.BlockCopy(BitConverter.GetBytes(value.SuffixItemId.Value), 0, buffer, index, 4);
                index += 4;
            }

            if (value.SecondarySuffixItemId.HasValue)
            {
                modifiers |= 0x20;
                Buffer.BlockCopy(BitConverter.GetBytes(value.SecondarySuffixItemId.Value), 0, buffer, index, 4);
                index += 4;
            }

            Buffer.SetByte(buffer, modifiersIndex, modifiers);
            Array.Resize(ref buffer, index);
            return buffer;
        }
    }
}
