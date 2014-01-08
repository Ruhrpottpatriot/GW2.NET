// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IApiResponse.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System;

namespace GW2DotNET.V1.Core
{
    /// <summary>
    /// Provides the base interface for HTTP responses originating from the Guild Wars 2 API.
    /// </summary>
    /// <typeparam name="TContent">The type of the response content.</typeparam>
    public interface IApiResponse<TContent>
    {
        /// <summary>
        /// Gets a value indicating whether the request returned a success status code.
        /// </summary>
        bool IsSuccessStatusCode { get; }

        /// <summary>
        /// Gets the error result if the request was unsuccessful.
        /// </summary>
        /// <returns>Return an instance of <see cref="ApiException"/> that represents the request error.</returns>
        ApiException DeserializeError();

        /// <summary>
        /// Gets the response content as an object of the specified type.
        /// </summary>
        /// <returns>Returns an instance of the specified type that represents the response.</returns>
        TContent DeserializeObject();

        /// <summary>
        /// Throws an exception if the request did not return a success status code.
        /// </summary>
        /// <returns>The current instance ('This').</returns>
        /// <remarks>'This' is returned to allow chaining method calls.</remarks>
        /// <example>
        /// <code>
        /// var responseContent = request.GetResponse<![CDATA[<]]>ObjectType<![CDATA[>]]>.EnsureSuccessStatusCode().DeserializeObject();
        /// </code>
        /// </example>
        IApiResponse<TContent> EnsureSuccessStatusCode();
    }
}