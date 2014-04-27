// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkinChatLink.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a chat link that links to a wardrobe skin.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.ChatLinks
{
    using System;

    /// <summary>Represents a chat link that links to a wardrobe skin.</summary>
    public class SkinChatLink : ChatLink
    {
        /// <summary>Initializes a new instance of the <see cref="SkinChatLink"/> class.</summary>
        /// <param name="skinId">The skin identifier.</param>
        public SkinChatLink(int skinId)
            : base(ChatLinkType.Wardrobe)
        {
            this.SkinId = skinId;
        }

        /// <summary>Gets the skin identifier.</summary>
        public int SkinId { get; private set; }

        /// <summary>Gets the bytes.</summary>
        /// <returns>The <see cref="byte" /> array.</returns>
        protected override byte[] GetBytes()
        {
            var buffer = new byte[5];
            Buffer.SetByte(buffer, 0, (byte)this.Type);
            Buffer.BlockCopy(BitConverter.GetBytes(this.SkinId), 0, buffer, 1, 4);
            return buffer;
        }
    }
}