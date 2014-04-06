// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDynamicEventDetailsServiceCache.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for an event details service cache.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.DynamicEvents.Details
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.V1.Common.Caching;
    using GW2DotNET.V1.DynamicEvents.Details.Types;

    /// <summary>Provides the interface for an event details service cache.</summary>
    public interface IDynamicEventDetailsServiceCache : IDynamicEventDetailsService
    {
        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        IEnumerable<DynamicEventDetails> GetDynamicEventDetails(bool allowCache);

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        IEnumerable<DynamicEventDetails> GetDynamicEventDetails(CultureInfo language, bool allowCache);

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        DynamicEventDetails GetDynamicEventDetails(Guid eventId, bool allowCache);

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="language">The language.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        DynamicEventDetails GetDynamicEventDetails(Guid eventId, CultureInfo language, bool allowCache);

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        Task<IEnumerable<DynamicEventDetails>> GetDynamicEventDetailsAsync(bool allowCache);

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        Task<IEnumerable<DynamicEventDetails>> GetDynamicEventDetailsAsync(CancellationToken cancellationToken, bool allowCache);

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        Task<IEnumerable<DynamicEventDetails>> GetDynamicEventDetailsAsync(CultureInfo language, bool allowCache);

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        Task<IEnumerable<DynamicEventDetails>> GetDynamicEventDetailsAsync(CultureInfo language, CancellationToken cancellationToken, bool allowCache);

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        Task<DynamicEventDetails> GetDynamicEventDetailsAsync(Guid eventId, bool allowCache);

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        Task<DynamicEventDetails> GetDynamicEventDetailsAsync(Guid eventId, CancellationToken cancellationToken, bool allowCache);

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="language">The language.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        Task<DynamicEventDetails> GetDynamicEventDetailsAsync(Guid eventId, CultureInfo language, bool allowCache);

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        Task<DynamicEventDetails> GetDynamicEventDetailsAsync(Guid eventId, CultureInfo language, CancellationToken cancellationToken, bool allowCache);

        /// <summary>Sets a collection of dynamic events and their localized details.</summary>
        /// <param name="dynamicEventDetails">A collection of dynamic events and their localized details.</param>
        /// <param name="language">The language.</param>
        void SetDynamicEventDetails(IEnumerable<DynamicEventDetails> dynamicEventDetails, CultureInfo language);

        /// <summary>Sets a collection of dynamic events and their localized details.</summary>
        /// <param name="dynamicEventDetails">A collection of dynamic events and their localized details.</param>
        /// <param name="language">The language.</param>
        /// <param name="parameters">The eviction and expiration details.</param>
        void SetDynamicEventDetails(IEnumerable<DynamicEventDetails> dynamicEventDetails, CultureInfo language, CacheItemParameters parameters);

        /// <summary>Sets a dynamic event and its localized details.</summary>
        /// <param name="dynamicEventDetails">A dynamic event and its localized details.</param>
        /// <param name="language">The language.</param>
        void SetDynamicEventDetails(DynamicEventDetails dynamicEventDetails, CultureInfo language);

        /// <summary>Sets a dynamic event and its localized details.</summary>
        /// <param name="dynamicEventDetails">A dynamic event and its localized details.</param>
        /// <param name="language">The language.</param>
        /// <param name="parameters">The eviction and expiration details.</param>
        void SetDynamicEventDetails(DynamicEventDetails dynamicEventDetails, CultureInfo language, CacheItemParameters parameters);
    }
}