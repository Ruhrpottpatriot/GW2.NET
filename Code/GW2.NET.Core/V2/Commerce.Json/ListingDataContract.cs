// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ListingContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The listing contract.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V2.Commerce.Json
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>The listing contract.</summary>
    [DataContract]
    public sealed class ListingDataContract
    {
        /// <summary>Gets or sets the buy offers.</summary>
        [DataMember(Name = "buys", Order = 1)]
        public ICollection<OfferDataContract> BuyOffers { get; set; }

        /// <summary>Gets or sets the id.</summary>
        [DataMember(Name = "id", Order = 0)]
        public int Id { get; set; }

        /// <summary>Gets or sets the sell offers.</summary>
        [DataMember(Name = "sells", Order = 2)]
        public ICollection<OfferDataContract> SellOffers { get; set; }
    }
}