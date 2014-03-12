// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapFloorRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for details regarding a map floor, used to populate a world map.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace RestSharp.GW2DotNET.Requests
{
    using System.Threading;
    using System.Threading.Tasks;

    using global::GW2DotNET.V1;

    using global::GW2DotNET.V1.Core;

    using global::GW2DotNET.V1.Core.MapsInformation.Floors;

    /// <summary>
    ///     Represents a request for details regarding a map floor, used to populate a world map.
    /// </summary>
    /// <remarks>
    ///     See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor" /> for more information.
    /// </remarks>
    public class MapFloorRequest : ServiceRequest
    {
        /// <summary>Infrastructure. Stores a parameter.</summary>
        private readonly Parameter continentIdParameter;

        /// <summary>Infrastructure. Stores a parameter.</summary>
        private readonly Parameter floorParameter;

        /// <summary>The continent ID.</summary>
        private int continentId;

        /// <summary>The floor.</summary>
        private int floor;

        /// <summary>Initializes a new instance of the <see cref="MapFloorRequest"/> class.</summary>
        public MapFloorRequest()
            : base(Services.MapFloor)
        {
            this.AddParameter(this.continentIdParameter = new Parameter { Name = "continent_id", Value = default(int), Type = ParameterType.GetOrPost });
            this.AddParameter(this.floorParameter = new Parameter { Name = "floor", Value = default(int), Type = ParameterType.GetOrPost });
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
                this.continentIdParameter.Value = this.continentId = value;
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
                this.floorParameter.Value = this.floor = value;
            }
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public IServiceResponse<Floor> GetResponse(IServiceClient serviceClient)
        {
            return this.GetResponse<Floor>(serviceClient);
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<Floor>> GetResponseAsync(IServiceClient serviceClient)
        {
            return this.GetResponseAsync<Floor>(serviceClient);
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<Floor>> GetResponseAsync(IServiceClient serviceClient, CancellationToken cancellationToken)
        {
            return this.GetResponseAsync<Floor>(serviceClient, cancellationToken);
        }
    }
}