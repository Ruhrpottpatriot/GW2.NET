// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CoinChatLinkConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides a type converter to convert string objects to and from its <see cref="CoinChatLink" /> representation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.ChatLinks
{
    using System;

    using GW2DotNET.Common;

    /// <summary>Provides a type converter to convert string objects to and from its <see cref="CoinChatLink"/> representation.</summary>
    [ConverterFor(typeof(CoinChatLink))]
    internal class CoinChatLinkConverter : ChatLinkConverter
    {
        /// <summary>Gets the chat link header.</summary>
        protected override byte Header
        {
            get
            {
                return 0x1;
            }
        }

        /// <summary>Converts the given byte array to the specified chat link type.</summary>
        /// <param name="bytes">The byte array.</param>
        /// <returns>A chat link.</returns>
        protected override ChatLink ConvertFromBytes(byte[] bytes)
        {
            // Create a new chat link object
            var value = new CoinChatLink();

            // Create a buffer
            var buffer = new byte[sizeof(int)];

            // Copy up to the first 4 bytes to the buffer
            Buffer.BlockCopy(bytes, 0, buffer, 0, Math.Min(bytes.Length, buffer.Length));

            // Set the quantity
            value.Quantity = BitConverter.ToInt32(buffer, 0);

            // Return the chat link object
            return value;
        }

        /// <summary>Converts the given chat link to a byte array.</summary>
        /// <param name="value">The chat link.</param>
        /// <returns>A byte array.</returns>
        protected override byte[] ConvertToBytes(ChatLink value)
        {
            return BitConverter.GetBytes(((CoinChatLink)value).Quantity);
        }
    }
}