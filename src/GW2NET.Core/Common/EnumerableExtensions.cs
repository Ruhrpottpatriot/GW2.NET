// <copyright file="EnumerableExtensions.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class EnumerableExtensions
    {
        public static IDictionaryRange<TKey, TValue> ToDictionaryRange<TKey, TValue>(this IEnumerable<TValue> source, Func<TValue, TKey> keySelector, int subtotalCount, int totalCount)
        {
            return new DictionaryRange<TKey, TValue>(source.ToDictionary(keySelector))
            {
                SubtotalCount = subtotalCount,
                TotalCount = totalCount
            };
        }
    }
}
