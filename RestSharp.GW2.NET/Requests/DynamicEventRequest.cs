// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading;
using System.Threading.Tasks;
using GW2DotNET.V1.Core;
using GW2DotNET.V1.Core.DynamicEventsInformation.Status;

namespace RestSharp.GW2DotNET.Requests
{
    /// <summary>
    ///     Represents a request for a list of events and their status that match the given filters (if any).
    /// </summary>
    /// <remarks>
    ///     See <a href="http://wiki.guildwars2.com/wiki/API:1/events" /> for more information.
    /// </remarks>
    public class DynamicEventRequest : ServiceRequest
    {
        /// <summary>Infrastructure. Stores a parameter.</summary>
        private readonly Parameter eventIdParameter;

        /// <summary>Infrastructure. Stores a parameter.</summary>
        private readonly Parameter mapIdParameter;

        /// <summary>Infrastructure. Stores a parameter.</summary>
        private readonly Parameter worldIdParameter;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DynamicEventRequest" /> class.
        /// </summary>
        public DynamicEventRequest()
            : base(Resources.Events)
        {
            this.AddParameter(
                this.worldIdParameter = new Parameter
                {
                    Name = "world_id",
                    Value = string.Empty,
                    Type = ParameterType.GetOrPost
                });

            this.AddParameter(
                this.mapIdParameter = new Parameter
                {
                    Name = "map_id",
                    Value = string.Empty,
                    Type = ParameterType.GetOrPost
                });

            this.AddParameter(
                this.eventIdParameter = new Parameter
                {
                    Name = "event_id",
                    Value = string.Empty,
                    Type = ParameterType.GetOrPost
                });
        }

        /// <summary>
        ///     Gets or sets the event ID filter.
        /// </summary>
        public Guid? EventId
        {
            get
            {
                if (string.IsNullOrEmpty((string)this.eventIdParameter.Value))
                {
                    return null;
                }

                return Guid.Parse((string)this.eventIdParameter.Value);
            }

            set
            {
                this.eventIdParameter.Value = value.ToString();
            }
        }

        /// <summary>
        ///     Gets or sets the map ID filter.
        /// </summary>
        public int? MapId
        {
            get
            {
                if (string.IsNullOrEmpty((string)this.mapIdParameter.Value))
                {
                    return null;
                }

                return int.Parse((string)this.mapIdParameter.Value);
            }

            set
            {
                this.mapIdParameter.Value = value.ToString();
            }
        }

        /// <summary>
        ///     Gets or sets the world ID filter.
        /// </summary>
        public int? WorldId
        {
            get
            {
                if (string.IsNullOrEmpty((string)this.worldIdParameter.Value))
                {
                    return null;
                }

                return int.Parse((string)this.worldIdParameter.Value);
            }

            set
            {
                this.worldIdParameter.Value = value.ToString();
            }
        }

        /// <summary>
        ///     Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public IServiceResponse<DynamicEventsResult> GetResponse(IServiceClient serviceClient)
        {
            return base.GetResponse<DynamicEventsResult>(serviceClient);
        }

        /// <summary>
        ///     Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<DynamicEventsResult>> GetResponseAsync(IServiceClient serviceClient)
        {
            return base.GetResponseAsync<DynamicEventsResult>(serviceClient);
        }

        /// <summary>
        ///     Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken" /> that provides cancellation support.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<DynamicEventsResult>> GetResponseAsync(IServiceClient serviceClient, CancellationToken cancellationToken)
        {
            return base.GetResponseAsync<DynamicEventsResult>(serviceClient, cancellationToken);
        }
    }
}