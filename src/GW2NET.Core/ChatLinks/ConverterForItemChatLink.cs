// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForItemChatLink.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="Stream" /> to objects of type <see cref="ItemChatLink" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.ChatLinks
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using GW2NET.Common;

    /// <summary>Converts objects of type <see cref="Stream"/> to objects of type <see cref="ItemChatLink"/>.</summary>
    internal sealed class ConverterForItemChatLink : IConverter<Stream, ItemChatLink>, IConverter<ItemChatLink, Stream>
    {
        /// <inheritdoc />
        public ItemChatLink Convert(Stream value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            using (var reader = new BinaryReader(value))
            {
                var quantity = reader.ReadByte();
                var id = reader.ReadInt32() & 0xFFFFFF;
                reader.BaseStream.Seek(-1, SeekOrigin.Current);
                var flags = reader.ReadByte();
                var modifiers = new Stack<int>();
                while (reader.PeekChar() != -1)
                {
                    modifiers.Push(reader.ReadInt32());
                }

                var chatLink = new ItemChatLink
                {
                    ItemId = id, 
                    Quantity = quantity, 
                };

                if ((flags & 0x20) == 0x20)
                {
                    chatLink.SecondarySuffixItemId = modifiers.Pop();
                }

                if ((flags & 0x40) == 0x40)
                {
                    chatLink.SuffixItemId = modifiers.Pop();
                }

                if ((flags & 0x80) == 0x80)
                {
                    chatLink.SkinId = modifiers.Pop();
                }

                return chatLink;
            }
        }

        /// <inheritdoc />
        public Stream Convert(ItemChatLink value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var quantity = (byte)value.Quantity;
            var id = value.ItemId;
            byte flags = 0;
            var modifiers = new Stack<int>();
            if (value.SecondarySuffixItemId.HasValue)
            {
                modifiers.Push(value.SecondarySuffixItemId.Value);
                flags |= 0x20;
            }

            if (value.SuffixItemId.HasValue)
            {
                modifiers.Push(value.SuffixItemId.Value);
                flags |= 0x40;
            }

            if (value.SkinId.HasValue)
            {
                modifiers.Push(value.SkinId.Value);
                flags |= 0x80;
            }

            var stream = new MemoryStream();
            var buffer = new MemoryStream();
            using (var writer = new BinaryWriter(buffer))
            {
                writer.Write((byte)2);
                writer.Write(quantity);
                writer.Write(id);
                writer.Seek(-1, SeekOrigin.Current);
                writer.Write(flags);
                foreach (var modifier in modifiers)
                {
                    writer.Write(modifier);
                }

                buffer.WriteTo(stream);
            }

            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }
    }
}