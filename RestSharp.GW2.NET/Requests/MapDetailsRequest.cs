// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapDetailsRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for details regarding (a) map(s) in the game.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RestSharp.GW2DotNET.Requests
{
    using System.Threading;
    using System.Threading.Tasks;

    using global::GW2DotNET.V1.Core;

    using global::GW2DotNET.V1.Core.MapsInformation.Details;

    /// <summary>
    ///     Represents a request for details regarding (a) map(s) in the game.
    /// </summary>
    /// <remarks>
    ///     See <a href="http://wiki.guildwars2.com/wiki/API:1/maps" /> for more information.
    /// </remarks>
    public class MapDetailsRequest : ServiceRequest
    {
        /// <summary>Infrastructure. Stores a parameter.</summary>
        private readonly Parameter mapIdParameter;

        /// <summary>The map filter.</summary>
        private int? mapId;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MapDetailsRequest" /> class.
        /// </summary>
        public MapDetailsRequest()
            : base(Resources.Maps)
        {
            this.AddParameter(this.mapIdParameter = new Parameter { Name = "map_id", Value = string.Empty, Type = ParameterType.GetOrPost });
        }

        /// <summary>
        /// Gets or sets the map filter.
        /// </summary>
        public int? MapId
        {
            get
            {
                return this.mapId;
            }

            set
            {
                this.mapIdParameter.Value = (this.mapId = value).ToString();
            }
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public IServiceResponse<MapsResult> GetResponse(IServiceClient serviceClient)
        {
            return this.GetResponse<MapsResult>(serviceClient);
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<MapsResult>> GetResponseAsync(IServiceClient serviceClient)
        {
            return this.GetResponseAsync<MapsResult>(serviceClient);
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<MapsResult>> GetResponseAsync(IServiceClient serviceClient, CancellationToken cancellationToken)
        {
            return this.GetResponseAsync<MapsResult>(serviceClient, cancellationToken);
        }
    }
}