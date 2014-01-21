// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Preconditions.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace GW2DotNET.V1.Core
{
    /// <summary>
    /// Utility class. Provides static methods for validating arguments.
    /// </summary>
    internal static class Preconditions
    {
        /// <summary>
        /// Ensures that the specified value is not a null reference.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The actual value.</param>
        /// <exception cref="ArgumentNullException">The exception that is thrown when the specified value is null.</exception>
        /// <returns>The specified value.</returns>
        internal static T EnsureNotNull<T>(T value) where T : class
        {
            return Preconditions.EnsureNotNull(value, null, null);
        }

        /// <summary>
        /// Ensures that the specified value is not a null reference.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The actual value.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <exception cref="ArgumentNullException">The exception that is thrown when the specified value is null.</exception>
        /// <returns>The specified value.</returns>
        internal static T EnsureNotNull<T>(T value, string paramName) where T : class
        {
            return Preconditions.EnsureNotNull(value, paramName, null);
        }

        /// <summary>
        /// Ensures that the specified value is not a null reference.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The actual value.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <param name="message">A message that describes the error.</param>
        /// <exception cref="ArgumentNullException">The exception that is thrown when the specified value is null.</exception>
        /// <returns>The specified value.</returns>
        internal static T EnsureNotNull<T>(T value, string paramName, string message) where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(paramName, message);
            }

            return value;
        }
    }
}