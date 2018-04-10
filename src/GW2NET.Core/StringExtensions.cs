// <copyright file="StringExtensions.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET
{
    using System;

    public static class StringExtensions
    {
        /// <summary>Returns a new string with the specified amount of characters removed, starting from the end.</summary>
        /// <param name="input">The input string.</param>
        /// <param name="amount">The amount of characters to remove.</param>
        /// <returns></returns>
        public static string RemoveFromEnd(this string input, int amount)
        {
            int startingIdx = input.Length - (amount + 1);
            if (startingIdx < 0)
            {
                throw new ArgumentOutOfRangeException("The amount of characters to remove is greater than the string length.");
            }

            return input.Remove(startingIdx);
        }
    }
}
