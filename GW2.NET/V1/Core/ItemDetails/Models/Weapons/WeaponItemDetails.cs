// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeaponItemDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.ItemDetails.Models.Common;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemDetails.Models.Weapons
{
    /// <summary>
    /// Represents detailed information about a weapon.
    /// </summary>
    public class WeaponItemDetails : EquipmentItemDetails
    {
        /// <summary>
        /// Gets or sets the weapon's damage type.
        /// </summary>
        [JsonProperty("damage_type", Order = 1)]
        public DamageType DamageType { get; set; }

        /// <summary>
        /// Gets or sets the weapon's defense.
        /// </summary>
        [JsonProperty("defense", Order = 4)]
        public string Defense { get; set; }

        /// <summary>
        /// Gets or sets the weapon's maximum power.
        /// </summary>
        [JsonProperty("max_power", Order = 3)]
        public string MaximumPower { get; set; }

        /// <summary>
        /// Gets or sets the weapon's minimum power.
        /// </summary>
        [JsonProperty("min_power", Order = 2)]
        public string MinimumPower { get; set; }

        /// <summary>
        /// Gets or sets the weapon's type.
        /// </summary>
        [JsonProperty("type", Order = 0)]
        public WeaponType Type { get; set; }
    }
}