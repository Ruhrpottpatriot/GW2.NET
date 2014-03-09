// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapDetailsRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using GW2DotNET.V1.Core;
using GW2DotNET.V1.Core.MapsInformation.Details;

namespace RestSharp.GW2DotNET.Requests
{
    /// <summary>
    ///     Represents a request for details regarding (a) map(s) in the game.
    /// </summary>
    /// <remarks>
    ///     See <a href="http://wiki.guildwars2.com/wiki/API:1/maps" /> for more information.
    /// </remarks>
    public class MapDetailsRequest : ServiceRequest
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MapDetailsRequest" /> class.
        /// </summary>
        public MapDetailsRequest()
            : base(Resources.Maps)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MapDetailsRequest" /> class.
        /// </summary>
        /// <param name="languageInfo">The output language.</param>
        public MapDetailsRequest(CultureInfo languageInfo)
            : base(Resources.Maps, languageInfo)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MapDetailsRequest" /> class.
        /// </summary>
        /// <param name="mapId">The map's ID.</param>
        /// <param name="languageInfo">The output language.</param>
        public MapDetailsRequest(int mapId, CultureInfo languageInfo)
            : this(languageInfo)
        {
            this.AddParameter("map_id", mapId);
        }

        /// <summary>
        ///     Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public IServiceResponse<MapsResult> GetResponse(IServiceClient serviceClient)
        {
            return base.GetResponse<MapsResult>(serviceClient);
        }

        /// <summary>
        ///     Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<MapsResult>> GetResponseAsync(IServiceClient serviceClient)
        {
            return base.GetResponseAsync<MapsResult>(serviceClient);
        }

        /// <summary>
        ///     Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken" /> that provides cancellation support.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<MapsResult>> GetResponseAsync(IServiceClient serviceClient, CancellationToken cancellationToken)
        {
            return base.GetResponseAsync<MapsResult>(serviceClient, cancellationToken);
        }
    }
}