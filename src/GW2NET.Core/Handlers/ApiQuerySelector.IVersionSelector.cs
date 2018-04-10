// <copyright file="ApiQuerySelector.IVersionSelector.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Handlers
{
    using System;

    public partial class ApiQuerySelector : IVersionSelector
    {
        IV2EndpointSelector IVersionSelector.V2()
        {
            this.currentRequest.Version = "v2";
            return this;
        }

        /// <inheritdoc />
        IV2AuthorizedEndpointSelector IVersionSelector.V2Authorized(string apiKey)
        {
            this.currentRequest.Version = "v2";
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentException("The provided api was not valid.", nameof(apiKey));
            }

            this.currentRequest.ApiKey = apiKey;
            return this;
        }

        /// <inheritdoc />
        IMessageBuilder IVersionSelector.Render(string signature, int fileId, string format)
        {
            this.currentRequest.Signature = signature;
            this.currentRequest.FileId = fileId;
            this.currentRequest.Format = format;
            return this;
        }
    }
}
