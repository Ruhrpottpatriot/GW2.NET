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
    using System.ComponentModel;

    /// <summary>Represents a chat link that links to a trait.</summary>
    [TypeConverter(typeof(TraitChatLinkConverter))]
    public class TraitChatLink : ChatLink
    {
        /// <summary>Gets or sets the trait identifier.</summary>
        public int TraitId { get; set; }
    }
}