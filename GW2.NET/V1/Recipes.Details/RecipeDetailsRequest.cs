// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeDetailsRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for information regarding a specific recipe.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Recipes.Details
{
    using System.Globalization;

    using GW2DotNET.Common;
    using GW2DotNET.V1.Common;

    /// <summary>Represents a request for information regarding a specific recipe.</summary>
    public class RecipeDetailsRequest : IRecipeRequest, ILocalizable
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
                return Services.RecipeDetails;
            }
        }
    }
}