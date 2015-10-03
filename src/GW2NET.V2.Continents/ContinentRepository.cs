// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContinentRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ContinentRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Continents
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Maps;
    using GW2NET.V2.Continents.Json;

    /// <summary>Represents a repository that retrieves data from the /v2/continents interface.</summary>
    public sealed class ContinentRepository : IContinentRepository
    {
        private readonly IServiceClient serviceClient;

        private readonly IConverter<IResponse<ICollection<int>>, ICollection<int>> identifiersConverter;

        private readonly IConverter<IResponse<ICollection<ContinentDTO>>, ICollectionPage<Continent>> pageResponseConverter;

        private readonly IConverter<IResponse<ContinentDTO>, Continent> responseConverter;

        private readonly IConverter<IResponse<ICollection<ContinentDTO>>, IDictionaryRange<int, Continent>> bulkResponseConverter;

        /// <summary>Initializes a new instance of the <see cref="ContinentRepository"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <param name="identifiersConverter"></param>
        /// <param name="responseConverter"></param>
        /// <param name="bulkResponseConverter"></param>
        /// <param name="pageResponseConverter"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ContinentRepository(IServiceClient serviceClient, IConverter<IResponse<ICollection<int>>, ICollection<int>> identifiersConverter, IConverter<IResponse<ContinentDTO>, Continent> responseConverter, IConverter<IResponse<ICollection<ContinentDTO>>, IDictionaryRange<int, Continent>> bulkResponseConverter, IConverter<IResponse<ICollection<ContinentDTO>>, ICollectionPage<Continent>> pageResponseConverter)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient");
            }

            if (identifiersConverter == null)
            {
                throw new ArgumentNullException("identifiersConverter");
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
            this.identifiersConverter = identifiersConverter;
            this.responseConverter = responseConverter;
            this.pageResponseConverter = pageResponseConverter;
            this.bulkResponseConverter = bulkResponseConverter;
        }

        /// <summary>Gets or sets the locale.</summary>
        CultureInfo ILocalizable.Culture { get; set; }

        /// <inheritdoc />
        ICollection<int> IDiscoverable<int>.Discover()
        {
            var request = new ContinentDiscoveryRequest();
            var response = this.serviceClient.Send<ICollection<int>>(request);
            return this.identifiersConverter.Convert(response, null) ?? new List<int>(0);
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync()
        {
            return ((IContinentRepository)this).DiscoverAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync(CancellationToken cancellationToken)
        {
            var request = new ContinentDiscoveryRequest();
            var response = this.serviceClient.SendAsync<ICollection<int>>(request, cancellationToken);
            return response.ContinueWith<ICollection<int>>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        ICollectionPage<Continent> IPaginator<Continent>.FindPage(int pageIndex)
        {
            var request = new ContinentPageRequest
            {
                Page = pageIndex,
                Culture = ((ILocalizable)this).Culture
            };
            var response = this.serviceClient.Send<ICollection<ContinentDTO>>(request);
            var values = this.pageResponseConverter.Convert(response, pageIndex);
            return values ?? new CollectionPage<Continent>(0);
        }

        /// <inheritdoc />
        ICollectionPage<Continent> IPaginator<Continent>.FindPage(int pageIndex, int pageSize)
        {
            var request = new ContinentPageRequest
            {
                Page = pageIndex,
                PageSize = pageSize,
                Culture = ((ILocalizable)this).Culture
            };
            var response = this.serviceClient.Send<ICollection<ContinentDTO>>(request);
            var values = this.pageResponseConverter.Convert(response, pageIndex);
            return values ?? new CollectionPage<Continent>(0);
        }

        /// <inheritdoc />
        Task<ICollectionPage<Continent>> IPaginator<Continent>.FindPageAsync(int pageIndex)
        {
            return ((IContinentRepository)this).FindPageAsync(pageIndex, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollectionPage<Continent>> IPaginator<Continent>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            var request = new ContinentPageRequest
            {
                Page = pageIndex,
                Culture = ((ILocalizable)this).Culture
            };
            var response = this.serviceClient.SendAsync<ICollection<ContinentDTO>>(request, cancellationToken);
            return response.ContinueWith(task => this.ConvertAsyncResponse(task, pageIndex), cancellationToken);
        }

        /// <inheritdoc />
        Task<ICollectionPage<Continent>> IPaginator<Continent>.FindPageAsync(int pageIndex, int pageSize)
        {
            return ((IContinentRepository)this).FindPageAsync(pageIndex, pageSize, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollectionPage<Continent>> IPaginator<Continent>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            var request = new ContinentPageRequest
            {
                Page = pageIndex,
                PageSize = pageSize,
                Culture = ((ILocalizable)this).Culture
            };
            var response = this.serviceClient.SendAsync<ICollection<ContinentDTO>>(request, cancellationToken);
            return response.ContinueWith(task => this.ConvertAsyncResponse(task, pageIndex), cancellationToken);
        }

        /// <inheritdoc />
        Continent IRepository<int, Continent>.Find(int identifier)
        {
            var request = new ContinentDetailsRequest
            {
                Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo),
                Culture = ((ILocalizable)this).Culture
            };
            var response = this.serviceClient.Send<ContinentDTO>(request);
            return this.responseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        IDictionaryRange<int, Continent> IRepository<int, Continent>.FindAll()
        {
            var request = new ContinentBulkRequest { Culture = ((ILocalizable)this).Culture };
            var response = this.serviceClient.Send<ICollection<ContinentDTO>>(request);
            return this.bulkResponseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        IDictionaryRange<int, Continent> IRepository<int, Continent>.FindAll(ICollection<int> identifiers)
        {
            var request = new ContinentBulkRequest
            {
                Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList(),
                Culture = ((ILocalizable)this).Culture
            };
            var response = this.serviceClient.Send<ICollection<ContinentDTO>>(request);
            return this.bulkResponseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Continent>> IRepository<int, Continent>.FindAllAsync()
        {
            return ((IContinentRepository)this).FindAllAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Continent>> IRepository<int, Continent>.FindAllAsync(CancellationToken cancellationToken)
        {
            var request = new ContinentBulkRequest
            {
                Culture = ((ILocalizable)this).Culture
            };
            var responseTask = this.serviceClient.SendAsync<ICollection<ContinentDTO>>(request, cancellationToken);
            return responseTask.ContinueWith<IDictionaryRange<int, Continent>>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Continent>> IRepository<int, Continent>.FindAllAsync(ICollection<int> identifiers)
        {
            return ((IContinentRepository)this).FindAllAsync(identifiers, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Continent>> IRepository<int, Continent>.FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            var request = new ContinentBulkRequest
            {
                Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList(),
                Culture = ((ILocalizable)this).Culture
            };
            var responseTask = this.serviceClient.SendAsync<ICollection<ContinentDTO>>(request, cancellationToken);
            return responseTask.ContinueWith<IDictionaryRange<int, Continent>>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        Task<Continent> IRepository<int, Continent>.FindAsync(int identifier)
        {
            return ((IContinentRepository)this).FindAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<Continent> IRepository<int, Continent>.FindAsync(int identifier, CancellationToken cancellationToken)
        {
            var request = new ContinentDetailsRequest
            {
                Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo),
                Culture = ((ILocalizable)this).Culture
            };
            var responseTask = this.serviceClient.SendAsync<ContinentDTO>(request, cancellationToken);
            return responseTask.ContinueWith<Continent>(this.ConvertAsyncResponse, cancellationToken);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private IDictionaryRange<int, Continent> ConvertAsyncResponse(Task<IResponse<ICollection<ContinentDTO>>> task)
        {
            Debug.Assert(task != null, "task != null");
            var values = this.bulkResponseConverter.Convert(task.Result, null);
            if (values == null)
            {
                return new DictionaryRange<int, Continent>(0);
            }

            return values;
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private ICollectionPage<Continent> ConvertAsyncResponse(Task<IResponse<ICollection<ContinentDTO>>> task, int pageIndex)
        {
            Debug.Assert(task != null, "task != null");
            var values = this.pageResponseConverter.Convert(task.Result, pageIndex);
            return values ?? new CollectionPage<Continent>(0);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private ICollection<int> ConvertAsyncResponse(Task<IResponse<ICollection<int>>> task)
        {
            Debug.Assert(task != null, "task != null");
            var ids = this.identifiersConverter.Convert(task.Result, null);
            if (ids == null)
            {
                return new List<int>(0);
            }

            return ids;
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private Continent ConvertAsyncResponse(Task<IResponse<ContinentDTO>> task)
        {
            Debug.Assert(task != null, "task != null");
            return this.responseConverter.Convert(task.Result, null);
        }
    }
}