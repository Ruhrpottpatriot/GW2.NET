// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RenderService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the render service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Rendering
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;

    /// <summary>Provides the default implementation of the render service.</summary>
    public class RenderService : IRenderService
    {
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="RenderService"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> is a null reference.</exception>
        public RenderService(IServiceClient serviceClient)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient");
            }

            this.serviceClient = serviceClient;
        }

        /// <inheritdoc />
        byte[] IRenderService.GetImage(IRenderable file, string imageFormat)
        {
            var request = new RenderRequest
            {
                FileId = file.FileId,
                FileSignature = file.FileSignature,
                ImageFormat = imageFormat
            };
            var response = this.serviceClient.Send<byte[]>(request);
            if (response.Content == null)
            {
                return null;
            }

            return response.Content;
        }

        /// <inheritdoc />
        public Task<byte[]> GetImageAsync(IRenderable file, string imageFormat)
        {
            return this.GetImageAsync(file, imageFormat, CancellationToken.None);
        }

        /// <inheritdoc />
        public async Task<byte[]> GetImageAsync(IRenderable file, string imageFormat, CancellationToken cancellationToken)
        {
            var request = new RenderRequest
            {
                FileId = file.FileId,
                FileSignature = file.FileSignature,
                ImageFormat = imageFormat
            };
            var response = await this.serviceClient.SendAsync<byte[]>(request, cancellationToken).ConfigureAwait(false);
            return response.Content;
        }
    }
}