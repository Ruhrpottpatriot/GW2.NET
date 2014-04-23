// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventDetailsServiceCache.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides an implementation of the event details service, backed up by a caching provider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.DynamicEvents.Details
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
    using GW2DotNET.V1.Common;
    using GW2DotNET.V1.Common.Caching;
    using GW2DotNET.V1.DynamicEvents.Details.Contracts;

    /// <summary>Provides an implementation of the event details service, backed up by a caching provider.</summary>
    public class DynamicEventDetailsServiceCache : ServiceObjectCache, IDynamicEventDetailsServiceCache
    {
        /// <summary>Infrastructure. Holds a reference to the default in-memory cache.</summary>
        private static readonly Lazy<DynamicEventDetailsServiceCache> DefaultServiceCache = new Lazy<DynamicEventDetailsServiceCache>();

        /// <summary>Infrastructure. Holds a reference to the fallback service.</summary>
        private readonly IDynamicEventDetailsService fallbackService;

        /// <summary>Initializes a new instance of the <see cref="DynamicEventDetailsServiceCache"/> class.</summary>
        public DynamicEventDetailsServiceCache()
            : this(new DynamicEventDetailsService())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DynamicEventDetailsServiceCache"/> class.</summary>
        /// <param name="objectCache">The object Cache.</param>
        public DynamicEventDetailsServiceCache(ObjectCache objectCache)
            : this(objectCache, new DynamicEventDetailsService())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DynamicEventDetailsServiceCache"/> class.</summary>
        /// <param name="fallbackService">The fallback Service.</param>
        public DynamicEventDetailsServiceCache(IDynamicEventDetailsService fallbackService)
            : this(new MemoryCache(Services.EventDetails), fallbackService)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DynamicEventDetailsServiceCache"/> class.</summary>
        /// <param name="objectCache">The object Cache.</param>
        /// <param name="fallbackService">The fallback Service.</param>
        public DynamicEventDetailsServiceCache(ObjectCache objectCache, IDynamicEventDetailsService fallbackService)
            : base(objectCache)
        {
            Preconditions.EnsureNotNull(paramName: "fallbackService", value: fallbackService);
            this.fallbackService = fallbackService;
        }

        /// <summary>Gets the default implementation of the service, backed up by an in-memory cache.</summary>
        public static DynamicEventDetailsServiceCache Default
        {
            get
            {
                return DefaultServiceCache.Value;
            }
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEventDetails> GetDynamicEventDetails(bool allowCache)
        {
            return this.GetDynamicEventDetails(ServiceBase.DefaultLanguage, allowCache);
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEventDetails> GetDynamicEventDetails(CultureInfo language, bool allowCache)
        {
            if (!allowCache)
            {
                return this.fallbackService.GetDynamicEventDetails(language);
            }

            var dynamicEventDetails = this.Get<IEnumerable<DynamicEventDetails>>(GetKey(language));

            if (dynamicEventDetails == null)
            {
                this.SetDynamicEventDetails(dynamicEventDetails = this.fallbackService.GetDynamicEventDetails(language), language);
            }

            return dynamicEventDetails;
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public DynamicEventDetails GetDynamicEventDetails(Guid eventId, bool allowCache)
        {
            return this.GetDynamicEventDetails(eventId, ServiceBase.DefaultLanguage, allowCache);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="language">The language.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public DynamicEventDetails GetDynamicEventDetails(Guid eventId, CultureInfo language, bool allowCache)
        {
            if (!allowCache)
            {
                return this.fallbackService.GetDynamicEventDetails(eventId, language);
            }

            var dynamicEventDetails = this.Get<DynamicEventDetails>(GetKey(eventId, language));

            if (dynamicEventDetails == null)
            {
                var allDynamicEventDetails = this.Get<IEnumerable<DynamicEventDetails>>(GetKey(language));
                if (allDynamicEventDetails != null)
                {
                    dynamicEventDetails = allDynamicEventDetails.SingleOrDefault(details => details.EventId == eventId);
                }
            }

            if (dynamicEventDetails == null)
            {
                this.SetDynamicEventDetails(dynamicEventDetails = this.fallbackService.GetDynamicEventDetails(eventId, language), language);
            }

            return dynamicEventDetails;
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEventDetails> GetDynamicEventDetails()
        {
            return this.GetDynamicEventDetails(true);
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEventDetails> GetDynamicEventDetails(CultureInfo language)
        {
            return this.GetDynamicEventDetails(language, true);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public DynamicEventDetails GetDynamicEventDetails(Guid eventId)
        {
            return this.GetDynamicEventDetails(eventId, true);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="language">The language.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public DynamicEventDetails GetDynamicEventDetails(Guid eventId, CultureInfo language)
        {
            return this.GetDynamicEventDetails(eventId, language, true);
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventDetails>> GetDynamicEventDetailsAsync(bool allowCache)
        {
            return this.GetDynamicEventDetailsAsync(ServiceBase.DefaultLanguage, CancellationToken.None, allowCache);
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventDetails>> GetDynamicEventDetailsAsync(CancellationToken cancellationToken, bool allowCache)
        {
            return this.GetDynamicEventDetailsAsync(ServiceBase.DefaultLanguage, cancellationToken, allowCache);
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventDetails>> GetDynamicEventDetailsAsync(CultureInfo language, bool allowCache)
        {
            return this.GetDynamicEventDetailsAsync(language, CancellationToken.None, allowCache);
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventDetails>> GetDynamicEventDetailsAsync(CultureInfo language, CancellationToken cancellationToken, bool allowCache)
        {
            if (!allowCache)
            {
                return this.fallbackService.GetDynamicEventDetailsAsync(language, cancellationToken);
            }

            var dynamicEventDetails = this.Get<IEnumerable<DynamicEventDetails>>(GetKey(language));

            if (dynamicEventDetails != null)
            {
                return Task.Factory.FromResult(dynamicEventDetails);
            }

            return this.fallbackService.GetDynamicEventDetailsAsync(language, cancellationToken).ContinueWith(
                task =>
                    {
                        this.SetDynamicEventDetails(dynamicEventDetails = task.Result, language);
                        return dynamicEventDetails;
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<DynamicEventDetails> GetDynamicEventDetailsAsync(Guid eventId, bool allowCache)
        {
            return this.GetDynamicEventDetailsAsync(eventId, ServiceBase.DefaultLanguage, CancellationToken.None, allowCache);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<DynamicEventDetails> GetDynamicEventDetailsAsync(Guid eventId, CancellationToken cancellationToken, bool allowCache)
        {
            return this.GetDynamicEventDetailsAsync(eventId, ServiceBase.DefaultLanguage, cancellationToken, allowCache);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="language">The language.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<DynamicEventDetails> GetDynamicEventDetailsAsync(Guid eventId, CultureInfo language, bool allowCache)
        {
            return this.GetDynamicEventDetailsAsync(eventId, language, CancellationToken.None, allowCache);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<DynamicEventDetails> GetDynamicEventDetailsAsync(Guid eventId, CultureInfo language, CancellationToken cancellationToken, bool allowCache)
        {
            if (!allowCache)
            {
                return this.fallbackService.GetDynamicEventDetailsAsync(eventId, language, cancellationToken);
            }

            var dynamicEventDetails = this.Get<DynamicEventDetails>(GetKey(eventId, language));

            if (dynamicEventDetails == null)
            {
                var allDynamicEventDetails = this.Get<IEnumerable<DynamicEventDetails>>(GetKey(language));
                if (allDynamicEventDetails != null)
                {
                    dynamicEventDetails = allDynamicEventDetails.SingleOrDefault(details => details.EventId == eventId);
                }
            }

            if (dynamicEventDetails != null)
            {
                return Task.Factory.FromResult(dynamicEventDetails);
            }

            return this.fallbackService.GetDynamicEventDetailsAsync(eventId, language, cancellationToken).ContinueWith(
                task =>
                    {
                        this.SetDynamicEventDetails(dynamicEventDetails = task.Result, language);
                        return dynamicEventDetails;
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventDetails>> GetDynamicEventDetailsAsync()
        {
            return this.GetDynamicEventDetailsAsync(true);
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventDetails>> GetDynamicEventDetailsAsync(CancellationToken cancellationToken)
        {
            return this.GetDynamicEventDetailsAsync(cancellationToken, true);
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventDetails>> GetDynamicEventDetailsAsync(CultureInfo language)
        {
            return this.GetDynamicEventDetailsAsync(language, true);
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventDetails>> GetDynamicEventDetailsAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            return this.GetDynamicEventDetailsAsync(language, cancellationToken, true);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<DynamicEventDetails> GetDynamicEventDetailsAsync(Guid eventId)
        {
            return this.GetDynamicEventDetailsAsync(eventId, true);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<DynamicEventDetails> GetDynamicEventDetailsAsync(Guid eventId, CancellationToken cancellationToken)
        {
            return this.GetDynamicEventDetailsAsync(eventId, cancellationToken, true);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="language">The language.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<DynamicEventDetails> GetDynamicEventDetailsAsync(Guid eventId, CultureInfo language)
        {
            return this.GetDynamicEventDetailsAsync(eventId, language, true);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<DynamicEventDetails> GetDynamicEventDetailsAsync(Guid eventId, CultureInfo language, CancellationToken cancellationToken)
        {
            return this.GetDynamicEventDetailsAsync(eventId, language, cancellationToken, true);
        }

        /// <summary>Sets a collection of dynamic events and their localized details.</summary>
        /// <param name="dynamicEventDetails">A collection of dynamic events and their localized details.</param>
        /// <param name="language">The language.</param>
        public void SetDynamicEventDetails(IEnumerable<DynamicEventDetails> dynamicEventDetails, CultureInfo language)
        {
            var absoluteExpiration = DateTimeOffset.Now.AddDays(1D);
            this.SetDynamicEventDetails(dynamicEventDetails, language, new CacheItemParameters { AbsoluteExpiration = absoluteExpiration });
        }

        /// <summary>Sets a dynamic event and its localized details.</summary>
        /// <param name="dynamicEventDetails">A dynamic event and its localized details.</param>
        /// <param name="language">The language.</param>
        public void SetDynamicEventDetails(DynamicEventDetails dynamicEventDetails, CultureInfo language)
        {
            var absoluteExpiration = DateTimeOffset.Now.AddDays(1D);
            this.SetDynamicEventDetails(dynamicEventDetails, language, new CacheItemParameters { AbsoluteExpiration = absoluteExpiration, Updatable = false });
        }

        /// <summary>Sets a dynamic event and its localized details.</summary>
        /// <param name="dynamicEventDetails">A dynamic event and its localized details.</param>
        /// <param name="language">The language.</param>
        /// <param name="parameters">The eviction and expiration details.</param>
        public void SetDynamicEventDetails(DynamicEventDetails dynamicEventDetails, CultureInfo language, CacheItemParameters parameters)
        {
            this.Set(GetKey(dynamicEventDetails.EventId, language), dynamicEventDetails, parameters);
        }

        /// <summary>Sets a collection of dynamic events and their localized details.</summary>
        /// <param name="dynamicEventDetails">A collection of dynamic events and their localized details.</param>
        /// <param name="language">The language.</param>
        /// <param name="parameters">The eviction and expiration details.</param>
        public void SetDynamicEventDetails(IEnumerable<DynamicEventDetails> dynamicEventDetails, CultureInfo language, CacheItemParameters parameters)
        {
            this.Set(GetKey(language), dynamicEventDetails, parameters);
        }

        /// <summary>Infrastructure. Gets the cache item key.</summary>
        /// <param name="language">The language.</param>
        /// <returns>The key.</returns>
        private static string GetKey(CultureInfo language)
        {
            return string.Join(".", "event_details", language.TwoLetterISOLanguageName);
        }

        /// <summary>Infrastructure. Gets the cache item key.</summary>
        /// <param name="eventId">The event.</param>
        /// <param name="language">The language.</param>
        /// <returns>The key.</returns>
        private static string GetKey(Guid eventId, CultureInfo language)
        {
            return string.Join(".", "event_details", eventId.ToString(), language.TwoLetterISOLanguageName);
        }
    }
}