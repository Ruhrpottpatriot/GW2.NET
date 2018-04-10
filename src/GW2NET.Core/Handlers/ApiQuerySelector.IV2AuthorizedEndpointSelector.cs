// <copyright file="ApiQuerySelector.IV2AuthorizedEndpointSelector.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Handlers
{
    public partial class ApiQuerySelector : IV2AuthorizedEndpointSelector
    {
        /// <inheritdoc />
        IMessageBuilder IV2AuthorizedEndpointSelector.Account()
        {
            this.currentRequest.Endpoint = "account";
            return this;
        }

        /// <inheritdoc />
        IRequestTypeSelector IV2AuthorizedEndpointSelector.Characters()
        {
            this.currentRequest.Endpoint = "characters";
            return this;
        }
    }
}
