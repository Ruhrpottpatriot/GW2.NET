// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceFactory.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides access to the Guild Wars 2 service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET
{
    using System;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Common.Serializers;
    using GW2NET.Compression;
    using GW2NET.Entities.Commerce;
    using GW2NET.Entities.Items;
    using GW2NET.Entities.Quaggans;
    using GW2NET.V2.Commerce;
    using GW2NET.V2.Common;
    using GW2NET.V2.Items;
    using GW2NET.V2.Quaggans;

    /// <summary>Provides access to the Guild Wars 2 service.</summary>
    public class ServiceFactory
    {
        /// <summary>Infrastructure. Holds a reference to a service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="ServiceFactory"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public ServiceFactory(IServiceClient serviceClient)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient", "Precondition failed: serviceClient != null");
            }

            Contract.Ensures(this.serviceClient != null);
            Contract.Ensures(object.ReferenceEquals(this.serviceClient, serviceClient));

            this.serviceClient = serviceClient;
        }

        /// <summary>Gets an instance of the <see cref="ServiceFactory"/> class using the default configuration.</summary>
        /// <returns>The <see cref="ServiceFactory"/>.</returns>
        public static ServiceFactory Default()
        {
            return new ServiceFactory(GetDefaultServiceClient());
        }

        /// <summary>Creates an instance of the <see cref="ExchangeService"/> class, which provides access to the /v2/commerce/exchange service.</summary>
        /// <returns>A new instance of the <see cref="ExchangeService"/> class.</returns>
        public IBroker<string, ExchangeQuote> GetExchangeService()
        {
            return new ExchangeService(this.serviceClient);
        }

        /// <summary>Creates an instance of the <see cref="ListingService"/> class, which provides access to the /v2/commerce/listings service.</summary>
        /// <returns>A new instance of the <see cref="ListingService"/> class.</returns>
        public IRepository<int, Listing> GetListingService()
        {
            return new ListingService(this.serviceClient);
        }

        /// <summary>Creates an instance of the <see cref="PriceService"/> class, which provides access to the /v2/commerce/prices service.</summary>
        /// <returns>A new instance of the <see cref="PriceService"/> class.</returns>
        public IRepository<int, AggregateListing> GetPriceService()
        {
            return new PriceService(this.serviceClient);
        }

        /// <summary>Creates an instance of the <see cref="QuagganService"/> class, which provides access to the /v2/quaggans service.</summary>
        /// <returns>A new instance of the <see cref="QuagganService"/> class.</returns>
        public IRepository<string, Quaggan> GetQuagganService()
        {
            return new QuagganService(this.serviceClient);
        }

        /// <summary>Creates an instance of the <see cref="ItemService"/> class, which provides access to the /v2/items service.</summary>
        /// <returns>A new instance of the <see cref="ItemService"/> class.</returns>
        public IRepository<int, Item> GetItemService()
        {
            return new ItemService(this.serviceClient);
        }

        /// <summary>Gets the base URI.</summary>
        /// <returns>A <see cref="Uri"/>.</returns>
        private static Uri GetBaseUri()
        {
            Contract.Ensures(Contract.Result<Uri>() != null);
            Contract.Ensures(Contract.Result<Uri>().IsAbsoluteUri);
            var baseUri = new Uri("https://api.guildwars2.com", UriKind.Absolute);
            Contract.Assume(baseUri.IsAbsoluteUri);
            return baseUri;
        }

        /// <summary>Infrastructure. Creates and configures an instance of the default service client.</summary>
        /// <returns>The <see cref="IServiceClient"/>.</returns>
        private static IServiceClient GetDefaultServiceClient()
        {
            Contract.Ensures(Contract.Result<IServiceClient>() != null);
            var baseUri = GetBaseUri();
            var serializerFactory = new DataContractJsonSerializerFactory();
            var gzipInflator = new GzipInflator();
            return new ServiceClient(baseUri, serializerFactory, serializerFactory, gzipInflator);
        }
    }
}