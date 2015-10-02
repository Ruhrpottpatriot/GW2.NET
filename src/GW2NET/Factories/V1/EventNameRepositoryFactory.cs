// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventNameRepositoryFactory.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides methods for creating repository objects.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Factories.V1
{
    using System;
    using System.Globalization;

    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.DynamicEvents;
    using GW2NET.V1.Events;
    using GW2NET.V1.Events.Converters;
    using GW2NET.V1.Events.Json;

    /// <summary>Provides methods for creating repository objects.</summary>
    public sealed class EventNameRepositoryFactory
    {
        
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="EventNameRepositoryFactory"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> is a null reference.</exception>
        public EventNameRepositoryFactory(IServiceClient serviceClient)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient");
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
                    throw new ArgumentNullException("language");
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
                    throw new ArgumentNullException("culture");
                }

                return this.ForCulture(culture);
            }
        }

        /// <summary>Creates an instance for the default language.</summary>
        /// <returns>A repository.</returns>
        public IEventNameRepository ForDefaultCulture()
        {
            return new EventNameRepository(this.serviceClient, new CollectionConverter<EventNameDTO, DynamicEventName>(new DynamicEventNameConverter()));
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public IEventNameRepository ForCulture(CultureInfo culture)
        {
            IEventNameRepository repository = new EventNameRepository(this.serviceClient, new CollectionConverter<EventNameDTO, DynamicEventName>(new DynamicEventNameConverter()));
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