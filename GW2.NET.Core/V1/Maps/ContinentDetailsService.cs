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
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Entities.Maps;
    using GW2DotNET.V1.Maps.Json;

    /// <summary>Provides the default implementation of the continents service.</summary>
    public class ContinentDetailsService : IContinentDetailsService
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="ContinentDetailsService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public ContinentDetailsService(IServiceClient serviceClient)
        {
            Contract.Requires(serviceClient != null);
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a collection of continents and their details.</summary>
        /// <returns>A collection of continents.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        public IDictionary<int, Continent> GetContinents()
        {
            var request = new ContinentDetailsRequest();
            var response = this.serviceClient.Send<ContinentCollectionContract>(request);
            if (response.Content == null || response.Content.Continents == null)
            {
                return new Dictionary<int, Continent>(0);
            }

            return ConvertContinentCollectionContract(response.Content);
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
            var request = new ContinentDetailsRequest();
            return this.serviceClient.SendAsync<ContinentCollectionContract>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null || response.Content.Continents == null)
                        {
                            return new Dictionary<int, Continent>(0);
                        }

                        return ConvertContinentCollectionContract(response.Content);
                    }, 
                cancellationToken);
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static IDictionary<int, Continent> ConvertContinentCollectionContract(ContinentCollectionContract content)
        {
            Contract.Requires(content != null);
            Contract.Requires(content.Continents != null);
            Contract.Ensures(Contract.Result<IDictionary<int, Continent>>() != null);
            var values = new Dictionary<int, Continent>(content.Continents.Count);
            foreach (var value in content.Continents.Select(ConvertContinentContract).Where(value => value != null))
            {
                Contract.Assume(value != null);
                values.Add(value.ContinentId, value);
            }

            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Continent ConvertContinentContract(KeyValuePair<string, ContinentContract> content)
        {
            Contract.Requires(content.Key != null);
            Contract.Requires(content.Value != null);
            Contract.Requires(content.Value.ContinentDimensions != null);
            Contract.Requires(content.Value.ContinentDimensions.Length == 2);
            return new Continent
                       {
                           ContinentId = int.Parse(content.Key), 
                           Name = content.Value.Name, 
                           ContinentDimensions = MapSize2DContract(content.Value.ContinentDimensions), 
                           MinimumZoom = content.Value.MinimumZoom, 
                           MaximumZoom = content.Value.MaximumZoom, 
                           FloorIds = content.Value.Floors
                       };
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Size2D MapSize2DContract(int[] content)
        {
            Contract.Requires(content != null);
            Contract.Requires(content.Length == 2);
            return new Size2D(content[0], content[1]);
        }

        /// <summary>The invariant method for this class.</summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.serviceClient != null);
        }
    }
}