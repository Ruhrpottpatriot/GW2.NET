// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IServiceManager.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for service managers.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

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
    /// Provides the interface for service managers.
    /// </summary>
    public interface IServiceManager
    {
        /// <summary>
        /// Gets or sets the preferred language.
        /// </summary>
        CultureInfo PreferredLanguageInfo { get; set; }

        /// <summary>
        /// Gets the current game build.
        /// </summary>
        /// <returns>The current game build.</returns>
        Build GetBuild();

        /// <summary>Gets the current build.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The current game build.</returns>
        Task<Build> GetBuildAsync(CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets the collection of dyes in the game.
        /// </summary>
        /// <returns>The collection of dyes.</returns>
        ColorCollection GetColors();

        /// <summary>Gets the collection of dyes in the game.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of dyes.</returns>
        Task<ColorCollection> GetColorsAsync(CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets the collection of continents in the game.
        /// </summary>
        /// <returns>The collection of continents</returns>
        ContinentCollection GetContinents();

        /// <summary>Gets the collection of continents in the game.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of continents</returns>
        Task<ContinentCollection> GetContinentsAsync(CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets a collection of dynamic events and their details.
        /// </summary>
        /// <returns>A collection of dynamic events.</returns>
        DynamicEventDetailsCollection GetDynamicEventDetails();

        /// <summary>Gets a collection of dynamic events and their details.</summary>
        /// <param name="dynamicEventName">The dynamic event filter.</param>
        /// <returns>A collection of dynamic events.</returns>
        DynamicEventDetailsCollection GetDynamicEventDetails(DynamicEventName dynamicEventName);

        /// <summary>Gets a collection of dynamic events and their details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <returns>A collection of dynamic events.</returns>
        DynamicEventDetailsCollection GetDynamicEventDetails(Guid eventId);

        /// <summary>Gets a collection of dynamic events and their details.</summary>
        /// <param name="dynamicEventName">The dynamic event filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events.</returns>
        Task<DynamicEventDetailsCollection> GetDynamicEventDetailsAsync(DynamicEventName dynamicEventName, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of dynamic events and their details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events.</returns>
        Task<DynamicEventDetailsCollection> GetDynamicEventDetailsAsync(Guid eventId, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of dynamic events and their details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events.</returns>
        Task<DynamicEventDetailsCollection> GetDynamicEventDetailsAsync(CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets the collection of dynamic events and their localized name.
        /// </summary>
        /// <returns>The collection of dynamic events and their localized name.</returns>
        DynamicEventNameCollection GetDynamicEventNames();

        /// <summary>Gets the collection of dynamic events and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of dynamic events and their localized name.</returns>
        Task<DynamicEventNameCollection> GetDynamicEventNamesAsync(CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets a collection of dynamic events and their status.
        /// </summary>
        /// <returns>A collection of dynamic events and their status.</returns>
        DynamicEventCollection GetDynamicEvents();

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        Task<DynamicEventCollection> GetDynamicEventsAsync(CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        DynamicEventCollection GetDynamicEventsById(Guid eventId);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        DynamicEventCollection GetDynamicEventsById(Guid eventId, int worldId);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldName">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        DynamicEventCollection GetDynamicEventsById(Guid eventId, WorldName worldName);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        Task<DynamicEventCollection> GetDynamicEventsByIdAsync(Guid eventId, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        Task<DynamicEventCollection> GetDynamicEventsByIdAsync(Guid eventId, int worldId, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldName">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        Task<DynamicEventCollection> GetDynamicEventsByIdAsync(Guid eventId, WorldName worldName, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        DynamicEventCollection GetDynamicEventsByMap(int mapId);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        DynamicEventCollection GetDynamicEventsByMap(int mapId, int worldId);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapName">The map filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        DynamicEventCollection GetDynamicEventsByMap(MapName mapName);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapName">The map filter.</param>
        /// <param name="worldName">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        DynamicEventCollection GetDynamicEventsByMap(MapName mapName, WorldName worldName);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        Task<DynamicEventCollection> GetDynamicEventsByMapAsync(int mapId, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        Task<DynamicEventCollection> GetDynamicEventsByMapAsync(int mapId, int worldId, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapName">The map filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        Task<DynamicEventCollection> GetDynamicEventsByMapAsync(MapName mapName, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapName">The map filter.</param>
        /// <param name="worldName">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        Task<DynamicEventCollection> GetDynamicEventsByMapAsync(MapName mapName, WorldName worldName, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        DynamicEventCollection GetDynamicEventsByWorld(int worldId);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldName">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        DynamicEventCollection GetDynamicEventsByWorld(WorldName worldName);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        Task<DynamicEventCollection> GetDynamicEventsByWorldAsync(int worldId, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldName">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        Task<DynamicEventCollection> GetDynamicEventsByWorldAsync(WorldName worldName, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets a collection of commonly requested in-game assets.
        /// </summary>
        /// <returns>A collection of commonly requested in-game assets.</returns>
        AssetCollection GetFiles();

        /// <summary>Gets a collection of commonly requested in-game assets.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of commonly requested in-game assets.</returns>
        Task<AssetCollection> GetFilesAsync(CancellationToken? cancellationToken = null);

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildId">The guild's ID.</param>
        /// <returns>A guild and its details.</returns>
        Guild GetGuildDetails(Guid guildId);

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildName">The guild's name.</param>
        /// <returns>A guild and its details.</returns>
        Guild GetGuildDetails(string guildName);

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildId">The guild's ID.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A guild and its details.</returns>
        Task<Guild> GetGuildDetailsAsync(Guid guildId, CancellationToken? cancellationToken = null);

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildName">The guild's name.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A guild and its details.</returns>
        Task<Guild> GetGuildDetailsAsync(string guildName, CancellationToken? cancellationToken = null);

        /// <summary>Gets an item and its details.</summary>
        /// <param name="itemId">The item's ID.</param>
        /// <returns>An item and its details.</returns>
        Item GetItemDetails(int itemId);

        /// <summary>Gets an item and its details.</summary>
        /// <param name="itemId">The item's ID.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>An item and its details.</returns>
        Task<Item> GetItemDetailsAsync(int itemId, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets the collection of discovered items.
        /// </summary>
        /// <returns>The collection of discovered items.</returns>
        ItemCollection GetItems();

        /// <summary>Gets the collection of discovered items.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of discovered items.</returns>
        Task<ItemCollection> GetItemsAsync(CancellationToken? cancellationToken = null);

        /// <summary>Gets a map floor and its details.</summary>
        /// <param name="continent">The continent.</param>
        /// <param name="floor">The map floor.</param>
        /// <returns>A map floor and its details.</returns>
        Floor GetMapFloor(Continent continent, int floor);

        /// <summary>Gets a map floor and its details.</summary>
        /// <param name="continentId">The continent.</param>
        /// <param name="floor">The map floor.</param>
        /// <returns>A map floor and its details.</returns>
        Floor GetMapFloor(int continentId, int floor);

        /// <summary>Gets a map floor and its details.</summary>
        /// <param name="continent">The continent.</param>
        /// <param name="floor">The map floor.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A map floor and its details.</returns>
        Task<Floor> GetMapFloorAsync(Continent continent, int floor, CancellationToken? cancellationToken = null);

        /// <summary>Gets a map floor and its details.</summary>
        /// <param name="continentId">The continent.</param>
        /// <param name="floor">The map floor.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A map floor and its details.</returns>
        Task<Floor> GetMapFloorAsync(int continentId, int floor, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets the collection of maps and their localized name.
        /// </summary>
        /// <returns>The collection of maps and their localized name.</returns>
        MapNameCollection GetMapNames();

        /// <summary>Gets the collection of maps and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of maps and their localized name.</returns>
        Task<MapNameCollection> GetMapNamesAsync(CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets a collection of maps and their details.
        /// </summary>
        /// <returns>A collection of maps and their details.</returns>
        MapCollection GetMaps();

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <param name="mapName">The map filter.</param>
        /// <returns>A collection of maps and their details.</returns>
        MapCollection GetMaps(MapName mapName);

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <returns>A collection of maps and their details.</returns>
        MapCollection GetMaps(int mapId);

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <param name="mapName">The map filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their details.</returns>
        Task<MapCollection> GetMapsAsync(MapName mapName, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their details.</returns>
        Task<MapCollection> GetMapsAsync(int mapId, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their details.</returns>
        Task<MapCollection> GetMapsAsync(CancellationToken? cancellationToken = null);

        /// <summary>Gets a World versus World match and its details.</summary>
        /// <param name="matchId">The match.</param>
        /// <returns>A World versus World match and its details.</returns>
        MatchDetails GetMatchDetails(string matchId);

        /// <summary>Gets a World versus World match and its details.</summary>
        /// <param name="matchId">The match.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A World versus World match and its details.</returns>
        Task<MatchDetails> GetMatchDetailsAsync(string matchId, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets the collection of currently running World versus World matches.
        /// </summary>
        /// <returns>The collection of currently running World versus World matches.</returns>
        MatchCollection GetMatches();

        /// <summary>Gets the collection of currently running World versus World matches.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of currently running World versus World matches.</returns>
        Task<MatchCollection> GetMatchesAsync(CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets the collection of World versus World objectives and their localized name.
        /// </summary>
        /// <returns>The collection of World versus World objectives and their localized name.</returns>
        ObjectiveNameCollection GetObjectiveNames();

        /// <summary>Gets the collection of World versus World objectives and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of World versus World objectives and their localized name.</returns>
        Task<ObjectiveNameCollection> GetObjectiveNamesAsync(CancellationToken? cancellationToken = null);

        /// <summary>Gets a recipe and its details.</summary>
        /// <param name="recipe">The recipe.</param>
        /// <returns>A recipe and its details.</returns>
        Recipe GetRecipeDetails(Recipe recipe);

        /// <summary>Gets a recipe and its details.</summary>
        /// <param name="recipeId">The recipe.</param>
        /// <returns>A recipe and its details.</returns>
        Recipe GetRecipeDetails(int recipeId);

        /// <summary>Gets a recipe and its details.</summary>
        /// <param name="recipe">The recipe.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A recipe and its details.</returns>
        Task<Recipe> GetRecipeDetailsAsync(Recipe recipe, CancellationToken? cancellationToken = null);

        /// <summary>Gets a recipe and its details.</summary>
        /// <param name="recipeId">The recipe.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A recipe and its details.</returns>
        Task<Recipe> GetRecipeDetailsAsync(int recipeId, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets the collection of discovered recipes.
        /// </summary>
        /// <returns>The collection of discovered recipes.</returns>
        RecipeCollection GetRecipes();

        /// <summary>Gets the collection of discovered recipes.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of discovered recipes.</returns>
        Task<RecipeCollection> GetRecipesAsync(CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets the collection of worlds and their localized name.
        /// </summary>
        /// <returns>The collection of worlds and their localized name.</returns>
        WorldNameCollection GetWorldNames();

        /// <summary>Gets the collection of worlds and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of worlds and their localized name.</returns>
        Task<WorldNameCollection> GetWorldNamesAsync(CancellationToken? cancellationToken = null);

        /// <summary>Renders an image.</summary>
        /// <param name="file">The file.</param>
        /// <param name="imageFormat">The image Format.</param>
        /// <returns>The <see cref="Image"/>.</returns>
        Image Render(IRenderable file, ImageFormat imageFormat);

        /// <summary>Renders an image.</summary>
        /// <param name="file">The file.</param>
        /// <param name="imageFormat">The image format.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <see cref="Image"/>.</returns>
        Task<Image> RenderAsync(IRenderable file, ImageFormat imageFormat, CancellationToken? cancellationToken = null);
    }
}