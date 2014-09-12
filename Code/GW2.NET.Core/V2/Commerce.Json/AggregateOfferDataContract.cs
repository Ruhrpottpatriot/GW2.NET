// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AggregateOfferDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The aggregate offer data contract.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V2.Commerce.Json
{
    using System.Runtime.Serialization;

    /// <summary>The aggregate offer data contract.</summary>
    [DataContract]
    public sealed class AggregateOfferDataContract
    {
        /// <summary>Gets or sets the quantity.</summary>
        [DataMember(Name = "quantity", Order = 2)]
        public int Quantity { get; set; }

        /// <summary>Gets or sets the unit price.</summary>
        [DataMember(Name = "unit_price", Order = 1)]
        public int UnitPrice { get; set; }
    }
}