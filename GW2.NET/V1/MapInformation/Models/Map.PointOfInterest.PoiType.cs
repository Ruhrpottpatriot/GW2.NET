// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Map.PointOfInterest.PoiType.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a map.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.MapInformation.Models
{
    /// <summary>Represents a map.</summary>
    public partial class Map
    {
        /// <summary>Represents a point of interest.</summary>
        public partial class PointOfInterest
        {
            /// <summary>Enumerates the poi type.</summary>
            public enum PoiType
            {
                /// <summary>A vista.</summary>
                Vista, 

                /// <summary>A landmark.</summary>
                Landmark, 

                /// <summary>A waypoint.</summary>
                Waypoint, 

                /// <summary>A unlock.</summary>
                Unlock
            }
        }
    }
}