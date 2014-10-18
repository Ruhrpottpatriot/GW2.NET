// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRenderService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for the render service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Rendering
{
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;

    /// <summary>Provides the interface for the render service.</summary>
    [ContractClass(typeof(ContractClassForIRenderService))]
    public interface IRenderService
    {
        /// <summary>Gets an image.</summary>
        /// <param name="file">The file identifier.</param>
        /// <param name="imageFormat">The image file format.</param>
        /// <returns>The binary representation of an image.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:Render_service">wiki</a> for more information.</remarks>
        byte[] GetImage(IRenderable file, string imageFormat);

        /// <summary>Gets an image.</summary>
        /// <param name="file">The file identifier.</param>
        /// <param name="imageFormat">The image format.</param>
        /// <returns>The binary representation of an image.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:Render_service">wiki</a> for more information.</remarks>
        Task<byte[]> GetImageAsync(IRenderable file, string imageFormat);

        /// <summary>Gets an image.</summary>
        /// <param name="file">The file identifier.</param>
        /// <param name="imageFormat">The image format.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The binary representation of an image.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:Render_service">wiki</a> for more information.</remarks>
        Task<byte[]> GetImageAsync(IRenderable file, string imageFormat, CancellationToken cancellationToken);
    }
}