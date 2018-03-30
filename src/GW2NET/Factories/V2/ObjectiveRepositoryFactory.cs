// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectiveRepositoryFactory.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides methods for creating repository objects.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Factories.V2
{
    using System;
    using System.Globalization;

    using GW2NET.Common;
    using GW2NET.V2.WorldVersusWorld.Objectives;
    using GW2NET.V2.WorldVersusWorld.Objectives.Converters;
    using GW2NET.WorldVersusWorld;

    /// <summary>Provides methods for creating repository objects.</summary>
    public sealed class ObjectiveRepositoryFactory
    {
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="ObjectiveRepositoryFactory"/> class.</summary>
        /// <param name="serviceClient"></param>
        public ObjectiveRepositoryFactory(IServiceClient serviceClient)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException(nameof(serviceClient));
            }

            this.serviceClient = serviceClient;
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="language">The two-letter language code.</param>
        /// <returns>A repository.</returns>
        public IObjectiveRepository this[string language]
        {
            get
            {
                if (language == null)
                {
                    throw new ArgumentNullException(nameof(language));
                }

                return this.ForCulture(new CultureInfo(language));
            }
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public IObjectiveRepository this[CultureInfo culture]
        {
            get
            {
                if (culture == null)
                {
                    throw new ArgumentNullException(nameof(culture));
                }

                return this.ForCulture(culture);
            }
        }

        /// <summary>Creates an instance for the default language.</summary>
        /// <returns>A repository.</returns>
        public IObjectiveRepository ForDefaultCulture()
        {
            return new ObjectiveRepository(this.serviceClient, new ObjectiveConverter());
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public IObjectiveRepository ForCulture(CultureInfo culture)
        {
            if (culture == null)
            {
                throw new ArgumentNullException(nameof(culture));
            }

            IObjectiveRepository repository = new ObjectiveRepository(this.serviceClient, new ObjectiveConverter());
            repository.Culture = culture;
            return repository;
        }

        /// <summary>Creates an instance for the current system language.</summary>
        /// <returns>A repository.</returns>
        public IObjectiveRepository ForCurrentCulture()
        {
            return this.ForCulture(CultureInfo.CurrentCulture);
        }

        /// <summary>Creates an instance for the current UI language.</summary>
        /// <returns>A repository.</returns>
        public IObjectiveRepository ForCurrentUICulture()
        {
            return this.ForCulture(CultureInfo.CurrentUICulture);
        }
    }
}