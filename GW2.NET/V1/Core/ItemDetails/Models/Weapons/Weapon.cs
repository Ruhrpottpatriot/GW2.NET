// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Weapon.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.ItemDetails.Models.Common;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemDetails.Models.Weapons
{
    /// <summary>
    /// Represents a weapon.
    /// </summary>
    public class Weapon : Item
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Weapon"/> class.
        /// </summary>
        public Weapon()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Weapon"/> class using the specified values.
        /// </summary>
        /// <param name="itemId">The weapon's ID.</param>
        /// <param name="name">The weapon's name.</param>
        /// <param name="description">The weapon's description.</param>
        /// <param name="type">The weapon's type.</param>
        /// <param name="level">The weapon's level.</param>
        /// <param name="rarity">The weapon's rarity.</param>
        /// <param name="vendorValue">The weapon's vendor value.</param>
        /// <param name="iconFileId">The weapon's icon ID.</param>
        /// <param name="iconFileSignature">The weapon's icon signature.</param>
        /// <param name="gameTypes">The weapon's game types.</param>
        /// <param name="flags">The weapon's additional flags.</param>
        /// <param name="restrictions">The weapon's restrictions.</param>
        /// <param name="weaponDetails">The weapon's details</param>
        public Weapon(int itemId, string name, string description, ItemType type, int level, ItemRarity rarity, int vendorValue, int iconFileId, string iconFileSignature, GameTypes gameTypes, ItemFlags flags, ItemRestrictions restrictions, WeaponDetails weaponDetails)
            : base(itemId, name, description, type, level, rarity, vendorValue, iconFileId, iconFileSignature, gameTypes, flags, restrictions)
        {
            this.WeaponDetails = weaponDetails;
        }

        /// <summary>
        /// Gets or sets the weapon's details.
        /// </summary>
        [JsonProperty("weapon", Order = 100)]
        public WeaponDetails WeaponDetails { get; set; }
    }
}