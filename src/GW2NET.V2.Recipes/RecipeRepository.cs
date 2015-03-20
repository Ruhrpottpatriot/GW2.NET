// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v2/recipes interface. See the remarks section for important limitations regarding this implementation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Recipes
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.Items;
    using GW2NET.Recipes;

    /// <summary>Represents a repository that retrieves data from the /v2/recipes interface. See the remarks section for important limitations regarding this implementation.</summary>
    /// <remarks>
    /// This implementation does not retrieve associated entities.
    /// <list type="bullet">
    ///     <item>
    ///         <description><see cref="Recipe"/>: <see cref="Recipe.BuildId"/> is always <c>0</c>. Retrieve the build number from the build service.</description>
    ///     </item>
    ///     <item>
    ///         <description><see cref="Recipe"/>: <see cref="Recipe.OutputItem"/> is always <c>null</c>. Use the value of <see cref="Recipe.OutputItemId"/> to retrieve the output item.</description>
    ///     </item>
    ///     <item>
    ///         <description><see cref="ItemStack"/>: <see cref="ItemStack.Item"/> is always <c>null</c>. Use the value of <see cref="ItemStack.ItemId"/> to retrieve the ingredient item.</description>
    ///     </item>
    /// </list>
    /// </remarks>
    public class RecipeRepository : IRecipeRepository
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<RecipeDataContract>>, IDictionaryRange<int, Recipe>> converterForBulkResponse;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<int>>, ICollection<int>> converterForIdentifiersResponse;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<RecipeDataContract>>, ICollectionPage<Recipe>> converterForPageResponse;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<RecipeDataContract>, Recipe> converterForResponse;

        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="RecipeRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public RecipeRepository(IServiceClient serviceClient)
            : this(serviceClient, new ConverterAdapter<ICollection<int>>(), new ConverterForRecipe())
        {
            Contract.Requires(serviceClient != null);
        }

        /// <summary>Initializes a new instance of the <see cref="RecipeRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="converterForRecipeCollection">The converter for <see cref="T:ICollection{int}"/>.</param>
        /// <param name="converterForRecipe">The converter for <see cref="Item"/>.</param>
        internal RecipeRepository(IServiceClient serviceClient, IConverter<ICollection<int>, ICollection<int>> converterForRecipeCollection, IConverter<RecipeDataContract, Recipe> converterForRecipe)
        {
            Contract.Requires(serviceClient != null);
            Contract.Requires(converterForRecipeCollection != null);
            Contract.Requires(converterForRecipe != null);
            this.serviceClient = serviceClient;
            this.converterForIdentifiersResponse = new ConverterForResponse<ICollection<int>, ICollection<int>>(converterForRecipeCollection);
            this.converterForResponse = new ConverterForResponse<RecipeDataContract, Recipe>(converterForRecipe);
            this.converterForBulkResponse = new ConverterForDictionaryRangeResponse<RecipeDataContract, int, Recipe>(converterForRecipe, recipe => recipe.RecipeId);
            this.converterForPageResponse = new ConverterForCollectionPageResponse<RecipeDataContract, Recipe>(converterForRecipe);
        }

        /// <inheritdoc />
        CultureInfo ILocalizable.Culture { get; set; }

        /// <inheritdoc />
        ICollection<int> IDiscoverable<int>.Discover()
        {
            var request = new RecipeDiscoveryRequest();
            var response = this.serviceClient.Send<ICollection<int>>(request);
            return this.converterForIdentifiersResponse.Convert(response) ?? new List<int>(0);
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
            var responseTask = this.serviceClient.SendAsync<ICollection<int>>(request, cancellationToken);
            return responseTask.ContinueWith<ICollection<int>>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        ICollection<int> IRecipeRepository.DiscoverByInput(int identifier)
        {
            var request = new RecipeSearchRequest
            {
                Input = identifier
            };
            var response = this.serviceClient.Send<ICollection<int>>(request);
            return this.converterForIdentifiersResponse.Convert(response);
        }

        /// <inheritdoc />
        Task<ICollection<int>> IRecipeRepository.DiscoverByInputAsync(int identifier)
        {
            IRecipeRepository self = this;
            return self.DiscoverByInputAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollection<int>> IRecipeRepository.DiscoverByInputAsync(int identifier, CancellationToken cancellationToken)
        {
            var request = new RecipeSearchRequest
            {
                Input = identifier
            };
            var responseTask = this.serviceClient.SendAsync<ICollection<int>>(request, cancellationToken);
            return responseTask.ContinueWith<ICollection<int>>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        ICollection<int> IRecipeRepository.DiscoverByOutput(int identifier)
        {
            var request = new RecipeSearchRequest
            {
                Output = identifier
            };
            var response = this.serviceClient.Send<ICollection<int>>(request);
            return this.converterForIdentifiersResponse.Convert(response);
        }

        /// <inheritdoc />
        Task<ICollection<int>> IRecipeRepository.DiscoverByOutputAsync(int identifier)
        {
            IRecipeRepository self = this;
            return self.DiscoverByOutputAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollection<int>> IRecipeRepository.DiscoverByOutputAsync(int identifier, CancellationToken cancellationToken)
        {
            var request = new RecipeSearchRequest
            {
                Output = identifier
            };
            var responseTask = this.serviceClient.SendAsync<ICollection<int>>(request, cancellationToken);
            return responseTask.ContinueWith<ICollection<int>>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        Recipe IRepository<int, Recipe>.Find(int identifier)
        {
            IRecipeRepository self = this;
            var request = new RecipeDetailsRequest
            {
                Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo), 
                Culture = self.Culture
            };
            var response = this.serviceClient.Send<RecipeDataContract>(request);
            return this.converterForResponse.Convert(response);
        }

        /// <inheritdoc />
        IDictionaryRange<int, Recipe> IRepository<int, Recipe>.FindAll()
        {
            IRecipeRepository self = this;
            var request = new RecipeBulkRequest
            {
                Culture = self.Culture
            };
            var response = this.serviceClient.Send<ICollection<RecipeDataContract>>(request);
            return this.converterForBulkResponse.Convert(response);
        }

        /// <inheritdoc />
        IDictionaryRange<int, Recipe> IRepository<int, Recipe>.FindAll(ICollection<int> identifiers)
        {
            IRecipeRepository self = this;
            var request = new RecipeBulkRequest
            {
                Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList(), 
                Culture = self.Culture
            };
            var response = this.serviceClient.Send<ICollection<RecipeDataContract>>(request);
            return this.converterForBulkResponse.Convert(response);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Recipe>> IRepository<int, Recipe>.FindAllAsync()
        {
            IRecipeRepository self = this;
            return self.FindAllAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Recipe>> IRepository<int, Recipe>.FindAllAsync(CancellationToken cancellationToken)
        {
            IRecipeRepository self = this;
            var request = new RecipeBulkRequest
            {
                Culture = self.Culture
            };
            var responseTask = this.serviceClient.SendAsync<ICollection<RecipeDataContract>>(request, cancellationToken);
            return responseTask.ContinueWith<IDictionaryRange<int, Recipe>>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Recipe>> IRepository<int, Recipe>.FindAllAsync(ICollection<int> identifiers)
        {
            IRecipeRepository self = this;
            return self.FindAllAsync(identifiers, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Recipe>> IRepository<int, Recipe>.FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            IRecipeRepository self = this;
            var request = new RecipeBulkRequest
            {
                Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList(), 
                Culture = self.Culture
            };
            var responseTask = this.serviceClient.SendAsync<ICollection<RecipeDataContract>>(request, cancellationToken);
            return responseTask.ContinueWith<IDictionaryRange<int, Recipe>>(this.ConvertAsyncResponse, cancellationToken);
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
                Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo), 
                Culture = self.Culture
            };
            var responseTask = this.serviceClient.SendAsync<RecipeDataContract>(request, cancellationToken);
            return responseTask.ContinueWith<Recipe>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        ICollectionPage<Recipe> IPaginator<Recipe>.FindPage(int pageIndex)
        {
            IRecipeRepository self = this;
            var request = new RecipePageRequest
            {
                Page = pageIndex, 
                Culture = self.Culture
            };
            var response = this.serviceClient.Send<ICollection<RecipeDataContract>>(request);
            var values = this.converterForPageResponse.Convert(response);
            PageContextPatchUtility.Patch(values, pageIndex);
            return values;
        }

        /// <inheritdoc />
        ICollectionPage<Recipe> IPaginator<Recipe>.FindPage(int pageIndex, int pageSize)
        {
            IRecipeRepository self = this;
            var request = new RecipePageRequest
            {
                Page = pageIndex, 
                PageSize = pageSize, 
                Culture = self.Culture
            };
            var response = this.serviceClient.Send<ICollection<RecipeDataContract>>(request);
            var values = this.converterForPageResponse.Convert(response);
            PageContextPatchUtility.Patch(values, pageIndex);
            return values;
        }

        /// <inheritdoc />
        Task<ICollectionPage<Recipe>> IPaginator<Recipe>.FindPageAsync(int pageIndex)
        {
            IRecipeRepository self = this;
            return self.FindPageAsync(pageIndex, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollectionPage<Recipe>> IPaginator<Recipe>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            IRecipeRepository self = this;
            var request = new RecipePageRequest
            {
                Page = pageIndex, 
                Culture = self.Culture
            };
            var responseTask = this.serviceClient.SendAsync<ICollection<RecipeDataContract>>(request, cancellationToken);
            return responseTask.ContinueWith(task => this.ConvertAsyncResponse(task, pageIndex), cancellationToken);
        }

        /// <inheritdoc />
        Task<ICollectionPage<Recipe>> IPaginator<Recipe>.FindPageAsync(int pageIndex, int pageSize)
        {
            IRecipeRepository self = this;
            return self.FindPageAsync(pageIndex, pageSize, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollectionPage<Recipe>> IPaginator<Recipe>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            IRecipeRepository self = this;
            var request = new RecipePageRequest
            {
                Page = pageIndex, 
                PageSize = pageSize, 
                Culture = self.Culture
            };
            var responseTask = this.serviceClient.SendAsync<ICollection<RecipeDataContract>>(request, cancellationToken);
            return responseTask.ContinueWith(task => this.ConvertAsyncResponse(task, pageIndex), cancellationToken);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private IDictionaryRange<int, Recipe> ConvertAsyncResponse(Task<IResponse<ICollection<RecipeDataContract>>> task)
        {
            Contract.Requires(task != null);
            Contract.Ensures(Contract.Result<IDictionaryRange<int, Recipe>>() != null);
            var values = this.converterForBulkResponse.Convert(task.Result);
            if (values == null)
            {
                return new DictionaryRange<int, Recipe>(0);
            }

            return values;
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private ICollectionPage<Recipe> ConvertAsyncResponse(Task<IResponse<ICollection<RecipeDataContract>>> task, int pageIndex)
        {
            Contract.Requires(task != null);
            Contract.Ensures(Contract.Result<ICollectionPage<Recipe>>() != null);
            var values = this.converterForPageResponse.Convert(task.Result);
            if (values == null)
            {
                return new CollectionPage<Recipe>(0);
            }

            PageContextPatchUtility.Patch(values, pageIndex);

            return values;
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private ICollection<int> ConvertAsyncResponse(Task<IResponse<ICollection<int>>> task)
        {
            Contract.Requires(task != null);
            Contract.Ensures(Contract.Result<ICollection<int>>() != null);
            var ids = this.converterForIdentifiersResponse.Convert(task.Result);
            if (ids == null)
            {
                return new List<int>(0);
            }

            return ids;
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private Recipe ConvertAsyncResponse(Task<IResponse<RecipeDataContract>> task)
        {
            Contract.Requires(task != null);
            return this.converterForResponse.Convert(task.Result);
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.serviceClient != null);
            Contract.Invariant(this.converterForResponse != null);
            Contract.Invariant(this.converterForIdentifiersResponse != null);
            Contract.Invariant(this.converterForBulkResponse != null);
            Contract.Invariant(this.converterForPageResponse != null);
        }
    }
}