// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Bag.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.ItemDetails.Common;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemDetails.Bags
{
    /// <summary>
    /// Represents a bag.
    /// </summary>
    public class Bag : Item
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Bag"/> class.
        /// </summary>
        public Bag()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Bag"/> class using the specified values.
        /// </summary>
        /// <param name="itemId">The bag's ID.</param>
        /// <param name="name">The bag's name.</param>
        /// <param name="description">The bag's description.</param>
        /// <param name="type">The bag's type.</param>
        /// <param name="level">The bag's level.</param>
        /// <param name="rarity">The bag's rarity.</param>
        /// <param name="vendorValue">The bag's vendor value.</param>
        /// <param name="iconFileId">The bag's icon ID.</param>
        /// <param name="iconFileSignature">The bag's icon signature.</param>
        /// <param name="gameTypes">The bag's game types.</param>
        /// <param name="flags">The bag's additional flags.</param>
        /// <param name="restrictions">The bag's restrictions.</param>
        /// <param name="bagDetails">The bag's details.</param>
        public Bag(int itemId, string name, string description, ItemType type, int level, ItemRarity rarity, int vendorValue, int iconFileId, string iconFileSignature, GameTypes gameTypes, ItemFlags flags, ItemRestrictions restrictions, BagDetails bagDetails)
            : base(itemId, name, description, type, level, rarity, vendorValue, iconFileId, iconFileSignature, gameTypes, flags, restrictions)
        {
            this.BagDetails = bagDetails;
        }

        /// <summary>
        /// Gets or sets the bag's details.
        /// </summary>
        [JsonProperty("bag", Order = 100)]
        public BagDetails BagDetails { get; set; }
    }
}