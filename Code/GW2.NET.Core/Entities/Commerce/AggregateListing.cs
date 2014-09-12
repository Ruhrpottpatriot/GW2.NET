using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GW2DotNET.Entities.Commerce
{
    using System.Globalization;

    using GW2DotNET.Entities.Items;

    /// <summary>TODO The aggregate listing.</summary>
    public class AggregateListing
    {
        /// <summary>Gets or sets the buy offers.</summary>
        public ICollection<AggregateOffer> BuyOffers { get; set; }

        /// <summary>Gets or sets the item.</summary>
        public Item Item { get; set; }

        /// <summary>Gets or sets the item identifier.</summary>
        public int ItemId { get; set; }

        /// <summary>Gets or sets the sell offers.</summary>
        public ICollection<AggregateOffer> SellOffers { get; set; }

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
