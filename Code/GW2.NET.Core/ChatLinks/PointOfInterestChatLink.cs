// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PointOfInterestChatLink.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a chat link that links to a point of interest.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.ChatLinks
{
    using GW2NET.Common;

    /// <summary>Represents a chat link that links to a point of interest.</summary>
    [Converter(typeof(PointOfInterestChatLinkConverter))]
    public class PointOfInterestChatLink : ChatLink
    {
        /// <summary>Gets or sets the point of interest identifier.</summary>
        public int PointOfInterestId { get; set; }
    }
}