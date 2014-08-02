// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResponseExtensions.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides extension methods for <see cref="IResponse{T}" /> types.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V2.Common
{
    using GW2DotNET.Common;

    /// <summary>Provides extension methods for <see cref="IResponse{T}" /> types.</summary>
    public static class ResponseExtensions
    {
        /// <summary>Gets the maximum number of values in a subset.</summary>
        /// <param name="instance">The response.</param>
        /// <typeparam name="T">The response content type.</typeparam>
        /// <returns>The maximum number of values in a subset.</returns>
        public static int GetPageSize<T>(this IResponse<T> instance)
        {
            return int.Parse(instance.ExtensionData["X-Page-Size"]);
        }

        /// <summary>Gets the number of subsets in a collection.</summary>
        /// <param name="instance">The response.</param>
        /// <typeparam name="T">The response content type.</typeparam>
        /// <returns>The number of subsets in a collection.</returns>
        public static int GetPageTotal<T>(this IResponse<T> instance)
        {
            return int.Parse(instance.ExtensionData["X-Page-Total"]);
        }

        /// <summary>Gets the number of values in a subset.</summary>
        /// <param name="instance">The response.</param>
        /// <typeparam name="T">The response content type.</typeparam>
        /// <returns>The number of values in a subset.</returns>
        public static int GetResultCount<T>(this IResponse<T> instance)
        {
            return int.Parse(instance.ExtensionData["X-Result-Count"]);
        }

        /// <summary>Gets the number of values in a collection.</summary>
        /// <param name="instance">The response.</param>
        /// <typeparam name="T">The response content type.</typeparam>
        /// <returns>The number of values in a collection.</returns>
        public static int GetResultTotal<T>(this IResponse<T> instance)
        {
            return int.Parse(instance.ExtensionData["X-Result-Total"]);
        }
    }
}