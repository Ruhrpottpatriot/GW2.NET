// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICachedServiceManager.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for service managers that are backed up by a cache.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.ServiceManagement
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.V1.Core.Builds;
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

    using ColorPalette = GW2DotNET.V1.Core.Colors.ColorPalette;

    /// <summary>Provides the interface for service managers that are backed up by a cache.</summary>
    internal interface ICachedServiceManager : IServiceManager
    {
        /// <summary>Gets the current game build.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>The current game build.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/build">wiki</a> for more information.</remarks>
        Build GetBuild(bool allowCache);

        /// <summary>Gets the current build.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The current game build.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/build">wiki</a> for more information.</remarks>
        Task<Build> GetBuildAsync(bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets the collection of colors in the game.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>The collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        IEnumerable<ColorPalette> GetColors(bool allowCache);

        /// <summary>Gets the collection of colors in the game.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        Task<IEnumerable<ColorPalette>> GetColorsAsync(bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets the collection of continents in the game.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>The collection of continents.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        IEnumerable<Continent> GetContinents(bool allowCache);

        /// <summary>Gets the collection of continents in the game.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of continents.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        Task<IEnumerable<Continent>> GetContinentsAsync(bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of dynamic events and their details.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        IEnumerable<DynamicEventDetails> GetDynamicEventDetails(bool allowCache);

        /// <summary>Gets a collection of dynamic events and their details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        IEnumerable<DynamicEventDetails> GetDynamicEventDetails(Guid eventId, bool allowCache);

        /// <summary>Gets a collection of dynamic events and their details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        Task<IEnumerable<DynamicEventDetails>> GetDynamicEventDetailsAsync(Guid eventId, bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of dynamic events and their details.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        Task<IEnumerable<DynamicEventDetails>> GetDynamicEventDetailsAsync(bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets the collection of dynamic events and their localized name.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>The collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        IEnumerable<DynamicEventName> GetDynamicEventNames(bool allowCache);

        /// <summary>Gets the collection of dynamic events and their localized name.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        Task<IEnumerable<DynamicEventName>> GetDynamicEventNamesAsync(bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        IEnumerable<DynamicEvent> GetDynamicEvents(bool allowCache);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        Task<IEnumerable<DynamicEvent>> GetDynamicEventsAsync(bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        IEnumerable<DynamicEvent> GetDynamicEventsById(Guid eventId, bool allowCache);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        IEnumerable<DynamicEvent> GetDynamicEventsById(Guid eventId, int worldId, bool allowCache);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        Task<IEnumerable<DynamicEvent>> GetDynamicEventsByIdAsync(Guid eventId, bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        Task<IEnumerable<DynamicEvent>> GetDynamicEventsByIdAsync(Guid eventId, int worldId, bool allowCache, CancellationToken? cancellationToken = null);

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
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        Task<IEnumerable<DynamicEvent>> GetDynamicEventsByMapAsync(int mapId, bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        Task<IEnumerable<DynamicEvent>> GetDynamicEventsByMapAsync(int mapId, int worldId, bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        IEnumerable<DynamicEvent> GetDynamicEventsByWorld(int worldId, bool allowCache);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        Task<IEnumerable<DynamicEvent>> GetDynamicEventsByWorldAsync(int worldId, bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of commonly requested in-game assets.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of commonly requested in-game assets.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/files">wiki</a> for more information.</remarks>
        IEnumerable<Asset> GetFiles(bool allowCache);

        /// <summary>Gets a collection of commonly requested in-game assets.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of commonly requested in-game assets.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/files">wiki</a> for more information.</remarks>
        Task<IEnumerable<Asset>> GetFilesAsync(bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildId">The guild's ID.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        Guild GetGuildDetails(Guid guildId, bool allowCache);

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildName">The guild's name.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        Guild GetGuildDetails(string guildName, bool allowCache);

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildId">The guild's ID.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        Task<Guild> GetGuildDetailsAsync(Guid guildId, bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildName">The guild's name.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        Task<Guild> GetGuildDetailsAsync(string guildName, bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets an image.</summary>
        /// <param name="file">The file.</param>
        /// <param name="imageFormat">The image Format.</param>
        /// <param name="allowCache">The allow Cache.</param>
        /// <returns>The <see cref="Image"/>.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:Render_service">wiki</a> for more information.</remarks>
        Image GetImage(IRenderable file, ImageFormat imageFormat, bool allowCache);

        /// <summary>Gets an image.</summary>
        /// <param name="file">The file.</param>
        /// <param name="imageFormat">The image format.</param>
        /// <param name="allowCache">The allow Cache.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <see cref="Image"/>.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:Render_service">wiki</a> for more information.</remarks>
        Task<Image> GetImageAsync(IRenderable file, ImageFormat imageFormat, bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets an item and its details.</summary>
        /// <param name="itemId">The item's ID.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>An item and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        Item GetItemDetails(int itemId, bool allowCache);

        /// <summary>Gets an item and its details.</summary>
        /// <param name="itemId">The item's ID.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>An item and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        Task<Item> GetItemDetailsAsync(int itemId, bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets the collection of discovered items.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>The collection of discovered items.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/items">wiki</a> for more information.</remarks>
        IEnumerable<int> GetItems(bool allowCache);

        /// <summary>Gets the collection of discovered items.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of discovered items.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/items">wiki</a> for more information.</remarks>
        Task<IEnumerable<int>> GetItemsAsync(bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets a map floor and its details.</summary>
        /// <param name="continentId">The continent.</param>
        /// <param name="floor">The map floor.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A map floor and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        Floor GetMapFloor(int continentId, int floor, bool allowCache);

        /// <summary>Gets a map floor and its details.</summary>
        /// <param name="continentId">The continent.</param>
        /// <param name="floor">The map floor.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A map floor and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        Task<Floor> GetMapFloorAsync(int continentId, int floor, bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets the collection of maps and their localized name.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>The collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        IEnumerable<MapName> GetMapNames(bool allowCache);

        /// <summary>Gets the collection of maps and their localized name.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        Task<IEnumerable<MapName>> GetMapNamesAsync(bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of maps and their details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        IEnumerable<Map> GetMaps(bool allowCache);

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of maps and their details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        IEnumerable<Map> GetMaps(int mapId, bool allowCache);

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        Task<IEnumerable<Map>> GetMapsAsync(int mapId, bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        Task<IEnumerable<Map>> GetMapsAsync(bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets a World versus World match and its details.</summary>
        /// <param name="matchId">The match.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A World versus World match and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/match_details">wiki</a> for more information.</remarks>
        MatchDetails GetMatchDetails(string matchId, bool allowCache);

        /// <summary>Gets a World versus World match and its details.</summary>
        /// <param name="matchId">The match.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A World versus World match and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/match_details">wiki</a> for more information.</remarks>
        Task<MatchDetails> GetMatchDetailsAsync(string matchId, bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets the collection of currently running World versus World matches.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>The collection of currently running World versus World matches.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/matches">wiki</a> for more information.</remarks>
        IEnumerable<Match> GetMatches(bool allowCache);

        /// <summary>Gets the collection of currently running World versus World matches.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of currently running World versus World matches.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/matches">wiki</a> for more information.</remarks>
        Task<IEnumerable<Match>> GetMatchesAsync(bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets the collection of World versus World objectives and their localized name.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>The collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        IEnumerable<ObjectiveName> GetObjectiveNames(bool allowCache);

        /// <summary>Gets the collection of World versus World objectives and their localized name.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        Task<IEnumerable<ObjectiveName>> GetObjectiveNamesAsync(bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets a recipe and its details.</summary>
        /// <param name="recipeId">The recipe.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A recipe and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        Recipe GetRecipeDetails(int recipeId, bool allowCache);

        /// <summary>Gets a recipe and its details.</summary>
        /// <param name="recipeId">The recipe.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A recipe and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        Task<Recipe> GetRecipeDetailsAsync(int recipeId, bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets the collection of discovered recipes.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>The collection of discovered recipes.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes">wiki</a> for more information.</remarks>
        IEnumerable<int> GetRecipes(bool allowCache);

        /// <summary>Gets the collection of discovered recipes.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of discovered recipes.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes">wiki</a> for more information.</remarks>
        Task<IEnumerable<int>> GetRecipesAsync(bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets the collection of worlds and their localized name.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>The collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        IEnumerable<WorldName> GetWorldNames(bool allowCache);

        /// <summary>Gets the collection of worlds and their localized name.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        Task<IEnumerable<WorldName>> GetWorldNamesAsync(bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Sets the current game build.</summary>
        /// <param name="build">The build.</param>
        void SetBuild(Build build);

        /// <summary>Sets the current game build.</summary>
        /// <param name="build">The build.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task SetBuildAsync(Build build, CancellationToken? cancellationToken = null);

        /// <summary>Sets the collection of colors in the game.</summary>
        /// <param name="colors">The colors.</param>
        void SetColors(IEnumerable<ColorPalette> colors);

        /// <summary>Sets the collection of colors in the game.</summary>
        /// <param name="colors">The colors.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task SetColorsAsync(IEnumerable<ColorPalette> colors, CancellationToken? cancellationToken = null);

        /// <summary>Sets the collection of continents in the game.</summary>
        /// <param name="continents">The collection of continents.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        void SetContinents(IEnumerable<Continent> continents);

        /// <summary>Sets the collection of continents in the game.</summary>
        /// <param name="continents">The collection of continents.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        /// <returns>The <see cref="Task"/>.</returns>
        Task SetContinentsAsync(IEnumerable<Continent> continents, CancellationToken? cancellationToken = null);

        /// <summary>Sets a collection of dynamic events and their details.</summary>
        /// <param name="dynamicEventDetails">A collection of dynamic events.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        void SetDynamicEventDetails(IEnumerable<DynamicEventDetails> dynamicEventDetails);

        /// <summary>Sets a collection of dynamic events and their details.</summary>
        /// <param name="dynamicEventDetails">A collection of dynamic events.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        /// <returns>The <see cref="Task"/>.</returns>
        Task SetDynamicEventDetailsAsync(IEnumerable<DynamicEventDetails> dynamicEventDetails, CancellationToken? cancellationToken = null);

        /// <summary>Sets the collection of dynamic events and their localized name.</summary>
        /// <param name="dynamicEventNames">The collection of dynamic events and their localized name.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        void SetDynamicEventNames(IEnumerable<DynamicEventName> dynamicEventNames);

        /// <summary>Sets the collection of dynamic events and their localized name.</summary>
        /// <param name="dynamicEventNames">The collection of dynamic events and their localized name.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        /// <returns>The <see cref="Task"/>.</returns>
        Task SetDynamicEventNamesAsync(IEnumerable<DynamicEventName> dynamicEventNames, CancellationToken? cancellationToken = null);

        /// <summary>Sets a collection of dynamic events and their status.</summary>
        /// <param name="dynamicEvents">A collection of dynamic events and their status.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        void SetDynamicEvents(IEnumerable<DynamicEvent> dynamicEvents);

        /// <summary>Sets a collection of dynamic events and their status.</summary>
        /// <param name="dynamicEvents">A collection of dynamic events and their status.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        /// <returns>The <see cref="Task"/>.</returns>
        Task SetDynamicEventsAsync(IEnumerable<DynamicEvent> dynamicEvents, CancellationToken? cancellationToken = null);

        /// <summary>Sets a collection of commonly requested in-game assets.</summary>
        /// <param name="assets">A collection of commonly requested in-game assets.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/files">wiki</a> for more information.</remarks>
        void SetFiles(IEnumerable<Asset> assets);

        /// <summary>Sets a collection of commonly requested in-game assets.</summary>
        /// <param name="assets">A collection of commonly requested in-game assets.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/files">wiki</a> for more information.</remarks>
        /// <returns>The <see cref="Task"/>.</returns>
        Task SetFilesAsync(IEnumerable<Asset> assets, CancellationToken? cancellationToken = null);

        /// <summary>Sets a guild and its details.</summary>
        /// <param name="guild">A guild and its details.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        void SetGuildDetails(Guild guild);

        /// <summary>Sets a guild and its details.</summary>
        /// <param name="guild">A guild and its details.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        /// <returns>The <see cref="Task"/>.</returns>
        Task SetGuildDetailsAsync(Guild guild, CancellationToken? cancellationToken = null);

        /// <summary>Sets an image.</summary>
        /// <param name="file">The file.</param>
        /// <param name="image">The image.</param>
        /// <returns>The <see cref="Image"/>.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:Render_service">wiki</a> for more information.</remarks>
        Image SetImage(IRenderable file, Image image);

        /// <summary>Sets an image.</summary>
        /// <param name="file">The file.</param>
        /// <param name="image">The image.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <see cref="Image"/>.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:Render_service">wiki</a> for more information.</remarks>
        Task<Image> SetImageAsync(IRenderable file, Image image, CancellationToken? cancellationToken = null);

        /// <summary>Sets an item and its details.</summary>
        /// <param name="item">An item and its details.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        void SetItemDetails(Item item);

        /// <summary>Sets an item and its details.</summary>
        /// <param name="item">An item and its details.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        /// <returns>The <see cref="Task"/>.</returns>
        Task SetItemDetailsAsync(Item item, CancellationToken? cancellationToken = null);

        /// <summary>Sets the collection of discovered items.</summary>
        /// <param name="items">The collection of discovered items.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/items">wiki</a> for more information.</remarks>
        void SetItems(IEnumerable<int> items);

        /// <summary>Sets the collection of discovered items.</summary>
        /// <param name="items">The collection of discovered items.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/items">wiki</a> for more information.</remarks>
        /// <returns>The <see cref="Task"/>.</returns>
        Task SetItemsAsync(IEnumerable<int> items, CancellationToken? cancellationToken = null);

        /// <summary>Sets a map floor and its details.</summary>
        /// <param name="floor">A map floor and its details.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        void SetMapFloor(Floor floor);

        /// <summary>Sets a map floor and its details.</summary>
        /// <param name="floor">A map floor and its details.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        /// <returns>The <see cref="Task"/>.</returns>
        Task SetMapFloorAsync(Floor floor, CancellationToken? cancellationToken = null);

        /// <summary>Sets the collection of maps and their localized name.</summary>
        /// <param name="mapNames">The collection of maps and their localized name.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        void SetMapNames(IEnumerable<MapName> mapNames);

        /// <summary>Sets the collection of maps and their localized name.</summary>
        /// <param name="mapNames">The collection of maps and their localized name.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        /// <returns>The <see cref="Task"/>.</returns>
        Task SetMapNamesAsync(IEnumerable<MapName> mapNames, CancellationToken? cancellationToken = null);

        /// <summary>Sets a collection of maps and their details.</summary>
        /// <param name="maps">A collection of maps and their details.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        void SetMaps(IEnumerable<Map> maps);

        /// <summary>Sets a collection of maps and their details.</summary>
        /// <param name="maps">A collection of maps and their details.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        /// <returns>The <see cref="Task"/>.</returns>
        Task SetMapsAsync(IEnumerable<Map> maps, CancellationToken? cancellationToken = null);

        /// <summary>Sets a World versus World match and its details.</summary>
        /// <param name="matchDetails">A World versus World match and its details</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/match_details">wiki</a> for more information.</remarks>
        void SetMatchDetails(MatchDetails matchDetails);

        /// <summary>Sets a World versus World match and its details.</summary>
        /// <param name="matchDetails">A World versus World match and its details</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/match_details">wiki</a> for more information.</remarks>
        /// <returns>The <see cref="Task"/>.</returns>
        Task SetMatchDetailsAsync(MatchDetails matchDetails, CancellationToken? cancellationToken = null);

        /// <summary>Sets the collection of currently running World versus World matches.</summary>
        /// <param name="matches">The collection of currently running World versus World matches..</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/matches">wiki</a> for more information.</remarks>
        void SetMatches(IEnumerable<Match> matches);

        /// <summary>Sets the collection of currently running World versus World matches.</summary>
        /// <param name="matches">The collection of currently running World versus World matches..</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/matches">wiki</a> for more information.</remarks>
        /// <returns>The <see cref="Task"/>.</returns>
        Task SetMatchesAsync(IEnumerable<Match> matches, CancellationToken? cancellationToken = null);

        /// <summary>Sets the collection of World versus World objectives and their localized name.</summary>
        /// <param name="objectiveNames">The collection of World versus World objectives and their localized name.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        void SetObjectiveNames(IEnumerable<ObjectiveName> objectiveNames);

        /// <summary>Sets the collection of World versus World objectives and their localized name.</summary>
        /// <param name="objectiveNames">The collection of World versus World objectives and their localized name.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        /// <returns>The <see cref="Task"/>.</returns>
        Task SetObjectiveNamesAsync(IEnumerable<ObjectiveName> objectiveNames, CancellationToken? cancellationToken = null);

        /// <summary>Sets a recipe and its details.</summary>
        /// <param name="recipe">The recipe.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        void SetRecipeDetails(Recipe recipe);

        /// <summary>Sets a recipe and its details.</summary>
        /// <param name="recipe">The recipe.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        /// <returns>The <see cref="Task"/>.</returns>
        Task SetRecipeDetailsAsync(Recipe recipe, CancellationToken? cancellationToken = null);

        /// <summary>Sets the collection of discovered recipes.</summary>
        /// <param name="recipes">The collection of discovered recipes.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes">wiki</a> for more information.</remarks>
        void SetRecipes(IEnumerable<int> recipes);

        /// <summary>Sets the collection of discovered recipes.</summary>
        /// <param name="recipes">The collection of discovered recipes.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes">wiki</a> for more information.</remarks>
        /// <returns>The <see cref="Task"/>.</returns>
        Task SetRecipesAsync(IEnumerable<int> recipes, CancellationToken? cancellationToken = null);

        /// <summary>Gets the collection of worlds and their localized name.</summary>
        /// <param name="worldNames">The collection of worlds and their localized name.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        void SetWorldNames(IEnumerable<WorldName> worldNames);

        /// <summary>Gets the collection of worlds and their localized name.</summary>
        /// <param name="worldNames">The collection of worlds and their localized name.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        /// <returns>The <see cref="Task"/>.</returns>
        Task SetWorldNamesAsync(IEnumerable<WorldName> worldNames, CancellationToken? cancellationToken = null);
    }
}