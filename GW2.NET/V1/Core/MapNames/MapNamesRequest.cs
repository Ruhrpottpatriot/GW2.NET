// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapNamesRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Threading.Tasks;
using GW2DotNET.V1.Core.Maps;

namespace GW2DotNET.V1.Core.MapNames
{
    /// <summary>
    /// Represents a request for a list of localized map names.
    /// Only maps with events are listed. If you need a list of all maps, use <see cref="MapsRequest"/> instead.
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names"/> for more information.
    /// </remarks>
    public class MapNamesRequest : ApiRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapNamesRequest"/> class.
        /// </summary>
        /// <param name="continentId">The continent ID.</param>
        /// <param name="floor">The map floor.</param>
        public MapNamesRequest(int continentId, int floor)
            : base(new Uri(Resources.MapNames, UriKind.Relative))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MapNamesRequest"/> class using the specified language.
        /// </summary>
        /// <param name="language">The output language. Supported values are enumerated in <see cref="SupportedLanguages"/>.</param>
        public MapNamesRequest(CultureInfo language)
            : base(new Uri(Resources.MapNames + "?lang={language}", UriKind.Relative))
        {
            this.AddUrlSegment("language", language.TwoLetterISOLanguageName);
        }

        /// <summary>
        /// Sends this request to the specified <see cref="ApiClient"/> and retrieves a response whose content is of type <see cref="MapNamesResponse"/>.
        /// </summary>
        /// <param name="handler">The <see cref="ApiClient"/> that sends the request over a network and returns an instance of type <see cref="ApiResponse{TContent}"/>.</param>
        /// <returns>Returns an instance of type <see cref="MapNamesResponse"/>.</returns>
        public IApiResponse<MapNamesResponse> GetResponse(IApiClient handler)
        {
            return base.GetResponse<MapNamesResponse>(handler);
        }

        /// <summary>
        /// Asynchronously sends this request to the specified <see cref="ApiClient"/> and retrieves a response whose content is of type <see cref="MapNamesResponse"/>.
        /// </summary>
        /// <param name="handler">The <see cref="ApiClient"/> that sends the request over a network and returns an instance of type <see cref="ApiResponse{TContent}"/>.</param>
        /// <returns>Returns an instance of type <see cref="MapNamesResponse"/>.</returns>
        public Task<IApiResponse<MapNamesResponse>> GetResponseAsync(IApiClient handler)
        {
            return base.GetResponseAsync<MapNamesResponse>(handler);
        }
    }
}