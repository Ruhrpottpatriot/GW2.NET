// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PointOfInterestChatLinkConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="Stream" /> to objects of type <see cref="PointOfInterestChatLink" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.ChatLinks
{
    using System;
    using System.IO;

    using GW2NET.Common;

    /// <summary>Converts objects of type <see cref="Stream"/> to objects of type <see cref="PointOfInterestChatLink"/>.</summary>
    public sealed class PointOfInterestChatLinkConverter : IConverter<Stream, PointOfInterestChatLink>, IConverter<PointOfInterestChatLink, Stream>
    {
        /// <inheritdoc />
        public PointOfInterestChatLink Convert(Stream value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            using (var reader = new BinaryReader(value))
            {
                return new PointOfInterestChatLink
                {
                    PointOfInterestId = reader.ReadInt16()
                };
            }
        }

        /// <inheritdoc />
        public Stream Convert(PointOfInterestChatLink value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            var stream = new MemoryStream();
            var buffer = new MemoryStream();
            using (var writer = new BinaryWriter(buffer))
            {
                writer.Write((byte)4);
                writer.Write(value.PointOfInterestId);
                buffer.WriteTo(stream);
            }

            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }
    }
}