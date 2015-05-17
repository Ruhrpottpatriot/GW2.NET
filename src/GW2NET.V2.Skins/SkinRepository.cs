// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkinRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
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

    /// <summary>Represents a repository that retrieves data from the /v2/items interface. See the remarks section for important limitations regarding this implementation.</summary>
    /// <remarks>
    /// This implementation does not retrieve associated entities.
    /// </remarks>
    public sealed class SkinRepository : ISkinRepository
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<SkinDataContract>>, IDictionaryRange<int, Skin>> bulkResponseConverter;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<int>>, ICollection<int>> identifiersResponseConverter;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<SkinDataContract>>, ICollectionPage<Skin>> pageResponseConverter;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<SkinDataContract>, Skin> responseConverter;

        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="SkinRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> is a null reference.</exception>
        public SkinRepository(IServiceClient serviceClient)
            : this(serviceClient, new ConverterAdapter<ICollection<int>>(), new SkinConverter())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="SkinRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="collectionConverter">The converter for <see cref="T:ICollection{int}"/>.</param>
        /// <param name="skinConverter">The converter for <see cref="Skin"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> or <paramref name="collectionConverter"/> or <paramref name="skinConverter"/> is a null reference.</exception>
        internal SkinRepository(IServiceClient serviceClient, IConverter<ICollection<int>, ICollection<int>> collectionConverter, IConverter<SkinDataContract, Skin> skinConverter)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient", "Precondition: serviceClient != null");
            }

            if (collectionConverter == null)
            {
                throw new ArgumentNullException("collectionConverter", "Precondition: collectionConverter != null");
            }

            if (skinConverter == null)
            {
                throw new ArgumentNullException("skinConverter", "Precondition: skinConverter != null");
            }

            this.serviceClient = serviceClient;
            this.identifiersResponseConverter = new ConverterForResponse<ICollection<int>, ICollection<int>>(collectionConverter);
            this.responseConverter = new ConverterForResponse<SkinDataContract, Skin>(skinConverter);
            this.bulkResponseConverter = new ConverterForDictionaryRangeResponse<SkinDataContract, int, Skin>(skinConverter, skin => skin.SkinId);
            this.pageResponseConverter = new ConverterForCollectionPageResponse<SkinDataContract, Skin>(skinConverter);
        }

        /// <inheritdoc />
        CultureInfo ILocalizable.Culture { get; set; }

        /// <inheritdoc />
        ICollection<int> IDiscoverable<int>.Discover()
        {
            var request = new SkinDiscoveryRequest();
            var response = this.serviceClient.Send<ICollection<int>>(request);
            return this.identifiersResponseConverter.Convert(response) ?? new List<int>(0);
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync()
        {
            return ((ISkinRepository)this).DiscoverAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync(CancellationToken cancellationToken)
        {
            var request = new SkinDiscoveryRequest();
            var responseTask = this.serviceClient.SendAsync<ICollection<int>>(request, cancellationToken);
            return responseTask.ContinueWith<ICollection<int>>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        Skin IRepository<int, Skin>.Find(int identifier)
        {
            var request = new SkinDetailsRequest
            {
                Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo),
                Culture = ((ILocalizable)this).Culture
            };
            var response = this.serviceClient.Send<SkinDataContract>(request);
            return this.responseConverter.Convert(response);
        }

        /// <inheritdoc />
        Task<Skin> IRepository<int, Skin>.FindAsync(int identifier)
        {
            return ((ISkinRepository)this).FindAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<Skin> IRepository<int, Skin>.FindAsync(int identifier, CancellationToken cancellationToken)
        {
            var request = new SkinDetailsRequest
            {
                Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo),
                Culture = ((ILocalizable)this).Culture
            };
            var responseTask = this.serviceClient.SendAsync<SkinDataContract>(request, cancellationToken);
            return responseTask.ContinueWith<Skin>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        IDictionaryRange<int, Skin> IRepository<int, Skin>.FindAll()
        {
            var request = new SkinBulkRequest
            {
                Culture = ((ISkinRepository)this).Culture
            };
            var response = this.serviceClient.Send<ICollection<SkinDataContract>>(request);
            return this.bulkResponseConverter.Convert(response);
        }

        /// <inheritdoc />
        IDictionaryRange<int, Skin> IRepository<int, Skin>.FindAll(ICollection<int> identifiers)
        {
            var request = new SkinBulkRequest
            {
                Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList(),
                Culture = ((ISkinRepository)this).Culture
            };
            var response = this.serviceClient.Send<ICollection<SkinDataContract>>(request);
            return this.bulkResponseConverter.Convert(response);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Skin>> IRepository<int, Skin>.FindAllAsync()
        {
            return ((ISkinRepository)this).FindAllAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Skin>> IRepository<int, Skin>.FindAllAsync(CancellationToken cancellationToken)
        {
            var request = new SkinBulkRequest
            {
                Culture = ((ISkinRepository)this).Culture
            };
            var responseTask = this.serviceClient.SendAsync<ICollection<SkinDataContract>>(request, cancellationToken);
            return responseTask.ContinueWith<IDictionaryRange<int, Skin>>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Skin>> IRepository<int, Skin>.FindAllAsync(ICollection<int> identifiers)
        {
            return ((ISkinRepository)this).FindAllAsync(identifiers, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Skin>> IRepository<int, Skin>.FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            var request = new SkinBulkRequest
            {
                Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList(),
                Culture = ((ISkinRepository)this).Culture
            };
            var responseTask = this.serviceClient.SendAsync<ICollection<SkinDataContract>>(request, cancellationToken);
            return responseTask.ContinueWith<IDictionaryRange<int, Skin>>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        ICollectionPage<Skin> IPaginator<Skin>.FindPage(int pageIndex)
        {
            var request = new SkinPageRequest
            {
                Page = pageIndex,
                Culture = ((ISkinRepository)this).Culture
            };
            var response = this.serviceClient.Send<ICollection<SkinDataContract>>(request);
            var values = this.pageResponseConverter.Convert(response);
            PageContextPatchUtility.Patch(values, pageIndex);
            return values;
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
            var response = this.serviceClient.Send<ICollection<SkinDataContract>>(request);
            var values = this.pageResponseConverter.Convert(response);
            PageContextPatchUtility.Patch(values, pageIndex);
            return values;
        }

        /// <inheritdoc />
        Task<ICollectionPage<Skin>> IPaginator<Skin>.FindPageAsync(int pageIndex)
        {
            return ((ISkinRepository)this).FindPageAsync(pageIndex, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollectionPage<Skin>> IPaginator<Skin>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            var request = new SkinPageRequest
            {
                Page = pageIndex,
                Culture = ((ISkinRepository)this).Culture
            };
            var responseTask = this.serviceClient.SendAsync<ICollection<SkinDataContract>>(request, cancellationToken);
            return responseTask.ContinueWith(task => this.ConvertAsyncResponse(task, pageIndex), cancellationToken);
        }

        /// <inheritdoc />
        Task<ICollectionPage<Skin>> IPaginator<Skin>.FindPageAsync(int pageIndex, int pageSize)
        {
            return ((ISkinRepository)this).FindPageAsync(pageIndex, pageSize, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollectionPage<Skin>> IPaginator<Skin>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            var request = new SkinPageRequest
            {
                Page = pageIndex,
                PageSize = pageSize,
                Culture = ((ISkinRepository)this).Culture
            };
            var responseTask = this.serviceClient.SendAsync<ICollection<SkinDataContract>>(request, cancellationToken);
            return responseTask.ContinueWith(task => this.ConvertAsyncResponse(task, pageIndex), cancellationToken);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private IDictionaryRange<int, Skin> ConvertAsyncResponse(Task<IResponse<ICollection<SkinDataContract>>> task)
        {
            Debug.Assert(task != null, "task != null");
            var values = this.bulkResponseConverter.Convert(task.Result);
            if (values == null)
            {
                return new DictionaryRange<int, Skin>(0);
            }

            return values;
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private ICollectionPage<Skin> ConvertAsyncResponse(Task<IResponse<ICollection<SkinDataContract>>> task, int pageIndex)
        {
            Debug.Assert(task != null, "task != null");
            var values = this.pageResponseConverter.Convert(task.Result);
            if (values == null)
            {
                return new CollectionPage<Skin>(0);
            }

            PageContextPatchUtility.Patch(values, pageIndex);

            return values;
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private ICollection<int> ConvertAsyncResponse(Task<IResponse<ICollection<int>>> task)
        {
            Debug.Assert(task != null, "task != null");
            var ids = this.identifiersResponseConverter.Convert(task.Result);
            if (ids == null)
            {
                return new List<int>(0);
            }

            return ids;
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private Skin ConvertAsyncResponse(Task<IResponse<SkinDataContract>> task)
        {
            Debug.Assert(task != null, "task != null");
            return this.responseConverter.Convert(task.Result);
        }
    }
}