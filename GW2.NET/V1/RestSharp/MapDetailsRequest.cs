// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapDetailsRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using GW2DotNET.V1.Core;
using GW2DotNET.V1.Core.MapsInformation.Details;
using GW2DotNET.V1.Core.Utilities;

namespace GW2DotNET.V1.RestSharp
{
    /// <summary>
    /// Represents a request for details regarding (a) map(s) in the game.
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/maps"/> for more information.
    /// </remarks>
    public class MapDetailsRequest : ServiceRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapDetailsRequest"/> class.
        /// </summary>
        public MapDetailsRequest()
            : base(new Uri(Resources.Maps, UriKind.Relative))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MapDetailsRequest"/> class using the specified language.
        /// </summary>
        /// <param name="language">The output language. Supported values are enumerated in <see cref="SupportedLanguages"/>.</param>
        public MapDetailsRequest(CultureInfo language)
            : base(new Uri(Resources.Maps + "?lang={language}", UriKind.Relative))
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            this.AddUrlSegment("language", language.TwoLetterISOLanguageName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MapDetailsRequest"/> class using the specified map ID.
        /// </summary>
        /// <param name="mapId">The map ID.</param>
        public MapDetailsRequest(int mapId)
            : base(new Uri(Resources.Maps + "?map_id={map_id}", UriKind.Relative))
        {
            this.AddUrlSegment("map_id", mapId.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MapDetailsRequest"/> class using the specified map ID and language.
        /// </summary>
        /// <param name="mapId">The map ID.</param>
        /// <param name="language">The output language. Supported values are enumerated in <see cref="SupportedLanguages"/>.</param>
        public MapDetailsRequest(int mapId, CultureInfo language)
            : base(new Uri(Resources.Maps + "?map_id={map_id}&lang={language}", UriKind.Relative))
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            this.AddUrlSegment("map_id", mapId.ToString(CultureInfo.InvariantCulture));
            this.AddUrlSegment("language", language.TwoLetterISOLanguageName);
        }

        /// <summary>
        /// Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public IServiceResponse<MapsResult> GetResponse(IServiceClient serviceClient)
        {
            return base.GetResponse<MapsResult>(serviceClient);
        }

        /// <summary>
        /// Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<MapsResult>> GetResponseAsync(IServiceClient serviceClient)
        {
            return base.GetResponseAsync<MapsResult>(serviceClient);
        }

        /// <summary>
        /// Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<MapsResult>> GetResponseAsync(IServiceClient serviceClient, CancellationToken cancellationToken)
        {
            return base.GetResponseAsync<MapsResult>(serviceClient, cancellationToken);
        }
    }
}