// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ListingService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides access to the listing service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V2.Commerce
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Entities.Commerce;
    using GW2DotNET.Entities.Items;
    using GW2DotNET.V2.Commerce.Json;
    using GW2DotNET.V2.Common;

    /// <summary>Provides access to the /v2/commerce/listings service. See the class remarks for important limitations regarding the default implementation.</summary>
    /// <remarks>
    /// This implementation does not retrieve associated entities.
    /// <list type="bullet">
    ///     <item>
    ///         <term><see cref="Listing.Item"/>:</term>
    ///         <description>Always <c>null</c>. Use the value of <see cref="Listing.ItemId"/> to retrieve the <see cref="Item"/>.</description>
    ///     </item>
    /// </list>
    /// See: <a href="http://wiki.guildwars2.com/wiki/API:2/commerce/listings">wiki</a>
    /// </remarks>
    public class ListingService : IRepository<int, Listing>
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="ListingService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public ListingService(IServiceClient serviceClient)
        {
            Contract.Requires(serviceClient != null);
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a collection of identifiers.</summary>
        /// <returns>A collection of identifiers.</returns>
        public ICollection<int> Discover()
        {
            var request = new ListingDiscoveryRequest();
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
            var request = new ListingDiscoveryRequest();
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

        /// <summary>Finds the <see cref="Listing"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>The <see cref="Listing"/> with the specified identifier.</returns>
        public Listing Find(int identifier)
        {
            var request = new ListingDetailsRequest { Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo) };
            var response = this.serviceClient.Send<ListingDataContract>(request);
            if (response.Content == null)
            {
                return null;
            }

            var value = ConvertListingDataContract(response.Content);
            value.Timestamp = response.Date;
            return value;
        }

        /// <summary>Finds every <see cref="Listing"/>.</summary>
        /// <returns>A collection of every <see cref="Listing"/>.</returns>
        public IDictionaryRange<int, Listing> FindAll()
        {
            var request = new ListingBulkRequest();
            var response = this.serviceClient.Send<ICollection<ListingDataContract>>(request);
            if (response.Content == null)
            {
                return new DictionaryRange<int, Listing>(0);
            }

            var values = ConvertListingDataContractRange(response.Content);
            values.SubtotalCount = response.GetResultCount();
            values.TotalCount = response.GetResultTotal();
            foreach (var value in values.Values)
            {
                value.Timestamp = response.Date;
            }

            return values;
        }

        /// <summary>Finds every <see cref="Listing"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <returns>A collection every <see cref="Listing"/> with one of the specified identifiers.</returns>
        public IDictionaryRange<int, Listing> FindAll(ICollection<int> identifiers)
        {
            var request = new ListingBulkRequest { Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList() };
            var response = this.serviceClient.Send<ICollection<ListingDataContract>>(request);
            if (response.Content == null)
            {
                return new DictionaryRange<int, Listing>(0);
            }

            var values = ConvertListingDataContractRange(response.Content);
            values.SubtotalCount = response.GetResultCount();
            values.TotalCount = response.GetResultTotal();
            foreach (var value in values.Values)
            {
                value.Timestamp = response.Date;
            }

            return values;
        }

        /// <summary>Finds every <see cref="Listing"/>.</summary>
        /// <returns>A collection of every <see cref="Listing"/>.</returns>
        public Task<IDictionaryRange<int, Listing>> FindAllAsync()
        {
            return this.FindAllAsync(CancellationToken.None);
        }

        /// <summary>Finds every <see cref="Listing"/>.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of every <see cref="Listing"/>.</returns>
        public Task<IDictionaryRange<int, Listing>> FindAllAsync(CancellationToken cancellationToken)
        {
            var request = new ListingBulkRequest();
            return this.serviceClient.SendAsync<ICollection<ListingDataContract>>(request, cancellationToken).ContinueWith(
                task =>
                {
                    var response = task.Result;
                    if (response.Content == null)
                    {
                        return new DictionaryRange<int, Listing>(0);
                    }

                    var values = ConvertListingDataContractRange(response.Content);
                    values.SubtotalCount = response.GetResultCount();
                    values.TotalCount = response.GetResultTotal();
                    foreach (var value in values.Values)
                    {
                        value.Timestamp = response.Date;
                    }

                    return values;
                },
                cancellationToken);
        }

        /// <summary>Finds every <see cref="Listing"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <returns>A collection every <see cref="Listing"/> with one of the specified identifiers.</returns>
        public Task<IDictionaryRange<int, Listing>> FindAllAsync(ICollection<int> identifiers)
        {
            return this.FindAllAsync(identifiers, CancellationToken.None);
        }

        /// <summary>Finds every <see cref="Listing"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection every <see cref="Listing"/> with one of the specified identifiers.</returns>
        public Task<IDictionaryRange<int, Listing>> FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            var request = new ListingBulkRequest() { Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList() };
            return this.serviceClient.SendAsync<ICollection<ListingDataContract>>(request, cancellationToken).ContinueWith(
                task =>
                {
                    var response = task.Result;
                    if (response.Content == null)
                    {
                        return new DictionaryRange<int, Listing>(0);
                    }

                    var values = ConvertListingDataContractRange(response.Content);
                    values.SubtotalCount = response.GetResultCount();
                    values.TotalCount = response.GetResultTotal();
                    foreach (var value in values.Values)
                    {
                        value.Timestamp = response.Date;
                    }

                    return values;
                },
                cancellationToken);
        }

        /// <summary>Finds the <see cref="Listing"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>The <see cref="Listing"/> with the specified identifier.</returns>
        public Task<Listing> FindAsync(int identifier)
        {
            return this.FindAsync(identifier, CancellationToken.None);
        }

        /// <summary>Finds the <see cref="Listing"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <see cref="Listing"/> with the specified identifier.</returns>
        public Task<Listing> FindAsync(int identifier, CancellationToken cancellationToken)
        {
            var request = new ListingDetailsRequest { Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo) };
            return this.serviceClient.SendAsync<ListingDataContract>(request, cancellationToken).ContinueWith(
                task =>
                {
                    var response = task.Result;
                    if (response.Content == null)
                    {
                        return null;
                    }

                    var value = ConvertListingDataContract(response.Content);
                    value.Timestamp = response.Date;
                    return value;
                },
                cancellationToken);
        }

        /// <summary>Gets a page with the specified page number.</summary>
        /// <param name="page">The page to get.</param>
        /// <returns>The page.</returns>
        public ICollectionPage<Listing> GetPage(int page)
        {
            var request = new ListingPageRequest { Page = page };
            var response = this.serviceClient.Send<ICollection<ListingDataContract>>(request);
            if (response == null)
            {
                return new CollectionPage<Listing>(0);
            }

            var values = ConvertListingDataContractPage(response.Content);
            values.Page = page;
            values.PageSize = response.GetPageSize();
            values.PageCount = response.GetPageTotal();
            values.SubtotalCount = response.GetResultCount();
            values.TotalCount = response.GetResultTotal();
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
        public ICollectionPage<Listing> GetPage(int page, int pageSize)
        {
            var request = new ListingPageRequest { Page = page, PageSize = pageSize };
            var response = this.serviceClient.Send<ICollection<ListingDataContract>>(request);
            if (response == null)
            {
                return new CollectionPage<Listing>(0);
            }

            var values = ConvertListingDataContractPage(response.Content);
            values.Page = page;
            values.PageSize = response.GetPageSize();
            values.PageCount = response.GetPageTotal();
            values.SubtotalCount = response.GetResultCount();
            values.TotalCount = response.GetResultTotal();
            foreach (var value in values)
            {
                value.Timestamp = response.Date;
            }

            return values;
        }

        /// <summary>Gets a page with the specified page number.</summary>
        /// <param name="page">The page to get.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<Listing>> GetPageAsync(int page)
        {
            return this.GetPageAsync(page, CancellationToken.None);
        }

        /// <summary>Gets a page with the specified page number.</summary>
        /// <param name="page">The page to get.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<Listing>> GetPageAsync(int page, CancellationToken cancellationToken)
        {
            var request = new ListingPageRequest { Page = page };
            return this.serviceClient.SendAsync<ICollection<ListingDataContract>>(request, cancellationToken).ContinueWith(
                task =>
                {
                    var response = task.Result;
                    if (response == null)
                    {
                        return new CollectionPage<Listing>(0);
                    }

                    var values = ConvertListingDataContractPage(response.Content);
                    values.Page = page;
                    values.PageSize = response.GetPageSize();
                    values.PageCount = response.GetPageTotal();
                    values.SubtotalCount = response.GetResultCount();
                    values.TotalCount = response.GetResultTotal();
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
        public Task<ICollectionPage<Listing>> GetPageAsync(int page, int pageSize)
        {
            return this.GetPageAsync(page, pageSize, CancellationToken.None);
        }

        /// <summary>Gets a page with the specified page number.</summary>
        /// <param name="page">The page to get.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<Listing>> GetPageAsync(int page, int pageSize, CancellationToken cancellationToken)
        {
            var request = new ListingPageRequest { Page = page, PageSize = pageSize };
            return this.serviceClient.SendAsync<ICollection<ListingDataContract>>(request, cancellationToken).ContinueWith(
                task =>
                {
                    var response = task.Result;
                    if (response == null)
                    {
                        return new CollectionPage<Listing>(0);
                    }

                    var values = ConvertListingDataContractPage(response.Content);
                    values.Page = page;
                    values.PageSize = response.GetPageSize();
                    values.PageCount = response.GetPageTotal();
                    values.SubtotalCount = response.GetResultCount();
                    values.TotalCount = response.GetResultTotal();
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
        private static Listing ConvertListingDataContract(ListingDataContract content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<Listing>() != null);
            var value = new Listing { ItemId = content.Id };

            if (content.BuyOffers != null)
            {
                value.BuyOffers = ConvertOfferDataContractCollection(content.BuyOffers);
            }
            else
            {
                Debug.WriteLine("Expected 'buys' for listing with ID {0}", content.Id);
            }

            if (content.SellOffers != null)
            {
                value.SellOffers = ConvertOfferDataContractCollection(content.SellOffers);
            }
            else
            {
                Debug.WriteLine("Expected 'sells' for listing with ID {0}", content.Id);
            }

            return value;
        }

        /// <summary>Infrastructure. Converts data contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The entity.</returns>
        private static Offer ConvertOfferDataContract(OfferDataContract content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<Offer>() != null);
            return new Offer { Listings = content.Listings, UnitPrice = content.UnitPrice, Quantity = content.Quantity };
        }

        /// <summary>Infrastructure. Converts data contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The entity.</returns>
        private static ICollection<Offer> ConvertOfferDataContractCollection(ICollection<OfferDataContract> content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<ICollection<Offer>>() != null);
            var values = new List<Offer>(content.Count);
            values.AddRange(content.Select(ConvertOfferDataContract));
            return values;
        }

        /// <summary>Infrastructure. Converts data contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The entity.</returns>
        private static IDictionaryRange<int, Listing> ConvertListingDataContractRange(ICollection<ListingDataContract> content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<IDictionaryRange<int, Listing>>() != null);
            var values = new DictionaryRange<int, Listing>(content.Count);
            foreach (var contract in content)
            {
                var value = ConvertListingDataContract(contract);
                values.Add(value.ItemId, value);
            }

            return values;
        }

        /// <summary>Infrastructure. Converts data contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The entity.</returns>
        private static ICollectionPage<Listing> ConvertListingDataContractPage(ICollection<ListingDataContract> content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<IDictionaryRange<int, Listing>>() != null);
            var values = new CollectionPage<Listing>(content.Count);
            values.AddRange(content.Select(ConvertListingDataContract));
            return values;
        }
    }
}