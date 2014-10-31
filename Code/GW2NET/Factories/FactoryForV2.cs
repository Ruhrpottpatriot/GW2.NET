namespace GW2NET.Factories
{
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Entities.Quaggans;
    using GW2NET.V2.Quaggans;

    public class FactoryForV2 : FactoryBase
    {
        /// <summary>Initializes a new instance of the <see cref="FactoryBase"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public FactoryForV2(IServiceClient serviceClient)
            : base(serviceClient)
        {
            Contract.Requires(serviceClient != null);
        }

        public FactoryForV2Items Items
        {
            get
            {
                Contract.Ensures(Contract.Result<FactoryForV2Items>() != null);
                return new FactoryForV2Items(this.ServiceClient);
            }
        }

        public IRepository<string, Quaggan> Quaggans
        {
            get
            {
                Contract.Ensures(Contract.Result<IRepository<string, Quaggan>>() != null);
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

        public FactoryForV2Worlds Worlds
        {
            get
            {
                Contract.Ensures(Contract.Result<FactoryForV2Worlds>() != null);
                return new FactoryForV2Worlds(this.ServiceClient);
            }
        }
    }
}