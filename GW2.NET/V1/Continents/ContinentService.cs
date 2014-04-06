// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContinentService.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the continents service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Continents
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.V1.Common;
    using GW2DotNET.V1.Continents.Types;

    /// <summary>Provides the default implementation of the continents service.</summary>
    public class ContinentService : ServiceBase, IContinentService
    {
        /// <summary>Initializes a new instance of the <see cref="ContinentService"/> class.</summary>
        public ContinentService()
            : this(new ServiceClient(new Uri(Services.DataServiceUrl)))
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ContinentService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public ContinentService(IServiceClient serviceClient)
            : base(serviceClient)
        {
        }

        /// <summary>Gets a collection of continents and their details.</summary>
        /// <returns>A collection of continents.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        public IEnumerable<Continent> GetContinents()
        {
            var serviceRequest = new ContinentsRequest();
            var result = this.Request<ContinentsResult>(serviceRequest);

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
            var serviceRequest = new ContinentsRequest();
            var t1 = this.RequestAsync<ContinentsResult>(serviceRequest, cancellationToken);
            var t2 = t1.ContinueWith<IEnumerable<Continent>>(task => task.Result.Continents.Values, cancellationToken);

            return t2;
        }
    }
}