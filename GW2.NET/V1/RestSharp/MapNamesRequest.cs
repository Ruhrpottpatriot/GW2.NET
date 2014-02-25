// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapNamesRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Threading.Tasks;
using GW2DotNET.V1.Core;
using GW2DotNET.V1.Core.MapsInformation.Names;
using GW2DotNET.V1.Core.Utilities;

namespace GW2DotNET.V1.RestSharp
{
    /// <summary>
    /// Represents a request for a list of localized map names.
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names"/> for more information.
    /// </remarks>
    public class MapNamesRequest : ServiceRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapNamesRequest"/> class.
        /// </summary>
        public MapNamesRequest()
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
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            this.AddUrlSegment("language", language.TwoLetterISOLanguageName);
        }

        /// <summary>
        /// Sends this request to the specified <see cref="ServiceClient"/> and retrieves a response whose content is of type <see cref="MapNames"/>.
        /// </summary>
        /// <param name="handler">The <see cref="ServiceClient"/> that sends the request over a network and returns an instance of type <see cref="ServiceResponse{TContent}"/>.</param>
        /// <returns>Returns an instance of type <see cref="MapNames"/>.</returns>
        public IServiceResponse<MapNames> GetResponse(IServiceClient handler)
        {
            return base.GetResponse<MapNames>(handler);
        }

        /// <summary>
        /// Asynchronously sends this request to the specified <see cref="ServiceClient"/> and retrieves a response whose content is of type <see cref="MapNames"/>.
        /// </summary>
        /// <param name="handler">The <see cref="ServiceClient"/> that sends the request over a network and returns an instance of type <see cref="ServiceResponse{TContent}"/>.</param>
        /// <returns>Returns an instance of type <see cref="MapNames"/>.</returns>
        public Task<IServiceResponse<MapNames>> GetResponseAsync(IServiceClient handler)
        {
            return base.GetResponseAsync<MapNames>(handler);
        }
    }
}