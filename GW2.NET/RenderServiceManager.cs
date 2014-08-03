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
    using System.Drawing;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Rendering;

    /// <summary>Provides the default implementation of the Guild Wars 2 render service.</summary>
    public class RenderServiceManager : IRenderService
    {
        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IRenderService renderService;

        /// <summary>Initializes a new instance of the <see cref="RenderServiceManager"/> class.</summary>
        /// <param name="renderService">The render service.</param>
        public RenderServiceManager(IRenderService renderService)
        {
            Contract.Requires(renderService != null);
            this.renderService = renderService;
        }

        /// <summary>Initializes a new instance of the <see cref="RenderServiceManager"/> class.</summary>
        public RenderServiceManager()
            : this(new ServiceClient(GetBaseUri()))
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
        /// <param name="file">The file.</param>
        /// <param name="imageFormat">The image Format.</param>
        /// <returns>An instance of <see cref="Image"/>.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:Render_service">wiki</a> for more information.</remarks>
        public Image GetImage(IRenderable file, string imageFormat)
        {
            return this.renderService.GetImage(file, imageFormat);
        }

        /// <summary>Gets an image.</summary>
        /// <param name="file">The file.</param>
        /// <param name="imageFormat">The image format.</param>
        /// <returns>An instance of <see cref="Image"/>.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:Render_service">wiki</a> for more information.</remarks>
        public Task<Image> GetImageAsync(IRenderable file, string imageFormat)
        {
            return this.renderService.GetImageAsync(file, imageFormat);
        }

        /// <summary>Gets an image.</summary>
        /// <param name="file">The file.</param>
        /// <param name="imageFormat">The image format.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>An instance of <see cref="Image"/>.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:Render_service">wiki</a> for more information.</remarks>
        public Task<Image> GetImageAsync(IRenderable file, string imageFormat, CancellationToken cancellationToken)
        {
            return this.renderService.GetImageAsync(file, imageFormat, cancellationToken);
        }

        /// <summary>Gets the base URI.</summary>
        /// <returns>A <see cref="Uri"/>.</returns>
        private static Uri GetBaseUri()
        {
            Contract.Ensures(Contract.Result<Uri>() != null);
            Contract.Ensures(Contract.Result<Uri>().IsAbsoluteUri);
            var baseUri = new Uri("https://api.guildwars2.com", UriKind.Absolute);
            Contract.Assume(baseUri.IsAbsoluteUri);
            return baseUri;
        }

        /// <summary>The invariant method for this class.</summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.renderService != null);
        }
    }
}