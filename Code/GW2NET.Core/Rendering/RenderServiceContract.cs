// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RenderServiceContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The render service contract.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Rendering
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;

    /// <summary>The render service contract.</summary>
    [ContractClassFor(typeof(IRenderService))]
    internal abstract class RenderServiceContract : IRenderService
    {
        /// <summary>Gets an image.</summary>
        /// <param name="file">The file identifier.</param>
        /// <param name="imageFormat">The image file format.</param>
        /// <returns>The binary representation of an image.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:Render_service">wiki</a> for more information.</remarks>
        public byte[] GetImage(IRenderable file, string imageFormat)
        {
            Contract.Requires(file != null);
            Contract.Requires(imageFormat != null);
            Contract.Requires(imageFormat == "jpg" || imageFormat == "png");
            throw new System.NotImplementedException();
        }

        /// <summary>Gets an image.</summary>
        /// <param name="file">The file identifier.</param>
        /// <param name="imageFormat">The image format.</param>
        /// <returns>The binary representation of an image.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:Render_service">wiki</a> for more information.</remarks>
        public Task<byte[]> GetImageAsync(IRenderable file, string imageFormat)
        {
            Contract.Requires(file != null);
            Contract.Requires(imageFormat != null);
            Contract.Requires(imageFormat == "jpg" || imageFormat == "png");
            throw new System.NotImplementedException();
        }

        /// <summary>Gets an image.</summary>
        /// <param name="file">The file identifier.</param>
        /// <param name="imageFormat">The image format.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The binary representation of an image.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:Render_service">wiki</a> for more information.</remarks>
        public Task<byte[]> GetImageAsync(IRenderable file, string imageFormat, CancellationToken cancellationToken)
        {
            Contract.Requires(file != null);
            Contract.Requires(imageFormat != null);
            Contract.Requires(imageFormat == "jpg" || imageFormat == "png");
            throw new System.NotImplementedException();
        }
    }
}