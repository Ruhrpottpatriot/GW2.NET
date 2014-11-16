// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FloorRepositoryFactory.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides methods for creating repository objects.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Floors
{
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Globalization;

    using GW2NET.Common;
    using GW2NET.Maps;

    /// <summary>Provides methods for creating repository objects.</summary>
    public sealed class FloorRepositoryFactory
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="FloorRepositoryFactory"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public FloorRepositoryFactory(IServiceClient serviceClient)
        {
            Contract.Requires(serviceClient != null);
            this.serviceClient = serviceClient;
        }

        /// <summary>Creates an instance for the default language.</summary>
        /// <param name="continentId">The continent identifier.</param>
        /// <returns>A repository.</returns>
        public IFloorRepository this[int continentId]
        {
            get
            {
                Contract.Ensures(Contract.Result<IFloorRepository>() != null);
                return this.English(continentId);
            }
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="continentId">The continent identifier.</param>
        /// <param name="language">The two-letter language code.</param>
        /// <returns>A repository.</returns>
        public IFloorRepository this[int continentId, string language]
        {
            get
            {
                Contract.Requires(language != null);
                Contract.Requires(language.Length == 2);
                Contract.Ensures(Contract.Result<IFloorRepository>() != null);
                return this.ForCulture(continentId, new CultureInfo(language));
            }
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="continentId">The continent identifier.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public IFloorRepository this[int continentId, CultureInfo culture]
        {
            get
            {
                Contract.Requires(culture != null);
                Contract.Ensures(Contract.Result<IFloorRepository>() != null);
                return this.ForCulture(continentId, culture);
            }
        }

        /// <summary>Creates an instance for the default language.</summary>
        /// <param name="continentId">The continent identifier.</param>
        /// <returns>A repository.</returns>
        public IFloorRepository English(int continentId)
        {
            Contract.Ensures(Contract.Result<IFloorRepository>() != null);
            return new FloorRepository(this.serviceClient, continentId);
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="continentId">The continent identifier.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public IFloorRepository ForCulture(int continentId, CultureInfo culture)
        {
            Contract.Ensures(Contract.Result<IFloorRepository>() != null);
            IFloorRepository repository = new FloorRepository(this.serviceClient, continentId);
            repository.Culture = culture;
            return repository;
        }

        /// <summary>Creates an instance for the current system language.</summary>
        /// <param name="continentId">The continent identifier.</param>
        /// <returns>A repository.</returns>
        public IFloorRepository ForCurrentCulture(int continentId)
        {
            Contract.Ensures(Contract.Result<IFloorRepository>() != null);
            return this.ForCulture(continentId, CultureInfo.CurrentCulture);
        }

        /// <summary>Creates an instance for the current UI language.</summary>
        /// <param name="continentId">The continent identifier.</param>
        /// <returns>A repository.</returns>
        public IFloorRepository ForCurrentUICulture(int continentId)
        {
            Contract.Ensures(Contract.Result<IFloorRepository>() != null);
            return this.ForCulture(continentId, CultureInfo.CurrentUICulture);
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.serviceClient != null);
        }
    }
}