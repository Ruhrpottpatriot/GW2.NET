// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorServiceCache.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides an implementation of the colors service, backed up by a caching provider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Colors
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Runtime.Caching;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Extensions;
    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Builds;
    using GW2DotNET.V1.Colors.Contracts;
    using GW2DotNET.V1.Common;
    using GW2DotNET.V1.Common.Caching;

    /// <summary>Provides an implementation of the colors service, backed up by a caching provider.</summary>
    public class ColorServiceCache : ServiceObjectCache, IColorServiceCache
    {
        /// <summary>Infrastructure. Holds a reference to the default in-memory cache.</summary>
        private static readonly Lazy<ColorServiceCache> DefaultServiceCache = new Lazy<ColorServiceCache>();

        /// <summary>Infrastructure. Holds a reference to the fallback service.</summary>
        private readonly IColorService fallbackService;

        /// <summary>Initializes a new instance of the <see cref="ColorServiceCache" /> class.</summary>
        public ColorServiceCache()
            : this(new ColorService())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ColorServiceCache"/> class.</summary>
        /// <param name="objectCache">The object cache.</param>
        public ColorServiceCache(ObjectCache objectCache)
            : this(objectCache, new ColorService())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ColorServiceCache"/> class.</summary>
        /// <param name="fallbackService">The fallback service.</param>
        public ColorServiceCache(IColorService fallbackService)
            : this(new MemoryCache(Services.Colors), fallbackService)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ColorServiceCache"/> class. Initializes a new instance of the <see cref="BuildServiceCache"/> class.</summary>
        /// <param name="objectCache">The object cache.</param>
        /// <param name="fallbackService">The fallback service.</param>
        public ColorServiceCache(ObjectCache objectCache, IColorService fallbackService)
            : base(objectCache)
        {
            Preconditions.EnsureNotNull(paramName: "fallbackService", value: fallbackService);
            this.fallbackService = fallbackService;
        }

        /// <summary>Gets the default implementation of the service, backed up by an in-memory cache.</summary>
        public static ColorServiceCache Default
        {
            get
            {
                return DefaultServiceCache.Value;
            }
        }

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public IEnumerable<ColorPalette> GetColors()
        {
            return this.GetColors(true);
        }

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public IEnumerable<ColorPalette> GetColors(CultureInfo language)
        {
            return this.GetColors(language, true);
        }

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public IEnumerable<ColorPalette> GetColors(bool allowCache)
        {
            return this.GetColors(ServiceBase.DefaultLanguage, allowCache);
        }

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public IEnumerable<ColorPalette> GetColors(CultureInfo language, bool allowCache)
        {
            if (!allowCache)
            {
                return this.fallbackService.GetColors(language);
            }

            var key = GetKey(language);

            var colors = this.Get<IEnumerable<ColorPalette>>(key);

            if (colors == null)
            {
                this.SetColors(colors = this.fallbackService.GetColors(language), language);
            }

            return colors;
        }

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public Task<IEnumerable<ColorPalette>> GetColorsAsync()
        {
            return this.GetColorsAsync(true);
        }

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public Task<IEnumerable<ColorPalette>> GetColorsAsync(CancellationToken cancellationToken)
        {
            return this.GetColorsAsync(cancellationToken, true);
        }

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public Task<IEnumerable<ColorPalette>> GetColorsAsync(CultureInfo language)
        {
            return this.GetColorsAsync(language, true);
        }

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public Task<IEnumerable<ColorPalette>> GetColorsAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            return this.GetColorsAsync(language, cancellationToken, true);
        }

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public Task<IEnumerable<ColorPalette>> GetColorsAsync(bool allowCache)
        {
            return this.GetColorsAsync(CancellationToken.None, allowCache);
        }

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public Task<IEnumerable<ColorPalette>> GetColorsAsync(CancellationToken cancellationToken, bool allowCache)
        {
            return this.GetColorsAsync(ServiceBase.DefaultLanguage, cancellationToken, allowCache);
        }

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public Task<IEnumerable<ColorPalette>> GetColorsAsync(CultureInfo language, bool allowCache)
        {
            return this.GetColorsAsync(language, CancellationToken.None, allowCache);
        }

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public Task<IEnumerable<ColorPalette>> GetColorsAsync(CultureInfo language, CancellationToken cancellationToken, bool allowCache)
        {
            if (!allowCache)
            {
                return this.fallbackService.GetColorsAsync(language, cancellationToken);
            }

            var key = GetKey(language);

            var colors = this.Get<IEnumerable<ColorPalette>>(key);

            if (colors != null)
            {
                return Task.Factory.FromResult(colors);
            }

            var t1 = this.fallbackService.GetColorsAsync(language, cancellationToken).ContinueWith(
                task =>
                    {
                        this.SetColors(colors = task.Result, language);
                        return colors;
                    }, 
                cancellationToken);

            return t1;
        }

        /// <summary>Sets a collection of colors.</summary>
        /// <param name="colors">A collection of colors.</param>
        /// <param name="language">The language.</param>
        public void SetColors(IEnumerable<ColorPalette> colors, CultureInfo language)
        {
            var absoluteExpiration = DateTimeOffset.Now.AddDays(1D);
            this.SetColors(colors, language, new CacheItemParameters { AbsoluteExpiration = absoluteExpiration });
        }

        /// <summary>Sets a collection of colors.</summary>
        /// <param name="colors">A collection of colors.</param>
        /// <param name="language">The language.</param>
        /// <param name="parameters">The eviction and expiration details.</param>
        public void SetColors(IEnumerable<ColorPalette> colors, CultureInfo language, CacheItemParameters parameters)
        {
            var key = GetKey(language);
            this.Set(key, colors, parameters);
        }

        /// <summary>When overridden in a derived class: specifies how to replace a cache entry that expired.</summary>
        /// <param name="cacheItem">The <see cref="CacheItem"/>.</param>
        /// <param name="parameters">The cache entry parameters.</param>
        /// <returns>The replacement <see cref="CacheItem"/>.</returns>
        /// <remarks>Notes to inheritors: returning null for items that were configured to be removable will cause them to be removed.</remarks>
        protected override CacheItem OnExpiring(CacheItem cacheItem, CacheItemParameters parameters)
        {
            try
            {
                var language = ((IEnumerable<ColorPalette>)cacheItem.Value).First().Language;
                var key = GetKey(language);
                var value = this.GetColors(language, allowCache: false);

                parameters.AbsoluteExpiration = DateTimeOffset.Now.AddDays(1D);

                return new CacheItem(key, value);
            }
            catch (ServiceException)
            {
                parameters.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(1D);
                return cacheItem;
            }
        }

        /// <summary>Infrastructure. Gets the cache item key for the specified language.</summary>
        /// <param name="language">The language.</param>
        /// <returns>The key.</returns>
        private static string GetKey(CultureInfo language)
        {
            return string.Join(".", "colors", language.TwoLetterISOLanguageName);
        }
    }
}