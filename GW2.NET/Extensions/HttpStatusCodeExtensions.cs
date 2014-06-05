// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HttpStatusCodeExtensions.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides extension methods for the <see cref="System.Net.HttpStatusCode" /> type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.Extensions
{
    using System.Net;

    /// <summary>Provides extension methods for the <see cref="System.Net.HttpStatusCode" /> type.</summary>
    public static class HttpStatusCodeExtensions
    {
        /// <summary>Gets whether the specified status code indicates success.</summary>
        /// <param name="value">The status code.</param>
        /// <returns>True if the status code indicates success; otherwise false.</returns>
        public static bool IsSuccessStatusCode(this HttpStatusCode value)
        {
            return ((int)value >= 200) && ((int)value < 300);
        }
    }
}