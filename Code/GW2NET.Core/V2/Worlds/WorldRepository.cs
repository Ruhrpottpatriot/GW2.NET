// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorldRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v2/worlds interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Worlds
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.Entities.Worlds;
    using GW2NET.V2.Common;
    using GW2NET.V2.Worlds.Converters;
    using GW2NET.V2.Worlds.Json;

    /// <summary>Represents a repository that retrieves data from the /v2/worlds interface.</summary>
    public class WorldRepository : IRepository<int, World>, ILocalizable
    {
        #region Fields

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<WorldDataContract>>, IDictionaryRange<int, World>> converterForBulkResponse;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<int>>, ICollection<int>> converterForIdentifiersResponse;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<WorldDataContract>>, ICollectionPage<World>> converterForPageResponse;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<WorldDataContract>, World> converterForResponse;

        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="WorldRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public WorldRepository(IServiceClient serviceClient)
            : this(serviceClient, new ConverterForWorld())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="WorldRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="converterForWorld">The converter for <see cref="World"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="serviceClient"/> is <c>null</c>.</exception>
        internal WorldRepository(IServiceClient serviceClient, IConverter<WorldDataContract, World> converterForWorld)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient", "Precondition failed: serviceClient != null");
            }

            if (converterForWorld == null)
            {
                throw new ArgumentNullException("converterForWorld", "Precondition failed: converterForWorld != null");
            }

            Contract.EndContractBlock();

            this.serviceClient = serviceClient;
            this.converterForIdentifiersResponse = new ConverterForCollectionResponse<int, int>(new ConverterAdapter<int>());
            this.converterForResponse = new ConverterForResponse<WorldDataContract, World>(converterForWorld);
            this.converterForBulkResponse = new ConverterForDictionaryRangeResponse<WorldDataContract, int, World>(converterForWorld, value => value.WorldId);
            this.converterForPageResponse = new ConverterForCollectionPageResponse<WorldDataContract, World>(converterForWorld);
        }

        #endregion

        #region Public Properties

        /// <summary>Gets or sets the locale.</summary>
        public CultureInfo Culture { get; set; }

        #endregion

        #region Explicit Interface Methods

        /// <inheritdoc />
        ICollection<int> IDiscoverable<int>.Discover()
        {
            var request = new WorldDiscoveryRequest();
            var response = this.serviceClient.Send<ICollection<int>>(request);
            return this.converterForIdentifiersResponse.Convert(response);
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync()
        {
            return ((IRepository<int, World>)this).DiscoverAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync(CancellationToken cancellationToken)
        {
            var request = new WorldDiscoveryRequest();
            return
                this.serviceClient.SendAsync<ICollection<int>>(request, cancellationToken)
                    .ContinueWith(task => this.converterForIdentifiersResponse.Convert(task.Result), cancellationToken);
        }

        /// <inheritdoc />
        World IRepository<int, World>.Find(int identifier)
        {
            var request = new WorldDetailsRequest { Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo), Culture = this.Culture };
            var response = this.serviceClient.Send<WorldDataContract>(request);
            return this.converterForResponse.Convert(response);
        }

        /// <inheritdoc />
        IDictionaryRange<int, World> IRepository<int, World>.FindAll()
        {
            var request = new WorldBulkRequest { Culture = this.Culture };
            var response = this.serviceClient.Send<ICollection<WorldDataContract>>(request);
            return this.converterForBulkResponse.Convert(response);
        }

        /// <inheritdoc />
        IDictionaryRange<int, World> IRepository<int, World>.FindAll(ICollection<int> identifiers)
        {
            var request = new WorldBulkRequest
                          {
                              Culture = this.Culture, 
                              Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList()
                          };
            var response = this.serviceClient.Send<ICollection<WorldDataContract>>(request);
            return this.converterForBulkResponse.Convert(response);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, World>> IRepository<int, World>.FindAllAsync()
        {
            return ((IRepository<int, World>)this).FindAllAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, World>> IRepository<int, World>.FindAllAsync(CancellationToken cancellationToken)
        {
            var request = new WorldBulkRequest { Culture = this.Culture };
            return
                this.serviceClient.SendAsync<ICollection<WorldDataContract>>(request, cancellationToken)
                    .ContinueWith<IDictionaryRange<int, World>>(task => this.converterForBulkResponse.Convert(task.Result), cancellationToken);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, World>> IRepository<int, World>.FindAllAsync(ICollection<int> identifiers)
        {
            return ((IRepository<int, World>)this).FindAllAsync(identifiers, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, World>> IRepository<int, World>.FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            var request = new WorldBulkRequest
                          {
                              Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList(), 
                              Culture = this.Culture
                          };
            return
                this.serviceClient.SendAsync<ICollection<WorldDataContract>>(request, cancellationToken)
                    .ContinueWith<IDictionaryRange<int, World>>(task => this.converterForBulkResponse.Convert(task.Result), cancellationToken);
        }

        /// <inheritdoc />
        Task<World> IRepository<int, World>.FindAsync(int identifier)
        {
            return ((IRepository<int, World>)this).FindAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<World> IRepository<int, World>.FindAsync(int identifier, CancellationToken cancellationToken)
        {
            var request = new WorldDetailsRequest { Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo), Culture = this.Culture };
            return
                this.serviceClient.SendAsync<WorldDataContract>(request, cancellationToken)
                    .ContinueWith(task => this.converterForResponse.Convert(task.Result), cancellationToken);
        }

        /// <inheritdoc />
        ICollectionPage<World> IPaginator<World>.FindPage(int pageIndex)
        {
            var request = new WorldPageRequest { Page = pageIndex, Culture = this.Culture };
            var response = this.serviceClient.Send<ICollection<WorldDataContract>>(request);
            var worlds = this.converterForPageResponse.Convert(response);

            PageContextPatchUtility.Patch(worlds, pageIndex);

            return worlds;
        }

        /// <inheritdoc />
        ICollectionPage<World> IPaginator<World>.FindPage(int pageIndex, int pageSize)
        {
            var request = new WorldPageRequest { Page = pageIndex, PageSize = pageSize, Culture = this.Culture };
            var response = this.serviceClient.Send<ICollection<WorldDataContract>>(request);
            var worlds = this.converterForPageResponse.Convert(response);

            PageContextPatchUtility.Patch(worlds, pageIndex);

            return worlds;
        }

        /// <inheritdoc />
        Task<ICollectionPage<World>> IPaginator<World>.FindPageAsync(int pageIndex)
        {
            return ((IRepository<int, World>)this).FindPageAsync(pageIndex, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollectionPage<World>> IPaginator<World>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            var request = new WorldPageRequest { Page = pageIndex, Culture = this.Culture };
            return this.serviceClient.SendAsync<ICollection<WorldDataContract>>(request, cancellationToken).ContinueWith<ICollectionPage<World>>(
                task =>
                {
                    var response = task.Result;
                    var worlds = this.converterForPageResponse.Convert(response);

                    PageContextPatchUtility.Patch(worlds, pageIndex);

                    return worlds;
                }, 
                cancellationToken);
        }

        /// <inheritdoc />
        Task<ICollectionPage<World>> IPaginator<World>.FindPageAsync(int pageIndex, int pageSize)
        {
            return ((IRepository<int, World>)this).FindPageAsync(pageIndex, pageSize, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollectionPage<World>> IPaginator<World>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            var request = new WorldPageRequest { Page = pageIndex, PageSize = pageSize, Culture = this.Culture };

            return this.serviceClient.SendAsync<ICollection<WorldDataContract>>(request, cancellationToken).ContinueWith<ICollectionPage<World>>(
                task =>
                {
                    var response = task.Result;
                    var worlds = this.converterForPageResponse.Convert(response);

                    PageContextPatchUtility.Patch(worlds, pageIndex);

                    return worlds;
                }, 
                cancellationToken);
        }

        #endregion
    }
}