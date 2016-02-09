﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FactoryForV2.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides access to version 2 of the public API.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Factories.V2
{
    using System;

    using GW2NET.Builds;
    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.Quaggans;
    using GW2NET.V2.Builds;
    using GW2NET.V2.Builds.Converters;
    using GW2NET.V2.Quaggans;
    using GW2NET.V2.Quaggans.Converters;
    using GW2NET.V2.Quaggans.Json;

    /// <summary>Provides access to version 2 of the public API.</summary>
    public class FactoryForV2 : FactoryBase
    {
        /// <summary>Initializes a new instance of the <see cref="FactoryForV2"/> class. Initializes a new instance of the <see cref="FactoryBase"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> is a null reference.</exception>
        public FactoryForV2(IServiceClient serviceClient)
            : base(serviceClient)
        {
        }

        /// <summary>Gets access to the v2 build service.</summary>
        public IBuildService Builds
        {
            get
            {
                return new BuildService(this.ServiceClient, new BuildConverter());
            }
        }

        /// <summary>Gets access to the colors data source.</summary>
        public V2.ColorRepositoryFactory Colors
        {
            get
            {
                return new V2.ColorRepositoryFactory(this.ServiceClient);
            }
        }

        /// <summary>Gets access to commerce data sources.</summary>
        public FactoryForV2Commerce Commerce
        {
            get
            {
                return new FactoryForV2Commerce(this.ServiceClient);
            }
        }

        /// <summary>Gets access to the continents data sources.</summary>
        public ContinentRepositoryFactory Continents
        {
            get
            {
                return new ContinentRepositoryFactory(this.ServiceClient);
            }
        }

        /// <summary>Gets access to the files data sources.</summary>
        public FileRepositoryFactory Files
        {
            get
            {
                return new FileRepositoryFactory(this.ServiceClient);
            }
        }

        /// <summary>Gets access to the items data source.</summary>
        public ItemRepositoryFactory Items
        {
            get
            {
                return new ItemRepositoryFactory(this.ServiceClient);
            }
        }

        /// <summary>Gets access to the maps data source.</summary>
        public MapsRepositoryFactory Maps
        {
            get
            {
                return new MapsRepositoryFactory(this.ServiceClient);
            }
        }

        /// <summary>Gets access to the Quaggans data source.</summary>
        public IQuagganRepository Quaggans
        {
            get
            {
                var identifiersResponseConverter = new CollectionResponseConverter<string, string>(new ConverterAdapter<string>());
                var quagganConverter = new QuagganConverter();
                var responseConverter = new ResponseConverter<QuagganDTO, Quaggan>(quagganConverter);
                var dictionaryRangeResponseConverter = new DictionaryRangeResponseConverter<QuagganDTO, string, Quaggan>(quagganConverter, quaggan => quaggan.Id);
                var collectionPageResponseConverter = new CollectionPageResponseConverter<QuagganDTO, Quaggan>(quagganConverter);
                return new QuagganRepository(this.ServiceClient, identifiersResponseConverter, responseConverter, dictionaryRangeResponseConverter, collectionPageResponseConverter);
            }
        }

        /// <summary>Gets access to the recipe data source.</summary>
        public RecipeRepositoryFactory Recipes
        {
            get
            {
                return new RecipeRepositoryFactory(this.ServiceClient);
            }
        }

        /// <summary>Gets access to the skins data source.</summary>
        public SkinRepositoryFactory Skins
        {
            get
            {
                return new SkinRepositoryFactory(this.ServiceClient);
            }
        }

        /// <summary>Gets access to the worlds data source.</summary>
        public WorldRepositoryFactory Worlds
        {
            get
            {
                return new WorldRepositoryFactory(this.ServiceClient);
            }
        }

        /// <summary>Gets access to world versus world data sources.</summary>
        public FactoryForV2WvW WorldVersusWorld
        {
            get
            {
                return new FactoryForV2WvW(this.ServiceClient);
            }
        }
    }
}