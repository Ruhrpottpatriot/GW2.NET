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
                return new FactoryForV2Items(this.ServiceClient);
            }
        }

        public IRepository<string, Quaggan> Quaggans
        {
            get
            {
                return new QuagganService(this.ServiceClient);
            }
        }

        public FactoryForV2Commerce Commerce
        {
            get
            {
                return new FactoryForV2Commerce(this.ServiceClient);
            }
        }

        public FactoryForV2Worlds Worlds
        {
            get
            {
                return new FactoryForV2Worlds(this.ServiceClient);
            }
        }
    }
}