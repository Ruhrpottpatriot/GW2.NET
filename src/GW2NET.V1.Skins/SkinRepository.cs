// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkinRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v1/skins.json and /v1/skin_details.json interfaces.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using GW2NET.V1.Skins.Converters;
using GW2NET.V1.Skins.Json;

namespace GW2NET.V1.Skins
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Skins;

    /// <summary>Represents a repository that retrieves data from the /v1/skins.json and /v1/skin_details.json interfaces.</summary>
    public sealed class SkinRepository : ISkinRepository
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
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient", "Precondition: serviceClient != null");
            }

            if (converterForSkin == null)
            {
                throw new ArgumentNullException("converterForSkin", "Precondition: converterForSkin != null");
            }

            if (converterForSkinCollection == null)
            {
                throw new ArgumentNullException("converterForSkinCollection", "Precondition: converterForSkinCollection != null");
            }

            this.converterForSkin = converterForSkin;
            this.converterForSkinCollection = converterForSkinCollection;
            this.serviceClient = serviceClient;
        }

        /// <inheritdoc />
        CultureInfo ILocalizable.Culture { get; set; }

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
            ISkinRepository self = this;
            return self.DiscoverAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync(CancellationToken cancellationToken)
        {
            var request = new SkinDiscoveryRequest();
            var response = await this.serviceClient.SendAsync<SkinCollectionDataContract>(request, cancellationToken).ConfigureAwait(false);
            if (response.Content == null)
            {
                return new List<int>(0);
            }

            return this.converterForSkinCollection.Convert(response.Content);
        }

        /// <inheritdoc />
        Skin IRepository<int, Skin>.Find(int identifier)
        {
            ISkinRepository self = this;
            var request = new SkinDetailsRequest
            {
                SkinId = identifier,
                Culture = self.Culture
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
            ISkinRepository self = this;
            return self.FindAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<Skin> IRepository<int, Skin>.FindAsync(int identifier, CancellationToken cancellationToken)
        {
            ISkinRepository self = this;
            var request = new SkinDetailsRequest
            {
                SkinId = identifier,
                Culture = self.Culture
            };
            var response = await this.serviceClient.SendAsync<SkinDataContract>(request, cancellationToken).ConfigureAwait(false);
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
    }
}