// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemChatLinkConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides a type converter to convert string objects to and from its <see cref="ItemChatLink" /> representation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.ChatLinks
{
    using System;
    using System.Diagnostics.Contracts;

    using GW2DotNET.Common;

    /// <summary>Provides a type converter to convert string objects to and from its <see cref="ItemChatLink"/> representation.</summary>
    [ConverterFor(typeof(ItemChatLink))]
    internal class ItemChatLinkConverter : ChatLinkConverter
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
        protected override ChatLink ConvertFromBytes(byte[] bytes)
        {
            var chatLink = new ItemChatLink();
            var buffer = new byte[64];
            var index = 0;

            // Copy up to the first 64 bytes to the buffer
            Buffer.BlockCopy(bytes, index, buffer, index, Math.Min(bytes.Length, buffer.Length));

            // Get a value that indicates the item quanitity
            var quantity = Buffer.GetByte(buffer, index);
            if (quantity > 0)
            {
                chatLink.Quantity = quantity;
            }

            index += sizeof(byte);

            // Get a value that indicates the item flags
            var flags = Buffer.GetByte(buffer, 4);

            // Clear the flags before trying to read the item identifier
            if (flags != 0)
            {
                Buffer.SetByte(buffer, 4, 0);
            }

            // Get a value that indicates the item identifier
            chatLink.ItemId = BitConverter.ToInt32(buffer, index);
            index += sizeof(int);

            // Get a value that indicates the skin identifier
            int skinId;
            if (HasFlag(flags, 0x80) && TryGetModifier(buffer, ref index, out skinId))
            {
                chatLink.SkinId = skinId;
            }

            // Get a value that indicates the upgrade identifier
            int suffixItemId;
            if (HasFlag(flags, 0x40) && TryGetModifier(buffer, ref index, out suffixItemId))
            {
                chatLink.SuffixItemId = suffixItemId;
            }

            // Get a value that indicates the secondary upgrade identifier
            int secondarySuffixItemId;
            if (HasFlag(flags, 0x20) && TryGetModifier(buffer, ref index, out secondarySuffixItemId))
            {
                chatLink.SecondarySuffixItemId = secondarySuffixItemId;
            }

            int unknownModifier10;
            int unknownSecondaryModifier10;
            if (HasFlag(flags, 0x10) && TryGetModifier(buffer, ref index, out unknownModifier10)
                && TryGetModifier(buffer, ref index, out unknownSecondaryModifier10))
            {
                // TODO: discover the meaning of flag 0x10
            }

            int unknownModifier8;
            int unknownSecondaryModifier8;
            if (HasFlag(flags, 0x08) && TryGetModifier(buffer, ref index, out unknownModifier8)
                && TryGetModifier(buffer, ref index, out unknownSecondaryModifier8))
            {
                // TODO: discover the meaning of flag 0x08
            }

            return chatLink;
        }

        /// <summary>Converts the given chat link to a byte array.</summary>
        /// <param name="value">The chat link.</param>
        /// <returns>A byte array.</returns>
        protected override byte[] ConvertToBytes(ChatLink value)
        {
            var chatLink = (ItemChatLink)value;
            var buffer = new byte[64];
            const int Flags = 4;
            var index = 0;

            // Set a value that indicates the item quanitity
            Buffer.SetByte(buffer, index, (byte)chatLink.Quantity);
            index += sizeof(byte);

            // Set a value that indicates the item identifier
            Buffer.BlockCopy(BitConverter.GetBytes(chatLink.ItemId), 0, buffer, index, 3);
            index += sizeof(int);

            // Set the skin modifier
            if (chatLink.SkinId.HasValue && TrySetModifier(buffer, ref index, chatLink.SkinId.Value))
            {
                SetFlag(ref buffer[Flags], 0x80);
            }

            // Set the upgrade modifier
            if (chatLink.SuffixItemId.HasValue && TrySetModifier(buffer, ref index, chatLink.SuffixItemId.Value))
            {
                SetFlag(ref buffer[Flags], 0x40);
            }

            // Set the secondary upgrade modifier
            if (chatLink.SecondarySuffixItemId.HasValue && TrySetModifier(buffer, ref index, chatLink.SecondarySuffixItemId.Value))
            {
                SetFlag(ref buffer[Flags], 0x20);
            }

            // Trim the size of the buffer
            Array.Resize(ref buffer, index);

            // Return the bytes
            return buffer;
        }

        /// <summary>Infrastructure. Gets whether the given byte contains the specified bit flag.</summary>
        /// <param name="flags">The byte.</param>
        /// <param name="flag">The bit flag.</param>
        /// <returns>true if the bit flag is set; otherwise, false.</returns>
        private static bool HasFlag(byte flags, byte flag)
        {
            return (flags & flag) == flag;
        }

        /// <summary>Infrastructure. Turns on the specified bit flag in a given byte.</summary>
        /// <param name="flags">The byte.</param>
        /// <param name="flag">The bit flag.</param>
        private static void SetFlag(ref byte flags, byte flag)
        {
            flags |= flag;
        }

        /// <summary>Infrastructure. Gets an item modifier from a byte array starting at the given index. A return value indicates whether the modifier could be retrieved.</summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="index">The start index.</param>
        /// <param name="modifier">The modifier.</param>
        /// <returns>true if the modifier could be retrieved; otherwise, false.</returns>
        private static bool TryGetModifier(byte[] bytes, ref int index, out int modifier)
        {
            Contract.Requires(bytes != null);
            Contract.Requires(index >= 0);
            Contract.Ensures(index >= Contract.OldValue(index));

            // Ensure that the specified index is not closer to the end of the array than there are bytes in an int
            if ((index + sizeof(int)) >= bytes.Length)
            {
                // Reset the output parameter to its default value
                modifier = default(int);

                // Return an error result
                return false;
            }

            // Get the modifier starting at the specified position
            modifier = BitConverter.ToInt32(bytes, index);

            // Set the position to right after that value
            index += sizeof(int);

            // Return a success result
            return true;
        }

        /// <summary>Infrastructure. Inserts an item modifier into a byte array at the given index. A return value indicates whether the modifier could be inserted.</summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="index">The start index.</param>
        /// <param name="modifier">The modifier.</param>
        /// <returns>true if the modifier could be inserted; otherwise, false.</returns>
        private static bool TrySetModifier(byte[] bytes, ref int index, int modifier)
        {
            Contract.Requires(bytes != null);
            Contract.Requires(index >= 0);
            Contract.Ensures(index >= Contract.OldValue(index));
            if (index > (bytes.Length - sizeof(int)))
            {
                return false;
            }

            var buffer = BitConverter.GetBytes(modifier);
            Buffer.BlockCopy(buffer, 0, bytes, index, sizeof(int));
            index += sizeof(int);
            return true;
        }
    }
}