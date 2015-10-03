// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkinRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the SkinRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Skins
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
    using GW2NET.Common.Converters;
    using GW2NET.Skins;
    using GW2NET.V2.Skins.Json;

    /// <summary>Represents a repository that retrieves data from the /v2/items interface. See the remarks section for important limitations regarding this implementation.</summary>
    /// <remarks>
    /// This implementation does not retrieve associated entities.
    /// </remarks>
    public sealed class SkinRepository : ISkinRepository
    {
        private readonly IConverter<IResponse<ICollection<SkinDTO>>, IDictionaryRange<int, Skin>> bulkResponseConverter;

        private readonly IConverter<IResponse<ICollection<int>>, ICollection<int>> identifiersResponseConverter;

        private readonly IConverter<IResponse<ICollection<SkinDTO>>, ICollectionPage<Skin>> pageResponseConverter;

        private readonly IConverter<IResponse<SkinDTO>, Skin> responseConverter;

        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="SkinRepository"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <param name="identifiersResponseConverter"></param>
        /// <param name="responseConverter"></param>
        /// <param name="bulkResponseConverter"></param>
        /// <param name="pageResponseConverter"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public SkinRepository(
            IServiceClient serviceClient,
            IConverter<IResponse<ICollection<int>>, ICollection<int>> identifiersResponseConverter,
            IConverter<IResponse<SkinDTO>, Skin> responseConverter, 
            IConverter<IResponse<ICollection<SkinDTO>>, IDictionaryRange<int, Skin>> bulkResponseConverter,
            IConverter<IResponse<ICollection<SkinDTO>>, ICollectionPage<Skin>> pageResponseConverter)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient");
            }

            if (identifiersResponseConverter == null)
            {
                throw new ArgumentNullException("responseConverter");
                throw new ArgumentNullException(nameof(identifiersResponseConverter));
            }

            if (responseConverter == null)
            {
                throw new ArgumentNullException("responseConverter");
                throw new ArgumentNullException(nameof(responseConverter));
            }

            if (bulkResponseConverter == null)
            {
                throw new ArgumentNullException("bulkResponseConverter");
                throw new ArgumentNullException(nameof(bulkResponseConverter));
            }

            if (pageResponseConverter == null)
            {
                throw new ArgumentNullException("pageResponseConverter");
                throw new ArgumentNullException(nameof(pageResponseConverter));
            }

            this.serviceClient = serviceClient;
            this.identifiersResponseConverter = identifiersResponseConverter;
            this.responseConverter = responseConverter;
            this.bulkResponseConverter = bulkResponseConverter;
            this.pageResponseConverter = pageResponseConverter;
        }

        /// <inheritdoc />
        CultureInfo ILocalizable.Culture { get; set; }

        /// <inheritdoc />
        ICollection<int> IDiscoverable<int>.Discover()
        {
            var request = new SkinDiscoveryRequest();
            var response = this.serviceClient.Send<ICollection<int>>(request);
            return this.identifiersResponseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync()
        {
            return ((ISkinRepository)this).DiscoverAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync(CancellationToken cancellationToken)
        {
            var request = new SkinDiscoveryRequest();
            var response = await this.serviceClient.SendAsync<ICollection<int>>(request, cancellationToken).ConfigureAwait(false);
            return this.identifiersResponseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        Skin IRepository<int, Skin>.Find(int identifier)
        {
            var request = new SkinDetailsRequest
            {
                Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo),
                Culture = ((ILocalizable)this).Culture
            };
            var response = this.serviceClient.Send<SkinDTO>(request);
            return this.responseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        Task<Skin> IRepository<int, Skin>.FindAsync(int identifier)
        {
            return ((ISkinRepository)this).FindAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<Skin> IRepository<int, Skin>.FindAsync(int identifier, CancellationToken cancellationToken)
        {
            var request = new SkinDetailsRequest
            {
                Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo),
                Culture = ((ILocalizable)this).Culture
            };
            var response = await this.serviceClient.SendAsync<SkinDTO>(request, cancellationToken).ConfigureAwait(false);
            return this.responseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        IDictionaryRange<int, Skin> IRepository<int, Skin>.FindAll()
        {
            var request = new SkinBulkRequest
            {
                Culture = ((ISkinRepository)this).Culture
            };
            var response = this.serviceClient.Send<ICollection<SkinDTO>>(request);
            return this.bulkResponseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        IDictionaryRange<int, Skin> IRepository<int, Skin>.FindAll(ICollection<int> identifiers)
        {
            var request = new SkinBulkRequest
            {
                Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList(),
                Culture = ((ISkinRepository)this).Culture
            };
            var response = this.serviceClient.Send<ICollection<SkinDTO>>(request);
            return this.bulkResponseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Skin>> IRepository<int, Skin>.FindAllAsync()
        {
            return ((ISkinRepository)this).FindAllAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<IDictionaryRange<int, Skin>> IRepository<int, Skin>.FindAllAsync(CancellationToken cancellationToken)
        {
            var request = new SkinBulkRequest
            {
                Culture = ((ISkinRepository)this).Culture
            };
            var response = await this.serviceClient.SendAsync<ICollection<SkinDTO>>(request, cancellationToken).ConfigureAwait(false);
            return this.bulkResponseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Skin>> IRepository<int, Skin>.FindAllAsync(ICollection<int> identifiers)
        {
            return ((ISkinRepository)this).FindAllAsync(identifiers, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<IDictionaryRange<int, Skin>> IRepository<int, Skin>.FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            var request = new SkinBulkRequest
            {
                Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList(),
                Culture = ((ISkinRepository)this).Culture
            };
            var response = await this.serviceClient.SendAsync<ICollection<SkinDTO>>(request, cancellationToken).ConfigureAwait(false);
            return this.bulkResponseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        ICollectionPage<Skin> IPaginator<Skin>.FindPage(int pageIndex)
        {
            var request = new SkinPageRequest
            {
                Page = pageIndex,
                Culture = ((ISkinRepository)this).Culture
            };
            var response = this.serviceClient.Send<ICollection<SkinDTO>>(request);
            return this.pageResponseConverter.Convert(response, pageIndex);
        }

        /// <inheritdoc />
        ICollectionPage<Skin> IPaginator<Skin>.FindPage(int pageIndex, int pageSize)
        {
            var request = new SkinPageRequest
            {
                Page = pageIndex,
                PageSize = pageSize,
                Culture = ((ISkinRepository)this).Culture
            };
            var response = this.serviceClient.Send<ICollection<SkinDTO>>(request);
            return this.pageResponseConverter.Convert(response, pageIndex);
        }

        /// <inheritdoc />
        Task<ICollectionPage<Skin>> IPaginator<Skin>.FindPageAsync(int pageIndex)
        {
            return ((ISkinRepository)this).FindPageAsync(pageIndex, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<ICollectionPage<Skin>> IPaginator<Skin>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            var request = new SkinPageRequest
            {
                Page = pageIndex,
                Culture = ((ISkinRepository)this).Culture
            };
            var response = await this.serviceClient.SendAsync<ICollection<SkinDTO>>(request, cancellationToken).ConfigureAwait(false);
            return this.pageResponseConverter.Convert(response, pageIndex);
        }

        /// <inheritdoc />
        Task<ICollectionPage<Skin>> IPaginator<Skin>.FindPageAsync(int pageIndex, int pageSize)
        {
            return ((ISkinRepository)this).FindPageAsync(pageIndex, pageSize, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<ICollectionPage<Skin>> IPaginator<Skin>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            var request = new SkinPageRequest
            {
                Page = pageIndex,
                PageSize = pageSize,
                Culture = ((ISkinRepository)this).Culture
            };
            var response = await this.serviceClient.SendAsync<ICollection<SkinDTO>>(request, cancellationToken).ConfigureAwait(false);
            return this.pageResponseConverter.Convert(response, pageIndex);
        }
    }
}