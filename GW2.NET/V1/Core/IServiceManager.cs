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

    /// <summary>Provides the interface for service managers.</summary>
    public interface IServiceManager
    {
        /// <summary>Gets or sets the preferred language.</summary>
        CultureInfo PreferredLanguageInfo { get; set; }

        /// <summary>Gets the current game build.</summary>
        /// <returns>The current game build.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/build">wiki</a> for more information.</remarks>
        Build GetBuild();

        /// <summary>Gets the current build.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The current game build.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/build">wiki</a> for more information.</remarks>
        Task<Build> GetBuildAsync(CancellationToken? cancellationToken = null);

        /// <summary>Gets the collection of colors in the game.</summary>
        /// <returns>The collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        ColorCollection GetColors();

        /// <summary>Gets the collection of colors in the game.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        Task<ColorCollection> GetColorsAsync(CancellationToken? cancellationToken = null);

        /// <summary>Gets the collection of continents in the game.</summary>
        /// <returns>The collection of continents</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        ContinentCollection GetContinents();

        /// <summary>Gets the collection of continents in the game.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of continents</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        Task<ContinentCollection> GetContinentsAsync(CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of dynamic events and their details.</summary>
        /// <returns>A collection of dynamic events.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        DynamicEventDetailsCollection GetDynamicEventDetails();

        /// <summary>Gets a collection of dynamic events and their details.</summary>
        /// <param name="dynamicEventName">The dynamic event filter.</param>
        /// <returns>A collection of dynamic events.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        DynamicEventDetailsCollection GetDynamicEventDetails(DynamicEventName dynamicEventName);

        /// <summary>Gets a collection of dynamic events and their details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <returns>A collection of dynamic events.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        DynamicEventDetailsCollection GetDynamicEventDetails(Guid eventId);

        /// <summary>Gets a collection of dynamic events and their details.</summary>
        /// <param name="dynamicEventName">The dynamic event filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        Task<DynamicEventDetailsCollection> GetDynamicEventDetailsAsync(DynamicEventName dynamicEventName, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of dynamic events and their details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        Task<DynamicEventDetailsCollection> GetDynamicEventDetailsAsync(Guid eventId, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of dynamic events and their details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        Task<DynamicEventDetailsCollection> GetDynamicEventDetailsAsync(CancellationToken? cancellationToken = null);

        /// <summary>Gets the collection of dynamic events and their localized name.</summary>
        /// <returns>The collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        DynamicEventNameCollection GetDynamicEventNames();

        /// <summary>Gets the collection of dynamic events and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        Task<DynamicEventNameCollection> GetDynamicEventNamesAsync(CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        DynamicEventCollection GetDynamicEvents();

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        Task<DynamicEventCollection> GetDynamicEventsAsync(CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        DynamicEventCollection GetDynamicEventsById(Guid eventId);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        DynamicEventCollection GetDynamicEventsById(Guid eventId, int worldId);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldName">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        DynamicEventCollection GetDynamicEventsById(Guid eventId, WorldName worldName);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        Task<DynamicEventCollection> GetDynamicEventsByIdAsync(Guid eventId, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        Task<DynamicEventCollection> GetDynamicEventsByIdAsync(Guid eventId, int worldId, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldName">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        Task<DynamicEventCollection> GetDynamicEventsByIdAsync(Guid eventId, WorldName worldName, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        DynamicEventCollection GetDynamicEventsByMap(int mapId);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        DynamicEventCollection GetDynamicEventsByMap(int mapId, int worldId);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapName">The map filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        DynamicEventCollection GetDynamicEventsByMap(MapName mapName);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapName">The map filter.</param>
        /// <param name="worldName">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        DynamicEventCollection GetDynamicEventsByMap(MapName mapName, WorldName worldName);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        Task<DynamicEventCollection> GetDynamicEventsByMapAsync(int mapId, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        Task<DynamicEventCollection> GetDynamicEventsByMapAsync(int mapId, int worldId, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapName">The map filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        Task<DynamicEventCollection> GetDynamicEventsByMapAsync(MapName mapName, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapName">The map filter.</param>
        /// <param name="worldName">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        Task<DynamicEventCollection> GetDynamicEventsByMapAsync(MapName mapName, WorldName worldName, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        DynamicEventCollection GetDynamicEventsByWorld(int worldId);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldName">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        DynamicEventCollection GetDynamicEventsByWorld(WorldName worldName);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        Task<DynamicEventCollection> GetDynamicEventsByWorldAsync(int worldId, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldName">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        Task<DynamicEventCollection> GetDynamicEventsByWorldAsync(WorldName worldName, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of commonly requested in-game assets.</summary>
        /// <returns>A collection of commonly requested in-game assets.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/files">wiki</a> for more information.</remarks>
        AssetCollection GetFiles();

        /// <summary>Gets a collection of commonly requested in-game assets.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of commonly requested in-game assets.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/files">wiki</a> for more information.</remarks>
        Task<AssetCollection> GetFilesAsync(CancellationToken? cancellationToken = null);

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildId">The guild's ID.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        Guild GetGuildDetails(Guid guildId);

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildName">The guild's name.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        Guild GetGuildDetails(string guildName);

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildId">The guild's ID.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        Task<Guild> GetGuildDetailsAsync(Guid guildId, CancellationToken? cancellationToken = null);

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildName">The guild's name.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        Task<Guild> GetGuildDetailsAsync(string guildName, CancellationToken? cancellationToken = null);

        /// <summary>Gets an item and its details.</summary>
        /// <param name="itemId">The item's ID.</param>
        /// <returns>An item and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        Item GetItemDetails(int itemId);

        /// <summary>Gets an item and its details.</summary>
        /// <param name="itemId">The item's ID.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>An item and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        Task<Item> GetItemDetailsAsync(int itemId, CancellationToken? cancellationToken = null);

        /// <summary>Gets the collection of discovered items.</summary>
        /// <returns>The collection of discovered items.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/items">wiki</a> for more information.</remarks>
        ItemCollection GetItems();

        /// <summary>Gets the collection of discovered items.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of discovered items.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/items">wiki</a> for more information.</remarks>
        Task<ItemCollection> GetItemsAsync(CancellationToken? cancellationToken = null);

        /// <summary>Gets a map floor and its details.</summary>
        /// <param name="continent">The continent.</param>
        /// <param name="floor">The map floor.</param>
        /// <returns>A map floor and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        Floor GetMapFloor(Continent continent, int floor);

        /// <summary>Gets a map floor and its details.</summary>
        /// <param name="continentId">The continent.</param>
        /// <param name="floor">The map floor.</param>
        /// <returns>A map floor and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        Floor GetMapFloor(int continentId, int floor);

        /// <summary>Gets a map floor and its details.</summary>
        /// <param name="continent">The continent.</param>
        /// <param name="floor">The map floor.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A map floor and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        Task<Floor> GetMapFloorAsync(Continent continent, int floor, CancellationToken? cancellationToken = null);

        /// <summary>Gets a map floor and its details.</summary>
        /// <param name="continentId">The continent.</param>
        /// <param name="floor">The map floor.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A map floor and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        Task<Floor> GetMapFloorAsync(int continentId, int floor, CancellationToken? cancellationToken = null);

        /// <summary>Gets the collection of maps and their localized name.</summary>
        /// <returns>The collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        MapNameCollection GetMapNames();

        /// <summary>Gets the collection of maps and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        Task<MapNameCollection> GetMapNamesAsync(CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <returns>A collection of maps and their details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        MapCollection GetMaps();

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <param name="mapName">The map filter.</param>
        /// <returns>A collection of maps and their details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        MapCollection GetMaps(MapName mapName);

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <returns>A collection of maps and their details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        MapCollection GetMaps(int mapId);

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <param name="mapName">The map filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        Task<MapCollection> GetMapsAsync(MapName mapName, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        Task<MapCollection> GetMapsAsync(int mapId, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        Task<MapCollection> GetMapsAsync(CancellationToken? cancellationToken = null);

        /// <summary>Gets a World versus World match and its details.</summary>
        /// <param name="matchId">The match.</param>
        /// <returns>A World versus World match and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/match_details">wiki</a> for more information.</remarks>
        MatchDetails GetMatchDetails(string matchId);

        /// <summary>Gets a World versus World match and its details.</summary>
        /// <param name="matchId">The match.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A World versus World match and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/match_details">wiki</a> for more information.</remarks>
        Task<MatchDetails> GetMatchDetailsAsync(string matchId, CancellationToken? cancellationToken = null);

        /// <summary>Gets the collection of currently running World versus World matches.</summary>
        /// <returns>The collection of currently running World versus World matches.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/matches">wiki</a> for more information.</remarks>
        MatchCollection GetMatches();

        /// <summary>Gets the collection of currently running World versus World matches.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of currently running World versus World matches.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/matches">wiki</a> for more information.</remarks>
        Task<MatchCollection> GetMatchesAsync(CancellationToken? cancellationToken = null);

        /// <summary>Gets the collection of World versus World objectives and their localized name.</summary>
        /// <returns>The collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        ObjectiveNameCollection GetObjectiveNames();

        /// <summary>Gets the collection of World versus World objectives and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        Task<ObjectiveNameCollection> GetObjectiveNamesAsync(CancellationToken? cancellationToken = null);

        /// <summary>Gets a recipe and its details.</summary>
        /// <param name="recipe">The recipe.</param>
        /// <returns>A recipe and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        Recipe GetRecipeDetails(Recipe recipe);

        /// <summary>Gets a recipe and its details.</summary>
        /// <param name="recipeId">The recipe.</param>
        /// <returns>A recipe and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        Recipe GetRecipeDetails(int recipeId);

        /// <summary>Gets a recipe and its details.</summary>
        /// <param name="recipe">The recipe.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A recipe and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        Task<Recipe> GetRecipeDetailsAsync(Recipe recipe, CancellationToken? cancellationToken = null);

        /// <summary>Gets a recipe and its details.</summary>
        /// <param name="recipeId">The recipe.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A recipe and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        Task<Recipe> GetRecipeDetailsAsync(int recipeId, CancellationToken? cancellationToken = null);

        /// <summary>Gets the collection of discovered recipes.</summary>
        /// <returns>The collection of discovered recipes.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes">wiki</a> for more information.</remarks>
        RecipeCollection GetRecipes();

        /// <summary>Gets the collection of discovered recipes.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of discovered recipes.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes">wiki</a> for more information.</remarks>
        Task<RecipeCollection> GetRecipesAsync(CancellationToken? cancellationToken = null);

        /// <summary>Gets the collection of worlds and their localized name.</summary>
        /// <returns>The collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        WorldNameCollection GetWorldNames();

        /// <summary>Gets the collection of worlds and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        Task<WorldNameCollection> GetWorldNamesAsync(CancellationToken? cancellationToken = null);

        /// <summary>Renders an image.</summary>
        /// <param name="file">The file.</param>
        /// <param name="imageFormat">The image Format.</param>
        /// <returns>The <see cref="Image"/>.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:Render_service">wiki</a> for more information.</remarks>
        Image Render(IRenderable file, ImageFormat imageFormat);

        /// <summary>Renders an image.</summary>
        /// <param name="file">The file.</param>
        /// <param name="imageFormat">The image format.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <see cref="Image"/>.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:Render_service">wiki</a> for more information.</remarks>
        Task<Image> RenderAsync(IRenderable file, ImageFormat imageFormat, CancellationToken? cancellationToken = null);
    }
}