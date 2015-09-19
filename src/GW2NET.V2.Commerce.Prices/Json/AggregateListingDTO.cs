// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AggregateListingDTO.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the AggregateListingDTO type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Commerce.Prices.Json
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:2/commerce/prices")]
    public sealed class AggregateListingDTO
    {
        #region Properties

        [DataMember(Name = "buys", Order = 1)]
        public AggregateOfferDTO BuyOffers { get; set; }

        [DataMember(Name = "id", Order = 0)]
        public int Id { get; set; }

        [DataMember(Name = "sells", Order = 2)]
        public AggregateOfferDTO SellOffers { get; set; }

        #endregion
    }
}