namespace GW2NET.Factories
{
    using System;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Files;
    using GW2NET.Guilds;
    using GW2NET.V1.Builds;
    using GW2NET.V1.Colors;
    using GW2NET.V1.Continents;
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

        public ColorRepositoryFactory Colors
        {
            get
            {
                Contract.Ensures(Contract.Result<ColorRepositoryFactory>() != null);
                return new ColorRepositoryFactory(this.ServiceClient);
            }
        }

        public ContinentRepositoryFactory Continents
        {
            get
            {
                Contract.Ensures(Contract.Result<ContinentRepositoryFactory>() != null);
                return new ContinentRepositoryFactory(this.ServiceClient);
            }
        }

        public EventRepositoryFactory Events
        {
            get
            {
                Contract.Ensures(Contract.Result<EventRepositoryFactory>() != null);
                return new EventRepositoryFactory(this.ServiceClient);
            }
        }

        public EventNameRepositoryFactory EventNames
        {
            get
            {
                Contract.Ensures(Contract.Result<EventNameRepositoryFactory>() != null);
                return new EventNameRepositoryFactory(this.ServiceClient);
            }
        }

        public IFileRepository Files
        {
            get
            {
                Contract.Ensures(Contract.Result<IFileRepository>() != null);
                return new FileRepository(this.ServiceClient);
            }
        }

        public IGuildRepository Guilds
        {
            get
            {
                Contract.Ensures(Contract.Result<IGuildRepository>() != null);
                return new GuildRepository(this.ServiceClient);
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

        public MapNameRepositoryFactory MapNames
        {
            get
            {
                Contract.Ensures(Contract.Result<MapNameRepositoryFactory>() != null);
                return new MapNameRepositoryFactory(this.ServiceClient);
            }
        }

        public MapRepositoryFactory Maps
        {
            get
            {
                Contract.Ensures(Contract.Result<MapRepositoryFactory>() != null);
                return new MapRepositoryFactory(this.ServiceClient);
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

        public SkinRepositoryFactory Skins
        {
            get
            {
                Contract.Ensures(Contract.Result<SkinRepositoryFactory>() != null);
                return new SkinRepositoryFactory(this.ServiceClient);
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
