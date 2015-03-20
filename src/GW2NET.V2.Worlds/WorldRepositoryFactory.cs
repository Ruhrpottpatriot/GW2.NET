// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorldRepositoryFactory.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides methods for creating repository objects.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Worlds
{
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.IO;

    using GW2NET.Common;
    using GW2NET.Worlds;

    /// <summary>Provides methods for creating repository objects.</summary>
    public sealed class WorldRepositoryFactory : RepositoryFactoryBase<IWorldRepository>
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="WorldRepositoryFactory"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public WorldRepositoryFactory(IServiceClient serviceClient)
        {
            Contract.Requires(serviceClient != null);
            this.serviceClient = serviceClient;
        }

        /// <summary>Creates an instance for the default language.</summary>
        /// <returns>A repository.</returns>
        public override IWorldRepository ForDefaultCulture()
        {
            Contract.Ensures(Contract.Result<IWorldRepository>() != null);
            return new WorldRepository(this.serviceClient);
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public override IWorldRepository ForCulture(CultureInfo culture)
        {
            Contract.Ensures(Contract.Result<IWorldRepository>() != null);
            IWorldRepository repository = new WorldRepository(this.serviceClient);
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