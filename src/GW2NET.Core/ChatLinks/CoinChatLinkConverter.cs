// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CoinChatLinkConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="Stream" /> to objects of type <see cref="CoinChatLink" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.ChatLinks
{
    using System;
    using System.IO;

    using GW2NET.Common;

    /// <summary>Converts objects of type <see cref="Stream"/> to objects of type <see cref="CoinChatLink"/>.</summary>
    public sealed class CoinChatLinkConverter : IConverter<Stream, CoinChatLink>, IConverter<CoinChatLink, Stream>
    {
        /// <inheritdoc />
        public CoinChatLink Convert(Stream value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            using (var reader = new BinaryReader(value))
            {
                return new CoinChatLink
                {
                    Quantity = reader.ReadInt32()
                };
            }
        }

        /// <inheritdoc />
        public Stream Convert(CoinChatLink value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            var stream = new MemoryStream();
            var buffer = new MemoryStream();
            using (var writer = new BinaryWriter(buffer))
            {
                writer.Write((byte)1);
                writer.Write(value.Quantity);
                buffer.WriteTo(stream);
            }

            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }
    }
}