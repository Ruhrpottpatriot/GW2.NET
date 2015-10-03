// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContinentRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v1/continents.json interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Continents
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Maps;
    using GW2NET.V1.Continents.Json;

    /// <summary>Represents a repository that retrieves data from the /v1/continents.json interface.</summary>
    public class ContinentRepository : IContinentRepository
    {
        private readonly IConverter<ContinentCollectionDTO, ICollection<Continent>> continentCollectionConverter;

        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="ContinentRepository"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <param name="continentCollectionConverter"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ContinentRepository(IServiceClient serviceClient, IConverter<ContinentCollectionDTO, ICollection<Continent>> continentCollectionConverter)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient");
            }

            if (continentCollectionConverter == null)
            {
                throw new ArgumentNullException("continentCollectionConverter");
            }

            this.serviceClient = serviceClient;
            this.continentCollectionConverter = continentCollectionConverter;
        }

        /// <inheritdoc />
        CultureInfo ILocalizable.Culture { get; set; }

        /// <inheritdoc />
        ICollection<int> IDiscoverable<int>.Discover()
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync()
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync(CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Continent IRepository<int, Continent>.Find(int identifier)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        IDictionaryRange<int, Continent> IRepository<int, Continent>.FindAll()
        {
            IContinentRepository self = this;
            var request = new ContinentRequest
            {
                Culture = self.Culture
            };
            var response = this.serviceClient.Send<ContinentCollectionDTO>(request);
            if (response.Content == null || response.Content.Continents == null)
            {
                return new DictionaryRange<int, Continent>(0);
            }

            var values = this.continentCollectionConverter.Convert(response.Content, null);
            var continents = new DictionaryRange<int, Continent>(values.Count)
            {
                SubtotalCount = values.Count,
                TotalCount = values.Count
            };

            foreach (var continent in values)
            {
                continent.Culture = request.Culture;
                continents.Add(continent.ContinentId, continent);
            }

            return continents;
        }

        /// <inheritdoc />
        IDictionaryRange<int, Continent> IRepository<int, Continent>.FindAll(ICollection<int> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Continent>> IRepository<int, Continent>.FindAllAsync()
        {
            return ((IContinentRepository)this).FindAllAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<IDictionaryRange<int, Continent>> IRepository<int, Continent>.FindAllAsync(CancellationToken cancellationToken)
        {
            IContinentRepository self = this;
            var request = new ContinentRequest
            {
                Culture = self.Culture
            };
            var response = await this.serviceClient.SendAsync<ContinentCollectionDTO>(request, cancellationToken).ConfigureAwait(false);
            if (response.Content == null || response.Content.Continents == null)
            {
                return new DictionaryRange<int, Continent>(0);
            }

            var values = this.continentCollectionConverter.Convert(response.Content, null);
            var continents = new DictionaryRange<int, Continent>(values.Count)
            {
                SubtotalCount = values.Count,
                TotalCount = values.Count
            };

            foreach (var continent in values)
            {
                continent.Culture = request.Culture;
                continents.Add(continent.ContinentId, continent);
            }

            return continents;
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Continent>> IRepository<int, Continent>.FindAllAsync(ICollection<int> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Continent>> IRepository<int, Continent>.FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<Continent> IRepository<int, Continent>.FindAsync(int identifier)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<Continent> IRepository<int, Continent>.FindAsync(int identifier, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        ICollectionPage<Continent> IPaginator<Continent>.FindPage(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        ICollectionPage<Continent> IPaginator<Continent>.FindPage(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<Continent>> IPaginator<Continent>.FindPageAsync(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<Continent>> IPaginator<Continent>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<Continent>> IPaginator<Continent>.FindPageAsync(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<Continent>> IPaginator<Continent>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }
    }
}