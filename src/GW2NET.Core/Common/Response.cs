// <copyright file="Response.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    /// <summary>Provides the default implementation of the <see cref="IResponse{T}"/> interface.</summary>
    /// <typeparam name="T">The type of the response content.</typeparam>
    public class Response<T> : IResponse<T>
    {
        public Response()
        {
            this.Content = new List<T>(0);
            this.ExtensionData = new Dictionary<string, string>(0);
        }

        /// <inheritdoc />
        public IEnumerable<T> Content { get; set; }

        /// <inheritdoc />
        public CultureInfo Culture { get; set; }

        /// <inheritdoc />
        public DateTimeOffset Date { get; set; }

        /// <inheritdoc />
        public IDictionary<string, string> ExtensionData { get; set; }

        public IEnumerable<T> ToIEnumerable()
        {
            return this.Content;
        }
    }
}