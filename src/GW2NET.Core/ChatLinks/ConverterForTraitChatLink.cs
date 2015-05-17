// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForTraitChatLink.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="Stream" /> to objects of type <see cref="TraitChatLink" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.ChatLinks
{
    using System;
    using System.IO;

    using GW2NET.Common;

    /// <summary>Converts objects of type <see cref="Stream"/> to objects of type <see cref="TraitChatLink"/>.</summary>
    internal sealed class ConverterForTraitChatLink : IConverter<Stream, TraitChatLink>
    {
        /// <inheritdoc />
        public TraitChatLink Convert(Stream value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            using (var reader = new BinaryReader(value))
            {
                return new TraitChatLink
                {
                    TraitId = reader.ReadInt16()
                };
            }
        }

        /// <inheritdoc />
        public Stream Convert(TraitChatLink value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var stream = new MemoryStream();
            var buffer = new MemoryStream();
            using (var writer = new BinaryWriter(buffer))
            {
                writer.Write((byte)8);
                writer.Write(value.TraitId);
                buffer.WriteTo(stream);
            }

            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }
    }
}