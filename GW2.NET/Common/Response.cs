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

    /// <summary>Provides the default implementation of the <see cref="IResponse{T}"/> interface.</summary>
    /// <typeparam name="T">The type of the response content.</typeparam>
    internal class Response<T> : IResponse<T>
    {
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