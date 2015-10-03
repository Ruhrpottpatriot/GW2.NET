// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharacterRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v2/characters interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Accounts.Characters
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using GW2NET.Characters;
    using GW2NET.Common;
    using GW2NET.V2.Accounts.Characters.Json;

    /// <summary>Represents a repository that retrieves data from the /v2/characters interface.</summary>
    public sealed class CharacterRepository : ICharacterRepository
    {
        private readonly IServiceClient serviceClient;

        private readonly IConverter<IResponse<ICollection<string>>, ICollection<string>> identifiersResponseConverter;

        private readonly IConverter<IResponse<CharacterDTO>, Character> responseConverter;

        private readonly IConverter<IResponse<ICollection<CharacterDTO>>, IDictionaryRange<string, Character>> bulkResponseConverter;

        private readonly IConverter<IResponse<ICollection<CharacterDTO>>, ICollectionPage<Character>> pageResponseConverter;

        /// <summary>Initializes a new instance of the <see cref="CharacterRepository"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <param name="identifiersResponseConverter"></param>
        /// <param name="responseConverter"></param>
        /// <param name="bulkResponseConverter"></param>
        /// <param name="pageResponseConverter"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public CharacterRepository(
            IServiceClient serviceClient,
            IConverter<IResponse<ICollection<string>>, ICollection<string>> identifiersResponseConverter,
            IConverter<IResponse<CharacterDTO>, Character> responseConverter,
            IConverter<IResponse<ICollection<CharacterDTO>>, IDictionaryRange<string, Character>> bulkResponseConverter,
            IConverter<IResponse<ICollection<CharacterDTO>>, ICollectionPage<Character>> pageResponseConverter)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient");
            }

            if (identifiersResponseConverter == null)
            {
                throw new ArgumentNullException("identifiersResponseConverter");
            }

            if (responseConverter == null)
            {
                throw new ArgumentNullException("responseConverter");
            }

            if (bulkResponseConverter == null)
            {
                throw new ArgumentNullException("bulkResponseConverter");
            }

            if (pageResponseConverter == null)
            {
                throw new ArgumentNullException("pageResponseConverter");
            }

            this.serviceClient = serviceClient;
            this.identifiersResponseConverter = identifiersResponseConverter;
            this.responseConverter = responseConverter;
            this.bulkResponseConverter = bulkResponseConverter;
            this.pageResponseConverter = pageResponseConverter;
        }

        /// <summary>Gets or sets the locale.</summary>
        CultureInfo ILocalizable.Culture { get; set; }

        /// <summary>Discovers identifiers of objects in the data source.</summary>
        /// <exception cref="NotSupportedException">The data source does not support the discovery of object identifiers.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <returns>A collection of object identifiers.</returns>
        ICollection<string> IDiscoverable<string>.Discover()
        {
            var request = new CharacterDiscoveryRequest();
            var response = this.serviceClient.Send<ICollection<string>>(request);
            return this.identifiersResponseConverter.Convert(response, null);
        }

        /// <summary>Discovers identifiers of objects in the data source.</summary>
        /// <exception cref="NotSupportedException">The data source does not support the discovery of object identifiers.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <returns>A collection of object identifiers.</returns>
        Task<ICollection<string>> IDiscoverable<string>.DiscoverAsync()
        {
            return ((IDiscoverable<string>)this).DiscoverAsync(CancellationToken.None);
        }

        /// <summary>Discovers identifiers of objects in the data source.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <exception cref="NotSupportedException">The data source does not support the discovery of object identifiers.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <exception cref="TaskCanceledException">A task was canceled.</exception>
        /// <returns>A collection of object identifiers.</returns>
        async Task<ICollection<string>> IDiscoverable<string>.DiscoverAsync(CancellationToken cancellationToken)
        {
            var request = new CharacterDiscoveryRequest();
            var response = await this.serviceClient.SendAsync<ICollection<string>>(request, cancellationToken).ConfigureAwait(false);
            return this.identifiersResponseConverter.Convert(response, null);
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <exception cref="NotSupportedException">The data source does not support pagination.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="pageIndex"/> is less than 0.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <returns>The page.</returns>
        ICollectionPage<Character> IPaginator<Character>.FindPage(int pageIndex)
        {
            var reuqest = new CharacterPageRequest
            {
                Page = pageIndex,
                Culture = ((ICharacterRepository)this).Culture
            };

            var response = this.serviceClient.Send<ICollection<CharacterDTO>>(reuqest);
            return this.pageResponseConverter.Convert(response, pageIndex);
        }

        /// <summary>Finds the page with the specified page number and maximum size.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <exception cref="NotSupportedException">The data source does not support pagination.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="pageIndex"/> is less than 0 or <paramref name="pageSize"/> is less than 0.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <returns>The page.</returns>
        ICollectionPage<Character> IPaginator<Character>.FindPage(int pageIndex, int pageSize)
        {
            var reuqest = new CharacterPageRequest
            {
                Page = pageIndex,
                PageSize = pageSize,
                Culture = ((ICharacterRepository)this).Culture
            };

            var response = this.serviceClient.Send<ICollection<CharacterDTO>>(reuqest);
            return this.pageResponseConverter.Convert(response, pageIndex);
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <exception cref="NotSupportedException">The data source does not support pagination.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="pageIndex"/> is less than 0.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <returns>The page.</returns>
        Task<ICollectionPage<Character>> IPaginator<Character>.FindPageAsync(int pageIndex)
        {
            return ((IPaginator<Character>)this).FindPageAsync(pageIndex, CancellationToken.None);
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <exception cref="NotSupportedException">The data source does not support pagination.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="pageIndex"/> is less than 0.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <exception cref="TaskCanceledException">A task was canceled.</exception>
        /// <returns>The page.</returns>
        async Task<ICollectionPage<Character>> IPaginator<Character>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            var reuqest = new CharacterPageRequest
            {
                Page = pageIndex,
                Culture = ((ICharacterRepository)this).Culture
            };

            var response = await this.serviceClient.SendAsync<ICollection<CharacterDTO>>(reuqest, cancellationToken).ConfigureAwait(false);
            return this.pageResponseConverter.Convert(response, pageIndex);
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <exception cref="NotSupportedException">The data source does not support pagination.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="pageIndex"/> is less than 0 or <paramref name="pageSize"/> is less than 0.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <returns>The page.</returns>
        Task<ICollectionPage<Character>> IPaginator<Character>.FindPageAsync(int pageIndex, int pageSize)
        {
            return ((IPaginator<Character>)this).FindPageAsync(pageIndex, pageSize, CancellationToken.None);
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <exception cref="NotSupportedException">The data source does not support pagination.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="pageIndex"/> is less than 0 or <paramref name="pageSize"/> is less than 0.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <exception cref="TaskCanceledException">A task was canceled.</exception>
        /// <returns>The page.</returns>
        async Task<ICollectionPage<Character>> IPaginator<Character>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            var reuqest = new CharacterPageRequest
            {
                Page = pageIndex,
                PageSize = pageSize,
                Culture = ((ICharacterRepository)this).Culture
            };

            var response = await this.serviceClient.SendAsync<ICollection<CharacterDTO>>(reuqest, cancellationToken).ConfigureAwait(false);
            return this.pageResponseConverter.Convert(response, pageIndex);
        }

        /// <summary>Finds the object with the given identifier.</summary>
        /// <param name="identifier">The identifier of the object to find.</param>
        /// <exception cref="NotSupportedException">The data source does not support searching by identifier.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <returns>The object with the given identifier, or a null reference.</returns>
        Character IRepository<string, Character>.Find(string identifier)
        {
            var request = new CharacterDetailsRequest
            {
                Identifier = identifier,
                Culture = ((ICharacterRepository)this).Culture
            };
            var response = this.serviceClient.Send<CharacterDTO>(request);
            return this.responseConverter.Convert(response, null);
        }

        /// <summary>Finds every object.</summary>
        /// <exception cref="NotSupportedException">The data source does not support searching for all objects.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <returns>A collection of objects.</returns>
        IDictionaryRange<string, Character> IRepository<string, Character>.FindAll()
        {
            var request = new CharacterBulkRequest { Culture = ((ICharacterRepository)this).Culture };
            var response = this.serviceClient.Send<ICollection<CharacterDTO>>(request);
            return this.bulkResponseConverter.Convert(response, null);
        }

        /// <summary>Finds every object with one of the given identifiers.</summary>
        /// <param name="identifiers">The identifiers of the objects to find.</param>
        /// <exception cref="NotSupportedException">The data source does not support searching for a range of objects.</exception>
        /// <exception cref="ArgumentNullException">The value of <paramref name="identifiers"/> is a null reference.</exception>
        /// <exception cref="ArgumentException">The value of <paramref name="identifiers"/> is an empty collection.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <returns>A collection of objects with one of the given identifiers.</returns>
        IDictionaryRange<string, Character> IRepository<string, Character>.FindAll(ICollection<string> identifiers)
        {
            var request = new CharacterBulkRequest
            {
                Identifiers = identifiers,
                Culture = ((ICharacterRepository)this).Culture
            };
            var response = this.serviceClient.Send<ICollection<CharacterDTO>>(request);
            return this.bulkResponseConverter.Convert(response, null);
        }

        /// <summary>Finds every object.</summary>
        /// <exception cref="NotSupportedException">The data source does not support searching for all objects.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <returns>A collection of objects.</returns>
        Task<IDictionaryRange<string, Character>> IRepository<string, Character>.FindAllAsync()
        {
            return ((ICharacterRepository)this).FindAllAsync(CancellationToken.None);
        }

        /// <summary>Finds every object.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <exception cref="NotSupportedException">The data source does not support searching for all objects.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <exception cref="TaskCanceledException">A task was canceled.</exception>
        /// <returns>A collection of objects.</returns>
        async Task<IDictionaryRange<string, Character>> IRepository<string, Character>.FindAllAsync(CancellationToken cancellationToken)
        {
            var request = new CharacterBulkRequest { Culture = ((ICharacterRepository)this).Culture };
            var response = await this.serviceClient.SendAsync<ICollection<CharacterDTO>>(request, cancellationToken).ConfigureAwait(false);
            return this.bulkResponseConverter.Convert(response, null);
        }

        /// <summary>Finds every object with one of the given identifiers.</summary>
        /// <param name="identifiers">The identifiers of the objects to find.</param>
        /// <exception cref="NotSupportedException">The data source does not support searching for a range of objects.</exception>
        /// <exception cref="ArgumentNullException">The value of <paramref name="identifiers"/> is a null reference.</exception>
        /// <exception cref="ArgumentException">The value of <paramref name="identifiers"/> is an empty collection.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <returns>A collection of objects with one of the given identifiers.</returns>
        Task<IDictionaryRange<string, Character>> IRepository<string, Character>.FindAllAsync(ICollection<string> identifiers)
        {
            return ((ICharacterRepository)this).FindAllAsync(identifiers, CancellationToken.None);
        }

        /// <summary>Finds every object with one of the given identifiers.</summary>
        /// <param name="identifiers">The identifiers of the objects to find.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <exception cref="NotSupportedException">The data source does not support searching for a range of objects.</exception>
        /// <exception cref="ArgumentNullException">The value of <paramref name="identifiers"/> is a null reference.</exception>
        /// <exception cref="ArgumentException">The value of <paramref name="identifiers"/> is an empty collection.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <exception cref="TaskCanceledException">A task was canceled.</exception>
        /// <returns>A collection of objects with one of the given identifiers.</returns>
        async Task<IDictionaryRange<string, Character>> IRepository<string, Character>.FindAllAsync(ICollection<string> identifiers, CancellationToken cancellationToken)
        {
            var request = new CharacterBulkRequest
            {
                Identifiers = identifiers,
                Culture = ((ICharacterRepository)this).Culture
            };
            var response = await this.serviceClient.SendAsync<ICollection<CharacterDTO>>(request, cancellationToken).ConfigureAwait(false);
            return this.bulkResponseConverter.Convert(response, null);
        }

        /// <summary>Finds the object with the given identifier.</summary>
        /// <param name="identifier">The identifier of the object to find.</param>
        /// <exception cref="NotSupportedException">The data source does not support searching by identifier.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <returns>The object with the given identifier, or a null reference.</returns>
        Task<Character> IRepository<string, Character>.FindAsync(string identifier)
        {
            return ((ICharacterRepository)this).FindAsync(identifier, CancellationToken.None);
        }

        /// <summary>Finds the object with the given identifier.</summary>
        /// <param name="identifier">The identifier of the object to find.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <exception cref="NotSupportedException">The data source does not support searching by identifier.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <exception cref="TaskCanceledException">A task was canceled.</exception>
        /// <returns>The object with the given identifier, or a null reference.</returns>
        async Task<Character> IRepository<string, Character>.FindAsync(string identifier, CancellationToken cancellationToken)
        {
            var request = new CharacterDetailsRequest
            {
                Identifier = identifier,
                Culture = ((ICharacterRepository)this).Culture
            };
            var response = await this.serviceClient.SendAsync<CharacterDTO>(request, cancellationToken).ConfigureAwait(false);
            return this.responseConverter.Convert(response, null);
        }
    }
}
