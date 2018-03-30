// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorldRepositoryFactory.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides methods for creating repository objects.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Factories.Services
{
    using System;
    using System.Globalization;
    using Common;
    using Common.Converters;
    using GW2NET.V2.Worlds;
    using GW2NET.V2.Worlds.Converters;
    using GW2NET.V2.Worlds.Json;
    using Worlds;

    /// <summary>Provides methods for creating repository objects.</summary>
    public sealed class WorldRepositoryFactory : RepositoryFactoryBase<IWorldRepository>
    {
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="WorldRepositoryFactory"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> is a null reference.</exception>
        public WorldRepositoryFactory(IServiceClient serviceClient)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException(nameof(serviceClient));
            }

            this.serviceClient = serviceClient;
        }

        /// <summary>Creates an instance for the default language.</summary>
        /// <returns>A repository.</returns>
        public override IWorldRepository ForDefaultCulture()
        {
            var worldConverter = new WorldConverter();
            var identifiersResponseConverter = new CollectionResponseConverter<int, int>(new ConverterAdapter<int>());
            var responseConverter = new ResponseConverter<WorldDTO, World>(worldConverter);
            var bulkResponseConverter = new DictionaryRangeResponseConverter<WorldDTO, int, World>(worldConverter, value => value.WorldId);
            var pageResponseConverter = new CollectionPageResponseConverter<WorldDTO, World>(worldConverter);
            return new WorldRepository(this.serviceClient, identifiersResponseConverter, responseConverter, bulkResponseConverter, pageResponseConverter);
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public override IWorldRepository ForCulture(CultureInfo culture)
        {
            var worldConverter = new WorldConverter();
            var identifiersResponseConverter = new CollectionResponseConverter<int, int>(new ConverterAdapter<int>());
            var responseConverter = new ResponseConverter<WorldDTO, World>(worldConverter);
            var bulkResponseConverter = new DictionaryRangeResponseConverter<WorldDTO, int, World>(worldConverter, value => value.WorldId);
            var pageResponseConverter = new CollectionPageResponseConverter<WorldDTO, World>(worldConverter);
            IWorldRepository repository = new WorldRepository(this.serviceClient, identifiersResponseConverter, responseConverter, bulkResponseConverter, pageResponseConverter);
            repository.Culture = culture;
            return repository;
        }
    }
}