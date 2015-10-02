// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemChatLink.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a chat link that links to an item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.ChatLinks
{
    using System;
    using System.Diagnostics;

    /// <summary>Represents a chat link that links to an item.</summary>
    public class ItemChatLink : ChatLink
    {
        private int quantity = 1;

        /// <summary>Gets or sets the item identifier.</summary>
        public int ItemId { get; set; }

        /// <summary>Gets or sets an item quantity between 1 and 255, both inclusive.</summary>
        public int Quantity
        {
            get
            {
                Debug.Assert(this.quantity > 0, "this.quantity > 0");
                Debug.Assert(this.quantity < 256, "this.quantity < 256");
                return this.quantity;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("value", value, "Precondition: value > 0");
                }

                if (value > 255)
                {
                    throw new ArgumentOutOfRangeException("value", value, "Precondition: value < 256");
                }

                this.quantity = value;
            }
        }

        /// <summary>Gets or sets the secondary upgrade identifier.</summary>
        public int? SecondarySuffixItemId { get; set; }

        /// <summary>Gets or sets the skin identifier.</summary>
        public int? SkinId { get; set; }

        /// <summary>Gets or sets the upgrade identifier.</summary>
        public int? SuffixItemId { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            var stream = new ItemChatLinkConverter().Convert(this, null);
            var buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            return string.Format("[&{0}]", Convert.ToBase64String(buffer));
        }
    }
}