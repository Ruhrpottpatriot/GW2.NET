// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceProvider.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Wraps a service manager that provides an implementation of the Guild Wars 2 service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Core;
    using GW2DotNET.V1.Core.Builds;
    using GW2DotNET.V1.Core.Colors;
    using GW2DotNET.V1.Core.Continents;
    using GW2DotNET.V1.Core.DynamicEvents;
    using GW2DotNET.V1.Core.DynamicEvents.Details;
    using GW2DotNET.V1.Core.DynamicEvents.Names;
    using GW2DotNET.V1.Core.Files;
    using GW2DotNET.V1.Core.Guilds.Details;
    using GW2DotNET.V1.Core.Items;
    using GW2DotNET.V1.Core.Items.Details;
    using GW2DotNET.V1.Core.Maps;
    using GW2DotNET.V1.Core.Maps.Floors;
    using GW2DotNET.V1.Core.Maps.Names;
    using GW2DotNET.V1.Core.Recipes;
    using GW2DotNET.V1.Core.Recipes.Details;
    using GW2DotNET.V1.Core.Worlds.Names;
    using GW2DotNET.V1.Core.WorldVersusWorld.Matches;
    using GW2DotNET.V1.Core.WorldVersusWorld.Matches.Details;
    using GW2DotNET.V1.Core.WorldVersusWorld.Objectives.Names;

    /// <summary>
    ///     Wraps a service manager that provides an implementation of the Guild Wars 2 service.
    /// </summary>
    public class ServiceProvider : IServiceManager
    {
        /// <summary>Infrastructure. Stores the service manager.</summary>
        private readonly IServiceManager serviceManager;

        /// <summary>Initializes a new instance of the <see cref="ServiceProvider"/> class.</summary>
        /// <param name="serviceManager">The service manager.</param>
        public ServiceProvider(IServiceManager serviceManager)
        {
            Preconditions.EnsureNotNull(paramName: "serviceManager", value: serviceManager);

            this.serviceManager = serviceManager;
        }

        /// <summary>
        /// Gets or sets the preferred language.
        /// </summary>
        public CultureInfo PreferredLanguageInfo
        {
            get
            {
                return this.serviceManager.PreferredLanguageInfo;
            }

            set
            {
                this.serviceManager.PreferredLanguageInfo = value;
            }
        }

        /// <summary>
        /// Gets the current game build.
        /// </summary>
        /// <returns>The current game build.</returns>
        public Build GetBuild()
        {
            return this.serviceManager.GetBuild();
        }

        /// <summary>Gets the current build.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The current game build.</returns>
        public Task<Build> GetBuildAsync(CancellationToken? cancellationToken = null)
        {
            return this.serviceManager.GetBuildAsync(cancellationToken);
        }

        /// <summary>
        /// Gets the collection of dyes in the game.
        /// </summary>
        /// <returns>The collection of dyes.</returns>
        public ColorCollection GetColors()
        {
            return this.serviceManager.GetColors();
        }

        /// <summary>Gets the collection of dyes in the game.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of dyes.</returns>
        public Task<ColorCollection> GetColorsAsync(CancellationToken? cancellationToken = null)
        {
            return this.serviceManager.GetColorsAsync(cancellationToken);
        }

        /// <summary>
        /// Gets the collection of continents in the game.
        /// </summary>
        /// <returns>The collection of continents</returns>
        public ContinentCollection GetContinents()
        {
            return this.serviceManager.GetContinents();
        }

        /// <summary>Gets the collection of continents in the game.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of continents</returns>
        public Task<ContinentCollection> GetContinentsAsync(CancellationToken? cancellationToken = null)
        {
            return this.serviceManager.GetContinentsAsync(cancellationToken);
        }

        /// <summary>
        /// Gets a collection of dynamic events and their details.
        /// </summary>
        /// <returns>A collection of dynamic events.</returns>
        public DynamicEventDetailsCollection GetDynamicEventDetails()
        {
            return this.serviceManager.GetDynamicEventDetails();
        }

        /// <summary>Gets a collection of dynamic events and their details.</summary>
        /// <param name="dynamicEventName">The dynamic event filter.</param>
        /// <returns>A collection of dynamic events.</returns>
        public DynamicEventDetailsCollection GetDynamicEventDetails(DynamicEventName dynamicEventName)
        {
            return this.serviceManager.GetDynamicEventDetails(dynamicEventName);
        }

        /// <summary>Gets a collection of dynamic events and their details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <returns>A collection of dynamic events.</returns>
        public DynamicEventDetailsCollection GetDynamicEventDetails(Guid eventId)
        {
            return this.serviceManager.GetDynamicEventDetails(eventId);
        }

        /// <summary>Gets a collection of dynamic events and their details.</summary>
        /// <param name="dynamicEventName">The dynamic event filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events.</returns>
        public Task<DynamicEventDetailsCollection> GetDynamicEventDetailsAsync(DynamicEventName dynamicEventName, CancellationToken? cancellationToken = null)
        {
            return this.serviceManager.GetDynamicEventDetailsAsync(dynamicEventName, cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events.</returns>
        public Task<DynamicEventDetailsCollection> GetDynamicEventDetailsAsync(Guid eventId, CancellationToken? cancellationToken = null)
        {
            return this.serviceManager.GetDynamicEventDetailsAsync(eventId, cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events.</returns>
        public Task<DynamicEventDetailsCollection> GetDynamicEventDetailsAsync(CancellationToken? cancellationToken = null)
        {
            return this.serviceManager.GetDynamicEventDetailsAsync(cancellationToken);
        }

        /// <summary>
        /// Gets the collection of dynamic events and their localized name.
        /// </summary>
        /// <returns>The collection of dynamic events and their localized name.</returns>
        public DynamicEventNameCollection GetDynamicEventNames()
        {
            return this.serviceManager.GetDynamicEventNames();
        }

        /// <summary>Gets the collection of dynamic events and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of dynamic events and their localized name.</returns>
        public Task<DynamicEventNameCollection> GetDynamicEventNamesAsync(CancellationToken? cancellationToken = null)
        {
            return this.serviceManager.GetDynamicEventNamesAsync(cancellationToken);
        }

        /// <summary>
        /// Gets a collection of dynamic events and their status.
        /// </summary>
        /// <returns>A collection of dynamic events and their status.</returns>
        public DynamicEventCollection GetDynamicEvents()
        {
            return this.serviceManager.GetDynamicEvents();
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        public Task<DynamicEventCollection> GetDynamicEventsAsync(CancellationToken? cancellationToken = null)
        {
            return this.serviceManager.GetDynamicEventsAsync(cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        public DynamicEventCollection GetDynamicEventsById(Guid eventId)
        {
            return this.serviceManager.GetDynamicEventsById(eventId);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        public DynamicEventCollection GetDynamicEventsById(Guid eventId, int worldId)
        {
            return this.serviceManager.GetDynamicEventsById(eventId, worldId);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldName">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        public DynamicEventCollection GetDynamicEventsById(Guid eventId, WorldName worldName)
        {
            return this.serviceManager.GetDynamicEventsById(eventId, worldName);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        public Task<DynamicEventCollection> GetDynamicEventsByIdAsync(Guid eventId, CancellationToken? cancellationToken = null)
        {
            return this.serviceManager.GetDynamicEventsByIdAsync(eventId, cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        public Task<DynamicEventCollection> GetDynamicEventsByIdAsync(Guid eventId, int worldId, CancellationToken? cancellationToken = null)
        {
            return this.serviceManager.GetDynamicEventsByIdAsync(eventId, worldId, cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldName">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        public Task<DynamicEventCollection> GetDynamicEventsByIdAsync(Guid eventId, WorldName worldName, CancellationToken? cancellationToken = null)
        {
            return this.serviceManager.GetDynamicEventsByIdAsync(eventId, worldName, cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        public DynamicEventCollection GetDynamicEventsByMap(int mapId)
        {
            return this.serviceManager.GetDynamicEventsByMap(mapId);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        public DynamicEventCollection GetDynamicEventsByMap(int mapId, int worldId)
        {
            return this.serviceManager.GetDynamicEventsByMap(mapId, worldId);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapName">The map filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        public DynamicEventCollection GetDynamicEventsByMap(MapName mapName)
        {
            return this.serviceManager.GetDynamicEventsByMap(mapName);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapName">The map filter.</param>
        /// <param name="worldName">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        public DynamicEventCollection GetDynamicEventsByMap(MapName mapName, WorldName worldName)
        {
            return this.serviceManager.GetDynamicEventsByMap(mapName, worldName);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        public Task<DynamicEventCollection> GetDynamicEventsByMapAsync(int mapId, CancellationToken? cancellationToken = null)
        {
            return this.serviceManager.GetDynamicEventsByMapAsync(mapId, cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        public Task<DynamicEventCollection> GetDynamicEventsByMapAsync(int mapId, int worldId, CancellationToken? cancellationToken = null)
        {
            return this.serviceManager.GetDynamicEventsByMapAsync(mapId, worldId, cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapName">The map filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        public Task<DynamicEventCollection> GetDynamicEventsByMapAsync(MapName mapName, CancellationToken? cancellationToken = null)
        {
            return this.serviceManager.GetDynamicEventsByMapAsync(mapName, cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapName">The map filter.</param>
        /// <param name="worldName">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        public Task<DynamicEventCollection> GetDynamicEventsByMapAsync(MapName mapName, WorldName worldName, CancellationToken? cancellationToken = null)
        {
            return this.serviceManager.GetDynamicEventsByMapAsync(mapName, worldName, cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldName">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        public DynamicEventCollection GetDynamicEventsByWorld(WorldName worldName)
        {
            return this.serviceManager.GetDynamicEventsByWorld(worldName);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        public DynamicEventCollection GetDynamicEventsByWorld(int worldId)
        {
            return this.serviceManager.GetDynamicEventsByWorld(worldId);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        public Task<DynamicEventCollection> GetDynamicEventsByWorldAsync(int worldId, CancellationToken? cancellationToken = null)
        {
            return this.serviceManager.GetDynamicEventsByWorldAsync(worldId, cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldName">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        public Task<DynamicEventCollection> GetDynamicEventsByWorldAsync(WorldName worldName, CancellationToken? cancellationToken = null)
        {
            return this.serviceManager.GetDynamicEventsByWorldAsync(worldName, cancellationToken);
        }

        /// <summary>
        /// Gets a collection of commonly requested in-game assets.
        /// </summary>
        /// <returns>A collection of commonly requested in-game assets.</returns>
        public AssetCollection GetFiles()
        {
            return this.serviceManager.GetFiles();
        }

        /// <summary>Gets a collection of commonly requested in-game assets.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of commonly requested in-game assets.</returns>
        public Task<AssetCollection> GetFilesAsync(CancellationToken? cancellationToken = null)
        {
            return this.serviceManager.GetFilesAsync(cancellationToken);
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildId">The guild's ID.</param>
        /// <returns>A guild and its details.</returns>
        public Guild GetGuildDetails(Guid guildId)
        {
            return this.serviceManager.GetGuildDetails(guildId);
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildName">The guild's name.</param>
        /// <returns>A guild and its details.</returns>
        public Guild GetGuildDetails(string guildName)
        {
            return this.serviceManager.GetGuildDetails(guildName);
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildId">The guild's ID.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A guild and its details.</returns>
        public Task<Guild> GetGuildDetailsAsync(Guid guildId, CancellationToken? cancellationToken = null)
        {
            return this.serviceManager.GetGuildDetailsAsync(guildId, cancellationToken);
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildName">The guild's name.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A guild and its details.</returns>
        public Task<Guild> GetGuildDetailsAsync(string guildName, CancellationToken? cancellationToken = null)
        {
            return this.serviceManager.GetGuildDetailsAsync(guildName, cancellationToken);
        }

        /// <summary>Gets an item and its details.</summary>
        /// <param name="itemId">The item's ID.</param>
        /// <returns>An item and its details.</returns>
        public Item GetItemDetails(int itemId)
        {
            return this.serviceManager.GetItemDetails(itemId);
        }

        /// <summary>Gets an item and its details.</summary>
        /// <param name="itemId">The item's ID.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>An item and its details.</returns>
        public Task<Item> GetItemDetailsAsync(int itemId, CancellationToken? cancellationToken = null)
        {
            return this.serviceManager.GetItemDetailsAsync(itemId, cancellationToken);
        }

        /// <summary>
        /// Gets the collection of discovered items.
        /// </summary>
        /// <returns>The collection of discovered items.</returns>
        public ItemCollection GetItems()
        {
            return this.serviceManager.GetItems();
        }

        /// <summary>Gets the collection of discovered items.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of discovered items.</returns>
        public Task<ItemCollection> GetItemsAsync(CancellationToken? cancellationToken = null)
        {
            return this.serviceManager.GetItemsAsync(cancellationToken);
        }

        /// <summary>Gets a map floor and its details.</summary>
        /// <param name="continent">The continent.</param>
        /// <param name="floor">The map floor.</param>
        /// <returns>A map floor and its details.</returns>
        public Floor GetMapFloor(Continent continent, int floor)
        {
            return this.serviceManager.GetMapFloor(continent, floor);
        }

        /// <summary>Gets a map floor and its details.</summary>
        /// <param name="continentId">The continent.</param>
        /// <param name="floor">The map floor.</param>
        /// <returns>A map floor and its details.</returns>
        public Floor GetMapFloor(int continentId, int floor)
        {
            return this.serviceManager.GetMapFloor(continentId, floor);
        }

        /// <summary>Gets a map floor and its details.</summary>
        /// <param name="continent">The continent.</param>
        /// <param name="floor">The map floor.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A map floor and its details.</returns>
        public Task<Floor> GetMapFloorAsync(Continent continent, int floor, CancellationToken? cancellationToken = null)
        {
            return this.serviceManager.GetMapFloorAsync(continent, floor, cancellationToken);
        }

        /// <summary>Gets a map floor and its details.</summary>
        /// <param name="continentId">The continent.</param>
        /// <param name="floor">The map floor.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A map floor and its details.</returns>
        public Task<Floor> GetMapFloorAsync(int continentId, int floor, CancellationToken? cancellationToken = null)
        {
            return this.serviceManager.GetMapFloorAsync(continentId, floor, cancellationToken);
        }

        /// <summary>
        /// Gets the collection of maps and their localized name.
        /// </summary>
        /// <returns>The collection of maps and their localized name.</returns>
        public MapNameCollection GetMapNames()
        {
            return this.serviceManager.GetMapNames();
        }

        /// <summary>Gets the collection of maps and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of maps and their localized name.</returns>
        public Task<MapNameCollection> GetMapNamesAsync(CancellationToken? cancellationToken = null)
        {
            return this.serviceManager.GetMapNamesAsync(cancellationToken);
        }

        /// <summary>
        /// Gets a collection of maps and their details.
        /// </summary>
        /// <returns>A collection of maps and their details.</returns>
        public MapCollection GetMaps()
        {
            return this.serviceManager.GetMaps();
        }

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <param name="mapName">The map filter.</param>
        /// <returns>A collection of maps and their details.</returns>
        public MapCollection GetMaps(MapName mapName)
        {
            return this.serviceManager.GetMaps(mapName);
        }

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <returns>A collection of maps and their details.</returns>
        public MapCollection GetMaps(int mapId)
        {
            return this.serviceManager.GetMaps(mapId);
        }

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <param name="mapName">The map filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their details.</returns>
        public Task<MapCollection> GetMapsAsync(MapName mapName, CancellationToken? cancellationToken = null)
        {
            return this.serviceManager.GetMapsAsync(mapName, cancellationToken);
        }

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their details.</returns>
        public Task<MapCollection> GetMapsAsync(int mapId, CancellationToken? cancellationToken = null)
        {
            return this.serviceManager.GetMapsAsync(mapId, cancellationToken);
        }

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their details.</returns>
        public Task<MapCollection> GetMapsAsync(CancellationToken? cancellationToken = null)
        {
            return this.serviceManager.GetMapsAsync(cancellationToken);
        }

        /// <summary>Gets a World versus World match and its details.</summary>
        /// <param name="matchId">The match.</param>
        /// <returns>A World versus World match and its details.</returns>
        public MatchDetails GetMatchDetails(string matchId)
        {
            return this.serviceManager.GetMatchDetails(matchId);
        }

        /// <summary>Gets a World versus World match and its details.</summary>
        /// <param name="matchId">The match.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A World versus World match and its details.</returns>
        public Task<MatchDetails> GetMatchDetailsAsync(string matchId, CancellationToken? cancellationToken = null)
        {
            return this.serviceManager.GetMatchDetailsAsync(matchId, cancellationToken);
        }

        /// <summary>
        /// Gets the collection of currently running World versus World matches.
        /// </summary>
        /// <returns>The collection of currently running World versus World matches.</returns>
        public MatchCollection GetMatches()
        {
            return this.serviceManager.GetMatches();
        }

        /// <summary>Gets the collection of currently running World versus World matches.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of currently running World versus World matches.</returns>
        public Task<MatchCollection> GetMatchesAsync(CancellationToken? cancellationToken = null)
        {
            return this.serviceManager.GetMatchesAsync(cancellationToken);
        }

        /// <summary>
        /// Gets the collection of World versus World objectives and their localized name.
        /// </summary>
        /// <returns>The collection of World versus World objectives and their localized name.</returns>
        public ObjectiveNameCollection GetObjectiveNames()
        {
            return this.serviceManager.GetObjectiveNames();
        }

        /// <summary>Gets the collection of World versus World objectives and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of World versus World objectives and their localized name.</returns>
        public Task<ObjectiveNameCollection> GetObjectiveNamesAsync(CancellationToken? cancellationToken = null)
        {
            return this.serviceManager.GetObjectiveNamesAsync(cancellationToken);
        }

        /// <summary>Gets a recipe and its details.</summary>
        /// <param name="recipe">The recipe.</param>
        /// <returns>A recipe and its details.</returns>
        public Recipe GetRecipeDetails(Recipe recipe)
        {
            return this.serviceManager.GetRecipeDetails(recipe);
        }

        /// <summary>Gets a recipe and its details.</summary>
        /// <param name="recipeId">The recipe.</param>
        /// <returns>A recipe and its details.</returns>
        public Recipe GetRecipeDetails(int recipeId)
        {
            return this.serviceManager.GetRecipeDetails(recipeId);
        }

        /// <summary>Gets a recipe and its details.</summary>
        /// <param name="recipe">The recipe.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A recipe and its details.</returns>
        public Task<Recipe> GetRecipeDetailsAsync(Recipe recipe, CancellationToken? cancellationToken = null)
        {
            return this.serviceManager.GetRecipeDetailsAsync(recipe, cancellationToken);
        }

        /// <summary>Gets a recipe and its details.</summary>
        /// <param name="recipeId">The recipe.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A recipe and its details.</returns>
        public Task<Recipe> GetRecipeDetailsAsync(int recipeId, CancellationToken? cancellationToken = null)
        {
            return this.serviceManager.GetRecipeDetailsAsync(recipeId, cancellationToken);
        }

        /// <summary>
        /// Gets the collection of discovered recipes.
        /// </summary>
        /// <returns>The collection of discovered recipes.</returns>
        public RecipeCollection GetRecipes()
        {
            return this.serviceManager.GetRecipes();
        }

        /// <summary>Gets the collection of discovered recipes.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of discovered recipes.</returns>
        public Task<RecipeCollection> GetRecipesAsync(CancellationToken? cancellationToken = null)
        {
            return this.serviceManager.GetRecipesAsync(cancellationToken);
        }

        /// <summary>
        /// Gets the collection of worlds and their localized name.
        /// </summary>
        /// <returns>The collection of worlds and their localized name.</returns>
        public WorldNameCollection GetWorldNames()
        {
            return this.serviceManager.GetWorldNames();
        }

        /// <summary>Gets the collection of worlds and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of worlds and their localized name.</returns>
        public Task<WorldNameCollection> GetWorldNamesAsync(CancellationToken? cancellationToken = null)
        {
            return this.serviceManager.GetWorldNamesAsync(cancellationToken);
        }

        /// <summary>Renders an image.</summary>
        /// <param name="file">The file.</param>
        /// <param name="imageFormat">The image Format.</param>
        /// <returns>The <see cref="Image"/>.</returns>
        public Image Render(IRenderable file, ImageFormat imageFormat)
        {
            return this.serviceManager.Render(file, imageFormat);
        }

        /// <summary>Renders an image.</summary>
        /// <param name="file">The file.</param>
        /// <param name="imageFormat">The image format.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <see cref="Image"/>.</returns>
        public Task<Image> RenderAsync(IRenderable file, ImageFormat imageFormat, CancellationToken? cancellationToken = null)
        {
            return this.serviceManager.RenderAsync(file, imageFormat, cancellationToken);
        }
    }
}