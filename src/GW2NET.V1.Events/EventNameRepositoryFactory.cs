// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventNameRepositoryFactory.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides methods for creating repository objects.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Globalization;
using GW2NET.Common;
using GW2NET.DynamicEvents;

namespace GW2NET.V1.Events
{
    using System;

    /// <summary>Provides methods for creating repository objects.</summary>
    public sealed class EventNameRepositoryFactory
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="EventNameRepositoryFactory"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> is a null reference.</exception>
        public EventNameRepositoryFactory(IServiceClient serviceClient)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient", "Precondition: serviceClient != null");
            }

            this.serviceClient = serviceClient;
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="language">The two-letter language code.</param>
        /// <returns>A repository.</returns>
        /// <exception cref="ArgumentNullException">The value of <paramref name="language"/> is a null reference.</exception>
        public IEventNameRepository this[string language]
        {
            get
            {
                if (language == null)
                {
                    throw new ArgumentNullException("language", "Precondition: language != null");
                }

                return this.ForCulture(new CultureInfo(language));
            }
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        /// <exception cref="ArgumentNullException">The value of <paramref name="culture"/> is a null reference.</exception>
        public IEventNameRepository this[CultureInfo culture]
        {
            get
            {
                if (culture == null)
                {
                    throw new ArgumentNullException("culture", "Precondition: culture != null");
                }

                return this.ForCulture(culture);
            }
        }

        /// <summary>Creates an instance for the default language.</summary>
        /// <returns>A repository.</returns>
        public IEventNameRepository ForDefaultCulture()
        {
            return new EventNameRepository(this.serviceClient);
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public IEventNameRepository ForCulture(CultureInfo culture)
        {
            IEventNameRepository repository = new EventNameRepository(this.serviceClient);
            repository.Culture = culture;
            return repository;
        }

        /// <summary>Creates an instance for the current system language.</summary>
        /// <returns>A repository.</returns>
        public IEventNameRepository ForCurrentCulture()
        {
            return this.ForCulture(CultureInfo.CurrentCulture);
        }

        /// <summary>Creates an instance for the current UI language.</summary>
        /// <returns>A repository.</returns>
        public IEventNameRepository ForCurrentUICulture()
        {
            return this.ForCulture(CultureInfo.CurrentUICulture);
        }
    }
}
