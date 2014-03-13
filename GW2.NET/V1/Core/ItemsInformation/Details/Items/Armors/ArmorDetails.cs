// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArmorDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about an armor piece.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.ItemsInformation.Details.Items.Armors
{
    using System;

    using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Common;

    using Newtonsoft.Json;

    /// <summary>
    ///     Represents detailed information about an armor piece.
    /// </summary>
    [JsonConverter(typeof(ArmorDetailsConverter))]
    public abstract class ArmorDetails : EquipmentDetails
    {
        /// <summary>Initializes a new instance of the <see cref="ArmorDetails"/> class.</summary>
        /// <param name="armorType">The armor type.</param>
        protected ArmorDetails(ArmorType armorType)
        {
            this.Type = armorType;
        }

        /// <summary>Gets or sets the armor.</summary>
        public Armor Armor { get; set; }

        /// <summary>
        ///     Gets or sets the armor piece's defense stat.
        /// </summary>
        [JsonProperty("defense", Order = 2)]
        public int Defense { get; set; }

        /// <summary>
        ///     Gets or sets the armor piece's type.
        /// </summary>
        [JsonProperty("type", Order = 0)]
        public ArmorType Type { get; set; }

        /// <summary>
        ///     Gets or sets the armor piece's weight class.
        /// </summary>
        [JsonProperty("weight_class", Order = 1)]
        public WeightClass WeightClass { get; set; }
    }
}