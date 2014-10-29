// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorldRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v2/worlds interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Worlds
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Entities.Worlds;
    using GW2NET.V2.Common;
    using GW2NET.V2.Worlds.Json;

    /// <summary>Represents a repository that retrieves data from the /v2/worlds interface.</summary>
    public class WorldRepository : IRepository<int, World>, ILocalizable
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="WorldRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="serviceClient"/> is <c>null</c>.</exception>
        public WorldRepository(IServiceClient serviceClient)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient", "Precondition failed: serviceClient != null");
            }

            Contract.Ensures(this.serviceClient != null);
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets or sets the locale.</summary>
        public CultureInfo Culture { get; set; }

        /// <inheritdoc />
        ICollection<int> IDiscoverable<int>.Discover()
        {
            var request = new WorldDiscoveryRequest();
            var response = this.serviceClient.Send<ICollection<int>>(request);
            if (response.Content == null)
            {
                return new int[0];
            }

            return response.Content;
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync()
        {
            return ((IRepository<int, World>)this).DiscoverAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync(CancellationToken cancellationToken)
        {
            var request = new WorldDiscoveryRequest();
            return this.serviceClient.SendAsync<ICollection<int>>(request, cancellationToken).ContinueWith(task =>
            {
                var response = task.Result;
                if (response.Content == null)
                {
                    return new int[0];
                }

                return response.Content;
            }, cancellationToken);
        }

        /// <inheritdoc />
        World IRepository<int, World>.Find(int identifier)
        {
            var request = new WorldDetailsRequest { Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo), Culture = this.Culture };
            var response = this.serviceClient.Send<WorldDataContract>(request);
            if (response.Content == null)
            {
                return null;
            }

            var value = ConvertWorldDataContract(response.Content);
            value.Locale = response.Culture;
            return value;
        }

        /// <inheritdoc />
        IDictionaryRange<int, World> IRepository<int, World>.FindAll()
        {
            var request = new WorldBulkRequest { Culture = this.Culture };
            var response = this.serviceClient.Send<ICollection<WorldDataContract>>(request);
            if (response.Content == null)
            {
                return new DictionaryRange<int, World>(0);
            }

            var values = new DictionaryRange<int, World>(response.Content.Count) { SubtotalCount = response.GetResultCount(), TotalCount = response.GetResultTotal() };

            var locale = response.Culture;
            foreach (var value in response.Content.Select(ConvertWorldDataContract))
            {
                value.Locale = locale;
                values.Add(value.WorldId, value);
            }

            return values;
        }

        /// <inheritdoc />
        IDictionaryRange<int, World> IRepository<int, World>.FindAll(ICollection<int> identifiers)
        {
            var request = new WorldBulkRequest { Culture = this.Culture, Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList() };
            var response = this.serviceClient.Send<ICollection<WorldDataContract>>(request);
            if (response.Content == null)
            {
                return new DictionaryRange<int, World>(0);
            }

            var values = new DictionaryRange<int, World>(response.Content.Count) { SubtotalCount = response.GetResultCount(), TotalCount = response.GetResultTotal() };

            var locale = response.Culture;
            foreach (var value in response.Content.Select(ConvertWorldDataContract))
            {
                value.Locale = locale;
                values.Add(value.WorldId, value);
            }

            return values;
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, World>> IRepository<int, World>.FindAllAsync()
        {
            return ((IRepository<int, World>)this).FindAllAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, World>> IRepository<int, World>.FindAllAsync(CancellationToken cancellationToken)
        {
            var request = new WorldBulkRequest { Culture = this.Culture };
            return this.serviceClient.SendAsync<ICollection<WorldDataContract>>(request, cancellationToken).ContinueWith<IDictionaryRange<int, World>>(task =>
            {
                var response = task.Result;
                if (response.Content == null)
                {
                    return new DictionaryRange<int, World>(0);
                }

                var values = new DictionaryRange<int, World>(response.Content.Count) { SubtotalCount = response.GetResultCount(), TotalCount = response.GetResultTotal() };

                var locale = response.Culture;
                foreach (var value in response.Content.Select(ConvertWorldDataContract))
                {
                    value.Locale = locale;
                    values.Add(value.WorldId, value);
                }

                return values;
            }, cancellationToken);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, World>> IRepository<int, World>.FindAllAsync(ICollection<int> identifiers)
        {
            return ((IRepository<int, World>)this).FindAllAsync(identifiers, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, World>> IRepository<int, World>.FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            var request = new WorldBulkRequest { Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList(), Culture = this.Culture };

            return this.serviceClient.SendAsync<ICollection<WorldDataContract>>(request, cancellationToken).ContinueWith<IDictionaryRange<int, World>>(task =>
            {
                var response = task.Result;
                if (response.Content == null)
                {
                    return new DictionaryRange<int, World>(0);
                }

                var values = new DictionaryRange<int, World>(response.Content.Count) { SubtotalCount = response.GetResultCount(), TotalCount = response.GetResultTotal() };

                var locale = response.Culture;
                foreach (var value in response.Content.Select(ConvertWorldDataContract))
                {
                    value.Locale = locale;
                    values.Add(value.WorldId, value);
                }

                return values;
            }, cancellationToken);
        }

        /// <inheritdoc />
        Task<World> IRepository<int, World>.FindAsync(int identifier)
        {
            return ((IRepository<int, World>)this).FindAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<World> IRepository<int, World>.FindAsync(int identifier, CancellationToken cancellationToken)
        {
            var request = new WorldDetailsRequest { Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo), Culture = this.Culture };

            return this.serviceClient.SendAsync<WorldDataContract>(request, cancellationToken).ContinueWith(task =>
            {
                var response = task.Result;
                if (response.Content == null)
                {
                    return null;
                }

                var value = ConvertWorldDataContract(response.Content);
                value.Locale = response.Culture;
                return value;
            }, cancellationToken);
        }

        /// <inheritdoc />
        ICollectionPage<World> IPaginator<World>.FindPage(int pageIndex)
        {
            var request = new WorldPageRequest { Page = pageIndex, Culture = this.Culture };
            var response = this.serviceClient.Send<ICollection<WorldDataContract>>(request);
            if (response.Content == null)
            {
                return new CollectionPage<World>(0);
            }

            var values = new CollectionPage<World>(response.Content.Count) { PageIndex = pageIndex, PageSize = response.GetPageSize(), PageCount = response.GetPageTotal(), SubtotalCount = response.GetResultCount(), TotalCount = response.GetResultTotal() };

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

            var locale = response.Culture;
            foreach (var value in response.Content.Select(ConvertWorldDataContract))
            {
                value.Locale = locale;
                values.Add(value);
            }

            return values;
        }

        /// <inheritdoc />
        ICollectionPage<World> IPaginator<World>.FindPage(int pageIndex, int pageSize)
        {
            var request = new WorldPageRequest { Page = pageIndex, PageSize = pageSize, Culture = this.Culture };

            var response = this.serviceClient.Send<ICollection<WorldDataContract>>(request);
            if (response.Content == null)
            {
                return new CollectionPage<World>(0);
            }

            var values = new CollectionPage<World>(response.Content.Count) { PageIndex = pageIndex, PageSize = response.GetPageSize(), PageCount = response.GetPageTotal(), SubtotalCount = response.GetResultCount(), TotalCount = response.GetResultTotal() };

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

            var locale = response.Culture;
            foreach (var value in response.Content.Select(ConvertWorldDataContract))
            {
                value.Locale = locale;
                values.Add(value);
            }

            return values;
        }

        /// <inheritdoc />
        Task<ICollectionPage<World>> IPaginator<World>.FindPageAsync(int pageIndex)
        {
            return ((IRepository<int, World>)this).FindPageAsync(pageIndex, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollectionPage<World>> IPaginator<World>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            var request = new WorldPageRequest { Page = pageIndex, Culture = this.Culture };
            return this.serviceClient.SendAsync<ICollection<WorldDataContract>>(request, cancellationToken).ContinueWith<ICollectionPage<World>>(task =>
            {
                var response = task.Result;
                if (response.Content == null)
                {
                    return new CollectionPage<World>(0);
                }

                var values = new CollectionPage<World>(response.Content.Count) { PageIndex = pageIndex, PageSize = response.GetPageSize(), PageCount = response.GetPageTotal(), SubtotalCount = response.GetResultCount(), TotalCount = response.GetResultTotal() };

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

                var locale = response.Culture;
                foreach (var value in response.Content.Select(ConvertWorldDataContract))
                {
                    value.Locale = locale;
                    values.Add(value);
                }

                return values;
            }, cancellationToken);
        }

        /// <inheritdoc />
        Task<ICollectionPage<World>> IPaginator<World>.FindPageAsync(int pageIndex, int pageSize)
        {
            return ((IRepository<int, World>)this).FindPageAsync(pageIndex, pageSize, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollectionPage<World>> IPaginator<World>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            var request = new WorldPageRequest { Page = pageIndex, PageSize = pageSize, Culture = this.Culture };

            return this.serviceClient.SendAsync<ICollection<WorldDataContract>>(request, cancellationToken).ContinueWith<ICollectionPage<World>>(task =>
            {
                var response = task.Result;
                if (response.Content == null)
                {
                    return new CollectionPage<World>(0);
                }

                var values = new CollectionPage<World>(response.Content.Count) { PageIndex = pageIndex, PageSize = response.GetPageSize(), PageCount = response.GetPageTotal(), SubtotalCount = response.GetResultCount(), TotalCount = response.GetResultTotal() };

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

                var locale = response.Culture;
                foreach (var value in response.Content.Select(ConvertWorldDataContract))
                {
                    value.Locale = locale;
                    values.Add(value);
                }

                return values;
            }, cancellationToken);
        }

        // TODO: refactor to IConverter
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private static World ConvertWorldDataContract(WorldDataContract content)
        {
            return new World { WorldId = content.Id, Name = content.Name };
        }
    }
}