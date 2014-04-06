// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventNameServiceCache.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides an implementation of the event names service, backed up by a caching provider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.DynamicEvents.Names
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Runtime.Caching;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Extensions;
    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Common;
    using GW2DotNET.V1.Common.Caching;
    using GW2DotNET.V1.DynamicEvents.Names.Types;

    /// <summary>Provides an implementation of the event names service, backed up by a caching provider.</summary>
    public class DynamicEventNameServiceCache : ServiceObjectCache, IDynamicEventNameServiceCache
    {
        /// <summary>Infrastructure. Holds a reference to the default in-memory cache.</summary>
        private static readonly Lazy<DynamicEventNameServiceCache> DefaultServiceCache = new Lazy<DynamicEventNameServiceCache>();

        /// <summary>Infrastructure. Holds a reference to the fallback service.</summary>
        private readonly IDynamicEventNameService fallbackService;

        /// <summary>Initializes a new instance of the <see cref="DynamicEventNameServiceCache"/> class.</summary>
        public DynamicEventNameServiceCache()
            : this(new DynamicEventNameService())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DynamicEventNameServiceCache"/> class.</summary>
        /// <param name="objectCache">The object Cache.</param>
        public DynamicEventNameServiceCache(ObjectCache objectCache)
            : this(objectCache, new DynamicEventNameService())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DynamicEventNameServiceCache"/> class.</summary>
        /// <param name="fallbackService">The fallback Service.</param>
        public DynamicEventNameServiceCache(IDynamicEventNameService fallbackService)
            : this(new MemoryCache(Services.EventNames), fallbackService)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DynamicEventNameServiceCache"/> class.</summary>
        /// <param name="objectCache">The object Cache.</param>
        /// <param name="fallbackService">The fallback Service.</param>
        public DynamicEventNameServiceCache(ObjectCache objectCache, IDynamicEventNameService fallbackService)
            : base(objectCache)
        {
            Preconditions.EnsureNotNull(paramName: "fallbackService", value: fallbackService);
            this.fallbackService = fallbackService;
        }

        /// <summary>Gets the default implementation of the service, backed up by an in-memory cache.</summary>
        public static DynamicEventNameServiceCache Default
        {
            get
            {
                return DefaultServiceCache.Value;
            }
        }

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEventName> GetDynamicEventNames(bool allowCache)
        {
            return this.GetDynamicEventNames(ServiceBase.DefaultLanguage, allowCache);
        }

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEventName> GetDynamicEventNames(CultureInfo language, bool allowCache)
        {
            if (!allowCache)
            {
                return this.fallbackService.GetDynamicEventNames(language);
            }

            var dynamicEventNames = this.Get<IEnumerable<DynamicEventName>>(GetKey(language));

            if (dynamicEventNames == null)
            {
                this.SetDynamicEventNames(dynamicEventNames = this.fallbackService.GetDynamicEventNames(language), language);
            }

            return dynamicEventNames;
        }

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEventName> GetDynamicEventNames()
        {
            return this.GetDynamicEventNames(true);
        }

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEventName> GetDynamicEventNames(CultureInfo language)
        {
            return this.GetDynamicEventNames(language, true);
        }

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventName>> GetDynamicEventNamesAsync(bool allowCache)
        {
            return this.GetDynamicEventNamesAsync(CancellationToken.None, allowCache);
        }

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventName>> GetDynamicEventNamesAsync(CancellationToken cancellationToken, bool allowCache)
        {
            return this.GetDynamicEventNamesAsync(ServiceBase.DefaultLanguage, cancellationToken, allowCache);
        }

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventName>> GetDynamicEventNamesAsync(CultureInfo language, bool allowCache)
        {
            return this.GetDynamicEventNamesAsync(language, CancellationToken.None, allowCache);
        }

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventName>> GetDynamicEventNamesAsync(CultureInfo language, CancellationToken cancellationToken, bool allowCache)
        {
            if (!allowCache)
            {
                return this.fallbackService.GetDynamicEventNamesAsync(language, cancellationToken);
            }

            var dynamicEventNames = this.Get<IEnumerable<DynamicEventName>>(GetKey(language));

            if (dynamicEventNames != null)
            {
                return Task.Factory.FromResult(dynamicEventNames);
            }

            var t1 = this.fallbackService.GetDynamicEventNamesAsync(language, cancellationToken).ContinueWith(
                task =>
                    {
                        this.SetDynamicEventNames(dynamicEventNames = task.Result, language);
                        return dynamicEventNames;
                    });

            return t1;
        }

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventName>> GetDynamicEventNamesAsync()
        {
            return this.GetDynamicEventNamesAsync(ServiceBase.DefaultLanguage, CancellationToken.None, true);
        }

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventName>> GetDynamicEventNamesAsync(CancellationToken cancellationToken)
        {
            return this.GetDynamicEventNamesAsync(ServiceBase.DefaultLanguage, cancellationToken, true);
        }

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventName>> GetDynamicEventNamesAsync(CultureInfo language)
        {
            return this.GetDynamicEventNamesAsync(language, CancellationToken.None, true);
        }

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventName>> GetDynamicEventNamesAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            return this.GetDynamicEventNamesAsync(language, cancellationToken, true);
        }

        /// <summary>Sets a collection of dynamic events and their localized name.</summary>
        /// <param name="dynamicEventNames">A collection of dynamic events and their localized name.</param>
        /// <param name="language">The language.</param>
        public void SetDynamicEventNames(IEnumerable<DynamicEventName> dynamicEventNames, CultureInfo language)
        {
            var absoluteExpiration = DateTimeOffset.Now.AddDays(1D);
            this.SetDynamicEventNames(dynamicEventNames, language, new CacheItemParameters { AbsoluteExpiration = absoluteExpiration });
        }

        /// <summary>Sets a collection of dynamic events and their localized name.</summary>
        /// <param name="dynamicEventNames">A collection of dynamic events and their localized name.</param>
        /// <param name="language">The language.</param>
        /// <param name="parameters">The eviction and expiration details.</param>
        public void SetDynamicEventNames(IEnumerable<DynamicEventName> dynamicEventNames, CultureInfo language, CacheItemParameters parameters)
        {
            this.Set(GetKey(language), dynamicEventNames, parameters);
        }

        /// <summary>Infrastructure. Gets the cache item key.</summary>
        /// <param name="language">The language.</param>
        /// <returns>The key.</returns>
        private static string GetKey(CultureInfo language)
        {
            return string.Join(".", "event_names", language.TwoLetterISOLanguageName);
        }
    }
}