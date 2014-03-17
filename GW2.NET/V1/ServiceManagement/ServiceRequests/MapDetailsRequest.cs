// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapDetailsRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for details regarding maps in the game.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.ServiceManagement.ServiceRequests
{
    using GW2DotNET.Extensions;

    /// <summary>Represents a request for details regarding maps in the game.</summary>
    public class MapDetailsRequest : ServiceRequest
    {
        /// <summary>Infrastructure. Stores a parameter.</summary>
        private int? mapId;

        /// <summary>Initializes a new instance of the <see cref="MapDetailsRequest" /> class.</summary>
        public MapDetailsRequest()
            : base(Services.Maps)
        {
        }

        /// <summary>Gets or sets the map filter.</summary>
        public int? MapId
        {
            get
            {
                return this.mapId;
            }

            set
            {
                this.Query["map_id"] = (this.mapId = value).ToStringInvariant();
            }
        }
    }
}