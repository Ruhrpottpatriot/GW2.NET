// <copyright file="Repository.cs" company="GW2.NET Coding Team">
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
    using Converters;
    using Microsoft.Extensions.Logging;

    public abstract class Repository<TApiData, TData, TKey> : ILocalizable, IDisposable
        where TData : IKey<TKey>, ILocalizable
        where TKey : IEquatable<TKey>
    {
        private readonly ITargetBlock<IRequest> headBlock;
        private bool disposed;
        private CancellationTokenSource tokenSource;

        protected Repository(IServiceClient client, ILogger<Repository<TApiData, TData, TKey>> logger, IConverter<TApiData, TData> dataConverter, ICache<TData, TKey> cache, RepositoryOptions options)
        {
            this.tokenSource = new CancellationTokenSource();

            this.headBlock = this.CreateProcessingNetwork();

            this.Client = client;
            this.Logger = logger;
            this.DataConverter = dataConverter;
            this.Cache = cache;
            this.Options = options;
        }

        public IObservable<IEnumerable<ApiData<TData>>> Data { get; set; }

        public ILogger<Repository<TApiData, TData, TKey>> Logger { get; }

        public IServiceClient Client { get; }

        public IConverter<TApiData, TData> DataConverter { get; }

        public ICache<TData, TKey> Cache { get; }

        public RepositoryOptions Options { get; }

        /// <inheritdoc />
        public CultureInfo Culture { get; set; }

        /// <summary>Gets the endpoint Uri.</summary>
        public abstract Uri Endpoint { get; }

        public Task RequestAsync(IRequest request)
        {
            return this.RequestAsync(request, CancellationToken.None);
        }

        public async Task RequestAsync(IRequest request, CancellationToken cancellationToken)
        {
            this.tokenSource = CancellationTokenSource.CreateLinkedTokenSource(this.tokenSource.Token, cancellationToken);

            await this.headBlock.SendAsync(request, this.tokenSource.Token);
        }

        private ITargetBlock<IRequest> CreateProcessingNetwork()
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
            var resultBuffer = new BufferBlock<IEnumerable<ApiData<TData>>>();
            var cacheRequest = new TransformBlock<IRequest, IRequest>(r => GetCacheItems(r));
            var messageBatcher = new TransformManyBlock<IRequest, HttpRequestMessage>(r => BuildMessages(r), execOpts);
            var requestExecutor = new TransformBlock<HttpRequestMessage, IEnumerable<ApiData<TData>>>(async m => await GetDataAsync(m), execOpts);

            this.Logger.LogDebug("Setting up block links");
            this.Data = resultBuffer.AsObservable();

            cacheRequest.LinkTo(messageBatcher, flowOpts, r => r != null);
            cacheRequest.LinkTo(DataflowBlock.NullTarget<IRequest>()); // Just to be save and not clog up the pipeline
            messageBatcher.LinkTo(requestExecutor, flowOpts);
            requestExecutor.LinkTo(resultBuffer, flowOpts);

            return cacheRequest;

            // Retrieve cache items for a given request
            IRequest GetCacheItems(IRequest r)
            {
                this.Logger.LogInformation("Retrieving cache items.");
                var allRetrieved = this.GetCacheItems(ref r, out var data);
                resultBuffer.Post(data.Select(i => new ApiData<TData>
                {
                    Content = (TData)i,
                    Culture = i.Culture,
                    Date = i.Added
                }));

                // If all could be retrieved just return null and "break" out of the pipeline
                return allRetrieved ? null : r;
            }

            // Build multiple request messages based on the batch size
            IEnumerable<HttpRequestMessage> BuildMessages(IRequest request)
            {
                this.Logger.LogInformation("Building request messages");

                this.Logger.LogDebug("Get http headers from request");
                var headers = request.Parameters
                    .Where(p => p.Location == ParameterLocation.Header)
                    .Select(i => new KeyValuePair<string, string>(i.Key, i.Value))
                    .ToList();

                this.Logger.LogDebug("Checking request type based on header");
                if (headers.Any(p => p.Key.Equals("page")))
                {
                    this.Logger.LogDebug("Creating page requests");

                    int.TryParse(headers.SingleOrDefault(p => p.Key.Equals("page")).Value, out var startPage);
                    int.TryParse(headers.SingleOrDefault(p => p.Key.Equals("page")).Value, out var endPage);
                    int numberOfPages = endPage - startPage;

                    IList<HttpRequestMessage> messages = new List<HttpRequestMessage>(numberOfPages);
                    for (int i = startPage; i < endPage + 1; i++)
                    {
                        HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, this.Endpoint);
                        message.Headers.AddRange(headers.Where(h => !h.Key.Equals("end_page", StringComparison.OrdinalIgnoreCase) || !h.Key.Equals("page", StringComparison.OrdinalIgnoreCase)));

                        message.Headers.Add("page", i.ToString());

                        messages.Add(message);
                    }

                    return messages;
                }
                else
                {
                    this.Logger.LogDebug("Creating normal request");

                    var ids = this.GetIdsFromRequest(request).ToList();
                    var messageCount = (ids.Count / this.Options.MaxBatchSize) + 1;
                    var messages = new List<HttpRequestMessage>(messageCount);

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
            }

            // Call the api to get the remaining data
            async Task<IEnumerable<ApiData<TData>>> GetDataAsync(HttpRequestMessage message)
            {
                this.Logger.LogDebug("Creating cancellation token to properly timeout the reuqests");
                var timeoutSource = CancellationTokenSource.CreateLinkedTokenSource(this.tokenSource.Token, new CancellationTokenSource(this.Options.Timeout).Token);

                this.Logger.LogInformation("Calling Web Service");
                var response = await this.Client.SendAsync<IEnumerable<TApiData>>(message, timeoutSource.Token).ConfigureAwait(false);
                var content = response.Content
                    .Select(d => this.DataConverter.Convert(d))
                    .Select(d => new ApiData<TData>
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
        private bool GetCacheItems(ref IRequest request, out IEnumerable<CacheItem<TData, TKey>> items)
        {
            this.Logger.LogDebug("Get ids from request");
            var ids = this.GetIdsFromRequest(request).ToList();
            if (ids.Count == 0)
            {
                items = Enumerable.Empty<CacheItem<TData, TKey>>();
                return false;
            }

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

        private IEnumerable<RequestParameter> GetIdsFromRequest(IRequest request)
        {
            return request.Parameters.Where(p =>
                p.Key.Equals("id", StringComparison.OrdinalIgnoreCase) ||
                p.Key.Equals("ids", StringComparison.OrdinalIgnoreCase));
        }

        #region IDisposable Support
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
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
                this.disposed = true;
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
