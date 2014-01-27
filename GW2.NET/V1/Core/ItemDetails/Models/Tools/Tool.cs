// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Tool.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.Converters;
using GW2DotNET.V1.Core.ItemDetails.Models.Common;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemDetails.Models.Tools
{
    /// <summary>
    /// Represents a tool.
    /// </summary>
    [JsonConverter(typeof(DefaultConverter))]
    public class Tool : Item
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Tool"/> class.
        /// </summary>
        public Tool()
            : base(ItemType.Tool)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tool"/> class using the specified values.
        /// </summary>
        /// <param name="itemId">The tool's ID.</param>
        /// <param name="name">The tool's name.</param>
        /// <param name="description">The tool's description.</param>
        /// <param name="type">The tool's type.</param>
        /// <param name="level">The tool's level.</param>
        /// <param name="rarity">The tool's rarity.</param>
        /// <param name="vendorValue">The tool's vendor value.</param>
        /// <param name="iconFileId">The tool's icon ID.</param>
        /// <param name="iconFileSignature">The tool's icon signature.</param>
        /// <param name="gameTypes">The tool's game types.</param>
        /// <param name="flags">The tool's additional flags.</param>
        /// <param name="restrictions">The tool's restrictions.</param>
        /// <param name="toolDetails">The tool's details.</param>
        public Tool(int itemId, string name, string description, ItemType type, int level, ItemRarity rarity, int vendorValue, int iconFileId, string iconFileSignature, GameTypes gameTypes, ItemFlags flags, ItemRestrictions restrictions, ToolDetails toolDetails)
            : base(itemId, name, description, type, level, rarity, vendorValue, iconFileId, iconFileSignature, gameTypes, flags, restrictions)
        {
            this.ToolDetails = toolDetails;
        }

        /// <summary>
        /// Gets or sets the tool's details.
        /// </summary>
        [JsonProperty("tool", Order = 100)]
        public ToolDetails ToolDetails { get; set; }
    }
}