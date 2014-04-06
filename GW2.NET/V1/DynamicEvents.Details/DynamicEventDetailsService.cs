// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventDetailsService.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the event details service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.DynamicEvents.Details
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Common;
    using GW2DotNET.V1.DynamicEvents.Details.Types;

    /// <summary>Provides the default implementation of the event details service.</summary>
    public class DynamicEventDetailsService : ServiceBase, IDynamicEventDetailsService
    {
        /// <summary>Initializes a new instance of the <see cref="DynamicEventDetailsService"/> class.</summary>
        public DynamicEventDetailsService()
            : this(new ServiceClient(new Uri(Services.DataServiceUrl)))
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DynamicEventDetailsService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public DynamicEventDetailsService(IServiceClient serviceClient)
            : base(serviceClient)
        {
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEventDetails> GetDynamicEventDetails()
        {
            return this.GetDynamicEventDetails(ServiceBase.DefaultLanguage);
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEventDetails> GetDynamicEventDetails(CultureInfo language)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var serviceRequest = new DynamicEventDetailsRequest { Language = language };
            var result = this.Request<DynamicEventDetailsResult>(serviceRequest);

            foreach (var dynamicEventDetails in result.EventDetails.Values)
            {
                // patch missing language information
                dynamicEventDetails.Language = language;
            }

            return result.EventDetails.Values;
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public DynamicEventDetails GetDynamicEventDetails(Guid eventId)
        {
            return this.GetDynamicEventDetails(eventId, ServiceBase.DefaultLanguage);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="language">The language.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public DynamicEventDetails GetDynamicEventDetails(Guid eventId, CultureInfo language)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var serviceRequest = new DynamicEventDetailsRequest { Language = language, EventId = eventId };
            var result = this.Request<DynamicEventDetailsResult>(serviceRequest);

            foreach (var dynamicEventDetails in result.EventDetails.Values)
            {
                // patch missing language information
                dynamicEventDetails.Language = language;
            }

            return result.EventDetails.Values.SingleOrDefault();
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventDetails>> GetDynamicEventDetailsAsync()
        {
            return this.GetDynamicEventDetailsAsync(ServiceBase.DefaultLanguage);
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventDetails>> GetDynamicEventDetailsAsync(CancellationToken cancellationToken)
        {
            return this.GetDynamicEventDetailsAsync(ServiceBase.DefaultLanguage, cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventDetails>> GetDynamicEventDetailsAsync(CultureInfo language)
        {
            return this.GetDynamicEventDetailsAsync(language, CancellationToken.None);
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventDetails>> GetDynamicEventDetailsAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var serviceRequest = new DynamicEventDetailsRequest { Language = language };
            var t1 = this.RequestAsync<DynamicEventDetailsResult>(serviceRequest, cancellationToken);

            var t2 = t1.ContinueWith<IEnumerable<DynamicEventDetails>>(
                task =>
                    {
                        foreach (var dynamicEventDetails in task.Result.EventDetails.Values)
                        {
                            // patch missing language information
                            dynamicEventDetails.Language = language;
                        }

                        return task.Result.EventDetails.Values;
                    }, 
                cancellationToken);

            return t2;
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<DynamicEventDetails> GetDynamicEventDetailsAsync(Guid eventId)
        {
            return this.GetDynamicEventDetailsAsync(eventId, ServiceBase.DefaultLanguage);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<DynamicEventDetails> GetDynamicEventDetailsAsync(Guid eventId, CancellationToken cancellationToken)
        {
            return this.GetDynamicEventDetailsAsync(eventId, ServiceBase.DefaultLanguage, cancellationToken);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="language">The language.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<DynamicEventDetails> GetDynamicEventDetailsAsync(Guid eventId, CultureInfo language)
        {
            return this.GetDynamicEventDetailsAsync(eventId, language, CancellationToken.None);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<DynamicEventDetails> GetDynamicEventDetailsAsync(Guid eventId, CultureInfo language, CancellationToken cancellationToken)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var serviceRequest = new DynamicEventDetailsRequest { Language = language, EventId = eventId };
            var t1 = this.RequestAsync<DynamicEventDetailsResult>(serviceRequest, cancellationToken);

            var t2 = t1.ContinueWith(
                task =>
                    {
                        foreach (var dynamicEventDetails in task.Result.EventDetails.Values)
                        {
                            // patch missing language information
                            dynamicEventDetails.Language = language;
                        }

                        return task.Result.EventDetails.Values.SingleOrDefault();
                    }, 
                cancellationToken);

            return t2;
        }
    }
}