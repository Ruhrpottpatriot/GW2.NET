// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RenderService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the render service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Rendering
{
    using System.Drawing;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Common.Serializers;
    using GW2DotNET.Utilities;

    /// <summary>Provides the default implementation of the render service.</summary>
    public class RenderService : IRenderService
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="RenderService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public RenderService(IServiceClient serviceClient)
        {
            Preconditions.EnsureNotNull(paramName: "serviceClient", value: serviceClient);
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets an image.</summary>
        /// <param name="file">The file.</param>
        /// <param name="imageFormat">The image Format.</param>
        /// <returns>The <see cref="Image"/>.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:Render_service">wiki</a> for more information.</remarks>
        public Image GetImage(IRenderable file, string imageFormat)
        {
            Preconditions.EnsureNotNull(paramName: "file", value: file);
            Preconditions.EnsureNotNull(paramName: "imageFormat", value: imageFormat);
            var request = new RenderRequest { FileId = file.FileId, FileSignature = file.FileSignature, ImageFormat = imageFormat };
            return this.serviceClient.Send(request, new ImageSerializer()).Content;
        }

        /// <summary>Gets an image.</summary>
        /// <param name="file">The file.</param>
        /// <param name="imageFormat">The image format.</param>
        /// <returns>The <see cref="Image"/>.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:Render_service">wiki</a> for more information.</remarks>
        public Task<Image> GetImageAsync(IRenderable file, string imageFormat)
        {
            return this.GetImageAsync(file, imageFormat, CancellationToken.None);
        }

        /// <summary>Gets an image.</summary>
        /// <param name="file">The file.</param>
        /// <param name="imageFormat">The image format.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <see cref="Image"/>.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:Render_service">wiki</a> for more information.</remarks>
        public Task<Image> GetImageAsync(IRenderable file, string imageFormat, CancellationToken cancellationToken)
        {
            Preconditions.EnsureNotNull(paramName: "file", value: file);
            Preconditions.EnsureNotNull(paramName: "imageFormat", value: imageFormat);
            var request = new RenderRequest { FileId = file.FileId, FileSignature = file.FileSignature, ImageFormat = imageFormat };
            return this.serviceClient.SendAsync(request, new ImageSerializer(), cancellationToken).ContinueWith(task => task.Result.Content, cancellationToken);
        }
    }
}