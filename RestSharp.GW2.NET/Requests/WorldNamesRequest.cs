// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorldNamesRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for a list of the localized WorldName names for the specified language.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RestSharp.GW2DotNET.Requests
{
    using System.Threading;
    using System.Threading.Tasks;

    using global::GW2DotNET.V1.Core;

    using global::GW2DotNET.V1.Core.WorldsInformation.Names;

    /// <summary>
    ///     Represents a request for a list of the localized WorldName names for the specified language.
    /// </summary>
    /// <remarks>
    ///     See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names" /> for more information.
    /// </remarks>
    public class WorldNamesRequest : ServiceRequest
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="WorldNamesRequest" /> class.
        /// </summary>
        public WorldNamesRequest()
            : base(Resources.WorldNames)
        {
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>Sends the current request and returns a response.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public IServiceResponse<WorldNameCollection> GetResponse(IServiceClient serviceClient)
        {
            return this.GetResponse<WorldNameCollection>(serviceClient);
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<WorldNameCollection>> GetResponseAsync(IServiceClient serviceClient)
        {
            return this.GetResponseAsync<WorldNameCollection>(serviceClient);
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<WorldNameCollection>> GetResponseAsync(IServiceClient serviceClient, CancellationToken cancellationToken)
        {
            return this.GetResponseAsync<WorldNameCollection>(serviceClient, cancellationToken);
        }

        #endregion
    }
}