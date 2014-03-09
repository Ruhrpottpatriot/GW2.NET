// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapNamesRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using GW2DotNET.V1.Core;
using GW2DotNET.V1.Core.MapsInformation.Names;

namespace RestSharp.GW2DotNET.Requests
{
    /// <summary>
    ///     Represents a request for a list of localized map names.
    /// </summary>
    /// <remarks>
    ///     See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names" /> for more information.
    /// </remarks>
    public class MapNamesRequest : ServiceRequest
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MapNamesRequest" /> class.
        /// </summary>
        public MapNamesRequest()
            : base(Resources.MapNames)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MapNamesRequest" /> class.
        /// </summary>
        /// <param name="languageInfo">The output language.</param>
        public MapNamesRequest(CultureInfo languageInfo)
            : base(Resources.MapNames, languageInfo)
        {
        }

        /// <summary>
        ///     Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public IServiceResponse<MapNameCollection> GetResponse(IServiceClient serviceClient)
        {
            return base.GetResponse<MapNameCollection>(serviceClient);
        }

        /// <summary>
        ///     Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<MapNameCollection>> GetResponseAsync(IServiceClient serviceClient)
        {
            return base.GetResponseAsync<MapNameCollection>(serviceClient);
        }

        /// <summary>
        ///     Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken" /> that provides cancellation support.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<MapNameCollection>> GetResponseAsync(IServiceClient serviceClient, CancellationToken cancellationToken)
        {
            return base.GetResponseAsync<MapNameCollection>(serviceClient, cancellationToken);
        }
    }
}