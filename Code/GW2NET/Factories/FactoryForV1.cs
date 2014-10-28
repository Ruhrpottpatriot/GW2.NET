namespace GW2NET.Factories
{
    using System;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Entities.Guilds;
    using GW2NET.Entities.Maps;
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

        public FactoryForV1Colors Colors
        {
            get
            {
                return new FactoryForV1Colors(this.ServiceClient);
            }
        }

        public FactoryForV1Continents Continents
        {
            get
            {
                return new FactoryForV1Continents(this.ServiceClient);
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

        public FactoryForV1Guilds Guilds
        {
            get
            {
                return new FactoryForV1Guilds(this.ServiceClient);
            }
        }
        public IItemService Items
        {
            get
            {
                return new ItemService(this.ServiceClient);
            }
        }

        public FactoryForV1MapNames MapNames
        {
            get
            {
                return new FactoryForV1MapNames(this.ServiceClient);
            }
        }

        public FactoryForV1Maps Maps
        {
            get
            {
                return new FactoryForV1Maps(this.ServiceClient);
            }
        }

        public IMapFloorService Floors
        {
            get
            {
                return new MapFloorService(this.ServiceClient);
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
