// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContinentRepositoryFactory.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides methods for creating repository objects.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Continents
{
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Globalization;

    using GW2NET.Common;
    using GW2NET.Maps;

    /// <summary>Provides methods for creating repository objects.</summary>
    public sealed class ContinentRepositoryFactory
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="ContinentRepositoryFactory"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public ContinentRepositoryFactory(IServiceClient serviceClient)
        {
            Contract.Requires(serviceClient != null);
            this.serviceClient = serviceClient;
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="language">The two-letter language code.</param>
        /// <returns>A repository.</returns>
        public IContinentRepository this[string language]
        {
            get
            {
                Contract.Requires(language != null);
                Contract.Requires(language.Length == 2);
                Contract.Ensures(Contract.Result<IContinentRepository>() != null);
                return this.ForCulture(new CultureInfo(language));
            }
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public IContinentRepository this[CultureInfo culture]
        {
            get
            {
                Contract.Requires(culture != null);
                Contract.Ensures(Contract.Result<IContinentRepository>() != null);
                return this.ForCulture(culture);
            }
        }

        /// <summary>Creates an instance for the default language.</summary>
        /// <returns>A repository.</returns>
        public IContinentRepository English()
        {
            Contract.Ensures(Contract.Result<IContinentRepository>() != null);
            return new ContinentRepository(this.serviceClient);
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public IContinentRepository ForCulture(CultureInfo culture)
        {
            Contract.Ensures(Contract.Result<IContinentRepository>() != null);
            IContinentRepository repository = new ContinentRepository(this.serviceClient);
            repository.Culture = culture;
            return repository;
        }

        /// <summary>Creates an instance for the current system language.</summary>
        /// <returns>A repository.</returns>
        public IContinentRepository ForCurrentCulture()
        {
            Contract.Ensures(Contract.Result<IContinentRepository>() != null);
            return this.ForCulture(CultureInfo.CurrentCulture);
        }

        /// <summary>Creates an instance for the current UI language.</summary>
        /// <param name="continentId">The continent identifier.</param>
        /// <returns>A repository.</returns>
        public IContinentRepository ForCurrentUICulture(int continentId)
        {
            Contract.Ensures(Contract.Result<IContinentRepository>() != null);
            return this.ForCulture(CultureInfo.CurrentUICulture);
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.serviceClient != null);
        }
    }
}