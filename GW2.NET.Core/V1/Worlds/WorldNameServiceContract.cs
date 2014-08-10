// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorldNameServiceContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The world name service contract.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Worlds
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Entities.Worlds;

    /// <summary>The world name service contract.</summary>
    [ContractClassFor(typeof(IWorldNameService))]
    internal abstract class WorldNameServiceContract : IWorldNameService
    {
        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public ICollection<World> GetWorldNames()
        {
            Contract.Ensures(Contract.Result<ICollection<World>>() != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public ICollection<World> GetWorldNames(CultureInfo language)
        {
            Contract.Requires(language != null);
            Contract.Ensures(Contract.Result<ICollection<World>>() != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<ICollection<World>> GetWorldNamesAsync()
        {
            Contract.Ensures(Contract.Result<Task<ICollection<World>>>() != null);
            Contract.Ensures(Contract.Result<Task<ICollection<World>>>().Result != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<ICollection<World>> GetWorldNamesAsync(CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<ICollection<World>>>() != null);
            Contract.Ensures(Contract.Result<Task<ICollection<World>>>().Result != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<ICollection<World>> GetWorldNamesAsync(CultureInfo language)
        {
            Contract.Requires(language != null);
            Contract.Ensures(Contract.Result<Task<ICollection<World>>>() != null);
            Contract.Ensures(Contract.Result<Task<ICollection<World>>>().Result != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<ICollection<World>> GetWorldNamesAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            Contract.Requires(language != null);
            Contract.Ensures(Contract.Result<Task<ICollection<World>>>() != null);
            Contract.Ensures(Contract.Result<Task<ICollection<World>>>().Result != null);
            throw new System.NotImplementedException();
        }
    }
}