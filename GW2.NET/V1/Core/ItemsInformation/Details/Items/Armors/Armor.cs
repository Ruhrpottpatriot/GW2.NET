// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Armor.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.Converters;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemsInformation.Details.Items.Armors
{
    /// <summary>
    ///     Represents an armor piece.
    /// </summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class Armor : Item
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Armor" /> class.
        /// </summary>
        public Armor()
            : base(ItemType.Armor)
        {
        }

        /// <summary>
        ///     Gets or sets the armor piece's details.
        /// </summary>
        [JsonProperty("armor", Order = 100)]
        public ArmorDetails ArmorDetails { get; set; }
    }
}