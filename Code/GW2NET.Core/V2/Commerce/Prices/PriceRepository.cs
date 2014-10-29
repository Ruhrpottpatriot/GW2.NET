// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PriceRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v2/commerce/prices interface. See the remarks section for important limitations regarding this implementation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Commerce.Prices
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Entities.Commerce;
    using GW2NET.Entities.Items;
    using GW2NET.V2.Commerce.Prices.Json;
    using GW2NET.V2.Common;

    /// <summary>Represents a repository that retrieves data from the /v2/commerce/prices interface. See the remarks section for important limitations regarding this implementation.</summary>
    /// <remarks>
    /// This implementation does not retrieve associated entities.
    /// <list type="bullet">
    ///     <item>
    ///         <term><see cref="AggregateListing.Item"/>:</term>
    ///         <description>Always <c>null</c>. Use the value of <see cref="AggregateListing.ItemId"/> to retrieve the <see cref="Item"/>.</description>
    ///     </item>
    /// </list>
    /// </remarks>
    public class PriceRepository : IRepository<int, AggregateListing>
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="PriceRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public PriceRepository(IServiceClient serviceClient)
        {
            Contract.Requires(serviceClient != null);
            this.serviceClient = serviceClient;
        }

        /// <inheritdoc />
        ICollection<int> IDiscoverable<int>.Discover()
        {
            var request = new PriceDiscoveryRequest();
            var response = this.serviceClient.Send<ICollection<int>>(request);
            if (response.Content == null)
            {
                return new List<int>(0);
            }

            return response.Content;
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync()
        {
            return ((IRepository<int, AggregateListing>)this).DiscoverAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync(CancellationToken cancellationToken)
        {
            var request = new PriceDiscoveryRequest();
            return this.serviceClient.SendAsync<ICollection<int>>(request, cancellationToken).ContinueWith(task =>
            {
                var response = task.Result;
                if (response.Content == null)
                {
                    return new List<int>(0);
                }

                return response.Content;
            }, cancellationToken);
        }

        /// <inheritdoc />
        AggregateListing IRepository<int, AggregateListing>.Find(int identifier)
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

        /// <inheritdoc />
        IDictionaryRange<int, AggregateListing> IRepository<int, AggregateListing>.FindAll()
        {
            var request = new PriceBulkRequest();
            var response = this.serviceClient.Send<ICollection<AggregateListingDataContract>>(request);
            if (response.Content == null)
            {
                return new DictionaryRange<int, AggregateListing>(0);
            }

            var values = ConvertAggregateListingDataContractRange(response.Content);
            values.SubtotalCount = response.GetResultCount();
            values.TotalCount = response.GetResultTotal();
            foreach (var value in values.Values)
            {
                value.Timestamp = response.Date;
            }

            return values;
        }

        /// <inheritdoc />
        IDictionaryRange<int, AggregateListing> IRepository<int, AggregateListing>.FindAll(ICollection<int> identifiers)
        {
            if (identifiers == null)
            {
                throw new ArgumentNullException("identifiers", "Precondition failed: identifiers != null");
            }

            if (identifiers.Count == 0)
            {
                throw new ArgumentOutOfRangeException("identifiers", "Precondition failed: identifiers.Count > 0");
            }

            Contract.EndContractBlock();

            var request = new PriceBulkRequest { Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList() };
            var response = this.serviceClient.Send<ICollection<AggregateListingDataContract>>(request);
            if (response.Content == null)
            {
                return new DictionaryRange<int, AggregateListing>(0);
            }

            var values = ConvertAggregateListingDataContractRange(response.Content);
            values.SubtotalCount = response.GetResultCount();
            values.TotalCount = response.GetResultTotal();
            foreach (var value in values.Values)
            {
                value.Timestamp = response.Date;
            }

            return values;
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, AggregateListing>> IRepository<int, AggregateListing>.FindAllAsync()
        {
            return ((IRepository<int, AggregateListing>)this).FindAllAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, AggregateListing>> IRepository<int, AggregateListing>.FindAllAsync(CancellationToken cancellationToken)
        {
            var request = new PriceBulkRequest();
            return this.serviceClient.SendAsync<ICollection<AggregateListingDataContract>>(request, cancellationToken).ContinueWith(task =>
            {
                var response = task.Result;
                if (response.Content == null)
                {
                    return new DictionaryRange<int, AggregateListing>(0);
                }

                var values = ConvertAggregateListingDataContractRange(response.Content);
                values.SubtotalCount = response.GetResultCount();
                values.TotalCount = response.GetResultTotal();
                foreach (var value in values.Values)
                {
                    value.Timestamp = response.Date;
                }

                return values;
            }, cancellationToken);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, AggregateListing>> IRepository<int, AggregateListing>.FindAllAsync(ICollection<int> identifiers)
        {
            return ((IRepository<int, AggregateListing>)this).FindAllAsync(identifiers, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, AggregateListing>> IRepository<int, AggregateListing>.FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            if (identifiers == null)
            {
                throw new ArgumentNullException("identifiers", "Precondition failed: identifiers != null");
            }

            if (identifiers.Count == 0)
            {
                throw new ArgumentOutOfRangeException("identifiers", "Precondition failed: identifiers.Count > 0");
            }

            Contract.EndContractBlock();

            var request = new PriceBulkRequest { Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList() };
            return this.serviceClient.SendAsync<ICollection<AggregateListingDataContract>>(request, cancellationToken).ContinueWith(task =>
            {
                var response = task.Result;
                if (response.Content == null)
                {
                    return new DictionaryRange<int, AggregateListing>(0);
                }

                var values = ConvertAggregateListingDataContractRange(response.Content);
                values.SubtotalCount = response.GetResultCount();
                values.TotalCount = response.GetResultTotal();
                foreach (var value in values.Values)
                {
                    value.Timestamp = response.Date;
                }

                return values;
            }, cancellationToken);
        }

        /// <inheritdoc />
        Task<AggregateListing> IRepository<int, AggregateListing>.FindAsync(int identifier)
        {
            return ((IRepository<int, AggregateListing>)this).FindAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<AggregateListing> IRepository<int, AggregateListing>.FindAsync(int identifier, CancellationToken cancellationToken)
        {
            var request = new PriceDetailsRequest { Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo) };
            return this.serviceClient.SendAsync<AggregateListingDataContract>(request, cancellationToken).ContinueWith(task =>
            {
                var response = task.Result;
                if (response.Content == null)
                {
                    return null;
                }

                var value = ConvertAggregateListingDataContract(response.Content);
                value.Timestamp = response.Date;
                return value;
            }, cancellationToken);
        }

        /// <inheritdoc />
        ICollectionPage<AggregateListing> IPaginator<AggregateListing>.FindPage(int pageIndex)
        {
            var request = new PricePageRequest { Page = pageIndex };
            var response = this.serviceClient.Send<ICollection<AggregateListingDataContract>>(request);
            if (response.Content == null)
            {
                return new CollectionPage<AggregateListing>(0);
            }

            var values = ConvertAggregateListingDataContractPage(response.Content);
            values.PageIndex = pageIndex;
            values.PageSize = response.GetPageSize();
            values.PageCount = response.GetPageTotal();
            values.SubtotalCount = response.GetResultCount();
            values.TotalCount = response.GetResultTotal();
            if (values.PageCount > 0)
            {
                values.LastPageIndex = values.PageCount - 1;
                if (values.PageIndex < values.LastPageIndex)
                {
                    values.NextPageIndex = values.PageIndex + 1;
                }

                if (values.PageIndex > values.FirstPageIndex)
                {
                    values.PreviousPageIndex = values.PageIndex - 1;
                }
            }

            foreach (var value in values)
            {
                value.Timestamp = response.Date;
            }

            return values;
        }

        /// <inheritdoc />
        ICollectionPage<AggregateListing> IPaginator<AggregateListing>.FindPage(int pageIndex, int pageSize)
        {
            var request = new PricePageRequest { Page = pageIndex, PageSize = pageSize };
            var response = this.serviceClient.Send<ICollection<AggregateListingDataContract>>(request);
            if (response.Content == null)
            {
                return new CollectionPage<AggregateListing>(0);
            }

            var values = ConvertAggregateListingDataContractPage(response.Content);
            values.PageIndex = pageIndex;
            values.PageSize = response.GetPageSize();
            values.PageCount = response.GetPageTotal();
            values.SubtotalCount = response.GetResultCount();
            values.TotalCount = response.GetResultTotal();
            if (values.PageCount > 0)
            {
                values.LastPageIndex = values.PageCount - 1;
                if (values.PageIndex < values.LastPageIndex)
                {
                    values.NextPageIndex = values.PageIndex + 1;
                }

                if (values.PageIndex > values.FirstPageIndex)
                {
                    values.PreviousPageIndex = values.PageIndex - 1;
                }
            }

            foreach (var value in values)
            {
                value.Timestamp = response.Date;
            }

            return values;
        }

        /// <inheritdoc />
        Task<ICollectionPage<AggregateListing>> IPaginator<AggregateListing>.FindPageAsync(int pageIndex)
        {
            return ((IRepository<int, AggregateListing>)this).FindPageAsync(pageIndex, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollectionPage<AggregateListing>> IPaginator<AggregateListing>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            var request = new PricePageRequest { Page = pageIndex };
            return this.serviceClient.SendAsync<ICollection<AggregateListingDataContract>>(request, cancellationToken).ContinueWith(task =>
            {
                var response = task.Result;
                if (response.Content == null)
                {
                    return new CollectionPage<AggregateListing>(0);
                }

                var values = ConvertAggregateListingDataContractPage(response.Content);
                values.PageIndex = pageIndex;
                values.PageSize = response.GetPageSize();
                values.PageCount = response.GetPageTotal();
                values.SubtotalCount = response.GetResultCount();
                values.TotalCount = response.GetResultTotal();
                if (values.PageCount > 0)
                {
                    values.LastPageIndex = values.PageCount - 1;
                    if (values.PageIndex < values.LastPageIndex)
                    {
                        values.NextPageIndex = values.PageIndex + 1;
                    }

                    if (values.PageIndex > values.FirstPageIndex)
                    {
                        values.PreviousPageIndex = values.PageIndex - 1;
                    }
                }

                foreach (var value in values)
                {
                    value.Timestamp = response.Date;
                }

                return values;
            }, cancellationToken);
        }

        /// <inheritdoc />
        Task<ICollectionPage<AggregateListing>> IPaginator<AggregateListing>.FindPageAsync(int pageIndex, int pageSize)
        {
            return ((IRepository<int, AggregateListing>)this).FindPageAsync(pageIndex, pageSize, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollectionPage<AggregateListing>> IPaginator<AggregateListing>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            var request = new PricePageRequest { Page = pageIndex, PageSize = pageSize };
            return this.serviceClient.SendAsync<ICollection<AggregateListingDataContract>>(request, cancellationToken).ContinueWith(task =>
            {
                var response = task.Result;
                if (response.Content == null)
                {
                    return new CollectionPage<AggregateListing>(0);
                }

                var values = ConvertAggregateListingDataContractPage(response.Content);
                values.PageIndex = pageIndex;
                values.PageSize = response.GetPageSize();
                values.PageCount = response.GetPageTotal();
                values.SubtotalCount = response.GetResultCount();
                values.TotalCount = response.GetResultTotal();
                if (values.PageCount > 0)
                {
                    values.LastPageIndex = values.PageCount - 1;
                    if (values.PageIndex < values.LastPageIndex)
                    {
                        values.NextPageIndex = values.PageIndex + 1;
                    }

                    if (values.PageIndex > values.FirstPageIndex)
                    {
                        values.PreviousPageIndex = values.PageIndex - 1;
                    }
                }

                foreach (var value in values)
                {
                    value.Timestamp = response.Date;
                }

                return values;
            }, cancellationToken);
        }

        // TODO: refactor to IConverter
        /// <summary>Infrastructure. Converts data contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The entity.</returns>
        private static AggregateListing ConvertAggregateListingDataContract(AggregateListingDataContract content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<AggregateListing>() != null);
            var value = new AggregateListing { ItemId = content.Id };
            if (content.BuyOffers != null)
            {
                value.BuyOffers = ConvertAggregateOfferDataContract(content.BuyOffers);
            }
            else
            {
                Debug.WriteLine("Expected 'buys' for listing with ID {0}", content.Id);
            }

            if (content.SellOffers != null)
            {
                value.SellOffers = ConvertAggregateOfferDataContract(content.SellOffers);
            }
            else
            {
                Debug.WriteLine("Expected 'sells' for listing with ID {0}", content.Id);
            }

            return value;
        }

        // TODO: refactor to IConverter
        /// <summary>Infrastructure. Converts data contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The entity.</returns>
        private static ICollectionPage<AggregateListing> ConvertAggregateListingDataContractPage(ICollection<AggregateListingDataContract> content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<ICollectionPage<AggregateListing>>() != null);
            var values = new CollectionPage<AggregateListing>(content.Count);
            values.AddRange(content.Select(ConvertAggregateListingDataContract));
            return values;
        }

        // TODO: refactor to IConverter
        /// <summary>Infrastructure. Converts data contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The entity.</returns>
        private static IDictionaryRange<int, AggregateListing> ConvertAggregateListingDataContractRange(ICollection<AggregateListingDataContract> content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<IDictionaryRange<int, AggregateListing>>() != null);
            var values = new DictionaryRange<int, AggregateListing>(content.Count);
            foreach (var value in content.Select(ConvertAggregateListingDataContract))
            {
                values.Add(value.ItemId, value);
            }

            return values;
        }

        // TODO: refactor to IConverter
        /// <summary>Infrastructure. Converts data contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The entity.</returns>
        private static AggregateOffer ConvertAggregateOfferDataContract(AggregateOfferDataContract content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<AggregateOffer>() != null);
            return new AggregateOffer { Quantity = content.Quantity, UnitPrice = content.UnitPrice };
        }
    }
}