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
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.IO;

    using GW2NET.Common;

    /// <summary>Converts objects of type <see cref="T:byte[]"/> to objects of type <see cref="ChatLink"/>.</summary>
    internal sealed class ConverterForChatLink : IConverter<byte[], ChatLink>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IDictionary<int, IConverter<Stream, ChatLink>> typeConverters;

        /// <summary>Initializes a new instance of the <see cref="ConverterForChatLink"/> class.</summary>
        public ConverterForChatLink()
        {
            this.typeConverters = GetKnownTypeConverters();
        }

        /// <summary>Converts the given object of type <see cref="T:byte[]"/> to an object of type <see cref="ChatLink"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public ChatLink Convert(byte[] value)
        {
            Contract.Assume(value != null);
            using (var stream = new MemoryStream(value, false))
            using (var reader = new BinaryReader(stream))
            {
                var header = reader.ReadByte();
                IConverter<Stream, ChatLink> converter;
                if (this.typeConverters.TryGetValue(header, out converter))
                {
                    return converter.Convert(reader.BaseStream);
                }

                return null;
            }
        }

        /// <summary>Infrastructure. Gets default type converters for all known types.</summary>
        /// <returns>The type converters.</returns>
        private static IDictionary<int, IConverter<Stream, ChatLink>> GetKnownTypeConverters()
        {
            Contract.Ensures(Contract.Result<IDictionary<int, IConverter<Stream, ChatLink>>>() != null);
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

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.typeConverters != null);
        }
    }
}