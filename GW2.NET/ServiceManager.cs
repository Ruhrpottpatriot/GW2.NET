// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceManager.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the Guild Wars 2 service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Entities.Builds;
    using GW2DotNET.Entities.Colors;
    using GW2DotNET.Entities.DynamicEvents;
    using GW2DotNET.Entities.Files;
    using GW2DotNET.Entities.Guilds;
    using GW2DotNET.Entities.Items;
    using GW2DotNET.Entities.Maps;
    using GW2DotNET.Entities.Recipes;
    using GW2DotNET.Entities.Skins;
    using GW2DotNET.Entities.Worlds;
    using GW2DotNET.Entities.WorldVersusWorld;
    using GW2DotNET.V1.Builds;
    using GW2DotNET.V1.Colors;
    using GW2DotNET.V1.DynamicEvents;
    using GW2DotNET.V1.Files;
    using GW2DotNET.V1.Guilds;
    using GW2DotNET.V1.Items;
    using GW2DotNET.V1.Maps;
    using GW2DotNET.V1.Recipes;
    using GW2DotNET.V1.Skins;
    using GW2DotNET.V1.Worlds;
    using GW2DotNET.V1.WorldVersusWorld;

    /// <summary>Provides the default implementation of the Guild Wars 2 service.</summary>
    public class ServiceManager : IBuildService, 
                                  IColorService, 
                                  IContinentService, 
                                  IDynamicEventStateService, 
                                  IDynamicEventDetailsService, 
                                  IDynamicEventNameService, 
                                  IDynamicEventRotationService, 
                                  IFileService, 
                                  IGuildDetailsService, 
                                  IItemService, 
                                  IMapService, 
                                  IMapFloorService, 
                                  IMapNameService, 
                                  IRecipeService, 
                                  IWorldNameService, 
                                  IMatchService, 
                                  ISkinService
    {
        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IBuildService buildService;

        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IColorService colorService;

        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IContinentService continentService;

        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IDynamicEventService dynamicEventService;

        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IFileService fileService;

        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IGuildDetailsService guildDetailsService;

        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IItemService itemService;

        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IMapFloorService mapFloorService;

        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IMapNameService mapNameService;

        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IMapService mapService;

        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IMatchService matchService;

        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IRecipeService recipeService;

        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly ISkinService skinService;

        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IWorldNameService worldNameService;

        /// <summary>Initializes a new instance of the <see cref="ServiceManager"/> class.</summary>
        /// <param name="buildService">The build service.</param>
        /// <param name="colorService">The color service.</param>
        /// <param name="continentService">The continent service.</param>
        /// <param name="dynamicEventService">The dynamic event service.</param>
        /// <param name="fileService">The file service.</param>
        /// <param name="guildDetailsService">The guild details service.</param>
        /// <param name="itemService">The item service.</param>
        /// <param name="mapFloorService">The map floor service.</param>
        /// <param name="mapNameService">The map name service.</param>
        /// <param name="mapService">The map service.</param>
        /// <param name="matchService">The match service.</param>
        /// <param name="recipeService">The recipe service.</param>
        /// <param name="worldNameService">The world name service.</param>
        /// <param name="skinService">The skin service.</param>
        public ServiceManager(
            IBuildService buildService, 
            IColorService colorService, 
            IContinentService continentService, 
            IDynamicEventService dynamicEventService, 
            IFileService fileService, 
            IGuildDetailsService guildDetailsService, 
            IItemService itemService, 
            IMapFloorService mapFloorService, 
            IMapNameService mapNameService, 
            IMapService mapService, 
            IMatchService matchService, 
            IRecipeService recipeService, 
            IWorldNameService worldNameService, 
            ISkinService skinService)
        {
            Contract.Requires(buildService != null);
            Contract.Requires(colorService != null);
            Contract.Requires(continentService != null);
            Contract.Requires(dynamicEventService != null);
            Contract.Requires(fileService != null);
            Contract.Requires(guildDetailsService != null);
            Contract.Requires(itemService != null);
            Contract.Requires(mapFloorService != null);
            Contract.Requires(mapNameService != null);
            Contract.Requires(mapService != null);
            Contract.Requires(matchService != null);
            Contract.Requires(recipeService != null);
            Contract.Requires(worldNameService != null);
            Contract.Requires(skinService != null);
            this.buildService = buildService;
            this.colorService = colorService;
            this.continentService = continentService;
            this.dynamicEventService = dynamicEventService;
            this.fileService = fileService;
            this.guildDetailsService = guildDetailsService;
            this.itemService = itemService;
            this.mapFloorService = mapFloorService;
            this.mapNameService = mapNameService;
            this.mapService = mapService;
            this.matchService = matchService;
            this.recipeService = recipeService;
            this.worldNameService = worldNameService;
            this.skinService = skinService;
        }

        /// <summary>Initializes a new instance of the <see cref="ServiceManager" /> class.</summary>
        public ServiceManager()
            : this(new ServiceClient(GetBaseUri()))
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ServiceManager"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public ServiceManager(IServiceClient serviceClient)
        {
            Contract.Requires(serviceClient != null);
            this.buildService = new BuildService(serviceClient);
            this.colorService = new ColorService(serviceClient);
            this.continentService = new ContinentService(serviceClient);
            this.dynamicEventService = new DynamicEventService(serviceClient);
            this.fileService = new FileService(serviceClient);
            this.guildDetailsService = new GuildDetailsService(serviceClient);
            this.itemService = new ItemService(serviceClient);
            this.mapFloorService = new MapFloorService(serviceClient);
            this.mapNameService = new MapNameService(serviceClient);
            this.mapService = new MapService(serviceClient);
            this.matchService = new MatchService(serviceClient);
            this.recipeService = new RecipeService(serviceClient);
            this.worldNameService = new WorldService(serviceClient);
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

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public IDictionary<int, ColorPalette> GetColors()
        {
            return this.colorService.GetColors();
        }

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public IDictionary<int, ColorPalette> GetColors(CultureInfo language)
        {
            return this.colorService.GetColors(language);
        }

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, ColorPalette>> GetColorsAsync()
        {
            return this.colorService.GetColorsAsync();
        }

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, ColorPalette>> GetColorsAsync(CancellationToken cancellationToken)
        {
            return this.colorService.GetColorsAsync(cancellationToken);
        }

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, ColorPalette>> GetColorsAsync(CultureInfo language)
        {
            return this.colorService.GetColorsAsync(language);
        }

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, ColorPalette>> GetColorsAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            return this.colorService.GetColorsAsync(language, cancellationToken);
        }

        /// <summary>Gets a collection of continents and their details.</summary>
        /// <returns>A collection of continents.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        public IDictionary<int, Continent> GetContinents()
        {
            return this.continentService.GetContinents();
        }

        /// <summary>Gets a collection of continents and their details.</summary>
        /// <returns>A collection of continents.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, Continent>> GetContinentsAsync()
        {
            return this.continentService.GetContinentsAsync();
        }

        /// <summary>Gets a collection of continents and their details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of continents.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, Continent>> GetContinentsAsync(CancellationToken cancellationToken)
        {
            return this.continentService.GetContinentsAsync(cancellationToken);
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

        /// <summary>Gets a collection of dynamic events and their start times.</summary>
        /// <returns>A collection of dynamic events and their start times.</returns>
        public IDictionary<Guid, DynamicEventRotation> GetDynamicEventRotations()
        {
            return this.dynamicEventService.GetDynamicEventRotations();
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

        /// <summary>Gets a collection of commonly requested in-game assets.</summary>
        /// <returns>A collection of commonly requested in-game assets.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/files">wiki</a> for more information.</remarks>
        public IDictionary<string, Asset> GetFiles()
        {
            return this.fileService.GetFiles();
        }

        /// <summary>Gets a collection of commonly requested in-game assets.</summary>
        /// <returns>A collection of commonly requested in-game assets.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/files">wiki</a> for more information.</remarks>
        public Task<IDictionary<string, Asset>> GetFilesAsync()
        {
            return this.fileService.GetFilesAsync();
        }

        /// <summary>Gets a collection of commonly requested in-game assets.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of commonly requested in-game assets.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/files">wiki</a> for more information.</remarks>
        public Task<IDictionary<string, Asset>> GetFilesAsync(CancellationToken cancellationToken)
        {
            return this.fileService.GetFilesAsync(cancellationToken);
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildId">The guild identifier.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public Guild GetGuildDetailsById(Guid guildId)
        {
            return this.guildDetailsService.GetGuildDetailsById(guildId);
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildId">The guild identifier.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public Task<Guild> GetGuildDetailsByIdAsync(Guid guildId)
        {
            return this.guildDetailsService.GetGuildDetailsByIdAsync(guildId);
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildId">The guild identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public Task<Guild> GetGuildDetailsByIdAsync(Guid guildId, CancellationToken cancellationToken)
        {
            return this.guildDetailsService.GetGuildDetailsByIdAsync(guildId, cancellationToken);
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildName">The name of the guild.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public Guild GetGuildDetailsByName(string guildName)
        {
            return this.guildDetailsService.GetGuildDetailsByName(guildName);
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildName">The name of the guild.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public Task<Guild> GetGuildDetailsByNameAsync(string guildName)
        {
            return this.guildDetailsService.GetGuildDetailsByNameAsync(guildName);
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildName">The name of the guild.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public Task<Guild> GetGuildDetailsByNameAsync(string guildName, CancellationToken cancellationToken)
        {
            return this.guildDetailsService.GetGuildDetailsByNameAsync(guildName, cancellationToken);
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="item">The item identifier.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Item GetItemDetails(int item)
        {
            return this.itemService.GetItemDetails(item);
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="item">The item identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Item GetItemDetails(int item, CultureInfo language)
        {
            return this.itemService.GetItemDetails(item, language);
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="item">The item identifier.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Task<Item> GetItemDetailsAsync(int item)
        {
            return this.itemService.GetItemDetailsAsync(item);
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="item">The item identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Task<Item> GetItemDetailsAsync(int item, CultureInfo language)
        {
            return this.itemService.GetItemDetailsAsync(item, language);
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="item">The item identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Task<Item> GetItemDetailsAsync(int item, CancellationToken cancellationToken)
        {
            return this.itemService.GetItemDetailsAsync(item, cancellationToken);
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="item">The item identifier.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Task<Item> GetItemDetailsAsync(int item, CultureInfo language, CancellationToken cancellationToken)
        {
            return this.itemService.GetItemDetailsAsync(item, language, cancellationToken);
        }

        /// <summary>Gets a collection of item identifiers.</summary>
        /// <returns>A collection of item identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/items">wiki</a> for more information.</remarks>
        public ICollection<int> GetItems()
        {
            return this.itemService.GetItems();
        }

        /// <summary>Gets a collection of item identifiers.</summary>
        /// <returns>A collection of item identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/items">wiki</a> for more information.</remarks>
        public Task<ICollection<int>> GetItemsAsync()
        {
            return this.itemService.GetItemsAsync();
        }

        /// <summary>Gets a collection of item identifiers.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of item identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/items">wiki</a> for more information.</remarks>
        public Task<ICollection<int>> GetItemsAsync(CancellationToken cancellationToken)
        {
            return this.itemService.GetItemsAsync(cancellationToken);
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="map">The map identifier.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Map GetMap(int map)
        {
            return this.mapService.GetMap(map);
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="map">The map identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Map GetMap(int map, CultureInfo language)
        {
            return this.mapService.GetMap(map, language);
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="map">The map identifier.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<Map> GetMapAsync(int map)
        {
            return this.mapService.GetMapAsync(map);
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="map">The map identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<Map> GetMapAsync(int map, CancellationToken cancellationToken)
        {
            return this.mapService.GetMapAsync(map, cancellationToken);
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="map">The map identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<Map> GetMapAsync(int map, CultureInfo language)
        {
            return this.mapService.GetMapAsync(map, language);
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="map">The map identifier.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<Map> GetMapAsync(int map, CultureInfo language, CancellationToken cancellationToken)
        {
            return this.mapService.GetMapAsync(map, language, cancellationToken);
        }

        /// <summary>Gets a map floor and its localized details.</summary>
        /// <param name="continent">The continent identifier.</param>
        /// <param name="floor">The floor identifier.</param>
        /// <returns>A map floor and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public Floor GetMapFloor(int continent, int floor)
        {
            return this.mapFloorService.GetMapFloor(continent, floor);
        }

        /// <summary>Gets a map floor and its localized details.</summary>
        /// <param name="continent">The continent identifier.</param>
        /// <param name="floor">The floor identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>A map floor and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public Floor GetMapFloor(int continent, int floor, CultureInfo language)
        {
            return this.mapFloorService.GetMapFloor(continent, floor, language);
        }

        /// <summary>Gets a map floor and its localized details.</summary>
        /// <param name="continent">The continent identifier.</param>
        /// <param name="floor">The floor identifier.</param>
        /// <returns>A map floor and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public Task<Floor> GetMapFloorAsync(int continent, int floor)
        {
            return this.mapFloorService.GetMapFloorAsync(continent, floor);
        }

        /// <summary>Gets a map floor and its localized details.</summary>
        /// <param name="continent">The continent identifier.</param>
        /// <param name="floor">The floor identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A map floor and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public Task<Floor> GetMapFloorAsync(int continent, int floor, CancellationToken cancellationToken)
        {
            return this.mapFloorService.GetMapFloorAsync(continent, floor, cancellationToken);
        }

        /// <summary>Gets a map floor and its localized details.</summary>
        /// <param name="continent">The continent identifier.</param>
        /// <param name="floor">The floor identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>A map floor and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public Task<Floor> GetMapFloorAsync(int continent, int floor, CultureInfo language)
        {
            return this.mapFloorService.GetMapFloorAsync(continent, floor, language);
        }

        /// <summary>Gets a map floor and its localized details.</summary>
        /// <param name="continent">The continent identifier.</param>
        /// <param name="floor">The floor identifier.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A map floor and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public Task<Floor> GetMapFloorAsync(int continent, int floor, CultureInfo language, CancellationToken cancellationToken)
        {
            return this.mapFloorService.GetMapFloorAsync(continent, floor, language, cancellationToken);
        }

        /// <summary>Gets a collection of maps and their localized name.</summary>
        /// <returns>A collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public IDictionary<int, Map> GetMapNames()
        {
            return this.mapNameService.GetMapNames();
        }

        /// <summary>Gets a collection of maps and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public IDictionary<int, Map> GetMapNames(CultureInfo language)
        {
            return this.mapNameService.GetMapNames(language);
        }

        /// <summary>Gets a collection of maps and their localized name.</summary>
        /// <returns>A collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, Map>> GetMapNamesAsync()
        {
            return this.mapNameService.GetMapNamesAsync();
        }

        /// <summary>Gets a collection of maps and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, Map>> GetMapNamesAsync(CancellationToken cancellationToken)
        {
            return this.mapNameService.GetMapNamesAsync(cancellationToken);
        }

        /// <summary>Gets a collection of maps and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, Map>> GetMapNamesAsync(CultureInfo language)
        {
            return this.mapNameService.GetMapNamesAsync(language);
        }

        /// <summary>Gets a collection of maps and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, Map>> GetMapNamesAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            return this.mapNameService.GetMapNamesAsync(language, cancellationToken);
        }

        /// <summary>Gets a collection of maps and their localized details.</summary>
        /// <returns>A collection of maps and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public IDictionary<int, Map> GetMaps()
        {
            return this.mapService.GetMaps();
        }

        /// <summary>Gets a collection of maps and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of maps and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public IDictionary<int, Map> GetMaps(CultureInfo language)
        {
            return this.mapService.GetMaps(language);
        }

        /// <summary>Gets a collection of maps and their localized details.</summary>
        /// <returns>A collection of maps and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, Map>> GetMapsAsync()
        {
            return this.mapService.GetMapsAsync();
        }

        /// <summary>Gets a collection of maps and their localized details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, Map>> GetMapsAsync(CancellationToken cancellationToken)
        {
            return this.mapService.GetMapsAsync(cancellationToken);
        }

        /// <summary>Gets a collection of maps and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of maps and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, Map>> GetMapsAsync(CultureInfo language)
        {
            return this.mapService.GetMapsAsync(language);
        }

        /// <summary>Gets a collection of maps and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, Map>> GetMapsAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            return this.mapService.GetMapsAsync(language, cancellationToken);
        }

        /// <summary>Gets a World versus World match and its details.</summary>
        /// <param name="match">The match identifier.</param>
        /// <returns>A World versus World match and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/match_details">wiki</a> for more information.</remarks>
        public Match GetMatchDetails(string match)
        {
            return this.matchService.GetMatchDetails(match);
        }

        /// <summary>Gets a World versus World match and its details.</summary>
        /// <param name="match">The match identifier.</param>
        /// <returns>A World versus World match and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/match_details">wiki</a> for more information.</remarks>
        public Task<Match> GetMatchDetailsAsync(string match)
        {
            return this.matchService.GetMatchDetailsAsync(match);
        }

        /// <summary>Gets a World versus World match and its details.</summary>
        /// <param name="match">The match identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A World versus World match and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/match_details">wiki</a> for more information.</remarks>
        public Task<Match> GetMatchDetailsAsync(string match, CancellationToken cancellationToken)
        {
            return this.matchService.GetMatchDetailsAsync(match, cancellationToken);
        }

        /// <summary>Gets a collection of currently running World versus World matches.</summary>
        /// <returns>A collection of currently running World versus World matches.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/matches">wiki</a> for more information.</remarks>
        public IDictionary<string, Matchup> GetMatches()
        {
            return this.matchService.GetMatches();
        }

        /// <summary>Gets a collection of currently running World versus World matches.</summary>
        /// <returns>A collection of currently running World versus World matches.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/matches">wiki</a> for more information.</remarks>
        public Task<IDictionary<string, Matchup>> GetMatchesAsync()
        {
            return this.matchService.GetMatchesAsync();
        }

        /// <summary>Gets a collection of currently running World versus World matches.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of currently running World versus World matches.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/matches">wiki</a> for more information.</remarks>
        public Task<IDictionary<string, Matchup>> GetMatchesAsync(CancellationToken cancellationToken)
        {
            return this.matchService.GetMatchesAsync(cancellationToken);
        }

        /// <summary>Gets a collection of World versus World objectives and their localized name.</summary>
        /// <returns>A collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public IDictionary<int, ObjectiveName> GetObjectiveNames()
        {
            return this.matchService.GetObjectiveNames();
        }

        /// <summary>Gets a collection of World versus World objectives and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public IDictionary<int, ObjectiveName> GetObjectiveNames(CultureInfo language)
        {
            return this.matchService.GetObjectiveNames(language);
        }

        /// <summary>Gets a collection of World versus World objectives and their localized name.</summary>
        /// <returns>A collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, ObjectiveName>> GetObjectiveNamesAsync()
        {
            return this.matchService.GetObjectiveNamesAsync();
        }

        /// <summary>Gets a collection of World versus World objectives and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, ObjectiveName>> GetObjectiveNamesAsync(CancellationToken cancellationToken)
        {
            return this.matchService.GetObjectiveNamesAsync(cancellationToken);
        }

        /// <summary>Gets a collection of World versus World objectives and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, ObjectiveName>> GetObjectiveNamesAsync(CultureInfo language)
        {
            return this.matchService.GetObjectiveNamesAsync(language);
        }

        /// <summary>Gets a collection of World versus World objectives and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, ObjectiveName>> GetObjectiveNamesAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            return this.matchService.GetObjectiveNamesAsync(language, cancellationToken);
        }

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipe">The recipe identifier.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Recipe GetRecipeDetails(int recipe)
        {
            var culture = CultureInfo.GetCultureInfo("en");
            Contract.Assume(culture != null);
            return this.GetRecipeDetails(recipe, culture);
        }

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipe">The recipe identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Recipe GetRecipeDetails(int recipe, CultureInfo language)
        {
            return this.recipeService.GetRecipeDetails(recipe, language);
        }

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipe">The recipe identifier.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Task<Recipe> GetRecipeDetailsAsync(int recipe)
        {
            var culture = CultureInfo.GetCultureInfo("en");
            Contract.Assume(culture != null);
            return this.GetRecipeDetailsAsync(recipe, culture, CancellationToken.None);
        }

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipe">The recipe identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Task<Recipe> GetRecipeDetailsAsync(int recipe, CancellationToken cancellationToken)
        {
            var culture = CultureInfo.GetCultureInfo("en");
            Contract.Assume(culture != null);
            return this.GetRecipeDetailsAsync(recipe, culture, cancellationToken);
        }

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipe">The recipe identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Task<Recipe> GetRecipeDetailsAsync(int recipe, CultureInfo language)
        {
            return this.GetRecipeDetailsAsync(recipe, language, CancellationToken.None);
        }

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipe">The recipe identifier.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Task<Recipe> GetRecipeDetailsAsync(int recipe, CultureInfo language, CancellationToken cancellationToken)
        {
            return this.recipeService.GetRecipeDetailsAsync(recipe, language, cancellationToken);
        }

        /// <summary>Gets a collection of discovered recipes.</summary>
        /// <returns>A collection of discovered recipes.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes">wiki</a> for more information.</remarks>
        public ICollection<int> GetRecipes()
        {
            return this.recipeService.GetRecipes();
        }

        /// <summary>Gets a collection of discovered recipes.</summary>
        /// <returns>A collection of discovered recipes.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes">wiki</a> for more information.</remarks>
        public Task<ICollection<int>> GetRecipesAsync()
        {
            return this.recipeService.GetRecipesAsync();
        }

        /// <summary>Gets a collection of discovered recipes.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of discovered recipes.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes">wiki</a> for more information.</remarks>
        public Task<ICollection<int>> GetRecipesAsync(CancellationToken cancellationToken)
        {
            return this.recipeService.GetRecipesAsync(cancellationToken);
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
        public ICollection<World> GetWorldNames()
        {
            return this.worldNameService.GetWorldNames();
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public ICollection<World> GetWorldNames(CultureInfo language)
        {
            return this.worldNameService.GetWorldNames(language);
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<ICollection<World>> GetWorldNamesAsync()
        {
            return this.worldNameService.GetWorldNamesAsync();
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<ICollection<World>> GetWorldNamesAsync(CancellationToken cancellationToken)
        {
            return this.worldNameService.GetWorldNamesAsync(cancellationToken);
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<ICollection<World>> GetWorldNamesAsync(CultureInfo language)
        {
            return this.worldNameService.GetWorldNamesAsync(language);
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<ICollection<World>> GetWorldNamesAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            return this.worldNameService.GetWorldNamesAsync(language, cancellationToken);
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

        /// <summary>The invariant method for this class.</summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.buildService != null);
            Contract.Invariant(this.colorService != null);
            Contract.Invariant(this.continentService != null);
            Contract.Invariant(this.dynamicEventService != null);
            Contract.Invariant(this.fileService != null);
            Contract.Invariant(this.guildDetailsService != null);
            Contract.Invariant(this.itemService != null);
            Contract.Invariant(this.mapFloorService != null);
            Contract.Invariant(this.mapNameService != null);
            Contract.Invariant(this.mapService != null);
            Contract.Invariant(this.matchService != null);
            Contract.Invariant(this.recipeService != null);
            Contract.Invariant(this.worldNameService != null);
            Contract.Invariant(this.skinService != null);
        }
    }
}