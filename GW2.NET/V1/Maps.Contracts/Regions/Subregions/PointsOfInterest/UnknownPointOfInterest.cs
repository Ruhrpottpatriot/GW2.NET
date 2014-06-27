// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnknownPointOfInterest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an unknown point of interest.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Maps.Contracts.Regions.Subregions.PointsOfInterest
{
    using GW2DotNET.Common;

    /// <summary>Represents an unknown point of interest.</summary>
    [TypeDiscriminator(Value = "unknown", BaseType = typeof(PointOfInterest))]
    public class UnknownPointOfInterest : PointOfInterest
    {
    }
}