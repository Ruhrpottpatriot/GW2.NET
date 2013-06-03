// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpgradeComponent.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the UpgradeComponent type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace GW2DotNET.V1.Items.Models.Items.SubType
{
    public struct UpgradeComponent
    {
        public UpgradeComponent(InfixUpgrade infixUpgrade, UpgradeType type, string suffix, IEnumerable<UpgradeFlag> infusionUpgradeType, UpgradeComponentFlags flags)
            : this()
        {
            this.Flags = flags;
            this.InfusionUpgradeType = infusionUpgradeType;
            this.Suffix = suffix;
            this.Type = type;
            this.InfixUpgrade = infixUpgrade;
        }

        public UpgradeType Type
        {
            get;
            private set;
        }

        public string Suffix
        {
            get;
            private set;
        }

        public IEnumerable<UpgradeFlag> InfusionUpgradeType
        {
            get;
            private set;
        }

        public InfixUpgrade InfixUpgrade
        {
            get;
            private set;
        }

        public UpgradeComponentFlags Flags
        {
            get;
            private set;
        }

        // Enums
        public enum UpgradeComponentFlags
        {
            HeavyArmor,
            MediumArmor,
            LightArmor,
            Axe,
            Dagger,
            Focus,
            Greatsword,
            Hammer,
            Harpoon,
            LongBow,
            Mace,
            Pistol,
            Rifle,
            Scepter,
            Shield,
            ShortBow,
            Speargun,
            Staff,
            Sword,
            Torch,
            Trident,
            Trinket,
            Warhorn
        }

        public enum UpgradeType
        {
            Rune,
            Default,
            Sigil,
            Gem,
        }
    }
}