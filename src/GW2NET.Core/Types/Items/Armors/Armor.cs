// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Armor.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for armor types.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Items.Armors
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using ChatLinks;
    using Common;
    using Skins;

    /// <summary>Provides the base class for armor types.</summary>
    public abstract class Armor : Item, IUpgrade, IUpgradable, ISkinnable
    {
        /// <summary>Backing field for <see cref="InfixUpgrade"/>.</summary>
        private InfixUpgrade infixUpgrade = new InfixUpgrade();

        private static readonly InfusionSlot[] EmptyInfusionSlots = new InfusionSlot[0];

        private ICollection<InfusionSlot> infusionSlots = EmptyInfusionSlots;

        /// <summary>Gets or sets the default skin. This is a navigation property. Use the value of <see cref="DefaultSkinId"/> to obtain a reference.</summary>
        public virtual Skin DefaultSkin { get; set; }

        /// <summary>Gets or sets the default skin identifier.</summary>
        public virtual int DefaultSkinId { get; set; }

        /// <summary>Gets or sets the armor's defense stat.</summary>
        public virtual int Defense { get; set; }

        /// <inheritdoc />
        public virtual InfixUpgrade InfixUpgrade
        {
            get
            {
                Debug.Assert(this.infixUpgrade != null, "this.infixUpgrade != null");
                return this.infixUpgrade;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this.infixUpgrade = value;
            }
        }

        /// <summary>Gets or sets the item's infusion slots.</summary>
        public virtual ICollection<InfusionSlot> InfusionSlots
        {
            get
            {
                Debug.Assert(this.infusionSlots != null, "this.infusionSlots != null");
                return this.infusionSlots;
            }
            set
            {
                this.infusionSlots = value ?? EmptyInfusionSlots;
            }
        }

        /// <summary>Gets or sets the item's secondary suffix item. This is a navigation property. Use the value of <see cref="SecondarySuffixItemId"/> to obtain a reference.</summary>
        public virtual Item SecondarySuffixItem { get; set; }

        /// <summary>Gets or sets the item's secondary suffix item identifier.</summary>
        public virtual int? SecondarySuffixItemId { get; set; }

        /// <summary>Gets or sets the item's suffix item. This is a navigation property. Use the value of <see cref="SuffixItemId"/> to obtain a reference.</summary>
        public virtual Item SuffixItem { get; set; }

        /// <summary>Gets or sets the item's suffix item identifier.</summary>
        public virtual int? SuffixItemId { get; set; }

        /// <summary>Gets or sets the armor's weight class.</summary>
        public virtual WeightClass WeightClass { get; set; }

        /// <summary>Gets an item chat link for this item.</summary>
        /// <returns>The <see cref="ChatLink"/>.</returns>
        public override ChatLink GetItemChatLink()
        {
            return new ItemChatLink
            {
                ItemId = this.ItemId,
                SuffixItemId = this.SuffixItemId,
                SecondarySuffixItemId = this.SecondarySuffixItemId,
                SkinId = this.DefaultSkinId
            };
        }
    }
}