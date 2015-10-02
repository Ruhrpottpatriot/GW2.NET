// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v1/recipes.json and /v1/recipe_details.json interfaces.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace GW2NET.V1.Recipes.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Recipes;
    using GW2NET.V1.Recipes.Json;

    /// <summary>Represents a repository that retrieves data from the /v1/recipes.json and /v1/recipe_details.json interfaces.</summary>
    public class RecipeRepository : IRecipeRepository
    {
        
        private readonly IConverter<RecipeDTO, Recipe> recipeConverter;

        
        private readonly IConverter<RecipeCollectionDTO, ICollection<int>> recipeCollectionConverter;

        
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="RecipeRepository"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <param name="recipeCollectionConverter">The converter for <see cref="T:ICollection{int}"/>.</param>
        /// <param name="recipeConverter">The converter for <see cref="Recipe"/>.</param>
        public RecipeRepository(IServiceClient serviceClient, IConverter<RecipeCollectionDTO, ICollection<int>> recipeCollectionConverter, IConverter<RecipeDTO, Recipe> recipeConverter)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient");
            }

            if (recipeCollectionConverter == null)
            {
                throw new ArgumentNullException("recipeCollectionConverter");
            }

            if (recipeConverter == null)
            {
                throw new ArgumentNullException("recipeConverter");
            }

            this.serviceClient = serviceClient;
            this.recipeCollectionConverter = recipeCollectionConverter;
            this.recipeConverter = recipeConverter;
        }

        /// <inheritdoc />
        CultureInfo ILocalizable.Culture { get; set; }

        /// <inheritdoc />
        ICollection<int> IDiscoverable<int>.Discover()
        {
            var request = new RecipeDiscoveryRequest();
            var response = this.serviceClient.Send<RecipeCollectionDTO>(request);
            if (response.Content == null)
            {
                return new List<int>(0);
            }

            return this.recipeCollectionConverter.Convert(response.Content, null);
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync()
        {
            IRecipeRepository self = this;
            return self.DiscoverAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync(CancellationToken cancellationToken)
        {
            var request = new RecipeDiscoveryRequest();
            var responseTask = this.serviceClient.SendAsync<RecipeCollectionDTO>(request, cancellationToken);
            return responseTask.ContinueWith<ICollection<int>>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        ICollection<int> IRecipeRepository.DiscoverByInput(int identifier)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollection<int>> IRecipeRepository.DiscoverByInputAsync(int identifier)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollection<int>> IRecipeRepository.DiscoverByInputAsync(int identifier, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        ICollection<int> IRecipeRepository.DiscoverByOutput(int identifier)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollection<int>> IRecipeRepository.DiscoverByOutputAsync(int identifier)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollection<int>> IRecipeRepository.DiscoverByOutputAsync(int identifier, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Recipe IRepository<int, Recipe>.Find(int identifier)
        {
            IRecipeRepository self = this;
            var request = new RecipeDetailsRequest
            {
                RecipeId = identifier,
                Culture = self.Culture
            };
            var response = this.serviceClient.Send<RecipeDTO>(request);
            if (response.Content == null)
            {
                return null;
            }

            var recipe = this.recipeConverter.Convert(response.Content, null);
            recipe.Culture = request.Culture;
            return recipe;
        }

        /// <inheritdoc />
        IDictionaryRange<int, Recipe> IRepository<int, Recipe>.FindAll()
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        IDictionaryRange<int, Recipe> IRepository<int, Recipe>.FindAll(ICollection<int> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Recipe>> IRepository<int, Recipe>.FindAllAsync()
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Recipe>> IRepository<int, Recipe>.FindAllAsync(CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Recipe>> IRepository<int, Recipe>.FindAllAsync(ICollection<int> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Recipe>> IRepository<int, Recipe>.FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<Recipe> IRepository<int, Recipe>.FindAsync(int identifier)
        {
            IRecipeRepository self = this;
            return self.FindAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<Recipe> IRepository<int, Recipe>.FindAsync(int identifier, CancellationToken cancellationToken)
        {
            IRecipeRepository self = this;
            var request = new RecipeDetailsRequest
            {
                RecipeId = identifier,
                Culture = self.Culture
            };
            var responseTask = this.serviceClient.SendAsync<RecipeDTO>(request, cancellationToken);
            return responseTask.ContinueWith(
                task =>
                {
                    var recipe = this.ConvertsAsyncResponse(task);
                    recipe.Culture = request.Culture;
                    return recipe;
                },
            cancellationToken);
        }

        /// <inheritdoc />
        ICollectionPage<Recipe> IPaginator<Recipe>.FindPage(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        ICollectionPage<Recipe> IPaginator<Recipe>.FindPage(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<Recipe>> IPaginator<Recipe>.FindPageAsync(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<Recipe>> IPaginator<Recipe>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<Recipe>> IPaginator<Recipe>.FindPageAsync(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<Recipe>> IPaginator<Recipe>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private ICollection<int> ConvertAsyncResponse(Task<IResponse<RecipeCollectionDTO>> task)
        {
            var response = task.Result;
            if (response.Content == null)
            {
                return new List<int>(0);
            }

            return this.recipeCollectionConverter.Convert(response.Content, null);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private Recipe ConvertsAsyncResponse(Task<IResponse<RecipeDTO>> task)
        {
            var response = task.Result;
            if (response.Content == null)
            {
                return null;
            }

            return this.recipeConverter.Convert(response.Content, null);
        }
    }
}