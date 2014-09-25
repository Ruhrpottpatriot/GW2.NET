// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemPageRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for a collection of items and their localized details.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V2.Items
{
    using System.Collections.Generic;
    using System.Globalization;

    using GW2DotNET.Common;
    using GW2DotNET.V2.Common;

    /// <summary>Represents a request for a collection of items and their localized details.</summary>
    internal sealed class ItemPageRequest : PageRequest, ILocalizable
    {
        /// <summary>Gets or sets the locale.</summary>
        public CultureInfo Culture { get; set; }

        /// <summary>Gets the resource path.</summary>
        public override string Resource
        {
            get
            {
                return "/v2/items";
            }
        }

        /// <summary>Gets the request parameters.</summary>
        /// <returns>A collection of parameters.</returns>
        public override IEnumerable<KeyValuePair<string, string>> GetParameters()
        {
            var culture = this.Culture;
            if (culture != null)
            {
                yield return new KeyValuePair<string, string>("lang", culture.TwoLetterISOLanguageName);
            }
        }
    }
}