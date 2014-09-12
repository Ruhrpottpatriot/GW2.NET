// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Listing.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents buy or sell offer listing information.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Entities.Commerce
{
    using System.Collections.Generic;
    using System.Globalization;

    using GW2DotNET.Entities.Items;

    /// <summary>Represents buy or sell offer listing information.</summary>
    public class Listing
    {
        /// <summary>Gets or sets the buy offers.</summary>
        public ICollection<Offer> BuyOffers { get; set; }

        /// <summary>Gets or sets the item.</summary>
        public Item Item { get; set; }

        /// <summary>Gets or sets the item identifier.</summary>
        public int ItemId { get; set; }

        /// <summary>Gets or sets the sell offers.</summary>
        public ICollection<Offer> SellOffers { get; set; }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            var item = this.Item;
            if (item != null)
            {
                return item.ToString();
            }

            return this.ItemId.ToString(NumberFormatInfo.InvariantInfo);
        }
    }
}