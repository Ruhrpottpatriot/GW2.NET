// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharacterRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v2/characters interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Accounts.Characters
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using GW2NET.Characters;
    using GW2NET.Common;
    using GW2NET.Common.Converters;

    /// <summary>Represents a repository that retrieves data from the /v2/characters interface.</summary>
    public sealed class CharacterRepository : ICharacterRepository
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<string>>, ICollection<string>> identifiersResponseConverter;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<CharacterDataContract>, Character> responseConverter;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<CharacterDataContract>>, IDictionaryRange<string, Character>> bulkResponseConverter;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<CharacterDataContract>>, ICollectionPage<Character>> pageResponseConverter;

        /// <summary> Initializes a new instance of the <see cref="CharacterRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public CharacterRepository(IServiceClient serviceClient)
            : this(serviceClient, new ConverterAdapter<ICollection<string>>(), new CharacterConverter())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="CharacterRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="identifierConverter">The identifier converter.</param>
        /// <param name="characterConverter">The character converter.</param>
        /// <exception cref="ArgumentNullException">Thrown when either of the arguments passed is null.</exception>
        private CharacterRepository(IServiceClient serviceClient, IConverter<ICollection<string>, ICollection<string>> identifierConverter, IConverter<CharacterDataContract, Character> characterConverter)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient", "Precondition: serviceClient != null");
            }

            if (identifierConverter == null)
            {
                throw new ArgumentNullException("identifierConverter", "Precondition: identifierConverter != null");
            }

            if (characterConverter == null)
            {
                throw new ArgumentNullException("characterConverter", "Precondition: characterConverter != null");
            }

            this.serviceClient = serviceClient;
            this.identifiersResponseConverter = new ConverterForResponse<ICollection<string>, ICollection<string>>(identifierConverter);
            this.responseConverter = new ConverterForResponse<CharacterDataContract, Character>(characterConverter);
            this.bulkResponseConverter = new ConverterForDictionaryRangeResponse<CharacterDataContract, string, Character>(characterConverter, c => c.Name);
            this.pageResponseConverter = new ConverterForCollectionPageResponse<CharacterDataContract, Character>(characterConverter);
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
            return this.identifiersResponseConverter.Convert(response, null) ?? new List<string>(0);
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
        Task<ICollection<string>> IDiscoverable<string>.DiscoverAsync(CancellationToken cancellationToken)
        {
            var request = new CharacterDiscoveryRequest();
            var response = this.serviceClient.SendAsync<ICollection<string>>(request, cancellationToken);
            return response.ContinueWith<ICollection<string>>(this.ConvertAsyncResponse, cancellationToken);
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

            var response = this.serviceClient.Send<ICollection<CharacterDataContract>>(reuqest);
            return this.pageResponseConverter.Convert(response, pageIndex) ?? new CollectionPage<Character>(0);
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

            var response = this.serviceClient.Send<ICollection<CharacterDataContract>>(reuqest);
            return this.pageResponseConverter.Convert(response, pageIndex) ?? new CollectionPage<Character>(0);
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
            var reuqest = new CharacterPageRequest
            {
                Page = pageIndex,
                Culture = ((ICharacterRepository)this).Culture
            };

            var response = this.serviceClient.SendAsync<ICollection<CharacterDataContract>>(reuqest, cancellationToken);
            return response.ContinueWith(task => this.ConvertAsyncResponse(task, pageIndex), cancellationToken);
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
        Task<ICollectionPage<Character>> IPaginator<Character>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            var reuqest = new CharacterPageRequest
            {
                Page = pageIndex,
                PageSize = pageSize,
                Culture = ((ICharacterRepository)this).Culture
            };

            var response = this.serviceClient.SendAsync<ICollection<CharacterDataContract>>(reuqest, cancellationToken);
            return response.ContinueWith(task => this.ConvertAsyncResponse(task, pageIndex), cancellationToken);
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
            var response = this.serviceClient.Send<CharacterDataContract>(request);
            return this.responseConverter.Convert(response, null);
        }

        /// <summary>Finds every object.</summary>
        /// <exception cref="NotSupportedException">The data source does not support searching for all objects.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <returns>A collection of objects.</returns>
        IDictionaryRange<string, Character> IRepository<string, Character>.FindAll()
        {
            var request = new CharacterBulkRequest { Culture = ((ICharacterRepository)this).Culture };
            var response = this.serviceClient.Send<ICollection<CharacterDataContract>>(request);
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
            var response = this.serviceClient.Send<ICollection<CharacterDataContract>>(request);
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
        Task<IDictionaryRange<string, Character>> IRepository<string, Character>.FindAllAsync(CancellationToken cancellationToken)
        {
            var request = new CharacterBulkRequest { Culture = ((ICharacterRepository)this).Culture };
            var response = this.serviceClient.SendAsync<ICollection<CharacterDataContract>>(request, cancellationToken);
            return response.ContinueWith<IDictionaryRange<string, Character>>(this.ConvertAsyncResponse, cancellationToken);
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
        Task<IDictionaryRange<string, Character>> IRepository<string, Character>.FindAllAsync(ICollection<string> identifiers, CancellationToken cancellationToken)
        {
            var request = new CharacterBulkRequest
                          {
                              Identifiers = identifiers,
                              Culture = ((ICharacterRepository)this).Culture
                          };
            var response = this.serviceClient.SendAsync<ICollection<CharacterDataContract>>(request, cancellationToken);
            return response.ContinueWith<IDictionaryRange<string, Character>>(this.ConvertAsyncResponse, cancellationToken);
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
        Task<Character> IRepository<string, Character>.FindAsync(string identifier, CancellationToken cancellationToken)
        {
            var request = new CharacterDetailsRequest
                          {
                              Identifier = identifier,
                              Culture = ((ICharacterRepository)this).Culture
                          };
            var response = this.serviceClient.SendAsync<CharacterDataContract>(request, cancellationToken);
            return response.ContinueWith<Character>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <summary>Converts the result of an asynchronous query into the appropriate return type.</summary>
        /// <param name="task">The task to convert.</param>
        /// <returns>An <see cref="ICollection{T}"/> of <see cref="string"/>.</returns>
        private ICollection<string> ConvertAsyncResponse(Task<IResponse<ICollection<string>>> task)
        {
            Debug.Assert(task != null, "task != null");
            return this.identifiersResponseConverter.Convert(task.Result, null) ?? new List<string>(0);
        }

        /// <summary>Converts the result of an asynchronous query into the appropriate return type.</summary>
        /// <param name="task">The task to convert.</param>
        /// <param name="pageIndex">The page index.</param>
        /// <returns>An <see cref="ICollectionPage{T}"/> of type <see cref="Character"/>.</returns>
        private ICollectionPage<Character> ConvertAsyncResponse(Task<IResponse<ICollection<CharacterDataContract>>> task, int pageIndex)
        {
            Debug.Assert(task != null, "task != null");
            return this.pageResponseConverter.Convert(task.Result, pageIndex) ?? new CollectionPage<Character>(0);
        }

        /// <summary>Converts the result of an asynchronous query into the appropriate return type.</summary>
        /// <param name="task">The task to convert.</param>
        /// <returns>A <see cref="IDictionaryRange{TKey, TValue}"/> with <see cref="string"/> as key and <see cref="Character"/> as value.</returns>
        private IDictionaryRange<string, Character> ConvertAsyncResponse(Task<IResponse<ICollection<CharacterDataContract>>> task)
        {
            Debug.Assert(task != null, "task != null");
            return this.bulkResponseConverter.Convert(task.Result, null) ?? new DictionaryRange<string, Character>(0);
        }

        /// <summary>Converts the result of an asynchronous query into the appropriate return type.</summary>
        /// <param name="task">The task to convert.</param>
        /// <returns>A <see cref="Character"/>.</returns>
        private Character ConvertAsyncResponse(Task<IResponse<CharacterDataContract>> task)
        {
            Debug.Assert(task != null, "task != null");
            return this.responseConverter.Convert(task.Result, null);
        }
    }
}
