// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventDetailsRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for static details about dynamic events.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RestSharp.GW2DotNET.Requests
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using global::GW2DotNET.V1.Core;

    using global::GW2DotNET.V1.Core.DynamicEventsInformation.Details;

    /// <summary>
    ///     Represents a request for static details about dynamic events.
    /// </summary>
    /// <remarks>
    ///     See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details" /> for more information.
    /// </remarks>
    public class DynamicEventDetailsRequest : ServiceRequest
    {
        /// <summary>Infrastructure. Stores a parameter.</summary>
        private readonly Parameter eventIdParameter;

        /// <summary>The event filter.</summary>
        private Guid? eventId;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DynamicEventDetailsRequest" /> class.
        /// </summary>
        public DynamicEventDetailsRequest()
            : base(Resources.EventDetails)
        {
            this.AddParameter(this.eventIdParameter = new Parameter { Name = "event_id", Value = string.Empty, Type = ParameterType.GetOrPost });
        }

        /// <summary>Gets or sets the event filter.</summary>
        public Guid? EventId
        {
            get
            {
                return this.eventId;
            }

            set
            {
                this.eventIdParameter.Value = (this.eventId = value).ToString();
            }
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public IServiceResponse<DynamicEventDetailsResult> GetResponse(IServiceClient serviceClient)
        {
            return this.GetResponse<DynamicEventDetailsResult>(serviceClient);
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<DynamicEventDetailsResult>> GetResponseAsync(IServiceClient serviceClient)
        {
            return this.GetResponseAsync<DynamicEventDetailsResult>(serviceClient);
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<DynamicEventDetailsResult>> GetResponseAsync(IServiceClient serviceClient, CancellationToken cancellationToken)
        {
            return this.GetResponseAsync<DynamicEventDetailsResult>(serviceClient, cancellationToken);
        }
    }
}