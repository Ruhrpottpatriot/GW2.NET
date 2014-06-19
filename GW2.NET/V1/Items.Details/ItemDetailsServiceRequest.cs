// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemDetailsServiceRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for details regarding a specific item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details
{
    using GW2DotNET.Extensions;
    using GW2DotNET.V1.Common;

    /// <summary>Represents a request for details regarding a specific item.</summary>
    public class ItemDetailsServiceRequest : ServiceRequest
    {
        /// <summary>Infrastructure. Stores a parameter.</summary>
        private int? itemId;

        /// <summary>Initializes a new instance of the <see cref="ItemDetailsServiceRequest" /> class.</summary>
        public ItemDetailsServiceRequest()
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
                this.FormData["item_id"] = (this.itemId = value).ToStringInvariant();
            }
        }
    }
}