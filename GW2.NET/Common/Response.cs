// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Response.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the <see cref="IResponse{T}" /> interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net;

    /// <summary>Provides the default implementation of the <see cref="IResponse{T}"/> interface.</summary>
    /// <typeparam name="T">The type of the response content.</typeparam>
    internal class Response<T> : IResponse<T>
    {
        /// <summary>Initializes a new instance of the <see cref="Response{T}"/> class.</summary>
        /// <param name="response">The response.</param>
        /// <param name="content">The response content.</param>
        public Response(HttpWebResponse response, T content)
        {
            this.Content = content;
            this.LastModified = response.LastModified;
            this.Culture = CultureInfo.GetCultureInfo(response.GetResponseHeader("Content-Language"));

            this.ExtensionData =
                response.Headers.AllKeys.Where(key => key.StartsWith("X-", StringComparison.OrdinalIgnoreCase))
                        .Select(key => new KeyValuePair<string, string>(key, response.GetResponseHeader(key)))
                        .ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        /// <summary>Gets or sets the response content.</summary>
        public T Content { get; set; }

        /// <summary>Gets or sets the locale.</summary>
        public CultureInfo Culture { get; set; }

        /// <summary>Gets or sets a collection of custom response headers.</summary>
        public IEnumerable<KeyValuePair<string, string>> ExtensionData { get; set; }

        /// <summary>Gets or sets the <see cref="DateTime"/> at which the message originated..</summary>
        public DateTime LastModified { get; set; }
    }
}