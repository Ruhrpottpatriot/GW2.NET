// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Back.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.ItemDetails.Common;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemDetails.BackPieces
{
    /// <summary>
    /// Represents a back piece.
    /// </summary>
    public class Back : Item
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Back"/> class.
        /// </summary>
        public Back()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Back"/> class using the specified values.
        /// </summary>
        /// <param name="itemId">The back piece's ID.</param>
        /// <param name="name">The back piece's name.</param>
        /// <param name="description">The back piece's description.</param>
        /// <param name="type">The back piece's type.</param>
        /// <param name="level">The back piece's level.</param>
        /// <param name="rarity">The back piece's rarity.</param>
        /// <param name="vendorValue">The back piece's vendor value.</param>
        /// <param name="iconFileId">The back piece's icon ID.</param>
        /// <param name="iconFileSignature">The back piece's icon signature.</param>
        /// <param name="gameTypes">The back piece's game types.</param>
        /// <param name="flags">The back piece's additional flags.</param>
        /// <param name="restrictions">The back piece's restrictions.</param>
        /// <param name="backDetails">The back piece's details.</param>
        public Back(int itemId, string name, string description, ItemType type, int level, ItemRarity rarity, int vendorValue, int iconFileId, string iconFileSignature, GameTypes gameTypes, ItemFlags flags, ItemRestrictions restrictions, BackDetails backDetails)
            : base(itemId, name, description, type, level, rarity, vendorValue, iconFileId, iconFileSignature, gameTypes, flags, restrictions)
        {
            this.BackDetails = backDetails;
        }

        /// <summary>
        /// Gets or sets the back piece's details.
        /// </summary>
        [JsonProperty("back", Order = 100)]
        public BackDetails BackDetails { get; set; }
    }
}