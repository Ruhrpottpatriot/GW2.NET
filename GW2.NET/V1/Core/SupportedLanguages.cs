// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupportedLanguages.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System.Globalization;

namespace GW2DotNET.V1.Core
{
    /// <summary>
    /// Utility class. Provides static properties enumerating the supported languages.
    /// </summary>
    public static class SupportedLanguages
    {
        /// <summary>
        /// Gets the English language.
        /// </summary>
        public static CultureInfo English
        {
            get { return CultureInfo.GetCultureInfo("en"); }
        }

        /// <summary>
        /// Gets the French language.
        /// </summary>
        public static CultureInfo French
        {
            get { return CultureInfo.GetCultureInfo("fr"); }
        }

        /// <summary>
        /// Gets the German language.
        /// </summary>
        public static CultureInfo German
        {
            get { return CultureInfo.GetCultureInfo("de"); }
        }

        /// <summary>
        /// Gets the Spanish language.
        /// </summary>
        public static CultureInfo Spanish
        {
            get { return CultureInfo.GetCultureInfo("es"); }
        }
    }
}
