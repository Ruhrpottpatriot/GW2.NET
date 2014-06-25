// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Bag.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a bag.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.Bags
{
    using System.Runtime.Serialization;

    using GW2DotNET.Common;

    /// <summary>Represents a bag.</summary>
    [TypeDiscriminator(Value = "Bag", BaseType = typeof(Item))]
    public class Bag : Item
    {
        /// <summary>Gets or sets a value indicating whether this is an invisible bag.</summary>
        [DataMember(Name = "no_sell_or_sort")]
        public virtual bool NoSellOrSort { get; set; }

        /// <summary>Gets or sets the bag's capacity.</summary>
        [DataMember(Name = "size")]
        public virtual int Size { get; set; }
    }
}