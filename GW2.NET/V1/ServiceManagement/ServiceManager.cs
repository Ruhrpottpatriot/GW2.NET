// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceManager.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the Guild Wars 2 service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.ServiceManagement
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Extensions;
    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Core.Builds;
    using GW2DotNET.V1.Core.Colors;
    using GW2DotNET.V1.Core.Common;
    using GW2DotNET.V1.Core.Continents;
    using GW2DotNET.V1.Core.DynamicEvents;
    using GW2DotNET.V1.Core.DynamicEvents.Details;
    using GW2DotNET.V1.Core.DynamicEvents.Names;
    using GW2DotNET.V1.Core.Files;
    using GW2DotNET.V1.Core.Guilds.Details;
    using GW2DotNET.V1.Core.Items.Details;
    using GW2DotNET.V1.Core.Maps;
    using GW2DotNET.V1.Core.Maps.Floors;
    using GW2DotNET.V1.Core.Maps.Names;
    using GW2DotNET.V1.Core.Recipes.Details;
    using GW2DotNET.V1.Core.Worlds.Names;
    using GW2DotNET.V1.Core.WorldVersusWorld.Matches;
    using GW2DotNET.V1.Core.WorldVersusWorld.Matches.Details;
    using GW2DotNET.V1.Core.WorldVersusWorld.Objectives.Names;
    using GW2DotNET.V1.ServiceManagement.ServiceRequests;

    using ColorPalette = GW2DotNET.V1.Core.Colors.ColorPalette;

    /// <summary>Provides the default implementation of the Guild Wars 2 service.</summary>
    public class ServiceManager : IServiceManager
    {
        /// <summary>Infrastructure. Stores a service client.</summary>
        private readonly IServiceClient dataService;

        /// <summary>Infrastructure. Stores a service client.</summary>
        private readonly IServiceClient renderService;

        /// <summary>Infrastructure. Stores the preferred language info.</summary>
        private CultureInfo preferredLanguageInfo;

        /// <summary>Initializes a new instance of the <see cref="ServiceManager"/> class.</summary>
        /// <param name="preferredLanguageInfo">The preferred language.</param>
        public ServiceManager(CultureInfo preferredLanguageInfo = null)
            : this(ServiceClient.DataServiceClient(), ServiceClient.RenderServiceClient(), preferredLanguageInfo)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ServiceManager"/> class.</summary>
        /// <param name="dataService">The da service client.</param>
        /// <param name="preferredLanguageInfo">The preferred language.</param>
        public ServiceManager(IServiceClient dataService, CultureInfo preferredLanguageInfo = null)
            : this(dataService, ServiceClient.RenderServiceClient(), preferredLanguageInfo)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ServiceManager"/> class.</summary>
        /// <param name="dataService">The data service client.</param>
        /// <param name="renderService">The render Service Client.</param>
        /// <param name="preferredLanguageInfo">The preferred language.</param>
        public ServiceManager(IServiceClient dataService, IServiceClient renderService, CultureInfo preferredLanguageInfo = null)
        {
            Preconditions.EnsureNotNull(paramName: "dataService", value: dataService);
            Preconditions.EnsureNotNull(paramName: "renderService", value: renderService);

            this.dataService = dataService;
            this.renderService = renderService;
            this.PreferredLanguageInfo = preferredLanguageInfo;
        }

        /// <summary>Gets or sets the preferred language.</summary>
        public CultureInfo PreferredLanguageInfo
        {
            get
            {
                return this.preferredLanguageInfo ?? CultureInfo.CurrentUICulture.GetValueOrDefaultIfNotSupported();
            }

            set
            {
                if (value != null && !this.preferredLanguageInfo.IsSupported())
                {
                    // if a language is specified but is not one of the supported languages
                    throw new NotSupportedException("The specified language is not supported");
                }

                this.preferredLanguageInfo = value;
            }
        }

        /// <summary>Gets the current game build.</summary>
        /// <returns>The current game build.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/build">wiki</a> for more information.</remarks>
        public Build GetBuild()
        {
            var request = new BuildRequest();
            var response = this.Get<Build>(request);

            return response;
        }

        /// <summary>Gets the current build.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The current game build.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/build">wiki</a> for more information.</remarks>
        public Task<Build> GetBuildAsync(CancellationToken? cancellationToken = null)
        {
            var request = new BuildRequest();
            var response = this.GetAsync<Build>(request, cancellationToken);

            return response;
        }

        /// <summary>Gets the collection of colors in the game.</summary>
        /// <returns>The collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public IEnumerable<ColorPalette> GetColors()
        {
            var request = new ColorsRequest { PreferredLanguageInfo = this.PreferredLanguageInfo };
            var response = this.Get<ColorsResult>(request);

            return response.Colors.Values;
        }

        /// <summary>Gets the collection of colors in the game.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public Task<IEnumerable<ColorPalette>> GetColorsAsync(CancellationToken? cancellationToken = null)
        {
            var request = new ColorsRequest { PreferredLanguageInfo = this.PreferredLanguageInfo };
            var response = this.GetAsync<ColorsResult>(request, cancellationToken);

            return this.Select(response, result => (IEnumerable<ColorPalette>)result.Colors.Values);
        }

        /// <summary>Gets the collection of continents in the game.</summary>
        /// <returns>The collection of continents</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        public IEnumerable<Continent> GetContinents()
        {
            var request = new ContinentsRequest();
            var response = this.Get<ContinentsResult>(request);

            return response.Continents.Values;
        }

        /// <summary>Gets the collection of continents in the game.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of continents</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Continent>> GetContinentsAsync(CancellationToken? cancellationToken = null)
        {
            var request = new ContinentsRequest();
            var response = this.GetAsync<ContinentsResult>(request, cancellationToken);

            return this.Select(response, result => (IEnumerable<Continent>)result.Continents.Values);
        }

        /// <summary>Gets a collection of dynamic events and their details.</summary>
        /// <returns>A collection of dynamic events.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEventDetails> GetDynamicEventDetails()
        {
            var request = new DynamicEventDetailsRequest { PreferredLanguageInfo = this.PreferredLanguageInfo };
            var response = this.Get<DynamicEventDetailsResult>(request);

            return response.EventDetails.Values;
        }

        /// <summary>Gets a collection of dynamic events and their details.</summary>
        /// <param name="dynamicEventName">The dynamic event filter.</param>
        /// <returns>A collection of dynamic events.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEventDetails> GetDynamicEventDetails(DynamicEventName dynamicEventName)
        {
            Preconditions.EnsureNotNull(paramName: "dynamicEventName", value: dynamicEventName);

            return this.GetDynamicEventDetails(dynamicEventName.Id);
        }

        /// <summary>Gets a collection of dynamic events and their details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <returns>A collection of dynamic events.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEventDetails> GetDynamicEventDetails(Guid eventId)
        {
            var request = new DynamicEventDetailsRequest { EventId = eventId, PreferredLanguageInfo = this.PreferredLanguageInfo };
            var response = this.Get<DynamicEventDetailsResult>(request);

            return response.EventDetails.Values;
        }

        /// <summary>Gets a collection of dynamic events and their details.</summary>
        /// <param name="dynamicEventName">The dynamic event filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventDetails>> GetDynamicEventDetailsAsync(
            DynamicEventName dynamicEventName,
            CancellationToken? cancellationToken = null)
        {
            Preconditions.EnsureNotNull(paramName: "dynamicEventName", value: dynamicEventName);

            return this.GetDynamicEventDetailsAsync(dynamicEventName.Id, cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventDetails>> GetDynamicEventDetailsAsync(Guid eventId, CancellationToken? cancellationToken = null)
        {
            var request = new DynamicEventDetailsRequest { EventId = eventId, PreferredLanguageInfo = this.PreferredLanguageInfo };
            var response = this.GetAsync<DynamicEventDetailsResult>(request, cancellationToken);

            return this.Select(response, result => (IEnumerable<DynamicEventDetails>)result.EventDetails.Values);
        }

        /// <summary>Gets a collection of dynamic events and their details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventDetails>> GetDynamicEventDetailsAsync(CancellationToken? cancellationToken = null)
        {
            var request = new DynamicEventDetailsRequest { PreferredLanguageInfo = this.PreferredLanguageInfo };
            var response = this.GetAsync<DynamicEventDetailsResult>(request, cancellationToken);

            return this.Select(response, result => (IEnumerable<DynamicEventDetails>)result.EventDetails.Values);
        }

        /// <summary>Gets the collection of dynamic events and their localized name.</summary>
        /// <returns>The collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEventName> GetDynamicEventNames()
        {
            var request = new DynamicEventNamesRequest { PreferredLanguageInfo = this.PreferredLanguageInfo };
            var response = this.Get<DynamicEventNameCollection>(request);

            return response;
        }

        /// <summary>Gets the collection of dynamic events and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventName>> GetDynamicEventNamesAsync(CancellationToken? cancellationToken = null)
        {
            var request = new DynamicEventNamesRequest { PreferredLanguageInfo = this.PreferredLanguageInfo };
            var response = this.GetAsync<DynamicEventNameCollection>(request, cancellationToken);

            return this.Select(response, result => (IEnumerable<DynamicEventName>)result);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEvent> GetDynamicEvents()
        {
            var request = new DynamicEventRequest();
            var response = this.Get<DynamicEventsResult>(request);

            return response.Events;
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsAsync(CancellationToken? cancellationToken = null)
        {
            var request = new DynamicEventRequest();
            var response = this.GetAsync<DynamicEventsResult>(request);

            return this.Select(response, result => (IEnumerable<DynamicEvent>)result.Events);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEvent> GetDynamicEventsById(Guid eventId)
        {
            var request = new DynamicEventRequest { EventId = eventId };
            var response = this.Get<DynamicEventsResult>(request);

            return response.Events;
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEvent> GetDynamicEventsById(Guid eventId, int worldId)
        {
            var request = new DynamicEventRequest { EventId = eventId, WorldId = worldId };
            var response = this.Get<DynamicEventsResult>(request);

            return response.Events;
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldName">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEvent> GetDynamicEventsById(Guid eventId, WorldName worldName)
        {
            Preconditions.EnsureNotNull(paramName: "worldName", value: worldName);

            return this.GetDynamicEventsById(eventId, worldName.Id);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsByIdAsync(Guid eventId, CancellationToken? cancellationToken = null)
        {
            var request = new DynamicEventRequest { EventId = eventId };
            var response = this.GetAsync<DynamicEventsResult>(request, cancellationToken);

            return this.Select(response, result => (IEnumerable<DynamicEvent>)result.Events);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsByIdAsync(Guid eventId, int worldId, CancellationToken? cancellationToken = null)
        {
            var request = new DynamicEventRequest { EventId = eventId, WorldId = worldId };
            var response = this.GetAsync<DynamicEventsResult>(request, cancellationToken);

            return this.Select(response, result => (IEnumerable<DynamicEvent>)result.Events);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldName">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsByIdAsync(Guid eventId, WorldName worldName, CancellationToken? cancellationToken = null)
        {
            Preconditions.EnsureNotNull(paramName: "worldName", value: worldName);

            return this.GetDynamicEventsByIdAsync(eventId, worldName.Id, cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEvent> GetDynamicEventsByMap(int mapId)
        {
            var request = new DynamicEventRequest { MapId = mapId };
            var response = this.Get<DynamicEventsResult>(request);

            return response.Events;
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEvent> GetDynamicEventsByMap(int mapId, int worldId)
        {
            var request = new DynamicEventRequest { MapId = mapId, WorldId = worldId };
            var response = this.Get<DynamicEventsResult>(request);

            return response.Events;
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapName">The map filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEvent> GetDynamicEventsByMap(MapName mapName)
        {
            Preconditions.EnsureNotNull(paramName: "mapName", value: mapName);

            return this.GetDynamicEventsByMap(mapName.Id);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapName">The map filter.</param>
        /// <param name="worldName">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEvent> GetDynamicEventsByMap(MapName mapName, WorldName worldName)
        {
            Preconditions.EnsureNotNull(paramName: "mapName", value: mapName);
            Preconditions.EnsureNotNull(paramName: "worldName", value: worldName);

            return this.GetDynamicEventsByMap(mapName.Id, worldName.Id);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsByMapAsync(int mapId, CancellationToken? cancellationToken = null)
        {
            var request = new DynamicEventRequest { MapId = mapId };
            var response = this.GetAsync<DynamicEventsResult>(request, cancellationToken);

            return this.Select(response, result => (IEnumerable<DynamicEvent>)result.Events);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsByMapAsync(int mapId, int worldId, CancellationToken? cancellationToken = null)
        {
            var request = new DynamicEventRequest { MapId = mapId, WorldId = worldId };
            var response = this.GetAsync<DynamicEventsResult>(request, cancellationToken);

            return this.Select(response, result => (IEnumerable<DynamicEvent>)result.Events);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapName">The map filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsByMapAsync(MapName mapName, CancellationToken? cancellationToken = null)
        {
            Preconditions.EnsureNotNull(paramName: "mapName", value: mapName);

            return this.GetDynamicEventsByMapAsync(mapName.Id, cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapName">The map filter.</param>
        /// <param name="worldName">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsByMapAsync(MapName mapName, WorldName worldName, CancellationToken? cancellationToken = null)
        {
            Preconditions.EnsureNotNull(paramName: "mapName", value: mapName);
            Preconditions.EnsureNotNull(paramName: "worldName", value: worldName);

            return this.GetDynamicEventsByMapAsync(mapName.Id, worldName.Id, cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEvent> GetDynamicEventsByWorld(int worldId)
        {
            var request = new DynamicEventRequest { WorldId = worldId };
            var response = this.Get<DynamicEventsResult>(request);

            return response.Events;
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldName">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEvent> GetDynamicEventsByWorld(WorldName worldName)
        {
            Preconditions.EnsureNotNull(paramName: "worldName", value: worldName);

            return this.GetDynamicEventsByWorld(worldName.Id);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsByWorldAsync(int worldId, CancellationToken? cancellationToken = null)
        {
            var request = new DynamicEventRequest { WorldId = worldId };
            var response = this.GetAsync<DynamicEventsResult>(request, cancellationToken);

            return this.Select(response, result => (IEnumerable<DynamicEvent>)result.Events);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldName">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsByWorldAsync(WorldName worldName, CancellationToken? cancellationToken = null)
        {
            Preconditions.EnsureNotNull(paramName: "worldName", value: worldName);

            return this.GetDynamicEventsByWorldAsync(worldName.Id, cancellationToken);
        }

        /// <summary>Gets a collection of commonly requested in-game assets.</summary>
        /// <returns>A collection of commonly requested in-game assets.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/files">wiki</a> for more information.</remarks>
        public IEnumerable<Asset> GetFiles()
        {
            var request = new FilesRequest();
            var response = this.Get<AssetCollection>(request);

            return response.Values;
        }

        /// <summary>Gets a collection of commonly requested in-game assets.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of commonly requested in-game assets.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/files">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Asset>> GetFilesAsync(CancellationToken? cancellationToken = null)
        {
            var request = new FilesRequest();
            Task<AssetCollection> response = this.GetAsync<AssetCollection>(request, cancellationToken);

            return this.Select(response, result => (IEnumerable<Asset>)result.Values);
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildId">The guild's ID.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public Guild GetGuildDetails(Guid guildId)
        {
            var request = new GuildDetailsRequest { GuildId = guildId };
            var response = this.Get<Guild>(request);

            return response;
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildName">The guild's name.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public Guild GetGuildDetails(string guildName)
        {
            var request = new GuildDetailsRequest { GuildName = guildName };
            var response = this.Get<Guild>(request);

            return response;
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildId">The guild's ID.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public Task<Guild> GetGuildDetailsAsync(Guid guildId, CancellationToken? cancellationToken = null)
        {
            var request = new GuildDetailsRequest { GuildId = guildId };
            Task<Guild> response = this.GetAsync<Guild>(request, cancellationToken);

            return response;
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildName">The guild's name.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public Task<Guild> GetGuildDetailsAsync(string guildName, CancellationToken? cancellationToken = null)
        {
            var request = new GuildDetailsRequest { GuildName = guildName };
            Task<Guild> response = this.GetAsync<Guild>(request, cancellationToken);

            return response;
        }

        /// <summary>Renders an image.</summary>
        /// <param name="file">The file.</param>
        /// <param name="imageFormat">The image Format.</param>
        /// <returns>The <see cref="Image"/>.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:Render_service">wiki</a> for more information.</remarks>
        public Image GetImage(IRenderable file, ImageFormat imageFormat)
        {
            var request = new RenderFileRequest(file, imageFormat);
            var response = this.Get<Image>(this.renderService, request);

            return response;
        }

        /// <summary>Renders an image.</summary>
        /// <param name="file">The file.</param>
        /// <param name="imageFormat">The image format.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <see cref="Image"/>.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:Render_service">wiki</a> for more information.</remarks>
        public Task<Image> GetImageAsync(IRenderable file, ImageFormat imageFormat, CancellationToken? cancellationToken = null)
        {
            var request = new RenderFileRequest(file, imageFormat);
            var response = this.GetAsync<Image>(this.renderService, request, cancellationToken);

            return response;
        }

        /// <summary>Gets an item and its details.</summary>
        /// <param name="itemId">The item's ID.</param>
        /// <returns>An item and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Item GetItemDetails(int itemId)
        {
            var request = new ItemDetailsRequest { ItemId = itemId, PreferredLanguageInfo = this.PreferredLanguageInfo };
            var response = this.Get<Item>(request);

            return response;
        }

        /// <summary>Gets an item and its details.</summary>
        /// <param name="itemId">The item's ID.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>An item and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Task<Item> GetItemDetailsAsync(int itemId, CancellationToken? cancellationToken = null)
        {
            var request = new ItemDetailsRequest { ItemId = itemId, PreferredLanguageInfo = this.PreferredLanguageInfo };
            Task<Item> response = this.GetAsync<Item>(request, cancellationToken);

            return response;
        }

        /// <summary>Gets the collection of discovered items.</summary>
        /// <returns>The collection of discovered items.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/items">wiki</a> for more information.</remarks>
        public IEnumerable<int> GetItems()
        {
            var request = new ItemsRequest();
            var response = this.Get<ItemsResult>(request);

            return response.Items;
        }

        /// <summary>Gets the collection of discovered items.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of discovered items.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/items">wiki</a> for more information.</remarks>
        public Task<IEnumerable<int>> GetItemsAsync(CancellationToken? cancellationToken = null)
        {
            var request = new ItemsRequest();
            Task<ItemsResult> response = this.GetAsync<ItemsResult>(request, cancellationToken);

            return this.Select(response, result => (IEnumerable<int>)result.Items);
        }

        /// <summary>Gets a map floor and its details.</summary>
        /// <param name="continent">The continent.</param>
        /// <param name="floor">The map floor.</param>
        /// <returns>A map floor and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public Floor GetMapFloor(Continent continent, int floor)
        {
            Preconditions.EnsureNotNull(paramName: "continent", value: continent);

            return this.GetMapFloor(continent.ContinentId, floor);
        }

        /// <summary>Gets a map floor and its details.</summary>
        /// <param name="continentId">The continent.</param>
        /// <param name="floor">The map floor.</param>
        /// <returns>A map floor and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public Floor GetMapFloor(int continentId, int floor)
        {
            var request = new MapFloorRequest { ContinentId = continentId, Floor = floor, PreferredLanguageInfo = this.PreferredLanguageInfo };
            var response = this.Get<Floor>(request);

            response.ContinentId = continentId;
            response.FloorNumber = floor;

            return response;
        }

        /// <summary>Gets a map floor and its details.</summary>
        /// <param name="continent">The continent.</param>
        /// <param name="floor">The map floor.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A map floor and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public Task<Floor> GetMapFloorAsync(Continent continent, int floor, CancellationToken? cancellationToken = null)
        {
            Preconditions.EnsureNotNull(paramName: "continent", value: continent);

            return this.GetMapFloorAsync(continent.ContinentId, floor, cancellationToken);
        }

        /// <summary>Gets a map floor and its details.</summary>
        /// <param name="continentId">The continent.</param>
        /// <param name="floor">The map floor.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A map floor and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public Task<Floor> GetMapFloorAsync(int continentId, int floor, CancellationToken? cancellationToken = null)
        {
            var request = new MapFloorRequest { ContinentId = continentId, Floor = floor, PreferredLanguageInfo = this.PreferredLanguageInfo };
            var response = this.GetAsync<Floor>(request, cancellationToken);
            response.ContinueWith(
                task =>
                {
                    var mapFloor = task.Result;
                    mapFloor.ContinentId = continentId;
                    mapFloor.FloorNumber = floor;
                });

            return response;
        }

        /// <summary>Gets the collection of maps and their localized name.</summary>
        /// <returns>The collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public IEnumerable<MapName> GetMapNames()
        {
            var request = new MapNamesRequest { PreferredLanguageInfo = this.PreferredLanguageInfo };
            var response = this.Get<MapNameCollection>(request);

            return response;
        }

        /// <summary>Gets the collection of maps and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<MapName>> GetMapNamesAsync(CancellationToken? cancellationToken = null)
        {
            var request = new MapNamesRequest { PreferredLanguageInfo = this.PreferredLanguageInfo };
            var response = this.GetAsync<MapNameCollection>(request, cancellationToken);

            return this.Select(response, result => (IEnumerable<MapName>)result);
        }

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <returns>A collection of maps and their details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public IEnumerable<Map> GetMaps()
        {
            var request = new MapDetailsRequest { PreferredLanguageInfo = this.PreferredLanguageInfo };
            var response = this.Get<MapsResult>(request);

            return response.Maps.Values;
        }

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <param name="mapName">The map filter.</param>
        /// <returns>A collection of maps and their details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public IEnumerable<Map> GetMaps(MapName mapName)
        {
            Preconditions.EnsureNotNull(paramName: "mapName", value: mapName);

            return this.GetMaps(mapName.Id);
        }

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <returns>A collection of maps and their details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public IEnumerable<Map> GetMaps(int mapId)
        {
            var request = new MapDetailsRequest { MapId = mapId, PreferredLanguageInfo = this.PreferredLanguageInfo };
            var response = this.Get<MapsResult>(request);

            return response.Maps.Values;
        }

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Map>> GetMapsAsync(CancellationToken? cancellationToken = null)
        {
            var request = new MapDetailsRequest { PreferredLanguageInfo = this.PreferredLanguageInfo };
            Task<MapsResult> response = this.GetAsync<MapsResult>(request, cancellationToken);

            return this.Select(response, result => (IEnumerable<Map>)result.Maps.Values);
        }

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <param name="mapName">The map filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Map>> GetMapsAsync(MapName mapName, CancellationToken? cancellationToken = null)
        {
            Preconditions.EnsureNotNull(paramName: "mapName", value: mapName);

            return this.GetMapsAsync(mapName.Id, cancellationToken);
        }

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Map>> GetMapsAsync(int mapId, CancellationToken? cancellationToken = null)
        {
            var request = new MapDetailsRequest { MapId = mapId, PreferredLanguageInfo = this.PreferredLanguageInfo };
            Task<MapsResult> response = this.GetAsync<MapsResult>(request, cancellationToken);

            return this.Select(response, result => (IEnumerable<Map>)result.Maps.Values);
        }

        /// <summary>Gets a World versus World match and its details.</summary>
        /// <param name="matchId">The match.</param>
        /// <returns>A World versus World match and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/match_details">wiki</a> for more information.</remarks>
        public MatchDetails GetMatchDetails(string matchId)
        {
            var request = new MatchDetailsRequest { MatchId = matchId };
            var response = this.Get<MatchDetails>(request);

            return response;
        }

        /// <summary>Gets a World versus World match and its details.</summary>
        /// <param name="matchId">The match.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A World versus World match and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/match_details">wiki</a> for more information.</remarks>
        public Task<MatchDetails> GetMatchDetailsAsync(string matchId, CancellationToken? cancellationToken = null)
        {
            var request = new MatchDetailsRequest { MatchId = matchId };
            Task<MatchDetails> response = this.GetAsync<MatchDetails>(request, cancellationToken);

            return response;
        }

        /// <summary>Gets the collection of currently running World versus World matches.</summary>
        /// <returns>The collection of currently running World versus World matches.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/matches">wiki</a> for more information.</remarks>
        public IEnumerable<Match> GetMatches()
        {
            var request = new MatchesRequest();
            var response = this.Get<MatchesResult>(request);

            return response.Matches;
        }

        /// <summary>Gets the collection of currently running World versus World matches.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of currently running World versus World matches.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/matches">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Match>> GetMatchesAsync(CancellationToken? cancellationToken = null)
        {
            var request = new MatchesRequest();
            var response = this.GetAsync<MatchesResult>(request, cancellationToken);

            return this.Select(response, result => (IEnumerable<Match>)result.Matches);
        }

        /// <summary>Gets the collection of World versus World objectives and their localized name.</summary>
        /// <returns>The collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public IEnumerable<ObjectiveName> GetObjectiveNames()
        {
            var request = new ObjectiveNamesRequest { PreferredLanguageInfo = this.PreferredLanguageInfo };
            var response = this.Get<ObjectiveNameCollection>(request);

            return response;
        }

        /// <summary>Gets the collection of World versus World objectives and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<ObjectiveName>> GetObjectiveNamesAsync(CancellationToken? cancellationToken = null)
        {
            var request = new ObjectiveNamesRequest { PreferredLanguageInfo = this.PreferredLanguageInfo };
            var response = this.GetAsync<ObjectiveNameCollection>(request, cancellationToken);

            return this.Select(response, result => (IEnumerable<ObjectiveName>)result);
        }

        /// <summary>Gets a recipe and its details.</summary>
        /// <param name="recipe">The recipe.</param>
        /// <returns>A recipe and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Recipe GetRecipeDetails(Recipe recipe)
        {
            Preconditions.EnsureNotNull(paramName: "recipe", value: recipe);

            return this.GetRecipeDetails(recipe.RecipeId);
        }

        /// <summary>Gets a recipe and its details.</summary>
        /// <param name="recipeId">The recipe.</param>
        /// <returns>A recipe and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Recipe GetRecipeDetails(int recipeId)
        {
            var request = new RecipeDetailsRequest { RecipeId = recipeId, PreferredLanguageInfo = this.PreferredLanguageInfo };
            var response = this.Get<Recipe>(request);

            return response;
        }

        /// <summary>Gets a recipe and its details.</summary>
        /// <param name="recipe">The recipe.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A recipe and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Task<Recipe> GetRecipeDetailsAsync(Recipe recipe, CancellationToken? cancellationToken = null)
        {
            Preconditions.EnsureNotNull(paramName: "recipe", value: recipe);

            return this.GetRecipeDetailsAsync(recipe.RecipeId, cancellationToken);
        }

        /// <summary>Gets a recipe and its details.</summary>
        /// <param name="recipeId">The recipe.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A recipe and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Task<Recipe> GetRecipeDetailsAsync(int recipeId, CancellationToken? cancellationToken = null)
        {
            var request = new RecipeDetailsRequest { RecipeId = recipeId, PreferredLanguageInfo = this.PreferredLanguageInfo };
            Task<Recipe> response = this.GetAsync<Recipe>(request, cancellationToken);

            return response;
        }

        /// <summary>Gets the collection of discovered recipes.</summary>
        /// <returns>The collection of discovered recipes.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes">wiki</a> for more information.</remarks>
        public IEnumerable<int> GetRecipes()
        {
            var request = new RecipesRequest();
            var response = this.Get<RecipesResult>(request);

            return response.Recipes;
        }

        /// <summary>Gets the collection of discovered recipes.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of discovered recipes.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes">wiki</a> for more information.</remarks>
        public Task<IEnumerable<int>> GetRecipesAsync(CancellationToken? cancellationToken = null)
        {
            var request = new RecipesRequest();
            Task<RecipesResult> response = this.GetAsync<RecipesResult>(request, cancellationToken);

            return this.Select(response, result => (IEnumerable<int>)result.Recipes);
        }

        /// <summary>Gets the collection of worlds and their localized name.</summary>
        /// <returns>The collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public IEnumerable<WorldName> GetWorldNames()
        {
            var request = new WorldNamesRequest { PreferredLanguageInfo = this.PreferredLanguageInfo };
            var response = this.Get<WorldNameCollection>(request);

            return response;
        }

        /// <summary>Gets the collection of worlds and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<WorldName>> GetWorldNamesAsync(CancellationToken? cancellationToken = null)
        {
            var request = new WorldNamesRequest { PreferredLanguageInfo = this.PreferredLanguageInfo };
            var response = this.GetAsync<WorldNameCollection>(request, cancellationToken);

            return this.Select(response, result => (IEnumerable<WorldName>)result);
        }

        /// <summary>Infrastructure. Sends a request and gets the response.</summary>
        /// <param name="serviceRequest">The service request.</param>
        /// <typeparam name="TResult">The type of the response content</typeparam>
        /// <returns>The response content.</returns>
        private TResult Get<TResult>(ServiceRequest serviceRequest) where TResult : class
        {
            return this.Get<TResult>(this.dataService, serviceRequest);
        }

        /// <summary>Infrastructure. Sends a request and gets the response.</summary>
        /// <param name="service">The service.</param>
        /// <param name="serviceRequest">The service request.</param>
        /// <typeparam name="TResult">The type of the response content</typeparam>
        /// <returns>The response content.</returns>
        private TResult Get<TResult>(IServiceClient service, ServiceRequest serviceRequest) where TResult : class
        {
            IServiceResponse<TResult> serviceResponse = null;
            try
            {
                serviceResponse = serviceRequest.GetResponse<TResult>(service);
                return serviceResponse.EnsureSuccessStatusCode().Deserialize();
            }
            finally
            {
                // clean up if necessary
                var disposable = serviceResponse as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
        }

        /// <summary>Infrastructure. Sends a request and gets the response.</summary>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The response content.</returns>
        private Task<TResult> GetAsync<TResult>(IServiceRequest request, CancellationToken? cancellationToken = null) where TResult : class
        {
            return this.GetAsync<TResult>(this.dataService, request, cancellationToken);
        }

        /// <summary>Infrastructure. Sends a request and gets the response.</summary>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <param name="service">The client.</param>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The response content.</returns>
        private Task<TResult> GetAsync<TResult>(IServiceClient service, IServiceRequest request, CancellationToken? cancellationToken = null)
            where TResult : class
        {
            var token = cancellationToken.GetValueOrDefault(CancellationToken.None);

            return request.GetResponseAsync<TResult>(service, token).ContinueWith(
                task =>
                {
                    IServiceResponse<TResult> serviceResponse = null;
                    try
                    {
                        serviceResponse = task.Result;
                        return serviceResponse.EnsureSuccessStatusCode().Deserialize();
                    }
                    finally
                    {
                        // clean up if necessary
                        var disposable = serviceResponse as IDisposable;
                        if (disposable != null)
                        {
                            disposable.Dispose();
                        }
                    }
                },
                token);
        }

        /// <summary>Gets the service response and selects a result based on the specified selector.</summary>
        /// <typeparam name="TContent">The type of the response content.</typeparam>
        /// <typeparam name="TResult">The type of the selected item.</typeparam>
        /// <param name="result">The response content.</param>
        /// <param name="selector">The selector.</param>
        /// <returns>The selected result.</returns>
        private Task<TResult> Select<TContent, TResult>(Task<TContent> result, Func<TContent, TResult> selector) where TContent : JsonObject
        {
            return result.ContinueWith(task => selector(task.Result));
        }
    }
}