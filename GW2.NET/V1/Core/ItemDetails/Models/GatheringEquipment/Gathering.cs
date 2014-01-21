// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Gathering.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.ItemDetails.Models.Common;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemDetails.Models.GatheringEquipment
{
    /// <summary>
    /// Represents a piece of gathering equipment.
    /// </summary>
    public class Gathering : Item
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gathering"/> class.
        /// </summary>
        public Gathering()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Gathering"/> class using the specified values.
        /// </summary>
        /// <param name="itemId">The gathering equipment's ID.</param>
        /// <param name="name">The gathering equipment's name.</param>
        /// <param name="description">The gathering equipment's description.</param>
        /// <param name="type">The gathering equipment's type.</param>
        /// <param name="level">The gathering equipment's level.</param>
        /// <param name="rarity">The gathering equipment's rarity.</param>
        /// <param name="vendorValue">The gathering equipment's vendor value.</param>
        /// <param name="iconFileId">The gathering equipment's icon ID.</param>
        /// <param name="iconFileSignature">The gathering equipment's icon signature.</param>
        /// <param name="gameTypes">The gathering equipment's game types.</param>
        /// <param name="flags">The gathering equipment's additional flags.</param>
        /// <param name="restrictions">The gathering equipment's restrictions.</param>
        /// <param name="gatheringDetails">The gathering equipment's details.</param>
        public Gathering(int itemId, string name, string description, ItemType type, int level, ItemRarity rarity, int vendorValue, int iconFileId, string iconFileSignature, GameTypes gameTypes, ItemFlags flags, ItemRestrictions restrictions, GatheringDetails gatheringDetails)
            : base(itemId, name, description, type, level, rarity, vendorValue, iconFileId, iconFileSignature, gameTypes, flags, restrictions)
        {
            this.GatheringDetails = gatheringDetails;
        }

        /// <summary>
        /// Gets or sets the gathering equipment's details.
        /// </summary>
        [JsonProperty("gathering", Order = 100)]
        public GatheringDetails GatheringDetails { get; set; }
    }
}