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

    using GW2NET.V2.Items;
    using GW2NET.V2.Recipes;
    using GW2NET.V2.Quaggans;
    using GW2NET.V2.Worlds;
    using GW2NET.Common;
    using GW2NET.Quaggans;

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

        /// <summary>Provides access to commerce data sources.</summary>
        public FactoryForV2Commerce Commerce
        {
            get
            {
                Contract.Ensures(Contract.Result<FactoryForV2Commerce>() != null);
                return new FactoryForV2Commerce(this.ServiceClient);
            }
        }

        /// <summary>Provides access to the items data source.</summary>
        public ItemRepositoryFactory Items
        {
            get
            {
                Contract.Ensures(Contract.Result<ItemRepositoryFactory>() != null);
                return new ItemRepositoryFactory(this.ServiceClient);
            }
        }

        /// <summary>Provides access to the Quaggans data source.</summary>
        public IQuagganRepository Quaggans
        {
            get
            {
                Contract.Ensures(Contract.Result<IQuagganRepository>() != null);
                return new QuagganRepository(this.ServiceClient);
            }
        }

        /// <summary>Provides access to the recipes data source.</summary>
        public RecipeRepositoryFactory Recipes
        {
            get
            {
                Contract.Ensures(Contract.Result<RecipeRepositoryFactory>() != null);
                return new RecipeRepositoryFactory(this.ServiceClient);
            }
        }

        /// <summary>Provides access to the worlds data source.</summary>
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