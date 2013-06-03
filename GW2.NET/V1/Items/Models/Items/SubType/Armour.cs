// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Armour.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the Armour type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

using Newtonsoft.Json;

namespace GW2DotNET.V1.Items.Models.Items.SubType
{
    /// <summary>
    /// The armour.
    /// </summary>
    public struct Armour
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Armour"/> struct.
        /// </summary>
        /// <param name="armourClass">
        /// The armour class.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="suffixId">
        /// The suffix id.
        /// </param>
        /// <param name="infusionSlots">
        /// The infusion slots.
        /// </param>
        /// <param name="infixUpgrade">
        /// The infix upgrade.
        /// </param>
        /// <param name="defense">
        /// The defense.
        /// </param>
        [JsonConstructor]
        public Armour(ArmourClass armourClass, ArmourType type, int? suffixId, IEnumerable<InfusionSlot> infusionSlots, InfixUpgrade infixUpgrade, int defense)
            : this()
        {
            this.Defense = defense;
            this.InfixUpgrade = infixUpgrade;
            this.InfusionSlots = infusionSlots;
            this.SuffixId = suffixId;
            this.Type = type;
            this.Class = armourClass;
        }

        /// <summary>
        /// Enumerates the armour class.
        /// </summary>
        public enum ArmourClass
        {
            /// <summary>
            /// The item is clothing.
            /// </summary>
            Clothing,

            /// <summary>
            /// The item is light armour.
            /// </summary>
            Light,

            /// <summary>
            /// The item is medium armour.
            /// </summary>
            Medium,

            /// <summary>
            /// The item is heavy armour.
            /// </summary>
            Heavy
        }

        /// <summary>
        /// Enumerates the armour type.
        /// </summary>
        public enum ArmourType
        {
            /// <summary>
            /// The item belong in the boots slot.
            /// </summary>
            Boots,

            /// <summary>
            /// The item belong in the helm slot.
            /// </summary>
            Helm,

            /// <summary>
            /// The item belong in the leggings slot.
            /// </summary>
            Leggings,

            /// <summary>
            /// The item belong in the gloves slot.
            /// </summary>
            Gloves,

            /// <summary>
            /// The item belong in the shoulders slot.
            /// </summary>
            Shoulders,

            /// <summary>
            /// The item belong in the coat slot.
            /// </summary>
            Coat,

            /// <summary>
            /// The item belong in the aquatic helmet slot.
            /// </summary>
            HelmAquatic,
        }

        /// <summary>
        /// Gets the armour class.
        /// </summary>
        [JsonProperty("weight_class")]
        public ArmourClass Class
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the armour type.
        /// </summary>
        [JsonProperty("type")]
        public ArmourType Type
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
    }
}
