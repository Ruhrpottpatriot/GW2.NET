// <copyright file="ApiMessageHandler.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Handlers
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Common;

    public class ApiMessageHandler : DelegatingHandler
    {
        protected ApiMessageHandler(HttpMessageHandler innerHandler)
            : base(innerHandler)
        {
        }

        /// <inheritdoc />
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);
            try
            {
                return response;
            }
            catch (ServiceException ex)
            {
                ex.Request = request;
                throw;
            }
        }
    }
}
