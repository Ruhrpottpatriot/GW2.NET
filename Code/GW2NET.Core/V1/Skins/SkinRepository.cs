// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkinRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v1/skins.json and /v1/skin_details.json interfaces.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Skins
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Entities.Skins;
    using GW2NET.V1.Skins.Converters;
    using GW2NET.V1.Skins.Json;

    /// <summary>Represents a repository that retrieves data from the /v1/skins.json and /v1/skin_details.json interfaces.</summary>
    public sealed class SkinRepository : IRepository<int, Skin>, ILocalizable
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<SkinDataContract, Skin> converterForSkin;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<SkinCollectionDataContract, ICollection<int>> converterForSkinCollection;

        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="SkinRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public SkinRepository(IServiceClient serviceClient)
            : this(serviceClient, new ConverterForSkin(), new ConverterForSkinCollection())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="SkinRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="converterForSkin">The converter for <see cref="Skin"/>.</param>
        /// <param name="converterForSkinCollection">The converter for <see cref="T:ICollection{int}"/>.</param>
        internal SkinRepository(IServiceClient serviceClient, IConverter<SkinDataContract, Skin> converterForSkin, IConverter<SkinCollectionDataContract, ICollection<int>> converterForSkinCollection)
        {
            Contract.Requires(serviceClient != null);
            Contract.Requires(converterForSkin != null);
            Contract.Requires(converterForSkinCollection != null);
            this.converterForSkin = converterForSkin;
            this.converterForSkinCollection = converterForSkinCollection;
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets or sets the locale.</summary>
        public CultureInfo Culture { get; set; }

        /// <inheritdoc />
        ICollection<int> IDiscoverable<int>.Discover()
        {
            var request = new SkinDiscoveryRequest();
            var response = this.serviceClient.Send<SkinCollectionDataContract>(request);
            if (response.Content == null)
            {
                return new List<int>(0);
            }

            return this.converterForSkinCollection.Convert(response.Content);
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync()
        {
            return ((IRepository<int, Skin>)this).DiscoverAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync(CancellationToken cancellationToken)
        {
            var request = new SkinDiscoveryRequest();
            var responseTask = this.serviceClient.SendAsync<SkinCollectionDataContract>(request, cancellationToken);
            return responseTask.ContinueWith<ICollection<int>>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        Skin IRepository<int, Skin>.Find(int identifier)
        {
            var request = new SkinDetailsRequest
            {
                SkinId = identifier, 
                Culture = this.Culture
            };
            var response = this.serviceClient.Send<SkinDataContract>(request);
            if (response.Content == null)
            {
                return null;
            }

            var skin = this.converterForSkin.Convert(response.Content);
            if (skin == null)
            {
                return null;
            }

            skin.Culture = request.Culture;

            return skin;
        }

        /// <inheritdoc />
        IDictionaryRange<int, Skin> IRepository<int, Skin>.FindAll()
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        IDictionaryRange<int, Skin> IRepository<int, Skin>.FindAll(ICollection<int> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Skin>> IRepository<int, Skin>.FindAllAsync()
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Skin>> IRepository<int, Skin>.FindAllAsync(CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Skin>> IRepository<int, Skin>.FindAllAsync(ICollection<int> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Skin>> IRepository<int, Skin>.FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<Skin> IRepository<int, Skin>.FindAsync(int identifier)
        {
            return ((IRepository<int, Skin>)this).FindAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<Skin> IRepository<int, Skin>.FindAsync(int identifier, CancellationToken cancellationToken)
        {
            var request = new SkinDetailsRequest
            {
                SkinId = identifier, 
                Culture = this.Culture
            };
            var responseTask = this.serviceClient.SendAsync<SkinDataContract>(request, cancellationToken);
            return responseTask.ContinueWith(task => this.OnAsyncResponse(task, request.Culture), cancellationToken);
        }

        /// <inheritdoc />
        ICollectionPage<Skin> IPaginator<Skin>.FindPage(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        ICollectionPage<Skin> IPaginator<Skin>.FindPage(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<Skin>> IPaginator<Skin>.FindPageAsync(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<Skin>> IPaginator<Skin>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<Skin>> IPaginator<Skin>.FindPageAsync(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<Skin>> IPaginator<Skin>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private ICollection<int> ConvertAsyncResponse(Task<IResponse<SkinCollectionDataContract>> task)
        {
            Contract.Requires(task != null);
            Contract.Ensures(Contract.Result<ICollection<int>>() != null);
            var response = task.Result;
            if (response.Content == null)
            {
                return new List<int>(0);
            }

            return this.converterForSkinCollection.Convert(response.Content);
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.serviceClient != null);
            Contract.Invariant(this.converterForSkin != null);
            Contract.Invariant(this.converterForSkinCollection != null);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private Skin OnAsyncResponse(Task<IResponse<SkinDataContract>> task, CultureInfo culture)
        {
            var response = task.Result;
            if (response.Content == null)
            {
                return null;
            }

            var skin = this.converterForSkin.Convert(response.Content);
            if (skin == null)
            {
                return null;
            }

            skin.Culture = culture;

            return skin;
        }
    }
}