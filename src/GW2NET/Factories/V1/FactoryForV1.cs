// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FactoryForV1.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Factories.V1
{
    using System;

    using GW2NET.Builds;
    using GW2NET.Common;
    using GW2NET.Files;
    using GW2NET.Guilds;
    using GW2NET.V1.Builds;
    using GW2NET.V1.Builds.Converters;
    using GW2NET.V1.Files;
    using GW2NET.V1.Files.Converters;
    using GW2NET.V1.Guilds;
    using GW2NET.V1.Guilds.Converters;

    /// <summary>Provides access to version 1 of the public API.</summary>
    public class FactoryForV1 : FactoryBase
    {
        /// <summary>Initializes a new instance of the <see cref="FactoryForV1"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> is a null reference.</exception>
        public FactoryForV1(IServiceClient serviceClient)
            : base(serviceClient)
        {
        }

        /// <summary>Gets access to the builds data source.</summary>
        [Obsolete("A build endpoint based on version 2 of the api is available. Usage of that version is recommended.")]
        public IBuildService Builds
        {
            get
            {
                return new BuildService(this.ServiceClient, new BuildConverter());
            }
        }

        /// <summary>Gets access to the colors data source.</summary>
        [Obsolete("A colors endpoint based on version 2 of the api is available. Usage of that version is recommended.")]
        public ColorRepositoryFactory Colors
        {
            get
            {
                return new ColorRepositoryFactory(this.ServiceClient);
            }
        }

        /// <summary>Gets access to the continents data source.</summary>
        [Obsolete("A continents endpoint based on version 2 of the api is available. Usage of that version is recommended.")]
        public ContinentRepositoryFactory Continents
        {
            get
            {
                return new ContinentRepositoryFactory(this.ServiceClient);
            }
        }

        /// <summary>Gets access to the event names data source.</summary>
        // [Obsolete("Events are no longer supported by the api since megaserver transition.")]
        // ^ not true, /v1/event_names.json is still supported
        public EventNameRepositoryFactory EventNames
        {
            get
            {
                return new EventNameRepositoryFactory(this.ServiceClient);
            }
        }

        /// <summary>Gets access to the events data source.</summary>
        // [Obsolete("Events are no longer supported by the api since megaserver transition.")]
        // ^ not true, /v1/event_details.json is still supported
        public EventRepositoryFactory Events
        {
            get
            {
                return new EventRepositoryFactory(this.ServiceClient);
            }
        }

        /// <summary>Gets access to the files data source.</summary>
        [Obsolete("A files endpoint based on version 2 of the api is available. Usage of that version is recommended.")]
        public IFileRepository Files
        {
            get
            {
                return new FileRepository(this.ServiceClient, new AssetConverter());
            }
        }

        /// <summary>Gets access to the floors data source.</summary>
        public FloorRepositoryFactory Floors
        {
            get
            {
                return new FloorRepositoryFactory(this.ServiceClient);
            }
        }

        /// <summary>Gets access to the guilds data source.</summary>
        public IGuildRepository Guilds
        {
            get
            {
                var emblemTransformationConverter = new EmblemTransformationConverter();
                var emblemTransformationsConverter = new EmblemTransformationCollectionConverter(emblemTransformationConverter);
                var emblemConverter = new EmblemConverter(emblemTransformationsConverter);
                return new GuildRepository(this.ServiceClient, new GuildConverter(emblemConverter));
            }
        }

        /// <summary>Gets access to the items data source.</summary>
        [Obsolete("A items endpoint based on version 2 of the api is available. Usage of that version is recommended.")]
        public ItemRepositoryFactory Items
        {
            get
            {
                return new ItemRepositoryFactory(this.ServiceClient);
            }
        }

        /// <summary>Gets access to the map names data source.</summary>
        [Obsolete("A map names endpoint based on version 2 of the api is available. Usage of that version is recommended.")]
        public MapNameRepositoryFactory MapNames
        {
            get
            {
                return new MapNameRepositoryFactory(this.ServiceClient);
            }
        }

        /// <summary>Gets access to the maps data source.</summary>
        [Obsolete("A maps endpoint based on version 2 of the api is available. Usage of that version is recommended.")]
        public MapRepositoryFactory Maps
        {
            get
            {
                return new MapRepositoryFactory(this.ServiceClient);
            }
        }

        /// <summary>Gets access to the recipes data source.</summary>
        [Obsolete("A recipes endpoint based on version 2 of the api is available. Usage of that version is recommended.")]
        public RecipeRepositoryFactory Recipes
        {
            get
            {
                return new RecipeRepositoryFactory(this.ServiceClient);
            }
        }

        /// <summary>Gets access to the skins data source.</summary>
        [Obsolete("A skins endpoint based on version 2 of the api is available. Usage of that version is recommended.")]
        public SkinRepositoryFactory Skins
        {
            get
            {
                return new SkinRepositoryFactory(this.ServiceClient);
            }
        }

        /// <summary>Gets access to the worlds data source.</summary>
        [Obsolete("A worlds endpoint based on version 2 of the api is available. Usage of that version is recommended.")]
        public WorldRepositoryFactory Worlds
        {
            get
            {
                return new WorldRepositoryFactory(this.ServiceClient);
            }
        }

        /// <summary>Gets access to world versus world data sources.</summary>
        public FactoryForV1WvW WorldVersusWorld
        {
            get
            {
                return new FactoryForV1WvW(this.ServiceClient);
            }
        }
    }
}