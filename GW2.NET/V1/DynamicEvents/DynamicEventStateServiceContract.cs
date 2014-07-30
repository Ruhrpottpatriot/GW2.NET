// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventStateServiceContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The dynamic event state service contract.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.DynamicEvents
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.DynamicEvents;

    /// <summary>The dynamic event state service contract.</summary>
    [ContractClassFor(typeof(IDynamicEventStateService))]
    internal abstract class DynamicEventStateServiceContract : IDynamicEventStateService
    {
        /// <summary>Gets a dynamic event and its status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A dynamic event and its status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public DynamicEventState GetDynamicEvent(Guid eventId, int worldId)
        {
            throw new NotImplementedException();
        }

        /// <summary>Gets a dynamic event and its status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A dynamic event and its status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<DynamicEventState> GetDynamicEventAsync(Guid eventId, int worldId)
        {
            Contract.Ensures(Contract.Result<Task<DynamicEventState>>() != null);
            throw new NotImplementedException();
        }

        /// <summary>Gets a dynamic event and its status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A dynamic event and its status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<DynamicEventState> GetDynamicEventAsync(Guid eventId, int worldId, CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<DynamicEventState>>() != null);
            throw new NotImplementedException();
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IDictionary<Guid, DynamicEventState> GetDynamicEvents()
        {
            Contract.Ensures(Contract.Result<IDictionary<Guid, DynamicEventState>>() != null);
            throw new NotImplementedException();
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IDictionary<Guid, DynamicEventState>> GetDynamicEventsAsync()
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEventState>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEventState>>>().Result != null);
            throw new NotImplementedException();
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IDictionary<Guid, DynamicEventState>> GetDynamicEventsAsync(CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEventState>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEventState>>>().Result != null);
            throw new NotImplementedException();
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IDictionary<Guid, DynamicEventState> GetDynamicEventsById(Guid eventId)
        {
            Contract.Ensures(Contract.Result<IDictionary<Guid, DynamicEventState>>() != null);
            throw new NotImplementedException();
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IDictionary<Guid, DynamicEventState>> GetDynamicEventsByIdAsync(Guid eventId)
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEventState>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEventState>>>().Result != null);
            throw new NotImplementedException();
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IDictionary<Guid, DynamicEventState>> GetDynamicEventsByIdAsync(Guid eventId, CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEventState>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEventState>>>().Result != null);
            throw new NotImplementedException();
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IDictionary<Guid, DynamicEventState> GetDynamicEventsByMap(int mapId)
        {
            Contract.Ensures(Contract.Result<IDictionary<Guid, DynamicEventState>>() != null);
            throw new NotImplementedException();
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IDictionary<Guid, DynamicEventState> GetDynamicEventsByMap(int mapId, int worldId)
        {
            Contract.Ensures(Contract.Result<IDictionary<Guid, DynamicEventState>>() != null);
            throw new NotImplementedException();
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IDictionary<Guid, DynamicEventState>> GetDynamicEventsByMapAsync(int mapId)
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEventState>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEventState>>>().Result != null);
            throw new NotImplementedException();
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IDictionary<Guid, DynamicEventState>> GetDynamicEventsByMapAsync(int mapId, CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEventState>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEventState>>>().Result != null);
            throw new NotImplementedException();
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IDictionary<Guid, DynamicEventState>> GetDynamicEventsByMapAsync(int mapId, int worldId)
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEventState>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEventState>>>().Result != null);
            throw new NotImplementedException();
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IDictionary<Guid, DynamicEventState>> GetDynamicEventsByMapAsync(int mapId, int worldId, CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEventState>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEventState>>>().Result != null);
            throw new NotImplementedException();
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IDictionary<Guid, DynamicEventState> GetDynamicEventsByWorld(int worldId)
        {
            Contract.Ensures(Contract.Result<IDictionary<Guid, DynamicEventState>>() != null);
            throw new NotImplementedException();
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IDictionary<Guid, DynamicEventState>> GetDynamicEventsByWorldAsync(int worldId)
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEventState>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEventState>>>().Result != null);
            throw new NotImplementedException();
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IDictionary<Guid, DynamicEventState>> GetDynamicEventsByWorldAsync(int worldId, CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEventState>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEventState>>>().Result != null);
            throw new NotImplementedException();
        }
    }
}