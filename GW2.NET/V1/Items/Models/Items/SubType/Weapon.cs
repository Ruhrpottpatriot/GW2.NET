// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Weapon.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the Weapon type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

using Newtonsoft.Json;

namespace GW2DotNET.V1.Items.Models.Items.SubType
{
    /// <summary>
    /// The weapon.
    /// </summary>
    public struct Weapon
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Weapon"/> struct.
        /// </summary>
        /// <param name="type">
        /// The weapon type.
        /// </param>
        /// <param name="infusionSlots">
        /// The infusion slots.
        /// </param>
        /// <param name="maxPower">
        /// The max power.
        /// </param>
        /// <param name="minPower">
        /// The min power.
        /// </param>
        /// <param name="suffixId">
        /// The suffix id.
        /// </param>
        /// <param name="infixUpgrade">
        /// The infix upgrade.
        /// </param>
        /// <param name="defense">
        /// The defense.
        /// </param>
        /// <param name="damageType">
        /// The damage type.
        /// </param>
        [JsonConstructor]
        public Weapon(WeaponType type, IEnumerable<InfusionSlot> infusionSlots, int maxPower, int minPower, int? suffixId, InfixUpgrade infixUpgrade, int defense, WeaponDamageType damageType)
            : this()
        {
            this.DamageType = damageType;
            this.Defense = defense;
            this.InfixUpgrade = infixUpgrade;
            this.SuffixId = suffixId;
            this.MinPower = minPower;
            this.MaxPower = maxPower;
            this.InfusionSlots = infusionSlots;
            this.Type = type;
        }

        /// <summary>
        /// Enumerates all possible weapon types.
        /// </summary>
        public enum WeaponType
        {
            /// <summary>
            /// A long bow.
            /// </summary>
            LongBow,

            /// <summary>
            /// A pistol.
            /// </summary>
            Pistol,

            /// <summary>
            /// A warhorn.
            /// </summary>
            Warhorn,

            /// <summary>
            /// A sword.
            /// </summary>
            Sword,

            /// <summary>
            /// A staff.
            /// </summary>
            Staff,

            /// <summary>
            /// A hammer.
            /// </summary>
            Hammer,

            /// <summary>
            /// A trident.
            /// </summary>
            Trident,

            /// <summary>
            /// A scepter.
            /// </summary>
            Scepter,

            /// <summary>
            /// A speargun.
            /// </summary>
            Speargun,

            /// <summary>
            /// A mace.
            /// </summary>
            Mace,

            /// <summary>
            /// An axe.
            /// </summary>
            Axe,

            /// <summary>
            /// A torch.
            /// </summary>
            Torch,

            /// <summary>
            /// A dagger.
            /// </summary>
            Dagger,

            /// <summary>
            /// A shield.
            /// </summary>
            Shield,

            /// <summary>
            /// A harpoon.
            /// </summary>
            Harpoon,

            /// <summary>
            /// A greatsword.
            /// </summary>
            Greatsword,

            /// <summary>
            /// A rifle.
            /// </summary>
            Rifle,

            /// <summary>
            /// A focus.
            /// </summary>
            Focus,

            /// <summary>
            /// A short bow.
            /// </summary>
            ShortBow,

            /// <summary>
            /// A toy.
            /// </summary>
            Toy,

            /// <summary>
            /// A two handed toy.
            /// </summary>
            TwoHandedToy,
        }

        /// <summary>
        /// Enumerates all possible weapon damage types.
        /// </summary>
        public enum WeaponDamageType
        {
            /// <summary>
            /// The weapon does physical damage.
            /// </summary>
            Physical,

            /// <summary>
            /// The weapon does fire damage.
            /// </summary>
            Fire,

            /// <summary>
            /// The weapon does ice damage.
            /// </summary>
            Ice,

            /// <summary>
            /// The weapon does lightning damage.
            /// </summary>
            Lightning,
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        [JsonProperty("type")]
        public WeaponType Type
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the suffix id.
        /// </summary>
        [JsonProperty("suffix_item_id")]
        public int? SuffixId
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the minimum power.
        /// </summary>
        [JsonProperty("min_power")]
        public int MinPower
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the maximum power.
        /// </summary>
        [JsonProperty("max_power")]
        public int MaxPower
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the infusion slots.
        /// </summary>
        [JsonProperty("infusion_slots")]
        public IEnumerable<InfusionSlot> InfusionSlots
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the infix upgrade.
        /// </summary>
        [JsonProperty("infix_upgrade")]
        public InfixUpgrade InfixUpgrade
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the defense.
        /// </summary>
        [JsonProperty("defense")]
        public int Defense
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the damage type.
        /// </summary>
        [JsonProperty("damage_type")]
        public WeaponDamageType DamageType
        {
            get;
            private set;
        }
    }
}
