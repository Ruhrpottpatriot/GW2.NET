// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnknownLocation.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an unknown location.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.DynamicEvents.Details.Contracts.Locations.LocationTypes
{
    /// <summary>Represents an unknown location.</summary>
    public class UnknownLocation : Location
    {
        /// <summary>Initializes a new instance of the <see cref="UnknownLocation" /> class.</summary>
        public UnknownLocation()
            : base(LocationType.Unknown)
        {
        }
    }
}