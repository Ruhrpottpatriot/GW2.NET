// <copyright file="HeaderExtensions.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET
{
    using System.Collections.Generic;
    using System.Net.Http.Headers;

    public static class HeaderExtensions
    {
        public static void AddRange(this HttpHeaders headers, IEnumerable<KeyValuePair<string, string>> addList)
        {
            foreach (var pair in addList)
            {
                headers.Add(pair.Key, pair.Value);
            }
        }

        public static void AddRange(this HttpHeaders headers, IEnumerable<KeyValuePair<string, IEnumerable<string>>> addList)
        {
            foreach (var pair in addList)
            {
                headers.Add(pair.Key, pair.Value);
            }
        }
    }
}