// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDynamicEventServiceCache.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for an events service cache.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.DynamicEvents
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.V1.DynamicEvents.Types;

    /// <summary>Provides the interface for an events service cache.</summary>
    public interface IDynamicEventServiceCache : IDynamicEventService
    {
        /// <summary>Gets a dynamic event and its status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A dynamic event and its status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        DynamicEvent GetDynamicEvent(Guid eventId, int worldId, bool allowCache);

        /// <summary>Gets a dynamic event and its status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A dynamic event and its status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        Task<DynamicEvent> GetDynamicEventAsync(Guid eventId, int worldId, bool allowCache);

        /// <summary>Gets a dynamic event and its status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A dynamic event and its status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        Task<DynamicEvent> GetDynamicEventAsync(Guid eventId, int worldId, CancellationToken cancellationToken, bool allowCache);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        IEnumerable<DynamicEvent> GetDynamicEvents(bool allowCache);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        Task<IEnumerable<DynamicEvent>> GetDynamicEventsAsync(bool allowCache);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        Task<IEnumerable<DynamicEvent>> GetDynamicEventsAsync(CancellationToken cancellationToken, bool allowCache);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        IEnumerable<DynamicEvent> GetDynamicEventsById(Guid eventId, bool allowCache);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        Task<IEnumerable<DynamicEvent>> GetDynamicEventsByIdAsync(Guid eventId, bool allowCache);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        Task<IEnumerable<DynamicEvent>> GetDynamicEventsByIdAsync(Guid eventId, CancellationToken cancellationToken, bool allowCache);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        IEnumerable<DynamicEvent> GetDynamicEventsByMap(int mapId, bool allowCache);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        IEnumerable<DynamicEvent> GetDynamicEventsByMap(int mapId, int worldId, bool allowCache);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        Task<IEnumerable<DynamicEvent>> GetDynamicEventsByMapAsync(int mapId, bool allowCache);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        Task<IEnumerable<DynamicEvent>> GetDynamicEventsByMapAsync(int mapId, CancellationToken cancellationToken, bool allowCache);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        Task<IEnumerable<DynamicEvent>> GetDynamicEventsByMapAsync(int mapId, int worldId, bool allowCache);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        Task<IEnumerable<DynamicEvent>> GetDynamicEventsByMapAsync(int mapId, int worldId, CancellationToken cancellationToken, bool allowCache);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        IEnumerable<DynamicEvent> GetDynamicEventsByWorld(int worldId, bool allowCache);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        Task<IEnumerable<DynamicEvent>> GetDynamicEventsByWorldAsync(int worldId, bool allowCache);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        Task<IEnumerable<DynamicEvent>> GetDynamicEventsByWorldAsync(int worldId, CancellationToken cancellationToken, bool allowCache);

        /// <summary>Sets a collection of dynamic events and their status.</summary>
        /// <param name="dynamicEvents">A collection of dynamic events and their status.</param>
        void SetDynamicEvents(IEnumerable<DynamicEvent> dynamicEvents);
    }
}