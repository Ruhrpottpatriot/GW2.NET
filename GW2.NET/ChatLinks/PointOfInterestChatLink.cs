// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PointOfInterestChatLink.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a chat link that links to a point of interest.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.ChatLinks
{
    using System;

    /// <summary>Represents a chat link that links to a point of interest.</summary>
    public class PointOfInterestChatLink : ChatLink
    {
        /// <summary>Initializes a new instance of the <see cref="PointOfInterestChatLink"/> class.</summary>
        /// <param name="pointOfInterestId">The point of interest identifier.</param>
        public PointOfInterestChatLink(int pointOfInterestId)
            : base(ChatLinkType.PointOfInterest)
        {
            this.PointOfInterestId = pointOfInterestId;
        }

        /// <summary>Gets the point of interest identifier.</summary>
        public int PointOfInterestId { get; private set; }

        /// <summary>Gets the bytes.</summary>
        /// <returns>The <see cref="byte" /> array.</returns>
        protected override byte[] GetBytes()
        {
            var buffer = new byte[5];
            Buffer.SetByte(buffer, 0, (byte)this.Type);
            Buffer.BlockCopy(BitConverter.GetBytes(this.PointOfInterestId), 0, buffer, 1, 4);
            return buffer;
        }
    }
}