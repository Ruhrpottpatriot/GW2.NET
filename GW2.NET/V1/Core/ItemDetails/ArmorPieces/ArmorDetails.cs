// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArmorDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using GW2DotNET.V1.Core.ItemDetails.Common;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemDetails.ArmorPieces
{
    /// <summary>
    /// Represents detailed information about an armor piece.
    /// </summary>
    public class ArmorDetails : EquipmentDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArmorDetails"/> class.
        /// </summary>
        public ArmorDetails()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmorDetails"/> class using the specified values.
        /// </summary>
        /// <param name="infusionSlots">The armor piece's infusion slots.</param>
        /// <param name="infixUpgrade">The armor piece's infix upgrade.</param>
        /// <param name="suffixItemId">The armor piece's suffix item ID.</param>
        /// <param name="type">The armor piece's type.</param>
        /// <param name="weightClass">The armor piece's weight class.</param>
        /// <param name="defense">The armor piece's defense stat.</param>
        public ArmorDetails(IEnumerable<InfusionSlot> infusionSlots, InfixUpgrade infixUpgrade, int? suffixItemId, ArmorType type, WeightClass weightClass, int defense)
            : base(infusionSlots, infixUpgrade, suffixItemId)
        {
            this.Type = type;
            this.WeightClass = weightClass;
            this.Defense = defense;
        }

        /// <summary>
        /// Gets or sets the armor piece's defense stat.
        /// </summary>
        [JsonProperty("defense", Order = 2)]
        public int Defense { get; set; }

        /// <summary>
        /// Gets or sets the armor piece's type.
        /// </summary>
        [JsonProperty("type", Order = 0)]
        public ArmorType Type { get; set; }

        /// <summary>
        /// Gets or sets the armor piece's weight class.
        /// </summary>
        [JsonProperty("weight_class", Order = 1)]
        public WeightClass WeightClass { get; set; }
    }
}