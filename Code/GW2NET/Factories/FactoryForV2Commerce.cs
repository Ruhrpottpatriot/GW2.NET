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
                return new ListingRepository(this.ServiceClient);
            }
        }

        public IRepository<int, AggregateListing> Prices
        {
            get
            {
                return new PriceRepository(this.ServiceClient);
            }
        }

        public IBroker<string, ExchangeQuote> Exchange
        {
            get
            {
                return new ExchangeBroker(this.ServiceClient);
            }
        }
    }
}
