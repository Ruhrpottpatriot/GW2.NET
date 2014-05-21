// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DialogChatLink.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a chat link that links to a dialog.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.ChatLinks
{
    using System;

    /// <summary>Represents a chat link that links to a dialog.</summary>
    public class DialogChatLink : ChatLink
    {
        /// <summary>Initializes a new instance of the <see cref="DialogChatLink"/> class.</summary>
        /// <param name="dialogId">The dialog identifier.</param>
        public DialogChatLink(int dialogId)
            : base(ChatLinkType.Text)
        {
            this.DialogId = dialogId;
        }

        /// <summary>Gets the dialog identifier.</summary>
        public int DialogId { get; private set; }

        /// <summary>Gets the bytes.</summary>
        /// <returns>The <see cref="byte" /> array.</returns>
        protected override byte[] GetBytes()
        {
            var buffer = new byte[5];
            Buffer.SetByte(buffer, 0, (byte)this.Type);
            Buffer.BlockCopy(BitConverter.GetBytes(this.DialogId), 0, buffer, 2, 2);
            return buffer;
        }
    }
}