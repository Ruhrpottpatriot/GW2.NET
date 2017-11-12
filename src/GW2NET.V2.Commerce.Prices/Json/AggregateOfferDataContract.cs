// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AggregateOfferDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the AggregateOfferDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Commerce.Prices
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:2/commerce/prices")]
    internal sealed class AggregateOfferDataContract
    {
        #region Properties

        [DataMember(Name = "quantity", Order = 2)]
        internal int Quantity { get; set; }

        [DataMember(Name = "unit_price", Order = 1)]
        internal int UnitPrice { get; set; }

        #endregion
    }
}