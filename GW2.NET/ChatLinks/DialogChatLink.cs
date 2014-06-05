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
    using System.ComponentModel;

    /// <summary>Represents a chat link that links to a dialog.</summary>
    [TypeConverter(typeof(DialogChatLinkConverter))]
    public class DialogChatLink : ChatLink
    {
        /// <summary>Gets or sets the dialog identifier.</summary>
        public int DialogId { get; set; }
    }
}