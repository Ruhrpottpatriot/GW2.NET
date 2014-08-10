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
    public class QuagganService : IQuagganService
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

        /// <summary>Gets a Quaggan.</summary>
        /// <param name="identifier">An identifier</param>
        /// <returns>A Quaggan.</returns>
        public Quaggan GetQuaggan(string identifier)
        {
            var request = new QuagganDetailsRequest { Identifier = identifier };
            var response = this.serviceClient.Send<QuagganContract>(request);
            if (response.Content == null)
            {
                return null;
            }

            return ConvertQuagganContract(response.Content);
        }

        /// <summary>Gets a Quaggan.</summary>
        /// <param name="identifier">An identifier</param>
        /// <returns>A Quaggan.</returns>
        public Task<Quaggan> GetQuagganAsync(string identifier)
        {
            return this.GetQuagganAsync(identifier, CancellationToken.None);
        }

        /// <summary>Gets a Quaggan.</summary>
        /// <param name="identifier">An identifier</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A Quaggan.</returns>
        public Task<Quaggan> GetQuagganAsync(string identifier, CancellationToken cancellationToken)
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

        /// <summary>Gets a collection of identifiers.</summary>
        /// <returns>A collection of identifiers.</returns>
        public ICollection<string> GetQuagganIdentifiers()
        {
            var request = new QuagganDiscoveryRequest();
            var response = this.serviceClient.Send<ICollection<string>>(request);
            if (response.Content == null)
            {
                return new List<string>(0);
            }

            return response.Content;
        }

        /// <summary>Gets a collection of identifiers.</summary>
        /// <returns>A collection of identifiers.</returns>
        public Task<ICollection<string>> GetQuagganIdentifiersAsync()
        {
            return this.GetQuagganIdentifiersAsync(CancellationToken.None);
        }

        /// <summary>Gets a collection of identifiers.</summary>
        /// <param name="cancellationToken">The cancellation Token.</param>
        /// <returns>A collection of identifiers.</returns>
        public Task<ICollection<string>> GetQuagganIdentifiersAsync(CancellationToken cancellationToken)
        {
            var request = new QuagganDiscoveryRequest();
            return this.serviceClient.SendAsync<ICollection<string>>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null)
                        {
                            return new List<string>(0);
                        }

                        return response.Content;
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a collection of Quaggans</summary>
        /// <returns>A collection of Quaggans.</returns>
        public Subdictionary<string, Quaggan> GetQuaggans()
        {
            var request = new QuagganBulkRequest();
            var response = this.serviceClient.Send<IEnumerable<QuagganContract>>(request);
            if (response.Content == null)
            {
                return new Subdictionary<string, Quaggan>(0);
            }

            // Get the number of values in this subset
            var pageCount = response.GetResultCount();

            // Get the number of values in the collection
            var totalCount = response.GetResultTotal();

            // Convert the return values to entities
            return ConvertQuagganContracts(response.Content, pageCount, totalCount);
        }

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="identifiers">A collection of identifiers.</param>
        /// <returns>A collection of Quaggans.</returns>
        public Subdictionary<string, Quaggan> GetQuaggans(IEnumerable<string> identifiers)
        {
            var request = new QuagganBulkRequest { Identifiers = identifiers.ToList() };
            var response = this.serviceClient.Send<IEnumerable<QuagganContract>>(request);
            if (response.Content == null)
            {
                return new Subdictionary<string, Quaggan>(0);
            }

            // Get the number of values in this subset
            var pageCount = response.GetResultCount();

            // Get the number of values in the collection
            var totalCount = response.GetResultTotal();

            // Convert the return values to entities
            return ConvertQuagganContracts(response.Content, pageCount, totalCount);
        }

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="page">The page number.</param>
        /// <returns>A collection of Quaggans.</returns>
        public PaginatedCollection<Quaggan> GetQuaggans(int page)
        {
            var request = new QuagganPageRequest { Page = page };
            var response = this.serviceClient.Send<IEnumerable<QuagganContract>>(request);
            if (response.Content == null)
            {
                return new PaginatedCollection<Quaggan>(0);
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

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="page">The page number.</param>
        /// <param name="size">The page size.</param>
        /// <returns>A collection of Quaggans.</returns>
        public PaginatedCollection<Quaggan> GetQuaggans(int page, int size)
        {
            var request = new QuagganPageRequest { Page = page, PageSize = size };
            var response = this.serviceClient.Send<IEnumerable<QuagganContract>>(request);
            if (response.Content == null)
            {
                return new PaginatedCollection<Quaggan>(0);
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

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="page">The page number.</param>
        /// <param name="size">The page size.</param>
        /// <returns>A collection of Quaggans.</returns>
        public Task<PaginatedCollection<Quaggan>> GetQuaggansAsync(int page, int size)
        {
            return this.GetQuaggansAsync(page, size, CancellationToken.None);
        }

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="page">The page number.</param>
        /// <param name="size">The page size.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of Quaggans.</returns>
        public Task<PaginatedCollection<Quaggan>> GetQuaggansAsync(int page, int size, CancellationToken cancellationToken)
        {
            var request = new QuagganPageRequest { Page = page, PageSize = size };
            return this.serviceClient.SendAsync<IEnumerable<QuagganContract>>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null)
                        {
                            return new PaginatedCollection<Quaggan>(0);
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

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="page">The page number.</param>
        /// <returns>A collection of Quaggans.</returns>
        public Task<PaginatedCollection<Quaggan>> GetQuaggansAsync(int page)
        {
            return this.GetQuaggansAsync(page, CancellationToken.None);
        }

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="page">The page number.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of Quaggans.</returns>
        public Task<PaginatedCollection<Quaggan>> GetQuaggansAsync(int page, CancellationToken cancellationToken)
        {
            var request = new QuagganPageRequest { Page = page };
            return this.serviceClient.SendAsync<IEnumerable<QuagganContract>>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null)
                        {
                            return new PaginatedCollection<Quaggan>(0);
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

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="identifiers">A collection of identifiers.</param>
        /// <returns>A collection of Quaggans.</returns>
        public Task<Subdictionary<string, Quaggan>> GetQuaggansAsync(IEnumerable<string> identifiers)
        {
            return this.GetQuaggansAsync(identifiers, CancellationToken.None);
        }

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="identifiers">A collection of identifiers.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of Quaggans.</returns>
        public Task<Subdictionary<string, Quaggan>> GetQuaggansAsync(IEnumerable<string> identifiers, CancellationToken cancellationToken)
        {
            var request = new QuagganBulkRequest { Identifiers = identifiers.ToList() };
            return this.serviceClient.SendAsync<IEnumerable<QuagganContract>>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null)
                        {
                            return new Subdictionary<string, Quaggan>(0);
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

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <returns>A collection of Quaggans.</returns>
        public Task<Subdictionary<string, Quaggan>> GetQuaggansAsync()
        {
            return this.GetQuaggansAsync(CancellationToken.None);
        }

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="cancellationToken">The cancellation.</param>
        /// <returns>A collection of Quaggans.</returns>
        public Task<Subdictionary<string, Quaggan>> GetQuaggansAsync(CancellationToken cancellationToken)
        {
            var request = new QuagganBulkRequest();
            return this.serviceClient.SendAsync<IEnumerable<QuagganContract>>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null)
                        {
                            return new Subdictionary<string, Quaggan>(0);
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
        private static Subdictionary<string, Quaggan> ConvertQuagganContracts(IEnumerable<QuagganContract> content, int pageCount, int totalCount)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<IDictionary<string, Quaggan>>() != null);
            var values = new Subdictionary<string, Quaggan>(pageCount) { PageCount = pageCount, TotalCount = totalCount };
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
        private static PaginatedCollection<Quaggan> ConvertQuagganContracts(
            IEnumerable<QuagganContract> content, 
            int pageCount, 
            int totalCount, 
            int page, 
            int pageSize, 
            int pageTotal)
        {
            Contract.Requires(content != null);
            Contract.Requires(pageCount >= 0);
            Contract.Ensures(Contract.Result<PaginatedCollection<Quaggan>>() != null);
            var values = new PaginatedCollection<Quaggan>(pageCount)
                             {
                                 PageCount = pageCount, 
                                 TotalCount = totalCount, 
                                 CurrentPage = page, 
                                 PageSize = pageSize, 
                                 PageTotal = pageTotal
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