// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRenderServiceCache.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for a render service cache.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Rendering
{
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.V1.Common.Caching;
    using GW2DotNET.V1.Rendering.Types;

    /// <summary>Provides the interface for a render service cache.</summary>
    public interface IRenderServiceCache : IRenderService
    {
        /// <summary>Gets an image.</summary>
        /// <param name="file">The file.</param>
        /// <param name="imageFormat">The image Format.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>The <see cref="Image"/>.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:Render_service">wiki</a> for more information.</remarks>
        Image GetImage(IRenderable file, ImageFormat imageFormat, bool allowCache);

        /// <summary>Gets an image.</summary>
        /// <param name="file">The file.</param>
        /// <param name="imageFormat">The image format.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>The <see cref="Image"/>.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:Render_service">wiki</a> for more information.</remarks>
        Task<Image> GetImageAsync(IRenderable file, ImageFormat imageFormat, bool allowCache);

        /// <summary>Gets an image.</summary>
        /// <param name="file">The file.</param>
        /// <param name="imageFormat">The image format.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>The <see cref="Image"/>.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:Render_service">wiki</a> for more information.</remarks>
        Task<Image> GetImageAsync(IRenderable file, ImageFormat imageFormat, CancellationToken cancellationToken, bool allowCache);

        /// <summary>Sets an image.</summary>
        /// <param name="file">The file.</param>
        /// <param name="image">The image.</param>
        void SetImage(IRenderable file, Image image);

        /// <summary>Sets an image.</summary>
        /// <param name="file">The file.</param>
        /// <param name="image">The image.</param>
        /// <param name="parameters">The eviction and expiration details.</param>
        void SetImage(IRenderable file, Image image, CacheItemParameters parameters);
    }
}