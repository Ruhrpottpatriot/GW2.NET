// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipesRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for a list of all discovered recipes.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RestSharp.GW2DotNET.Requests
{
    using System.Threading;
    using System.Threading.Tasks;

    using global::GW2DotNET.V1.Core;

    using global::GW2DotNET.V1.Core.ItemsInformation.Catalogs;

    /// <summary>
    ///     Represents a request for a list of all discovered recipes.
    /// </summary>
    /// <remarks>
    ///     See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes" /> for more information.
    /// </remarks>
    public class RecipesRequest : ServiceRequest
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="RecipesRequest" /> class.
        /// </summary>
        public RecipesRequest()
            : base(Resources.Recipes)
        {
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>Sends the current request and returns a response.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public IServiceResponse<RecipesResult> GetResponse(IServiceClient serviceClient)
        {
            return this.GetResponse<RecipesResult>(serviceClient);
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<RecipesResult>> GetResponseAsync(IServiceClient serviceClient)
        {
            return this.GetResponseAsync<RecipesResult>(serviceClient);
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<RecipesResult>> GetResponseAsync(IServiceClient serviceClient, CancellationToken cancellationToken)
        {
            return this.GetResponseAsync<RecipesResult>(serviceClient, cancellationToken);
        }

        #endregion
    }
}