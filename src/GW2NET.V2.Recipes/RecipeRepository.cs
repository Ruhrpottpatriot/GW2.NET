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
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.Items;
    using GW2NET.Recipes;
    using GW2NET.V2.Recipes.Json;

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
    ///         <description><see cref="ItemQuantity"/>: <see cref="ItemQuantity.Item"/> is always <c>null</c>. Use the value of <see cref="ItemQuantity.ItemId"/> to retrieve the ingredient item.</description>
    ///     </item>
    /// </list>
    /// </remarks>
    public class RecipeRepository : IRecipeRepository
    {
        
        private readonly IConverter<IResponse<ICollection<RecipeDTO>>, IDictionaryRange<int, Recipe>> bulkResponseConverter;

        
        private readonly IConverter<IResponse<ICollection<int>>, ICollection<int>> identifiersResponseConverter;

        
        private readonly IConverter<IResponse<ICollection<RecipeDTO>>, ICollectionPage<Recipe>> pageResponseConverter;

        
        private readonly IConverter<IResponse<RecipeDTO>, Recipe> responseConverter;

        
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="RecipeRepository"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <param name="identifiersResponseConverter"></param>
        /// <param name="responseConverter"></param>
        /// <param name="bulkResponseConverter"></param>
        /// <param name="pageResponseConverter"></param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> or <paramref name="RecipeCollectionConverter"/> or <paramref name="RecipeConverter"/> is a null reference.</exception>
        public RecipeRepository(IServiceClient serviceClient,
            IConverter<IResponse<ICollection<int>>, ICollection<int>> identifiersResponseConverter,
            IConverter<IResponse<RecipeDTO>, Recipe> responseConverter,
            IConverter<IResponse<ICollection<RecipeDTO>>, IDictionaryRange<int, Recipe>> bulkResponseConverter,
            IConverter<IResponse<ICollection<RecipeDTO>>, ICollectionPage<Recipe>> pageResponseConverter)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient");
            }

            if (identifiersResponseConverter == null)
            {
                throw new ArgumentNullException("identifiersResponseConverter");
            }

            if (responseConverter == null)
            {
                throw new ArgumentNullException("responseConverter");
            }

            if (bulkResponseConverter == null)
            {
                throw new ArgumentNullException("bulkResponseConverter");
            }

            if (pageResponseConverter == null)
            {
                throw new ArgumentNullException("pageResponseConverter");
            }

            this.serviceClient = serviceClient;
            this.identifiersResponseConverter = identifiersResponseConverter;
            this.responseConverter = responseConverter;
            this.bulkResponseConverter = bulkResponseConverter;
            this.pageResponseConverter = pageResponseConverter;
        }

        /// <inheritdoc />
        CultureInfo ILocalizable.Culture { get; set; }

        /// <inheritdoc />
        ICollection<int> IDiscoverable<int>.Discover()
        {
            var request = new RecipeDiscoveryRequest();
            var response = this.serviceClient.Send<ICollection<int>>(request);
            return this.identifiersResponseConverter.Convert(response, null) ?? new List<int>(0);
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
            return this.identifiersResponseConverter.Convert(response, null);
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
            return this.identifiersResponseConverter.Convert(response, null);
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
            var response = this.serviceClient.Send<RecipeDTO>(request);
            return this.responseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        IDictionaryRange<int, Recipe> IRepository<int, Recipe>.FindAll()
        {
            IRecipeRepository self = this;
            var request = new RecipeBulkRequest
            {
                Culture = self.Culture
            };
            var response = this.serviceClient.Send<ICollection<RecipeDTO>>(request);
            return this.bulkResponseConverter.Convert(response, null);
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
            var response = this.serviceClient.Send<ICollection<RecipeDTO>>(request);
            return this.bulkResponseConverter.Convert(response, null);
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
            var responseTask = this.serviceClient.SendAsync<ICollection<RecipeDTO>>(request, cancellationToken);
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
            var responseTask = this.serviceClient.SendAsync<ICollection<RecipeDTO>>(request, cancellationToken);
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
            var responseTask = this.serviceClient.SendAsync<RecipeDTO>(request, cancellationToken);
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
            var response = this.serviceClient.Send<ICollection<RecipeDTO>>(request);
            var values = this.pageResponseConverter.Convert(response, pageIndex);
            return values ?? new CollectionPage<Recipe>(0);
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
            var response = this.serviceClient.Send<ICollection<RecipeDTO>>(request);
            var values = this.pageResponseConverter.Convert(response, pageIndex);
            return values ?? new CollectionPage<Recipe>(0);
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
            var responseTask = this.serviceClient.SendAsync<ICollection<RecipeDTO>>(request, cancellationToken);
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
            var responseTask = this.serviceClient.SendAsync<ICollection<RecipeDTO>>(request, cancellationToken);
            return responseTask.ContinueWith(task => this.ConvertAsyncResponse(task, pageIndex), cancellationToken);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private IDictionaryRange<int, Recipe> ConvertAsyncResponse(Task<IResponse<ICollection<RecipeDTO>>> task)
        {
            Debug.Assert(task != null, "task != null");
            var values = this.bulkResponseConverter.Convert(task.Result, null);
            if (values == null)
            {
                return new DictionaryRange<int, Recipe>(0);
            }

            return values;
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private ICollectionPage<Recipe> ConvertAsyncResponse(Task<IResponse<ICollection<RecipeDTO>>> task, int pageIndex)
        {
            Debug.Assert(task != null, "task != null");
            var values = this.pageResponseConverter.Convert(task.Result, pageIndex);
            return values ?? new CollectionPage<Recipe>(0);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private ICollection<int> ConvertAsyncResponse(Task<IResponse<ICollection<int>>> task)
        {
            Debug.Assert(task != null, "task != null");
            var ids = this.identifiersResponseConverter.Convert(task.Result, null);
            if (ids == null)
            {
                return new List<int>(0);
            }

            return ids;
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private Recipe ConvertAsyncResponse(Task<IResponse<RecipeDTO>> task)
        {
            Debug.Assert(task != null, "task != null");
            return this.responseConverter.Convert(task.Result, null);
        }

    }
}