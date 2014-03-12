// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RenderFileRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for the current build ID of the game.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace RestSharp.GW2DotNET.Requests
{
    using System.Drawing.Imaging;
    using System.Threading;
    using System.Threading.Tasks;

    using global::GW2DotNET.Utilities;

    using global::GW2DotNET.V1.Core;

    using global::GW2DotNET.V1.Core.ErrorInformation;

    /// <summary>
    ///     Represents a request for the current build ID of the game.
    /// </summary>
    /// <remarks>
    ///     See <a href="http://wiki.guildwars2.com/wiki/API:Render_service" /> for more information.
    /// </remarks>
    public class RenderFileRequest : ServiceRequest
    {
        /// <summary>Initializes a new instance of the <see cref="RenderFileRequest"/> class. Initializes a new instance of the <see cref="BuildRequest"/> class.</summary>
        /// <param name="file">The file.</param>
        /// <param name="imageFormat">The image Format.</param>
        public RenderFileRequest(IRenderable file, ImageFormat imageFormat)
            : base(CreateFileResource(file, imageFormat))
        {
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public IServiceResponse<ErrorResult> GetResponse(IServiceClient serviceClient)
        {
            return this.GetResponse<ErrorResult>(serviceClient);
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<ErrorResult>> GetResponseAsync(IServiceClient serviceClient)
        {
            return this.GetResponseAsync<ErrorResult>(serviceClient);
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<ErrorResult>> GetResponseAsync(IServiceClient serviceClient, CancellationToken cancellationToken)
        {
            return this.GetResponseAsync<ErrorResult>(serviceClient, cancellationToken);
        }

        /// <summary>Gets the URI that points to the specified file.</summary>
        /// <param name="file">The file.</param>
        /// <param name="imageFormat">The image format.</param>
        /// <returns>The file resource.</returns>
        private static string CreateFileResource(IRenderable file, ImageFormat imageFormat)
        {
            Preconditions.EnsureNotNull(paramName: "file", value: file);
            Preconditions.EnsureNotNull(paramName: "imageFormat", value: imageFormat);

            return string.Format("file/{0}/{1}.{2}", file.GetFileSignature(), file.GetFileId(), GetExtension(imageFormat));
        }

        /// <summary>Gets a file extension for the specified image format.</summary>
        /// <param name="imageFormat">The image format.</param>
        /// <returns>The extension.</returns>
        private static string GetExtension(ImageFormat imageFormat)
        {
            if (object.Equals(imageFormat, ImageFormat.Jpeg))
            {
                return @"jpg";
            }

            return imageFormat.ToString().ToLowerInvariant();
        }
    }
}