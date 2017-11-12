﻿// --------------------------------------------------------------------------------------------------------------------
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
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> is a null reference.</exception>
        public RecipeRepository(IServiceClient serviceClient)
            : this(serviceClient, new ConverterAdapter<ICollection<int>>(), new ConverterForRecipe())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="RecipeRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="converterForRecipeCollection">The converter for <see cref="T:ICollection{int}"/>.</param>
        /// <param name="converterForRecipe">The converter for <see cref="Item"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> or <paramref name="converterForRecipeCollection"/> or <paramref name="converterForRecipe"/> is a null reference.</exception>
        internal RecipeRepository(IServiceClient serviceClient, IConverter<ICollection<int>, ICollection<int>> converterForRecipeCollection, IConverter<RecipeDataContract, Recipe> converterForRecipe)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient", "Precondition: serviceClient != null");
            }

            if (converterForRecipeCollection == null)
            {
                throw new ArgumentNullException("converterForRecipeCollection", "Precondition: converterForRecipeCollection != null");
            }

            if (converterForRecipe == null)
            {
                throw new ArgumentNullException("converterForRecipe", "Precondition: converterForRecipe != null");
            }

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
        async Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync(CancellationToken cancellationToken)
        {
            var request = new RecipeDiscoveryRequest();
            var response = await this.serviceClient.SendAsync<ICollection<int>>(request, cancellationToken).ConfigureAwait(false);
            var ids = this.converterForIdentifiersResponse.Convert(response);
            if (ids == null)
            {
                return new List<int>(0);
            }

            return ids;
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
        async Task<ICollection<int>> IRecipeRepository.DiscoverByInputAsync(int identifier, CancellationToken cancellationToken)
        {
            var request = new RecipeSearchRequest
            {
                Input = identifier
            };
            var response = await this.serviceClient.SendAsync<ICollection<int>>(request, cancellationToken).ConfigureAwait(false);
            var ids = this.converterForIdentifiersResponse.Convert(response);
            if (ids == null)
            {
                return new List<int>(0);
            }

            return ids;
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
        async Task<ICollection<int>> IRecipeRepository.DiscoverByOutputAsync(int identifier, CancellationToken cancellationToken)
        {
            var request = new RecipeSearchRequest
            {
                Output = identifier
            };
            var response = await this.serviceClient.SendAsync<ICollection<int>>(request, cancellationToken).ConfigureAwait(false);
            var ids = this.converterForIdentifiersResponse.Convert(response);
            if (ids == null)
            {
                return new List<int>(0);
            }

            return ids;
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
        async Task<IDictionaryRange<int, Recipe>> IRepository<int, Recipe>.FindAllAsync(CancellationToken cancellationToken)
        {
            IRecipeRepository self = this;
            var request = new RecipeBulkRequest
            {
                Culture = self.Culture
            };
            var response = await this.serviceClient.SendAsync<ICollection<RecipeDataContract>>(request, cancellationToken).ConfigureAwait(false);
            var values = this.converterForBulkResponse.Convert(response);
            if (values == null)
            {
                return new DictionaryRange<int, Recipe>(0);
            }

            return values;
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Recipe>> IRepository<int, Recipe>.FindAllAsync(ICollection<int> identifiers)
        {
            IRecipeRepository self = this;
            return self.FindAllAsync(identifiers, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<IDictionaryRange<int, Recipe>> IRepository<int, Recipe>.FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            IRecipeRepository self = this;
            var request = new RecipeBulkRequest
            {
                Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList(),
                Culture = self.Culture
            };
            var response = await this.serviceClient.SendAsync<ICollection<RecipeDataContract>>(request, cancellationToken).ConfigureAwait(false);
            var values = this.converterForBulkResponse.Convert(response);
            if (values == null)
            {
                return new DictionaryRange<int, Recipe>(0);
            }

            return values;
        }

        /// <inheritdoc />
        Task<Recipe> IRepository<int, Recipe>.FindAsync(int identifier)
        {
            IRecipeRepository self = this;
            return self.FindAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<Recipe> IRepository<int, Recipe>.FindAsync(int identifier, CancellationToken cancellationToken)
        {
            IRecipeRepository self = this;
            var request = new RecipeDetailsRequest
            {
                Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo),
                Culture = self.Culture
            };
            var response = await this.serviceClient.SendAsync<RecipeDataContract>(request, cancellationToken).ConfigureAwait(false);
            return this.converterForResponse.Convert(response);
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
        async Task<ICollectionPage<Recipe>> IPaginator<Recipe>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            IRecipeRepository self = this;
            var request = new RecipePageRequest
            {
                Page = pageIndex,
                Culture = self.Culture
            };
            var response = await this.serviceClient.SendAsync<ICollection<RecipeDataContract>>(request, cancellationToken).ConfigureAwait(false);
            var values = this.converterForPageResponse.Convert(response);
            if (values == null)
            {
                return new CollectionPage<Recipe>(0);
            }

            PageContextPatchUtility.Patch(values, pageIndex);

            return values;
        }

        /// <inheritdoc />
        Task<ICollectionPage<Recipe>> IPaginator<Recipe>.FindPageAsync(int pageIndex, int pageSize)
        {
            IRecipeRepository self = this;
            return self.FindPageAsync(pageIndex, pageSize, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<ICollectionPage<Recipe>> IPaginator<Recipe>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            IRecipeRepository self = this;
            var request = new RecipePageRequest
            {
                Page = pageIndex,
                PageSize = pageSize,
                Culture = self.Culture
            };
            var response = await this.serviceClient.SendAsync<ICollection<RecipeDataContract>>(request, cancellationToken).ConfigureAwait(false);
            var values = this.converterForPageResponse.Convert(response);
            if (values == null)
            {
                return new CollectionPage<Recipe>(0);
            }

            PageContextPatchUtility.Patch(values, pageIndex);

            return values;
        }
    }
}