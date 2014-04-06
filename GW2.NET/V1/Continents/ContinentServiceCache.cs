// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContinentServiceCache.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides an implementation of the continents service, backed up by a caching provider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Continents
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Caching;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Extensions;
    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Common;
    using GW2DotNET.V1.Common.Caching;
    using GW2DotNET.V1.Continents.Types;

    /// <summary>Provides an implementation of the continents service, backed up by a caching provider.</summary>
    public class ContinentServiceCache : ServiceObjectCache, IContinentServiceCache
    {
        /// <summary>Infrastructure. Holds a reference to the default in-memory cache.</summary>
        private static readonly Lazy<ContinentServiceCache> DefaultServiceCache = new Lazy<ContinentServiceCache>();

        /// <summary>Infrastructure. Holds a reference to the fallback service.</summary>
        private readonly IContinentService fallbackService;

        /// <summary>Initializes a new instance of the <see cref="ContinentServiceCache"/> class.</summary>
        public ContinentServiceCache()
            : this(new ContinentService())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ContinentServiceCache"/> class.</summary>
        /// <param name="objectCache">The object Cache.</param>
        public ContinentServiceCache(ObjectCache objectCache)
            : this(objectCache, new ContinentService())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ContinentServiceCache"/> class.</summary>
        /// <param name="fallbackService">The fallback Service.</param>
        public ContinentServiceCache(IContinentService fallbackService)
            : this(new MemoryCache(Services.Continents), fallbackService)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ContinentServiceCache"/> class.</summary>
        /// <param name="objectCache">The object Cache.</param>
        /// <param name="fallbackService">The fallback Service.</param>
        public ContinentServiceCache(ObjectCache objectCache, IContinentService fallbackService)
            : base(objectCache)
        {
            Preconditions.EnsureNotNull(paramName: "fallbackService", value: fallbackService);
            this.fallbackService = fallbackService;
        }

        /// <summary>Gets the default implementation of the service, backed up by an in-memory cache.</summary>
        public static ContinentServiceCache Default
        {
            get
            {
                return DefaultServiceCache.Value;
            }
        }

        /// <summary>Gets a collection of continents and their details.</summary>
        /// <returns>A collection of continents.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        public IEnumerable<Continent> GetContinents()
        {
            return this.GetContinents(true);
        }

        /// <summary>Gets a collection of continents and their details.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of continents.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        public IEnumerable<Continent> GetContinents(bool allowCache)
        {
            if (!allowCache)
            {
                return this.fallbackService.GetContinents();
            }

            var continents = this.Get<IEnumerable<Continent>>(GetKey());

            if (continents == null)
            {
                this.SetContinents(continents = this.fallbackService.GetContinents());
            }

            return continents;
        }

        /// <summary>Gets a collection of continents and their details.</summary>
        /// <returns>A collection of continents.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Continent>> GetContinentsAsync()
        {
            return this.GetContinentsAsync(true);
        }

        /// <summary>Gets a collection of continents and their details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of continents.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Continent>> GetContinentsAsync(CancellationToken cancellationToken)
        {
            return this.GetContinentsAsync(cancellationToken, true);
        }

        /// <summary>Gets a collection of continents and their details.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of continents.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Continent>> GetContinentsAsync(bool allowCache)
        {
            return this.GetContinentsAsync(CancellationToken.None, allowCache);
        }

        /// <summary>Gets a collection of continents and their details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of continents.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Continent>> GetContinentsAsync(CancellationToken cancellationToken, bool allowCache)
        {
            if (!allowCache)
            {
                return this.fallbackService.GetContinentsAsync(cancellationToken);
            }

            var continents = this.Get<IEnumerable<Continent>>(GetKey());

            if (continents != null)
            {
                return Task.Factory.FromResult(continents);
            }

            var t1 = this.fallbackService.GetContinentsAsync(cancellationToken).ContinueWith(
                task =>
                    {
                        this.SetContinents(continents = task.Result);
                        return continents;
                    }, 
                cancellationToken);

            return t1;
        }

        /// <summary>Sets a collection of continents.</summary>
        /// <param name="continents">A collection of continents.</param>
        public void SetContinents(IEnumerable<Continent> continents)
        {
            var absoluteExpiration = DateTimeOffset.Now.AddDays(1D);
            this.SetContinents(continents, new CacheItemParameters { AbsoluteExpiration = absoluteExpiration });
        }

        /// <summary>Sets a collection of continents.</summary>
        /// <param name="continents">A collection of continents.</param>
        /// <param name="parameters">The eviction and expiration details.</param>
        public void SetContinents(IEnumerable<Continent> continents, CacheItemParameters parameters)
        {
            this.Set(GetKey(), continents, parameters);
        }

        /// <summary>Infrastructure. Gets the cache item key.</summary>
        /// <returns>The key.</returns>
        private static string GetKey()
        {
            return "continents";
        }
    }
}