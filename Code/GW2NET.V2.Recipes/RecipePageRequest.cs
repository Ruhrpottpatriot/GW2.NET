// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipePageRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a page request that targets the /v2/recipes interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Recipes
{
    using System.Collections.Generic;
    using System.Globalization;

    using GW2NET.Common;
    using GW2NET.Common;

    /// <summary>Represents a page request that targets the /v2/recipes interface.</summary>
    internal sealed class RecipePageRequest : PageRequest, ILocalizable
    {
        /// <summary>Gets or sets the locale.</summary>
        public CultureInfo Culture { get; set; }

        /// <summary>Gets the resource path.</summary>
        public override string Resource
        {
            get
            {
                return "/v2/recipes";
            }
        }

        /// <summary>Gets the request parameters.</summary>
        /// <returns>A collection of parameters.</returns>
        public override IEnumerable<KeyValuePair<string, string>> GetParameters()
        {
            foreach (var parameter in base.GetParameters())
            {
                yield return parameter;
            }

            var culture = this.Culture;
            if (culture != null)
            {
                yield return new KeyValuePair<string, string>("lang", culture.TwoLetterISOLanguageName);
            }
        }
    }
}