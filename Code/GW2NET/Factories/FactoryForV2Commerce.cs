namespace GW2NET.Factories
{
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Entities.Commerce;
    using GW2NET.V2.Commerce;
    using GW2NET.V2.Commerce.Exchange;
    using GW2NET.V2.Commerce.Listings;
    using GW2NET.V2.Commerce.Prices;

    public class FactoryForV2Commerce : FactoryBase
    {
        /// <summary>Initializes a new instance of the <see cref="FactoryBase"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public FactoryForV2Commerce(IServiceClient serviceClient)
            : base(serviceClient)
        {
            Contract.Requires(serviceClient != null);
        }

        public IRepository<int, Listing> Listings
        {
            get
            {
                Contract.Ensures(Contract.Result<IRepository<int, Listing>>() != null);
                return new ListingRepository(this.ServiceClient);
            }
        }

        public IRepository<int, AggregateListing> Prices
        {
            get
            {
                Contract.Ensures(Contract.Result<IRepository<int, AggregateListing>>() != null);
                return new PriceRepository(this.ServiceClient);
            }
        }

        public ExchangeBrokerFactory Exchange
        {
            get
            {
                Contract.Ensures(Contract.Result<ExchangeBrokerFactory>() != null);
                return new ExchangeBrokerFactory(this.ServiceClient);
            }
        }
    }
}
