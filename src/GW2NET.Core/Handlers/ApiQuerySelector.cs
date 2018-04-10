// <copyright file="ApiQuerySelector.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Handlers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net.Http;

    public partial class ApiQuerySelector
    {
        private readonly List<EndpointRequestDetails> requestParams;

        private EndpointRequestDetails currentRequest;

        private ApiQuerySelector()
        {
            this.requestParams = new List<EndpointRequestDetails>();
        }

        public static IVersionSelector Init()
        {
            return new ApiQuerySelector();
        }

        private void SaveCurrent()
        {
            if (this.currentRequest == null)
            {
                return;
            }

            this.requestParams.Add(this.currentRequest);
            this.currentRequest = null;
        }

        private IEnumerable<HttpRequestMessage> BuildRequests()
        {
            throw new NotImplementedException();
        }
    }
}