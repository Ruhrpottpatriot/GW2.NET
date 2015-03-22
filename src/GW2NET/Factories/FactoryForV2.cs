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
    using System.Diagnostics.Contracts;

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
        public FactoryForV2(IServiceClient serviceClient)
            : base(serviceClient)
        {
            Contract.Requires(serviceClient != null);
        }

        /// <summary>Gets access to the v2 build service.</summary>
        public IBuildService Build
        {
            get
            {
                Contract.Ensures(Contract.Result<IBuildService>() != null);
                return new BuildService(this.ServiceClient);
            }
        }

        /// <summary>Gets access to the colors data source.</summary>
        public ColorRepositoryFactory Colors
        {
            get
            {
                Contract.Ensures(Contract.Result<ColorRepositoryFactory>() != null);
                return new ColorRepositoryFactory(this.ServiceClient);
            }
        }

        /// <summary>Gets access to commerce data sources.</summary>
        public FactoryForV2Commerce Commerce
        {
            get
            {
                Contract.Ensures(Contract.Result<FactoryForV2Commerce>() != null);
                return new FactoryForV2Commerce(this.ServiceClient);
            }
        }

        /// <summary>Gets access to the continents data sources.</summary>
        public ContinentRepositoryFactory Continents
        {
            get
            {
                Contract.Ensures(Contract.Result<ContinentRepositoryFactory>() != null);
                return new ContinentRepositoryFactory(this.ServiceClient);
            }
        }

        /// <summary>Gets access to the files data sources.</summary>
        public FileRepositoryFactoryV2 Files
        {
            get
            {
                Contract.Ensures(Contract.Result<FileRepositoryFactoryV2>() != null);
                return new FileRepositoryFactoryV2(this.ServiceClient);
            }
        }

        /// <summary>Gets access to the floors data source.</summary>
        public FloorRepositoryFactory Floors
        {
            get
            {
                Contract.Ensures(Contract.Result<FloorRepositoryFactory>() != null);
                return new FloorRepositoryFactory(this.ServiceClient);
            }
        }

        /// <summary>Gets access to the items data source.</summary>
        public ItemRepositoryFactory Items
        {
            get
            {
                Contract.Ensures(Contract.Result<ItemRepositoryFactory>() != null);
                return new ItemRepositoryFactory(this.ServiceClient);
            }
        }

        /// <summary>Gets access to the maps data source.</summary>
        public MapsRepositoryFactory Maps
        {
            get
            {
                Contract.Ensures(Contract.Result<MapsRepositoryFactory>() != null);
                return new MapsRepositoryFactory(this.ServiceClient);
            }
        }

        /// <summary>Gets access to the Quaggans data source.</summary>
        public IQuagganRepository Quaggans
        {
            get
            {
                Contract.Ensures(Contract.Result<IQuagganRepository>() != null);
                return new QuagganRepository(this.ServiceClient);
            }
        }

        /// <summary>Gets access to the recipe data source.</summary>
        public RecipeRepositoryFactory Recipes
        {
            get
            {
                Contract.Ensures(Contract.Result<RecipeRepositoryFactory>() != null);
                return new RecipeRepositoryFactory(this.ServiceClient);
            }
        }

        /// <summary>Gets access to the skins data source.</summary>
        public SkinRepositoryFactory Skins
        {
            get
            {
                Contract.Ensures(Contract.Result<SkinRepositoryFactory>() != null);
                return new SkinRepositoryFactory(this.ServiceClient);
            }
        }

        /// <summary>Gets access to the worlds data source.</summary>
        public WorldRepositoryFactory Worlds
        {
            get
            {
                Contract.Ensures(Contract.Result<WorldRepositoryFactory>() != null);
                return new WorldRepositoryFactory(this.ServiceClient);
            }
        }
    }
}