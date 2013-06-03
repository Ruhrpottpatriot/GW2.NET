// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Weapon.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the Weapon type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace GW2DotNET.V1.Items.Models.Items.SubType
{
    public struct Weapon
    {
        public Weapon(WeaponType type, IEnumerable<InfusionSlot> infusionSlots, int maxPower, int minPower, int suffixId, InfixUpgrade infixUpgrade, int defense, WeaponDamageType damageType)
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

        public WeaponType Type
        {
            get;
            private set;
        }

        public int SuffixId
        {
            get;
            private set;
        }

        public int MinPower
        {
            get;
            private set;
        }

        public int MaxPower
        {
            get;
            private set;
        }

        public IEnumerable<InfusionSlot> InfusionSlots
        {
            get;
            private set;
        }

        public InfixUpgrade InfixUpgrade
        {
            get;
            private set;
        }

        public int Defense
        {
            get;
            private set;
        }

        public WeaponDamageType DamageType
        {
            get;
            private set;
        }

        public enum WeaponType
        {
            LongBow,

            Pistol,

            Warhorn,

            Sword,

            Staff,

            Hammer,

            Trident,

            Scepter,

            Speargun,

            Mace,

            Axe,

            Torch,

            Dagger,

            Shield,

            Harpoon,

            Greatsword,

            Rifle,

            Focus,

            ShortBow,

            Toy,

            TwoHandedToy,
        }

        public enum WeaponDamageType
        {
            Physical,
            Fire,
            Ice,
            Lightning,
        }
    }
}
