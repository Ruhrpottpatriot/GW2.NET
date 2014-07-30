// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PointOfInterestExtensions.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides static extension methods for the <see cref="PointOfInterestContract" /> class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.ChatLinks.Extensions
{
    using System.Diagnostics.Contracts;

    using GW2DotNET.V1.Maps.Contracts;

    /// <summary>Provides static extension methods for the <see cref="PointOfInterestContract" /> class.</summary>
    public static class PointOfInterestExtensions
    {
        /// <summary>Gets a chat link for the specified point of interest.</summary>
        /// <param name="pointOfInterest">The point of interest.</param>
        /// <returns>The <see cref="ChatLink"/>The chat link.</returns>
        public static ChatLink GetChatLink(this PointOfInterestContract pointOfInterest)
        {
            Contract.Requires(pointOfInterest != null);
            return new PointOfInterestChatLink { PointOfInterestId = pointOfInterest.PointOfInterestId };
        }
    }
}