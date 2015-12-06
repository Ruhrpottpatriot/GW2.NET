// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Weapon.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for weapon types.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Items
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    using GW2NET.ChatLinks;
    using GW2NET.Skins;

    /// <summary>Provides the base class for weapon types.</summary>
    public abstract class Weapon : Item, IUpgradable, IUpgrade, ISkinnable
    {
        private InfixUpgrade infixUpgrade = new InfixUpgrade();

        private static readonly InfusionSlot[] EmptyInfusionSlots = new InfusionSlot[0];

        private ICollection<InfusionSlot> infusionSlots = EmptyInfusionSlots;

        /// <summary>Gets or sets the weapon's damage type.</summary>
        public virtual DamageType DamageType { get; set; }

        /// <summary>Gets or sets the default skin. This is a navigation property. Use the value of <see cref="DefaultSkinId"/> to obtain a reference.</summary>
        public virtual Skin DefaultSkin { get; set; }

        /// <summary>Gets or sets the default skin identifier.</summary>
        public virtual int DefaultSkinId { get; set; }

        /// <summary>Gets or sets the weapon's defense.</summary>
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
                    throw new ArgumentNullException("value", "Precondition: value != null");
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

        /// <summary>Gets or sets the weapon's maximum power.</summary>
        public virtual int MaximumPower { get; set; }

        /// <summary>Gets or sets the weapon's minimum power.</summary>
        public virtual int MinimumPower { get; set; }

        /// <summary>Gets or sets the item's secondary suffix item. This is a navigation property. Use the value of <see cref="SecondarySuffixItem"/> to obtain a reference.</summary>
        public virtual Item SecondarySuffixItem { get; set; }

        /// <summary>Gets or sets the item's secondary suffix item identifier.</summary>
        public virtual int? SecondarySuffixItemId { get; set; }

        /// <summary>Gets or sets the item's suffix item. This is a navigation property. Use the value of <see cref="SuffixItemId"/> to obtain a reference.</summary>
        public virtual Item SuffixItem { get; set; }

        /// <summary>Gets or sets the item's suffix item identifier.</summary>
        public virtual int? SuffixItemId { get; set; }

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