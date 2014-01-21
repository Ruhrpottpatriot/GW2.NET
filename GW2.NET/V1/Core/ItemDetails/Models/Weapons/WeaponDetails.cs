// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeaponDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using GW2DotNET.V1.Core.ItemDetails.Models.Common;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemDetails.Models.Weapons
{
    /// <summary>
    /// Represents detailed information about a weapon.
    /// </summary>
    public class WeaponDetails : EquipmentDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WeaponDetails"/> class.
        /// </summary>
        public WeaponDetails()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeaponDetails"/> class using the specified values.
        /// </summary>
        /// <param name="infusionSlots">The weapon's infusion slots.</param>
        /// <param name="infixUpgrade">The weapon's infix upgrade.</param>
        /// <param name="suffixItemId">The weapon's suffix item ID.</param>
        /// <param name="type">The weapon's type.</param>
        /// <param name="damageType">The weapon's damage type.</param>
        /// <param name="minimumPower">The weapon's minimum power stat.</param>
        /// <param name="maximumPower">The weapon's maximum power stat.</param>
        /// <param name="defense">The weapon's defense stat.</param>
        public WeaponDetails(IEnumerable<InfusionSlot> infusionSlots, InfixUpgrade infixUpgrade, int? suffixItemId, WeaponType type, DamageType damageType, string minimumPower, string maximumPower, string defense)
            : base(infusionSlots, infixUpgrade, suffixItemId)
        {
            this.Type = type;
            this.DamageType = damageType;
            this.MinimumPower = minimumPower;
            this.MaximumPower = maximumPower;
            this.Defense = defense;
        }

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