// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceObjectCache.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for cached service implementations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Common.Caching
{
    using System.Runtime.Caching;

    using GW2DotNET.Utilities;

    /// <summary>Provides the base class for cached service implementations.</summary>
    public abstract class ServiceObjectCache
    {
        /// <summary>Infrastructure. Holds a reference to the object cache.</summary>
        private readonly ObjectCache objectCache;

        /// <summary>Initializes a new instance of the <see cref="ServiceObjectCache"/> class.</summary>
        /// <param name="objectCache">The object cache.</param>
        protected ServiceObjectCache(ObjectCache objectCache)
        {
            Preconditions.EnsureNotNull(paramName: "objectCache", value: objectCache);
            this.objectCache = objectCache;
        }

        /// <summary>Gets the specified cache entry from the cache.</summary>
        /// <param name="key">The key.</param>
        /// <typeparam name="T">The type of the cache item.</typeparam>
        /// <returns>The cache item.</returns>
        protected T Get<T>(string key)
        {
            return (T)this.objectCache.Get(key);
        }

        /// <summary>When overridden in a derived class: specifies what to do after a cache entry is removed because of a change monitor event.</summary>
        /// <param name="cacheItem">The removed <see cref="CacheItem"/>.</param>
        /// <remarks>Notes to inheritors: this procedure will not be invoked for items that were configured to be updatable.</remarks>
        protected virtual void OnChangeEventReceivedRemoval(CacheItem cacheItem)
        {
        }

        /// <summary>When overridden in a derived class: specifies how to replace a cache entry after a change monitor event.</summary>
        /// <param name="cacheItem">The <see cref="CacheItem"/>.</param>
        /// <param name="parameters">The cache entry parameters.</param>
        /// <returns>The replacement <see cref="CacheItem"/>.</returns>
        /// <remarks>Notes to inheritors: returning null for items that were configured to be removable will cause them to be removed.</remarks>
        protected virtual CacheItem OnChangeEventReceivedUpdate(CacheItem cacheItem, CacheItemParameters parameters)
        {
            return null;
        }

        /// <summary>When overridden in a derived class: specifies what to do after a cache entry is evicted to free memory.</summary>
        /// <param name="cacheItem">The <see cref="CacheItem"/>.</param>
        /// <remarks>Notes to inheritors: this procedure will not be invoked for items that were configured to be updatable.</remarks>
        protected virtual void OnEvicted(CacheItem cacheItem)
        {
        }

        /// <summary>When overridden in a derived class: specifies what to do after a cache entry is evicted for a cache-specific reason.</summary>
        /// <param name="cacheItem">The <see cref="CacheItem"/>.</param>
        /// <remarks>Notes to inheritors: this procedure will not be invoked for items that were configured to be updatable.</remarks>
        protected virtual void OnEvictedCacheSpecific(CacheItem cacheItem)
        {
        }

        /// <summary>When overridden in a derived class: specifies how to replace a cache entry that is evicted to free memory.</summary>
        /// <param name="cacheItem">The <see cref="CacheItem"/>.</param>
        /// <param name="parameters">The cache entry parameters.</param>
        /// <returns>The replacement <see cref="CacheItem"/>.</returns>
        /// <remarks>Notes to inheritors: returning null for items that were configured to be removable will cause them to be removed.</remarks>
        protected virtual CacheItem OnEvicting(CacheItem cacheItem, CacheItemParameters parameters)
        {
            return null;
        }

        /// <summary>When overridden in a derived class: specifies how to replace a cache entry that is evicted for a cache-specific reason.</summary>
        /// <param name="cacheItem">The <see cref="CacheItem"/>.</param>
        /// <param name="parameters">The cache entry parameters.</param>
        /// <returns>The replacement <see cref="CacheItem"/>.</returns>
        /// <remarks>Notes to inheritors: returning null for items that were configured to be removable will cause them to be removed.</remarks>
        protected virtual CacheItem OnEvictingCacheSpecific(CacheItem cacheItem, CacheItemParameters parameters)
        {
            return null;
        }

        /// <summary>When overridden in a derived class: specifies what to do after a cache entry was removed because it expired.</summary>
        /// <param name="cacheItem">The <see cref="CacheItem"/>.</param>
        /// <remarks>Notes to inheritors: this procedure will not be invoked for items that were configured to be updatable.</remarks>
        protected virtual void OnExpired(CacheItem cacheItem)
        {
        }

        /// <summary>When overridden in a derived class: specifies how to replace a cache entry that expired.</summary>
        /// <param name="cacheItem">The <see cref="CacheItem"/>.</param>
        /// <param name="parameters">The cache entry parameters.</param>
        /// <returns>The replacement <see cref="CacheItem"/>.</returns>
        /// <remarks>Notes to inheritors: returning null for items that were configured to be removable will cause them to be removed.</remarks>
        protected virtual CacheItem OnExpiring(CacheItem cacheItem, CacheItemParameters parameters)
        {
            return null;
        }

        /// <summary>When overridden in a derived class: specifies what to do after a cache entry was explicitly removed.</summary>
        /// <param name="cacheItem">The <see cref="CacheItem"/>.</param>
        /// <remarks>Notes to inheritors: this procedure will not be invoked for items that were configured to be updatable.</remarks>
        protected virtual void OnRemoved(CacheItem cacheItem)
        {
        }

        /// <summary>When overridden in a derived class: specifies how to replace a cache entry that was explicitly removed.</summary>
        /// <param name="cacheItem">The <see cref="CacheItem"/>.</param>
        /// <param name="parameters">The cache entry parameters.</param>
        /// <returns>The replacement <see cref="CacheItem"/>.</returns>
        /// <remarks>Notes to inheritors: returning null for items that were configured to be removable will cause them to be removed.</remarks>
        protected virtual CacheItem OnRemoving(CacheItem cacheItem, CacheItemParameters parameters)
        {
            return null;
        }

        /// <summary>Registers the specified cache item.</summary>
        /// <param name="key">The key.</param>
        /// <param name="item">The cache item.</param>
        /// <param name="parameters">The cache entry parameters.</param>
        /// <typeparam name="T">The type of the cache item.</typeparam>
        protected void Set<T>(string key, T item, CacheItemParameters parameters)
        {
            var cacheItem = new CacheItem(key, item);
            var policy = this.GetPolicy(parameters);

            this.objectCache.Set(cacheItem, policy);
        }

        /// <summary>Infrastructure. Gets a set of eviction and expiration details based on the specified cache entry parameters.</summary>
        /// <param name="parameters">The cache entry parameters.</param>
        /// <returns>The <see cref="CacheItemPolicy"/>.</returns>
        private CacheItemPolicy GetPolicy(CacheItemParameters parameters)
        {
            var policy = new CacheItemPolicy()
                             {
                                 AbsoluteExpiration = parameters.AbsoluteExpiration, 
                                 Priority = parameters.Removable ? CacheItemPriority.Default : CacheItemPriority.NotRemovable, 
                             };

            if (parameters.Updatable)
            {
                policy.UpdateCallback = this.OnUpdateCallback;
            }
            else
            {
                policy.RemovedCallback = this.OnRemovedCallback;
            }

            foreach (var changeMonitor in parameters.ChangeMonitors)
            {
                policy.ChangeMonitors.Add(changeMonitor);
            }

            return policy;
        }

        /// <summary>Infrastructure. The method that is called after a cache entry is removed.</summary>
        /// <param name="arguments">The <see cref="CacheEntryRemovedArguments"/>.</param>
        private void OnRemovedCallback(CacheEntryRemovedArguments arguments)
        {
            var oldCacheItem = arguments.CacheItem;

            switch (arguments.RemovedReason)
            {
                case CacheEntryRemovedReason.Removed:
                    this.OnRemoved(oldCacheItem);
                    break;
                case CacheEntryRemovedReason.Expired:
                    this.OnExpired(oldCacheItem);
                    break;
                case CacheEntryRemovedReason.Evicted:
                    this.OnEvicted(oldCacheItem);
                    break;
                case CacheEntryRemovedReason.ChangeMonitorChanged:
                    this.OnChangeEventReceivedRemoval(oldCacheItem);
                    break;
                case CacheEntryRemovedReason.CacheSpecificEviction:
                    this.OnEvictedCacheSpecific(oldCacheItem);
                    break;
            }
        }

        /// <summary>Infrastructure. The method that is called before a cache entry is removed.</summary>
        /// <param name="arguments">The <see cref="CacheEntryUpdateArguments"/>.</param>
        private void OnUpdateCallback(CacheEntryUpdateArguments arguments)
        {
            var oldCacheItem = arguments.Source.GetCacheItem(arguments.Key);
            var parameters = new CacheItemParameters();
            switch (arguments.RemovedReason)
            {
                case CacheEntryRemovedReason.Removed:
                    arguments.UpdatedCacheItem = this.OnRemoving(oldCacheItem, parameters);
                    break;
                case CacheEntryRemovedReason.Expired:
                    arguments.UpdatedCacheItem = this.OnExpiring(oldCacheItem, parameters);
                    break;
                case CacheEntryRemovedReason.Evicted:
                    arguments.UpdatedCacheItem = this.OnEvicting(oldCacheItem, parameters);
                    break;
                case CacheEntryRemovedReason.ChangeMonitorChanged:
                    arguments.UpdatedCacheItem = this.OnChangeEventReceivedUpdate(oldCacheItem, parameters);
                    break;
                case CacheEntryRemovedReason.CacheSpecificEviction:
                    arguments.UpdatedCacheItem = this.OnEvictingCacheSpecific(oldCacheItem, parameters);
                    break;
            }

            if (arguments.UpdatedCacheItem == null)
            {
                arguments.UpdatedCacheItemPolicy = this.GetPolicy(parameters);
            }
        }
    }
}