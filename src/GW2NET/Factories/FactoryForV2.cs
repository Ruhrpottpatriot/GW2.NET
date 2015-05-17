// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FactoryForV2.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides access to version 2 of the public API.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Factories
{
    using System;

    using GW2NET.Common;
    using GW2NET.Quaggans;
    using GW2NET.V2.Build;
    using GW2NET.V2.Colors;
    using GW2NET.V2.Continents;
    using GW2NET.V2.Files;
    using GW2NET.V2.Floors;
    using GW2NET.V2.Items;
    using GW2NET.V2.Maps;
    using GW2NET.V2.Quaggans;
    using GW2NET.V2.Recipes;
    using GW2NET.V2.Skins;
    using GW2NET.V2.Worlds;

    /// <summary>Provides access to version 2 of the public API.</summary>
    public class FactoryForV2 : FactoryBase
    {
        /// <summary>Initializes a new instance of the <see cref="FactoryForV2"/> class. Initializes a new instance of the <see cref="FactoryBase"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> is a null reference.</exception>
        public FactoryForV2(IServiceClient serviceClient)
            : base(serviceClient)
        {
        }

        /// <summary>Gets access to the v2 build service.</summary>
        public IBuildService Build
        {
            get
            {
                return new BuildService(this.ServiceClient);
            }
        }

        /// <summary>Gets access to the colors data source.</summary>
        public ColorRepositoryFactory Colors
        {
            get
            {
                return new ColorRepositoryFactory(this.ServiceClient);
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
        public FileRepositoryFactoryV2 Files
        {
            get
            {
                return new FileRepositoryFactoryV2(this.ServiceClient);
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
                return new QuagganRepository(this.ServiceClient);
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
    }
}