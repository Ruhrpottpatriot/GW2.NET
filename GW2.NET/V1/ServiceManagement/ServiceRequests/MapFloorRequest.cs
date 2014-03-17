// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapFloorRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for details regarding a map floor, used to populate a world map.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.ServiceManagement.ServiceRequests
{
    using GW2DotNET.Extensions;

    /// <summary>Represents a request for details regarding a map floor, used to populate a world map.</summary>
    public class MapFloorRequest : ServiceRequest
    {
        /// <summary>Infrastructure. Stores a parameter.</summary>
        private int continentId;

        /// <summary>Infrastructure. Stores a parameter.</summary>
        private int floor;

        /// <summary>Initializes a new instance of the <see cref="MapFloorRequest"/> class.</summary>
        public MapFloorRequest()
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
                this.Query["continent_id"] = (this.continentId = value).ToStringInvariant();
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
                this.Query["floor"] = (this.floor = value).ToStringInvariant();
            }
        }
    }
}