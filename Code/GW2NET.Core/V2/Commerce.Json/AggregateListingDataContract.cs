// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AggregateListingDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The aggregate listing data contract.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Commerce.Json
{
    using System.Runtime.Serialization;

    /// <summary>The aggregate listing data contract.</summary>
    [DataContract]
    internal sealed class AggregateListingDataContract
    {
        /// <summary>Gets or sets the buy offers.</summary>
        [DataMember(Name = "buys", Order = 1)]
        public AggregateOfferDataContract BuyOffers { get; set; }

        /// <summary>Gets or sets the id.</summary>
        [DataMember(Name = "id", Order = 0)]
        public int Id { get; set; }

        /// <summary>Gets or sets the sell offers.</summary>
        [DataMember(Name = "sells", Order = 2)]
        public AggregateOfferDataContract SellOffers { get; set; }
    }
}