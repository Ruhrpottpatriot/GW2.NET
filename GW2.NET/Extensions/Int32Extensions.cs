// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Int32Extensions.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides extension methods for the  type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Extensions
{
    using System.Globalization;

    /// <summary>Provides extension methods for the <see cref="T:System.Int32" /> type.</summary>
    public static class Int32Extensions
    {
        /// <summary>Converts the numeric value of this instance to its equivalent string representation using the format rules of the invariant culture.</summary>
        /// <param name="instance">The instance.</param>
        /// <returns>The string representation of the value of this instance as specified by provider.</returns>
        public static string ToStringInvariant(this int instance)
        {
            return instance.ToString(NumberFormatInfo.InvariantInfo);
        }

        /// <summary>Converts the numeric value of this instance to its equivalent string representation using the format rules of the invariant culture.</summary>
        /// <param name="instance">The instance.</param>
        /// <returns>The string representation of the value of this instance as specified by provider.</returns>
        public static string ToStringInvariant(this int? instance)
        {
            return !instance.HasValue ? string.Empty : instance.Value.ToString(NumberFormatInfo.InvariantInfo);
        }
    }
}