// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapFloorServiceContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The map floor service contract.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Maps
{
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Maps;

    /// <summary>The map floor service contract.</summary>
    [ContractClassFor(typeof(IMapFloorService))]
    internal abstract class MapFloorServiceContract : IMapFloorService
    {
        /// <summary>Gets a map floor and its localized details.</summary>
        /// <param name="continent">The continent identifier.</param>
        /// <param name="floor">The floor identifier.</param>
        /// <returns>A map floor and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public Floor GetMapFloor(int continent, int floor)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a map floor and its localized details.</summary>
        /// <param name="continent">The continent identifier.</param>
        /// <param name="floor">The floor identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>A map floor and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public Floor GetMapFloor(int continent, int floor, CultureInfo language)
        {
            Contract.Requires(language != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a map floor and its localized details.</summary>
        /// <param name="continent">The continent identifier.</param>
        /// <param name="floor">The floor identifier.</param>
        /// <returns>A map floor and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public Task<Floor> GetMapFloorAsync(int continent, int floor)
        {
            Contract.Ensures(Contract.Result<Task<Floor>>() != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a map floor and its localized details.</summary>
        /// <param name="continent">The continent identifier.</param>
        /// <param name="floor">The floor identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A map floor and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public Task<Floor> GetMapFloorAsync(int continent, int floor, CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<Floor>>() != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a map floor and its localized details.</summary>
        /// <param name="continent">The continent identifier.</param>
        /// <param name="floor">The floor identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>A map floor and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public Task<Floor> GetMapFloorAsync(int continent, int floor, CultureInfo language)
        {
            Contract.Requires(language != null);
            Contract.Ensures(Contract.Result<Task<Floor>>() != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a map floor and its localized details.</summary>
        /// <param name="continent">The continent identifier.</param>
        /// <param name="floor">The floor identifier.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A map floor and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public Task<Floor> GetMapFloorAsync(int continent, int floor, CultureInfo language, CancellationToken cancellationToken)
        {
            Contract.Requires(language != null);
            Contract.Ensures(Contract.Result<Task<Floor>>() != null);
            throw new System.NotImplementedException();
        }
    }
}