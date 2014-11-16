// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRecipeRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for repositories that provide localized recipe details.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Entities.Recipes
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;

    /// <summary>Provides the interface for repositories that provide localized recipe details.</summary>
    public interface IRecipeRepository : IRepository<int, Recipe>, ILocalizable
    {
        /// <summary>Discovers identifiers of every <see cref="Recipe"/> whose <see cref="Recipe.Ingredients"/> collection contains the given <paramref name="identifier"/>.</summary>
        /// <param name="identifier">The identifier of the input item.</param>
        /// <exception cref="NotSupportedException">The data source does not support searching by input identifiers.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <returns>A collection of identifiers for every <see cref="Recipe"/> whose <see cref="Recipe.Ingredients"/> collection contains the given <paramref name="identifier"/>.</returns>
        ICollection<int> DiscoverByInput(int identifier);

        /// <summary>Discovers identifiers of every <see cref="Recipe"/> whose <see cref="Recipe.Ingredients"/> collection contains the given <paramref name="identifier"/>.</summary>
        /// <param name="identifier">The identifier of the input item.</param>
        /// <exception cref="NotSupportedException">The data source does not support searching by input identifiers.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <returns>A collection of identifiers for every <see cref="Recipe"/> whose <see cref="Recipe.Ingredients"/> collection contains the given <paramref name="identifier"/>.</returns>
        Task<ICollection<int>> DiscoverByInputAsync(int identifier);

        /// <summary>Discovers identifiers of every <see cref="Recipe"/> whose <see cref="Recipe.Ingredients"/> collection contains the given <paramref name="identifier"/>.</summary>
        /// <param name="identifier">The identifier of the input item.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <exception cref="NotSupportedException">The data source does not support searching by input identifiers.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <exception cref="TaskCanceledException">A task was canceled.</exception>
        /// <returns>A collection of identifiers for every <see cref="Recipe"/> whose <see cref="Recipe.Ingredients"/> collection contains the given <paramref name="identifier"/>.</returns>
        Task<ICollection<int>> DiscoverByInputAsync(int identifier, CancellationToken cancellationToken);

        /// <summary>Discovers identifiers of every <see cref="Recipe"/> whose <see cref="Recipe.OutputItemId"/> is set to the given <paramref name="identifier"/>.</summary>
        /// <param name="identifier">The identifier of the output item.</param>
        /// <exception cref="NotSupportedException">The data source does not support searching by output identifiers.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <returns>A collection of identifiers for every <see cref="Recipe"/> whose <see cref="Recipe.OutputItemId"/> is set to the given <paramref name="identifier"/>.</returns>
        ICollection<int> DiscoverByOutput(int identifier);

        /// <summary>Discovers identifiers of every <see cref="Recipe"/> whose <see cref="Recipe.OutputItemId"/> is set to the given <paramref name="identifier"/>.</summary>
        /// <param name="identifier">The identifier of the output item.</param>
        /// <exception cref="NotSupportedException">The data source does not support searching by output identifiers.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <returns>A collection of identifiers for every <see cref="Recipe"/> whose <see cref="Recipe.OutputItemId"/> is set to the given <paramref name="identifier"/>.</returns>
        Task<ICollection<int>> DiscoverByOutputAsync(int identifier);

        /// <summary>Discovers identifiers of every <see cref="Recipe"/> whose <see cref="Recipe.OutputItemId"/> is set to the given <paramref name="identifier"/>.</summary>
        /// <param name="identifier">The identifier of the output item.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <exception cref="NotSupportedException">The data source does not support searching by output identifiers.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <exception cref="TaskCanceledException">A task was canceled.</exception>
        /// <returns>A collection of identifiers for every <see cref="Recipe"/> whose <see cref="Recipe.OutputItemId"/> is set to the given <paramref name="identifier"/>.</returns>
        Task<ICollection<int>> DiscoverByOutputAsync(int identifier, CancellationToken cancellationToken);
    }
}