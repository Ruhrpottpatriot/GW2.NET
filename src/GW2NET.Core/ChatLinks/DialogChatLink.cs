// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DialogChatLink.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a chat link that links to a dialog.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.ChatLinks
{
    using GW2NET.ChatLinks.Interop;

    /// <summary>Represents a chat link that links to a dialog.</summary>
    public class DialogChatLink : ChatLink
    {
        /// <summary>Gets or sets the dialog identifier.</summary>
        public int DialogId { get; set; }

        protected override int CopyTo(ChatLinkStruct value)
        {
            value.header = Header.Text;
            value.text.dialogId = this.DialogId;
            return 5;
        }
    }
}