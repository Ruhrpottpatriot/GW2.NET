// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Listing.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents buy or sell offer listing information.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Commerce
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;

    using GW2NET.Common;
    using GW2NET.Items;

    /// <summary>Represents buy or sell offer listing information.</summary>
    public class Listing : ITimeSensitive
    {
        private static readonly Offer[] EmptyOffers = new Offer[0];

        private ICollection<Offer> buyOffers = EmptyOffers;

        private ICollection<Offer> sellOffers = EmptyOffers;

        /// <summary>Gets or sets the buy offers.</summary>
        public virtual ICollection<Offer> BuyOffers
        {
            get
            {
                Debug.Assert(this.buyOffers != null, "this.buyOffers != null");
                return this.buyOffers;
            }
            set
            {
                this.buyOffers = value ?? EmptyOffers;
            }
        }

        /// <summary>Gets or sets the item. This is a navigation property. Use the value of <see cref="ItemId"/> to obtain a reference.</summary>
        public virtual Item Item { get; set; }

        /// <summary>Gets or sets the item identifier.</summary>
        public virtual int ItemId { get; set; }

        /// <summary>Gets or sets the sell offers.</summary>
        public virtual ICollection<Offer> SellOffers
        {
            get
            {
                Debug.Assert(this.sellOffers != null, "this.sellOffers != null");
                return this.sellOffers;
            }
            set
            {
                this.sellOffers = value ?? EmptyOffers;
            }
        }

        /// <summary>Gets or sets the timestamp.</summary>
        public virtual DateTimeOffset Timestamp { get; set; }

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
