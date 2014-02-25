// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapFloorRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Threading.Tasks;
using GW2DotNET.V1.Core.MapsInformation.Floors;

namespace GW2DotNET.V1.Core.MapsInformation
{
    /// <summary>
    /// Represents a request for details regarding a map floor, used to populate a world map.
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor"/> for more information.
    /// </remarks>
    public class MapFloorRequest : ApiRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapFloorRequest"/> class.
        /// </summary>
        /// <param name="continentId">The continent ID.</param>
        /// <param name="floor">The map floor.</param>
        public MapFloorRequest(int continentId, int floor)
            : base(new Uri(Resources.MapFloor + "?continent_id={continent_id}&floor={floor}", UriKind.Relative))
        {
            this.AddUrlSegment("continent_id", continentId.ToString(CultureInfo.InvariantCulture));
            this.AddUrlSegment("floor", floor.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MapFloorRequest"/> class using the specified language.
        /// </summary>
        /// <param name="continentId">The continent ID.</param>
        /// <param name="floor">The map floor.</param>
        /// <param name="language">The output language. Supported values are enumerated in <see cref="SupportedLanguages"/>.</param>
        public MapFloorRequest(int continentId, int floor, CultureInfo language)
            : base(new Uri(Resources.MapFloor + "?continent_id={continent_id}&floor={floor}&lang={language}", UriKind.Relative))
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            this.AddUrlSegment("continent_id", continentId.ToString(CultureInfo.InvariantCulture));
            this.AddUrlSegment("floor", floor.ToString(CultureInfo.InvariantCulture));
            this.AddUrlSegment("language", language.TwoLetterISOLanguageName);
        }

        /// <summary>
        /// Sends this request to the specified <see cref="ApiClient"/> and retrieves a response whose content is of type <see cref="MapFloor"/>.
        /// </summary>
        /// <param name="handler">The <see cref="ApiClient"/> that sends the request over a network and returns an instance of type <see cref="ApiResponse{TContent}"/>.</param>
        /// <returns>Returns an instance of type <see cref="MapFloor"/>.</returns>
        public IApiResponse<MapFloor> GetResponse(IApiClient handler)
        {
            return base.GetResponse<MapFloor>(handler);
        }

        /// <summary>
        /// Asynchronously sends this request to the specified <see cref="ApiClient"/> and retrieves a response whose content is of type <see cref="MapFloor"/>.
        /// </summary>
        /// <param name="handler">The <see cref="ApiClient"/> that sends the request over a network and returns an instance of type <see cref="ApiResponse{TContent}"/>.</param>
        /// <returns>Returns an instance of type <see cref="MapFloor"/>.</returns>
        public Task<IApiResponse<MapFloor>> GetResponseAsync(IApiClient handler)
        {
            return base.GetResponseAsync<MapFloor>(handler);
        }
    }
}