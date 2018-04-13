// <copyright file="Request.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;

    public abstract class Request
    {
        /// <summary>Initializes a new instance of the <see cref="Request"/> class.</summary>
        protected Request()
        {
            this.Parameters = new List<RequestParameter>();
        }

        /// <summary>Gets the request parameters.</summary>
        public IList<RequestParameter> Parameters { get; set; }

        public static string IdParam => "ids";

        public string Language => "lang";

        /// <summary>Returns a <see cref="HttpRequestMessage"/> object representing the current request.</summary>
        public HttpRequestMessage ToHttpRequestMessage()
        {
            var builder = new StringBuilder("?");

            // Build Query Params
            var queryStrings = this.Parameters
                .Where(e => e.Location == ParameterLocation.Url)
                .ToLookup(p => p.Key)
                .Select(l => $"{l.Key}={string.Join(",", l.Select(i => i.Value))}");
            builder.Append(string.Join("&", queryStrings));

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, builder.ToString());

            foreach (var parameter in this.Parameters.Where(p => p.Location == ParameterLocation.Header))
            {
                requestMessage.Headers.Add(parameter.Key, new[] { parameter.Value });
            }

            return requestMessage;
        }
    }
}
