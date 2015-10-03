// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkinRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v1/skins.json and /v1/skin_details.json interfaces.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Skins
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using GW2NET.Common;
    using GW2NET.Skins;
    using GW2NET.V1.Skins.Json;

    /// <summary>Represents a repository that retrieves data from the /v1/skins.json and /v1/skin_details.json interfaces.</summary>
    public sealed class SkinRepository : ISkinRepository
    {
        private readonly IConverter<SkinDTO, Skin> skinConverter;

        private readonly IConverter<SkinCollectionDTO, ICollection<int>> skinCollectionConverter;

        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="SkinRepository"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <param name="skinConverter">The converter for <see cref="Skin"/>.</param>
        /// <param name="skinCollectionConverter">The converter for <see cref="T:ICollection{int}"/>.</param>
        public SkinRepository(IServiceClient serviceClient, IConverter<SkinDTO, Skin> skinConverter, IConverter<SkinCollectionDTO, ICollection<int>> skinCollectionConverter)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient");
            }

            if (skinConverter == null)
            {
                throw new ArgumentNullException("skinConverter");
            }

            if (skinCollectionConverter == null)
            {
                throw new ArgumentNullException("skinCollectionConverter");
            }

            this.skinConverter = skinConverter;
            this.skinCollectionConverter = skinCollectionConverter;
            this.serviceClient = serviceClient;
        }

        /// <inheritdoc />
        CultureInfo ILocalizable.Culture { get; set; }

        /// <inheritdoc />
        ICollection<int> IDiscoverable<int>.Discover()
        {
            var request = new SkinDiscoveryRequest();
            var response = this.serviceClient.Send<SkinCollectionDTO>(request);
            if (response.Content == null)
            {
                return new List<int>(0);
            }

            return this.skinCollectionConverter.Convert(response.Content, null);
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
            var response = await this.serviceClient.SendAsync<SkinCollectionDTO>(request, cancellationToken).ConfigureAwait(false);
            if (response.Content == null)
            {
                return new List<int>(0);
            }

            return this.skinCollectionConverter.Convert(response.Content, response);
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
            var response = this.serviceClient.Send<SkinDTO>(request);
            if (response.Content == null)
            {
                return null;
            }

            var skin = this.skinConverter.Convert(response.Content, null);
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
            var response = await this.serviceClient.SendAsync<SkinDTO>(request, cancellationToken).ConfigureAwait(false);
            if (response.Content == null)
            {
                return null;
            }

            var skin = this.skinConverter.Convert(response.Content, response);
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