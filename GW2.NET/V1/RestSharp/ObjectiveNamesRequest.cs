// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectiveNamesRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using GW2DotNET.V1.Core;
using GW2DotNET.V1.Core.Utilities;
using GW2DotNET.V1.Core.WorldVersusWorldInformation.Catalogs;

namespace GW2DotNET.V1.RestSharp
{
    /// <summary>
    /// Represents a request for a list of the localized World versus World objective names for the specified language.
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names"/> for more information.
    /// </remarks>
    public class ObjectiveNamesRequest : ServiceRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectiveNamesRequest"/> class.
        /// </summary>
        public ObjectiveNamesRequest()
            : base(new Uri(Resources.ObjectiveNames, UriKind.Relative))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectiveNamesRequest"/> class using the specified language.
        /// </summary>
        /// <param name="language">The output language. Supported values are enumerated in <see cref="SupportedLanguages"/>.</param>
        public ObjectiveNamesRequest(CultureInfo language)
            : base(new Uri(Resources.ObjectiveNames + "?lang={language}", UriKind.Relative))
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            this.AddUrlSegment("language", language.TwoLetterISOLanguageName);
        }

        /// <summary>
        /// Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public IServiceResponse<ObjectiveNameCollection> GetResponse(IServiceClient serviceClient)
        {
            return base.GetResponse<ObjectiveNameCollection>(serviceClient);
        }

        /// <summary>
        /// Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<ObjectiveNameCollection>> GetResponseAsync(IServiceClient serviceClient)
        {
            return base.GetResponseAsync<ObjectiveNameCollection>(serviceClient);
        }

        /// <summary>
        /// Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<ObjectiveNameCollection>> GetResponseAsync(IServiceClient serviceClient, CancellationToken cancellationToken)
        {
            return base.GetResponseAsync<ObjectiveNameCollection>(serviceClient, cancellationToken);
        }
    }
}