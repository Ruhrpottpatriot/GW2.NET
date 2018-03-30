// <copyright file="ApiQuerySelector.IV2EndpointSelector.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Handlers
{
    public partial class ApiQuerySelector : IV2EndpointSelector
    {
        /// <inheritdoc />
        IRequestTypeSelector IV2EndpointSelector.Items()
        {
            this.currentRequest.Endpoint = "items";
            return this;
        }

        /// <inheritdoc />
        IAbstractRequestBuilder IV2EndpointSelector.OnEndpoint(string endpoint)
        {
            this.currentRequest.Endpoint = endpoint;
            return this;
        }
    }
}
