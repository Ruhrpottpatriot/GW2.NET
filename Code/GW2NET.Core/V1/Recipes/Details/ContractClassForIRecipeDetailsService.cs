// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractClassForIRecipeDetailsService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ContractClassForIRecipeDetailsService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Recipes
{
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Entities.Recipes;

    [ContractClassFor(typeof(IRecipeDetailsService))]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", 
        Justification = "Only used by the Code Contracts for .NET extension.")]
    internal abstract class ContractClassForIRecipeDetailsService : IRecipeDetailsService
    {
        public Recipe GetRecipeDetails(int recipe)
        {
            throw new System.NotImplementedException();
        }

        public Recipe GetRecipeDetails(int recipe, CultureInfo language)
        {
            Contract.Requires(language != null);
            throw new System.NotImplementedException();
        }

        public Task<Recipe> GetRecipeDetailsAsync(int recipe)
        {
            Contract.Ensures(Contract.Result<Task<Recipe>>() != null);
            throw new System.NotImplementedException();
        }

        public Task<Recipe> GetRecipeDetailsAsync(int recipe, CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<Recipe>>() != null);
            throw new System.NotImplementedException();
        }

        public Task<Recipe> GetRecipeDetailsAsync(int recipe, CultureInfo language)
        {
            Contract.Requires(language != null);
            Contract.Ensures(Contract.Result<Task<Recipe>>() != null);
            throw new System.NotImplementedException();
        }

        public Task<Recipe> GetRecipeDetailsAsync(int recipe, CultureInfo language, CancellationToken cancellationToken)
        {
            Contract.Requires(language != null);
            Contract.Ensures(Contract.Result<Task<Recipe>>() != null);
            throw new System.NotImplementedException();
        }
    }
}