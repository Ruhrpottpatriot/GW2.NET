// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventDetailsService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the event details service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.DynamicEvents
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Common.Serializers;
    using GW2DotNET.Utilities;
    using GW2DotNET.V1.DynamicEvents.Contracts;

    /// <summary>Provides the default implementation of the event details service.</summary>
    public class DynamicEventDetailsService : IDynamicEventDetailsService
    {
        /// <summary>Infrastructure. Holds a reference to the serializer settings.</summary>
        private static readonly DynamicEventDetailsSerializerSettings Settings = new DynamicEventDetailsSerializerSettings();

        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="DynamicEventDetailsService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public DynamicEventDetailsService(IServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEvent> GetDynamicEventDetails()
        {
            return this.GetDynamicEventDetails(CultureInfo.GetCultureInfo("en"));
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEvent> GetDynamicEventDetails(CultureInfo language)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new DynamicEventDetailsRequest { Culture = language };
            var result = this.serviceClient.Send(request, new JsonSerializer<DynamicEventCollectionResult>(Settings));

            // Apply patches
            foreach (var dynamicEvent in result.Events)
            {
                // Patch missing event identifier
                dynamicEvent.Value.EventId = dynamicEvent.Key;

                // Patch missing language information
                dynamicEvent.Value.Language = language.TwoLetterISOLanguageName;
            }

            return result.Events.Values;
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public DynamicEvent GetDynamicEventDetails(Guid eventId)
        {
            return this.GetDynamicEventDetails(eventId, CultureInfo.GetCultureInfo("en"));
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="language">The language.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public DynamicEvent GetDynamicEventDetails(Guid eventId, CultureInfo language)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new DynamicEventDetailsRequest { Culture = language, EventId = eventId };
            var result = this.serviceClient.Send(request, new JsonSerializer<DynamicEventCollectionResult>(Settings));

            // Apply patches
            foreach (var dynamicEvent in result.Events)
            {
                // Patch missing event identifier
                dynamicEvent.Value.EventId = dynamicEvent.Key;

                // Patch missing language information
                dynamicEvent.Value.Language = language.TwoLetterISOLanguageName;
            }

            return result.Events.Values.SingleOrDefault();
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventDetailsAsync()
        {
            return this.GetDynamicEventDetailsAsync(CultureInfo.GetCultureInfo("en"), CancellationToken.None);
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventDetailsAsync(CancellationToken cancellationToken)
        {
            return this.GetDynamicEventDetailsAsync(CultureInfo.GetCultureInfo("en"), cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventDetailsAsync(CultureInfo language)
        {
            return this.GetDynamicEventDetailsAsync(language, CancellationToken.None);
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventDetailsAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new DynamicEventDetailsRequest { Culture = language };
            var t1 = this.serviceClient.SendAsync(request, new JsonSerializer<DynamicEventCollectionResult>(Settings), cancellationToken);
            var t2 = t1.ContinueWith<IEnumerable<DynamicEvent>>(
                task =>
                    {
                        var result = task.Result;

                        // Apply patches
                        foreach (var dynamicEvent in result.Events)
                        {
                            // Patch missing event identifier
                            dynamicEvent.Value.EventId = dynamicEvent.Key;

                            // Patch missing language information
                            dynamicEvent.Value.Language = language.TwoLetterISOLanguageName;
                        }

                        return result.Events.Values;
                    }, 
                cancellationToken);

            return t2;
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<DynamicEvent> GetDynamicEventDetailsAsync(Guid eventId)
        {
            return this.GetDynamicEventDetailsAsync(eventId, CultureInfo.GetCultureInfo("en"), CancellationToken.None);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<DynamicEvent> GetDynamicEventDetailsAsync(Guid eventId, CancellationToken cancellationToken)
        {
            return this.GetDynamicEventDetailsAsync(eventId, CultureInfo.GetCultureInfo("en"), cancellationToken);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="language">The language.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<DynamicEvent> GetDynamicEventDetailsAsync(Guid eventId, CultureInfo language)
        {
            return this.GetDynamicEventDetailsAsync(eventId, language, CancellationToken.None);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<DynamicEvent> GetDynamicEventDetailsAsync(Guid eventId, CultureInfo language, CancellationToken cancellationToken)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new DynamicEventDetailsRequest { Culture = language, EventId = eventId };
            var t1 = this.serviceClient.SendAsync(request, new JsonSerializer<DynamicEventCollectionResult>(Settings), cancellationToken);
            var t2 = t1.ContinueWith(
                task =>
                    {
                        var result = task.Result;

                        // Apply patches
                        foreach (var dynamicEvent in result.Events)
                        {
                            // Patch missing event identifier
                            dynamicEvent.Value.EventId = dynamicEvent.Key;

                            // Patch missing language information
                            dynamicEvent.Value.Language = language.TwoLetterISOLanguageName;
                        }

                        return result.Events.Values.SingleOrDefault();
                    }, 
                cancellationToken);

            return t2;
        }
    }
}