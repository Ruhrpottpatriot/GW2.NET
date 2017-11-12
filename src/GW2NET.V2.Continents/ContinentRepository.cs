// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContinentRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
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
    using GW2NET.Common.Converters;
    using GW2NET.Maps;

    /// <summary>Represents a repository that retrieves data from the /v2/continents interface.</summary>
    public sealed class ContinentRepository : IContinentRepository
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<int>>, ICollection<int>> identifiersConverter;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<ContinentDataContract>>, ICollectionPage<Continent>> pageResponseConverter;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ContinentDataContract>, Continent> responseConverter;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<ContinentDataContract>>, IDictionaryRange<int, Continent>> bulkResponseConverter;

        /// <summary>Initializes a new instance of the <see cref="ContinentRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> is a null reference.</exception>
        public ContinentRepository(IServiceClient serviceClient)
            : this(serviceClient, new ConverterAdapter<ICollection<int>>(), new ContinentConverter())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ContinentRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="identifiersConverter">The identifiers converter.</param>
        /// <param name="continentConverter">The continent converter.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> or <paramref name="identifiersConverter"/> or <paramref name="continentConverter"/> is a null reference.</exception>
        internal ContinentRepository(IServiceClient serviceClient, IConverter<ICollection<int>, ICollection<int>> identifiersConverter, IConverter<ContinentDataContract, Continent> continentConverter)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient", "Precondition: serviceClient != null");
            }

            if (identifiersConverter == null)
            {
                throw new ArgumentNullException("identifiersConverter", "Precondition: identifiersConverter != null");
            }

            if (continentConverter == null)
            {
                throw new ArgumentNullException("continentConverter", "Precondition: continentConverter != null");
            }

            this.serviceClient = serviceClient;

            this.identifiersConverter = new ConverterForResponse<ICollection<int>, ICollection<int>>(identifiersConverter);
            this.responseConverter = new ConverterForResponse<ContinentDataContract, Continent>(continentConverter);
            this.pageResponseConverter = new ConverterForCollectionPageResponse<ContinentDataContract, Continent>(continentConverter);
            this.bulkResponseConverter = new ConverterForDictionaryRangeResponse<ContinentDataContract, int, Continent>(continentConverter, cont => cont.ContinentId);
        }

        /// <summary>Gets or sets the locale.</summary>
        CultureInfo ILocalizable.Culture { get; set; }

        /// <inheritdoc />
        ICollection<int> IDiscoverable<int>.Discover()
        {
            var request = new ContinentDiscoveryRequest();
            var response = this.serviceClient.Send<ICollection<int>>(request);
            return this.identifiersConverter.Convert(response) ?? new List<int>(0);
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync()
        {
            return ((IContinentRepository)this).DiscoverAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync(CancellationToken cancellationToken)
        {
            var request = new ContinentDiscoveryRequest();
            var response = await this.serviceClient.SendAsync<ICollection<int>>(request, cancellationToken).ConfigureAwait(false);
            var ids = this.identifiersConverter.Convert(response);
            if (ids == null)
            {
                return new List<int>(0);
            }

            return ids;
        }

        /// <inheritdoc />
        ICollectionPage<Continent> IPaginator<Continent>.FindPage(int pageIndex)
        {
            var request = new ContinentPageRequest
            {
                Page = pageIndex,
                Culture = ((ILocalizable)this).Culture
            };
            var response = this.serviceClient.Send<ICollection<ContinentDataContract>>(request);

            var values = this.pageResponseConverter.Convert(response);

            if (values == null)
            {
                return new CollectionPage<Continent>(0);
            }

            PageContextPatchUtility.Patch(values, pageIndex);
            return values;
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
            var response = this.serviceClient.Send<ICollection<ContinentDataContract>>(request);
            var values = this.pageResponseConverter.Convert(response);

            if (values == null)
            {
                return new CollectionPage<Continent>(0);
            }

            PageContextPatchUtility.Patch(values, pageIndex);

            return values;
        }

        /// <inheritdoc />
        Task<ICollectionPage<Continent>> IPaginator<Continent>.FindPageAsync(int pageIndex)
        {
            return ((IContinentRepository)this).FindPageAsync(pageIndex, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<ICollectionPage<Continent>> IPaginator<Continent>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            var request = new ContinentPageRequest
            {
                Page = pageIndex,
                Culture = ((ILocalizable)this).Culture
            };
            var response = await this.serviceClient.SendAsync<ICollection<ContinentDataContract>>(request, cancellationToken).ConfigureAwait(false);
            var values = this.pageResponseConverter.Convert(response);
            if (values == null)
            {
                return new CollectionPage<Continent>(0);
            }

            PageContextPatchUtility.Patch(values, pageIndex);

            return values;
        }

        /// <inheritdoc />
        Task<ICollectionPage<Continent>> IPaginator<Continent>.FindPageAsync(int pageIndex, int pageSize)
        {
            return ((IContinentRepository)this).FindPageAsync(pageIndex, pageSize, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<ICollectionPage<Continent>> IPaginator<Continent>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            var request = new ContinentPageRequest
            {
                Page = pageIndex,
                PageSize = pageSize,
                Culture = ((ILocalizable)this).Culture
            };
            var response = await this.serviceClient.SendAsync<ICollection<ContinentDataContract>>(request, cancellationToken).ConfigureAwait(false);
            var values = this.pageResponseConverter.Convert(response);
            if (values == null)
            {
                return new CollectionPage<Continent>(0);
            }

            PageContextPatchUtility.Patch(values, pageIndex);

            return values;
        }

        /// <inheritdoc />
        Continent IRepository<int, Continent>.Find(int identifier)
        {
            var request = new ContinentDetailsRequest
            {
                Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo),
                Culture = ((ILocalizable)this).Culture
            };
            var response = this.serviceClient.Send<ContinentDataContract>(request);
            return this.responseConverter.Convert(response);
        }

        /// <inheritdoc />
        IDictionaryRange<int, Continent> IRepository<int, Continent>.FindAll()
        {
            var request = new ContinentBulkRequest { Culture = ((ILocalizable)this).Culture };
            var response = this.serviceClient.Send<ICollection<ContinentDataContract>>(request);
            return this.bulkResponseConverter.Convert(response);
        }

        /// <inheritdoc />
        IDictionaryRange<int, Continent> IRepository<int, Continent>.FindAll(ICollection<int> identifiers)
        {
            var request = new ContinentBulkRequest
            {
                Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList(),
                Culture = ((ILocalizable)this).Culture
            };
            var response = this.serviceClient.Send<ICollection<ContinentDataContract>>(request);
            return this.bulkResponseConverter.Convert(response);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Continent>> IRepository<int, Continent>.FindAllAsync()
        {
            return ((IContinentRepository)this).FindAllAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<IDictionaryRange<int, Continent>> IRepository<int, Continent>.FindAllAsync(CancellationToken cancellationToken)
        {
            var request = new ContinentBulkRequest
            {
                Culture = ((ILocalizable)this).Culture
            };
            var response = await this.serviceClient.SendAsync<ICollection<ContinentDataContract>>(request, cancellationToken).ConfigureAwait(false);
            var values = this.bulkResponseConverter.Convert(response);
            if (values == null)
            {
                return new DictionaryRange<int, Continent>(0);
            }

            return values;
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Continent>> IRepository<int, Continent>.FindAllAsync(ICollection<int> identifiers)
        {
            return ((IContinentRepository)this).FindAllAsync(identifiers, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<IDictionaryRange<int, Continent>> IRepository<int, Continent>.FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            var request = new ContinentBulkRequest
            {
                Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList(),
                Culture = ((ILocalizable)this).Culture
            };
            var response = await this.serviceClient.SendAsync<ICollection<ContinentDataContract>>(request, cancellationToken).ConfigureAwait(false);
            var values = this.bulkResponseConverter.Convert(response);
            if (values == null)
            {
                return new DictionaryRange<int, Continent>(0);
            }

            return values;
        }

        /// <inheritdoc />
        Task<Continent> IRepository<int, Continent>.FindAsync(int identifier)
        {
            return ((IContinentRepository)this).FindAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<Continent> IRepository<int, Continent>.FindAsync(int identifier, CancellationToken cancellationToken)
        {
            var request = new ContinentDetailsRequest
            {
                Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo),
                Culture = ((ILocalizable)this).Culture
            };
            var response = await this.serviceClient.SendAsync<ContinentDataContract>(request, cancellationToken).ConfigureAwait(false);
            return this.responseConverter.Convert(response);
        }
    }
}
