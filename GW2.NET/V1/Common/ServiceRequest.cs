// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for service requests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Utilities;

    /// <summary>Provides the base class for service requests.</summary>
    public abstract class ServiceRequest : IServiceRequest
    {
        /// <summary>Infrastructure. Stores the supported languages.</summary>
        private static readonly string[] SupportedLanguages = { "de", "en", "es", "fr" };

        /// <summary>Infrastructure. Holds a reference to the language info.</summary>
        private CultureInfo language;

        /// <summary>Initializes a new instance of the <see cref="ServiceRequest"/> class.</summary>
        /// <param name="resource">The service endpoint as a relative path.</param>
        protected ServiceRequest(string resource)
            : this(new Uri(resource, UriKind.Relative))
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ServiceRequest"/> class.</summary>
        /// <param name="resource">The service endpoint as a relative path.</param>
        protected ServiceRequest(Uri resource)
        {
            Preconditions.EnsureNotNull(paramName: "resource", value: resource);
            Preconditions.Ensure(!resource.IsAbsoluteUri, paramName: "resource", message: "'resource' should be a relative path.");

            this.ResourceUri = resource;
            this.Query = new Dictionary<string, string>();
        }

        /// <summary>Gets or sets the preferred language info.</summary>
        public CultureInfo Language
        {
            get
            {
                return this.language;
            }

            set
            {
                Preconditions.EnsureNotNull(paramName: "value", value: value);

                if (!SupportedLanguages.Contains(value.TwoLetterISOLanguageName))
                {
                    throw new NotSupportedException("The specified language is not supported.");
                }

                this.Query["lang"] = (this.language = value).TwoLetterISOLanguageName;
            }
        }

        /// <summary>Gets the query.</summary>
        public IDictionary<string, string> Query { get; private set; }

        /// <summary>Gets the resource URI.</summary>
        public Uri ResourceUri { get; private set; }

        /// <summary>Gets the query string.</summary>
        /// <returns>The query <see cref="string" />.</returns>
        public string GetQueryString()
        {
            return string.Join("&", this.Query.Where(pair => !string.IsNullOrEmpty(pair.Value)).Select(EncodeNameValuePair));
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public IServiceResponse<TResult> GetResponse<TResult>(IServiceClient serviceClient) where TResult : class
        {
            return serviceClient.Send<TResult>(this);
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<TResult>> GetResponseAsync<TResult>(IServiceClient serviceClient) where TResult : class
        {
            return serviceClient.SendAsync<TResult>(this);
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<TResult>> GetResponseAsync<TResult>(IServiceClient serviceClient, CancellationToken cancellationToken)
            where TResult : class
        {
            return serviceClient.SendAsync<TResult>(this, cancellationToken);
        }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return this.ResourceUri.ToString();
        }

        /// <summary>Encodes a key value pair for safe transportation over HTTP.</summary>
        /// <param name="keyValuePair">The key value pair.</param>
        /// <returns>The encoded key value pair.</returns>
        private static string EncodeNameValuePair(KeyValuePair<string, string> keyValuePair)
        {
            var name = Uri.EscapeUriString(keyValuePair.Key);
            var value = Uri.EscapeUriString(keyValuePair.Value);

            return string.Concat(name, "=", value);
        }
    }
}