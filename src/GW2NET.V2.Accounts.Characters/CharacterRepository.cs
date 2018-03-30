// <copyright file="CharacterRepository.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

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
    using Handlers;

    /// <summary>Represents a repository that retrieves data from the /v2/characters interface.</summary>
    public sealed class CharacterRepository : ICharacterRepository
    {
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
            this.Client = serviceClient ?? throw new ArgumentNullException(nameof(serviceClient));
            this.IdentifiersResponseConverter = identifiersResponseConverter ?? throw new ArgumentNullException(nameof(identifiersResponseConverter));
            this.ResponseConverter = responseConverter ?? throw new ArgumentNullException(nameof(responseConverter));
            this.BulkResponseConverter = bulkResponseConverter ?? throw new ArgumentNullException(nameof(bulkResponseConverter));
            this.PageResponseConverter = pageResponseConverter ?? throw new ArgumentNullException(nameof(pageResponseConverter));
        }

        /// <summary>Gets or sets the locale.</summary>
        CultureInfo ILocalizable.Culture { get; set; }

        public string ApiKey { get; }

        public IServiceClient Client { get; }

        public IConverter<IResponse<ICollection<string>>, ICollection<string>> IdentifiersResponseConverter { get; }

        public IConverter<IResponse<CharacterDTO>, Character> ResponseConverter { get; }

        public IConverter<IResponse<ICollection<CharacterDTO>>, IDictionaryRange<string, Character>> BulkResponseConverter { get; }

        public IConverter<IResponse<ICollection<CharacterDTO>>, ICollectionPage<Character>> PageResponseConverter { get; }



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
            var request = ApiQuerySelector.Init(new CultureInfo("en"))
                .V2Authorized(this.ApiKey)
                .Characters()
                .Discover()
                .BuildSingle();

            var response = await this.Client.SendAsync<ICollection<string>>(request, cancellationToken).ConfigureAwait(false);
            return this.IdentifiersResponseConverter.Convert(response);
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
        Task<ICollectionPage<Character>> IPaginator<Character>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            return ((IPaginator<Character>)this).FindPageAsync(pageIndex, 20, cancellationToken);
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
            var request = ApiQuerySelector.Init(new CultureInfo("en"))
                .V2Authorized()
                .Characters()
                .GetDetails()
                .

            var reuqest = 
                
                new CharacterPageRequest
            {
                Page = pageIndex,
                PageSize = pageSize,
                Culture = ((ICharacterRepository)this).Culture
            };

            var response = await this.Client.SendAsync<ICollection<CharacterDTO>>(reuqest, cancellationToken).ConfigureAwait(false);
            return this.PageResponseConverter.Convert(response, pageIndex);
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
            var response = await this.Client.SendAsync<ICollection<CharacterDTO>>(request, cancellationToken).ConfigureAwait(false);
            return this.BulkResponseConverter.Convert(response);
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
            var response = await this.Client.SendAsync<ICollection<CharacterDTO>>(request, cancellationToken).ConfigureAwait(false);
            return this.BulkResponseConverter.Convert(response);
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
            var response = await this.Client.SendAsync<CharacterDTO>(request, cancellationToken).ConfigureAwait(false);
            return this.ResponseConverter.Convert(response);
        }
    }
}
