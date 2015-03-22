// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FloorRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the FloorRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Floors
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.Maps;

    /// <summary>Represents a repository that retrieves data from the /v2/floors interface.</summary>
    public sealed class FloorRepository : IFloorRepository
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<FloorDataContract>>, IDictionaryRange<int, Floor>> bulkConverter;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<int>>, ICollection<int>> identifiersConverter;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<FloorDataContract>>, ICollectionPage<Floor>> pageConverter;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<FloorDataContract>, Floor> responseConverter;

        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>The continent identifier.</summary>
        private readonly int continentId;

        /// <summary>Initializes a new instance of the <see cref="FloorRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="continentId">The continent identifier.</param>
        public FloorRepository(IServiceClient serviceClient, int continentId = 0)
            : this(serviceClient, new ConverterAdapter<ICollection<int>>(), new FloorConverter())
        {
            Contract.Requires(serviceClient != null);
            this.continentId = continentId;
        }

        /// <summary>Initializes a new instance of the <see cref="FloorRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="converterForFloorCollection">The converter for <see cref="T:ICollection{int}"/>.</param>
        /// <param name="converterForFloor">The converter for <see cref="Floor"/>.</param>
        internal FloorRepository(IServiceClient serviceClient, IConverter<ICollection<int>, ICollection<int>> converterForFloorCollection, IConverter<FloorDataContract, Floor> converterForFloor)
        {
            Contract.Requires(serviceClient != null);
            Contract.Requires(converterForFloorCollection != null);
            Contract.Requires(converterForFloor != null);
            this.serviceClient = serviceClient;
            this.identifiersConverter = new ConverterForResponse<ICollection<int>, ICollection<int>>(converterForFloorCollection);
            this.responseConverter = new ConverterForResponse<FloorDataContract, Floor>(converterForFloor);
            this.bulkConverter = new ConverterForDictionaryRangeResponse<FloorDataContract, int, Floor>(converterForFloor, floor => floor.FloorId);
            this.pageConverter = new ConverterForCollectionPageResponse<FloorDataContract, Floor>(converterForFloor);
        }

        /// <inheritdoc />
        int IFloorRepository.ContinentId
        {
            get
            {
                return this.continentId;
            }
        }

        /// <inheritdoc />
        CultureInfo ILocalizable.Culture { get; set; }

        /// <inheritdoc />
        ICollection<int> IDiscoverable<int>.Discover()
        {
            var request = new FloorDiscoveryRequest { ContinentId = ((IFloorRepository)this).ContinentId };
            var response = this.serviceClient.Send<ICollection<int>>(request);
            return this.identifiersConverter.Convert(response) ?? new List<int>(0);
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync()
        {
            return ((IFloorRepository)this).DiscoverAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync(CancellationToken cancellationToken)
        {
            var request = new FloorDiscoveryRequest { ContinentId = ((IFloorRepository)this).ContinentId };
            var responseTask = this.serviceClient.SendAsync<ICollection<int>>(request, cancellationToken);
            return responseTask.ContinueWith<ICollection<int>>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        Floor IRepository<int, Floor>.Find(int identifier)
        {
            var request = new FloorDetailsRequest
            {
                ContinentId = ((IFloorRepository)this).ContinentId,
                Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo),
                Culture = ((ILocalizable)this).Culture
            };
            var response = this.serviceClient.Send<FloorDataContract>(request);
            return this.responseConverter.Convert(response);
        }

        /// <inheritdoc />
        IDictionaryRange<int, Floor> IRepository<int, Floor>.FindAll()
        {
            var request = new FloorBulkRequest
            {
                ContinentId = ((IFloorRepository)this).ContinentId,
                Culture = ((ILocalizable)this).Culture
            };
            var response = this.serviceClient.Send<ICollection<FloorDataContract>>(request);
            return this.bulkConverter.Convert(response);
        }

        /// <inheritdoc />
        IDictionaryRange<int, Floor> IRepository<int, Floor>.FindAll(ICollection<int> identifiers)
        {
            var request = new FloorBulkRequest
            {
                ContinentId = ((IFloorRepository)this).ContinentId,
                Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList(),
                Culture = ((ILocalizable)this).Culture
            };
            var response = this.serviceClient.Send<ICollection<FloorDataContract>>(request);
            return this.bulkConverter.Convert(response);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Floor>> IRepository<int, Floor>.FindAllAsync()
        {
            return ((IFloorRepository)this).FindAllAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Floor>> IRepository<int, Floor>.FindAllAsync(CancellationToken cancellationToken)
        {
            var request = new FloorBulkRequest
            {
                ContinentId = ((IFloorRepository)this).ContinentId,
                Culture = ((ILocalizable)this).Culture
            };
            var responseTask = this.serviceClient.SendAsync<ICollection<FloorDataContract>>(request, cancellationToken);
            return responseTask.ContinueWith<IDictionaryRange<int, Floor>>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Floor>> IRepository<int, Floor>.FindAllAsync(ICollection<int> identifiers)
        {
            return ((IFloorRepository)this).FindAllAsync(identifiers, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Floor>> IRepository<int, Floor>.FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            var request = new FloorBulkRequest
            {
                ContinentId = ((IFloorRepository)this).ContinentId,
                Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList(),
                Culture = ((ILocalizable)this).Culture
            };
            var responseTask = this.serviceClient.SendAsync<ICollection<FloorDataContract>>(request, cancellationToken);
            return responseTask.ContinueWith<IDictionaryRange<int, Floor>>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        Task<Floor> IRepository<int, Floor>.FindAsync(int identifier)
        {
            return ((IFloorRepository)this).FindAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<Floor> IRepository<int, Floor>.FindAsync(int identifier, CancellationToken cancellationToken)
        {
            var request = new FloorDetailsRequest
            {
                ContinentId = ((IFloorRepository)this).ContinentId,
                Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo),
                Culture = ((ILocalizable)this).Culture
            };
            var responseTask = this.serviceClient.SendAsync<FloorDataContract>(request, cancellationToken);
            return responseTask.ContinueWith<Floor>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        ICollectionPage<Floor> IPaginator<Floor>.FindPage(int pageIndex)
        {
            var request = new FloorPageRequest
            {
                ContinentId = ((IFloorRepository)this).ContinentId,
                Page = pageIndex,
                Culture = ((ILocalizable)this).Culture
            };
            var response = this.serviceClient.Send<ICollection<FloorDataContract>>(request);
            var values = this.pageConverter.Convert(response);
            PageContextPatchUtility.Patch(values, pageIndex);
            return values;
        }

        /// <inheritdoc />
        ICollectionPage<Floor> IPaginator<Floor>.FindPage(int pageIndex, int pageSize)
        {
            var request = new FloorPageRequest
            {
                ContinentId = ((IFloorRepository)this).ContinentId,
                Page = pageIndex,
                PageSize = pageSize,
                Culture = ((ILocalizable)this).Culture
            };
            var response = this.serviceClient.Send<ICollection<FloorDataContract>>(request);
            var values = this.pageConverter.Convert(response);
            PageContextPatchUtility.Patch(values, pageIndex);
            return values;
        }

        /// <inheritdoc />
        Task<ICollectionPage<Floor>> IPaginator<Floor>.FindPageAsync(int pageIndex)
        {
            return ((IFloorRepository)this).FindPageAsync(pageIndex, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollectionPage<Floor>> IPaginator<Floor>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            var request = new FloorPageRequest
            {
                ContinentId = ((IFloorRepository)this).ContinentId,
                Page = pageIndex,
                Culture = ((ILocalizable)this).Culture
            };
            var responseTask = this.serviceClient.SendAsync<ICollection<FloorDataContract>>(request, cancellationToken);
            return responseTask.ContinueWith(task => this.ConvertAsyncResponse(task, pageIndex), cancellationToken);
        }

        /// <inheritdoc />
        Task<ICollectionPage<Floor>> IPaginator<Floor>.FindPageAsync(int pageIndex, int pageSize)
        {
            return ((IFloorRepository)this).FindPageAsync(pageIndex, pageSize, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollectionPage<Floor>> IPaginator<Floor>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            var request = new FloorPageRequest
            {
                ContinentId = ((IFloorRepository)this).ContinentId,
                Page = pageIndex,
                PageSize = pageSize,
                Culture = ((ILocalizable)this).Culture
            };
            var responseTask = this.serviceClient.SendAsync<ICollection<FloorDataContract>>(request, cancellationToken);
            return responseTask.ContinueWith(task => this.ConvertAsyncResponse(task, pageIndex), cancellationToken);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private IDictionaryRange<int, Floor> ConvertAsyncResponse(Task<IResponse<ICollection<FloorDataContract>>> task)
        {
            Contract.Requires(task != null);
            Contract.Ensures(Contract.Result<IDictionaryRange<int, Floor>>() != null);
            var values = this.bulkConverter.Convert(task.Result);
            return values ?? new DictionaryRange<int, Floor>(0);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private ICollectionPage<Floor> ConvertAsyncResponse(Task<IResponse<ICollection<FloorDataContract>>> task, int pageIndex)
        {
            Contract.Requires(task != null);
            Contract.Ensures(Contract.Result<ICollectionPage<Floor>>() != null);
            var values = this.pageConverter.Convert(task.Result);
            if (values == null)
            {
                return new CollectionPage<Floor>(0);
            }

            PageContextPatchUtility.Patch(values, pageIndex);

            return values;
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private ICollection<int> ConvertAsyncResponse(Task<IResponse<ICollection<int>>> task)
        {
            Contract.Requires(task != null);
            Contract.Ensures(Contract.Result<ICollection<int>>() != null);
            var ids = this.identifiersConverter.Convert(task.Result);
            return ids ?? new List<int>(0);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private Floor ConvertAsyncResponse(Task<IResponse<FloorDataContract>> task)
        {
            Contract.Requires(task != null);
            return this.responseConverter.Convert(task.Result);
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        [SuppressMessage("ReSharper", "UnusedMember.Local", Justification = "Only used when CodeContracts are enabled.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.serviceClient != null);
            Contract.Invariant(this.responseConverter != null);
            Contract.Invariant(this.identifiersConverter != null);
            Contract.Invariant(this.bulkConverter != null);
            Contract.Invariant(this.pageConverter != null);
        }
    }
}