// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DialogChatLinkConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="Stream" /> to objects of type <see cref="DialogChatLink" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.ChatLinks
{
    using System;
    using System.IO;

    using GW2NET.Common;

    /// <summary>Converts objects of type <see cref="Stream"/> to objects of type <see cref="DialogChatLink"/>.</summary>
    public sealed class DialogChatLinkConverter : IConverter<Stream, DialogChatLink>, IConverter<DialogChatLink, Stream>
    {
        /// <inheritdoc />
        public DialogChatLink Convert(Stream value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            using (var reader = new BinaryReader(value))
            {
                return new DialogChatLink
                {
                    DialogId = reader.ReadInt16()
                };
            }
        }

        /// <inheritdoc />
        public Stream Convert(DialogChatLink value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            var stream = new MemoryStream();
            var buffer = new MemoryStream();
            using (var writer = new BinaryWriter(buffer))
            {
                writer.Write((byte)3);
                writer.Write(value.DialogId);
                buffer.WriteTo(stream);
            }

            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }
    }
}