// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceManager.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides a RestSharp-specific implementation of the Guild Wars 2 service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace RestSharp.GW2DotNET
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Globalization;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    using global::GW2DotNET.Utilities;

    using global::GW2DotNET.V1;

    using global::GW2DotNET.V1.Core;

    using global::GW2DotNET.V1.Core.Builds;

    using global::GW2DotNET.V1.Core.Colors;

    using global::GW2DotNET.V1.Core.Continents;

    using global::GW2DotNET.V1.Core.DynamicEvents;

    using global::GW2DotNET.V1.Core.DynamicEvents.Details;

    using global::GW2DotNET.V1.Core.DynamicEvents.Names;

    using global::GW2DotNET.V1.Core.Files;

    using global::GW2DotNET.V1.Core.Guilds.Details;

    using global::GW2DotNET.V1.Core.Items;

    using global::GW2DotNET.V1.Core.Items.Details;

    using global::GW2DotNET.V1.Core.Maps;

    using global::GW2DotNET.V1.Core.Maps.Floors;

    using global::GW2DotNET.V1.Core.Maps.Names;

    using global::GW2DotNET.V1.Core.Recipes;

    using global::GW2DotNET.V1.Core.Recipes.Details;

    using global::GW2DotNET.V1.Core.Worlds.Names;

    using global::GW2DotNET.V1.Core.WorldVersusWorld.Matches;

    using global::GW2DotNET.V1.Core.WorldVersusWorld.Matches.Details;

    using global::GW2DotNET.V1.Core.WorldVersusWorld.Objectives.Names;

    using RestSharp.GW2DotNET.Requests;

    /// <summary>
    ///     Provides a RestSharp-specific implementation of the Guild Wars 2 service.
    /// </summary>
    public class ServiceManager : IServiceManager
    {
        /// <summary>Infrastructure. Stores the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Infrastructure. Stores the preferred language info.</summary>
        private CultureInfo preferredLanguageInfo;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ServiceManager" /> class.
        /// </summary>
        public ServiceManager()
            : this(ServiceClient.Create(), null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ServiceManager"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public ServiceManager(IServiceClient serviceClient)
            : this(serviceClient, null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ServiceManager"/> class.</summary>
        /// <param name="preferredLanguageInfo">The preferred language.</param>
        public ServiceManager(CultureInfo preferredLanguageInfo)
            : this(ServiceClient.Create(), preferredLanguageInfo)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ServiceManager"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="preferredLanguageInfo">The preferred language.</param>
        public ServiceManager(IServiceClient serviceClient, CultureInfo preferredLanguageInfo)
        {
            Preconditions.EnsureNotNull(paramName: "serviceClient", value: serviceClient);

            this.serviceClient = serviceClient;
            this.preferredLanguageInfo = preferredLanguageInfo;
        }

        /// <summary>
        ///     Gets or sets the preferred language.
        /// </summary>
        public CultureInfo PreferredLanguageInfo
        {
            get
            {
                return this.preferredLanguageInfo ?? CultureInfo.CurrentUICulture;
            }

            set
            {
                this.preferredLanguageInfo = value;
            }
        }

        /// <summary>
        ///     Gets the current game build.
        /// </summary>
        /// <returns>The current game build.</returns>
        public Build GetBuild()
        {
            var request = new BuildRequest();
            var response = this.Get<Build>(request);

            return response;
        }

        /// <summary>Gets the current build.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The current game build.</returns>
        public Task<Build> GetBuildAsync(CancellationToken? cancellationToken = null)
        {
            var request = new BuildRequest();
            Task<Build> response = this.GetAsync<Build>(request, cancellationToken);

            return response;
        }

        /// <summary>
        ///     Gets the collection of dyes in the game.
        /// </summary>
        /// <returns>The collection of dyes.</returns>
        public ColorCollection GetColors()
        {
            var request = new ColorsRequest { PreferredLanguageInfo = this.PreferredLanguageInfo };
            var response = this.Get<ColorsResult>(request);

            return response.Colors;
        }

        /// <summary>Gets the collection of dyes in the game.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of dyes.</returns>
        public Task<ColorCollection> GetColorsAsync(CancellationToken? cancellationToken = null)
        {
            var request = new ColorsRequest { PreferredLanguageInfo = this.PreferredLanguageInfo };
            var response = this.GetAsync<ColorsResult>(request, cancellationToken);

            return this.Select(response, result => result.Colors);
        }

        /// <summary>
        ///     Gets the collection of continents in the game.
        /// </summary>
        /// <returns>The collection of continents</returns>
        public ContinentCollection GetContinents()
        {
            var request = new ContinentsRequest();
            var response = this.Get<ContinentsResult>(request);

            return response.Continents;
        }

        /// <summary>Gets the collection of continents in the game.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of continents</returns>
        public Task<ContinentCollection> GetContinentsAsync(CancellationToken? cancellationToken = null)
        {
            var request = new ContinentsRequest();
            Task<ContinentsResult> response = this.GetAsync<ContinentsResult>(request, cancellationToken);

            return this.Select(response, result => result.Continents);
        }

        /// <summary>
        ///     Gets a collection of dynamic events and their details.
        /// </summary>
        /// <returns>A collection of dynamic events.</returns>
        public DynamicEventDetailsCollection GetDynamicEventDetails()
        {
            var request = new DynamicEventDetailsRequest { PreferredLanguageInfo = this.PreferredLanguageInfo };
            var response = this.Get<DynamicEventDetailsResult>(request);

            return response.EventDetails;
        }

        /// <summary>Gets a collection of dynamic events and their details.</summary>
        /// <param name="dynamicEventName">The dynamic event filter.</param>
        /// <returns>A collection of dynamic events.</returns>
        public DynamicEventDetailsCollection GetDynamicEventDetails(DynamicEventName dynamicEventName)
        {
            Preconditions.EnsureNotNull(paramName: "dynamicEventName", value: dynamicEventName);

            var request = new DynamicEventDetailsRequest { EventId = dynamicEventName.Id, PreferredLanguageInfo = this.PreferredLanguageInfo };
            var response = this.Get<DynamicEventDetailsResult>(request);

            return response.EventDetails;
        }

        /// <summary>Gets a collection of dynamic events and their details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <returns>A collection of dynamic events.</returns>
        public DynamicEventDetailsCollection GetDynamicEventDetails(Guid eventId)
        {
            var request = new DynamicEventDetailsRequest { EventId = eventId, PreferredLanguageInfo = this.PreferredLanguageInfo };
            var response = this.Get<DynamicEventDetailsResult>(request);

            return response.EventDetails;
        }

        /// <summary>Gets a collection of dynamic events and their details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events.</returns>
        public Task<DynamicEventDetailsCollection> GetDynamicEventDetailsAsync(CancellationToken? cancellationToken = null)
        {
            var request = new DynamicEventDetailsRequest { PreferredLanguageInfo = this.PreferredLanguageInfo };
            Task<DynamicEventDetailsResult> response = this.GetAsync<DynamicEventDetailsResult>(request, cancellationToken);

            return this.Select(response, result => result.EventDetails);
        }

        /// <summary>Gets a collection of dynamic events and their details.</summary>
        /// <param name="dynamicEventName">The dynamic event filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events.</returns>
        public Task<DynamicEventDetailsCollection> GetDynamicEventDetailsAsync(DynamicEventName dynamicEventName, CancellationToken? cancellationToken = null)
        {
            Preconditions.EnsureNotNull(paramName: "dynamicEventName", value: dynamicEventName);

            var request = new DynamicEventDetailsRequest { EventId = dynamicEventName.Id, PreferredLanguageInfo = this.PreferredLanguageInfo };
            Task<DynamicEventDetailsResult> response = this.GetAsync<DynamicEventDetailsResult>(request, cancellationToken);

            return this.Select(response, result => result.EventDetails);
        }

        /// <summary>Gets a collection of dynamic events and their details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events.</returns>
        public Task<DynamicEventDetailsCollection> GetDynamicEventDetailsAsync(Guid eventId, CancellationToken? cancellationToken = null)
        {
            var request = new DynamicEventDetailsRequest { EventId = eventId, PreferredLanguageInfo = this.PreferredLanguageInfo };
            Task<DynamicEventDetailsResult> response = this.GetAsync<DynamicEventDetailsResult>(request, cancellationToken);

            return this.Select(response, result => result.EventDetails);
        }

        /// <summary>
        ///     Gets the collection of dynamic events and their localized name.
        /// </summary>
        /// <returns>The collection of dynamic events and their localized name.</returns>
        public DynamicEventNameCollection GetDynamicEventNames()
        {
            var request = new DynamicEventNamesRequest { PreferredLanguageInfo = this.PreferredLanguageInfo };
            var response = this.Get<DynamicEventNameCollection>(request);

            return response;
        }

        /// <summary>Gets the collection of dynamic events and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of dynamic events and their localized name.</returns>
        public Task<DynamicEventNameCollection> GetDynamicEventNamesAsync(CancellationToken? cancellationToken = null)
        {
            var request = new DynamicEventNamesRequest { PreferredLanguageInfo = this.PreferredLanguageInfo };
            Task<DynamicEventNameCollection> response = this.GetAsync<DynamicEventNameCollection>(request, cancellationToken);

            return response;
        }

        /// <summary>
        /// Gets a collection of dynamic events and their status.
        /// </summary>
        /// <returns>A collection of dynamic events and their status.</returns>
        public DynamicEventCollection GetDynamicEvents()
        {
            var request = new DynamicEventRequest();
            var response = this.Get<DynamicEventsResult>(request);

            return response.Events;
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        public Task<DynamicEventCollection> GetDynamicEventsAsync(CancellationToken? cancellationToken = null)
        {
            var request = new DynamicEventRequest();
            var response = this.GetAsync<DynamicEventsResult>(request);

            return this.Select(response, result => result.Events);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        public DynamicEventCollection GetDynamicEventsById(Guid eventId)
        {
            var request = new DynamicEventRequest { EventId = eventId };

            var response = this.Get<DynamicEventsResult>(request);

            return response.Events;
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        public DynamicEventCollection GetDynamicEventsById(Guid eventId, int worldId)
        {
            var request = new DynamicEventRequest { EventId = eventId, WorldId = worldId };

            var response = this.Get<DynamicEventsResult>(request);

            return response.Events;
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldName">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        public DynamicEventCollection GetDynamicEventsById(Guid eventId, WorldName worldName)
        {
            Preconditions.EnsureNotNull(paramName: "worldName", value: worldName);

            var request = new DynamicEventRequest { EventId = eventId, WorldId = worldName.Id };

            var response = this.Get<DynamicEventsResult>(request);

            return response.Events;
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        public Task<DynamicEventCollection> GetDynamicEventsByIdAsync(Guid eventId, CancellationToken? cancellationToken = null)
        {
            var request = new DynamicEventRequest { EventId = eventId };

            var response = this.GetAsync<DynamicEventsResult>(request, cancellationToken);

            return this.Select(response, result => result.Events);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        public Task<DynamicEventCollection> GetDynamicEventsByIdAsync(Guid eventId, int worldId, CancellationToken? cancellationToken = null)
        {
            var request = new DynamicEventRequest { EventId = eventId, WorldId = worldId };

            var response = this.GetAsync<DynamicEventsResult>(request, cancellationToken);

            return this.Select(response, result => result.Events);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldName">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        public Task<DynamicEventCollection> GetDynamicEventsByIdAsync(Guid eventId, WorldName worldName, CancellationToken? cancellationToken = null)
        {
            Preconditions.EnsureNotNull(paramName: "worldName", value: worldName);

            var request = new DynamicEventRequest { EventId = eventId, WorldId = worldName.Id };

            var response = this.GetAsync<DynamicEventsResult>(request, cancellationToken);

            return this.Select(response, result => result.Events);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        public DynamicEventCollection GetDynamicEventsByMap(int mapId)
        {
            var request = new DynamicEventRequest { MapId = mapId };

            var response = this.Get<DynamicEventsResult>(request);

            return response.Events;
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        public DynamicEventCollection GetDynamicEventsByMap(int mapId, int worldId)
        {
            var request = new DynamicEventRequest { MapId = mapId, WorldId = worldId };

            var response = this.Get<DynamicEventsResult>(request);

            return response.Events;
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapName">The map filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        public DynamicEventCollection GetDynamicEventsByMap(MapName mapName)
        {
            Preconditions.EnsureNotNull(paramName: "mapName", value: mapName);

            var request = new DynamicEventRequest { MapId = mapName.Id, };

            var response = this.Get<DynamicEventsResult>(request);

            return response.Events;
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapName">The map filter.</param>
        /// <param name="worldName">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        public DynamicEventCollection GetDynamicEventsByMap(MapName mapName, WorldName worldName)
        {
            Preconditions.EnsureNotNull(paramName: "mapName", value: mapName);
            Preconditions.EnsureNotNull(paramName: "worldName", value: worldName);

            var request = new DynamicEventRequest { MapId = mapName.Id, WorldId = worldName.Id };

            var response = this.Get<DynamicEventsResult>(request);

            return response.Events;
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        public Task<DynamicEventCollection> GetDynamicEventsByMapAsync(int mapId, CancellationToken? cancellationToken = null)
        {
            var request = new DynamicEventRequest { MapId = mapId };

            var response = this.GetAsync<DynamicEventsResult>(request, cancellationToken);

            return this.Select(response, result => result.Events);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        public Task<DynamicEventCollection> GetDynamicEventsByMapAsync(int mapId, int worldId, CancellationToken? cancellationToken = null)
        {
            var request = new DynamicEventRequest { MapId = mapId, WorldId = worldId };

            var response = this.GetAsync<DynamicEventsResult>(request, cancellationToken);

            return this.Select(response, result => result.Events);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapName">The map filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        public Task<DynamicEventCollection> GetDynamicEventsByMapAsync(MapName mapName, CancellationToken? cancellationToken = null)
        {
            Preconditions.EnsureNotNull(paramName: "mapName", value: mapName);

            var request = new DynamicEventRequest { MapId = mapName.Id };

            var response = this.GetAsync<DynamicEventsResult>(request, cancellationToken);

            return this.Select(response, result => result.Events);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapName">The map filter.</param>
        /// <param name="worldName">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        public Task<DynamicEventCollection> GetDynamicEventsByMapAsync(MapName mapName, WorldName worldName, CancellationToken? cancellationToken = null)
        {
            Preconditions.EnsureNotNull(paramName: "mapName", value: mapName);
            Preconditions.EnsureNotNull(paramName: "worldName", value: worldName);

            var request = new DynamicEventRequest { MapId = mapName.Id, WorldId = worldName.Id };

            var response = this.GetAsync<DynamicEventsResult>(request, cancellationToken);

            return this.Select(response, result => result.Events);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        public DynamicEventCollection GetDynamicEventsByWorld(int worldId)
        {
            var request = new DynamicEventRequest { WorldId = worldId };

            var response = this.Get<DynamicEventsResult>(request);

            return response.Events;
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldName">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        public DynamicEventCollection GetDynamicEventsByWorld(WorldName worldName)
        {
            Preconditions.EnsureNotNull(paramName: "worldName", value: worldName);

            var request = new DynamicEventRequest { WorldId = worldName.Id };

            var response = this.Get<DynamicEventsResult>(request);

            return response.Events;
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        public Task<DynamicEventCollection> GetDynamicEventsByWorldAsync(int worldId, CancellationToken? cancellationToken = null)
        {
            var request = new DynamicEventRequest { WorldId = worldId };

            var response = this.GetAsync<DynamicEventsResult>(request, cancellationToken);

            return this.Select(response, result => result.Events);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldName">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        public Task<DynamicEventCollection> GetDynamicEventsByWorldAsync(WorldName worldName, CancellationToken? cancellationToken = null)
        {
            Preconditions.EnsureNotNull(paramName: "worldName", value: worldName);

            var request = new DynamicEventRequest { WorldId = worldName.Id };

            var response = this.GetAsync<DynamicEventsResult>(request, cancellationToken);

            return this.Select(response, result => result.Events);
        }

        /// <summary>
        ///     Gets a collection of commonly requested in-game assets.
        /// </summary>
        /// <returns>A collection of commonly requested in-game assets.</returns>
        public AssetCollection GetFiles()
        {
            var request = new FilesRequest();
            var response = this.Get<AssetCollection>(request);

            return response;
        }

        /// <summary>Gets a collection of commonly requested in-game assets.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of commonly requested in-game assets.</returns>
        public Task<AssetCollection> GetFilesAsync(CancellationToken? cancellationToken = null)
        {
            var request = new FilesRequest();
            Task<AssetCollection> response = this.GetAsync<AssetCollection>(request, cancellationToken);

            return response;
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildId">The guild's ID.</param>
        /// <returns>A guild and its details.</returns>
        public Guild GetGuildDetails(Guid guildId)
        {
            var request = new GuildDetailsRequest { GuildId = guildId };
            var response = this.Get<Guild>(request);

            return response;
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildName">The guild's name.</param>
        /// <returns>A guild and its details.</returns>
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
        public Task<Guild> GetGuildDetailsAsync(string guildName, CancellationToken? cancellationToken = null)
        {
            var request = new GuildDetailsRequest { GuildName = guildName };
            Task<Guild> response = this.GetAsync<Guild>(request, cancellationToken);

            return response;
        }

        /// <summary>Gets an item and its details.</summary>
        /// <param name="itemId">The item's ID.</param>
        /// <returns>An item and its details.</returns>
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
        public Task<Item> GetItemDetailsAsync(int itemId, CancellationToken? cancellationToken = null)
        {
            var request = new ItemDetailsRequest { ItemId = itemId, PreferredLanguageInfo = this.PreferredLanguageInfo };
            Task<Item> response = this.GetAsync<Item>(request, cancellationToken);

            return response;
        }

        /// <summary>
        ///     Gets the collection of discovered items.
        /// </summary>
        /// <returns>The collection of discovered items.</returns>
        public ItemCollection GetItems()
        {
            var request = new ItemsRequest();
            var response = this.Get<ItemsResult>(request);

            return response.Items;
        }

        /// <summary>Gets the collection of discovered items.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of discovered items.</returns>
        public Task<ItemCollection> GetItemsAsync(CancellationToken? cancellationToken = null)
        {
            var request = new ItemsRequest();
            Task<ItemsResult> response = this.GetAsync<ItemsResult>(request, cancellationToken);

            return this.Select(response, result => result.Items);
        }

        /// <summary>Gets a map floor and its details.</summary>
        /// <param name="continent">The continent.</param>
        /// <param name="floor">The map floor.</param>
        /// <returns>A map floor and its details.</returns>
        public Floor GetMapFloor(Continent continent, int floor)
        {
            Preconditions.EnsureNotNull(paramName: "continent", value: continent);

            var request = new MapFloorRequest { ContinentId = continent.ContinentId, Floor = floor, PreferredLanguageInfo = this.PreferredLanguageInfo };
            var response = this.Get<Floor>(request);

            return response;
        }

        /// <summary>Gets a map floor and its details.</summary>
        /// <param name="continentId">The continent.</param>
        /// <param name="floor">The map floor.</param>
        /// <returns>A map floor and its details.</returns>
        public Floor GetMapFloor(int continentId, int floor)
        {
            var request = new MapFloorRequest { ContinentId = continentId, Floor = floor, PreferredLanguageInfo = this.PreferredLanguageInfo };
            var response = this.Get<Floor>(request);

            return response;
        }

        /// <summary>Gets a map floor and its details.</summary>
        /// <param name="continent">The continent.</param>
        /// <param name="floor">The map floor.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A map floor and its details.</returns>
        public Task<Floor> GetMapFloorAsync(Continent continent, int floor, CancellationToken? cancellationToken = null)
        {
            Preconditions.EnsureNotNull(paramName: "continent", value: continent);

            var request = new MapFloorRequest { ContinentId = continent.ContinentId, Floor = floor, PreferredLanguageInfo = this.PreferredLanguageInfo };
            Task<Floor> response = this.GetAsync<Floor>(request, cancellationToken);

            return response;
        }

        /// <summary>Gets a map floor and its details.</summary>
        /// <param name="continentId">The continent.</param>
        /// <param name="floor">The map floor.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A map floor and its details.</returns>
        public Task<Floor> GetMapFloorAsync(int continentId, int floor, CancellationToken? cancellationToken = null)
        {
            var request = new MapFloorRequest { ContinentId = continentId, Floor = floor, PreferredLanguageInfo = this.PreferredLanguageInfo };
            Task<Floor> response = this.GetAsync<Floor>(request, cancellationToken);

            return response;
        }

        /// <summary>
        ///     Gets the collection of maps and their localized name.
        /// </summary>
        /// <returns>The collection of maps and their localized name.</returns>
        public MapNameCollection GetMapNames()
        {
            var request = new MapNamesRequest { PreferredLanguageInfo = this.PreferredLanguageInfo };
            var response = this.Get<MapNameCollection>(request);

            return response;
        }

        /// <summary>Gets the collection of maps and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of maps and their localized name.</returns>
        public Task<MapNameCollection> GetMapNamesAsync(CancellationToken? cancellationToken = null)
        {
            var request = new MapNamesRequest { PreferredLanguageInfo = this.PreferredLanguageInfo };
            Task<MapNameCollection> response = this.GetAsync<MapNameCollection>(request, cancellationToken);

            return response;
        }

        /// <summary>
        ///     Gets a collection of maps and their details.
        /// </summary>
        /// <returns>A collection of maps and their details.</returns>
        public MapCollection GetMaps()
        {
            var request = new MapDetailsRequest { PreferredLanguageInfo = this.PreferredLanguageInfo };
            var response = this.Get<MapsResult>(request);

            return response.Maps;
        }

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <param name="mapName">The map filter.</param>
        /// <returns>A collection of maps and their details.</returns>
        public MapCollection GetMaps(MapName mapName)
        {
            Preconditions.EnsureNotNull(paramName: "mapName", value: mapName);

            var request = new MapDetailsRequest { MapId = mapName.Id, PreferredLanguageInfo = this.PreferredLanguageInfo };
            var response = this.Get<MapsResult>(request);

            return response.Maps;
        }

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <returns>A collection of maps and their details.</returns>
        public MapCollection GetMaps(int mapId)
        {
            var request = new MapDetailsRequest { MapId = mapId, PreferredLanguageInfo = this.PreferredLanguageInfo };
            var response = this.Get<MapsResult>(request);

            return response.Maps;
        }

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their details.</returns>
        public Task<MapCollection> GetMapsAsync(CancellationToken? cancellationToken = null)
        {
            var request = new MapDetailsRequest { PreferredLanguageInfo = this.PreferredLanguageInfo };
            Task<MapsResult> response = this.GetAsync<MapsResult>(request, cancellationToken);

            return this.Select(response, result => result.Maps);
        }

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <param name="mapName">The map filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their details.</returns>
        public Task<MapCollection> GetMapsAsync(MapName mapName, CancellationToken? cancellationToken = null)
        {
            Preconditions.EnsureNotNull(paramName: "mapName", value: mapName);

            var request = new MapDetailsRequest { MapId = mapName.Id, PreferredLanguageInfo = this.PreferredLanguageInfo };
            Task<MapsResult> response = this.GetAsync<MapsResult>(request, cancellationToken);

            return this.Select(response, result => result.Maps);
        }

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their details.</returns>
        public Task<MapCollection> GetMapsAsync(int mapId, CancellationToken? cancellationToken = null)
        {
            var request = new MapDetailsRequest { MapId = mapId, PreferredLanguageInfo = this.PreferredLanguageInfo };
            Task<MapsResult> response = this.GetAsync<MapsResult>(request, cancellationToken);

            return this.Select(response, result => result.Maps);
        }

        /// <summary>Gets a World versus World match and its details.</summary>
        /// <param name="matchId">The match.</param>
        /// <returns>A World versus World match and its details.</returns>
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
        public Task<MatchDetails> GetMatchDetailsAsync(string matchId, CancellationToken? cancellationToken = null)
        {
            var request = new MatchDetailsRequest { MatchId = matchId };
            Task<MatchDetails> response = this.GetAsync<MatchDetails>(request, cancellationToken);

            return response;
        }

        /// <summary>
        ///     Gets the collection of currently running World versus World matches.
        /// </summary>
        /// <returns>The collection of currently running World versus World matches.</returns>
        public MatchCollection GetMatches()
        {
            var request = new MatchesRequest();
            var response = this.Get<MatchesResult>(request);

            return response.Matches;
        }

        /// <summary>Gets the collection of currently running World versus World matches.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of currently running World versus World matches.</returns>
        public Task<MatchCollection> GetMatchesAsync(CancellationToken? cancellationToken = null)
        {
            var request = new MatchesRequest();
            Task<MatchesResult> response = this.GetAsync<MatchesResult>(request, cancellationToken);

            return this.Select(response, result => result.Matches);
        }

        /// <summary>
        ///     Gets the collection of World versus World objectives and their localized name.
        /// </summary>
        /// <returns>The collection of World versus World objectives and their localized name.</returns>
        public ObjectiveNameCollection GetObjectiveNames()
        {
            var request = new ObjectiveNamesRequest { PreferredLanguageInfo = this.PreferredLanguageInfo };
            var response = this.Get<ObjectiveNameCollection>(request);

            return response;
        }

        /// <summary>Gets the collection of World versus World objectives and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of World versus World objectives and their localized name.</returns>
        public Task<ObjectiveNameCollection> GetObjectiveNamesAsync(CancellationToken? cancellationToken = null)
        {
            var request = new ObjectiveNamesRequest { PreferredLanguageInfo = this.PreferredLanguageInfo };
            Task<ObjectiveNameCollection> response = this.GetAsync<ObjectiveNameCollection>(request, cancellationToken);

            return response;
        }

        /// <summary>Gets a recipe and its details.</summary>
        /// <param name="recipe">The recipe.</param>
        /// <returns>A recipe and its details.</returns>
        public Recipe GetRecipeDetails(Recipe recipe)
        {
            Preconditions.EnsureNotNull(paramName: "recipe", value: recipe);

            var request = new RecipeDetailsRequest { RecipeId = recipe.RecipeId, PreferredLanguageInfo = this.PreferredLanguageInfo };
            var response = this.Get<Recipe>(request);

            return response;
        }

        /// <summary>Gets a recipe and its details.</summary>
        /// <param name="recipeId">The recipe.</param>
        /// <returns>A recipe and its details.</returns>
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
        public Task<Recipe> GetRecipeDetailsAsync(Recipe recipe, CancellationToken? cancellationToken = null)
        {
            Preconditions.EnsureNotNull(paramName: "recipe", value: recipe);

            var request = new RecipeDetailsRequest { RecipeId = recipe.RecipeId, PreferredLanguageInfo = this.PreferredLanguageInfo };
            Task<Recipe> response = this.GetAsync<Recipe>(request, cancellationToken);

            return response;
        }

        /// <summary>Gets a recipe and its details.</summary>
        /// <param name="recipeId">The recipe.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A recipe and its details.</returns>
        public Task<Recipe> GetRecipeDetailsAsync(int recipeId, CancellationToken? cancellationToken = null)
        {
            var request = new RecipeDetailsRequest { RecipeId = recipeId, PreferredLanguageInfo = this.PreferredLanguageInfo };
            Task<Recipe> response = this.GetAsync<Recipe>(request, cancellationToken);

            return response;
        }

        /// <summary>
        ///     Gets the collection of discovered recipes.
        /// </summary>
        /// <returns>The collection of discovered recipes.</returns>
        public RecipeCollection GetRecipes()
        {
            var request = new RecipesRequest();
            var response = this.Get<RecipesResult>(request);

            return response.Recipes;
        }

        /// <summary>Gets the collection of discovered recipes.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of discovered recipes.</returns>
        public Task<RecipeCollection> GetRecipesAsync(CancellationToken? cancellationToken = null)
        {
            var request = new RecipesRequest();
            Task<RecipesResult> response = this.GetAsync<RecipesResult>(request, cancellationToken);

            return this.Select(response, result => result.Recipes);
        }

        /// <summary>
        ///     Gets the collection of worlds and their localized name.
        /// </summary>
        /// <returns>The collection of worlds and their localized name.</returns>
        public WorldNameCollection GetWorldNames()
        {
            var request = new WorldNamesRequest { PreferredLanguageInfo = this.PreferredLanguageInfo };
            var response = this.Get<WorldNameCollection>(request);

            return response;
        }

        /// <summary>Gets the collection of worlds and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of worlds and their localized name.</returns>
        public Task<WorldNameCollection> GetWorldNamesAsync(CancellationToken? cancellationToken = null)
        {
            var request = new WorldNamesRequest { PreferredLanguageInfo = this.PreferredLanguageInfo };
            Task<WorldNameCollection> response = this.GetAsync<WorldNameCollection>(request, cancellationToken);

            return response;
        }

        /// <summary>Renders an image.</summary>
        /// <param name="file">The file.</param>
        /// <param name="imageFormat">The image Format.</param>
        /// <returns>The <see cref="Image"/>.</returns>
        public Image Render(IRenderable file, ImageFormat imageFormat)
        {
            Preconditions.EnsureNotNull(paramName: "file", value: file);
            Preconditions.EnsureNotNull(paramName: "imageFormat", value: imageFormat);

            var client = new ServiceClient(new Uri(Services.RenderServiceUrl));
            var request = new RenderFileRequest(file, imageFormat);
            var response = request.GetResponse(client).EnsureSuccessStatusCode();
            var rawBytes = ((RestResponse)response).RawBytes;

            return Image.FromStream(new MemoryStream(rawBytes));
        }

        /// <summary>Renders an image.</summary>
        /// <param name="file">The file.</param>
        /// <param name="imageFormat">The image format.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <see cref="Image"/>.</returns>
        public Task<Image> RenderAsync(IRenderable file, ImageFormat imageFormat, CancellationToken? cancellationToken = null)
        {
            Preconditions.EnsureNotNull(paramName: "file", value: file);
            Preconditions.EnsureNotNull(paramName: "imageFormat", value: imageFormat);

            CancellationToken token = cancellationToken.GetValueOrDefault(CancellationToken.None);
            var client = new ServiceClient(new Uri(Services.RenderServiceUrl));
            var request = new RenderFileRequest(file, imageFormat);
            return request.GetResponseAsync(client, token).ContinueWith(
                task =>
                {
                    var response = task.Result.EnsureSuccessStatusCode();
                    var rawBytes = ((RestResponse)response).RawBytes;

                    return Image.FromStream(new MemoryStream(rawBytes));
                },
                token,
                TaskContinuationOptions.OnlyOnRanToCompletion,
                TaskScheduler.Current);
        }

        /// <summary>Sends a request and gets the response content.</summary>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <param name="request">The request.</param>
        /// <returns>The response content.</returns>
        private TResult Get<TResult>(IServiceRequest request) where TResult : global::GW2DotNET.V1.Core.Common.JsonObject
        {
            IServiceResponse<TResult> response = request.GetResponse<TResult>(this.serviceClient);
            TResult content = response.EnsureSuccessStatusCode().Deserialize();

            return content;
        }

        /// <summary>Sends a request and gets the response content.</summary>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The response content.</returns>
        private Task<TResult> GetAsync<TResult>(IServiceRequest request, CancellationToken? cancellationToken = null)
            where TResult : global::GW2DotNET.V1.Core.Common.JsonObject
        {
            return this.GetAsync<TResult>(this.serviceClient, request, cancellationToken);
        }

        /// <summary>Sends a request and gets the response content.</summary>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <param name="client">The client.</param>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The response content.</returns>
        private Task<TResult> GetAsync<TResult>(IServiceClient client, IServiceRequest request, CancellationToken? cancellationToken = null)
            where TResult : global::GW2DotNET.V1.Core.Common.JsonObject
        {
            CancellationToken token = cancellationToken.GetValueOrDefault(CancellationToken.None);
            Task<IServiceResponse<TResult>> t1 = request.GetResponseAsync<TResult>(client, token);
            Task<TResult> t2 = t1.ContinueWith(
                task =>
                {
                    IServiceResponse<TResult> response = task.Result;
                    TResult content = response.EnsureSuccessStatusCode().Deserialize();

                    return content;
                },
                token,
                TaskContinuationOptions.OnlyOnRanToCompletion,
                TaskScheduler.Current);

            return t2;
        }

        /// <summary>Gets the service response and selects a result based on the specified selector.</summary>
        /// <typeparam name="TContent">The type of the response content.</typeparam>
        /// <typeparam name="TResult">The type of the selected item.</typeparam>
        /// <param name="result">The response content.</param>
        /// <param name="selector">The selector.</param>
        /// <returns>The selected result.</returns>
        private Task<TResult> Select<TContent, TResult>(Task<TContent> result, Func<TContent, TResult> selector)
            where TContent : global::GW2DotNET.V1.Core.Common.JsonObject
            where TResult : global::GW2DotNET.V1.Core.Common.JsonObject
        {
            return result.ContinueWith(task => selector(task.Result), TaskContinuationOptions.OnlyOnRanToCompletion);
        }
    }
}