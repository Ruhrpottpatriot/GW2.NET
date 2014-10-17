// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Backpack.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a backpack.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Entities.Items
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    using GW2NET.ChatLinks;
    using GW2NET.Entities.Skins;

    /// <summary>Represents a backpack.</summary>
    public class Backpack : Item, IUpgrade, IUpgradable, ISkinnable
    {
        /// <summary>Gets or sets the item's buff.</summary>
        public virtual ItemBuff Buff { get; set; }

        /// <summary>Gets or sets the Condition Damage modifier.</summary>
        public virtual int ConditionDamage { get; set; }

        /// <summary>Gets or sets the default skin. This is a navigation property. Use the value of <see cref="DefaultSkinId"/> to obtain a reference.</summary>
        public virtual Skin DefaultSkin { get; set; }

        /// <summary>Gets or sets the default skin identifier.</summary>
        public virtual int DefaultSkinId { get; set; }

        /// <summary>Gets or sets the Ferocity modifier.</summary>
        public virtual int Ferocity { get; set; }

        /// <summary>Gets or sets the Healing modifier.</summary>
        public virtual int Healing { get; set; }

        /// <summary>Gets or sets the item's infusion slots.</summary>
        public virtual ICollection<InfusionSlot> InfusionSlots { get; set; }

        /// <summary>Gets or sets the Power modifier.</summary>
        public virtual int Power { get; set; }

        /// <summary>Gets or sets the Precision modifier.</summary>
        public virtual int Precision { get; set; }

        /// <summary>Gets or sets the item's secondary suffix item. This is a navigation property. Use the value of <see cref="SecondarySuffixItemId"/> to obtain a reference.</summary>
        public virtual Item SecondarySuffixItem { get; set; }

        /// <summary>Gets or sets the item's secondary suffix item identifier.</summary>
        public virtual int? SecondarySuffixItemId { get; set; }

        /// <summary>Gets or sets the item's suffix item. This is a navigation property. Use the value of <see cref="SuffixItemId"/> to obtain a reference.</summary>
        public virtual Item SuffixItem { get; set; }

        /// <summary>Gets or sets the item's suffix item identifier.</summary>
        public virtual int? SuffixItemId { get; set; }

        /// <summary>Gets or sets the Toughness modifier.</summary>
        public virtual int Toughness { get; set; }

        /// <summary>Gets or sets the Vitality modifier.</summary>
        public virtual int Vitality { get; set; }

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
    }
}