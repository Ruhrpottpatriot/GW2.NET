// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PointOfInterestChatLink.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a chat link that links to a point of interest.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.ChatLinks
{
    using GW2NET.ChatLinks.Interop;

    /// <summary>Represents a chat link that links to a point of interest.</summary>
    public class PointOfInterestChatLink : ChatLink
    {
        /// <summary>Gets or sets the point of interest identifier.</summary>
        public int PointOfInterestId { get; set; }

        protected override int CopyTo(ChatLinkStruct value)
        {
            value.header = Header.Map;
            value.map.pointOfInterestId = this.PointOfInterestId;
            return 5;
        }
    }
}