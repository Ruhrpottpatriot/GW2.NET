// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharacterRepositoryFactory.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides methods and properties for creating a character repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Factories.Services
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Characters;
    using Common;
    using Common.Converters;
    using GW2NET.V2.Accounts.Characters;
    using GW2NET.V2.Accounts.Characters.Converter;
    using GW2NET.V2.Accounts.Characters.Json;

    /// <summary>Provides methods and properties for creating a character repository.</summary>
    public sealed class CharacterRepositoryFactory : RepositoryFactoryBase<ICharacterRepository>
    {
        private readonly IServiceClient serviceClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterRepositoryFactory"/> class.
        /// </summary>
        /// <param name="serviceClient">
        /// The service client.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the reference to the service client is null.
        /// </exception>
        public CharacterRepositoryFactory(IServiceClient serviceClient)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient");
            }

            this.serviceClient = serviceClient;
        }

        /// <summary>Creates an instance for the default language.</summary>
        /// <returns>A repository.</returns>
        public override ICharacterRepository ForDefaultCulture()
        {
            var genderConverter = new GenderConverter();
            var professionConverter = new ProfesionConverter();
            var raceConverter = new RaceConverter();
            var characterConverter = new CharacterConverter(genderConverter, professionConverter, raceConverter);
            var identifiersResponseConverter = new ResponseConverter<ICollection<string>, ICollection<string>>(new ConverterAdapter<ICollection<string>>());
            var responseConverter = new ResponseConverter<CharacterDTO, Character>(characterConverter);
            var bulkResponseConverter = new DictionaryRangeResponseConverter<CharacterDTO, string, Character>(characterConverter, c => c.Name);
            var pageResponseConverter = new CollectionPageResponseConverter<CharacterDTO, Character>(characterConverter);
            return new CharacterRepository(this.serviceClient, identifiersResponseConverter, responseConverter, bulkResponseConverter, pageResponseConverter);
        }

        /// <summary>
        /// Creates an instance for the given language.
        /// </summary>
        /// <param name="culture">
        /// The culture.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// The value of <paramref name="culture"/> is a null reference.
        /// </exception>
        /// <returns>
        /// A repository.
        /// </returns>
        public override ICharacterRepository ForCulture(CultureInfo culture)
        {
            ICharacterRepository repository = this.ForDefaultCulture();
            repository.Culture = culture;
            return repository;
        }
    }
}
