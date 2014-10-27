// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectiveNameRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v1/wvw/objective_names.json interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.WorldVersusWorld.Objectives
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Entities.WorldVersusWorld;
    using GW2NET.V1.WorldVersusWorld.Objectives.Json;
    using GW2NET.V1.WorldVersusWorld.Objectives.Json.Converters;

    /// <summary>Represents a repository that retrieves data from the /v1/wvw/objective_names.json interface.</summary>
    public class ObjectiveNameRepository : IRepository<int, ObjectiveName>, ILocalizable
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ObjectiveNameDataContract, ObjectiveName> converterForObjectiveName;

        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="ObjectiveNameRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public ObjectiveNameRepository(IServiceClient serviceClient)
            : this(serviceClient, new ConverterForObjectiveName())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ObjectiveNameRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="converterForObjectiveName">The converter <see cref="ObjectiveName"/>.</param>
        internal ObjectiveNameRepository(IServiceClient serviceClient, IConverter<ObjectiveNameDataContract, ObjectiveName> converterForObjectiveName)
        {
            this.serviceClient = serviceClient;
            this.converterForObjectiveName = converterForObjectiveName;
        }

        /// <summary>Gets or sets the locale.</summary>
        public CultureInfo Culture { get; set; }

        /// <summary>Gets the discovered identifiers.</summary>
        /// <returns>A collection of discovered identifiers.</returns>
        public ICollection<int> Discover()
        {
            throw new NotSupportedException("This endpoint only supports the 'FindAll()' interface.");
        }

        /// <summary>Gets the discovered identifiers.</summary>
        /// <returns>A collection of discovered identifiers.</returns>
        public Task<ICollection<int>> DiscoverAsync()
        {
            throw new NotSupportedException("This endpoint only supports the 'FindAll()' interface.");
        }

        /// <summary>Gets the discovered identifiers.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of discovered identifiers.</returns>
        public Task<ICollection<int>> DiscoverAsync(CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This endpoint only supports the 'FindAll()' interface.");
        }

        /// <summary>Finds the <see cref="Objective"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>The <see cref="Objective"/> with the specified identifier.</returns>
        public ObjectiveName Find(int identifier)
        {
            throw new NotSupportedException("This endpoint only supports the 'FindAll()' interface.");
        }

        /// <summary>Finds every <see cref="Objective"/>.</summary>
        /// <returns>A collection of every <see cref="Objective"/>.</returns>
        public IDictionaryRange<int, ObjectiveName> FindAll()
        {
            var request = new ObjectiveNameRequest { Culture = this.Culture };
            var response = this.serviceClient.Send<ICollection<ObjectiveNameDataContract>>(request);
            if (response == null)
            {
                return new DictionaryRange<int, ObjectiveName>(0);
            }

            var values = new DictionaryRange<int, ObjectiveName>(response.Content.Count) { SubtotalCount = response.Content.Count, TotalCount = response.Content.Count };

            foreach (var value in response.Content.Select(this.converterForObjectiveName.Convert))
            {
                value.Culture = request.Culture;
                values.Add(value.ObjectiveId, value);
            }

            return values;
        }

        /// <summary>Finds every <see cref="Objective"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <returns>A collection every <see cref="Objective"/> with one of the specified identifiers.</returns>
        public IDictionaryRange<int, ObjectiveName> FindAll(ICollection<int> identifiers)
        {
            throw new NotSupportedException("This endpoint only supports the 'FindAll()' interface.");
        }

        /// <summary>Finds every <see cref="Objective"/>.</summary>
        /// <returns>A collection of every <see cref="Objective"/>.</returns>
        public Task<IDictionaryRange<int, ObjectiveName>> FindAllAsync()
        {
            return this.FindAllAsync(CancellationToken.None);
        }

        /// <summary>Finds every <see cref="Objective"/>.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of every <see cref="Objective"/></returns>
        public Task<IDictionaryRange<int, ObjectiveName>> FindAllAsync(CancellationToken cancellationToken)
        {
            var request = new ObjectiveNameRequest { Culture = this.Culture };
            return this.serviceClient.SendAsync<ICollection<ObjectiveNameDataContract>>(request, cancellationToken).ContinueWith<IDictionaryRange<int, ObjectiveName>>(task =>
            {
                var response = task.Result;
                if (response == null)
                {
                    return new DictionaryRange<int, ObjectiveName>(0);
                }

                var values = new DictionaryRange<int, ObjectiveName>(response.Content.Count) { SubtotalCount = response.Content.Count, TotalCount = response.Content.Count };

                foreach (var value in response.Content.Select(this.converterForObjectiveName.Convert))
                {
                    value.Culture = request.Culture;
                    values.Add(value.ObjectiveId, value);
                }

                return values;
            }, cancellationToken);
        }

        /// <summary>Finds every <see cref="Objective"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <returns>A collection every <see cref="Objective"/> with one of the specified identifiers.</returns>
        public Task<IDictionaryRange<int, ObjectiveName>> FindAllAsync(ICollection<int> identifiers)
        {
            throw new NotSupportedException("This endpoint only supports the 'FindAll()' interface.");
        }

        /// <summary>Finds every <see cref="Objective"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection every <see cref="Objective"/> with one of the specified identifiers.</returns>
        public Task<IDictionaryRange<int, ObjectiveName>> FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This endpoint only supports the 'FindAll()' interface.");
        }

        /// <summary>Finds the <see cref="Objective"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>The <see cref="Objective"/> with the specified identifier.</returns>
        public Task<ObjectiveName> FindAsync(int identifier)
        {
            throw new NotSupportedException("This endpoint only supports the 'FindAll()' interface.");
        }

        /// <summary>Finds the <see cref="Objective"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <see cref="Objective"/> with the specified identifier.</returns>
        public Task<ObjectiveName> FindAsync(int identifier, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This endpoint only supports the 'FindAll()' interface.");
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <returns>The page.</returns>
        public ICollectionPage<ObjectiveName> FindPage(int pageIndex)
        {
            throw new NotSupportedException("This endpoint only supports the 'FindAll()' interface.");
        }

        /// <summary>Finds the page with the specified page number and maximum size.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <returns>The page.</returns>
        public ICollectionPage<ObjectiveName> FindPage(int pageIndex, int pageSize)
        {
            throw new NotSupportedException("This endpoint only supports the 'FindAll()' interface.");
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<ObjectiveName>> FindPageAsync(int pageIndex)
        {
            throw new NotSupportedException("This endpoint only supports the 'FindAll()' interface.");
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<ObjectiveName>> FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This endpoint only supports the 'FindAll()' interface.");
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<ObjectiveName>> FindPageAsync(int pageIndex, int pageSize)
        {
            throw new NotSupportedException("This endpoint only supports the 'FindAll()' interface.");
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<ObjectiveName>> FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This endpoint only supports the 'FindAll()' interface.");
        }

        /// <summary>The invariant method for this class.</summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.serviceClient != null);
            Contract.Invariant(this.converterForObjectiveName != null);
        }
    }
}