// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuagganService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the Quaggan service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V2.Quaggans
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Entities.Quaggans;
    using GW2DotNET.V2.Common;
    using GW2DotNET.V2.Quaggans.Json;

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
            var response = this.serviceClient.Send<QuagganContract>(request);
            if (response.Content == null)
            {
                return null;
            }

            return ConvertQuagganContract(response.Content);
        }

        /// <summary>Finds every <see cref="Quaggan"/>.</summary>
        /// <returns>A collection of every <see cref="Quaggan"/>.</returns>
        public IDictionaryRange<string, Quaggan> FindAll()
        {
            var request = new QuagganBulkRequest();
            var response = this.serviceClient.Send<IEnumerable<QuagganContract>>(request);
            if (response.Content == null)
            {
                return new DictionaryRange<string, Quaggan>(0);
            }

            // Get the number of values in this subset
            var pageCount = response.GetResultCount();

            // Get the number of values in the collection
            var totalCount = response.GetResultTotal();

            // Convert the return values to entities
            return ConvertQuagganContracts(response.Content, pageCount, totalCount);
        }

        /// <summary>Finds every <see cref="Quaggan"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <returns>A collection every <see cref="Quaggan"/> with one of the specified identifiers.</returns>
        public IDictionaryRange<string, Quaggan> FindAll(ICollection<string> identifiers)
        {
            var request = new QuagganBulkRequest { Identifiers = identifiers.ToList() };
            var response = this.serviceClient.Send<IEnumerable<QuagganContract>>(request);
            if (response.Content == null)
            {
                return new DictionaryRange<string, Quaggan>(0);
            }

            // Get the number of values in this subset
            var pageCount = response.GetResultCount();

            // Get the number of values in the collection
            var totalCount = response.GetResultTotal();

            // Convert the return values to entities
            return ConvertQuagganContracts(response.Content, pageCount, totalCount);
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
            return this.serviceClient.SendAsync<IEnumerable<QuagganContract>>(request, cancellationToken).ContinueWith(
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
                        return ConvertQuagganContracts(response.Content, pageCount, totalCount);
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
            var request = new QuagganBulkRequest { Identifiers = identifiers.ToList() };
            return this.serviceClient.SendAsync<IEnumerable<QuagganContract>>(request, cancellationToken).ContinueWith(
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
                        return ConvertQuagganContracts(response.Content, pageCount, totalCount);
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
            return this.serviceClient.SendAsync<QuagganContract>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null)
                        {
                            return null;
                        }

                        return ConvertQuagganContract(response.Content);
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a page with the specified page number.</summary>
        /// <param name="page">The page to get.</param>
        /// <returns>The page.</returns>
        public ICollectionPage<Quaggan> GetPage(int page)
        {
            var request = new QuagganPageRequest { Page = page };
            var response = this.serviceClient.Send<IEnumerable<QuagganContract>>(request);
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
            return ConvertQuagganContracts(response.Content, pageCount, totalCount, page, pageSize, pageTotal);
        }

        /// <summary>Gets a page with the specified page number and maximum size.</summary>
        /// <param name="page">The page to get.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <returns>The page.</returns>
        public ICollectionPage<Quaggan> GetPage(int page, int pageSize)
        {
            var request = new QuagganPageRequest { Page = page, PageSize = pageSize };
            var response = this.serviceClient.Send<IEnumerable<QuagganContract>>(request);
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
            return ConvertQuagganContracts(response.Content, pageCount, totalCount, page, size, pageTotal);
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
            return this.serviceClient.SendAsync<IEnumerable<QuagganContract>>(request, cancellationToken).ContinueWith(
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
                        return ConvertQuagganContracts(response.Content, pageCount, totalCount, page, pageSize, pageTotal);
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
            return this.serviceClient.SendAsync<IEnumerable<QuagganContract>>(request, cancellationToken).ContinueWith(
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
                        return ConvertQuagganContracts(response.Content, pageCount, totalCount, page, size, pageTotal);
                    }, 
                cancellationToken);
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Quaggan ConvertQuagganContract(QuagganContract content)
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

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <param name="pageCount">The page count.</param>
        /// <param name="totalCount">The total count.</param>
        /// <returns>A collection of entities.</returns>
        private static IDictionaryRange<string, Quaggan> ConvertQuagganContracts(IEnumerable<QuagganContract> content, int pageCount, int totalCount)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<IDictionary<string, Quaggan>>() != null);
            var values = new DictionaryRange<string, Quaggan>(pageCount) { SubtotalCount = pageCount, TotalCount = totalCount };
            foreach (var value in content.Select(ConvertQuagganContract))
            {
                Contract.Assume(value != null);
                values.Add(value.Id, value);
            }

            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <param name="pageCount">The page count.</param>
        /// <param name="totalCount">The total count.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="pageTotal">The page total.</param>
        /// <returns>A collection of entities.</returns>
        private static ICollectionPage<Quaggan> ConvertQuagganContracts(
            IEnumerable<QuagganContract> content, 
            int pageCount, 
            int totalCount, 
            int page, 
            int pageSize, 
            int pageTotal)
        {
            Contract.Requires(content != null);
            Contract.Requires(pageCount >= 0);
            Contract.Ensures(Contract.Result<ICollectionPage<Quaggan>>() != null);
            var values = new CollectionPage<Quaggan>(pageCount)
                {
                    SubtotalCount = pageCount, 
                    TotalCount = totalCount, 
                    Page = page, 
                    PageSize = pageSize, 
                    PageCount = pageTotal
                };
            values.AddRange(content.Select(ConvertQuagganContract));
            return values;
        }

        /// <summary>The invariant method for this class.</summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.serviceClient != null);
        }
    }
}