// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Armor.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for armor types.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Entities.Items
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using GW2NET.ChatLinks;
    using GW2NET.Entities.Skins;

    /// <summary>Provides the base class for armor types.</summary>
    public abstract class Armor : Item, IUpgrade, IUpgradable, ISkinnable
    {
        /// <summary>Backing field for <see cref="InfixUpgrade"/>.</summary>
        private InfixUpgrade infixUpgrade = new InfixUpgrade();

        /// <summary>Gets or sets the default skin. This is a navigation property. Use the value of <see cref="DefaultSkinId"/> to obtain a reference.</summary>
        public virtual Skin DefaultSkin { get; set; }

        /// <summary>Gets or sets the default skin identifier.</summary>
        public virtual int DefaultSkinId { get; set; }

        /// <summary>Gets or sets the armor's defense stat.</summary>
        public virtual int Defense { get; set; }

        /// <summary>Gets or sets the item's infixed combat upgrades.</summary>
        public virtual InfixUpgrade InfixUpgrade
        {
            get
            {
                return this.infixUpgrade;
            }

            set
            {
                this.infixUpgrade = value;
            }
        }

        /// <summary>Gets or sets the item's infusion slots.</summary>
        public virtual ICollection<InfusionSlot> InfusionSlots { get; set; }

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
            Contract.Ensures(Contract.Result<ChatLink>() != null);
            return new ItemChatLink
            {
                ItemId = this.ItemId, 
                SuffixItemId = this.SuffixItemId, 
                SecondarySuffixItemId = this.SecondarySuffixItemId, 
                SkinId = this.DefaultSkinId
            };
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.infixUpgrade != null);
        }
    }
}