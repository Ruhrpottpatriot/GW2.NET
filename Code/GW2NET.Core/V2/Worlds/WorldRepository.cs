// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorldRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the world service.
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

    /// <summary>Provides the default implementation of the world service.</summary>
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

        /// <summary>Gets the discovered identifiers.</summary>
        /// <returns>A collection of discovered identifiers.</returns>
        public ICollection<int> Discover()
        {
            var request = new WorldDiscoveryRequest();
            var response = this.serviceClient.Send<ICollection<int>>(request);
            if (response.Content == null)
            {
                return new int[0];
            }

            return response.Content;
        }

        /// <summary>Gets the discovered identifiers.</summary>
        /// <returns>A collection of discovered identifiers.</returns>
        public Task<ICollection<int>> DiscoverAsync()
        {
            return this.DiscoverAsync(CancellationToken.None);
        }

        /// <summary>Gets the discovered identifiers.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of discovered identifiers.</returns>
        public Task<ICollection<int>> DiscoverAsync(CancellationToken cancellationToken)
        {
            var request = new WorldDiscoveryRequest();
            return this.serviceClient.SendAsync<ICollection<int>>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null)
                        {
                            return new int[0];
                        }

                        return response.Content;
                    }, 
                cancellationToken);
        }

        /// <summary>Finds the <see cref="World"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>The <see cref="World"/> with the specified identifier.</returns>
        public World Find(int identifier)
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

        /// <summary>Finds every <see cref="World"/>.</summary>
        /// <returns>A collection of every <see cref="World"/>.</returns>
        public IDictionaryRange<int, World> FindAll()
        {
            var request = new WorldBulkRequest { Culture = this.Culture };
            var response = this.serviceClient.Send<ICollection<WorldDataContract>>(request);
            if (response.Content == null)
            {
                return new DictionaryRange<int, World>(0);
            }

            var values = new DictionaryRange<int, World>(response.Content.Count)
                {
                    SubtotalCount = response.GetResultCount(), 
                    TotalCount = response.GetResultTotal()
                };

            var locale = response.Culture;
            foreach (var value in response.Content.Select(ConvertWorldDataContract))
            {
                value.Locale = locale;
                values.Add(value.WorldId, value);
            }

            return values;
        }

        /// <summary>Finds every <see cref="World"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <returns>A collection every <see cref="World"/> with one of the specified identifiers.</returns>
        public IDictionaryRange<int, World> FindAll(ICollection<int> identifiers)
        {
            var request = new WorldBulkRequest
                {
                    Culture = this.Culture, 
                    Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList()
                };
            var response = this.serviceClient.Send<ICollection<WorldDataContract>>(request);
            if (response.Content == null)
            {
                return new DictionaryRange<int, World>(0);
            }

            var values = new DictionaryRange<int, World>(response.Content.Count)
                {
                    SubtotalCount = response.GetResultCount(), 
                    TotalCount = response.GetResultTotal()
                };

            var locale = response.Culture;
            foreach (var value in response.Content.Select(ConvertWorldDataContract))
            {
                value.Locale = locale;
                values.Add(value.WorldId, value);
            }

            return values;
        }

        /// <summary>Finds every <see cref="World"/>.</summary>
        /// <returns>A collection of every <see cref="World"/>.</returns>
        public Task<IDictionaryRange<int, World>> FindAllAsync()
        {
            return this.FindAllAsync(CancellationToken.None);
        }

        /// <summary>Finds every <see cref="World"/>.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of every <see cref="World"/></returns>
        public Task<IDictionaryRange<int, World>> FindAllAsync(CancellationToken cancellationToken)
        {
            var request = new WorldBulkRequest { Culture = this.Culture };
            return this.serviceClient.SendAsync<ICollection<WorldDataContract>>(request, cancellationToken).ContinueWith<IDictionaryRange<int, World>>(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null)
                        {
                            return new DictionaryRange<int, World>(0);
                        }

                        var values = new DictionaryRange<int, World>(response.Content.Count)
                            {
                                SubtotalCount = response.GetResultCount(), 
                                TotalCount = response.GetResultTotal()
                            };

                        var locale = response.Culture;
                        foreach (var value in response.Content.Select(ConvertWorldDataContract))
                        {
                            value.Locale = locale;
                            values.Add(value.WorldId, value);
                        }

                        return values;
                    }, 
                cancellationToken);
        }

        /// <summary>Finds every <see cref="World"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <returns>A collection every <see cref="World"/> with one of the specified identifiers.</returns>
        public Task<IDictionaryRange<int, World>> FindAllAsync(ICollection<int> identifiers)
        {
            return this.FindAllAsync(identifiers, CancellationToken.None);
        }

        /// <summary>Finds every <see cref="World"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection every <see cref="World"/> with one of the specified identifiers.</returns>
        public Task<IDictionaryRange<int, World>> FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            var request = new WorldBulkRequest
                {
                    Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList(), 
                    Culture = this.Culture
                };

            return this.serviceClient.SendAsync<ICollection<WorldDataContract>>(request, cancellationToken).ContinueWith<IDictionaryRange<int, World>>(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null)
                        {
                            return new DictionaryRange<int, World>(0);
                        }

                        var values = new DictionaryRange<int, World>(response.Content.Count)
                            {
                                SubtotalCount = response.GetResultCount(), 
                                TotalCount = response.GetResultTotal()
                            };

                        var locale = response.Culture;
                        foreach (var value in response.Content.Select(ConvertWorldDataContract))
                        {
                            value.Locale = locale;
                            values.Add(value.WorldId, value);
                        }

                        return values;
                    }, 
                cancellationToken);
        }

        /// <summary>Finds the <see cref="World"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>The <see cref="World"/> with the specified identifier.</returns>
        public Task<World> FindAsync(int identifier)
        {
            return this.FindAsync(identifier, CancellationToken.None);
        }

        /// <summary>Finds the <see cref="World"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <see cref="World"/> with the specified identifier.</returns>
        public Task<World> FindAsync(int identifier, CancellationToken cancellationToken)
        {
            var request = new WorldDetailsRequest { Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo), Culture = this.Culture };

            return this.serviceClient.SendAsync<WorldDataContract>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null)
                        {
                            return null;
                        }

                        var value = ConvertWorldDataContract(response.Content);
                        value.Locale = response.Culture;
                        return value;
                    }, 
                cancellationToken);
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <returns>The page.</returns>
        public ICollectionPage<World> FindPage(int pageIndex)
        {
            var request = new WorldPageRequest { Page = pageIndex, Culture = this.Culture };
            var response = this.serviceClient.Send<ICollection<WorldDataContract>>(request);
            if (response.Content == null)
            {
                return new CollectionPage<World>(0);
            }

            var values = new CollectionPage<World>(response.Content.Count)
                {
                    PageIndex = pageIndex, 
                    PageSize = response.GetPageSize(), 
                    PageCount = response.GetPageTotal(), 
                    SubtotalCount = response.GetResultCount(), 
                    TotalCount = response.GetResultTotal()
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

            var locale = response.Culture;
            foreach (var value in response.Content.Select(ConvertWorldDataContract))
            {
                value.Locale = locale;
                values.Add(value);
            }

            return values;
        }

        /// <summary>Finds the page with the specified page number and maximum size.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <returns>The page.</returns>
        public ICollectionPage<World> FindPage(int pageIndex, int pageSize)
        {
            var request = new WorldPageRequest { Page = pageIndex, PageSize = pageSize, Culture = this.Culture };

            var response = this.serviceClient.Send<ICollection<WorldDataContract>>(request);
            if (response.Content == null)
            {
                return new CollectionPage<World>(0);
            }

            var values = new CollectionPage<World>(response.Content.Count)
                {
                    PageIndex = pageIndex, 
                    PageSize = response.GetPageSize(), 
                    PageCount = response.GetPageTotal(), 
                    SubtotalCount = response.GetResultCount(), 
                    TotalCount = response.GetResultTotal()
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

            var locale = response.Culture;
            foreach (var value in response.Content.Select(ConvertWorldDataContract))
            {
                value.Locale = locale;
                values.Add(value);
            }

            return values;
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<World>> FindPageAsync(int pageIndex)
        {
            return this.FindPageAsync(pageIndex, CancellationToken.None);
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<World>> FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            var request = new WorldPageRequest { Page = pageIndex, Culture = this.Culture };
            return this.serviceClient.SendAsync<ICollection<WorldDataContract>>(request, cancellationToken).ContinueWith<ICollectionPage<World>>(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null)
                        {
                            return new CollectionPage<World>(0);
                        }

                        var values = new CollectionPage<World>(response.Content.Count)
                            {
                                PageIndex = pageIndex, 
                                PageSize = response.GetPageSize(), 
                                PageCount = response.GetPageTotal(), 
                                SubtotalCount = response.GetResultCount(), 
                                TotalCount = response.GetResultTotal()
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

                        var locale = response.Culture;
                        foreach (var value in response.Content.Select(ConvertWorldDataContract))
                        {
                            value.Locale = locale;
                            values.Add(value);
                        }

                        return values;
                    }, 
                cancellationToken);
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<World>> FindPageAsync(int pageIndex, int pageSize)
        {
            return this.FindPageAsync(pageIndex, pageSize, CancellationToken.None);
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<World>> FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            var request = new WorldPageRequest { Page = pageIndex, PageSize = pageSize, Culture = this.Culture };

            return this.serviceClient.SendAsync<ICollection<WorldDataContract>>(request, cancellationToken).ContinueWith<ICollectionPage<World>>(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null)
                        {
                            return new CollectionPage<World>(0);
                        }

                        var values = new CollectionPage<World>(response.Content.Count)
                            {
                                PageIndex = pageIndex, 
                                PageSize = response.GetPageSize(), 
                                PageCount = response.GetPageTotal(), 
                                SubtotalCount = response.GetResultCount(), 
                                TotalCount = response.GetResultTotal()
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

                        var locale = response.Culture;
                        foreach (var value in response.Content.Select(ConvertWorldDataContract))
                        {
                            value.Locale = locale;
                            values.Add(value);
                        }

                        return values;
                    }, 
                cancellationToken);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private static World ConvertWorldDataContract(WorldDataContract content)
        {
            return new World { WorldId = content.Id, Name = content.Name };
        }
    }
}