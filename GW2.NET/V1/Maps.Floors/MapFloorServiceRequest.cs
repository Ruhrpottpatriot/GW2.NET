// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapFloorServiceRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for details regarding a map floor, used to populate a world map.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Maps.Floors
{
    using GW2DotNET.Extensions;
    using GW2DotNET.V1.Common;

    /// <summary>Represents a request for details regarding a map floor, used to populate a world map.</summary>
    public class MapFloorServiceRequest : ServiceRequest
    {
        /// <summary>Infrastructure. Stores a parameter.</summary>
        private int continentId;

        /// <summary>Infrastructure. Stores a parameter.</summary>
        private int floor;

        /// <summary>Initializes a new instance of the <see cref="MapFloorServiceRequest" /> class.</summary>
        public MapFloorServiceRequest()
            : base(Services.MapFloor)
        {
        }

        /// <summary>Gets or sets the continent ID.</summary>
        public int ContinentId
        {
            get
            {
                return this.continentId;
            }

            set
            {
                this.FormData["continent_id"] = (this.continentId = value).ToStringInvariant();
            }
        }

        /// <summary>Gets or sets the floor.</summary>
        public int Floor
        {
            get
            {
                return this.floor;
            }

            set
            {
                this.FormData["floor"] = (this.floor = value).ToStringInvariant();
            }
        }
    }
}