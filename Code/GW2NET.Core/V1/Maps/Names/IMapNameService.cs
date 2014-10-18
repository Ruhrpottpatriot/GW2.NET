// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMapNameService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for the map names service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Maps
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Entities.Maps;

    /// <summary>Provides the interface for the map names service.</summary>
    [ContractClass(typeof(ContractClassForIMapNameService))]
    public interface IMapNameService
    {
        /// <summary>Gets a collection of maps and their localized name.</summary>
        /// <returns>A collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        IDictionary<int, Map> GetMapNames();

        /// <summary>Gets a collection of maps and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        IDictionary<int, Map> GetMapNames(CultureInfo language);

        /// <summary>Gets a collection of maps and their localized name.</summary>
        /// <returns>A collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        Task<IDictionary<int, Map>> GetMapNamesAsync();

        /// <summary>Gets a collection of maps and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        Task<IDictionary<int, Map>> GetMapNamesAsync(CancellationToken cancellationToken);

        /// <summary>Gets a collection of maps and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        Task<IDictionary<int, Map>> GetMapNamesAsync(CultureInfo language);

        /// <summary>Gets a collection of maps and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        Task<IDictionary<int, Map>> GetMapNamesAsync(CultureInfo language, CancellationToken cancellationToken);
    }
}