// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Response.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides a RestSharp-based implementation of the <see cref="IResponse{T}" /> interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.RestSharp
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using GW2DotNET.Common;

    using global::RestSharp;

    /// <summary>Provides a RestSharp-based implementation of the <see cref="IResponse{T}"/> interface.</summary>
    /// <typeparam name="T">The type of the response content.</typeparam>
    internal class Response<T> : IResponse<T>
    {
        /// <summary>Initializes a new instance of the <see cref="Response{T}"/> class.</summary>
        /// <param name="response">The response.</param>
        /// <param name="content">The response content.</param>
        public Response(IRestResponse response, T content)
        {
            this.Content = content;
            var lastModified = response.Headers.Single(parameter => parameter.Name.Equals("Date", StringComparison.OrdinalIgnoreCase));
            this.LastModified = DateTime.Parse((string)lastModified.Value);

            var culture = response.Headers.SingleOrDefault(parameter => parameter.Name.Equals("Content-Language", StringComparison.OrdinalIgnoreCase));
            if (culture != null)
            {
                this.Culture = CultureInfo.GetCultureInfo((string)culture.Value);
            }

            var metadata = response.Headers.Where(parameter => parameter.Name.StartsWith("X-", StringComparison.OrdinalIgnoreCase));
            this.ExtensionData = metadata.ToDictionary(parameter => parameter.Name, parameter => (string)parameter.Value);
        }

        /// <summary>Gets or sets the response content.</summary>
        public T Content { get; set; }

        /// <summary>Gets or sets the locale.</summary>
        public CultureInfo Culture { get; set; }

        /// <summary>Gets or sets a collection of custom response headers.</summary>
        public IDictionary<string, string> ExtensionData { get; set; }

        /// <summary>Gets or sets the <see cref="DateTime"/> at which the message originated..</summary>
        public DateTime LastModified { get; set; }
    }
}