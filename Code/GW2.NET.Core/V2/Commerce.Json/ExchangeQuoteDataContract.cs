// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExchangeQuoteDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The exchange rate data contract.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V2.Commerce.Json
{
    using System.Runtime.Serialization;

    /// <summary>The exchange quote data contract.</summary>
    [DataContract]
    public class ExchangeQuoteDataContract
    {
        /// <summary>Gets or sets the coins per gem.</summary>
        [DataMember(Order = 0, Name = "coins_per_gem")]
        public int CoinsPerGem { get; set; }

        /// <summary>Gets or sets the quantity.</summary>
        [DataMember(Order = 1, Name = "quantity")]
        public long Quantity { get; set; }
    }
}