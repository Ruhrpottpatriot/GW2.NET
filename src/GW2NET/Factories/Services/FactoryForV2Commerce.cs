// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FactoryForV2Commerce.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides access to commerce data sources.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Factories.Services
{
    using System;
    using Commerce;
    using Common;
    using Common.Converters;
    using GW2NET.V2.Commerce.Exchange;
    using GW2NET.V2.Commerce.Exchange.Converters;
    using GW2NET.V2.Commerce.Listings;
    using GW2NET.V2.Commerce.Listings.Converters;
    using GW2NET.V2.Commerce.Listings.Json;
    using GW2NET.V2.Commerce.Prices;
    using GW2NET.V2.Commerce.Prices.Converters;
    using GW2NET.V2.Commerce.Prices.Json;

    /// <summary>Provides access to commerce data sources based on the /v2/ api.</summary>
    public class FactoryForV2Commerce : ServiceFactoryBase
    {
        /// <summary>Initializes a new instance of the <see cref="FactoryForV2Commerce"/> class. Initializes a new instance of the <see cref="ServiceFactoryBase"/> class.</summary>
        /// <param name="serviceClient"></param>
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
                var offerCollectionConverter = new CollectionConverter<ListingOfferDTO, Offer>(offerConverter);
                var listingConverter = new ListingConverter(offerCollectionConverter);
                var identifiersResponseConverter = new CollectionResponseConverter<int, int>(new ConverterAdapter<int>());
                var responseConverter = new ResponseConverter<ListingDTO, Listing>(listingConverter);
                var bulkResponseConverter = new DictionaryRangeResponseConverter<ListingDTO, int, Listing>(listingConverter, listing => listing.ItemId);
                var pageResponseConverter = new CollectionPageResponseConverter<ListingDTO, Listing>(listingConverter);
                return new ListingRepository(this.ServiceClient, identifiersResponseConverter, responseConverter, bulkResponseConverter, pageResponseConverter);
            }
        }

        /// <summary>Gets access to the aggregate listings data source.</summary>
        public IAggregateListingRepository Prices
        {
            get
            {
                var aggregateOfferConverter = new AggregateOfferConverter();
                var aggregateListingConverter = new AggregateListingConverter(aggregateOfferConverter);
                var identifiersResponseConverter = new CollectionResponseConverter<int, int>(new ConverterAdapter<int>());
                var responseConverter = new ResponseConverter<AggregateListingDTO, AggregateListing>(aggregateListingConverter);
                var bulkResponseConverter = new DictionaryRangeResponseConverter<AggregateListingDTO, int, AggregateListing>(aggregateListingConverter, listing => listing.ItemId);
                var pageResponseConverter = new CollectionPageResponseConverter<AggregateListingDTO, AggregateListing>(aggregateListingConverter);
                return new AggregateListingRepository(this.ServiceClient, identifiersResponseConverter, responseConverter, bulkResponseConverter, pageResponseConverter);
            }
        }
    }
}