// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IServiceResponse.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base interface for HTTP responses originating from the Guild Wars 2 API.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Common
{
    using System.Net;
    using System.Net.Mime;

    /// <summary>Provides the base interface for HTTP responses originating from the Guild Wars 2 API.</summary>
    /// <typeparam name="TResult">The type of the response content.</typeparam>
    public interface IServiceResponse<out TResult>
        where TResult : class
    {
        /// <summary>Gets a value indicating the Internet media type of the message content.</summary>
        ContentType ContentType { get; }

        /// <summary>Gets a value indicating whether the service returned an image response.</summary>
        bool IsImageResponse { get; }

        /// <summary>Gets a value indicating whether the service returned a JSON response.</summary>
        bool IsJsonResponse { get; }

        /// <summary>Gets a value indicating whether the service returned a success status code.</summary>
        bool IsSuccessStatusCode { get; }

        /// <summary>Gets the status code.</summary>
        HttpStatusCode StatusCode { get; }

        /// <summary>Gets the status description.</summary>
        string StatusDescription { get; }

        /// <summary>Gets the response content as an instance of the specified type.</summary>
        /// <returns>The response content.</returns>
        TResult Deserialize();

        /// <summary>Throws an exception if the request did not return a success status code.</summary>
        /// <returns>Returns the current instance.</returns>
        /// <remarks>The current instance is returned to allow chaining method calls.</remarks>
        IServiceResponse<TResult> EnsureSuccessStatusCode();
    }
}