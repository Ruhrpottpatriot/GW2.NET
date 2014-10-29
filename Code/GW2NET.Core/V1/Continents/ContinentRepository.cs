// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContinentRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v1/continents.json interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Continents
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Entities.Maps;
    using GW2NET.V1.Continents.Json;
    using GW2NET.V1.Continents.Json.Converters;

    /// <summary>Represents a repository that retrieves data from the /v1/continents.json interface.</summary>
    public class ContinentRepository : IRepository<int, Continent>, ILocalizable
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ContinentCollectionDataContract, ICollection<Continent>> converterForContinentCollection;

        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="ContinentRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public ContinentRepository(IServiceClient serviceClient)
            : this(serviceClient, new ConverterForContinentCollection())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ContinentRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="converterForContinentCollection">The converter for <see cref="ICollection{Continent}"/>.</param>
        internal ContinentRepository(IServiceClient serviceClient, IConverter<ContinentCollectionDataContract, ICollection<Continent>> converterForContinentCollection)
        {
            this.serviceClient = serviceClient;
            this.converterForContinentCollection = converterForContinentCollection;
        }

        /// <summary>Gets or sets the locale.</summary>
        public CultureInfo Culture { get; set; }

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
            var request = new ContinentRequest { Culture = this.Culture };
            var response = this.serviceClient.Send<ContinentCollectionDataContract>(request);
            if (response.Content == null || response.Content.Continents == null)
            {
                return new DictionaryRange<int, Continent>(0);
            }

            var values = this.converterForContinentCollection.Convert(response.Content);
            var continents = new DictionaryRange<int, Continent>(values.Count) { SubtotalCount = values.Count, TotalCount = values.Count };

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
            return ((IRepository<int, Continent>)this).FindAllAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Continent>> IRepository<int, Continent>.FindAllAsync(CancellationToken cancellationToken)
        {
            var request = new ContinentRequest { Culture = this.Culture };
            return this.serviceClient.SendAsync<ContinentCollectionDataContract>(request, cancellationToken).ContinueWith<IDictionaryRange<int, Continent>>(task =>
            {
                var response = task.Result;
                if (response.Content == null || response.Content.Continents == null)
                {
                    return new DictionaryRange<int, Continent>(0);
                }

                var values = this.converterForContinentCollection.Convert(response.Content);
                var continents = new DictionaryRange<int, Continent>(values.Count) { SubtotalCount = values.Count, TotalCount = values.Count };

                foreach (var continent in values)
                {
                    continent.Culture = request.Culture;
                    continents.Add(continent.ContinentId, continent);
                }

                return continents;
            }, cancellationToken);
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

        /// <summary>The invariant method for this class.</summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.serviceClient != null);
            Contract.Invariant(this.converterForContinentCollection != null);
        }
    }
}