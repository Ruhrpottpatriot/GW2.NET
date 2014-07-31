// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRenderService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for the render service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Rendering
{
    using System.Diagnostics.Contracts;
    using System.Drawing;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;

    /// <summary>Provides the interface for the render service.</summary>
    [ContractClass(typeof(RenderServiceContract))]
    public interface IRenderService
    {
        /// <summary>Gets an image.</summary>
        /// <param name="file">The file.</param>
        /// <param name="imageFormat">The image Format.</param>
        /// <returns>An instance of <see cref="Image"/>.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:Render_service">wiki</a> for more information.</remarks>
        Image GetImage(IRenderable file, string imageFormat);

        /// <summary>Gets an image.</summary>
        /// <param name="file">The file.</param>
        /// <param name="imageFormat">The image format.</param>
        /// <returns>An instance of <see cref="Image"/>.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:Render_service">wiki</a> for more information.</remarks>
        Task<Image> GetImageAsync(IRenderable file, string imageFormat);

        /// <summary>Gets an image.</summary>
        /// <param name="file">The file.</param>
        /// <param name="imageFormat">The image format.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>An instance of <see cref="Image"/>.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:Render_service">wiki</a> for more information.</remarks>
        Task<Image> GetImageAsync(IRenderable file, string imageFormat, CancellationToken cancellationToken);
    }
}