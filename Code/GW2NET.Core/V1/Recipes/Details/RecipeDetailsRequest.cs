// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeDetailsRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for information regarding a specific recipe.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Recipes
{
    using System.Collections.Generic;
    using System.Globalization;

    using GW2NET.Common;

    /// <summary>Represents a request for information regarding a specific recipe.</summary>
    public class RecipeDetailsRequest : IRequest, ILocalizable
    {
        /// <summary>Gets or sets the locale.</summary>
        public CultureInfo Culture { get; set; }

        /// <summary>Gets or sets the recipe identifier.</summary>
        public int? RecipeId { get; set; }

        /// <summary>Gets the resource path.</summary>
        public string Resource
        {
            get
            {
                return "v1/recipe_details.json";
            }
        }

        /// <summary>Gets the request parameters.</summary>
        /// <returns>A collection of parameters.</returns>
        public IEnumerable<KeyValuePair<string, string>> GetParameters()
        {
            // Get the 'recipe_id' parameter
            if (this.RecipeId.HasValue)
            {
                yield return new KeyValuePair<string, string>("recipe_id", this.RecipeId.Value.ToString(NumberFormatInfo.InvariantInfo));
            }

            // Get the 'lang' parameter
            if (this.Culture != null)
            {
                yield return new KeyValuePair<string, string>("lang", this.Culture.TwoLetterISOLanguageName);
            }
        }

        /// <summary>Gets additional path segments for the targeted resource.</summary>
        /// <returns>A collection of path segments.</returns>
        public IEnumerable<string> GetPathSegments()
        {
            yield break;
        }
    }
}