// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapDetailsRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
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
        /// Sends this request to the specified <see cref="ServiceClient"/> and retrieves a response whose content is of type <see cref="MapsResult"/>.
        /// </summary>
        /// <param name="handler">The <see cref="ServiceClient"/> that sends the request over a network and returns an instance of type <see cref="ServiceResponse{TContent}"/>.</param>
        /// <returns>Returns an instance of type <see cref="MapsResult"/>.</returns>
        public IServiceResponse<MapsResult> GetResponse(IServiceClient handler)
        {
            return base.GetResponse<MapsResult>(handler);
        }

        /// <summary>
        /// Asynchronously sends this request to the specified <see cref="ServiceClient"/> and retrieves a response whose content is of type <see cref="MapsResult"/>.
        /// </summary>
        /// <param name="handler">The <see cref="ServiceClient"/> that sends the request over a network and returns an instance of type <see cref="ServiceResponse{TContent}"/>.</param>
        /// <returns>Returns an instance of type <see cref="MapsResult"/>.</returns>
        public Task<IServiceResponse<MapsResult>> GetResponseAsync(IServiceClient handler)
        {
            return base.GetResponseAsync<MapsResult>(handler);
        }
    }
}