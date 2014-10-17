// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChatLinkConverterContracts.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The chat link converter contracts.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.ChatLinks
{
    using System;
    using System.Diagnostics.Contracts;

    /// <summary>The chat link converter contracts.</summary>
    [ContractClassFor(typeof(ChatLinkConverter))]
    internal abstract class ChatLinkConverterContracts : ChatLinkConverter
    {
        /// <summary>Converts the given byte array to the specified chat link type.</summary>
        /// <param name="bytes">The byte array.</param>
        /// <returns>A chat link.</returns>
        protected override ChatLink ConvertFromBytes(byte[] bytes)
        {
            Contract.Requires(bytes != null);
            Contract.Ensures(Contract.Result<ChatLink>() != null);
            throw new NotImplementedException();
        }

        /// <summary>Converts the given chat link to a byte array.</summary>
        /// <param name="value">The chat link.</param>
        /// <returns>A byte array.</returns>
        protected override byte[] ConvertToBytes(ChatLink value)
        {
            Contract.Requires(value != null);
            Contract.Ensures(Contract.Result<byte[]>() != null);
            throw new NotImplementedException();
        }
    }
}