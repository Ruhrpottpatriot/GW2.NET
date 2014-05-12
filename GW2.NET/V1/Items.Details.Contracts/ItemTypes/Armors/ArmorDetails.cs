// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArmorDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about an armor piece.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Armors
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Common;

    using Newtonsoft.Json;

    /// <summary>Represents detailed information about an armor piece.</summary>
    [JsonConverter(typeof(ArmorDetailsConverter))]
    public abstract class ArmorDetails : EquipmentDetails
    {
        /// <summary>Initializes a new instance of the <see cref="ArmorDetails"/> class.</summary>
        /// <param name="armorType">The armor type.</param>
        protected ArmorDetails(ArmorType armorType)
        {
            this.Type = armorType;
        }

        /// <summary>Gets or sets the armor's defense stat.</summary>
        [DataMember(Name = "defense", Order = 102)]
        public virtual int Defense { get; set; }

        /// <summary>Gets or sets the armor's weight class.</summary>
        [DataMember(Name = "weight_class", Order = 101)]
        public virtual ArmorWeightClass WeightClass { get; set; }

        /// <summary>Gets or sets the armor's type.</summary>
        [DataMember(Name = "type", Order = 100)]
        protected ArmorType Type { get; set; }
    }
}