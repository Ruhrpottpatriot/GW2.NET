// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemsRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using GW2DotNET.V1.Core;
using GW2DotNET.V1.Core.ItemsInformation.Catalogs;

namespace GW2DotNET.V1.RestSharp
{
    /// <summary>
    /// Represents a request for a list of all discovered items.
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/items"/> for more information.
    /// </remarks>
    public class ItemsRequest : ServiceRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemsRequest"/> class.
        /// </summary>
        public ItemsRequest()
            : base(new Uri(Resources.Items, UriKind.Relative))
        {
        }

        /// <summary>
        /// Sends this request to the specified <see cref="ServiceClient"/> and retrieves a response whose content is of type <see cref="ItemsResult"/>.
        /// </summary>
        /// <param name="handler">The <see cref="ServiceResponse{TContent}"/> that sends the request over a network and returns an instance of type <see cref="ItemsResult"/>.</param>
        /// <returns>Returns an instance of type <see cref="ItemsResult"/>.</returns>
        public IServiceResponse<ItemsResult> GetResponse(IServiceClient handler)
        {
            return base.GetResponse<ItemsResult>(handler);
        }

        /// <summary>
        /// Asynchronously sends this request to the specified <see cref="ServiceClient"/> and retrieves a response whose content is of type <see cref="ItemsResult"/>.
        /// </summary>
        /// <param name="handler">The <see cref="ServiceResponse{TContent}"/> that sends the request over a network and returns an instance of type <see cref="ItemsResult"/>.</param>
        /// <returns>Returns an instance of type <see cref="ItemsResult"/>.</returns>
        public Task<IServiceResponse<ItemsResult>> GetResponseAsync(IServiceClient handler)
        {
            return base.GetResponseAsync<ItemsResult>(handler);
        }
    }
}