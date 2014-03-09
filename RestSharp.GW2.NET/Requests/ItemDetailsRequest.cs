// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemDetailsRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for details regarding a specific item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RestSharp.GW2DotNET.Requests
{
    using System.Threading;
    using System.Threading.Tasks;

    using global::GW2DotNET.V1.Core;

    using global::GW2DotNET.V1.Core.ItemsInformation.Details;

    /// <summary>
    ///     Represents a request for details regarding a specific item.
    /// </summary>
    /// <remarks>
    ///     See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details" /> for more information.
    /// </remarks>
    public class ItemDetailsRequest : ServiceRequest
    {
        #region Fields

        /// <summary>Infrastructure. Stores a parameter.</summary>
        private readonly Parameter itemIdParameter;

        /// <summary>The item ID.</summary>
        private int itemId;

        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="ItemDetailsRequest"/> class.</summary>
        public ItemDetailsRequest()
            : base(Resources.ItemDetails)
        {
            this.AddParameter(this.itemIdParameter = new Parameter { Name = "item_id", Value = default(int), Type = ParameterType.GetOrPost });
        }

        #endregion

        #region Public Properties

        /// <summary>Gets or sets the item ID.</summary>
        public int ItemId
        {
            get
            {
                return this.itemId;
            }

            set
            {
                this.itemIdParameter.Value = this.itemId = value;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>Sends the current request and returns a response.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public IServiceResponse<Item> GetResponse(IServiceClient serviceClient)
        {
            return this.GetResponse<Item>(serviceClient);
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<Item>> GetResponseAsync(IServiceClient serviceClient)
        {
            return this.GetResponseAsync<Item>(serviceClient);
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<Item>> GetResponseAsync(IServiceClient serviceClient, CancellationToken cancellationToken)
        {
            return this.GetResponseAsync<Item>(serviceClient, cancellationToken);
        }

        #endregion
    }
}