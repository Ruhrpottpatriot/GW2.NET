// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISkinDetailsService.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for the skin details service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Skins.Details
{
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.V1.Skins.Details.Contracts;

    /// <summary>Provides the interface for the skin details service.</summary>
    public interface ISkinDetailsService
    {
        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skinId">The skin identifier.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        Skin GetSkinDetails(int skinId);

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skinId">The skin identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        Skin GetSkinDetails(int skinId, CultureInfo language);

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skinId">The skin identifier.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        Task<Skin> GetSkinDetailsAsync(int skinId);

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skinId">The skin identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        Task<Skin> GetSkinDetailsAsync(int skinId, CultureInfo language);

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skinId">The skin identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        Task<Skin> GetSkinDetailsAsync(int skinId, CancellationToken cancellationToken);

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skinId">The skin identifier.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        Task<Skin> GetSkinDetailsAsync(int skinId, CultureInfo language, CancellationToken cancellationToken);
    }
}