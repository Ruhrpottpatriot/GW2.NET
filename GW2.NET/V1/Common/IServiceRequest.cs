// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IServiceRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base interface for HTTP requests targeting the Guild Wars 2 API.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>Provides the base interface for HTTP requests targeting the Guild Wars 2 API.</summary>
    public interface IServiceRequest
    {
        /// <summary>Gets the query.</summary>
        IDictionary<string, string> Query { get; }

        /// <summary>Gets the resource URI.</summary>
        Uri ResourceUri { get; }

        /// <summary>Gets the query string.</summary>
        /// <returns>The query <see cref="string" />.</returns>
        string GetQueryString();
    }
}