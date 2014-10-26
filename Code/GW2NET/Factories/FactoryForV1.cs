namespace GW2NET.Factories
{
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.V1.Builds;
    using GW2NET.V1.Colors;
    using GW2NET.V1.DynamicEvents;
    using GW2NET.V1.Files;
    using GW2NET.V1.Floors;
    using GW2NET.V1.Guilds;
    using GW2NET.V1.Items;
    using GW2NET.V1.Maps;
    using GW2NET.V1.Recipes;
    using GW2NET.V1.Skins;
    using GW2NET.V1.Worlds;

    public class FactoryForV1 : FactoryBase
    {
        /// <summary>Initializes a new instance of the <see cref="FactoryBase"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public FactoryForV1(IServiceClient serviceClient)
            : base(serviceClient)
        {
            Contract.Requires(serviceClient != null);
        }

        public IBuildService Build
        {
            get
            {
                return new BuildService(this.ServiceClient);
            }
        }

        public IColorService Colors
        {
            get
            {
                return new ColorService(this.ServiceClient);
            }
        }

        public IContinentDetailsService Continents
        {
            get
            {
                return new MapService(this.ServiceClient);
            }
        }

        public IDynamicEventDetailsService Events
        {
            get
            {
                return new DynamicEventService(this.ServiceClient);
            }
        }

        public IDynamicEventStateService EventStates
        {
            get
            {
                return new DynamicEventService(this.ServiceClient);
            }
        }

        public IDynamicEventStateService EventNames
        {
            get
            {
                return new DynamicEventService(this.ServiceClient);
            }
        }

        public IFileService Files
        {
            get
            {
                return new FileService(this.ServiceClient);
            }
        }

        public IGuildDetailsService Guilds
        {
            get
            {
                return new GuildService(this.ServiceClient);
            }
        }

        public IItemService Items
        {
            get
            {
                return new ItemService(this.ServiceClient);
            }
        }

        public IMapDetailsService Maps
        {
            get
            {
                return new MapService(this.ServiceClient);
            }
        }

        public IMapFloorService Floors
        {
            get
            {
                return new MapFloorService(this.ServiceClient);
            }
        }

        public IMapNameService MapNames
        {
            get
            {
                return new MapService(this.ServiceClient);
            }
        }

        public IRecipeService Recipes
        {
            get
            {
                return new RecipeService(this.ServiceClient);
            }
        }

        public ISkinService Skins
        {
            get
            {
                return new SkinService(this.ServiceClient);
            }
        }

        public IWorldService Worlds
        {
            get
            {
                return new WorldService(this.ServiceClient);
            }
        }

        public FactoryForV1WvW WvW
        {
            get
            {
                return new FactoryForV1WvW(this.ServiceClient);
            }
        }
    }
}
