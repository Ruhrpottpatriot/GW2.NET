// <copyright file="RepositoryBase.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.V2.Achievements.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Threading.Tasks.Dataflow;
    using Common;
    using Foo;
    using Microsoft.Extensions.Logging;

    public abstract class RepositoryBase<TApiData, TData, TKey> : ILocalizable
        where TData : IKey<TKey>, ILocalizable
        where TKey : IEquatable<TKey>
    {
        private ITargetBlock<TApiData> headBlock;

        protected RepositoryBase(IServiceClient serviceClient, ILogger<RepositoryBase<TApiData, TData, TKey>> logger, IConverter<TApiData, TData> dataConverter, ICache<TData, TKey> cache)
        {
            this.headBlock = this.CreateProcessingNetwork();

            this.ServiceClient = serviceClient;
            this.Logger = logger;
            this.DataConverter = dataConverter;
            this.Cache = cache;
        }

        public Task<IResponse<TData>> RequestAsync(TKey id, CancellationToken cancellationToken)
        {
            if (this.headBlock == null)
            {
                this.headBlock = this.CreateProcessingNetwork();
            }

            // Do Stuff

            // Reset head block
            this.headBlock = null;

            throw new NotImplementedException();
        }

        private ITargetBlock<TApiData> CreateProcessingNetwork()
        {
            var idBlock = new BufferBlock<IEnumerable<int>>();




            var cacheDataBlock = new ActionBlock<IEnumerable<TKey>>();

        }

        public ILogger<RepositoryBase<TApiData, TData, TKey>> Logger { get; }

        public IServiceClient ServiceClient { get; }

        /// <inheritdoc />
        public CultureInfo Culture { get; }

        public IConverter<TApiData, TData> DataConverter { get; }

        public ICache<TData, TKey> Cache { get; }

        /// <summary>Gets the endpoint Uri.</summary>
        public abstract Uri Endpoint { get; }

        public Task<IResponse<TData>> RequestAsync(Request request)
        {
            return this.RequestAsync(request, CancellationToken.None);
        }

        public async Task<IResponse<TData>> RequestAsync(Request request, CancellationToken cancellationToken)
        {

        }

        /// <summary>Retrieves all non stale items from the cache.</summary>
        /// <param name="request">The request. Modified to only include the non cache retrieveable ids.</param>
        /// <param name="items">The cache items.</param>
        /// <returns>True when all items could be retrieved from the cache, false otherwise.</returns>
        private bool GetCacheItems(ref Request request, out IEnumerable<CacheItem<TData, TKey>> items)
        {
            var ids = request.Parameters.Where(p =>
                p.Key.Equals("id", StringComparison.OrdinalIgnoreCase) ||
                p.Key.Equals("ids", StringComparison.OrdinalIgnoreCase)).ToList();

            var cacheItems = this.Cache.Get(c => ids.Any(i => c.Id.Equals(i.Key)) && c.Culture.Equals(this.Culture));
            ids.RemoveAll(i => !cacheItems.Any(c => c.Data.Id.Equals(i.Key)));
            items = cacheItems;

            if (ids.Count == 0)
            {
                return true;
            }

            // ToDo: Modify request to only include the missing ids
            RequestParameter[] paramCopy = new RequestParameter[request.Parameters.Count];
            request.Parameters.CopyTo(paramCopy, 0);


            return false;
        }
    }
}
