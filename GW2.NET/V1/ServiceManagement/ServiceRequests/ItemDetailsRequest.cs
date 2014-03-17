// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemDetailsRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for details regarding a specific item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.ServiceManagement.ServiceRequests
{
    using GW2DotNET.Extensions;

    /// <summary>Represents a request for details regarding a specific item.</summary>
    public class ItemDetailsRequest : ServiceRequest
    {
        /// <summary>Infrastructure. Stores a parameter.</summary>
        private int? itemId;

        /// <summary>Initializes a new instance of the <see cref="ItemDetailsRequest"/> class.</summary>
        public ItemDetailsRequest()
            : base(Services.ItemDetails)
        {
        }

        /// <summary>Gets or sets the item ID.</summary>
        public int? ItemId
        {
            get
            {
                return this.itemId;
            }

            set
            {
                this.Query["item_id"] = (this.itemId = value).ToStringInvariant();
            }
        }
    }
}