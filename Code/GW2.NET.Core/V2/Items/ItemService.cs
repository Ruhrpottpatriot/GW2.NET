// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides access to the /v2/items service using the default implementation.
//   This implementation does not retrieve associated entities. For example: item skins can be retrieved from the skins service, but this class does not ever touch the skins service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V2.Items
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Entities.Items;
    using GW2DotNET.V2.Common;

    /// <summary>
    /// Provides access to the /v2/items service using the default implementation.
    /// This implementation does not retrieve associated entities. For example: item skins can be retrieved from the skins service, but this class does not ever touch the skins service.
    /// </summary>
    public class ItemService : IRepository<int, Item>
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="ItemService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public ItemService(IServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets the discovered identifiers.</summary>
        /// <returns>A collection of discovered identifiers.</returns>
        public ICollection<int> Discover()
        {
            var request = new ItemDiscoveryRequest();
            var response = this.serviceClient.Send<ICollection<int>>(request);
            if (response.Content == null)
            {
                return null;
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
            var request = new ItemDiscoveryRequest();
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

        /// <summary>Finds the <see cref="Item"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>The <see cref="Item"/> with the specified identifier.</returns>
        public Item Find(int identifier)
        {
            throw new NotImplementedException();
        }

        /// <summary>Finds every <see cref="Item"/>.</summary>
        /// <returns>A collection of every <see cref="Item"/>.</returns>
        public IDictionaryRange<int, Item> FindAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>Finds every <see cref="Item"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <returns>A collection every <see cref="Item"/> with one of the specified identifiers.</returns>
        public IDictionaryRange<int, Item> FindAll(ICollection<int> identifiers)
        {
            throw new NotImplementedException();
        }

        /// <summary>Finds every <see cref="Item"/>.</summary>
        /// <returns>A collection of every <see cref="Item"/>.</returns>
        public Task<IDictionaryRange<int, Item>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>Finds every <see cref="Item"/>.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of every <see cref="Item"/></returns>
        public Task<IDictionaryRange<int, Item>> FindAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>Finds every <see cref="Item"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <returns>A collection every <see cref="Item"/> with one of the specified identifiers.</returns>
        public Task<IDictionaryRange<int, Item>> FindAllAsync(ICollection<int> identifiers)
        {
            throw new NotImplementedException();
        }

        /// <summary>Finds every <see cref="Item"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection every <see cref="Item"/> with one of the specified identifiers.</returns>
        public Task<IDictionaryRange<int, Item>> FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>Finds the <see cref="Item"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>The <see cref="Item"/> with the specified identifier.</returns>
        public Task<Item> FindAsync(int identifier)
        {
            throw new NotImplementedException();
        }

        /// <summary>Finds the <see cref="Item"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <see cref="Item"/> with the specified identifier.</returns>
        public Task<Item> FindAsync(int identifier, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>Gets a page with the specified page number.</summary>
        /// <param name="page">The page to get.</param>
        /// <returns>The page.</returns>
        public ICollectionPage<Item> GetPage(int page)
        {
            throw new NotImplementedException();
        }

        /// <summary>Gets a page with the specified page number and maximum size.</summary>
        /// <param name="page">The page to get.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <returns>The page.</returns>
        public ICollectionPage<Item> GetPage(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        /// <summary>Gets a page with the specified page number.</summary>
        /// <param name="page">The page to get.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<Item>> GetPageAsync(int page)
        {
            throw new NotImplementedException();
        }

        /// <summary>Gets a page with the specified page number.</summary>
        /// <param name="page">The page to get.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<Item>> GetPageAsync(int page, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>Gets a page with the specified page number.</summary>
        /// <param name="page">The page to get.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<Item>> GetPageAsync(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        /// <summary>Gets a page with the specified page number.</summary>
        /// <param name="page">The page to get.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<Item>> GetPageAsync(int page, int pageSize, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}