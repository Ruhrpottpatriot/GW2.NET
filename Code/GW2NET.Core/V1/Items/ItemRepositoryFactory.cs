﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemRepositoryFactory.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides methods for creating repository objects.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Items
{
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Globalization;

    using GW2NET.Common;
    using GW2NET.Entities.Items;

    /// <summary>Provides methods for creating repository objects.</summary>
    public sealed class ItemRepositoryFactory
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="ItemRepositoryFactory"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public ItemRepositoryFactory(IServiceClient serviceClient)
        {
            Contract.Requires(serviceClient != null);
            this.serviceClient = serviceClient;
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="language">The two-letter language code.</param>
        /// <returns>A repository.</returns>
        public IRepository<int, Item> this[string language]
        {
            get
            {
                Contract.Requires(language != null);
                Contract.Requires(language.Length == 2);
                Contract.Ensures(Contract.Result<IRepository<int, Item>>() != null);
                return this.ForCulture(new CultureInfo(language));
            }
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public IRepository<int, Item> this[CultureInfo culture]
        {
            get
            {
                Contract.Requires(culture != null);
                Contract.Ensures(Contract.Result<IRepository<int, Item>>() != null);
                return this.ForCulture(culture);
            }
        }

        /// <summary>Creates an instance for the default language.</summary>
        /// <returns>A repository.</returns>
        public IRepository<int, Item> English()
        {
            Contract.Ensures(Contract.Result<IRepository<int, Item>>() != null);
            return new ItemRepository(this.serviceClient);
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public IRepository<int, Item> ForCulture(CultureInfo culture)
        {
            Contract.Ensures(Contract.Result<IRepository<int, Item>>() != null);
            return new ItemRepository(this.serviceClient)
            {
                Culture = culture
            };
        }

        /// <summary>Creates an instance for the current system language.</summary>
        /// <returns>A repository.</returns>
        public IRepository<int, Item> ForCurrentCulture()
        {
            Contract.Ensures(Contract.Result<IRepository<int, Item>>() != null);
            return this.ForCulture(CultureInfo.CurrentCulture);
        }

        /// <summary>Creates an instance for the current UI language.</summary>
        /// <param name="continentId">The continent identifier.</param>
        /// <returns>A repository.</returns>
        public IRepository<int, Item> ForCurrentUICulture(int continentId)
        {
            Contract.Ensures(Contract.Result<IRepository<int, Item>>() != null);
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