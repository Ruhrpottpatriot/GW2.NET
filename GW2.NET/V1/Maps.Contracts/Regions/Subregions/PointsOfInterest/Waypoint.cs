// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Waypoint.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a waypoint.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Maps.Contracts.Regions.Subregions.PointsOfInterest
{
    using GW2DotNET.Common;

    /// <summary>Represents a waypoint.</summary>
    [TypeDiscriminator(Value = "waypoint", BaseType = typeof(PointOfInterest))]
    public class Waypoint : PointOfInterest
    {
    }
}