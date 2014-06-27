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
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Common.Serializers;
    using GW2DotNET.V1.Maps.Contracts;

    /// <summary>Provides the default implementation of the continents service.</summary>
    public class ContinentService : IContinentService
    {
        /// <summary>Infrastructure. Holds a reference to the serializer settings.</summary>
        private static readonly ContinentSerializerSettings Settings = new ContinentSerializerSettings();

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
        public IEnumerable<Continent> GetContinents()
        {
            var request = new ContinentRequest();
            var result = this.serviceClient.Send(request, new JsonSerializer<ContinentCollectionResult>(Settings));

            // Patch missing continent identifiers
            foreach (var continent in result.Continents)
            {
                continent.Value.ContinentId = continent.Key;
                foreach (var floor in continent.Value.Floors)
                {
                    floor.ContinentId = continent.Key;
                }
            }

            return result.Continents.Values;
        }

        /// <summary>Gets a collection of continents and their details.</summary>
        /// <returns>A collection of continents.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Continent>> GetContinentsAsync()
        {
            return this.GetContinentsAsync(CancellationToken.None);
        }

        /// <summary>Gets a collection of continents and their details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of continents.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Continent>> GetContinentsAsync(CancellationToken cancellationToken)
        {
            var request = new ContinentRequest();
            var t1 = this.serviceClient.SendAsync(request, new JsonSerializer<ContinentCollectionResult>(Settings), cancellationToken);
            var t2 = t1.ContinueWith<IEnumerable<Continent>>(
                task =>
                    {
                        var result = task.Result;

                        // Patch missing continent identifiers
                        foreach (var continent in result.Continents)
                        {
                            continent.Value.ContinentId = continent.Key;
                            foreach (var floor in continent.Value.Floors)
                            {
                                floor.ContinentId = continent.Key;
                            }
                        }

                        return result.Continents.Values;
                    }, 
                cancellationToken);

            return t2;
        }
    }
}