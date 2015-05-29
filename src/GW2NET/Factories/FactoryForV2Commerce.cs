// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FactoryForV2Commerce.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides access to commerce data sources.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Factories
{
    using System;

    using GW2NET.Commerce;
    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.V2.Commerce.Exchange;
    using GW2NET.V2.Commerce.Exchange.Converters;
    using GW2NET.V2.Commerce.Listings;
    using GW2NET.V2.Commerce.Listings.DataContracts;
    using GW2NET.V2.Commerce.Prices;

    /// <summary>Provides access to commerce data sources based on the /v2/ api.</summary>
    public class FactoryForV2Commerce : FactoryBase
    {
        /// <summary>Initializes a new instance of the <see cref="FactoryForV2Commerce"/> class. Initializes a new instance of the <see cref="FactoryBase"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> is a null reference.</exception>
        public FactoryForV2Commerce(IServiceClient serviceClient)
            : base(serviceClient)
        {
        }

        /// <summary>Gets access to the gem exchange data source.</summary>
        public ICurrencyExchange Exchange
        {
            get
            {
                return new CurrencyExchange(this.ServiceClient, new ExchangeConverter());
            }
        }

        /// <summary>Gets access to the listings data source.</summary>
        public IListingRepository Listings
        {
            get
            {
                var offerConverter = new OfferConverter();
                var offerCollectionConverter = new ConverterForCollection<ListingOfferDataContract, Offer>(offerConverter);
                var listingConverter = new ListingConverter(offerCollectionConverter);
                return new ListingRepository(this.ServiceClient, listingConverter);
            }
        }

        /// <summary>Gets access to the aggregate listings data source.</summary>
        public IAggregateListingRepository Prices
        {
            get
            {
                return new AggregateListingRepository(this.ServiceClient);
            }
        }
    }
}