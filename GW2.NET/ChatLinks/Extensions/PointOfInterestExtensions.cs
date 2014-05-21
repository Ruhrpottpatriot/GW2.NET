// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PointOfInterestExtensions.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides static extension methods for the <see cref="PointOfInterest" /> class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.ChatLinks.Extensions
{
    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Maps.Floors.Contracts.Regions.Subregions.PointsOfInterest;

    /// <summary>Provides static extension methods for the <see cref="PointOfInterest" /> class.</summary>
    public static class PointOfInterestExtensions
    {
        /// <summary>Gets a chat link for the specified point of interest.</summary>
        /// <param name="pointOfInterest">The point of interest.</param>
        /// <returns>The <see cref="ChatLink"/>The chat link.</returns>
        public static ChatLink GetChatLink(this PointOfInterest pointOfInterest)
        {
            Preconditions.EnsureNotNull(pointOfInterest);
            return new PointOfInterestChatLink(pointOfInterest.PointOfInterestId);
        }
    }
}