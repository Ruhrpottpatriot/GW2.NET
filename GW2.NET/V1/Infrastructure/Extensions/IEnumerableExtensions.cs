using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GW2DotNET.V1.Infrastructure.Extensions
{
    /// <summary>Some IEnumerable extensions.</summary>
    public static class EnumerableExtensions
    {
        /// <summary>Checks if a collection is null or empty.</summary>
        /// <param name="enumerable">The enumerable to check.</param>
        /// <typeparam name="T"></typeparam>
        /// <returns>The <see cref="bool"/>.</returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable == null || !enumerable.Any();
        }
    }
}
