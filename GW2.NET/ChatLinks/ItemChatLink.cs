// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemChatLink.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a chat link that links to an item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.ChatLinks
{
    using System.Diagnostics.Contracts;

    using GW2DotNET.Common;

    /// <summary>Represents a chat link that links to an item.</summary>
    [Converter(typeof(ItemChatLinkConverter))]
    public class ItemChatLink : ChatLink
    {
        /// <summary>Initializes a new instance of the <see cref="ItemChatLink"/> class.</summary>
        public ItemChatLink()
        {
            this.Quantity = 1;
        }

        /// <summary>Gets or sets the item identifier.</summary>
        public int ItemId { get; set; }

        /// <summary>Gets or sets an item quantity between 1 and 255, both inclusive.</summary>
        public int Quantity { get; set; }

        /// <summary>Gets or sets the secondary upgrade identifier.</summary>
        public int? SecondarySuffixItemId { get; set; }

        /// <summary>Gets or sets the skin identifier.</summary>
        public int? SkinId { get; set; }

        /// <summary>Gets or sets the upgrade identifier.</summary>
        public int? SuffixItemId { get; set; }

        /// <summary>The invariant method for this class.</summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.Quantity >= 1);
            Contract.Invariant(this.Quantity <= 255);
        }
    }
}