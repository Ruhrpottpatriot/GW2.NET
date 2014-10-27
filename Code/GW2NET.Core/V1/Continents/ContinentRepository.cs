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

        /// <summary>Gets the discovered identifiers.</summary>
        /// <returns>A collection of discovered identifiers.</returns>
        public ICollection<int> Discover()
        {
            throw new NotSupportedException();
        }

        /// <summary>Gets the discovered identifiers.</summary>
        /// <returns>A collection of discovered identifiers.</returns>
        public Task<ICollection<int>> DiscoverAsync()
        {
            throw new NotSupportedException();
        }

        /// <summary>Gets the discovered identifiers.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of discovered identifiers.</returns>
        public Task<ICollection<int>> DiscoverAsync(CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the <see cref="Continent"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>The <see cref="Continent"/> with the specified identifier.</returns>
        public Continent Find(int identifier)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds every <see cref="Continent"/>.</summary>
        /// <returns>A collection of every <see cref="Continent"/>.</returns>
        public IDictionaryRange<int, Continent> FindAll()
        {
            var request = new ContinentRequest { Culture = this.Culture };
            var response = this.serviceClient.Send<ContinentCollectionDataContract>(request);
            if (response.Content == null || response.Content.Continents == null)
            {
                return new DictionaryRange<int, Continent>(0);
            }

            var values = this.converterForContinentCollection.Convert(response.Content);
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

        /// <summary>Finds every <see cref="Continent"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <returns>A collection every <see cref="Continent"/> with one of the specified identifiers.</returns>
        public IDictionaryRange<int, Continent> FindAll(ICollection<int> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds every <see cref="Continent"/>.</summary>
        /// <returns>A collection of every <see cref="Continent"/>.</returns>
        public Task<IDictionaryRange<int, Continent>> FindAllAsync()
        {
            return this.FindAllAsync(CancellationToken.None);
        }

        /// <summary>Finds every <see cref="Continent"/>.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of every <see cref="Continent"/></returns>
        public Task<IDictionaryRange<int, Continent>> FindAllAsync(CancellationToken cancellationToken)
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
            }, cancellationToken);
        }

        /// <summary>Finds every <see cref="Continent"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <returns>A collection every <see cref="Continent"/> with one of the specified identifiers.</returns>
        public Task<IDictionaryRange<int, Continent>> FindAllAsync(ICollection<int> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds every <see cref="Continent"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection every <see cref="Continent"/> with one of the specified identifiers.</returns>
        public Task<IDictionaryRange<int, Continent>> FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the <see cref="Continent"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>The <see cref="Continent"/> with the specified identifier.</returns>
        public Task<Continent> FindAsync(int identifier)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the <see cref="Continent"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <see cref="Continent"/> with the specified identifier.</returns>
        public Task<Continent> FindAsync(int identifier, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <returns>The page.</returns>
        public ICollectionPage<Continent> FindPage(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the page with the specified page number and maximum size.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <returns>The page.</returns>
        public ICollectionPage<Continent> FindPage(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<Continent>> FindPageAsync(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<Continent>> FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<Continent>> FindPageAsync(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<Continent>> FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
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