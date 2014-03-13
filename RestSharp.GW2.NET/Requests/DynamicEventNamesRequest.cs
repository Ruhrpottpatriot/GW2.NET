// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventNamesRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for a list of events and their localized name.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace RestSharp.GW2DotNET.Requests
{
    using System.Threading;
    using System.Threading.Tasks;

    using global::GW2DotNET.V1;

    using global::GW2DotNET.V1.Core;

    using global::GW2DotNET.V1.Core.DynamicEvents.Names;

    /// <summary>
    ///     Represents a request for a list of events and their localized name.
    /// </summary>
    /// <remarks>
    ///     See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names" /> for more information.
    /// </remarks>
    public class DynamicEventNamesRequest : ServiceRequest
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DynamicEventNamesRequest" /> class.
        /// </summary>
        public DynamicEventNamesRequest()
            : base(Services.EventNames)
        {
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public IServiceResponse<DynamicEventNameCollection> GetResponse(IServiceClient serviceClient)
        {
            return this.GetResponse<DynamicEventNameCollection>(serviceClient);
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<DynamicEventNameCollection>> GetResponseAsync(IServiceClient serviceClient)
        {
            return this.GetResponseAsync<DynamicEventNameCollection>(serviceClient);
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<DynamicEventNameCollection>> GetResponseAsync(IServiceClient serviceClient, CancellationToken cancellationToken)
        {
            return this.GetResponseAsync<DynamicEventNameCollection>(serviceClient, cancellationToken);
        }
    }
}