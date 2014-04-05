// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDynamicEventNameServiceCache.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for an event names service cache.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.DynamicEvents.Names
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.V1.DynamicEvents.Names.Types;

    /// <summary>Provides the interface for an event names service cache.</summary>
    public interface IDynamicEventNameServiceCache : IDynamicEventNameService
    {
        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        IEnumerable<DynamicEventName> GetDynamicEventNames(bool allowCache);

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        IEnumerable<DynamicEventName> GetDynamicEventNames(CultureInfo language, bool allowCache);

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        Task<IEnumerable<DynamicEventName>> GetDynamicEventNamesAsync(bool allowCache);

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        Task<IEnumerable<DynamicEventName>> GetDynamicEventNamesAsync(CancellationToken cancellationToken, bool allowCache);

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        Task<IEnumerable<DynamicEventName>> GetDynamicEventNamesAsync(CultureInfo language, bool allowCache);

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        Task<IEnumerable<DynamicEventName>> GetDynamicEventNamesAsync(CultureInfo language, CancellationToken cancellationToken, bool allowCache);

        /// <summary>Sets a collection of dynamic events and their localized name.</summary>
        /// <param name="dynamicEventNames">A collection of dynamic events and their localized name.</param>
        /// <param name="language">The language.</param>
        void SetDynamicEventNames(IEnumerable<DynamicEventName> dynamicEventNames, CultureInfo language);
    }
}