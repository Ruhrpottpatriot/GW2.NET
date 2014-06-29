// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkinService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the skins service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Skins
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Common.Serializers;
    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Skins.Contracts;

    /// <summary>Provides the default implementation of the skins service.</summary>
    public class SkinService : ISkinService
    {
        /// <summary>Infrastructure. Holds a reference to the serializer settings.</summary>
        private static readonly SkinSerializerSettings Settings = new SkinSerializerSettings();

        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="SkinService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public SkinService(IServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skin">The skin identifier.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        public Skin GetSkinDetails(Skin skin)
        {
            return this.GetSkinDetails(skin, CultureInfo.GetCultureInfo("en"));
        }

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skin">The skin identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        public Skin GetSkinDetails(Skin skin, CultureInfo language)
        {
            Preconditions.EnsureNotNull(paramName: "skin", value: skin);
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new SkinDetailsRequest { SkinId = skin.SkinId, Culture = language };
            var result = this.serviceClient.Send(request, new JsonSerializer<Skin>(Settings));

            // Patch missing language information
            result.Language = language.TwoLetterISOLanguageName;

            return result;
        }

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skin">The skin identifier.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        public Task<Skin> GetSkinDetailsAsync(Skin skin)
        {
            return this.GetSkinDetailsAsync(skin, CultureInfo.GetCultureInfo("en"), CancellationToken.None);
        }

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skin">The skin identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        public Task<Skin> GetSkinDetailsAsync(Skin skin, CultureInfo language)
        {
            return this.GetSkinDetailsAsync(skin, language, CancellationToken.None);
        }

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skin">The skin identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        public Task<Skin> GetSkinDetailsAsync(Skin skin, CancellationToken cancellationToken)
        {
            return this.GetSkinDetailsAsync(skin, CultureInfo.GetCultureInfo("en"), cancellationToken);
        }

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skin">The skin identifier.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        public Task<Skin> GetSkinDetailsAsync(Skin skin, CultureInfo language, CancellationToken cancellationToken)
        {
            Preconditions.EnsureNotNull(paramName: "skin", value: skin);
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new SkinDetailsRequest { SkinId = skin.SkinId, Culture = language };
            var t1 = this.serviceClient.SendAsync(request, new JsonSerializer<Skin>(Settings), cancellationToken).ContinueWith(
                task =>
                    {
                        var result = task.Result;

                        // Patch missing language information
                        result.Language = language.TwoLetterISOLanguageName;

                        return result;
                    }, 
                cancellationToken);

            return t1;
        }

        /// <summary>Gets a collection of skin identifiers.</summary>
        /// <returns>A collection of skin identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skins">wiki</a> for more information.</remarks>
        public IEnumerable<Skin> GetSkins()
        {
            var request = new SkinRequest();
            var result = this.serviceClient.Send(request, new JsonSerializer<SkinCollectionResult>());

            return result.Skins;
        }

        /// <summary>Gets a collection of skin identifiers.</summary>
        /// <returns>A collection of skin identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skins">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Skin>> GetSkinsAsync()
        {
            return this.GetSkinsAsync(CancellationToken.None);
        }

        /// <summary>Gets a collection of skin identifiers.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of skin identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skins">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Skin>> GetSkinsAsync(CancellationToken cancellationToken)
        {
            var request = new SkinRequest();
            var t1 = this.serviceClient.SendAsync(request, new JsonSerializer<SkinCollectionResult>(), cancellationToken);
            var t2 = t1.ContinueWith<IEnumerable<Skin>>(task => task.Result.Skins, cancellationToken);

            return t2;
        }
    }
}