// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapFloorRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for details regarding a map floor, used to populate a world map.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Maps.Floors
{
    using System.Globalization;

    using GW2DotNET.Common;
    using GW2DotNET.V1.Common;

    /// <summary>Represents a request for details regarding a map floor, used to populate a world map.</summary>
    public class MapFloorRequest : IFloorRequest, ILocalizable
    {
        /// <summary>Gets or sets the continent identifier.</summary>
        public int? ContinentId { get; set; }

        /// <summary>Gets or sets the locale.</summary>
        public CultureInfo Culture { get; set; }

        /// <summary>Gets or sets the floor number.</summary>
        public int? Floor { get; set; }

        /// <summary>Gets the resource path.</summary>
        public string Resource
        {
            get
            {
                return Services.MapFloor;
            }
        }
    }
}