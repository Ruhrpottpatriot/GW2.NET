// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RenderServiceManager.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the Guild Wars 2 render service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Common.Serializers;
    using GW2DotNET.Rendering;

    /// <summary>Provides the default implementation of the Guild Wars 2 render service.</summary>
    public class RenderServiceManager : IRenderService
    {
        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IRenderService renderService;

        /// <summary>Initializes a new instance of the <see cref="RenderServiceManager"/> class.</summary>
        public RenderServiceManager()
            : this(GetDefaultServiceClient())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="RenderServiceManager"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public RenderServiceManager(IServiceClient serviceClient)
        {
            Contract.Requires(serviceClient != null);
            this.renderService = new RenderService(serviceClient);
        }

        /// <summary>Gets an image.</summary>
        /// <param name="file">The file identifier.</param>
        /// <param name="imageFormat">The image file format.</param>
        /// <returns>The binary representation of an image.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:Render_service">wiki</a> for more information.</remarks>
        public byte[] GetImage(IRenderable file, string imageFormat)
        {
            return this.renderService.GetImage(file, imageFormat);
        }

        /// <summary>Gets an image.</summary>
        /// <param name="file">The file identifier.</param>
        /// <param name="imageFormat">The image format.</param>
        /// <returns>The binary representation of an image.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:Render_service">wiki</a> for more information.</remarks>
        public Task<byte[]> GetImageAsync(IRenderable file, string imageFormat)
        {
            return this.renderService.GetImageAsync(file, imageFormat);
        }

        /// <summary>Gets an image.</summary>
        /// <param name="file">The file identifier.</param>
        /// <param name="imageFormat">The image format.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The binary representation of an image.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:Render_service">wiki</a> for more information.</remarks>
        public Task<byte[]> GetImageAsync(IRenderable file, string imageFormat, CancellationToken cancellationToken)
        {
            return this.renderService.GetImageAsync(file, imageFormat, cancellationToken);
        }

        /// <summary>Gets the base URI.</summary>
        /// <returns>A <see cref="Uri"/>.</returns>
        private static Uri GetBaseUri()
        {
            Contract.Ensures(Contract.Result<Uri>() != null);
            Contract.Ensures(Contract.Result<Uri>().IsAbsoluteUri);
            var baseUri = new Uri("https://render.guildwars2.com", UriKind.Absolute);
            Contract.Assume(baseUri.IsAbsoluteUri);
            return baseUri;
        }

        /// <summary>Infrastructure. Creates and configures an instance of the default service client.</summary>
        /// <returns>The <see cref="IServiceClient"/>.</returns>
        private static IServiceClient GetDefaultServiceClient()
        {
            Contract.Ensures(Contract.Result<IServiceClient>() != null);
            var baseUri = GetBaseUri();
            var successSerializerFactory = new BinarySerializerFactory();
            var errorSerializerFactory = new DataContractJsonSerializerFactory();
            return new ServiceClient(baseUri, successSerializerFactory, errorSerializerFactory);
        }

        /// <summary>The invariant method for this class.</summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.renderService != null);
        }
    }
}