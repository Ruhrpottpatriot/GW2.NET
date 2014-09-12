// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PriceService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides access to the Trading Post price service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V2.Commerce
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Entities.Commerce;
    using GW2DotNET.V2.Commerce.Json;
    using GW2DotNET.V2.Common;

    /// <summary>Provides access to the Trading Post price service.</summary>
    /// <remarks>See: <a href="http://wiki.guildwars2.com/wiki/API:2/commerce/prices">wiki</a></remarks>
    public class PriceService : IRepository<int, AggregateListing>
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="PriceService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public PriceService(IServiceClient serviceClient)
        {
            Contract.Requires(serviceClient != null);
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a collection of identifiers.</summary>
        /// <returns>A collection of identifiers.</returns>
        public ICollection<int> Discover()
        {
            var request = new PriceDiscoveryRequest();
            var response = this.serviceClient.Send<ICollection<int>>(request);
            if (response.Content == null)
            {
                return new List<int>(0);
            }

            return response.Content;
        }

        /// <summary>Gets a collection of identifiers.</summary>
        /// <returns>A collection of identifiers.</returns>
        public Task<ICollection<int>> DiscoverAsync()
        {
            return this.DiscoverAsync(CancellationToken.None);
        }

        /// <summary>Gets a collection of identifiers.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of identifiers.</returns>
        public Task<ICollection<int>> DiscoverAsync(CancellationToken cancellationToken)
        {
            var request = new PriceDiscoveryRequest();
            return this.serviceClient.SendAsync<ICollection<int>>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null)
                        {
                            return new List<int>(0);
                        }

                        return response.Content;
                    }, 
                cancellationToken);
        }

        /// <summary>Finds the <see cref="AggregateListing"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>The <see cref="AggregateListing"/> with the specified identifier.</returns>
        public AggregateListing Find(int identifier)
        {
            var request = new PriceDetailsRequest { Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo) };
            var response = this.serviceClient.Send<AggregateListingDataContract>(request);
            if (response.Content == null)
            {
                return null;
            }

            var value = ConvertAggregateListingDataContract(response.Content);
            value.Timestamp = response.Date;
            return value;
        }

        /// <summary>Finds every <see cref="AggregateListing"/>.</summary>
        /// <returns>A collection of every <see cref="AggregateListing"/>.</returns>
        public IDictionaryRange<int, AggregateListing> FindAll()
        {
            var request = new PriceBulkRequest();
            var response = this.serviceClient.Send<ICollection<AggregateListingDataContract>>(request);
            if (response.Content == null)
            {
                return new DictionaryRange<int, AggregateListing>(0);
            }

            var values = ConvertAggregateListingDataContractRange(response.Content);
            foreach (var value in values.Values)
            {
                value.Timestamp = response.Date;
            }

            return values;
        }

        /// <summary>Finds every <see cref="AggregateListing"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <returns>A collection every <see cref="AggregateListing"/> with one of the specified identifiers.</returns>
        public IDictionaryRange<int, AggregateListing> FindAll(ICollection<int> identifiers)
        {
            var request = new PriceBulkRequest { Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList() };
            var response = this.serviceClient.Send<ICollection<AggregateListingDataContract>>(request);
            if (response.Content == null)
            {
                return new DictionaryRange<int, AggregateListing>(0);
            }

            var values = ConvertAggregateListingDataContractRange(response.Content);
            foreach (var value in values.Values)
            {
                value.Timestamp = response.Date;
            }

            return values;
        }

        /// <summary>Finds every <see cref="AggregateListing"/>.</summary>
        /// <returns>A collection of every <see cref="AggregateListing"/>.</returns>
        public Task<IDictionaryRange<int, AggregateListing>> FindAllAsync()
        {
            return this.FindAllAsync(CancellationToken.None);
        }

        /// <summary>Finds every <see cref="AggregateListing"/>.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of every <see cref="AggregateListing"/>.</returns>
        public Task<IDictionaryRange<int, AggregateListing>> FindAllAsync(CancellationToken cancellationToken)
        {
            var request = new PriceBulkRequest();
            return this.serviceClient.SendAsync<ICollection<AggregateListingDataContract>>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null)
                        {
                            return new DictionaryRange<int, AggregateListing>(0);
                        }

                        var values = ConvertAggregateListingDataContractRange(response.Content);
                        foreach (var value in values.Values)
                        {
                            value.Timestamp = response.Date;
                        }

                        return values;
                    }, 
                cancellationToken);
        }

        /// <summary>Finds every <see cref="AggregateListing"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <returns>A collection every <see cref="AggregateListing"/> with one of the specified identifiers.</returns>
        public Task<IDictionaryRange<int, AggregateListing>> FindAllAsync(ICollection<int> identifiers)
        {
            return this.FindAllAsync(identifiers, CancellationToken.None);
        }

        /// <summary>Finds every <see cref="AggregateListing"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection every <see cref="AggregateListing"/> with one of the specified identifiers.</returns>
        public Task<IDictionaryRange<int, AggregateListing>> FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            var request = new PriceBulkRequest { Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList() };
            return this.serviceClient.SendAsync<ICollection<AggregateListingDataContract>>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null)
                        {
                            return new DictionaryRange<int, AggregateListing>(0);
                        }

                        var values = ConvertAggregateListingDataContractRange(response.Content);
                        foreach (var value in values.Values)
                        {
                            value.Timestamp = response.Date;
                        }

                        return values;
                    }, 
                cancellationToken);
        }

        /// <summary>Finds the <see cref="AggregateListing"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>The <see cref="AggregateListing"/> with the specified identifier.</returns>
        public Task<AggregateListing> FindAsync(int identifier)
        {
            return this.FindAsync(identifier, CancellationToken.None);
        }

        /// <summary>Finds the <see cref="AggregateListing"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <see cref="AggregateListing"/> with the specified identifier.</returns>
        public Task<AggregateListing> FindAsync(int identifier, CancellationToken cancellationToken)
        {
            var request = new PriceDetailsRequest { Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo) };
            return this.serviceClient.SendAsync<AggregateListingDataContract>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null)
                        {
                            return null;
                        }

                        var value = ConvertAggregateListingDataContract(response.Content);
                        value.Timestamp = response.Date;
                        return value;
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a page with the specified page number.</summary>
        /// <param name="page">The page to get.</param>
        /// <returns>The page.</returns>
        public ICollectionPage<AggregateListing> GetPage(int page)
        {
            var request = new PricePageRequest { Page = page };
            var response = this.serviceClient.Send<ICollection<AggregateListingDataContract>>(request);
            if (response.Content == null)
            {
                return new CollectionPage<AggregateListing>(0);
            }

            var values = ConvertAggregateListingDataContractPage(response.Content);
            values.Page = page;
            values.PageSize = response.GetPageSize();
            values.PageCount = response.GetPageTotal();
            foreach (var value in values)
            {
                value.Timestamp = response.Date;
            }

            return values;
        }

        /// <summary>Gets a page with the specified page number and maximum size.</summary>
        /// <param name="page">The page to get.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <returns>The page.</returns>
        public ICollectionPage<AggregateListing> GetPage(int page, int pageSize)
        {
            var request = new PricePageRequest { Page = page, PageSize = pageSize };
            var response = this.serviceClient.Send<ICollection<AggregateListingDataContract>>(request);
            if (response.Content == null)
            {
                return new CollectionPage<AggregateListing>(0);
            }

            var values = ConvertAggregateListingDataContractPage(response.Content);
            values.Page = page;
            values.PageSize = response.GetPageSize();
            values.PageCount = response.GetPageTotal();
            foreach (var value in values)
            {
                value.Timestamp = response.Date;
            }

            return values;
        }

        /// <summary>Gets a page with the specified page number.</summary>
        /// <param name="page">The page to get.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<AggregateListing>> GetPageAsync(int page)
        {
            return this.GetPageAsync(page, CancellationToken.None);
        }

        /// <summary>Gets a page with the specified page number.</summary>
        /// <param name="page">The page to get.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<AggregateListing>> GetPageAsync(int page, CancellationToken cancellationToken)
        {
            var request = new PricePageRequest { Page = page };
            return this.serviceClient.SendAsync<ICollection<AggregateListingDataContract>>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null)
                        {
                            return new CollectionPage<AggregateListing>(0);
                        }

                        var values = ConvertAggregateListingDataContractPage(response.Content);
                        values.Page = page;
                        values.PageSize = response.GetPageSize();
                        values.PageCount = response.GetPageTotal();
                        foreach (var value in values)
                        {
                            value.Timestamp = response.Date;
                        }

                        return values;
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a page with the specified page number.</summary>
        /// <param name="page">The page to get.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<AggregateListing>> GetPageAsync(int page, int pageSize)
        {
            return this.GetPageAsync(page, pageSize, CancellationToken.None);
        }

        /// <summary>Gets a page with the specified page number.</summary>
        /// <param name="page">The page to get.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<AggregateListing>> GetPageAsync(int page, int pageSize, CancellationToken cancellationToken)
        {
            var request = new PricePageRequest { Page = page, PageSize = pageSize };
            return this.serviceClient.SendAsync<ICollection<AggregateListingDataContract>>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null)
                        {
                            return new CollectionPage<AggregateListing>(0);
                        }

                        var values = ConvertAggregateListingDataContractPage(response.Content);
                        values.Page = page;
                        values.PageSize = response.GetPageSize();
                        values.PageCount = response.GetPageTotal();
                        foreach (var value in values)
                        {
                            value.Timestamp = response.Date;
                        }

                        return values;
                    }, 
                cancellationToken);
        }

        /// <summary>Infrastructure. Converts data contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The entity.</returns>
        private static AggregateListing ConvertAggregateListingDataContract(AggregateListingDataContract content)
        {
            return new AggregateListing
                {
                    ItemId = content.Id, 
                    BuyOffers = ConvertAggregateOfferDataContract(content.BuyOffers), 
                    SellOffers = ConvertAggregateOfferDataContract(content.SellOffers)
                };
        }

        /// <summary>Infrastructure. Converts data contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The entity.</returns>
        private static ICollectionPage<AggregateListing> ConvertAggregateListingDataContractPage(ICollection<AggregateListingDataContract> content)
        {
            var values = new CollectionPage<AggregateListing>(content.Count);
            values.AddRange(content.Select(ConvertAggregateListingDataContract));
            return values;
        }

        /// <summary>Infrastructure. Converts data contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The entity.</returns>
        private static IDictionaryRange<int, AggregateListing> ConvertAggregateListingDataContractRange(ICollection<AggregateListingDataContract> content)
        {
            var values = new DictionaryRange<int, AggregateListing>(content.Count);
            foreach (var value in content.Select(ConvertAggregateListingDataContract))
            {
                values.Add(value.ItemId, value);
            }

            return values;
        }

        /// <summary>Infrastructure. Converts data contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The entity.</returns>
        private static AggregateOffer ConvertAggregateOfferDataContract(AggregateOfferDataContract content)
        {
            return new AggregateOffer { Quantity = content.Quantity, UnitPrice = content.UnitPrice };
        }
    }
}