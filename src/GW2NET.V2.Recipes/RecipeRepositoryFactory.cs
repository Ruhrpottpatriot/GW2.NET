// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeRepositoryFactory.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides methods for creating repository objects.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Recipes
{
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Globalization;

    using GW2NET.Common;
    using GW2NET.Recipes;
    using GW2NET.V2.Worlds;

    /// <summary>Provides methods for creating repository objects.</summary>
    public sealed class RecipeRepositoryFactory : RepositoryFactoryBase<IRecipeRepository>
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="RecipeRepositoryFactory"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public RecipeRepositoryFactory(IServiceClient serviceClient)
        {
            Contract.Requires(serviceClient != null);
            this.serviceClient = serviceClient;
        }

        /// <summary>Creates an instance for the default language.</summary>
        /// <returns>A repository.</returns>
        public override IRecipeRepository ForDefaultCulture()
        {
            Contract.Ensures(Contract.Result<IRecipeRepository>() != null);
            return new RecipeRepository(this.serviceClient);
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public override IRecipeRepository ForCulture(CultureInfo culture)
        {
            Contract.Ensures(Contract.Result<IRecipeRepository>() != null);
            IRecipeRepository repository = new RecipeRepository(this.serviceClient);
            repository.Culture = culture;
            return repository;
        }
        
        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        [SuppressMessage("ReSharper", "UnusedMember.Local", Justification = "Only used when COdeCOntracts are enabled.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.serviceClient != null);
        }
    }
}