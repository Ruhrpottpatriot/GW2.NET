// <copyright file="RepositoryBase.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Threading.Tasks.Dataflow;
    using Caching;
    using Common;
    using Microsoft.Extensions.Logging;

    public abstract class RepositoryBase<TApiData, TData, TKey> : ILocalizable, IDisposable
        where TData : IKey<TKey>, ILocalizable
        where TKey : IEquatable<TKey>
    {
        private readonly ITargetBlock<Request> headBlock;
        private bool disposedValue = false; // To detect redundant calls
        private CancellationTokenSource tokenSource;

        protected RepositoryBase(
            IServiceClient client,
            ILogger<RepositoryBase<TApiData, TData, TKey>> logger,
            IConverter<TApiData, TData> dataConverter,
            ICache<TData, TKey> cache,
            RepositoryOptions options)
        {
            this.tokenSource = new CancellationTokenSource();

            this.headBlock = this.CreateProcessingNetwork();

            this.Client = client;
            this.Logger = logger;
            this.DataConverter = dataConverter;
            this.Cache = cache;
            this.Options = options;
        }

        public IObservable<IEnumerable<Response<TData>>> Data { get; set; }

        public ILogger<RepositoryBase<TApiData, TData, TKey>> Logger { get; }

        public IServiceClient Client { get; }

        public IConverter<TApiData, TData> DataConverter { get; }

        public ICache<TData, TKey> Cache { get; }

        public RepositoryOptions Options { get; }

        /// <inheritdoc />
        public CultureInfo Culture { get; set; }

        /// <summary>Gets the endpoint Uri.</summary>
        public abstract Uri Endpoint { get; }

        public Task RequestAsync(Request request)
        {
            return this.RequestAsync(request, CancellationToken.None);
        }

        public async Task RequestAsync(Request request, CancellationToken cancellationToken)
        {
            this.tokenSource = CancellationTokenSource.CreateLinkedTokenSource(this.tokenSource.Token, cancellationToken);

            await this.headBlock.SendAsync(request, this.tokenSource.Token);
        }

        private ITargetBlock<Request> CreateProcessingNetwork()
        {
            this.Logger.LogInformation("Creating request pipeline");

            this.Logger.LogDebug("Setting up block options");
            var execOpts = new ExecutionDataflowBlockOptions
            {
                MaxDegreeOfParallelism = this.Options.MaxDegreeOfParallelism,
                CancellationToken = this.tokenSource.Token
            };

            var flowOpts = new DataflowLinkOptions
            {
                PropagateCompletion = true
            };

            this.Logger.LogDebug("Setting up blocks");
            var resultBuffer = new BufferBlock<IEnumerable<Response<TData>>>();
            var cacheRequest = new TransformBlock<Request, Request>(r => GetCacheItems(r));
            var messageBatcher = new TransformManyBlock<Request, HttpRequestMessage>(r => BuildMessages(r), execOpts);
            var requestExecutor = new TransformBlock<HttpRequestMessage, IEnumerable<Response<TData>>>(async m => await GetDataAsync(m), execOpts);

            this.Logger.LogDebug("Setting up block links");
            this.Data = resultBuffer.AsObservable();

            this.Logger.LogInformation("Linking blocks.");

            cacheRequest.LinkTo(messageBatcher, flowOpts, r => r != null);
            cacheRequest.LinkTo(DataflowBlock.NullTarget<Request>()); // Just to be save and not clog up the pipeline
            messageBatcher.LinkTo(requestExecutor, flowOpts);
            requestExecutor.LinkTo(resultBuffer, flowOpts);

            return cacheRequest;

            // Retrieve cache items for a given request
            Request GetCacheItems(Request r)
            {
                this.Logger.LogInformation("Retrieving cache items.");

                var allRetrieved = this.GetCacheItems(ref r, out var data);
                resultBuffer.Post(data.Select(i => new Response<TData>
                {
                    Content = (TData)i,
                    Culture = i.Culture,
                    Date = i.Added
                }));

                // If all were retrieved just return null and "break" out of the pipeline
                return allRetrieved ? null : r;
            }

            // Build multiple request messages based on the batch size
            IEnumerable<HttpRequestMessage> BuildMessages(Request request)
            {
                this.Logger.LogInformation("Building request messages");
                var ids = this.GetIdsFromRequest(request).ToList();
                var messageCount = (ids.Count / this.Options.BatchSize) + 1;
                var messages = new List<HttpRequestMessage>(messageCount);

                this.Logger.LogDebug("Retrieve http headers from request");
                var headers = request.Parameters
                    .Where(p => p.Location == ParameterLocation.Header)
                    .Select(i => new KeyValuePair<string, string>(i.Key, i.Value))
                    .ToList();

                this.Logger.LogDebug("Batch messages");
                if (ids.Count == 0)
                {
                    var message = new HttpRequestMessage(HttpMethod.Get, this.Endpoint);
                    message.Headers.AddRange(headers);
                    messages.Add(message);
                }
                else
                {
                    foreach (var idList in ids.BatchBy(messageCount))
                    {
                        var query = $"{this.Endpoint}?ids={string.Join(",", idList)}";
                        var message = new HttpRequestMessage(HttpMethod.Get, query);

                        message.Headers.AddRange(headers);
                        messages.Add(message);
                    }
                }

                return messages;
            }

            // Call the api to get the remaining data
            async Task<IEnumerable<Response<TData>>> GetDataAsync(HttpRequestMessage message)
            {
                this.Logger.LogInformation("Calling Web Service");

                var response = await this.Client.SendAsync<IEnumerable<TApiData>>(message).ConfigureAwait(false);
                var content = response.Content
                    .Select(i => this.DataConverter.Convert(i))
                    .Select(d => new Response<TData>
                    {
                        Content = d,
                        Culture = response.Culture,
                        ExtensionData = response.ExtensionData,
                        Date = response.Date
                    });

                return content;
            }
        }

        /// <summary>Retrieves all non stale items from the cache.</summary>
        /// <param name="request">The request. Modified to only include the non cache retrieveable ids.</param>
        /// <param name="items">The cache items.</param>
        /// <returns>True when all items could be retrieved from the cache, false otherwise.</returns>
        private bool GetCacheItems(ref Request request, out IEnumerable<CacheItem<TData, TKey>> items)
        {
            this.Logger.LogDebug("Get ids from request");
            var ids = this.GetIdsFromRequest(request).ToList();

            this.Logger.LogDebug("Retrieve items from cache");
            var cacheItems = this.Cache.Get(c => ids.Any(i => c.Id.Equals(i.Key)) && c.Culture.Equals(this.Culture)).ToList();
            items = cacheItems;

            this.Logger.LogDebug("Check if all items were retrieved");
            if (cacheItems.Count != ids.Count)
            {
                request.Parameters = request.Parameters.Where(p => ids.Any(i => i.Equals(p))).ToList();
                return false;
            }

            return true;
        }

        private IEnumerable<RequestParameter> GetIdsFromRequest(Request request)
        {
            return request.Parameters.Where(p =>
                p.Key.Equals("id", StringComparison.OrdinalIgnoreCase) ||
                p.Key.Equals(Request.IdParam, StringComparison.OrdinalIgnoreCase));
        }

        #region IDisposable Support
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    // Dispose managed state (managed objects).
                    this.headBlock.Complete();
                    this.tokenSource.Cancel();
                }

                // Free unmanaged resources (unmanaged objects) 
                // and override a finalizer below and and set large fields to null.
                this.Data = null;
                this.disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            this.Dispose(true);
        }
        #endregion
    }
}
