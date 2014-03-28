// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceMemoryCache.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.ServiceManagement.Caching
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Caching;

    using GW2DotNET.Utilities;

    /// <summary>Represents the type that implements an in-memory cache for service data.</summary>
    public abstract class ServiceMemoryCache : MemoryCache
    {
        private readonly IServiceManager serviceManager;

        /// <summary>Initializes a new instance of the <see cref="ServiceMemoryCache"/> class.</summary>
        /// <param name="name">The name.</param>
        protected ServiceMemoryCache(string name)
            : this(name, new ServiceManager())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceMemoryCache" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="serviceManager">The service manager.</param>
        protected ServiceMemoryCache(string name, IServiceManager serviceManager)
            : base(name)
        {
            Preconditions.EnsureNotNull(paramName: "serviceManager", value: serviceManager);
            this.serviceManager = serviceManager;
        }

        /// <summary>
        /// Gets the service manager.
        /// </summary>
        protected IServiceManager ServiceManager
        {
            get
            {
                return this.serviceManager;
            }
        }

        /// <summary>
        /// Sets the specified cache item.
        /// </summary>
        public void Set(CacheItem item)
        {
            base.Set(item, this.CreatePolicy(item));
        }

        /// <summary>
        /// When overridden, gets the collection of change monitors for the specified cache item.
        /// </summary>
        /// <param name="cacheItem">The cache item.</param>
        /// <returns>The colletion of change monitors</returns>
        protected virtual IEnumerable<ChangeMonitor> GetChangeMonitors(CacheItem cacheItem)
        {
            return Enumerable.Empty<ChangeMonitor>();
        }

        /// <summary>
        /// When overridden, gets the expiration date for the specified cache item.
        /// </summary>
        /// <param name="cacheItem">The cache item.</param>
        /// <returns>The expiration date.</returns>
        protected virtual DateTimeOffset GetExpirationDate(CacheItem cacheItem)
        {
            return ObjectCache.InfiniteAbsoluteExpiration;
        }

        /// <summary>
        /// When overridden, gets the cache priority for the specified cache item.
        /// </summary>
        /// <param name="cacheItem">The cache item.</param>
        /// <returns>The cache priority.</returns>
        protected virtual CacheItemPriority GetPriority(CacheItem cacheItem)
        {
            return CacheItemPriority.Default;
        }

        /// <summary>
        /// Updates the cache item.
        /// </summary>
        /// <param name="oldCacheItem">The old cache item.</param>
        /// <returns>The updated cache item.</returns>
        protected abstract CacheItem UpdateCacheItem(CacheItem oldCacheItem);

        /// <summary>
        /// Creates the cache item policy for the specified cache item.
        /// </summary>
        /// <param name="cacheItem">The cache item.</param>
        /// <param name="expirationDate">The expiration date.</param>
        /// <returns>
        /// The cache item policy.
        /// </returns>
        private CacheItemPolicy CreatePolicy(CacheItem cacheItem, DateTimeOffset? expirationDate = null)
        {
            var policy = new CacheItemPolicy
                             {
                                 AbsoluteExpiration = expirationDate ?? this.GetExpirationDate(cacheItem),
                                 Priority = this.GetPriority(cacheItem),
                                 UpdateCallback = this.UpdateCallback
                             };

            foreach (var changeMonitor in this.GetChangeMonitors(cacheItem))
            {
                policy.ChangeMonitors.Add(changeMonitor);
            }

            return policy;
        }

        /// <summary>
        /// The update callback that is invoked when a cache item has been invalidated.
        /// </summary>
        /// <param name="arguments">The cache entry update arguments.</param>
        private void UpdateCallback(CacheEntryUpdateArguments arguments)
        {
            var oldCacheItem = arguments.Source.GetCacheItem(arguments.Key);
            try
            {
                arguments.UpdatedCacheItem = this.UpdateCacheItem(oldCacheItem);
                arguments.UpdatedCacheItemPolicy = this.CreatePolicy(arguments.UpdatedCacheItem);
            }
            catch (ServiceException)
            {
                if (this.GetPriority(oldCacheItem) != CacheItemPriority.NotRemovable)
                {
                    // allow the framework to remove the cache item
                    return;
                }

                // else try again in 1 minute
                arguments.UpdatedCacheItem = oldCacheItem;
                arguments.UpdatedCacheItemPolicy = this.CreatePolicy(oldCacheItem, DateTimeOffset.Now.AddMinutes(1D));
            }
        }
    }
}