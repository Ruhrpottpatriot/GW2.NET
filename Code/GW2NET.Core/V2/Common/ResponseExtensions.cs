// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResponseExtensions.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides extension methods for <see cref="IResponse{T}" /> types.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Common
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;

    /// <summary>Provides extension methods for <see cref="IResponse{T}" /> types.</summary>
    public static class ResponseExtensions
    {
        /// <summary>Gets the maximum number of values in a subset.</summary>
        /// <param name="instance">The response.</param>
        /// <typeparam name="T">The response content type.</typeparam>
        /// <returns>The maximum number of values in a subset.</returns>
        [Pure]
        public static int GetPageSize<T>(this IResponse<ICollection<T>> instance)
        {
            Contract.Requires(instance != null);
            Contract.Requires(instance.ExtensionData != null);
            Contract.Ensures(Contract.Result<int>() >= 0);
            string header;
            if (!instance.ExtensionData.TryGetValue("X-Page-Size", out header))
            {
                return 0;
            }

            int value;
            if (!int.TryParse(header, out value))
            {
                return 0;
            }

            return value;
        }

        /// <summary>Gets the number of subsets in a collection.</summary>
        /// <param name="instance">The response.</param>
        /// <typeparam name="T">The response content type.</typeparam>
        /// <returns>The number of subsets in a collection.</returns>
        [Pure]
        public static int GetPageTotal<T>(this IResponse<ICollection<T>> instance)
        {
            Contract.Requires(instance != null);
            Contract.Requires(instance.ExtensionData != null);
            Contract.Ensures(Contract.Result<int>() >= 0);
            string header;
            if (!instance.ExtensionData.TryGetValue("X-Page-Total", out header))
            {
                return 0;
            }

            int value;
            if (!int.TryParse(header, out value))
            {
                return 0;
            }

            return value;
        }

        /// <summary>Gets the number of values in a subset.</summary>
        /// <param name="instance">The response.</param>
        /// <typeparam name="T">The response content type.</typeparam>
        /// <returns>The number of values in a subset.</returns>
        [Pure]
        public static int GetResultCount<T>(this IResponse<ICollection<T>> instance)
        {
            Contract.Requires(instance != null);
            Contract.Requires(instance.ExtensionData != null);
            Contract.Ensures(Contract.Result<int>() >= 0);
            string header;
            if (!instance.ExtensionData.TryGetValue("X-Result-Count", out header))
            {
                return 0;
            }

            int value;
            if (!int.TryParse(header, out value))
            {
                return 0;
            }

            return value;
        }

        /// <summary>Gets the number of values in a collection.</summary>
        /// <param name="instance">The response.</param>
        /// <typeparam name="T">The response content type.</typeparam>
        /// <returns>The number of values in a collection.</returns>
        [Pure]
        public static int GetResultTotal<T>(this IResponse<ICollection<T>> instance)
        {
            Contract.Requires(instance != null);
            Contract.Requires(instance.ExtensionData != null);
            Contract.Ensures(Contract.Result<int>() >= 0);
            string header;
            if (!instance.ExtensionData.TryGetValue("X-Result-Total", out header))
            {
                return 0;
            }

            int value;
            if (!int.TryParse(header, out value))
            {
                return 0;
            }

            return value;
        }
    }
}