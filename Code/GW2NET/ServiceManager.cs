// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceManager.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the Guild Wars 2 service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Common.Serializers;
    using GW2NET.Compression;
    using GW2NET.Entities.Builds;
    using GW2NET.Entities.DynamicEvents;
    using GW2NET.Entities.Recipes;
    using GW2NET.Entities.Skins;
    using GW2NET.Entities.Worlds;
    using GW2NET.V1.Builds;
    using GW2NET.V1.DynamicEvents;
    using GW2NET.V1.Skins;
    using GW2NET.V1.Worlds;

    /// <summary>Provides the default implementation of the Guild Wars 2 service.</summary>
    public class ServiceManager : IBuildService, 
                                  IDynamicEventService, 
                                  IWorldService, 
                                  ISkinService
    {
        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IBuildService buildService;

        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IDynamicEventService dynamicEventService;

        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly ISkinService skinService;

        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IWorldService worldService;

        /// <summary>Initializes a new instance of the <see cref="ServiceManager" /> class.</summary>
        public ServiceManager()
            : this(GetDefaultServiceClient())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ServiceManager"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public ServiceManager(IServiceClient serviceClient)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient", "Precondition failed: serviceClient != null");
            }

            Contract.EndContractBlock();

            this.buildService = new BuildService(serviceClient);
            this.dynamicEventService = new DynamicEventService(serviceClient);
            this.worldService = new WorldService(serviceClient);
            this.skinService = new SkinService(serviceClient);
        }

        /// <summary>Gets the current game build.</summary>
        /// <returns>The current game build.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/build">wiki</a> for more information.</remarks>
        public Build GetBuild()
        {
            return this.buildService.GetBuild();
        }

        /// <summary>Gets the current build.</summary>
        /// <returns>The current game build.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/build">wiki</a> for more information.</remarks>
        public Task<Build> GetBuildAsync()
        {
            return this.buildService.GetBuildAsync();
        }

        /// <summary>Gets the current build.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The current game build.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/build">wiki</a> for more information.</remarks>
        public Task<Build> GetBuildAsync(CancellationToken cancellationToken)
        {
            return this.buildService.GetBuildAsync(cancellationToken);
        }

        /// <summary>Gets a dynamic event and its status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A dynamic event and its status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        [Obsolete("events.json disabled", true)]
        public DynamicEventState GetDynamicEvent(Guid eventId, int worldId)
        {
            return this.dynamicEventService.GetDynamicEvent(eventId, worldId);
        }

        /// <summary>Gets a dynamic event and its status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A dynamic event and its status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        [Obsolete("events.json disabled", true)]
        public Task<DynamicEventState> GetDynamicEventAsync(Guid eventId, int worldId)
        {
            return this.dynamicEventService.GetDynamicEventAsync(eventId, worldId);
        }

        /// <summary>Gets a dynamic event and its status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A dynamic event and its status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        [Obsolete("events.json disabled", true)]
        public Task<DynamicEventState> GetDynamicEventAsync(Guid eventId, int worldId, CancellationToken cancellationToken)
        {
            return this.dynamicEventService.GetDynamicEventAsync(eventId, worldId, cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public IDictionary<Guid, DynamicEvent> GetDynamicEventDetails()
        {
            return this.dynamicEventService.GetDynamicEventDetails();
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public IDictionary<Guid, DynamicEvent> GetDynamicEventDetails(CultureInfo language)
        {
            return this.dynamicEventService.GetDynamicEventDetails(language);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public DynamicEvent GetDynamicEventDetails(Guid eventId)
        {
            return this.dynamicEventService.GetDynamicEventDetails(eventId);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="language">The language.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public DynamicEvent GetDynamicEventDetails(Guid eventId, CultureInfo language)
        {
            return this.dynamicEventService.GetDynamicEventDetails(eventId, language);
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<IDictionary<Guid, DynamicEvent>> GetDynamicEventDetailsAsync()
        {
            return this.dynamicEventService.GetDynamicEventDetailsAsync();
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<IDictionary<Guid, DynamicEvent>> GetDynamicEventDetailsAsync(CancellationToken cancellationToken)
        {
            return this.dynamicEventService.GetDynamicEventDetailsAsync(cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<IDictionary<Guid, DynamicEvent>> GetDynamicEventDetailsAsync(CultureInfo language)
        {
            return this.dynamicEventService.GetDynamicEventDetailsAsync(language);
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<IDictionary<Guid, DynamicEvent>> GetDynamicEventDetailsAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            return this.dynamicEventService.GetDynamicEventDetailsAsync(language, cancellationToken);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<DynamicEvent> GetDynamicEventDetailsAsync(Guid eventId)
        {
            return this.dynamicEventService.GetDynamicEventDetailsAsync(eventId);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<DynamicEvent> GetDynamicEventDetailsAsync(Guid eventId, CancellationToken cancellationToken)
        {
            return this.dynamicEventService.GetDynamicEventDetailsAsync(eventId, cancellationToken);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="language">The language.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<DynamicEvent> GetDynamicEventDetailsAsync(Guid eventId, CultureInfo language)
        {
            return this.dynamicEventService.GetDynamicEventDetailsAsync(eventId, language);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<DynamicEvent> GetDynamicEventDetailsAsync(Guid eventId, CultureInfo language, CancellationToken cancellationToken)
        {
            return this.dynamicEventService.GetDynamicEventDetailsAsync(eventId, language, cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public IDictionary<Guid, DynamicEvent> GetDynamicEventNames()
        {
            return this.dynamicEventService.GetDynamicEventNames();
        }

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public IDictionary<Guid, DynamicEvent> GetDynamicEventNames(CultureInfo language)
        {
            return this.dynamicEventService.GetDynamicEventNames(language);
        }

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<Guid, DynamicEvent>> GetDynamicEventNamesAsync()
        {
            return this.dynamicEventService.GetDynamicEventNamesAsync();
        }

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<Guid, DynamicEvent>> GetDynamicEventNamesAsync(CancellationToken cancellationToken)
        {
            return this.dynamicEventService.GetDynamicEventNamesAsync(cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<Guid, DynamicEvent>> GetDynamicEventNamesAsync(CultureInfo language)
        {
            return this.dynamicEventService.GetDynamicEventNamesAsync(language);
        }

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<Guid, DynamicEvent>> GetDynamicEventNamesAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            return this.dynamicEventService.GetDynamicEventNamesAsync(language, cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        [Obsolete("events.json disabled", true)]
        public IDictionary<Guid, DynamicEventState> GetDynamicEvents()
        {
            return this.dynamicEventService.GetDynamicEvents();
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        [Obsolete("events.json disabled", true)]
        public Task<IDictionary<Guid, DynamicEventState>> GetDynamicEventsAsync()
        {
            return this.dynamicEventService.GetDynamicEventsAsync();
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        [Obsolete("events.json disabled", true)]
        public Task<IDictionary<Guid, DynamicEventState>> GetDynamicEventsAsync(CancellationToken cancellationToken)
        {
            return this.dynamicEventService.GetDynamicEventsAsync(cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        [Obsolete("events.json disabled", true)]
        public IDictionary<Guid, DynamicEventState> GetDynamicEventsById(Guid eventId)
        {
            return this.dynamicEventService.GetDynamicEventsById(eventId);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        [Obsolete("events.json disabled", true)]
        public Task<IDictionary<Guid, DynamicEventState>> GetDynamicEventsByIdAsync(Guid eventId)
        {
            return this.dynamicEventService.GetDynamicEventsByIdAsync(eventId);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        [Obsolete("events.json disabled", true)]
        public Task<IDictionary<Guid, DynamicEventState>> GetDynamicEventsByIdAsync(Guid eventId, CancellationToken cancellationToken)
        {
            return this.dynamicEventService.GetDynamicEventsByIdAsync(eventId, cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        [Obsolete("events.json disabled", true)]
        public IDictionary<Guid, DynamicEventState> GetDynamicEventsByMap(int mapId)
        {
            return this.dynamicEventService.GetDynamicEventsByMap(mapId);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        [Obsolete("events.json disabled", true)]
        public IDictionary<Guid, DynamicEventState> GetDynamicEventsByMap(int mapId, int worldId)
        {
            return this.dynamicEventService.GetDynamicEventsByMap(mapId, worldId);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        [Obsolete("events.json disabled", true)]
        public Task<IDictionary<Guid, DynamicEventState>> GetDynamicEventsByMapAsync(int mapId)
        {
            return this.dynamicEventService.GetDynamicEventsByMapAsync(mapId);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        [Obsolete("events.json disabled", true)]
        public Task<IDictionary<Guid, DynamicEventState>> GetDynamicEventsByMapAsync(int mapId, CancellationToken cancellationToken)
        {
            return this.dynamicEventService.GetDynamicEventsByMapAsync(mapId, cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        [Obsolete("events.json disabled", true)]
        public Task<IDictionary<Guid, DynamicEventState>> GetDynamicEventsByMapAsync(int mapId, int worldId)
        {
            return this.dynamicEventService.GetDynamicEventsByMapAsync(mapId, worldId);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        [Obsolete("events.json disabled", true)]
        public Task<IDictionary<Guid, DynamicEventState>> GetDynamicEventsByMapAsync(int mapId, int worldId, CancellationToken cancellationToken)
        {
            return this.dynamicEventService.GetDynamicEventsByMapAsync(mapId, worldId, cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        [Obsolete("events.json disabled", true)]
        public IDictionary<Guid, DynamicEventState> GetDynamicEventsByWorld(int worldId)
        {
            return this.dynamicEventService.GetDynamicEventsByWorld(worldId);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        [Obsolete("events.json disabled", true)]
        public Task<IDictionary<Guid, DynamicEventState>> GetDynamicEventsByWorldAsync(int worldId)
        {
            return this.dynamicEventService.GetDynamicEventsByWorldAsync(worldId);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        [Obsolete("events.json disabled", true)]
        public Task<IDictionary<Guid, DynamicEventState>> GetDynamicEventsByWorldAsync(int worldId, CancellationToken cancellationToken)
        {
            return this.dynamicEventService.GetDynamicEventsByWorldAsync(worldId, cancellationToken);
        }
        
        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skin">The skin identifier.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        public Skin GetSkinDetails(int skin)
        {
            return this.skinService.GetSkinDetails(skin);
        }

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skin">The skin identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        public Skin GetSkinDetails(int skin, CultureInfo language)
        {
            return this.skinService.GetSkinDetails(skin, language);
        }

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skin">The skin identifier.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        public Task<Skin> GetSkinDetailsAsync(int skin)
        {
            return this.skinService.GetSkinDetailsAsync(skin);
        }

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skin">The skin identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        public Task<Skin> GetSkinDetailsAsync(int skin, CultureInfo language)
        {
            return this.skinService.GetSkinDetailsAsync(skin, language);
        }

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skin">The skin identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        public Task<Skin> GetSkinDetailsAsync(int skin, CancellationToken cancellationToken)
        {
            return this.skinService.GetSkinDetailsAsync(skin, cancellationToken);
        }

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skin">The skin identifier.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        public Task<Skin> GetSkinDetailsAsync(int skin, CultureInfo language, CancellationToken cancellationToken)
        {
            return this.skinService.GetSkinDetailsAsync(skin, language, cancellationToken);
        }

        /// <summary>Gets a collection of skin identifiers.</summary>
        /// <returns>A collection of skin identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skins">wiki</a> for more information.</remarks>
        public ICollection<int> GetSkins()
        {
            return this.skinService.GetSkins();
        }

        /// <summary>Gets a collection of skin identifiers.</summary>
        /// <returns>A collection of skin identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skins">wiki</a> for more information.</remarks>
        public Task<ICollection<int>> GetSkinsAsync()
        {
            return this.skinService.GetSkinsAsync();
        }

        /// <summary>Gets a collection of skin identifiers.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of skin identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skins">wiki</a> for more information.</remarks>
        public Task<ICollection<int>> GetSkinsAsync(CancellationToken cancellationToken)
        {
            return this.skinService.GetSkinsAsync(cancellationToken);
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public IDictionary<int, World> GetWorldNames()
        {
            return this.worldService.GetWorldNames();
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public IDictionary<int, World> GetWorldNames(CultureInfo language)
        {
            return this.worldService.GetWorldNames(language);
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, World>> GetWorldNamesAsync()
        {
            return this.worldService.GetWorldNamesAsync();
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, World>> GetWorldNamesAsync(CancellationToken cancellationToken)
        {
            return this.worldService.GetWorldNamesAsync(cancellationToken);
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, World>> GetWorldNamesAsync(CultureInfo language)
        {
            return this.worldService.GetWorldNamesAsync(language);
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, World>> GetWorldNamesAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            return this.worldService.GetWorldNamesAsync(language, cancellationToken);
        }

        /// <summary>Gets the base URI.</summary>
        /// <returns>A <see cref="Uri"/>.</returns>
        private static Uri GetBaseUri()
        {
            Contract.Ensures(Contract.Result<Uri>() != null);
            Contract.Ensures(Contract.Result<Uri>().IsAbsoluteUri);
            var baseUri = new Uri("https://api.guildwars2.com", UriKind.Absolute);
            Contract.Assume(baseUri.IsAbsoluteUri);
            return baseUri;
        }

        /// <summary>Infrastructure. Creates and configures an instance of the default service client.</summary>
        /// <returns>The <see cref="IServiceClient"/>.</returns>
        private static IServiceClient GetDefaultServiceClient()
        {
            Contract.Ensures(Contract.Result<IServiceClient>() != null);
            var baseUri = GetBaseUri();
            var successSerializerFactory = new JsonSerializerFactory();
            var errorSerializerFactory = new DataContractJsonSerializerFactory();
            var gzipInflator = new GzipInflator();
            return new ServiceClient(baseUri, successSerializerFactory, errorSerializerFactory, gzipInflator);
        }

        /// <summary>The invariant method for this class.</summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.buildService != null);
            Contract.Invariant(this.dynamicEventService != null);
            Contract.Invariant(this.worldService != null);
            Contract.Invariant(this.skinService != null);
        }
    }
}