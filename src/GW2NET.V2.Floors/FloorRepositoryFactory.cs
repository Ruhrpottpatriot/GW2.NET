// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FloorRepositoryFactory.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides methods and properties to create a floor repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Floors
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;

    using GW2NET.Common;
    using GW2NET.Maps;

    /// <summary>Provides methods and properties to create a floor repository.</summary>
    public class FloorRepositoryFactory
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="FloorRepositoryFactory"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> is a null reference.</exception>
        public FloorRepositoryFactory(IServiceClient serviceClient)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient", "Precondition: serviceClient != null");
            }

            this.serviceClient = serviceClient;
        }

        /// <summary>Creates an instance for the default language.</summary>
        /// <param name="continentId">The continent identifier.</param>
        /// <returns>A repository.</returns>
        public IFloorRepository this[int continentId]
        {
            get
            {
                return this.ForDefaultCulture(continentId);
            }
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="language">The two-letter language code.</param>
        /// <param name="continentId">The continent identifier.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="language"/> is a null reference.</exception>
        /// <returns>A repository of type <see cref="IFloorRepository"/>.</returns>
        public IFloorRepository this[string language, int continentId]
        {
            get
            {
                if (language == null)
                {
                    throw new ArgumentNullException("language", "Precondition: language != null");
                }

                return this.ForCulture(new CultureInfo(language), continentId);
            }
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <param name="continentId">The continent identifier.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="culture"/> is a null reference.</exception>
        /// <returns>A repository of type <see cref="IFloorRepository"/>.</returns>
        public IFloorRepository this[CultureInfo culture, int continentId]
        {
            get
            {
                if (culture == null)
                {
                    throw new ArgumentNullException("culture", "Precondition: culture != null");
                }

                return this.ForCulture(culture, continentId);
            }
        }

        /// <summary>Creates an instance for the default language.</summary>
        /// <param name="continentId">The continent Id.</param>
        /// <returns>A repository of type <see cref="IFloorRepository"/>.</returns>
        public IFloorRepository ForDefaultCulture(int continentId)
        {
            return new FloorRepository(this.serviceClient, continentId);
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <param name="continentId">The continent identifier.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="culture"/> is a null reference.</exception>
        /// <returns>A repository of type <see cref="IFloorRepository"/>.</returns>
        public IFloorRepository ForCulture(CultureInfo culture, int continentId)
        {
            if (culture == null)
            {
                throw new ArgumentNullException("culture", "Precondition: culture != null");
            }

            IFloorRepository repository = new FloorRepository(this.serviceClient, continentId);
            repository.Culture = culture;
            return repository;
        }

        /// <summary>Creates an instance for the current system language.</summary>
        /// <param name="continentId">The continent identifier.</param>
        /// <returns>A repository of type <see cref="IFloorRepository"/>.</returns>
        public IFloorRepository ForCurrentCulture(int continentId)
        {
            return this.ForCulture(CultureInfo.CurrentCulture, continentId);
        }

        /// <summary>Creates an instance for the current UI language.</summary>
        /// <param name="continentId">The continent identifier.</param>
        /// <returns>A repository of type <see cref="IFloorRepository"/>.</returns>
        [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Consitent with the standard .NET naming.")]
        public IFloorRepository ForCurrentUICulture(int continentId)
        {
            return this.ForCulture(CultureInfo.CurrentUICulture, continentId);
        }
    }
}
