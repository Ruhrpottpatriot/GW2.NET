// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemExtensions.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides static extension methods for the <see cref="Item" /> class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.ChatLinks.Extensions
{
    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Items.Details.Contracts;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Armors;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Backs;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Common;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Weapons;

    /// <summary>Provides static extension methods for the <see cref="Item"/> class.</summary>
    public static class ItemExtensions
    {
        /// <summary>Gets a chat link for the specified item.</summary>
        /// <param name="instance">The item.</param>
        /// <returns>The <see cref="ChatLink"/>The chat link.</returns>
        public static ChatLink GetChatLink(this Item instance)
        {
            Preconditions.EnsureNotNull(instance);
            var chatLink = new ItemChatLink(instance.ItemId);
            EquipmentDetails details = null;
            var armor = instance as Armor;
            if (armor != null)
            {
                details = armor.Details;
            }
            else
            {
                var back = instance as Back;
                if (back != null)
                {
                    details = back.Details;
                }
                else
                {
                    var weapon = instance as Weapon;
                    if (weapon != null)
                    {
                        details = weapon.Details;
                    }
                }
            }

            if (details != null)
            {
                chatLink.SuffixItemId = details.SuffixItemId;
                chatLink.SecondarySuffixItemId = details.SecondarySuffixItemId;
            }

            return chatLink;
        }
    }
}