// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContinentDetailsServiceContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The continent service contract.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Maps
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Entities.Maps;

    /// <summary>The continent service contract.</summary>
    [ContractClassFor(typeof(IContinentDetailsService))]
    internal abstract class ContinentDetailsServiceContract : IContinentDetailsService
    {
        /// <summary>Gets a collection of continents and their details.</summary>
        /// <returns>A collection of continents.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        public IDictionary<int, Continent> GetContinents()
        {
            Contract.Ensures(Contract.Result<IDictionary<int, Continent>>() != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of continents and their details.</summary>
        /// <returns>A collection of continents.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, Continent>> GetContinentsAsync()
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<int, Continent>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<int, Continent>>>().Result != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of continents and their details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of continents.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, Continent>> GetContinentsAsync(CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<int, Continent>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<int, Continent>>>().Result != null);
            throw new System.NotImplementedException();
        }
    }
}