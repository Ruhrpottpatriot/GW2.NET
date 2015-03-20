// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FactoryForV1.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides access to version 1 of the public API.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using GW2NET.V1.Events;

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
    using GW2NET.V1.Files;
    using GW2NET.V1.Floors;
    using GW2NET.V1.Guilds;
    using GW2NET.V1.Maps;
    using GW2NET.V1.Skins;
    using GW2NET.V1.Items;
    using GW2NET.V1.Recipes;
    using GW2NET.V1.Worlds;

    /// <summary>Provides access to version 1 of the public API.</summary>
    public class FactoryForV1 : FactoryBase
    {
        /// <summary>Initializes a new instance of the <see cref="FactoryForV1"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public FactoryForV1(IServiceClient serviceClient)
            : base(serviceClient)
        {
            Contract.Requires(serviceClient != null);
        }

        /// <summary>Provides access to the builds data source.</summary>
        [Obsolete("A build endpoint based on version 2 of the api is available. Usage of that version is recommended.")]
        public IBuildService Build
        {
            get
            {
                Contract.Ensures(Contract.Result<IBuildService>() != null);
                return new BuildService(this.ServiceClient);
            }
        }

        /// <summary>Provides access to the colors data source.</summary>
        [Obsolete("A colors endpoint based on version 2 of the api is available. Usage of that version is recommended.")]
        public ColorRepositoryFactory Colors
        {
            get
            {
                Contract.Ensures(Contract.Result<ColorRepositoryFactory>() != null);
                return new ColorRepositoryFactory(this.ServiceClient);
            }
        }

        /// <summary>Provides access to the continents data source.</summary>
        [Obsolete("A continents endpoint based on version 2 of the api is available. Usage of that version is recommended.")]
        public ContinentRepositoryFactory Continents
        {
            get
            {
                Contract.Ensures(Contract.Result<ContinentRepositoryFactory>() != null);
                return new ContinentRepositoryFactory(this.ServiceClient);
            }
        }

        /// <summary>Provides access to the event names data source.</summary>
        [Obsolete("Events are no longer supported by the api since megaserver transition.")]
        public EventNameRepositoryFactory EventNames
        {
            get
            {
                Contract.Ensures(Contract.Result<EventNameRepositoryFactory>() != null);
                return new EventNameRepositoryFactory(this.ServiceClient);
            }
        }

        /// <summary>Provides access to the events data source.</summary>
        [Obsolete("Events are no longer supported by the api since megaserver transition.", true)]
        public EventRepositoryFactory Events
        {
            get
            {
                Contract.Ensures(Contract.Result<EventRepositoryFactory>() != null);
                return new EventRepositoryFactory(this.ServiceClient);
            }
        }

        /// <summary>Provides access to the files data source.</summary>
        [Obsolete("A files endpoint based on version 2 of the api is available. Usage of that version is recommended.")]
        public IFileRepository Files
        {
            get
            {
                Contract.Ensures(Contract.Result<IFileRepository>() != null);
                return new FileRepository(this.ServiceClient);
            }
        }

        /// <summary>Provides access to the floors data source.</summary>
       public FloorRepositoryFactory Floors
        {
            get
            {
                Contract.Ensures(Contract.Result<FloorRepositoryFactory>() != null);
                return new FloorRepositoryFactory(this.ServiceClient);
            }
        }

        /// <summary>Provides access to the guilds data source.</summary>
        public IGuildRepository Guilds
        {
            get
            {
                Contract.Ensures(Contract.Result<IGuildRepository>() != null);
                return new GuildRepository(this.ServiceClient);
            }
        }

        /// <summary>Provides access to the items data source.</summary>
        [Obsolete("A items endpoint based on version 2 of the api is available. Usage of that version is recommended.")]
        public ItemRepositoryFactory Items
        {
            get
            {
                Contract.Ensures(Contract.Result<ItemRepositoryFactory>() != null);
                return new ItemRepositoryFactory(this.ServiceClient);
            }
        }

        /// <summary>Provides access to the map names data source.</summary>
        [Obsolete("A map names endpoint based on version 2 of the api is available. Usage of that version is recommended.")]
        public MapNameRepositoryFactory MapNames
        {
            get
            {
                Contract.Ensures(Contract.Result<MapNameRepositoryFactory>() != null);
                return new MapNameRepositoryFactory(this.ServiceClient);
            }
        }

        /// <summary>Provides access to the maps data source.</summary>
        [Obsolete("A maps endpoint based on version 2 of the api is available. Usage of that version is recommended.")]
        public MapRepositoryFactory Maps
        {
            get
            {
                Contract.Ensures(Contract.Result<MapRepositoryFactory>() != null);
                return new MapRepositoryFactory(this.ServiceClient);
            }
        }

        /// <summary>Provides access to the recipes data source.</summary>
        [Obsolete("A recipes endpoint based on version 2 of the api is available. Usage of that version is recommended.")]
        public RecipeRepositoryFactory Recipes
        {
            get
            {
                Contract.Ensures(Contract.Result<RecipeRepositoryFactory>() != null);
                return new RecipeRepositoryFactory(this.ServiceClient);
            }
        }

        /// <summary>Provides access to the skins data source.</summary>
        [Obsolete("A skins endpoint based on version 2 of the api is available. Usage of that version is recommended.")]
        public SkinRepositoryFactory Skins
        {
            get
            {
                Contract.Ensures(Contract.Result<SkinRepositoryFactory>() != null);
                return new SkinRepositoryFactory(this.ServiceClient);
            }
        }

        /// <summary>Provides access to the worlds data source.</summary>
        [Obsolete("A worlds endpoint based on version 2 of the api is available. Usage of that version is recommended.")]
        public WorldRepositoryFactory Worlds
        {
            get
            {
                Contract.Ensures(Contract.Result<WorldRepositoryFactory>() != null);
                return new WorldRepositoryFactory(this.ServiceClient);
            }
        }

        /// <summary>Provides access to WvW data sources.</summary>
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