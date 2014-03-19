// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonResponse.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a JSON-object response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.ServiceManagement.ServiceResponses
{
    using System;
    using System.IO;
    using System.Net;

    using Newtonsoft.Json;

    /// <summary>Represents a JSON-object response.</summary>
    /// <typeparam name="TResult">The type of the response content.</typeparam>
    public class JsonResponse<TResult> : ServiceResponse<TResult>
        where TResult : class
    {
        /// <summary>Initializes a new instance of the <see cref="JsonResponse{TResult}"/> class.</summary>
        /// <param name="webResponse">The <see cref="System.Net.HttpWebResponse"/>.</param>
        public JsonResponse(HttpWebResponse webResponse)
            : base(webResponse)
        {
        }

        /// <summary>Gets the response content as an instance of the specified type.</summary>
        /// <param name="stream">The response stream.</param>
        /// <returns>The response content.</returns>
        protected override TResult Deserialize(Stream stream)
        {
            if (!this.IsSuccessStatusCode)
            {
                // if the service returned an error code
                throw new InvalidOperationException("Unable to deserialize the response content: the service returned an error code.");
            }

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                var serializer = JsonSerializer.Create();
                return serializer.Deserialize<TResult>(jsonReader);
            }
        }
    }
}