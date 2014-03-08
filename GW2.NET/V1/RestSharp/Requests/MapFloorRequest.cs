// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapFloorRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using GW2DotNET.V1.Core;
using GW2DotNET.V1.Core.MapsInformation.Floors;

namespace GW2DotNET.V1.RestSharp.Requests
{
    /// <summary>
    ///     Represents a request for details regarding a map floor, used to populate a world map.
    /// </summary>
    /// <remarks>
    ///     See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor" /> for more information.
    /// </remarks>
    public class MapFloorRequest : ServiceRequest
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MapFloorRequest" /> class.
        /// </summary>
        /// <param name="continentId">The continent's ID.</param>
        /// <param name="floor">The map floor.</param>
        public MapFloorRequest(int continentId, int floor)
            : base(Resources.MapFloor)
        {
            this.AddParameter("continent_id", continentId);
            this.AddParameter("floor", floor);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MapFloorRequest" /> class.
        /// </summary>
        /// <param name="continentId">The continent's ID.</param>
        /// <param name="floor">The map floor.</param>
        /// <param name="languageInfo">The output language.</param>
        public MapFloorRequest(int continentId, int floor, CultureInfo languageInfo)
            : base(Resources.MapFloor, languageInfo)
        {
            this.AddParameter("continent_id", continentId);
            this.AddParameter("floor", floor);
        }

        /// <summary>
        ///     Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public IServiceResponse<Floor> GetResponse(IServiceClient serviceClient)
        {
            return base.GetResponse<Floor>(serviceClient);
        }

        /// <summary>
        ///     Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<Floor>> GetResponseAsync(IServiceClient serviceClient)
        {
            return base.GetResponseAsync<Floor>(serviceClient);
        }

        /// <summary>
        ///     Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken" /> that provides cancellation support.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<Floor>> GetResponseAsync(IServiceClient serviceClient, CancellationToken cancellationToken)
        {
            return base.GetResponseAsync<Floor>(serviceClient, cancellationToken);
        }
    }
}