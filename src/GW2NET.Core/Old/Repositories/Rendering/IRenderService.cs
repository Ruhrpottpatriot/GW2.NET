// <copyright file="IRenderService.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Rendering
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;

    /// <summary>Provides the interface for the render service.</summary>
    /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:Render_service">wiki</a> for more information.</remarks>
    public interface IRenderService
    {
        /// <summary>Gets binary image data for the given file identifier and image format.</summary>
        /// <param name="file">The file identifier.</param>
        /// <param name="imageFormat">The image format.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="file"/> or <paramref name="imageFormat"/> is a null reference.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The value of <paramref name="imageFormat"/> is not "jpg" or "png".</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving the image data.</exception>
        /// <returns>The binary image data.</returns>
        Task<byte[]> GetImageAsync(IRenderable file, string imageFormat);

        /// <summary>Gets binary image data for the given file identifier and image format.</summary>
        /// <param name="file">The file identifier.</param>
        /// <param name="imageFormat">The image format.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="file"/> or <paramref name="imageFormat"/> is a null reference.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The value of <paramref name="imageFormat"/> is not "jpg" or "png".</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving the image data.</exception>
        /// <exception cref="TaskCanceledException">A task was canceled.</exception>
        /// <returns>The binary image data.</returns>
        Task<byte[]> GetImageAsync(IRenderable file, string imageFormat, CancellationToken cancellationToken);
    }
}