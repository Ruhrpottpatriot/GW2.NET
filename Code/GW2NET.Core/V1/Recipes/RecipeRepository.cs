// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v1/recipes.json and /v1/recipe_details.json interfaces.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Recipes
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Entities.Recipes;
    using GW2NET.V1.Recipes.Converters;
    using GW2NET.V1.Recipes.Json;

    /// <summary>Represents a repository that retrieves data from the /v1/recipes.json and /v1/recipe_details.json interfaces.</summary>
    public class RecipeRepository : IRepository<int, Recipe>, ILocalizable
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<RecipeDataContract, Recipe> converterForRecipe;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<RecipeCollectionDataContract, ICollection<int>> converterForRecipeCollection;

        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="RecipeRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public RecipeRepository(IServiceClient serviceClient)
            : this(serviceClient, new ConverterForRecipeCollection(), new ConverterForRecipe())
        {
            Contract.Requires(serviceClient != null);
        }

        /// <summary>Initializes a new instance of the <see cref="RecipeRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="converterForRecipeCollection">The converter for <see cref="T:ICollection{int}"/>.</param>
        /// <param name="converterForRecipe">The converter for <see cref="Recipe"/>.</param>
        internal RecipeRepository(IServiceClient serviceClient, IConverter<RecipeCollectionDataContract, ICollection<int>> converterForRecipeCollection, IConverter<RecipeDataContract, Recipe> converterForRecipe)
        {
            Contract.Requires(serviceClient != null);
            Contract.Requires(converterForRecipeCollection != null);
            Contract.Requires(converterForRecipe != null);
            this.serviceClient = serviceClient;
            this.converterForRecipeCollection = converterForRecipeCollection;
            this.converterForRecipe = converterForRecipe;
        }

        /// <summary>Gets or sets the locale.</summary>
        public CultureInfo Culture { get; set; }

        /// <inheritdoc />
        ICollection<int> IDiscoverable<int>.Discover()
        {
            var request = new RecipeDiscoveryRequest();
            var response = this.serviceClient.Send<RecipeCollectionDataContract>(request);
            if (response.Content == null)
            {
                return new List<int>(0);
            }

            return this.converterForRecipeCollection.Convert(response.Content);
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync()
        {
            return ((IRepository<int, Recipe>)this).DiscoverAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync(CancellationToken cancellationToken)
        {
            var request = new RecipeDiscoveryRequest();
            var responseTask = this.serviceClient.SendAsync<RecipeCollectionDataContract>(request, cancellationToken);
            return responseTask.ContinueWith<ICollection<int>>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        Recipe IRepository<int, Recipe>.Find(int identifier)
        {
            var request = new RecipeDetailsRequest
            {
                RecipeId = identifier, 
                Culture = this.Culture
            };
            var response = this.serviceClient.Send<RecipeDataContract>(request);
            if (response.Content == null)
            {
                return null;
            }

            var recipe = this.converterForRecipe.Convert(response.Content);
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
            return ((IRepository<int, Recipe>)this).FindAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<Recipe> IRepository<int, Recipe>.FindAsync(int identifier, CancellationToken cancellationToken)
        {
            var request = new RecipeDetailsRequest
            {
                RecipeId = identifier, 
                Culture = this.Culture
            };
            var responseTask = this.serviceClient.SendAsync<RecipeDataContract>(request, cancellationToken);
            return responseTask.ContinueWith(task =>
            {
                var recipe = this.ConvertsAsyncResponse(task);
                recipe.Culture = request.Culture;
                return recipe;
            }, cancellationToken);
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
        private ICollection<int> ConvertAsyncResponse(Task<IResponse<RecipeCollectionDataContract>> task)
        {
            var response = task.Result;
            if (response.Content == null)
            {
                return new List<int>(0);
            }

            return this.converterForRecipeCollection.Convert(response.Content);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private Recipe ConvertsAsyncResponse(Task<IResponse<RecipeDataContract>> task)
        {
            var response = task.Result;
            if (response.Content == null)
            {
                return null;
            }

            return this.converterForRecipe.Convert(response.Content);
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.serviceClient != null);
            Contract.Invariant(this.converterForRecipeCollection != null);
            Contract.Invariant(this.converterForRecipe != null);
        }
    }
}