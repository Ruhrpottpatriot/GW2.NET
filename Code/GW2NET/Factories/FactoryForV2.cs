namespace GW2NET.Factories
{
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Quaggans;
    using GW2NET.V2.Items;
    using GW2NET.V2.Quaggans;
    using GW2NET.V2.Recipes;
    using GW2NET.V2.Worlds;

    public class FactoryForV2 : FactoryBase
    {
        /// <summary>Initializes a new instance of the <see cref="FactoryBase"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public FactoryForV2(IServiceClient serviceClient)
            : base(serviceClient)
        {
            Contract.Requires(serviceClient != null);
        }

        public ItemRepositoryFactory Items
        {
            get
            {
                Contract.Ensures(Contract.Result<ItemRepositoryFactory>() != null);
                return new ItemRepositoryFactory(this.ServiceClient);
            }
        }

        public IQuagganRepository Quaggans
        {
            get
            {
                Contract.Ensures(Contract.Result<IQuagganRepository>() != null);
                return new QuagganRepository(this.ServiceClient);
            }
        }

        public FactoryForV2Commerce Commerce
        {
            get
            {
                Contract.Ensures(Contract.Result<FactoryForV2Commerce>() != null);
                return new FactoryForV2Commerce(this.ServiceClient);
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

        public RecipeRepositoryFactory Recipes
        {
            get
            {
                Contract.Ensures(Contract.Result<RecipeRepositoryFactory>() != null);
                return new RecipeRepositoryFactory(this.ServiceClient);
            }
        }

    }
}