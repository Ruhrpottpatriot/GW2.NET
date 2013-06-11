// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpgradeComponent.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the UpgradeComponent type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace GW2DotNET.V1.Items.Models.Items.SubType
{
    /// <summary>
    /// The upgrade component.
    /// </summary>
    [Serializable]
    public struct UpgradeComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpgradeComponent"/> struct.
        /// </summary>
        /// <param name="infixUpgrade">
        /// The infix upgrade.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="suffix">
        /// The suffix.
        /// </param>
        /// <param name="infusionUpgradeType">
        /// The infusion upgrade type.
        /// </param>
        /// <param name="flags">
        /// The flags.
        /// </param>
        [JsonConstructor]
        public UpgradeComponent(InfixUpgrade infixUpgrade, UpgradeType type, string suffix, IEnumerable<UpgradeFlag> infusionUpgradeType, IEnumerable<UpgradeComponentFlags> flags)
            : this()
        {
            this.Flags = flags;
            this.InfusionUpgradeType = infusionUpgradeType;
            this.Suffix = suffix;
            this.Type = type;
            this.InfixUpgrade = infixUpgrade;
        }

        /// <summary>
        /// Enumerates all upgrade component flags.
        /// </summary>
        public enum UpgradeComponentFlags
        {
            /// <summary>
            /// A heavy armor.
            /// </summary>
            HeavyArmor,

            /// <summary>
            /// A medium armor.
            /// </summary>
            MediumArmor,

            /// <summary>
            /// A light armor.
            /// </summary>
            LightArmor,

            /// <summary>
            /// An axe.
            /// </summary>
            Axe,

            /// <summary>
            /// A dagger.
            /// </summary>
            Dagger,

            /// <summary>
            /// A focus.
            /// </summary>
            Focus,

            /// <summary>
            /// A greatsword.
            /// </summary>
            Greatsword,

            /// <summary>
            /// A hammer.
            /// </summary>
            Hammer,

            /// <summary>
            /// A harpoon.
            /// </summary>
            Harpoon,

            /// <summary>
            /// A long bow.
            /// </summary>
            LongBow,

            /// <summary>
            /// A mace.
            /// </summary>
            Mace,

            /// <summary>
            /// A pistol.
            /// </summary>
            Pistol,

            /// <summary>
            /// A rifle.
            /// </summary>
            Rifle,

            /// <summary>
            /// A scepter.
            /// </summary>
            Scepter,

            /// <summary>
            /// A shield.
            /// </summary>
            Shield,

            /// <summary>
            /// A short bow.
            /// </summary>
            ShortBow,

            /// <summary>
            /// A speargun.
            /// </summary>
            Speargun,

            /// <summary>
            /// A staff.
            /// </summary>
            Staff,

            /// <summary>
            /// A sword.
            /// </summary>
            Sword,

            /// <summary>
            /// A torch.
            /// </summary>
            Torch,

            /// <summary>
            /// A trident.
            /// </summary>
            Trident,

            /// <summary>
            /// A trinket.
            /// </summary>
            Trinket,

            /// <summary>
            /// A warhorn.
            /// </summary>
            Warhorn
        }

        /// <summary>
        /// Enumerates all possible upgrade types.
        /// </summary>
        public enum UpgradeType
        {
            /// <summary>
            /// A rune.
            /// </summary>
            Rune,
            
            /// <summary>
            /// A default upgrade.
            /// </summary>
            Default,

            /// <summary>
            /// A sigil.
            /// </summary>
            Sigil,

            /// <summary>
            /// A gem.
            /// </summary>
            Gem,
        }

        /// <summary>
        /// Gets the upgrade type.
        /// </summary>
        [JsonProperty("type")]
        public UpgradeType Type
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the suffix.
        /// </summary>
        [JsonProperty("suffix")]
        public string Suffix
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the infusion upgrade type.
        /// </summary>
        [JsonProperty("infusion_upgrade_flags")]
        public IEnumerable<UpgradeFlag> InfusionUpgradeType
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
        /// Gets the flags.
        /// </summary>
        [JsonProperty("flags")]
        public IEnumerable<UpgradeComponentFlags> Flags
        {
            get;
            private set;
        }
    }
}