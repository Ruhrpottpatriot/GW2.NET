// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Armor.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an armor piece.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Armors
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Converters;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Common;

    using Newtonsoft.Json;

    /// <summary>Represents an armor piece.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class Armor : SkinnedItem
    {
        /// <summary>Initializes a new instance of the <see cref="Armor" /> class.</summary>
        public Armor()
            : base(ItemType.Armor)
        {
        }

        /// <summary>Gets or sets the item details.</summary>
        [DataMember(Name = "armor", Order = 1000)]
        [JsonConverter(typeof(ArmorDetailsConverter))]
        public new virtual ArmorDetails Details
        {
            get
            {
                return base.Details as ArmorDetails;
            }

            set
            {
                base.Details = value;
            }
        }
    }
}