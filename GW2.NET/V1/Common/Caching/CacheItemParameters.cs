// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CacheItemParameters.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a set of eviction and expiration details for a specific cache entry..
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Common.Caching
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Runtime.Caching;

    /// <summary>Represents a set of eviction and expiration details for a specific cache entry..</summary>
    public class CacheItemParameters
    {
        /// <summary>Initializes a new instance of the <see cref="CacheItemParameters"/> class.</summary>
        public CacheItemParameters()
        {
            this.Updatable = true;
            this.Removable = true;
            this.AbsoluteExpiration = ObjectCache.InfiniteAbsoluteExpiration;
            this.SlidingExpiration = ObjectCache.NoSlidingExpiration;
            this.ChangeMonitors = new Collection<ChangeMonitor>();
        }

        /// <summary>Gets or sets a value that indicates whether a cache entry should be evicted after a specified duration.</summary>
        public DateTimeOffset AbsoluteExpiration { get; set; }

        /// <summary>Gets a collection of <see cref="ChangeMonitor"/> objects that are associated with a cache entry.</summary>
        public ICollection<ChangeMonitor> ChangeMonitors { get; private set; }

        /// <summary>Gets or sets a value indicating whether to evict a cache entry..</summary>
        public bool Removable { get; set; }

        /// <summary>Gets or sets a value that indicates whether a cache entry should be evicted if it has not been accessed in a given span of time.</summary>
        public TimeSpan SlidingExpiration { get; set; }

        /// <summary>Gets or sets a value indicating whether a cache entry can be updated instead of being removed from the cache.</summary>
        public bool Updatable { get; set; }
    }
}