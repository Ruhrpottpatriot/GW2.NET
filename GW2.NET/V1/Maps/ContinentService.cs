// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContinentService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the continents service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Maps
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Common.Serializers;
    using GW2DotNET.Maps;
    using GW2DotNET.V1.Maps.Contracts;

    /// <summary>Provides the default implementation of the continents service.</summary>
    public class ContinentService : IContinentService
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="ContinentService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public ContinentService(IServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a collection of continents and their details.</summary>
        /// <returns>A collection of continents.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        public IDictionary<int, Continent> GetContinents()
        {
            var request = new ContinentRequest();
            var response = this.serviceClient.Send(request, new JsonSerializer<ContinentCollectionContract>());
            return MapContinentCollectionContract(response.Content);
        }

        /// <summary>Gets a collection of continents and their details.</summary>
        /// <returns>A collection of continents.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, Continent>> GetContinentsAsync()
        {
            return this.GetContinentsAsync(CancellationToken.None);
        }

        /// <summary>Gets a collection of continents and their details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of continents.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, Continent>> GetContinentsAsync(CancellationToken cancellationToken)
        {
            var request = new ContinentRequest();
            return this.serviceClient.SendAsync(request, new JsonSerializer<ContinentCollectionContract>(), cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        return MapContinentCollectionContract(response.Content);
                    }, 
                cancellationToken);
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static IDictionary<int, Continent> MapContinentCollectionContract(ContinentCollectionContract content)
        {
            var values = new Dictionary<int, Continent>(content.Continents.Count);
            foreach (var value in content.Continents.Select(MapContinentContract))
            {
                values.Add(value.ContinentId, value);
            }

            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Continent MapContinentContract(KeyValuePair<string, ContinentContract> content)
        {
            return new Continent
                       {
                           ContinentId = int.Parse(content.Key), 
                           Name = content.Value.Name, 
                           ContinentDimensions = MapSizeContract(content.Value.ContinentDimensions), 
                           MinimumZoom = content.Value.MinimumZoom, 
                           MaximumZoom = content.Value.MaximumZoom, 
                           FloorIds = content.Value.Floors
                       };
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Size2D MapSizeContract(int[] content)
        {
            return new Size2D(content[0], content[1]);
        }
    }
}