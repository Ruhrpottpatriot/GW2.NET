// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorldNamesRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Threading.Tasks;
using GW2DotNET.V1.Core;
using GW2DotNET.V1.Core.Utilities;
using GW2DotNET.V1.Core.WorldsInformation.Names;

namespace GW2DotNET.V1.RestSharp
{
    /// <summary>
    /// Represents a request for a list of the localized WorldName names for the specified language.
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names"/> for more information.
    /// </remarks>
    public class WorldNamesRequest : ServiceRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorldNamesRequest"/> class.
        /// </summary>
        public WorldNamesRequest()
            : base(new Uri(Resources.ObjectiveNames, UriKind.Relative))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WorldNamesRequest"/> class using the specified language.
        /// </summary>
        /// <param name="language">The output language. Supported values are enumerated in <see cref="SupportedLanguages"/>.</param>
        public WorldNamesRequest(CultureInfo language)
            : base(new Uri(Resources.ObjectiveNames + "?lang={language}", UriKind.Relative))
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            this.AddUrlSegment("language", language.TwoLetterISOLanguageName);
        }

        /// <summary>
        /// Sends this request to the specified <see cref="ServiceClient"/> and retrieves a response whose content is of type <see cref="WorldNames"/>.
        /// </summary>
        /// <param name="handler">The <see cref="ServiceClient"/> that sends the request over a network and returns an instance of type <see cref="ServiceResponse{TContent}"/>.</param>
        /// <returns>Returns an instance of type <see cref="WorldNames"/>.</returns>
        public IServiceResponse<WorldNames> GetResponse(IServiceClient handler)
        {
            return base.GetResponse<WorldNames>(handler);
        }

        /// <summary>
        /// Asynchronously sends this request to the specified <see cref="ServiceClient"/> and retrieves a response whose content is of type <see cref="WorldNames"/>.
        /// </summary>
        /// <param name="handler">The <see cref="ServiceClient"/> that sends the request over a network and returns an instance of type <see cref="ServiceResponse{TContent}"/>.</param>
        /// <returns>Returns an instance of type <see cref="WorldNames"/>.</returns>
        public Task<IServiceResponse<WorldNames>> GetResponseAsync(IServiceClient handler)
        {
            return base.GetResponseAsync<WorldNames>(handler);
        }
    }
}