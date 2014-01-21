// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Trinket.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.ItemDetails.Models.Common;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemDetails.Models.Trinkets
{
    /// <summary>
    /// Represents a trinket.
    /// </summary>
    public class Trinket : Item
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Trinket"/> class.
        /// </summary>
        public Trinket()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Trinket"/> class using the specified values.
        /// </summary>
        /// <param name="itemId">The trinket's ID.</param>
        /// <param name="name">The trinket's name.</param>
        /// <param name="description">The trinket's description.</param>
        /// <param name="type">The trinket's type.</param>
        /// <param name="level">The trinket's level.</param>
        /// <param name="rarity">The trinket's rarity.</param>
        /// <param name="vendorValue">The trinket's vendor value.</param>
        /// <param name="iconFileId">The trinket's icon ID.</param>
        /// <param name="iconFileSignature">The trinket's icon signature.</param>
        /// <param name="gameTypes">The trinket's game types.</param>
        /// <param name="flags">The trinket's additional flags.</param>
        /// <param name="restrictions">The trinket's restrictions.</param>
        /// <param name="trinketDetails">The trinket's details.</param>
        public Trinket(int itemId, string name, string description, ItemType type, int level, ItemRarity rarity, int vendorValue, int iconFileId, string iconFileSignature, GameTypes gameTypes, ItemFlags flags, ItemRestrictions restrictions, TrinketDetails trinketDetails)
            : base(itemId, name, description, type, level, rarity, vendorValue, iconFileId, iconFileSignature, gameTypes, flags, restrictions)
        {
            this.TrinketDetails = trinketDetails;
        }

        /// <summary>
        /// Gets or sets the trinket's details.
        /// </summary>
        [JsonProperty("trinket", Order = 100)]
        public TrinketDetails TrinketDetails { get; set; }
    }
}