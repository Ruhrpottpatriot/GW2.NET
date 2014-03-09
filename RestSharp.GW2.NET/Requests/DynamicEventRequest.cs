// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for a list of events and their status that match the given filters (if any).
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RestSharp.GW2DotNET.Requests
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using global::GW2DotNET.V1.Core;

    using global::GW2DotNET.V1.Core.DynamicEventsInformation.Status;

    /// <summary>
    ///     Represents a request for a list of events and their status that match the given filters (if any).
    /// </summary>
    /// <remarks>
    ///     See <a href="http://wiki.guildwars2.com/wiki/API:1/events" /> for more information.
    /// </remarks>
    public class DynamicEventRequest : ServiceRequest
    {
        #region Fields

        /// <summary>Infrastructure. Stores a parameter.</summary>
        private readonly Parameter eventIdParameter;

        /// <summary>Infrastructure. Stores a parameter.</summary>
        private readonly Parameter mapIdParameter;

        /// <summary>Infrastructure. Stores a parameter.</summary>
        private readonly Parameter worldIdParameter;

        /// <summary>The event filter.</summary>
        private Guid? eventId;

        /// <summary>The map filter.</summary>
        private int? mapId;

        /// <summary>The world filter.</summary>
        private int? worldId;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="DynamicEventRequest" /> class.
        /// </summary>
        public DynamicEventRequest()
            : base(Resources.Events)
        {
            this.AddParameter(this.worldIdParameter = new Parameter { Name = "world_id", Value = string.Empty, Type = ParameterType.GetOrPost });

            this.AddParameter(this.mapIdParameter = new Parameter { Name = "map_id", Value = string.Empty, Type = ParameterType.GetOrPost });

            this.AddParameter(this.eventIdParameter = new Parameter { Name = "event_id", Value = string.Empty, Type = ParameterType.GetOrPost });
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the event filter.
        /// </summary>
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

        /// <summary>
        ///     Gets or sets the map filter.
        /// </summary>
        public int? MapId
        {
            get
            {
                return this.mapId;
            }

            set
            {
                this.mapIdParameter.Value = (this.mapId = value).ToString();
            }
        }

        /// <summary>
        ///     Gets or sets the world filter.
        /// </summary>
        public int? WorldId
        {
            get
            {
                return this.worldId;
            }

            set
            {
                this.worldIdParameter.Value = (this.worldId = value).ToString();
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>Sends the current request and returns a response.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public IServiceResponse<DynamicEventsResult> GetResponse(IServiceClient serviceClient)
        {
            return this.GetResponse<DynamicEventsResult>(serviceClient);
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<DynamicEventsResult>> GetResponseAsync(IServiceClient serviceClient)
        {
            return this.GetResponseAsync<DynamicEventsResult>(serviceClient);
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<DynamicEventsResult>> GetResponseAsync(IServiceClient serviceClient, CancellationToken cancellationToken)
        {
            return this.GetResponseAsync<DynamicEventsResult>(serviceClient, cancellationToken);
        }

        #endregion
    }
}