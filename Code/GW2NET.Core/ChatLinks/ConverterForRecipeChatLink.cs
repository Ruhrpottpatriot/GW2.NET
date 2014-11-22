// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForRecipeChatLink.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="Stream" /> to objects of type <see cref="RecipeChatLink" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.ChatLinks
{
    using System.Diagnostics.Contracts;
    using System.IO;

    using GW2NET.Common;

    /// <summary>Converts objects of type <see cref="Stream"/> to objects of type <see cref="RecipeChatLink"/>.</summary>
    internal sealed class ConverterForRecipeChatLink : IConverter<Stream, RecipeChatLink>
    {
        /// <summary>Converts the given object of type <see cref="Stream"/> to an object of type <see cref="RecipeChatLink"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public RecipeChatLink Convert(Stream value)
        {
            Contract.Assume(value != null);
            using (var reader = new BinaryReader(value))
            {
                return new RecipeChatLink
                {
                    RecipeId = reader.ReadInt16()
                };
            }
        }

        /// <summary>Converts the given object of type <see cref="RecipeChatLink"/> to an object of type <see cref="Stream"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Stream Convert(RecipeChatLink value)
        {
            Contract.Assume(value != null);
            var stream = new MemoryStream();
            var buffer = new MemoryStream();
            using (var writer = new BinaryWriter(buffer))
            {
                writer.Write((byte)10);
                writer.Write(value.RecipeId);
                buffer.WriteTo(stream);
            }

            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }
    }
}