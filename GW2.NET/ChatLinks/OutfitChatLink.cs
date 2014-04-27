// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OutfitChatLink.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a chat link that links to an outfit.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.ChatLinks
{
    using System;

    /// <summary>Represents a chat link that links to an outfit.</summary>
    public class OutfitChatLink : ChatLink
    {
        /// <summary>Initializes a new instance of the <see cref="OutfitChatLink"/> class.</summary>
        /// <param name="outfitId">The outfit identifier.</param>
        public OutfitChatLink(int outfitId)
            : base(ChatLinkType.Outfit)
        {
            this.OutfitId = outfitId;
        }

        /// <summary>Gets the outfit identifier.</summary>
        public int OutfitId { get; private set; }

        /// <summary>Gets the bytes.</summary>
        /// <returns>The <see cref="byte" /> array.</returns>
        protected override byte[] GetBytes()
        {
            var buffer = new byte[5];
            Buffer.SetByte(buffer, 0, (byte)this.Type);
            Buffer.BlockCopy(BitConverter.GetBytes(this.OutfitId), 0, buffer, 1, 4);
            return buffer;
        }
    }
}