// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeDetailsServiceRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for information regarding a specific recipe.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Recipes.Details
{
    using GW2DotNET.Extensions;
    using GW2DotNET.V1.Common;

    /// <summary>Represents a request for information regarding a specific recipe.</summary>
    public class RecipeDetailsServiceRequest : ServiceRequest
    {
        /// <summary>Infrastructure. Stores a parameter.</summary>
        private int? recipeId;

        /// <summary>Initializes a new instance of the <see cref="RecipeDetailsServiceRequest" /> class.</summary>
        public RecipeDetailsServiceRequest()
            : base(Services.RecipeDetails)
        {
        }

        /// <summary>Gets or sets the recipe ID.</summary>
        public int? RecipeId
        {
            get
            {
                return this.recipeId;
            }

            set
            {
                this.Query["recipe_id"] = (this.recipeId = value).ToStringInvariant();
            }
        }
    }
}