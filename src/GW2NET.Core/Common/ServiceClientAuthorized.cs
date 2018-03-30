// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceClientAuthorized.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides an implementation of <see cref="IServiceClient" /> that allows authorized requests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Common
{
    using System;
    using System.IO;
    using System.Net;
    using GW2NET.Common.Serializers;

    /// <summary>Provides an implementation of <see cref="IServiceClient"/> that allows authorized requests.</summary>
    public class ServiceClientAuthorized : ServiceClient
    {
        /// <summary>Infrastructure. Holds a reference to the api key.
        /// </summary>
        private readonly string apiKey;

        /// <summary>Initializes a new instance of the <see cref="ServiceClientAuthorized"/> class.</summary>
        /// <param name="baseUri">The base uri.</param>
        /// <param name="apiKey">The api key.</param>
        /// <param name="successSerializerFactory">The success serializer factory.</param>
        /// <param name="errorSerializerFactory">The error serializer factory.</param>
        /// <param name="gzipInflator">The gzip inflator.</param>
        /// <exception cref="ArgumentException">Thrown when one of the arguments is null.</exception>
        public ServiceClientAuthorized(Uri baseUri, string apiKey, ISerializerFactory successSerializerFactory, ISerializerFactory errorSerializerFactory, IConverter<Stream, Stream> gzipInflator)
            : base(baseUri, successSerializerFactory, errorSerializerFactory, gzipInflator)
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentException("The provided api key has to be valid", "apiKey");
            }

            this.apiKey = apiKey;
        }

        /// <summary>Creates and configures a new instance of the <see cref="HttpWebRequest"/> class.</summary>
        /// <param name="uri">The resource <see cref="Uri"/>.</param>
        /// <returns>The <see cref="HttpWebRequest"/>.</returns>
        protected override HttpWebRequest CreateHttpWebRequest(Uri uri)
        {
            var request = base.CreateHttpWebRequest(uri);
            request.Headers[HttpRequestHeader.Authorization] = string.Format("Bearer {0}", this.apiKey);

            // Return the request object
            return request;
        }
    }
}
