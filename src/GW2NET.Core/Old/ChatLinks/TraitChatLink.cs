// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TraitChatLink.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a chat link that links to a trait.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.ChatLinks
{
    using GW2NET.ChatLinks.Interop;

    /// <summary>Represents a chat link that links to a trait.</summary>
    public class TraitChatLink : ChatLink
    {
        /// <summary>Gets or sets the trait identifier.</summary>
        public int TraitId { get; set; }

        protected override int CopyTo(ChatLinkStruct value)
        {
            value.header = Header.Trait;
            value.trait.traitId = this.TraitId;
            return 5;
        }
    }
}