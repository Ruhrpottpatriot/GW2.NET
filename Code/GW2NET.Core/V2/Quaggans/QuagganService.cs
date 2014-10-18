// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuagganService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the Quaggan service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Quaggans
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Entities.Quaggans;
    using GW2NET.V2.Common;
    using GW2NET.V2.Quaggans.Json;

    /// <summary>Provides the default implementation of the Quaggan service.</summary>
    public class QuagganService : IRepository<string, Quaggan>
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="QuagganService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public QuagganService(IServiceClient serviceClient)
        {
            Contract.Requires(serviceClient != null);
            Contract.Ensures(this.serviceClient != null);
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a collection of identifiers.</summary>
        /// <returns>A collection of identifiers.</returns>
        public ICollection<string> Discover()
        {
            var request = new QuagganDiscoveryRequest();
            var response = this.serviceClient.Send<ICollection<string>>(request);
            if (response.Content == null)
            {
                return new string[0];
            }

            return response.Content;
        }

        /// <summary>Gets a collection of identifiers.</summary>
        /// <returns>A collection of identifiers.</returns>
        public Task<ICollection<string>> DiscoverAsync()
        {
            return this.DiscoverAsync(CancellationToken.None);
        }

        /// <summary>Gets a collection of identifiers.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of identifiers.</returns>
        public Task<ICollection<string>> DiscoverAsync(CancellationToken cancellationToken)
        {
            var request = new QuagganDiscoveryRequest();
            return this.serviceClient.SendAsync<ICollection<string>>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null)
                        {
                            return new string[0];
                        }

                        return response.Content;
                    }, 
                cancellationToken);
        }

        /// <summary>Finds the <see cref="Quaggan"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>The <see cref="Quaggan"/> with the specified identifier.</returns>
        public Quaggan Find(string identifier)
        {
            var request = new QuagganDetailsRequest { Identifier = identifier };
            var response = this.serviceClient.Send<QuagganDataContract>(request);
            if (response.Content == null)
            {
                return null;
            }

            return ConvertQuagganDataContract(response.Content);
        }

        /// <summary>Finds every <see cref="Quaggan"/>.</summary>
        /// <returns>A collection of every <see cref="Quaggan"/>.</returns>
        public IDictionaryRange<string, Quaggan> FindAll()
        {
            var request = new QuagganBulkRequest();
            var response = this.serviceClient.Send<ICollection<QuagganDataContract>>(request);
            if (response.Content == null)
            {
                return new DictionaryRange<string, Quaggan>(0);
            }

            // Get the number of values in this subset
            var pageCount = response.GetResultCount();

            // Get the number of values in the collection
            var totalCount = response.GetResultTotal();

            // Convert the return values to entities
            return ConvertQuagganDataContractCollection(response.Content, pageCount, totalCount);
        }

        /// <summary>Finds every <see cref="Quaggan"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <returns>A collection every <see cref="Quaggan"/> with one of the specified identifiers.</returns>
        public IDictionaryRange<string, Quaggan> FindAll(ICollection<string> identifiers)
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

            var request = new QuagganBulkRequest { Identifiers = identifiers.ToList() };
            var response = this.serviceClient.Send<ICollection<QuagganDataContract>>(request);
            if (response.Content == null)
            {
                return new DictionaryRange<string, Quaggan>(0);
            }

            // Get the number of values in this subset
            var pageCount = response.GetResultCount();

            // Get the number of values in the collection
            var totalCount = response.GetResultTotal();

            // Convert the return values to entities
            return ConvertQuagganDataContractCollection(response.Content, pageCount, totalCount);
        }

        /// <summary>Finds every <see cref="Quaggan"/>.</summary>
        /// <returns>A collection of every <see cref="Quaggan"/>.</returns>
        public Task<IDictionaryRange<string, Quaggan>> FindAllAsync()
        {
            return this.FindAllAsync(CancellationToken.None);
        }

        /// <summary>Finds every <see cref="Quaggan"/>.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of every <see cref="Quaggan"/>.</returns>
        public Task<IDictionaryRange<string, Quaggan>> FindAllAsync(CancellationToken cancellationToken)
        {
            var request = new QuagganBulkRequest();
            return this.serviceClient.SendAsync<ICollection<QuagganDataContract>>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null)
                        {
                            return new DictionaryRange<string, Quaggan>(0);
                        }

                        // Get the number of values in this subset
                        var pageCount = response.GetResultCount();

                        // Get the number of values in the collection
                        var totalCount = response.GetResultTotal();

                        // Convert the return values to entities
                        return ConvertQuagganDataContractCollection(response.Content, pageCount, totalCount);
                    }, 
                cancellationToken);
        }

        /// <summary>Finds every <see cref="Quaggan"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <returns>A collection every <see cref="Quaggan"/> with one of the specified identifiers.</returns>
        public Task<IDictionaryRange<string, Quaggan>> FindAllAsync(ICollection<string> identifiers)
        {
            return this.FindAllAsync(identifiers, CancellationToken.None);
        }

        /// <summary>Finds every <see cref="Quaggan"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection every <see cref="Quaggan"/> with one of the specified identifiers.</returns>
        public Task<IDictionaryRange<string, Quaggan>> FindAllAsync(ICollection<string> identifiers, CancellationToken cancellationToken)
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

            var request = new QuagganBulkRequest { Identifiers = identifiers.ToList() };
            return this.serviceClient.SendAsync<ICollection<QuagganDataContract>>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null)
                        {
                            return new DictionaryRange<string, Quaggan>(0);
                        }

                        // Get the number of values in this subset
                        var pageCount = response.GetResultCount();

                        // Get the number of values in the collection
                        var totalCount = response.GetResultTotal();

                        // Convert the return values to entities
                        return ConvertQuagganDataContractCollection(response.Content, pageCount, totalCount);
                    }, 
                cancellationToken);
        }

        /// <summary>Finds the <see cref="Quaggan"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>The <see cref="Quaggan"/> with the specified identifier.</returns>
        public Task<Quaggan> FindAsync(string identifier)
        {
            return this.FindAsync(identifier, CancellationToken.None);
        }

        /// <summary>Finds the <see cref="Quaggan"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <see cref="Quaggan"/> with the specified identifier.</returns>
        public Task<Quaggan> FindAsync(string identifier, CancellationToken cancellationToken)
        {
            var request = new QuagganDetailsRequest { Identifier = identifier };
            return this.serviceClient.SendAsync<QuagganDataContract>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null)
                        {
                            return null;
                        }

                        return ConvertQuagganDataContract(response.Content);
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a page with the specified page number.</summary>
        /// <param name="page">The page to get.</param>
        /// <returns>The page.</returns>
        public ICollectionPage<Quaggan> GetPage(int page)
        {
            var request = new QuagganPageRequest { Page = page };
            var response = this.serviceClient.Send<ICollection<QuagganDataContract>>(request);
            if (response.Content == null)
            {
                return new CollectionPage<Quaggan>(0);
            }

            // Get the number of values in this subset
            var pageCount = response.GetResultCount();

            // Get the number of values in the collection
            var totalCount = response.GetResultTotal();

            // Get the maximum number of values in this subset
            var pageSize = response.GetPageSize();

            // Get the number of subsets in the collection
            var pageTotal = response.GetPageTotal();

            // Convert the return values to entities
            return ConvertQuagganDataContractCollection(response.Content, pageCount, totalCount, page, pageSize, pageTotal);
        }

        /// <summary>Gets a page with the specified page number and maximum size.</summary>
        /// <param name="page">The page to get.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <returns>The page.</returns>
        public ICollectionPage<Quaggan> GetPage(int page, int pageSize)
        {
            var request = new QuagganPageRequest { Page = page, PageSize = pageSize };
            var response = this.serviceClient.Send<ICollection<QuagganDataContract>>(request);
            if (response.Content == null)
            {
                return new CollectionPage<Quaggan>(0);
            }

            // Get the number of values in this subset
            var pageCount = response.GetResultCount();

            // Get the number of values in the collection
            var totalCount = response.GetResultTotal();

            // Get the maximum number of values in this subset
            var size = response.GetPageSize();

            // Get the number of subsets in the collection
            var pageTotal = response.GetPageTotal();

            // Convert the return values to entities
            return ConvertQuagganDataContractCollection(response.Content, pageCount, totalCount, page, size, pageTotal);
        }

        /// <summary>Gets a page with the specified page number.</summary>
        /// <param name="page">The page to get.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<Quaggan>> GetPageAsync(int page)
        {
            return this.GetPageAsync(page, CancellationToken.None);
        }

        /// <summary>Gets a page with the specified page number.</summary>
        /// <param name="page">The page to get.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<Quaggan>> GetPageAsync(int page, CancellationToken cancellationToken)
        {
            var request = new QuagganPageRequest { Page = page };
            return this.serviceClient.SendAsync<ICollection<QuagganDataContract>>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null)
                        {
                            return new CollectionPage<Quaggan>(0);
                        }

                        // Get the number of values in this subset
                        var pageCount = response.GetResultCount();

                        // Get the number of values in the collection
                        var totalCount = response.GetResultTotal();

                        // Get the maximum number of values in this subset
                        var pageSize = response.GetPageSize();

                        // Get the number of subsets in the collection
                        var pageTotal = response.GetPageTotal();

                        // Convert the return values to entities
                        return ConvertQuagganDataContractCollection(response.Content, pageCount, totalCount, page, pageSize, pageTotal);
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a page with the specified page number.</summary>
        /// <param name="page">The page to get.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<Quaggan>> GetPageAsync(int page, int pageSize)
        {
            return this.GetPageAsync(page, pageSize, CancellationToken.None);
        }

        /// <summary>Gets a page with the specified page number.</summary>
        /// <param name="page">The page to get.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<Quaggan>> GetPageAsync(int page, int pageSize, CancellationToken cancellationToken)
        {
            var request = new QuagganPageRequest { Page = page, PageSize = pageSize };
            return this.serviceClient.SendAsync<ICollection<QuagganDataContract>>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null)
                        {
                            return new CollectionPage<Quaggan>(0);
                        }

                        // Get the number of values in this subset
                        var pageCount = response.GetResultCount();

                        // Get the number of values in the collection
                        var totalCount = response.GetResultTotal();

                        // Get the maximum number of values in this subset
                        var size = response.GetPageSize();

                        // Get the number of subsets in the collection
                        var pageTotal = response.GetPageTotal();

                        // Convert the return values to entities
                        return ConvertQuagganDataContractCollection(response.Content, pageCount, totalCount, page, size, pageTotal);
                    }, 
                cancellationToken);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private static Quaggan ConvertQuagganDataContract(QuagganDataContract content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<Quaggan>() != null);

            // Create a new Quaggan object
            var value = new Quaggan();

            // Set the Quaggan identifier
            if (content.Id != null)
            {
                value.Id = content.Id;
            }

            // Set the resource location
            if (content.Url != null)
            {
                value.Url = new Uri(content.Url, UriKind.Absolute);
            }

            // Return the Quaggan object
            return value;
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private static IDictionaryRange<string, Quaggan> ConvertQuagganDataContractCollection(IEnumerable<QuagganDataContract> content, int subtotalCount, int totalCount)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<IDictionary<string, Quaggan>>() != null);
            var values = new DictionaryRange<string, Quaggan>(subtotalCount) { SubtotalCount = subtotalCount, TotalCount = totalCount };
            foreach (var value in content.Select(ConvertQuagganDataContract))
            {
                Contract.Assume(value != null);
                values.Add(value.Id, value);
            }

            return values;
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private static ICollectionPage<Quaggan> ConvertQuagganDataContractCollection(
            ICollection<QuagganDataContract> content, 
            int subtotalCount, 
            int totalCount, 
            int page, 
            int pageSize, 
            int pageTotal)
        {
            Contract.Requires(content != null);
            Contract.Requires(subtotalCount >= 0);
            Contract.Ensures(Contract.Result<ICollectionPage<Quaggan>>() != null);
            var values = new CollectionPage<Quaggan>(content.Count)
                {
                    PageIndex = page, 
                    PageSize = pageSize, 
                    PageCount = pageTotal, 
                    SubtotalCount = subtotalCount, 
                    TotalCount = totalCount
                };

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

            values.AddRange(content.Select(ConvertQuagganDataContract));
            return values;
        }
    }
}