// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuagganRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v2/quaggans interface.
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

    /// <summary>Represents a repository that retrieves data from the /v2/quaggans interface.</summary>
    public class QuagganRepository : IRepository<string, Quaggan>
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="QuagganRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public QuagganRepository(IServiceClient serviceClient)
        {
            Contract.Requires(serviceClient != null);
            Contract.Ensures(this.serviceClient != null);
            this.serviceClient = serviceClient;
        }

        /// <inheritdoc />
        ICollection<string> IDiscoverable<string>.Discover()
        {
            var request = new QuagganDiscoveryRequest();
            var response = this.serviceClient.Send<ICollection<string>>(request);
            if (response.Content == null)
            {
                return new string[0];
            }

            return response.Content;
        }

        /// <inheritdoc />
        Task<ICollection<string>> IDiscoverable<string>.DiscoverAsync()
        {
            return ((IRepository<string, Quaggan>)this).DiscoverAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollection<string>> IDiscoverable<string>.DiscoverAsync(CancellationToken cancellationToken)
        {
            var request = new QuagganDiscoveryRequest();
            return this.serviceClient.SendAsync<ICollection<string>>(request, cancellationToken).ContinueWith(task =>
            {
                var response = task.Result;
                if (response.Content == null)
                {
                    return new string[0];
                }

                return response.Content;
            }, cancellationToken);
        }

        /// <inheritdoc />
        Quaggan IRepository<string, Quaggan>.Find(string identifier)
        {
            var request = new QuagganDetailsRequest
            {
                Identifier = identifier
            };
            var response = this.serviceClient.Send<QuagganDataContract>(request);
            if (response.Content == null)
            {
                return null;
            }

            return ConvertQuagganDataContract(response.Content);
        }

        /// <inheritdoc />
        IDictionaryRange<string, Quaggan> IRepository<string, Quaggan>.FindAll()
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

        /// <inheritdoc />
        IDictionaryRange<string, Quaggan> IRepository<string, Quaggan>.FindAll(ICollection<string> identifiers)
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

            var request = new QuagganBulkRequest
            {
                Identifiers = identifiers.ToList()
            };
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

        /// <inheritdoc />
        Task<IDictionaryRange<string, Quaggan>> IRepository<string, Quaggan>.FindAllAsync()
        {
            return ((IRepository<string, Quaggan>)this).FindAllAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<string, Quaggan>> IRepository<string, Quaggan>.FindAllAsync(CancellationToken cancellationToken)
        {
            var request = new QuagganBulkRequest();
            return this.serviceClient.SendAsync<ICollection<QuagganDataContract>>(request, cancellationToken).ContinueWith(task =>
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
            }, cancellationToken);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<string, Quaggan>> IRepository<string, Quaggan>.FindAllAsync(ICollection<string> identifiers)
        {
            return ((IRepository<string, Quaggan>)this).FindAllAsync(identifiers, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<string, Quaggan>> IRepository<string, Quaggan>.FindAllAsync(ICollection<string> identifiers, CancellationToken cancellationToken)
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

            var request = new QuagganBulkRequest
            {
                Identifiers = identifiers.ToList()
            };
            return this.serviceClient.SendAsync<ICollection<QuagganDataContract>>(request, cancellationToken).ContinueWith(task =>
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
            }, cancellationToken);
        }

        /// <inheritdoc />
        Task<Quaggan> IRepository<string, Quaggan>.FindAsync(string identifier)
        {
            return ((IRepository<string, Quaggan>)this).FindAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<Quaggan> IRepository<string, Quaggan>.FindAsync(string identifier, CancellationToken cancellationToken)
        {
            var request = new QuagganDetailsRequest
            {
                Identifier = identifier
            };
            return this.serviceClient.SendAsync<QuagganDataContract>(request, cancellationToken).ContinueWith(task =>
            {
                var response = task.Result;
                if (response.Content == null)
                {
                    return null;
                }

                return ConvertQuagganDataContract(response.Content);
            }, cancellationToken);
        }

        /// <inheritdoc />
        ICollectionPage<Quaggan> IPaginator<Quaggan>.FindPage(int pageIndex)
        {
            var request = new QuagganPageRequest
            {
                Page = pageIndex
            };
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
            return ConvertQuagganDataContractCollection(response.Content, pageCount, totalCount, pageIndex, pageSize, pageTotal);
        }

        /// <inheritdoc />
        ICollectionPage<Quaggan> IPaginator<Quaggan>.FindPage(int pageIndex, int pageSize)
        {
            var request = new QuagganPageRequest
            {
                Page = pageIndex, 
                PageSize = pageSize
            };
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
            return ConvertQuagganDataContractCollection(response.Content, pageCount, totalCount, pageIndex, size, pageTotal);
        }

        /// <inheritdoc />
        Task<ICollectionPage<Quaggan>> IPaginator<Quaggan>.FindPageAsync(int pageIndex)
        {
            return ((IRepository<string, Quaggan>)this).FindPageAsync(pageIndex, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollectionPage<Quaggan>> IPaginator<Quaggan>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            var request = new QuagganPageRequest
            {
                Page = pageIndex
            };
            return this.serviceClient.SendAsync<ICollection<QuagganDataContract>>(request, cancellationToken).ContinueWith(task =>
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
                return ConvertQuagganDataContractCollection(response.Content, pageCount, totalCount, pageIndex, pageSize, pageTotal);
            }, cancellationToken);
        }

        /// <inheritdoc />
        Task<ICollectionPage<Quaggan>> IPaginator<Quaggan>.FindPageAsync(int pageIndex, int pageSize)
        {
            return ((IRepository<string, Quaggan>)this).FindPageAsync(pageIndex, pageSize, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollectionPage<Quaggan>> IPaginator<Quaggan>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            var request = new QuagganPageRequest
            {
                Page = pageIndex, 
                PageSize = pageSize
            };
            return this.serviceClient.SendAsync<ICollection<QuagganDataContract>>(request, cancellationToken).ContinueWith(task =>
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
                return ConvertQuagganDataContractCollection(response.Content, pageCount, totalCount, pageIndex, size, pageTotal);
            }, cancellationToken);
        }

        // TODO: refactor to IConverter
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

        // TODO: refactor to IConverter
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private static IDictionaryRange<string, Quaggan> ConvertQuagganDataContractCollection(IEnumerable<QuagganDataContract> content, int subtotalCount, int totalCount)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<IDictionary<string, Quaggan>>() != null);
            var values = new DictionaryRange<string, Quaggan>(subtotalCount)
            {
                SubtotalCount = subtotalCount, 
                TotalCount = totalCount
            };
            foreach (var value in content.Select(ConvertQuagganDataContract))
            {
                Contract.Assume(value != null);
                values.Add(value.Id, value);
            }

            return values;
        }

        // TODO: refactor to IConverter
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private static ICollectionPage<Quaggan> ConvertQuagganDataContractCollection(ICollection<QuagganDataContract> content, int subtotalCount, int totalCount, int page, int pageSize, int pageTotal)
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