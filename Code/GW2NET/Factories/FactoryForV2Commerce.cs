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

        public IListingRepository Listings
        {
            get
            {
                Contract.Ensures(Contract.Result<IListingRepository>() != null);
                return new ListingRepository(this.ServiceClient);
            }
        }

        public IAggregateListingRepository Prices
        {
            get
            {
                Contract.Ensures(Contract.Result<IAggregateListingRepository>() != null);
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
