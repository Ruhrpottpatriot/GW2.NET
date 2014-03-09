// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeExtensions.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides utility methods for the <see cref="System.Type" /> class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.Extensions
{
    using System;

    /// <summary>
    ///     Provides utility methods for the <see cref="System.Type" /> class.
    /// </summary>
    internal static class TypeExtensions
    {
        #region Methods

        /// <summary>Gets the default value of the specified type.</summary>
        /// <param name="type">The instance of <see cref="System.Type"/> that specifies the target type.</param>
        /// <returns>The default value.</returns>
        /// <remarks>This method is semantically the equivalent of calling <c>default(objectType)</c>.</remarks>
        internal static object CreateDefault(this Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }

            return null;
        }

        #endregion
    }
}