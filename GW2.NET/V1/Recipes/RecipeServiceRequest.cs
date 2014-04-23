// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeServiceRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for a list of all discovered recipes.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Recipes
{
    using GW2DotNET.V1.Common;

    /// <summary>Represents a request for a list of all discovered recipes.</summary>
    public class RecipeServiceRequest : ServiceRequest
    {
        /// <summary>Initializes a new instance of the <see cref="RecipeServiceRequest" /> class.</summary>
        public RecipeServiceRequest()
            : base(Services.Recipes)
        {
        }
    }
}