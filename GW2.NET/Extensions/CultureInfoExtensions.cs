// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CultureInfoExtensions.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides extension methods for the <see cref="System.Globalization.CultureInfo" /> type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Extensions
{
    using System.Collections.Generic;
    using System.Globalization;

    using GW2DotNET.Utilities;

    /// <summary>Provides extension methods for the <see cref="System.Globalization.CultureInfo" /> type.</summary>
    public static class CultureInfoExtensions
    {
        /// <summary>Infrastructure. Stores the collection of supported languages.</summary>
        private static readonly ICollection<CultureInfo> SupportedCultureInfos;

        /// <summary>Initializes static members of the <see cref="CultureInfoExtensions" /> class.</summary>
        static CultureInfoExtensions()
        {
            SupportedCultureInfos = new HashSet<CultureInfo> { new CultureInfo("de"), new CultureInfo("en"), new CultureInfo("es"), new CultureInfo("fr") };
        }

        /// <summary>Gets the culture info or a default culture info if not supported.</summary>
        /// <param name="instance">The instance.</param>
        /// <param name="name">The name of the culture info.</param>
        /// <returns>The culture info.</returns>
        public static CultureInfo GetLanguageInfoOrDefault(this CultureInfo instance, string name = "en")
        {
            Preconditions.EnsureNotNull(instance);
            return IsSupported(instance) ? instance.ToLanguageInfo() : new CultureInfo(name).ToLanguageInfo();
        }

        /// <summary>Determines whether the specified culture info is supported.</summary>
        /// <param name="instance">The instance.</param>
        /// <returns>True if the specified culture info is supported; otherwise false.</returns>
        public static bool IsSupported(this CultureInfo instance)
        {
            Preconditions.EnsureNotNull(instance);
            return SupportedCultureInfos.Contains(instance);
        }

        /// <summary>To the language information.</summary>
        /// <param name="instance">The instance.</param>
        /// <returns>The language info</returns>
        public static CultureInfo ToLanguageInfo(this CultureInfo instance)
        {
            Preconditions.EnsureNotNull(instance);
            return new CultureInfo(instance.TwoLetterISOLanguageName);
        }
    }
}