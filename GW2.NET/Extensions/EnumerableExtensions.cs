// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumerableExtensions.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Some IEnumerable extensions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>Some IEnumerable extensions.</summary>
    public static class EnumerableExtensions
    {
        /// <summary>Checks if a collection is null or empty.</summary>
        /// <param name="enumerable">The enumerable to check.</param>
        /// <typeparam name="T">they type to check</typeparam>
        /// <returns>The <see cref="bool"/>.</returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable == null || !enumerable.Any();
        }
    }
}