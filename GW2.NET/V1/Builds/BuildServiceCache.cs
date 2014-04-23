// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BuildServiceCache.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides an implementation of the build service, backed up by a caching provider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Builds
{
    using System;
    using System.Runtime.Caching;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Extensions;
    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Builds.Contracts;
    using GW2DotNET.V1.Common;
    using GW2DotNET.V1.Common.Caching;

    /// <summary>Provides an implementation of the build service, backed up by a caching provider.</summary>
    public class BuildServiceCache : ServiceObjectCache, IBuildServiceCache
    {
        /// <summary>Infrastructure. Holds a reference to the default in-memory cache.</summary>
        private static readonly Lazy<BuildServiceCache> DefaultServiceCache = new Lazy<BuildServiceCache>();

        /// <summary>Infrastructure. Holds a reference to the fallback service.</summary>
        private readonly IBuildService fallbackService;

        /// <summary>Initializes a new instance of the <see cref="BuildServiceCache"/> class.</summary>
        public BuildServiceCache()
            : this(new BuildService())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="BuildServiceCache"/> class.</summary>
        /// <param name="objectCache">The object Cache.</param>
        public BuildServiceCache(ObjectCache objectCache)
            : this(objectCache, new BuildService())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="BuildServiceCache"/> class.</summary>
        /// <param name="fallbackService">The fallback Service.</param>
        public BuildServiceCache(IBuildService fallbackService)
            : this(new MemoryCache(Services.Build), fallbackService)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="BuildServiceCache"/> class.</summary>
        /// <param name="objectCache">The object Cache.</param>
        /// <param name="fallbackService">The fallback Service.</param>
        public BuildServiceCache(ObjectCache objectCache, IBuildService fallbackService)
            : base(objectCache)
        {
            Preconditions.EnsureNotNull(paramName: "fallbackService", value: fallbackService);
            this.fallbackService = fallbackService;
        }

        /// <summary>Gets the default implementation of the service, backed up by an in-memory cache.</summary>
        public static BuildServiceCache Default
        {
            get
            {
                return DefaultServiceCache.Value;
            }
        }

        /// <summary>Gets the current game build.</summary>
        /// <returns>The current game build.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/build">wiki</a> for more information.</remarks>
        public Build GetBuild()
        {
            return this.GetBuild(true);
        }

        /// <summary>Gets the current game build.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>The current game build.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/build">wiki</a> for more information.</remarks>
        public Build GetBuild(bool allowCache)
        {
            if (!allowCache)
            {
                return this.fallbackService.GetBuild();
            }

            var build = this.Get<Build>(GetKey());

            if (build == null)
            {
                this.SetBuild(build = this.fallbackService.GetBuild());
            }

            return build;
        }

        /// <summary>Gets the current build.</summary>
        /// <returns>The current game build.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/build">wiki</a> for more information.</remarks>
        public Task<Build> GetBuildAsync()
        {
            return this.GetBuildAsync(true);
        }

        /// <summary>Gets the current build.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The current game build.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/build">wiki</a> for more information.</remarks>
        public Task<Build> GetBuildAsync(CancellationToken cancellationToken)
        {
            return this.GetBuildAsync(cancellationToken, true);
        }

        /// <summary>Gets the current build.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>The current game build.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/build">wiki</a> for more information.</remarks>
        public Task<Build> GetBuildAsync(bool allowCache)
        {
            return this.GetBuildAsync(CancellationToken.None, allowCache);
        }

        /// <summary>Gets the current build.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>The current game build.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/build">wiki</a> for more information.</remarks>
        public Task<Build> GetBuildAsync(CancellationToken cancellationToken, bool allowCache)
        {
            if (!allowCache)
            {
                return this.fallbackService.GetBuildAsync(cancellationToken);
            }

            var build = this.Get<Build>(GetKey());

            if (build != null)
            {
                return Task.Factory.FromResult(build);
            }

            var t1 = this.fallbackService.GetBuildAsync(cancellationToken).ContinueWith(
                task =>
                    {
                        this.SetBuild(build = task.Result);
                        return build;
                    }, 
                cancellationToken);

            return t1;
        }

        /// <summary>Sets the current game build.</summary>
        /// <param name="build">The build.</param>
        public void SetBuild(Build build)
        {
            var absoluteExpiration = DateTimeOffset.Now.AddMinutes(10D);
            this.SetBuild(build, new CacheItemParameters { AbsoluteExpiration = absoluteExpiration });
        }

        /// <summary>Sets the current game build.</summary>
        /// <param name="build">The build.</param>
        /// <param name="parameters">The eviction and expiration details.</param>
        public void SetBuild(Build build, CacheItemParameters parameters)
        {
            this.Set(GetKey(), build, parameters);
        }

        /// <summary>When overridden in a derived class: specifies how to replace a cache entry that expired.</summary>
        /// <param name="cacheItem">The <see cref="CacheItem"/>.</param>
        /// <param name="parameters">The cache entry parameters.</param>
        /// <returns>The replacement <see cref="CacheItem"/>.</returns>
        /// <remarks>Notes to inheritors: returning null for items that were configured to be removable will cause them to be removed.</remarks>
        protected override CacheItem OnExpiring(CacheItem cacheItem, CacheItemParameters parameters)
        {
            parameters.Updatable = true;
            try
            {
                parameters.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(10D);
                return new CacheItem(GetKey(), this.GetBuild(allowCache: false));
            }
            catch (ServiceException)
            {
                parameters.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(1D);
                return cacheItem;
            }
        }

        /// <summary>Infrastructure. Gets the cache item key.</summary>
        /// <returns>The key.</returns>
        private static string GetKey()
        {
            return "build";
        }
    }
}