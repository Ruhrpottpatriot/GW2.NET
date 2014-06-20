// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkinDetailsService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the skin details service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Skins.Details
{
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Common;
    using GW2DotNET.V1.Skins.Details.Contracts;

    /// <summary>Provides the default implementation of the skin details service.</summary>
    public class SkinDetailsService : ISkinDetailsService
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="SkinDetailsService" /> class.</summary>
        public SkinDetailsService()
            : this(new ServiceClient())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="SkinDetailsService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public SkinDetailsService(IServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skinId">The skin identifier.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        public Skin GetSkinDetails(int skinId)
        {
            return this.GetSkinDetails(skinId, CultureInfo.GetCultureInfo("en"));
        }

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skinId">The skin identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        public Skin GetSkinDetails(int skinId, CultureInfo language)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var serviceRequest = new SkinDetailsRequest { SkinId = skinId, Culture = language };
            var result = this.serviceClient.Send<Skin>(serviceRequest);

            // patch missing language information
            result.Language = language;

            return result;
        }

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skinId">The skin identifier.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        public Task<Skin> GetSkinDetailsAsync(int skinId)
        {
            return this.GetSkinDetailsAsync(skinId, CultureInfo.GetCultureInfo("en"), CancellationToken.None);
        }

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skinId">The skin identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        public Task<Skin> GetSkinDetailsAsync(int skinId, CultureInfo language)
        {
            return this.GetSkinDetailsAsync(skinId, language, CancellationToken.None);
        }

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skinId">The skin identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        public Task<Skin> GetSkinDetailsAsync(int skinId, CancellationToken cancellationToken)
        {
            return this.GetSkinDetailsAsync(skinId, CultureInfo.GetCultureInfo("en"), cancellationToken);
        }

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skinId">The skin identifier.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        public Task<Skin> GetSkinDetailsAsync(int skinId, CultureInfo language, CancellationToken cancellationToken)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var serviceRequest = new SkinDetailsRequest { SkinId = skinId, Culture = language };
            var t1 = this.serviceClient.SendAsync<Skin>(serviceRequest, cancellationToken).ContinueWith(
                task =>
                    {
                        var result = task.Result;

                        // patch missing language information
                        result.Language = language;

                        return result;
                    }, 
                cancellationToken);

            return t1;
        }
    }
}