// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CraftingMaterial.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.ItemDetails.Models.Common;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemDetails.Models.CraftingMaterials
{
    /// <summary>
    /// Represents a crafting material.
    /// </summary>
    public class CraftingMaterial : Item
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CraftingMaterial"/> class.
        /// </summary>
        public CraftingMaterial()
            : base(ItemType.CraftingMaterial)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CraftingMaterial"/> class using the specified values.
        /// </summary>
        /// <param name="itemId">The crafting material's ID.</param>
        /// <param name="name">The crafting material's name.</param>
        /// <param name="description">The crafting material's description.</param>
        /// <param name="type">The crafting material's type.</param>
        /// <param name="level">The crafting material's level.</param>
        /// <param name="rarity">The crafting material's rarity.</param>
        /// <param name="vendorValue">The crafting material's vendor value.</param>
        /// <param name="iconFileId">The crafting material's icon ID.</param>
        /// <param name="iconFileSignature">The crafting material's icon signature.</param>
        /// <param name="gameTypes">The crafting material's game types.</param>
        /// <param name="flags">The crafting material's additional flags.</param>
        /// <param name="restrictions">The crafting material's restrictions.</param>
        public CraftingMaterial(int itemId, string name, string description, ItemType type, int level, ItemRarity rarity, int vendorValue, int iconFileId, string iconFileSignature, GameTypes gameTypes, ItemFlags flags, ItemRestrictions restrictions)
            : base(itemId, name, description, type, level, rarity, vendorValue, iconFileId, iconFileSignature, gameTypes, flags, restrictions)
        {
        }
    }
}