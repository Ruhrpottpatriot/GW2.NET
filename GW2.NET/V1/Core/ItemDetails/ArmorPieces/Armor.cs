// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Armor.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.ItemDetails.Common;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemDetails.ArmorPieces
{
    /// <summary>
    /// Represents an armor piece.
    /// </summary>
    public class Armor : Item
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Armor"/> class.
        /// </summary>
        public Armor()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Armor"/> class using the specified values.
        /// </summary>
        /// <param name="itemId">The armor piece's ID.</param>
        /// <param name="name">The armor piece's name.</param>
        /// <param name="description">The armor piece's description.</param>
        /// <param name="type">The armor piece's type.</param>
        /// <param name="level">The armor piece's level.</param>
        /// <param name="rarity">The armor piece's rarity.</param>
        /// <param name="vendorValue">The armor piece's vendor value.</param>
        /// <param name="iconFileId">The armor piece's icon ID.</param>
        /// <param name="iconFileSignature">The armor piece's icon signature.</param>
        /// <param name="gameTypes">The armor piece's game types.</param>
        /// <param name="flags">The armor piece's additional flags.</param>
        /// <param name="restrictions">The armor piece's restrictions.</param>
        /// <param name="armorDetails">The armor piece's details.</param>
        public Armor(int itemId, string name, string description, ItemType type, int level, ItemRarity rarity, int vendorValue, int iconFileId, string iconFileSignature, GameTypes gameTypes, ItemFlags flags, ItemRestrictions restrictions, ArmorDetails armorDetails)
            : base(itemId, name, description, type, level, rarity, vendorValue, iconFileId, iconFileSignature, gameTypes, flags, restrictions)
        {
            this.ArmorDetails = armorDetails;
        }

        /// <summary>
        /// Gets or sets the armor piece's details.
        /// </summary>
        [JsonProperty("armor", Order = 100)]
        public ArmorDetails ArmorDetails { get; set; }
    }
}