// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnknownChatLinkConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="Stream" /> to objects of type <see cref="UnknownChatLink" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.ChatLinks
{
    using System;
    using System.IO;

    using GW2NET.Common;

    /// <summary>Converts objects of type <see cref="Stream"/> to objects of type <see cref="UnknownChatLink"/>.</summary>
    public sealed class UnknownChatLinkConverter : IConverter<Stream, UnknownChatLink>, IConverter<UnknownChatLink, Stream>
    {
        /// <inheritdoc />
        public UnknownChatLink Convert(Stream value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            if (state == null)
            {
                throw new ArgumentNullException("state", "Precondition: state is byte[]");
            }

            var raw = state as byte[];
            if (raw == null)
            {
                throw new ArgumentException("Precondition: state is byte[]", "state");
            }

            return new UnknownChatLink(raw);
        }

        /// <inheritdoc />
        public Stream Convert(UnknownChatLink value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return new MemoryStream(value.Raw, writable: false);
        }
    }
}