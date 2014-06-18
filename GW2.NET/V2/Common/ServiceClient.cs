// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceClient.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides a default implementation for the <see cref="IServiceClient" /> interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V2.Common
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Net;

    using GW2DotNET.Utilities;
    using GW2DotNET.V2.Common.Contracts;

    using Newtonsoft.Json;

    /// <summary>Provides a default implementation for the <see cref="IServiceClient" /> interface.</summary>
    public class ServiceClient : IServiceClient
    {
        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>A collection of the specified type.</returns>
        public TResult Send<TResult>(IRequest request)
        {
            var uriBuilder = new UriBuilder { Scheme = "https", Host = "api.guildwars2.com", Path = string.Concat("/v2/", request.Resource) };
            var webRequest = (HttpWebRequest)WebRequest.Create(uriBuilder.ToString());
            webRequest.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip");
            try
            {
                var response = (HttpWebResponse)webRequest.GetResponse();
                using (var stream = response.GetResponseStream())
                using (var streamReader = new StreamReader(stream ?? new MemoryStream()))
                using (var jsonReader = new JsonTextReader(streamReader))
                {
                    var serializer = JsonSerializer.CreateDefault();
                    return serializer.Deserialize<TResult>(jsonReader);
                }
            }
            catch (WebException exception)
            {
                // Rethrow in case of transport errors
                if (exception.Status != WebExceptionStatus.ProtocolError)
                {
                    throw;
                }

                var response = exception.Response;
                using (var stream = response.GetResponseStream())
                using (var streamReader = new StreamReader(stream ?? new MemoryStream()))
                using (var jsonReader = new JsonTextReader(streamReader))
                {
                    var serializer = JsonSerializer.CreateDefault();
                    var errorResult = serializer.Deserialize<ErrorResult>(jsonReader);
                    throw new ServiceException(null, errorResult, exception);
                }
            }
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <param name="culture">The culture.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public TResult Send<TResult>(IDetailsRequest request, CultureInfo culture = null)
        {
            string pathTemplate = request.Identifier.HasValue ? "/v2/{0}/{1}" : "/v2/{0}";
            var uriBuilder = new UriBuilder
                                 {
                                     Scheme = "https",
                                     Host = "api.guildwars2.com",
                                     Path = string.Format(pathTemplate, request.Resource, request.Identifier)
                                 };
            if (culture != null)
            {
                var formData = new UrlEncodedForm { { "lang", culture.TwoLetterISOLanguageName } };
                uriBuilder.Query = formData.GetQueryString();
            }

            var webRequest = (HttpWebRequest)WebRequest.Create(uriBuilder.ToString());
            webRequest.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip");
            try
            {
                var response = (HttpWebResponse)webRequest.GetResponse();
                using (var stream = response.GetResponseStream())
                using (var streamReader = new StreamReader(stream ?? new MemoryStream()))
                using (var jsonReader = new JsonTextReader(streamReader))
                {
                    var serializer = JsonSerializer.CreateDefault();
                    return serializer.Deserialize<TResult>(jsonReader);
                }
            }
            catch (WebException exception)
            {
                // Rethrow in case of transport errors
                if (exception.Status != WebExceptionStatus.ProtocolError)
                {
                    throw;
                }

                var response = exception.Response;
                using (var stream = response.GetResponseStream())
                using (var streamReader = new StreamReader(stream ?? new MemoryStream()))
                using (var jsonReader = new JsonTextReader(streamReader))
                {
                    var serializer = JsonSerializer.CreateDefault();
                    var errorResult = serializer.Deserialize<ErrorResult>(jsonReader);
                    throw new ServiceException(null, errorResult, exception);
                }
            }
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <param name="culture">The culture.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>A collection of the specified type.</returns>
        public TResult Send<TResult>(IBulkRequest request, CultureInfo culture = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <param name="culture">The culture.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>A collection of the specified type.</returns>
        public TResult Send<TResult>(IPaginatedRequest request, CultureInfo culture = null)
        {
            throw new NotImplementedException();
        }
    }
}