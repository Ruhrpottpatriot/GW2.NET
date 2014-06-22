// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the recipes service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Recipes
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Common.Serializers;
    using GW2DotNET.V1.Recipes.Contracts;

    /// <summary>Provides the default implementation of the recipes service.</summary>
    public class RecipeService : IRecipeService
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="RecipeService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public RecipeService(IServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a collection of discovered recipes.</summary>
        /// <returns>A collection of discovered recipes.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes">wiki</a> for more information.</remarks>
        public IEnumerable<int> GetRecipes()
        {
            var request = new RecipeRequest();
            var result = this.serviceClient.Send(request, new JsonSerializer<RecipeCollectionResult>());

            return result.Recipes;
        }

        /// <summary>Gets a collection of discovered recipes.</summary>
        /// <returns>A collection of discovered recipes.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes">wiki</a> for more information.</remarks>
        public Task<IEnumerable<int>> GetRecipesAsync()
        {
            return this.GetRecipesAsync(CancellationToken.None);
        }

        /// <summary>Gets a collection of discovered recipes.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of discovered recipes.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes">wiki</a> for more information.</remarks>
        public Task<IEnumerable<int>> GetRecipesAsync(CancellationToken cancellationToken)
        {
            var request = new RecipeRequest();
            var t1 = this.serviceClient.SendAsync(request, new JsonSerializer<RecipeCollectionResult>(), cancellationToken);
            var t2 = t1.ContinueWith<IEnumerable<int>>(task => task.Result.Recipes, cancellationToken);

            return t2;
        }
    }
}