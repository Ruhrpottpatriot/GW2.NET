// <copyright file="ApiQuerySelector.IAbstractRequestBuilder.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Handlers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;

    public partial class ApiQuerySelector : IAbstractRequestBuilder
    {
        /// <inheritdoc />
        IAbstractRequestBuilder IAbstractRequestBuilder.WithBodyParameter<TValue>(string key, TValue value)
        {
            this.currentRequest.RequestParameters.Add((key, value.ToString(), true));
            return this;
        }

        /// <inheritdoc />
        IAbstractRequestBuilder IAbstractRequestBuilder.WithQueryStringParameter<TValue>(string key, TValue value)
        {
            this.currentRequest.RequestParameters.Add((key, value.ToString(), false));
            return this;
        }

        /// <inheritdoc />
        IEnumerable<HttpRequestMessage> IAbstractRequestBuilder.Build()
        {
            this.SaveCurrent();
            return this.BuildRequests();
        }

        /// <inheritdoc />
        public HttpRequestMessage BuildSingle()
        {
            this.SaveCurrent();
            return this.BuildRequests().Single();
        }

        /// <inheritdoc />
        IVersionSelector IAbstractRequestBuilder.Also()
        {
            this.SaveCurrent();
            return this;
        }
    }
}
