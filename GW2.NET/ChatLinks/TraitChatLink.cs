// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TraitChatLink.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a chat link that links to a trait.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.ChatLinks
{
    using System;

    /// <summary>Represents a chat link that links to a trait.</summary>
    public class TraitChatLink : ChatLink
    {
        /// <summary>Initializes a new instance of the <see cref="TraitChatLink"/> class.</summary>
        /// <param name="traitId">The trait identifier.</param>
        public TraitChatLink(int traitId)
            : base(ChatLinkType.Trait)
        {
            this.TraitId = traitId;
        }

        /// <summary>Gets the trait identifier.</summary>
        public int TraitId { get; private set; }

        /// <summary>Gets the bytes.</summary>
        /// <returns>The <see cref="byte" /> array.</returns>
        protected override byte[] GetBytes()
        {
            var buffer = new byte[5];
            Buffer.SetByte(buffer, 0, (byte)this.Type);
            Buffer.BlockCopy(BitConverter.GetBytes(this.TraitId), 0, buffer, 1, 4);
            return buffer;
        }
    }
}