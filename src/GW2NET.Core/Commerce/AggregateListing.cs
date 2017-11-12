// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AggregateListing.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents aggregate buy or sell offer listing information.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Commerce
{
    using System;
    using System.Globalization;

    using GW2NET.Common;
    using GW2NET.Items;

    /// <summary>Represents aggregate buy or sell offer listing information.</summary>
    public class AggregateListing : ITimeSensitive
    {
        /// <summary>Gets or sets the buy offers.</summary>
        public AggregateOffer BuyOffers { get; set; }

        /// <summary>Gets or sets the item. This is a navigation property. Use the value of <see cref="ItemId"/> to obtain a reference.</summary>
        public Item Item { get; set; }

        /// <summary>Gets or sets the item identifier.</summary>
        public int ItemId { get; set; }

        /// <summary>Gets or sets a value indicating whether this item can be acquired in the free version of the game.</summary>
        public bool Whitelisted { get; set; }

        /// <summary>Gets or sets the sell offers.</summary>
        public AggregateOffer SellOffers { get; set; }

        /// <summary>Gets or sets the timestamp.</summary>
        public DateTimeOffset Timestamp { get; set; }

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