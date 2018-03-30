// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResponseExtensions.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides extension methods for <see cref="IResponse{T}" /> types.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>Provides extension methods for <see cref="IResponse{T}" /> types.</summary>
    public static class ResponseExtensions
    {
        /// <summary>Gets the maximum number of values in a subset.</summary>
        /// <param name="instance">The response.</param>
        /// <typeparam name="T">The response content type.</typeparam>
        /// <exception cref="ArgumentNullException">The value of <paramref name="instance"/> is a null reference.</exception>
        /// <returns>The maximum number of values in a subset.</returns>
        public static int GetPageSize<T>(this IResponse<ICollection<T>> instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            if (!instance.ExtensionData.TryGetValue("X-Page-Size", out var header))
            {
                return 0;
            }

            if (!int.TryParse(header, out var value))
            {
                return 0;
            }

            return value;
        }

        /// <summary>Gets the number of subsets in a collection.</summary>
        /// <param name="instance">The response.</param>
        /// <typeparam name="T">The response content type.</typeparam>
        /// <exception cref="ArgumentNullException">The value of <paramref name="instance"/> is a null reference.</exception>
        /// <returns>The number of subsets in a collection.</returns>
        public static int GetPageTotal<T>(this IResponse<ICollection<T>> instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            if (!instance.ExtensionData.TryGetValue("X-Page-Total", out var header))
            {
                return 0;
            }

            if (!int.TryParse(header, out var value))
            {
                return 0;
            }

            return value;
        }

        /// <summary>Gets the number of values in a subset.</summary>
        /// <param name="instance">The response.</param>
        /// <typeparam name="T">The response content type.</typeparam>
        /// <exception cref="ArgumentNullException">The value of <paramref name="instance"/> is a null reference.</exception>
        /// <returns>The number of values in a subset.</returns>
        public static int GetResultCount<T>(this IResponse<ICollection<T>> instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            if (!instance.ExtensionData.TryGetValue("X-Result-Count", out var header))
            {
                return 0;
            }

            if (!int.TryParse(header, out var value))
            {
                return 0;
            }

            return value;
        }

        /// <summary>Gets the number of values in a collection.</summary>
        /// <param name="instance">The response.</param>
        /// <typeparam name="T">The response content type.</typeparam>
        /// <exception cref="ArgumentNullException">The value of <paramref name="instance"/> is a null reference.</exception>
        /// <returns>The number of values in a collection.</returns>
        public static int GetResultTotal<T>(this IResponse<ICollection<T>> instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            if (!instance.ExtensionData.TryGetValue("X-Result-Total", out var header))
            {
                return 0;
            }

            if (!int.TryParse(header, out var value))
            {
                return 0;
            }

            return value;
        }
    }
}