// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeDetailsRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for information regarding a specific recipe.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.ServiceManagement.ServiceRequests
{
    using GW2DotNET.Extensions;

    /// <summary>Represents a request for information regarding a specific recipe.</summary>
    public class RecipeDetailsRequest : ServiceRequest
    {
        /// <summary>Infrastructure. Stores a parameter.</summary>
        private int? recipeId;

        /// <summary>Initializes a new instance of the <see cref="RecipeDetailsRequest" /> class.</summary>
        public RecipeDetailsRequest()
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