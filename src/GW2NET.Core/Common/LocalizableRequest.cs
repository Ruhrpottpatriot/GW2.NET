// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocalizableRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Common
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;

    /// <summary>Provides the base class for requests for content with a given locale.</summary>
    public abstract class LocalizableRequest : IRequest, ILocalizable
    {
        /// <inheritdoc />
        public CultureInfo Culture { get; set; }

        /// <inheritdoc />
        public abstract string Resource { get; }

        /// <inheritdoc />
        public IEnumerable<KeyValuePair<string, string>> GetParameters()
        {
            var lang = this.Culture;

            foreach (var parameter in this.GetParameters(lang))
            {
                Debug.Assert(!string.Equals(parameter.Key, "lang", StringComparison.OrdinalIgnoreCase), "parameter.Key != lang");
                yield return parameter;
            }

            if (lang != null)
            {
                yield return new KeyValuePair<string, string>("lang", lang.TwoLetterISOLanguageName);
            }
        }

        protected virtual IEnumerable<KeyValuePair<string, string>> GetParameters(CultureInfo culture)
        {
            yield break;
        }

        /// <inheritdoc />
        public virtual IEnumerable<string> GetPathSegments()
        {
            yield break;
        }
    }
}
