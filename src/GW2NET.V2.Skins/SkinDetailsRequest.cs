// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkinDetailsRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a details request that targets the /v2/skins interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Skins
{
    using System.Collections.Generic;
    using System.Globalization;

    using GW2NET.Common;

    /// <summary>Represents a details request that targets the /v2/skins interface.</summary>
    public sealed class SkinDetailsRequest : DetailsRequest, ILocalizable
    {
        /// <summary>Gets or sets the locale.</summary>
        public CultureInfo Culture { get; set; }

        /// <summary>Gets the resource path.</summary>
        public override string Resource
        {
            get
            {
                return "/v2/skins";
            }
        }

        protected override IEnumerable<KeyValuePair<string, string>> GetParameters(string id)
        {
            var culture = this.Culture;
            if (culture != null)
            {
                yield return new KeyValuePair<string, string>("lang", culture.TwoLetterISOLanguageName);
            }
        }
    }
}