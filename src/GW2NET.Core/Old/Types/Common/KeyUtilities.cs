// --------------------------------------------------------------------------------------------------------------------
// <copyright file="KeyUtilities.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides static utility functions for api keys.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Common
{
    using System.Text.RegularExpressions;

    /// <summary>Provides static utility functions for api keys.</summary>
    public static class KeyUtilities
    {
        /// <summary>Describes the pattern a api key has.
        /// </summary>
        private const string Pattern = @"\b[A-F0-9]{8}(?:-[A-F0-9]{4}){3}-[A-F0-9]{20}(?:-[A-F0-9]{4}){3}-[A-F0-9]{12}\b";

        /// <summary>Checks if a specified string is a valid api key.</summary>
        /// <param name="key">The key to check.</param>
        /// <returns>True when the string is a valid api key, otherwise false.</returns>
        public static bool IsValid(string key)
        {
            Regex regex = new Regex(Pattern, RegexOptions.CultureInvariant);

            return regex.IsMatch(key);
        }
    }
}
