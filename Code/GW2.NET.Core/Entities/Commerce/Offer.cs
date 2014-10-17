// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Offer.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a buy or sell offer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Entities.Commerce
{
    using System.Globalization;

    /// <summary>Represents buy or sell offer information.</summary>
    public sealed class Offer
    {
        /// <summary>Gets or sets the number of offers for this <see cref="UnitPrice"/>.</summary>
        public int Listings { get; set; }

        /// <summary>Gets or sets the total number of items listed.</summary>
        public int Quantity { get; set; }

        /// <summary>Gets or sets the price per unit.</summary>
        public int UnitPrice { get; set; }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return this.UnitPrice.ToString(NumberFormatInfo.InvariantInfo);
        }
    }
}