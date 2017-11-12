// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocalizableRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Common
{
    using System.Collections.Generic;
    using System.Globalization;

    /// <summary>Represents a request, targeting any the v2/ endpoint.</summary>
    public abstract class LocalizableRequest : IRequest, ILocalizable
    {
        /// <summary>Gets or sets the locale.</summary>
        public CultureInfo Culture { get; set; }

        /// <summary>Gets the resource path.</summary>
        public abstract string Resource { get; }

        /// <summary>Gets the request parameters.</summary>
        /// <returns>A collection of parameters.</returns>
        public virtual IEnumerable<KeyValuePair<string, string>> GetParameters()
        {
            // Get the 'lang' parameter
            if (this.Culture != null)
            {
                yield return new KeyValuePair<string, string>("lang", this.Culture.TwoLetterISOLanguageName);
            }
        }

        /// <summary>The get path segments.</summary>
        /// <returns>The <see cref="IEnumerable{T}"/>.</returns>
        public virtual IEnumerable<string> GetPathSegments()
        {
            yield break;
        }
    }
}
