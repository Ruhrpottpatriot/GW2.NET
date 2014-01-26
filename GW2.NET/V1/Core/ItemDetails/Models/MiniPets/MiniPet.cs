// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MiniPet.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.ItemDetails.Models.Common;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemDetails.Models.MiniPets
{
    /// <summary>
    /// Represents a mini pet.
    /// </summary>
    public class MiniPet : Item
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MiniPet"/> class.
        /// </summary>
        public MiniPet()
            : base(ItemType.MiniPet)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MiniPet"/> class using the specified values.
        /// </summary>
        /// <param name="itemId">The mini pet's ID.</param>
        /// <param name="name">The mini pet's name.</param>
        /// <param name="description">The mini pet's description.</param>
        /// <param name="type">The mini pet's type.</param>
        /// <param name="level">The mini pet's level.</param>
        /// <param name="rarity">The mini pet's rarity.</param>
        /// <param name="vendorValue">The mini pet's vendor value.</param>
        /// <param name="iconFileId">The mini pet's icon ID.</param>
        /// <param name="iconFileSignature">The mini pet's icon signature.</param>
        /// <param name="gameTypes">The mini pet's game types.</param>
        /// <param name="flags">The mini pet's additional flags.</param>
        /// <param name="restrictions">The mini pet's restrictions.</param>
        public MiniPet(int itemId, string name, string description, ItemType type, int level, ItemRarity rarity, int vendorValue, int iconFileId, string iconFileSignature, GameTypes gameTypes, ItemFlags flags, ItemRestrictions restrictions)
            : base(itemId, name, description, type, level, rarity, vendorValue, iconFileId, iconFileSignature, gameTypes, flags, restrictions)
        {
        }
    }
}