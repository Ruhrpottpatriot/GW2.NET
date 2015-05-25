// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForChatLink.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:byte[]" /> to objects of type <see cref="ChatLink" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.ChatLinks
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;

    using GW2NET.Common;

    /// <summary>Converts objects of type <see cref="T:byte[]"/> to objects of type <see cref="ChatLink"/>.</summary>
    internal sealed class ConverterForChatLink : IConverter<byte[], ChatLink>
    {
        private readonly IDictionary<int, IConverter<Stream, ChatLink>> typeConverters;

        public ConverterForChatLink()
        {
            this.typeConverters = GetKnownTypeConverters();
            Debug.Assert(this.typeConverters != null);
        }

        /// <inheritdoc />
        public ChatLink Convert(byte[] value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            using (var stream = new MemoryStream(value, false))
            using (var reader = new BinaryReader(stream))
            {
                var header = reader.ReadByte();
                IConverter<Stream, ChatLink> converter;
                if (this.typeConverters.TryGetValue(header, out converter))
                {
                    return converter.Convert(reader.BaseStream, state);
                }

                return null;
            }
        }

        private static IDictionary<int, IConverter<Stream, ChatLink>> GetKnownTypeConverters()
        {
            return new Dictionary<int, IConverter<Stream, ChatLink>>
            {
                { 1, new ConverterForCoinChatLink() }, 
                { 2, new ConverterForItemChatLink() }, 
                { 3, new ConverterForDialogChatLink() }, 
                { 4, new ConverterForPointOfInterestChatLink() }, 
                { 7, new ConverterForSkillChatLink() }, 
                { 8, new ConverterForTraitChatLink() }, 
                { 10, new ConverterForRecipeChatLink() }, 
                { 11, new ConverterForSkinChatLink() }, 
                { 12, new ConverterForOutfitChatLink() }, 
            };
        }
    }
}