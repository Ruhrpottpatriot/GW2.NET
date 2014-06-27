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
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.V1.Builds;
    using GW2DotNET.V1.Builds.Contracts;
    using GW2DotNET.V1.Colors;
    using GW2DotNET.V1.Colors.Contracts;
    using GW2DotNET.V1.Continents;
    using GW2DotNET.V1.Continents.Contracts;
    using GW2DotNET.V1.DynamicEvents;
    using GW2DotNET.V1.DynamicEvents.Contracts;
    using GW2DotNET.V1.Files;
    using GW2DotNET.V1.Files.Contracts;
    using GW2DotNET.V1.Guilds;
    using GW2DotNET.V1.Guilds.Contracts;
    using GW2DotNET.V1.Items;
    using GW2DotNET.V1.Items.Contracts;
    using GW2DotNET.V1.Maps;
    using GW2DotNET.V1.Maps.Contracts;
    using GW2DotNET.V1.Recipes;
    using GW2DotNET.V1.Recipes.Contracts;
    using GW2DotNET.V1.Skins;
    using GW2DotNET.V1.Skins.Contracts;
    using GW2DotNET.V1.Worlds;
    using GW2DotNET.V1.Worlds.Contracts;
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
            this.worldNameService = worldNameService;
            this.skinService = skinService;
            this.skinDetailsService = skinDetailsService;
        }

        /// <summary>Initializes a new instance of the <see cref="ServiceManager" /> class.</summary>
        public ServiceManager()
            : this(new ServiceClient(new Uri("https://api.guildwars2.com")))
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ServiceManager"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public ServiceManager(IServiceClient serviceClient)
        {
            this.buildService = new BuildService(serviceClient);
            this.colorService = new ColorService(serviceClient);
            this.continentService = new ContinentService(serviceClient);
            this.dynamicEventDetailsService = new DynamicEventDetailsService(serviceClient);
            this.dynamicEventNameService = new DynamicEventNameService(serviceClient);
            this.dynamicEventRotationService = new DynamicEventRotationService();
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

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEvent> GetDynamicEventDetails()
        {
            return this.dynamicEventDetailsService.GetDynamicEventDetails();
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEvent> GetDynamicEventDetails(CultureInfo language)
        {
            return this.dynamicEventDetailsService.GetDynamicEventDetails(language);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public DynamicEvent GetDynamicEventDetails(Guid eventId)
        {
            return this.dynamicEventDetailsService.GetDynamicEventDetails(eventId);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="language">The language.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public DynamicEvent GetDynamicEventDetails(Guid eventId, CultureInfo language)
        {
            return this.dynamicEventDetailsService.GetDynamicEventDetails(eventId, language);
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventDetailsAsync()
        {
            return this.dynamicEventDetailsService.GetDynamicEventDetailsAsync();
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventDetailsAsync(CancellationToken cancellationToken)
        {
            return this.dynamicEventDetailsService.GetDynamicEventDetailsAsync(cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventDetailsAsync(CultureInfo language)
        {
            return this.dynamicEventDetailsService.GetDynamicEventDetailsAsync(language);
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventDetailsAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            return this.dynamicEventDetailsService.GetDynamicEventDetailsAsync(language, cancellationToken);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<DynamicEvent> GetDynamicEventDetailsAsync(Guid eventId)
        {
            return this.dynamicEventDetailsService.GetDynamicEventDetailsAsync(eventId);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<DynamicEvent> GetDynamicEventDetailsAsync(Guid eventId, CancellationToken cancellationToken)
        {
            return this.dynamicEventDetailsService.GetDynamicEventDetailsAsync(eventId, cancellationToken);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="language">The language.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<DynamicEvent> GetDynamicEventDetailsAsync(Guid eventId, CultureInfo language)
        {
            return this.dynamicEventDetailsService.GetDynamicEventDetailsAsync(eventId, language);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<DynamicEvent> GetDynamicEventDetailsAsync(Guid eventId, CultureInfo language, CancellationToken cancellationToken)
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

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="item">The item identifier.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Item GetItemDetails(Item item)
        {
            return this.itemDetailsService.GetItemDetails(item);
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="item">The item identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Item GetItemDetails(Item item, CultureInfo language)
        {
            return this.itemDetailsService.GetItemDetails(item, language);
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="item">The item identifier.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Task<Item> GetItemDetailsAsync(Item item)
        {
            return this.itemDetailsService.GetItemDetailsAsync(item);
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="item">The item identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Task<Item> GetItemDetailsAsync(Item item, CultureInfo language)
        {
            return this.itemDetailsService.GetItemDetailsAsync(item, language);
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="item">The item identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Task<Item> GetItemDetailsAsync(Item item, CancellationToken cancellationToken)
        {
            return this.itemDetailsService.GetItemDetailsAsync(item, cancellationToken);
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="item">The item identifier.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Task<Item> GetItemDetailsAsync(Item item, CultureInfo language, CancellationToken cancellationToken)
        {
            return this.itemDetailsService.GetItemDetailsAsync(item, language, cancellationToken);
        }

        /// <summary>Gets a collection of item identifiers.</summary>
        /// <returns>A collection of item identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/items">wiki</a> for more information.</remarks>
        public IEnumerable<Item> GetItems()
        {
            return this.itemService.GetItems();
        }

        /// <summary>Gets a collection of item identifiers.</summary>
        /// <returns>A collection of item identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/items">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Item>> GetItemsAsync()
        {
            return this.itemService.GetItemsAsync();
        }

        /// <summary>Gets a collection of item identifiers.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of item identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/items">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Item>> GetItemsAsync(CancellationToken cancellationToken)
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
        /// <param name="recipe">The recipe identifier.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Recipe GetRecipeDetails(Recipe recipe)
        {
            return this.GetRecipeDetails(recipe, CultureInfo.GetCultureInfo("en"));
        }

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipe">The recipe identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Recipe GetRecipeDetails(Recipe recipe, CultureInfo language)
        {
            recipe = this.recipeDetailsService.GetRecipeDetails(recipe, language);
            recipe.OutputItem = this.GetItemDetails(recipe.OutputItem, language);
            foreach (var ingredient in recipe.Ingredients)
            {
                ingredient.Item = this.GetItemDetails(ingredient.Item, language);
            }

            return recipe;
        }

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipe">The recipe identifier.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Task<Recipe> GetRecipeDetailsAsync(Recipe recipe)
        {
            return this.GetRecipeDetailsAsync(recipe, CultureInfo.GetCultureInfo("en"), CancellationToken.None);
        }

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipe">The recipe identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Task<Recipe> GetRecipeDetailsAsync(Recipe recipe, CancellationToken cancellationToken)
        {
            return this.GetRecipeDetailsAsync(recipe, CultureInfo.GetCultureInfo("en"), cancellationToken);
        }

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipe">The recipe identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Task<Recipe> GetRecipeDetailsAsync(Recipe recipe, CultureInfo language)
        {
            return this.GetRecipeDetailsAsync(recipe, language, CancellationToken.None);
        }

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipe">The recipe identifier.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Task<Recipe> GetRecipeDetailsAsync(Recipe recipe, CultureInfo language, CancellationToken cancellationToken)
        {
            var t1 = this.recipeDetailsService.GetRecipeDetailsAsync(recipe, language, cancellationToken);
            var t2 = t1.ContinueWith(
                task =>
                    {
                        recipe = task.Result;
                        recipe.OutputItem = this.GetItemDetailsAsync(recipe.OutputItem, language, cancellationToken).Result;
                        Parallel.ForEach(
                            recipe.Ingredients, 
                            ingredient => { ingredient.Item = this.GetItemDetailsAsync(ingredient.Item, language, cancellationToken).Result; });

                        return recipe;
                    }, 
                cancellationToken);

            return t2;
        }

        /// <summary>Gets a collection of discovered recipes.</summary>
        /// <returns>A collection of discovered recipes.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes">wiki</a> for more information.</remarks>
        public IEnumerable<Recipe> GetRecipes()
        {
            return this.recipeService.GetRecipes();
        }

        /// <summary>Gets a collection of discovered recipes.</summary>
        /// <returns>A collection of discovered recipes.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Recipe>> GetRecipesAsync()
        {
            return this.recipeService.GetRecipesAsync();
        }

        /// <summary>Gets a collection of discovered recipes.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of discovered recipes.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Recipe>> GetRecipesAsync(CancellationToken cancellationToken)
        {
            return this.recipeService.GetRecipesAsync(cancellationToken);
        }

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skin">The skin identifier.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        public Skin GetSkinDetails(Skin skin)
        {
            return this.skinDetailsService.GetSkinDetails(skin);
        }

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skin">The skin identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        public Skin GetSkinDetails(Skin skin, CultureInfo language)
        {
            return this.skinDetailsService.GetSkinDetails(skin, language);
        }

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skin">The skin identifier.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        public Task<Skin> GetSkinDetailsAsync(Skin skin)
        {
            return this.skinDetailsService.GetSkinDetailsAsync(skin);
        }

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skin">The skin identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        public Task<Skin> GetSkinDetailsAsync(Skin skin, CultureInfo language)
        {
            return this.skinDetailsService.GetSkinDetailsAsync(skin, language);
        }

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skin">The skin identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        public Task<Skin> GetSkinDetailsAsync(Skin skin, CancellationToken cancellationToken)
        {
            return this.skinDetailsService.GetSkinDetailsAsync(skin, cancellationToken);
        }

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skin">The skin identifier.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        public Task<Skin> GetSkinDetailsAsync(Skin skin, CultureInfo language, CancellationToken cancellationToken)
        {
            return this.skinDetailsService.GetSkinDetailsAsync(skin, language, cancellationToken);
        }

        /// <summary>Gets a collection of skin identifiers.</summary>
        /// <returns>A collection of skin identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skins">wiki</a> for more information.</remarks>
        public IEnumerable<Skin> GetSkins()
        {
            return this.skinService.GetSkins();
        }

        /// <summary>Gets a collection of skin identifiers.</summary>
        /// <returns>A collection of skin identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skins">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Skin>> GetSkinsAsync()
        {
            return this.skinService.GetSkinsAsync();
        }

        /// <summary>Gets a collection of skin identifiers.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of skin identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skins">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Skin>> GetSkinsAsync(CancellationToken cancellationToken)
        {
            return this.skinService.GetSkinsAsync(cancellationToken);
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public IEnumerable<World> GetWorldNames()
        {
            return this.worldNameService.GetWorldNames();
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public IEnumerable<World> GetWorldNames(CultureInfo language)
        {
            return this.worldNameService.GetWorldNames(language);
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<World>> GetWorldNamesAsync()
        {
            return this.worldNameService.GetWorldNamesAsync();
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<World>> GetWorldNamesAsync(CancellationToken cancellationToken)
        {
            return this.worldNameService.GetWorldNamesAsync(cancellationToken);
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<World>> GetWorldNamesAsync(CultureInfo language)
        {
            return this.worldNameService.GetWorldNamesAsync(language);
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<World>> GetWorldNamesAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            return this.worldNameService.GetWorldNamesAsync(language, cancellationToken);
        }
    }
}