// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContinentRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for static information about the continents.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Continents
{
    using System.Collections.Generic;
    using System.Globalization;

    using GW2NET.Common;

    /// <summary>Represents a request for static information about the continents.</summary>
    public sealed class ContinentRequest : IRequest, ILocalizable
    {
        /// <summary>Gets or sets the locale.</summary>
        public CultureInfo Culture { get; set; }

        /// <summary>Gets the resource path.</summary>
        public string Resource
        {
            get
            {
                return "v1/continents.json";
            }
        }

        /// <summary>Gets the request parameters.</summary>
        /// <returns>A collection of parameters.</returns>
        public IEnumerable<KeyValuePair<string, string>> GetParameters()
        {
            var locale = this.Culture;
            if (locale != null)
            {
                yield return new KeyValuePair<string, string>("lang", locale.TwoLetterISOLanguageName);
            }
        }
    }
}