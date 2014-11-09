namespace GW2NET.Factories
{
    using System;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Entities.Files;
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
                Contract.Ensures(Contract.Result<IBuildService>() != null);
                return new BuildService(this.ServiceClient);
            }
        }

        public FactoryForV1Colors Colors
        {
            get
            {
                Contract.Ensures(Contract.Result<FactoryForV1Colors>() != null);
                return new FactoryForV1Colors(this.ServiceClient);
            }
        }

        public FactoryForV1Continents Continents
        {
            get
            {
                Contract.Ensures(Contract.Result<FactoryForV1Continents>() != null);
                return new FactoryForV1Continents(this.ServiceClient);
            }
        }

        public IDynamicEventDetailsService Events
        {
            get
            {
                Contract.Ensures(Contract.Result<IDynamicEventDetailsService>() != null);
                return new DynamicEventService(this.ServiceClient);
            }
        }

        public IDynamicEventStateService EventStates
        {
            get
            {
                Contract.Ensures(Contract.Result<IDynamicEventStateService>() != null);
                return new DynamicEventService(this.ServiceClient);
            }
        }

        public IDynamicEventStateService EventNames
        {
            get
            {
                Contract.Ensures(Contract.Result<IDynamicEventStateService>() != null);
                return new DynamicEventService(this.ServiceClient);
            }
        }

        public IRepository<string, Asset> Files
        {
            get
            {
                Contract.Ensures(Contract.Result<IRepository<string, Asset>>() != null);
                return new FileRepository(this.ServiceClient);
            }
        }

        public FactoryForV1Guilds Guilds
        {
            get
            {
                Contract.Ensures(Contract.Result<FactoryForV1Guilds>() != null);
                return new FactoryForV1Guilds(this.ServiceClient);
            }
        }
        public ItemRepositoryFactory Items
        {
            get
            {
                Contract.Ensures(Contract.Result<ItemRepositoryFactory>() != null);
                return new ItemRepositoryFactory(this.ServiceClient);
            }
        }

        public FactoryForV1MapNames MapNames
        {
            get
            {
                Contract.Ensures(Contract.Result<FactoryForV1MapNames>() != null);
                return new FactoryForV1MapNames(this.ServiceClient);
            }
        }

        public FactoryForV1Maps Maps
        {
            get
            {
                Contract.Ensures(Contract.Result<FactoryForV1Maps>() != null);
                return new FactoryForV1Maps(this.ServiceClient);
            }
        }

        public FloorRepositoryFactory Floors
        {
            get
            {
                Contract.Ensures(Contract.Result<FloorRepositoryFactory>() != null);
                return new FloorRepositoryFactory(this.ServiceClient);
            }
        }

        public RecipeRepositoryFactory Recipes
        {
            get
            {
                Contract.Ensures(Contract.Result<RecipeRepositoryFactory>() != null);
                return new RecipeRepositoryFactory(this.ServiceClient);
            }
        }

        public ISkinService Skins
        {
            get
            {
                Contract.Ensures(Contract.Result<ISkinService>() != null);
                return new SkinService(this.ServiceClient);
            }
        }

        public WorldRepositoryFactory Worlds
        {
            get
            {
                Contract.Ensures(Contract.Result<WorldRepositoryFactory>() != null);
                return new WorldRepositoryFactory(this.ServiceClient);
            }
        }

        public FactoryForV1WvW WvW
        {
            get
            {
                Contract.Ensures(Contract.Result<FactoryForV1WvW>() != null);
                return new FactoryForV1WvW(this.ServiceClient);
            }
        }
    }
}
