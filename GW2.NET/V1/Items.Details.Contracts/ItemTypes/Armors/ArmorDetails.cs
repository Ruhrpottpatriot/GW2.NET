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
        /// <summary>Infrastructure. Stores type information.</summary>
        private readonly ArmorType type;

        /// <summary>Initializes a new instance of the <see cref="ArmorDetails"/> class.</summary>
        /// <param name="armorType">The armor type.</param>
        protected ArmorDetails(ArmorType armorType)
        {
            this.type = armorType;
        }

        /// <summary>Gets or sets the armor's defense stat.</summary>
        [DataMember(Name = "defense", Order = 2)]
        public int Defense { get; set; }

        /// <summary>Gets the armor's type.</summary>
        [DataMember(Name = "type", Order = 0)]
        public ArmorType Type
        {
            get
            {
                return this.type;
            }
        }

        /// <summary>Gets or sets the armor's weight class.</summary>
        [DataMember(Name = "weight_class", Order = 1)]
        public ArmorWeightClass WeightClass { get; set; }
    }
}