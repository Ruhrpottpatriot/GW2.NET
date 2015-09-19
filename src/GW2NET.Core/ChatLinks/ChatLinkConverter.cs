// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChatLinkConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:byte[]" /> to objects of type <see cref="ChatLink" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.ChatLinks
{
    using System;
    using System.IO;

    using GW2NET.Common;

    /// <summary>Converts objects of type <see cref="T:byte[]" /> to objects of type <see cref="ChatLink" />.</summary>
    public sealed class ChatLinkConverter : IConverter<byte[], ChatLink>
    {
        /// <inheritdoc />
        public ChatLink Convert(byte[] value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            using (var stream = new MemoryStream(value, false))
            using (var reader = new BinaryReader(stream))
            {
                var header = reader.ReadByte();
                IConverter<Stream, ChatLink> converter;
                switch (header)
                {
                    case 1:
                        converter = new CoinChatLinkConverter();
                        break;
                    case 2:
                        converter = new ItemChatLinkConverter();
                        break;
                    case 3:
                        converter = new DialogChatLinkConverter();
                        break;
                    case 4:
                        converter = new PointOfInterestChatLinkConverter();
                        break;
                    case 7:
                        converter = new SkillChatLinkConverter();
                        break;
                    case 8:
                        converter = new TraitChatLinkConverter();
                        break;
                    case 10:
                        converter = new RecipeChatLinkConverter();
                        break;
                    case 11:
                        converter = new SkinChatLinkConverter();
                        break;
                    case 12:
                        converter = new OutfitChatLinkConverter();
                        break;
                    default:
                        converter = new UnknownChatLinkConverter();
                        break;
                }

                return converter.Convert(stream, value);
            }
        }
    }
}