// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Preconditions.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace GW2DotNET.Utilities
{
    /// <summary>
    ///     Utility class. Provides static methods for validating arguments.
    /// </summary>
    internal static class Preconditions
    {
        /// <summary>
        ///     Ensures that the specified value is not a null reference.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The actual value.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <param name="message">A message that describes the error.</param>
        /// <exception cref="System.ArgumentNullException">The exception that is thrown when the specified value is null.</exception>
        /// <returns>The specified value.</returns>
        internal static T EnsureNotNull<T>(T value, string paramName = null, string message = null) where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(paramName, message);
            }

            return value;
        }

        /// <summary>
        ///     Ensures that the specified value is equal to the expected value.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="expectedValue">The expected value.</param>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <param name="message">A message that describes the error.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        ///     The exception that is thrown when the specified value differs from
        ///     the expected value.
        /// </exception>
        /// <returns>The specified value.</returns>
        internal static T EnsureExact<T>(T expectedValue, T actualValue, string paramName = null, string message = null)
        {
            if (!object.Equals(expectedValue, actualValue))
            {
                throw new ArgumentOutOfRangeException(paramName, actualValue, message);
            }

            return actualValue;
        }

        /// <summary>
        ///     Ensures that the specified value is in the specified range.
        /// </summary>
        /// <param name="value">The actual value.</param>
        /// <param name="floor">The minimum value.</param>
        /// <param name="ceiling">The maximum value.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <param name="message">A message that describes the error.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        ///     The exception that is thrown when the specified value is out of
        ///     range.
        /// </exception>
        /// <returns>The specified value.</returns>
        internal static int EnsureInRange(
            int value,
            int floor,
            int ceiling,
            string paramName = null,
            string message = null)
        {
            if (value < floor || value > ceiling)
            {
                throw new ArgumentOutOfRangeException(paramName, value, message);
            }

            return value;
        }
    }
}