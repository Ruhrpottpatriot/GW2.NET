// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CoinChatLink.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a chat link that links to an amount of coins.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.ChatLinks
{
    using System;

    /// <summary>Represents a chat link that links to an amount of coins.</summary>
    public class CoinChatLink : ChatLink
    {
        /// <summary>Initializes a new instance of the <see cref="CoinChatLink"/> class.</summary>
        /// <param name="quantity">The quantity.</param>
        public CoinChatLink(int quantity)
            : base(ChatLinkType.Coin)
        {
            this.Quantity = quantity;
        }

        /// <summary>Gets the quantity.</summary>
        public int Quantity { get; private set; }

        /// <summary>Gets the bytes.</summary>
        /// <returns>The <see cref="byte"/> array.</returns>
        protected override byte[] GetBytes()
        {
            var buffer = new byte[5];
            Buffer.SetByte(buffer, 0, (byte)this.Type);
            Buffer.BlockCopy(BitConverter.GetBytes(this.Quantity), 0, buffer, 1, 4);
            return buffer;
        }
    }
}