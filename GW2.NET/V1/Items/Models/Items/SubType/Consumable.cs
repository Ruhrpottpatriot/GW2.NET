// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Consumable.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the Consumable type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Newtonsoft.Json;

namespace GW2DotNET.V1.Items.Models.Items.SubType
{
    /// <summary>The consumable.</summary>
    [Serializable]
    public class Consumable
    {
        /// <summary>The consumable type.</summary>
        public enum ConsumableType
        {
            /// <summary>A consumable to unlock certain things.</summary>
            Unlock, 

            /// <summary>A consumable to change the appearance.</summary>
            AppearanceChange, 

            /// <summary>A consumable to summon a contract npc.</summary>
            ContractNpc, 

            /// <summary>A food consumable.</summary>
            Food, 

            /// <summary>An alcoholic beverage.</summary>
            Booze, 

            /// <summary>A generic consumable.</summary>
            Generic, 

            /// <summary>A halloween consumable.</summary>
            Halloween, 

            /// <summary>An immediate consumable.</summary>
            Immediate, 

            /// <summary>A consumable to transmute items.</summary>
            Transmutation, 

            /// <summary>An utility consumable.</summary>
            Utility, 

            /// <summary>An unknown consumable.</summary>
            Unknown
        }

        /// <summary>Initializes a new instance of the <see cref="Consumable"/> class.</summary>
        /// <param name="type">The type.</param>
        [JsonConstructor]
        public Consumable(ConsumableType type)
        {
            this.Type = type;
        }

        /// <summary>Gets the type.</summary>
        [JsonProperty("type")]
        public ConsumableType Type { get; private set; }
    }
}