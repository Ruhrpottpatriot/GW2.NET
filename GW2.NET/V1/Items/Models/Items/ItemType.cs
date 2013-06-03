// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemType.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Enumerates all possible types an item can be.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Items.Models.Items
{
    /// <summary>
    /// Enumerates all possible types an item can be.
    /// </summary>
    public enum ItemType
    {
        /// <summary>
        /// The item is a weapon.
        /// </summary>
        Weapon,

        /// <summary>
        /// The item is an upgrade component.
        /// </summary>
        UpgradeComponent,

        /// <summary>
        /// The item is a trophy.
        /// </summary>
        Trophy,

        /// <summary>
        /// The item is a trinket.
        /// </summary>
        Trinket,

        /// <summary>
        /// The item is a tool.
        /// </summary>
        Tool,

        /// <summary>
        /// The item is a mini pet.
        /// </summary>
        MiniPet,

        /// <summary>
        /// The item is a gizmo.
        /// </summary>
        Gizmo,

        /// <summary>
        /// The item is a gathering tool.
        /// </summary>
        Gathering,

        /// <summary>
        /// The item is a crafting material.
        /// </summary>
        CraftingMaterial,

        /// <summary>
        /// The item is a container.
        /// </summary>
        Container,

        /// <summary>
        /// The item is a consumable.
        /// </summary>
        Consumable,

        /// <summary>
        /// The item is a bag.
        /// </summary>
        Bag,

        /// <summary>
        /// The item occupies the back slot.
        /// </summary>
        Back,

        /// <summary>
        /// The item is an armor piece.
        /// </summary>
        Armor
    }
}