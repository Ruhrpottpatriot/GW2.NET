// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FloorRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v1/map_floor.json interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Floors
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Maps;
    using GW2NET.V1.Floors.Converters;
    using GW2NET.V1.Floors.Json;

    /// <summary>Represents a repository that retrieves data from the /v1/map_floor.json interface.</summary>
    public class FloorRepository : IFloorRepository
    {
        /// <summary>The continent identifier.</summary>
        private readonly int continentId;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<FloorDataContract, Floor> converterForFloor;

        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="FloorRepository"/> class.</summary>
        public FloorRepository()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="FloorRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="continentId">The continent identifier.</param>
        public FloorRepository(IServiceClient serviceClient, int continentId = 0)
            : this(serviceClient, continentId, new ConverterForFloor())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="FloorRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="continentId">The continent identifier.</param>
        /// <param name="converterForFloor">The converter for <see cref="Floor"/>.</param>
        internal FloorRepository(IServiceClient serviceClient, int continentId, IConverter<FloorDataContract, Floor> converterForFloor)
        {
            Contract.Requires(serviceClient != null);
            Contract.Requires(converterForFloor != null);
            this.serviceClient = serviceClient;
            this.continentId = continentId;
            this.converterForFloor = converterForFloor;
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
        Floor IRepository<int, Floor>.Find(int identifier)
        {
            IFloorRepository self = this;
            var request = new FloorRequest
            {
                ContinentId = self.ContinentId,
                Floor = identifier,
                Culture = self.Culture
            };
            var response = this.serviceClient.Send<FloorDataContract>(request);
            if (response.Content == null)
            {
                return null;
            }

            var floor = this.converterForFloor.Convert(response.Content);
            if (floor == null)
            {
                return null;
            }

            floor.ContinentId = this.continentId;
            floor.FloorId = identifier;
            floor.Culture = request.Culture;

            return floor;
        }

        /// <inheritdoc />
        IDictionaryRange<int, Floor> IRepository<int, Floor>.FindAll()
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        IDictionaryRange<int, Floor> IRepository<int, Floor>.FindAll(ICollection<int> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Floor>> IRepository<int, Floor>.FindAllAsync()
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Floor>> IRepository<int, Floor>.FindAllAsync(CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Floor>> IRepository<int, Floor>.FindAllAsync(ICollection<int> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Floor>> IRepository<int, Floor>.FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<Floor> IRepository<int, Floor>.FindAsync(int identifier)
        {
            IFloorRepository self = this;
            return self.FindAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<Floor> IRepository<int, Floor>.FindAsync(int identifier, CancellationToken cancellationToken)
        {
            IFloorRepository self = this;
            var request = new FloorRequest
            {
                ContinentId = self.ContinentId,
                Floor = identifier,
                Culture = self.Culture
            };
            var responseTask = this.serviceClient.SendAsync<FloorDataContract>(request, cancellationToken);
            return responseTask.ContinueWith(task => this.ConvertAsyncResponse(task, this.continentId, identifier, request.Culture), cancellationToken);
        }

        /// <inheritdoc />
        ICollectionPage<Floor> IPaginator<Floor>.FindPage(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        ICollectionPage<Floor> IPaginator<Floor>.FindPage(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<Floor>> IPaginator<Floor>.FindPageAsync(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<Floor>> IPaginator<Floor>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<Floor>> IPaginator<Floor>.FindPageAsync(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<Floor>> IPaginator<Floor>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private Floor ConvertAsyncResponse(Task<IResponse<FloorDataContract>> task, int continentId, int floorId, CultureInfo culture)
        {
            Contract.Requires(task != null);
            var response = task.Result;
            if (response.Content == null)
            {
                return null;
            }

            var floor = this.converterForFloor.Convert(response.Content);
            if (floor == null)
            {
                return null;
            }

            floor.ContinentId = continentId;
            floor.FloorId = floorId;
            floor.Culture = culture;

            return floor;
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.serviceClient != null);
        }

        /// <inheritdoc />
        int IFloorRepository.ContinentId
        {
            get
            {
                return this.continentId;
            }
        }
    }
}