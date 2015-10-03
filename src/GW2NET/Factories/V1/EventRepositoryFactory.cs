// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventRepositoryFactory.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
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
    using GW2NET.DynamicEvents;
    using GW2NET.V1.Events;
    using GW2NET.V1.Events.Converters;

    /// <summary>Provides methods for creating repository objects.</summary>
    public sealed class EventRepositoryFactory
    {
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="EventRepositoryFactory"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> is a null reference.</exception>
        public EventRepositoryFactory(IServiceClient serviceClient)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient");
            }

            this.serviceClient = serviceClient;
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="language">The two-letter language code.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="language"/> is a null reference.</exception>
        /// <returns>A repository.</returns>
        public IEventRepository this[string language]
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
        /// <exception cref="ArgumentNullException">The value of <paramref name="culture"/> is a null reference.</exception>
        /// <returns>A repository.</returns>
        public IEventRepository this[CultureInfo culture]
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
        public IEventRepository ForDefaultCulture()
        {
            var vector2DConverter = new Vector2DConverter();
            var vector3DConverter = new Vector3DConverter();
            var dynamicEventFlagConverter = new DynamicEventFlagConverter();
            var dynamicEventFlagCollectionConverter = new DynamicEventFlagCollectionConverter(dynamicEventFlagConverter);
            var locationConverterFactory = new LocationConverterFactory(vector2DConverter);
            var locationConverter = new LocationConverter(locationConverterFactory, vector3DConverter);
            var dynamicEventConverter = new DynamicEventConverter(dynamicEventFlagCollectionConverter, locationConverter);
            var dynamicEventCollectionConverter = new DynamicEventCollectionConverter(dynamicEventConverter);
            return new EventRepository(this.serviceClient, dynamicEventCollectionConverter);
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public IEventRepository ForCulture(CultureInfo culture)
        {
            var vector2DConverter = new Vector2DConverter();
            var vector3DConverter = new Vector3DConverter();
            var dynamicEventFlagConverter = new DynamicEventFlagConverter();
            var dynamicEventFlagCollectionConverter = new DynamicEventFlagCollectionConverter(dynamicEventFlagConverter);
            var locationConverterFactory = new LocationConverterFactory(vector2DConverter);
            var locationConverter = new LocationConverter(locationConverterFactory, vector3DConverter);
            var dynamicEventConverter = new DynamicEventConverter(dynamicEventFlagCollectionConverter, locationConverter);
            var dynamicEventCollectionConverter = new DynamicEventCollectionConverter(dynamicEventConverter);
            IEventRepository repository = new EventRepository(this.serviceClient, dynamicEventCollectionConverter);
            repository.Culture = culture;
            return repository;
        }

        /// <summary>Creates an instance for the current system language.</summary>
        /// <returns>A repository.</returns>
        public IEventRepository ForCurrentCulture()
        {
            return this.ForCulture(CultureInfo.CurrentCulture);
        }

        /// <summary>Creates an instance for the current UI language.</summary>
        /// <returns>A repository.</returns>
        public IEventRepository ForCurrentUICulture()
        {
            return this.ForCulture(CultureInfo.CurrentUICulture);
        }
    }
}