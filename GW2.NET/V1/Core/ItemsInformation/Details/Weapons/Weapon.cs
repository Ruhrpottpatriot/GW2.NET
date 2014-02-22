// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Weapon.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.Converters;
using GW2DotNET.V1.Core.ItemsInformation.Details.Common;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemsInformation.Details.Weapons
{
    /// <summary>
    /// Represents a weapon.
    /// </summary>
    [JsonConverter(typeof(DefaultConverter))]
    public class Weapon : Item
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Weapon"/> class.
        /// </summary>
        public Weapon()
            : base(ItemType.Weapon)
        {
        }

        /// <summary>
        /// Gets or sets the weapon's details.
        /// </summary>
        [JsonProperty("weapon", Order = 100)]
        public WeaponItemDetails WeaponItemDetails { get; set; }
    }
}