// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceManager.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the Guild Wars 2 service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.V1.Builds;
    using GW2DotNET.V1.Builds.Contracts;
    using GW2DotNET.V1.Colors;
    using GW2DotNET.V1.Colors.Contracts;
    using GW2DotNET.V1.Common;
    using GW2DotNET.V1.Continents;
    using GW2DotNET.V1.Continents.Contracts;
    using GW2DotNET.V1.DynamicEvents;
    using GW2DotNET.V1.DynamicEvents.Contracts;
    using GW2DotNET.V1.DynamicEvents.Details;
    using GW2DotNET.V1.DynamicEvents.Details.Contracts;
    using GW2DotNET.V1.DynamicEvents.Names;
    using GW2DotNET.V1.DynamicEvents.Names.Contracts;
    using GW2DotNET.V1.DynamicEvents.Rotations;
    using GW2DotNET.V1.DynamicEvents.Rotations.Contracts;
    using GW2DotNET.V1.Files;
    using GW2DotNET.V1.Files.Contracts;
    using GW2DotNET.V1.Guilds.Details;
    using GW2DotNET.V1.Guilds.Details.Contracts;
    using GW2DotNET.V1.Items;
    using GW2DotNET.V1.Items.Details;
    using GW2DotNET.V1.Items.Details.Contracts;
    using GW2DotNET.V1.Maps;
    using GW2DotNET.V1.Maps.Contracts;
    using GW2DotNET.V1.Maps.Floors;
    using GW2DotNET.V1.Maps.Floors.Contracts;
    using GW2DotNET.V1.Maps.Names;
    using GW2DotNET.V1.Maps.Names.Contracts;
    using GW2DotNET.V1.Recipes;
    using GW2DotNET.V1.Recipes.Details;
    using GW2DotNET.V1.Recipes.Details.Contracts;
    using GW2DotNET.V1.Rendering;
    using GW2DotNET.V1.Rendering.Contracts;
    using GW2DotNET.V1.Skins;
    using GW2DotNET.V1.Skins.Details;
    using GW2DotNET.V1.Skins.Details.Contracts;
    using GW2DotNET.V1.Worlds.Names;
    using GW2DotNET.V1.Worlds.Names.Contracts;
    using GW2DotNET.V1.WorldVersusWorld.Matches;
    using GW2DotNET.V1.WorldVersusWorld.Matches.Contracts;
    using GW2DotNET.V1.WorldVersusWorld.Matches.Details;
    using GW2DotNET.V1.WorldVersusWorld.Matches.Details.Contracts;
    using GW2DotNET.V1.WorldVersusWorld.Objectives.Names;
    using GW2DotNET.V1.WorldVersusWorld.Objectives.Names.Contracts;

    /// <summary>Provides the default implementation of the Guild Wars 2 service.</summary>
    public class ServiceManager : IBuildService, 
                                  IColorService, 
                                  IContinentService, 
                                  IDynamicEventService, 
                                  IDynamicEventDetailsService, 
                                  IDynamicEventNameService, 
                                  IDynamicEventRotationService, 
                                  IFileService, 
                                  IGuildDetailsService, 
                                  IItemService, 
                                  IItemDetailsService, 
                                  IMapService, 
                                  IMapFloorService, 
                                  IMapNameService, 
                                  IRecipeService, 
                                  IRecipeDetailsService, 
                                  IRenderService, 
                                  IWorldNameService, 
                                  IMatchService, 
                                  IMatchDetailsService, 
                                  IObjectiveNameService, 
                                  ISkinService, 
                                  ISkinDetailsService
    {
        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IBuildService buildService;

        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IColorService colorService;

        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IContinentService continentService;

        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IDynamicEventDetailsService dynamicEventDetailsService;

        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IDynamicEventNameService dynamicEventNameService;

        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IDynamicEventRotationService dynamicEventRotationService;

        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IDynamicEventService dynamicEventService;

        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IFileService fileService;

        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IGuildDetailsService guildDetailsService;

        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IItemDetailsService itemDetailsService;

        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IItemService itemService;

        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IMapFloorService mapFloorService;

        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IMapNameService mapNameService;

        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IMapService mapService;

        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IMatchDetailsService matchDetailsService;

        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IMatchService matchService;

        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IObjectiveNameService objectiveNameService;

        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IRecipeDetailsService recipeDetailsService;

        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IRecipeService recipeService;

        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IRenderService renderService;

        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly ISkinDetailsService skinDetailsService;

        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly ISkinService skinService;

        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IWorldNameService worldNameService;

        /// <summary>Initializes a new instance of the <see cref="ServiceManager"/> class.</summary>
        /// <param name="buildService">The build service.</param>
        /// <param name="colorService">The color service.</param>
        /// <param name="continentService">The continent service.</param>
        /// <param name="dynamicEventDetailsService">The dynamic event details service.</param>
        /// <param name="dynamicEventNameService">The dynamic event name service.</param>
        /// <param name="dynamicEventRotationService">The dynamic Event Rotation Service.</param>
        /// <param name="dynamicEventService">The dynamic event service.</param>
        /// <param name="fileService">The file service.</param>
        /// <param name="guildDetailsService">The guild details service.</param>
        /// <param name="itemDetailsService">The item details service.</param>
        /// <param name="itemService">The item service.</param>
        /// <param name="mapFloorService">The map floor service.</param>
        /// <param name="mapNameService">The map name service.</param>
        /// <param name="mapService">The map service.</param>
        /// <param name="matchDetailsService">The match details service.</param>
        /// <param name="matchService">The match service.</param>
        /// <param name="objectiveNameService">The objective name service.</param>
        /// <param name="recipeDetailsService">The recipe details service.</param>
        /// <param name="recipeService">The recipe service.</param>
        /// <param name="renderService">The render service.</param>
        /// <param name="worldNameService">The world name service.</param>
        /// <param name="skinService">The skin service.</param>
        /// <param name="skinDetailsService">The skin details Service.</param>
        public ServiceManager(
            IBuildService buildService, 
            IColorService colorService, 
            IContinentService continentService, 
            IDynamicEventDetailsService dynamicEventDetailsService, 
            IDynamicEventNameService dynamicEventNameService, 
            IDynamicEventRotationService dynamicEventRotationService, 
            IDynamicEventService dynamicEventService, 
            IFileService fileService, 
            IGuildDetailsService guildDetailsService, 
            IItemDetailsService itemDetailsService, 
            IItemService itemService, 
            IMapFloorService mapFloorService, 
            IMapNameService mapNameService, 
            IMapService mapService, 
            IMatchDetailsService matchDetailsService, 
            IMatchService matchService, 
            IObjectiveNameService objectiveNameService, 
            IRecipeDetailsService recipeDetailsService, 
            IRecipeService recipeService, 
            IRenderService renderService, 
            IWorldNameService worldNameService, 
            ISkinService skinService, 
            ISkinDetailsService skinDetailsService)
        {
            this.buildService = buildService;
            this.colorService = colorService;
            this.continentService = continentService;
            this.dynamicEventDetailsService = dynamicEventDetailsService;
            this.dynamicEventNameService = dynamicEventNameService;
            this.dynamicEventRotationService = dynamicEventRotationService;
            this.dynamicEventService = dynamicEventService;
            this.fileService = fileService;
            this.guildDetailsService = guildDetailsService;
            this.itemDetailsService = itemDetailsService;
            this.itemService = itemService;
            this.mapFloorService = mapFloorService;
            this.mapNameService = mapNameService;
            this.mapService = mapService;
            this.matchDetailsService = matchDetailsService;
            this.matchService = matchService;
            this.objectiveNameService = objectiveNameService;
            this.recipeDetailsService = recipeDetailsService;
            this.recipeService = recipeService;
            this.renderService = renderService;
            this.worldNameService = worldNameService;
            this.skinService = skinService;
            this.skinDetailsService = skinDetailsService;
        }

        /// <summary>Initializes a new instance of the <see cref="ServiceManager" /> class.</summary>
        public ServiceManager()
            : this(new ServiceClient(), new RenderServiceClient())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ServiceManager"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="renderServiceClient">The render service client.</param>
        public ServiceManager(IServiceClient serviceClient, IRenderServiceClient renderServiceClient)
        {
            this.buildService = new BuildService(serviceClient);
            this.colorService = new ColorService(serviceClient);
            this.continentService = new ContinentService(serviceClient);
            this.dynamicEventDetailsService = new DynamicEventDetailsService(serviceClient);
            this.dynamicEventNameService = new DynamicEventNameService(serviceClient);
            this.dynamicEventRotationService = new DynamicEventRotationService();
            this.dynamicEventService = new DynamicEventService(serviceClient);
            this.fileService = new FileService(serviceClient);
            this.guildDetailsService = new GuildDetailsService(serviceClient);
            this.itemDetailsService = new ItemDetailsService(serviceClient);
            this.itemService = new ItemService(serviceClient);
            this.mapFloorService = new MapFloorService(serviceClient);
            this.mapNameService = new MapNameService(serviceClient);
            this.mapService = new MapService(serviceClient);
            this.matchDetailsService = new MatchDetailsService(serviceClient);
            this.matchService = new MatchService(serviceClient);
            this.objectiveNameService = new ObjectiveNameService(serviceClient);
            this.recipeDetailsService = new RecipeDetailsService(serviceClient);
            this.recipeService = new RecipeService(serviceClient);
            this.renderService = new RenderService();
            this.worldNameService = new WorldNameService(serviceClient);
            this.skinService = new SkinService(serviceClient);
            this.skinDetailsService = new SkinDetailsService(serviceClient);
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
        public IEnumerable<ColorPalette> GetColors()
        {
            return this.colorService.GetColors();
        }

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public IEnumerable<ColorPalette> GetColors(CultureInfo language)
        {
            return this.colorService.GetColors(language);
        }

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public Task<IEnumerable<ColorPalette>> GetColorsAsync()
        {
            return this.colorService.GetColorsAsync();
        }

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public Task<IEnumerable<ColorPalette>> GetColorsAsync(CancellationToken cancellationToken)
        {
            return this.colorService.GetColorsAsync(cancellationToken);
        }

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public Task<IEnumerable<ColorPalette>> GetColorsAsync(CultureInfo language)
        {
            return this.colorService.GetColorsAsync(language);
        }

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public Task<IEnumerable<ColorPalette>> GetColorsAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            return this.colorService.GetColorsAsync(language, cancellationToken);
        }

        /// <summary>Gets a collection of continents and their details.</summary>
        /// <returns>A collection of continents.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        public IEnumerable<Continent> GetContinents()
        {
            return this.continentService.GetContinents();
        }

        /// <summary>Gets a collection of continents and their details.</summary>
        /// <returns>A collection of continents.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Continent>> GetContinentsAsync()
        {
            return this.continentService.GetContinentsAsync();
        }

        /// <summary>Gets a collection of continents and their details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of continents.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Continent>> GetContinentsAsync(CancellationToken cancellationToken)
        {
            return this.continentService.GetContinentsAsync(cancellationToken);
        }

        /// <summary>Gets a dynamic event and its status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A dynamic event and its status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public DynamicEvent GetDynamicEvent(Guid eventId, int worldId)
        {
            return this.dynamicEventService.GetDynamicEvent(eventId, worldId);
        }

        /// <summary>Gets a dynamic event and its status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A dynamic event and its status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<DynamicEvent> GetDynamicEventAsync(Guid eventId, int worldId)
        {
            return this.dynamicEventService.GetDynamicEventAsync(eventId, worldId);
        }

        /// <summary>Gets a dynamic event and its status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A dynamic event and its status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<DynamicEvent> GetDynamicEventAsync(Guid eventId, int worldId, CancellationToken cancellationToken)
        {
            return this.dynamicEventService.GetDynamicEventAsync(eventId, worldId, cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEventDetails> GetDynamicEventDetails()
        {
            return this.dynamicEventDetailsService.GetDynamicEventDetails();
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEventDetails> GetDynamicEventDetails(CultureInfo language)
        {
            return this.dynamicEventDetailsService.GetDynamicEventDetails(language);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public DynamicEventDetails GetDynamicEventDetails(Guid eventId)
        {
            return this.dynamicEventDetailsService.GetDynamicEventDetails(eventId);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="language">The language.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public DynamicEventDetails GetDynamicEventDetails(Guid eventId, CultureInfo language)
        {
            return this.dynamicEventDetailsService.GetDynamicEventDetails(eventId, language);
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventDetails>> GetDynamicEventDetailsAsync()
        {
            return this.dynamicEventDetailsService.GetDynamicEventDetailsAsync();
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventDetails>> GetDynamicEventDetailsAsync(CancellationToken cancellationToken)
        {
            return this.dynamicEventDetailsService.GetDynamicEventDetailsAsync(cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventDetails>> GetDynamicEventDetailsAsync(CultureInfo language)
        {
            return this.dynamicEventDetailsService.GetDynamicEventDetailsAsync(language);
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventDetails>> GetDynamicEventDetailsAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            return this.dynamicEventDetailsService.GetDynamicEventDetailsAsync(language, cancellationToken);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<DynamicEventDetails> GetDynamicEventDetailsAsync(Guid eventId)
        {
            return this.dynamicEventDetailsService.GetDynamicEventDetailsAsync(eventId);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<DynamicEventDetails> GetDynamicEventDetailsAsync(Guid eventId, CancellationToken cancellationToken)
        {
            return this.dynamicEventDetailsService.GetDynamicEventDetailsAsync(eventId, cancellationToken);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="language">The language.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<DynamicEventDetails> GetDynamicEventDetailsAsync(Guid eventId, CultureInfo language)
        {
            return this.dynamicEventDetailsService.GetDynamicEventDetailsAsync(eventId, language);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<DynamicEventDetails> GetDynamicEventDetailsAsync(Guid eventId, CultureInfo language, CancellationToken cancellationToken)
        {
            return this.dynamicEventDetailsService.GetDynamicEventDetailsAsync(eventId, language, cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEventName> GetDynamicEventNames()
        {
            return this.dynamicEventNameService.GetDynamicEventNames();
        }

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEventName> GetDynamicEventNames(CultureInfo language)
        {
            return this.dynamicEventNameService.GetDynamicEventNames(language);
        }

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventName>> GetDynamicEventNamesAsync()
        {
            return this.dynamicEventNameService.GetDynamicEventNamesAsync();
        }

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventName>> GetDynamicEventNamesAsync(CancellationToken cancellationToken)
        {
            return this.dynamicEventNameService.GetDynamicEventNamesAsync(cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventName>> GetDynamicEventNamesAsync(CultureInfo language)
        {
            return this.dynamicEventNameService.GetDynamicEventNamesAsync(language);
        }

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventName>> GetDynamicEventNamesAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            return this.dynamicEventNameService.GetDynamicEventNamesAsync(language, cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their start times.</summary>
        /// <returns>A collection of dynamic events and their start times.</returns>
        public IEnumerable<DynamicEventRotation> GetDynamicEventRotations()
        {
            return this.dynamicEventRotationService.GetDynamicEventRotations();
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEvent> GetDynamicEvents()
        {
            return this.dynamicEventService.GetDynamicEvents();
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsAsync()
        {
            return this.dynamicEventService.GetDynamicEventsAsync();
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsAsync(CancellationToken cancellationToken)
        {
            return this.dynamicEventService.GetDynamicEventsAsync(cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEvent> GetDynamicEventsById(Guid eventId)
        {
            return this.dynamicEventService.GetDynamicEventsById(eventId);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsByIdAsync(Guid eventId)
        {
            return this.dynamicEventService.GetDynamicEventsByIdAsync(eventId);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsByIdAsync(Guid eventId, CancellationToken cancellationToken)
        {
            return this.dynamicEventService.GetDynamicEventsByIdAsync(eventId, cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEvent> GetDynamicEventsByMap(int mapId)
        {
            return this.dynamicEventService.GetDynamicEventsByMap(mapId);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEvent> GetDynamicEventsByMap(int mapId, int worldId)
        {
            return this.dynamicEventService.GetDynamicEventsByMap(mapId, worldId);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsByMapAsync(int mapId)
        {
            return this.dynamicEventService.GetDynamicEventsByMapAsync(mapId);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsByMapAsync(int mapId, CancellationToken cancellationToken)
        {
            return this.dynamicEventService.GetDynamicEventsByMapAsync(mapId, cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsByMapAsync(int mapId, int worldId)
        {
            return this.dynamicEventService.GetDynamicEventsByMapAsync(mapId, worldId);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsByMapAsync(int mapId, int worldId, CancellationToken cancellationToken)
        {
            return this.dynamicEventService.GetDynamicEventsByMapAsync(mapId, worldId, cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEvent> GetDynamicEventsByWorld(int worldId)
        {
            return this.dynamicEventService.GetDynamicEventsByWorld(worldId);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsByWorldAsync(int worldId)
        {
            return this.dynamicEventService.GetDynamicEventsByWorldAsync(worldId);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsByWorldAsync(int worldId, CancellationToken cancellationToken)
        {
            return this.dynamicEventService.GetDynamicEventsByWorldAsync(worldId, cancellationToken);
        }

        /// <summary>Gets a collection of commonly requested in-game assets.</summary>
        /// <returns>A collection of commonly requested in-game assets.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/files">wiki</a> for more information.</remarks>
        public IEnumerable<Asset> GetFiles()
        {
            return this.fileService.GetFiles();
        }

        /// <summary>Gets a collection of commonly requested in-game assets.</summary>
        /// <returns>A collection of commonly requested in-game assets.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/files">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Asset>> GetFilesAsync()
        {
            return this.fileService.GetFilesAsync();
        }

        /// <summary>Gets a collection of commonly requested in-game assets.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of commonly requested in-game assets.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/files">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Asset>> GetFilesAsync(CancellationToken cancellationToken)
        {
            return this.fileService.GetFilesAsync(cancellationToken);
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildId">The guild's ID.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public Guild GetGuildDetailsById(Guid guildId)
        {
            return this.guildDetailsService.GetGuildDetailsById(guildId);
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildId">The guild's ID.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public Task<Guild> GetGuildDetailsByIdAsync(Guid guildId)
        {
            return this.guildDetailsService.GetGuildDetailsByIdAsync(guildId);
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildId">The guild's ID.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public Task<Guild> GetGuildDetailsByIdAsync(Guid guildId, CancellationToken cancellationToken)
        {
            return this.guildDetailsService.GetGuildDetailsByIdAsync(guildId, cancellationToken);
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildName">The guild's name.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public Guild GetGuildDetailsByName(string guildName)
        {
            return this.guildDetailsService.GetGuildDetailsByName(guildName);
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildName">The guild's name.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public Task<Guild> GetGuildDetailsByNameAsync(string guildName)
        {
            return this.guildDetailsService.GetGuildDetailsByNameAsync(guildName);
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildName">The guild's name.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public Task<Guild> GetGuildDetailsByNameAsync(string guildName, CancellationToken cancellationToken)
        {
            return this.guildDetailsService.GetGuildDetailsByNameAsync(guildName, cancellationToken);
        }

        /// <summary>Gets an image.</summary>
        /// <param name="file">The file.</param>
        /// <param name="imageFormat">The image Format.</param>
        /// <returns>The <see cref="Image"/>.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:Render_service">wiki</a> for more information.</remarks>
        public Image GetImage(IRenderable file, string imageFormat)
        {
            return this.renderService.GetImage(file, imageFormat);
        }

        /// <summary>Gets an image.</summary>
        /// <param name="file">The file.</param>
        /// <param name="imageFormat">The image format.</param>
        /// <returns>The <see cref="Image"/>.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:Render_service">wiki</a> for more information.</remarks>
        public Task<Image> GetImageAsync(IRenderable file, string imageFormat)
        {
            return this.renderService.GetImageAsync(file, imageFormat, CancellationToken.None);
        }

        /// <summary>Gets an image.</summary>
        /// <param name="file">The file.</param>
        /// <param name="imageFormat">The image format.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <see cref="Image"/>.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:Render_service">wiki</a> for more information.</remarks>
        public Task<Image> GetImageAsync(IRenderable file, string imageFormat, CancellationToken cancellationToken)
        {
            return this.renderService.GetImageAsync(file, imageFormat, cancellationToken);
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="itemId">The item identifier.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Item GetItemDetails(int itemId)
        {
            return this.itemDetailsService.GetItemDetails(itemId);
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="itemId">The item identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Item GetItemDetails(int itemId, CultureInfo language)
        {
            return this.itemDetailsService.GetItemDetails(itemId, language);
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="itemId">The item identifier.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Task<Item> GetItemDetailsAsync(int itemId)
        {
            return this.itemDetailsService.GetItemDetailsAsync(itemId);
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="itemId">The item identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Task<Item> GetItemDetailsAsync(int itemId, CultureInfo language)
        {
            return this.itemDetailsService.GetItemDetailsAsync(itemId, language);
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="itemId">The item identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Task<Item> GetItemDetailsAsync(int itemId, CancellationToken cancellationToken)
        {
            return this.itemDetailsService.GetItemDetailsAsync(itemId, cancellationToken);
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="itemId">The item identifier.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Task<Item> GetItemDetailsAsync(int itemId, CultureInfo language, CancellationToken cancellationToken)
        {
            return this.itemDetailsService.GetItemDetailsAsync(itemId, language, cancellationToken);
        }

        /// <summary>Gets a collection of item identifiers.</summary>
        /// <returns>A collection of item identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/items">wiki</a> for more information.</remarks>
        public IEnumerable<int> GetItems()
        {
            return this.itemService.GetItems();
        }

        /// <summary>Gets a collection of item identifiers.</summary>
        /// <returns>A collection of item identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/items">wiki</a> for more information.</remarks>
        public Task<IEnumerable<int>> GetItemsAsync()
        {
            return this.itemService.GetItemsAsync();
        }

        /// <summary>Gets a collection of item identifiers.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of item identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/items">wiki</a> for more information.</remarks>
        public Task<IEnumerable<int>> GetItemsAsync(CancellationToken cancellationToken)
        {
            return this.itemService.GetItemsAsync(cancellationToken);
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Map GetMap(int mapId)
        {
            return this.mapService.GetMap(mapId);
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="language">The language.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Map GetMap(int mapId, CultureInfo language)
        {
            return this.mapService.GetMap(mapId, language);
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<Map> GetMapAsync(int mapId)
        {
            return this.mapService.GetMapAsync(mapId);
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<Map> GetMapAsync(int mapId, CancellationToken cancellationToken)
        {
            return this.mapService.GetMapAsync(mapId, cancellationToken);
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="language">The language.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<Map> GetMapAsync(int mapId, CultureInfo language)
        {
            return this.mapService.GetMapAsync(mapId, language);
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<Map> GetMapAsync(int mapId, CultureInfo language, CancellationToken cancellationToken)
        {
            return this.mapService.GetMapAsync(mapId, language, cancellationToken);
        }

        /// <summary>Gets a map floor and its localized details.</summary>
        /// <param name="continentId">The continent.</param>
        /// <param name="floor">The floor number.</param>
        /// <returns>A map floor and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public Floor GetMapFloor(int continentId, int floor)
        {
            return this.mapFloorService.GetMapFloor(continentId, floor);
        }

        /// <summary>Gets a map floor and its localized details.</summary>
        /// <param name="continentId">The continent.</param>
        /// <param name="floor">The floor number.</param>
        /// <param name="language">The language.</param>
        /// <returns>A map floor and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public Floor GetMapFloor(int continentId, int floor, CultureInfo language)
        {
            return this.mapFloorService.GetMapFloor(continentId, floor, language);
        }

        /// <summary>Gets a map floor and its localized details.</summary>
        /// <param name="continentId">The continent.</param>
        /// <param name="floor">The floor number.</param>
        /// <returns>A map floor and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public Task<Floor> GetMapFloorAsync(int continentId, int floor)
        {
            return this.mapFloorService.GetMapFloorAsync(continentId, floor);
        }

        /// <summary>Gets a map floor and its localized details.</summary>
        /// <param name="continentId">The continent.</param>
        /// <param name="floor">The floor number.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A map floor and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public Task<Floor> GetMapFloorAsync(int continentId, int floor, CancellationToken cancellationToken)
        {
            return this.mapFloorService.GetMapFloorAsync(continentId, floor, cancellationToken);
        }

        /// <summary>Gets a map floor and its localized details.</summary>
        /// <param name="continentId">The continent.</param>
        /// <param name="floor">The floor number.</param>
        /// <param name="language">The language.</param>
        /// <returns>A map floor and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public Task<Floor> GetMapFloorAsync(int continentId, int floor, CultureInfo language)
        {
            return this.mapFloorService.GetMapFloorAsync(continentId, floor, language);
        }

        /// <summary>Gets a map floor and its localized details.</summary>
        /// <param name="continentId">The continent.</param>
        /// <param name="floor">The floor number.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A map floor and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public Task<Floor> GetMapFloorAsync(int continentId, int floor, CultureInfo language, CancellationToken cancellationToken)
        {
            return this.mapFloorService.GetMapFloorAsync(continentId, floor, language, cancellationToken);
        }

        /// <summary>Gets a collection of maps and their localized name.</summary>
        /// <returns>A collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public IEnumerable<MapName> GetMapNames()
        {
            return this.mapNameService.GetMapNames();
        }

        /// <summary>Gets a collection of maps and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public IEnumerable<MapName> GetMapNames(CultureInfo language)
        {
            return this.mapNameService.GetMapNames(language);
        }

        /// <summary>Gets a collection of maps and their localized name.</summary>
        /// <returns>A collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<MapName>> GetMapNamesAsync()
        {
            return this.mapNameService.GetMapNamesAsync();
        }

        /// <summary>Gets a collection of maps and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<MapName>> GetMapNamesAsync(CancellationToken cancellationToken)
        {
            return this.mapNameService.GetMapNamesAsync(cancellationToken);
        }

        /// <summary>Gets a collection of maps and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<MapName>> GetMapNamesAsync(CultureInfo language)
        {
            return this.mapNameService.GetMapNamesAsync(language);
        }

        /// <summary>Gets a collection of maps and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<MapName>> GetMapNamesAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            return this.mapNameService.GetMapNamesAsync(language, cancellationToken);
        }

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <returns>A collection of maps and their details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public IEnumerable<Map> GetMaps()
        {
            return this.mapService.GetMaps();
        }

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of maps and their details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public IEnumerable<Map> GetMaps(CultureInfo language)
        {
            return this.mapService.GetMaps(language);
        }

        /// <summary>Gets a collection of maps and their localized details.</summary>
        /// <returns>A collection of maps and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Map>> GetMapsAsync()
        {
            return this.mapService.GetMapsAsync();
        }

        /// <summary>Gets a collection of maps and their localized details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Map>> GetMapsAsync(CancellationToken cancellationToken)
        {
            return this.mapService.GetMapsAsync(cancellationToken);
        }

        /// <summary>Gets a collection of maps and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of maps and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Map>> GetMapsAsync(CultureInfo language)
        {
            return this.mapService.GetMapsAsync(language);
        }

        /// <summary>Gets a collection of maps and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Map>> GetMapsAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            return this.mapService.GetMapsAsync(language, cancellationToken);
        }

        /// <summary>Gets a World versus World match and its details.</summary>
        /// <param name="matchId">The match.</param>
        /// <returns>A World versus World match and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/match_details">wiki</a> for more information.</remarks>
        public MatchDetails GetMatchDetails(string matchId)
        {
            return this.matchDetailsService.GetMatchDetails(matchId);
        }

        /// <summary>Gets a World versus World match and its details.</summary>
        /// <param name="matchId">The match.</param>
        /// <returns>A World versus World match and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/match_details">wiki</a> for more information.</remarks>
        public Task<MatchDetails> GetMatchDetailsAsync(string matchId)
        {
            return this.matchDetailsService.GetMatchDetailsAsync(matchId);
        }

        /// <summary>Gets a World versus World match and its details.</summary>
        /// <param name="matchId">The match.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A World versus World match and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/match_details">wiki</a> for more information.</remarks>
        public Task<MatchDetails> GetMatchDetailsAsync(string matchId, CancellationToken cancellationToken)
        {
            return this.matchDetailsService.GetMatchDetailsAsync(matchId, cancellationToken);
        }

        /// <summary>Gets a collection of currently running World versus World matches.</summary>
        /// <returns>A collection of currently running World versus World matches.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/matches">wiki</a> for more information.</remarks>
        public IEnumerable<Match> GetMatches()
        {
            return this.matchService.GetMatches();
        }

        /// <summary>Gets a collection of currently running World versus World matches.</summary>
        /// <returns>A collection of currently running World versus World matches.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/matches">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Match>> GetMatchesAsync()
        {
            return this.matchService.GetMatchesAsync();
        }

        /// <summary>Gets a collection of currently running World versus World matches.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of currently running World versus World matches.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/matches">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Match>> GetMatchesAsync(CancellationToken cancellationToken)
        {
            return this.matchService.GetMatchesAsync(cancellationToken);
        }

        /// <summary>Gets a collection of World versus World objectives and their localized name.</summary>
        /// <returns>A collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public IEnumerable<ObjectiveName> GetObjectiveNames()
        {
            return this.objectiveNameService.GetObjectiveNames();
        }

        /// <summary>Gets a collection of World versus World objectives and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public IEnumerable<ObjectiveName> GetObjectiveNames(CultureInfo language)
        {
            return this.objectiveNameService.GetObjectiveNames(language);
        }

        /// <summary>Gets a collection of World versus World objectives and their localized name.</summary>
        /// <returns>A collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<ObjectiveName>> GetObjectiveNamesAsync()
        {
            return this.objectiveNameService.GetObjectiveNamesAsync();
        }

        /// <summary>Gets a collection of World versus World objectives and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<ObjectiveName>> GetObjectiveNamesAsync(CancellationToken cancellationToken)
        {
            return this.objectiveNameService.GetObjectiveNamesAsync(cancellationToken);
        }

        /// <summary>Gets a collection of World versus World objectives and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<ObjectiveName>> GetObjectiveNamesAsync(CultureInfo language)
        {
            return this.objectiveNameService.GetObjectiveNamesAsync(language);
        }

        /// <summary>Gets a collection of World versus World objectives and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<ObjectiveName>> GetObjectiveNamesAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            return this.objectiveNameService.GetObjectiveNamesAsync(language, cancellationToken);
        }

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipeId">A recipe.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Recipe GetRecipeDetails(int recipeId)
        {
            return this.recipeDetailsService.GetRecipeDetails(recipeId);
        }

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipeId">A recipe.</param>
        /// <param name="language">The language.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Recipe GetRecipeDetails(int recipeId, CultureInfo language)
        {
            return this.recipeDetailsService.GetRecipeDetails(recipeId, language);
        }

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipeId">A recipe.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Task<Recipe> GetRecipeDetailsAsync(int recipeId)
        {
            return this.recipeDetailsService.GetRecipeDetailsAsync(recipeId);
        }

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipeId">A recipe.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Task<Recipe> GetRecipeDetailsAsync(int recipeId, CancellationToken cancellationToken)
        {
            return this.recipeDetailsService.GetRecipeDetailsAsync(recipeId, cancellationToken);
        }

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipeId">A recipe.</param>
        /// <param name="language">The language.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Task<Recipe> GetRecipeDetailsAsync(int recipeId, CultureInfo language)
        {
            return this.recipeDetailsService.GetRecipeDetailsAsync(recipeId, language);
        }

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipeId">A recipe.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Task<Recipe> GetRecipeDetailsAsync(int recipeId, CultureInfo language, CancellationToken cancellationToken)
        {
            return this.recipeDetailsService.GetRecipeDetailsAsync(recipeId, language, cancellationToken);
        }

        /// <summary>Gets a collection of discovered recipes.</summary>
        /// <returns>A collection of discovered recipes.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes">wiki</a> for more information.</remarks>
        public IEnumerable<int> GetRecipes()
        {
            return this.recipeService.GetRecipes();
        }

        /// <summary>Gets a collection of discovered recipes.</summary>
        /// <returns>A collection of discovered recipes.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes">wiki</a> for more information.</remarks>
        public Task<IEnumerable<int>> GetRecipesAsync()
        {
            return this.recipeService.GetRecipesAsync();
        }

        /// <summary>Gets a collection of discovered recipes.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of discovered recipes.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes">wiki</a> for more information.</remarks>
        public Task<IEnumerable<int>> GetRecipesAsync(CancellationToken cancellationToken)
        {
            return this.recipeService.GetRecipesAsync(cancellationToken);
        }

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skinId">The skin identifier.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        public Skin GetSkinDetails(int skinId)
        {
            return this.skinDetailsService.GetSkinDetails(skinId);
        }

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skinId">The skin identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        public Skin GetSkinDetails(int skinId, CultureInfo language)
        {
            return this.skinDetailsService.GetSkinDetails(skinId, language);
        }

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skinId">The skin identifier.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        public Task<Skin> GetSkinDetailsAsync(int skinId)
        {
            return this.skinDetailsService.GetSkinDetailsAsync(skinId);
        }

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skinId">The skin identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        public Task<Skin> GetSkinDetailsAsync(int skinId, CultureInfo language)
        {
            return this.skinDetailsService.GetSkinDetailsAsync(skinId, language);
        }

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skinId">The skin identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        public Task<Skin> GetSkinDetailsAsync(int skinId, CancellationToken cancellationToken)
        {
            return this.skinDetailsService.GetSkinDetailsAsync(skinId, cancellationToken);
        }

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skinId">The skin identifier.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        public Task<Skin> GetSkinDetailsAsync(int skinId, CultureInfo language, CancellationToken cancellationToken)
        {
            return this.skinDetailsService.GetSkinDetailsAsync(skinId, language, cancellationToken);
        }

        /// <summary>Gets a collection of skin identifiers.</summary>
        /// <returns>A collection of skin identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skins">wiki</a> for more information.</remarks>
        public IEnumerable<int> GetSkins()
        {
            return this.skinService.GetSkins();
        }

        /// <summary>Gets a collection of skin identifiers.</summary>
        /// <returns>A collection of skin identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skins">wiki</a> for more information.</remarks>
        public Task<IEnumerable<int>> GetSkinsAsync()
        {
            return this.skinService.GetSkinsAsync();
        }

        /// <summary>Gets a collection of skin identifiers.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of skin identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skins">wiki</a> for more information.</remarks>
        public Task<IEnumerable<int>> GetSkinsAsync(CancellationToken cancellationToken)
        {
            return this.skinService.GetSkinsAsync(cancellationToken);
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public IEnumerable<WorldName> GetWorldNames()
        {
            return this.worldNameService.GetWorldNames();
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public IEnumerable<WorldName> GetWorldNames(CultureInfo language)
        {
            return this.worldNameService.GetWorldNames(language);
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<WorldName>> GetWorldNamesAsync()
        {
            return this.worldNameService.GetWorldNamesAsync();
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<WorldName>> GetWorldNamesAsync(CancellationToken cancellationToken)
        {
            return this.worldNameService.GetWorldNamesAsync(cancellationToken);
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<WorldName>> GetWorldNamesAsync(CultureInfo language)
        {
            return this.worldNameService.GetWorldNamesAsync(language);
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<WorldName>> GetWorldNamesAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            return this.worldNameService.GetWorldNamesAsync(language, cancellationToken);
        }
    }
}