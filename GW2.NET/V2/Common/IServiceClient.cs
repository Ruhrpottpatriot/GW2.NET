// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IServiceClient.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for service clients.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V2.Common
{
    using System.Collections.Generic;
    using System.Globalization;

    /// <summary>Provides the interface for service clients.</summary>
    public interface IServiceClient
    {
        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>A collection of the specified type.</returns>
        IEnumerable<TResult> Send<TResult>(IRequest request);

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <param name="culture">The culture.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        TResult Send<TResult>(IDetailsRequest request, CultureInfo culture = null);

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <param name="culture">The culture.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>A collection of the specified type.</returns>
        IEnumerable<TResult> Send<TResult>(IBulkRequest request, CultureInfo culture = null);

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <param name="culture">The culture.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>A collection of the specified type.</returns>
        IEnumerable<TResult> Send<TResult>(IPaginatedRequest request, CultureInfo culture = null);
    }
}