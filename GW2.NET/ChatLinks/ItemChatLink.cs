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
    using System.ComponentModel;

    using GW2DotNET.Utilities;

    /// <summary>Represents a chat link that links to an item.</summary>
    [TypeConverter(typeof(ItemChatLinkConverter))]
    public class ItemChatLink : ChatLink
    {
        /// <summary>The quantity.</summary>
        private int quantity;

        /// <summary>Gets or sets the item identifier.</summary>
        public int ItemId { get; set; }

        /// <summary>Gets or sets the quantity.</summary>
        public int Quantity
        {
            get
            {
                return this.quantity;
            }

            set
            {
                Preconditions.EnsureInRange(value, 1, byte.MaxValue);
                this.quantity = value;
            }
        }

        /// <summary>Gets or sets the secondary upgrade identifier.</summary>
        public int? SecondarySuffixItemId { get; set; }

        /// <summary>Gets or sets the skin identifier.</summary>
        public int? SkinId { get; set; }

        /// <summary>Gets or sets the upgrade identifier.</summary>
        public int? SuffixItemId { get; set; }
    }
}